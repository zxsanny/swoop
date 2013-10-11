'Данный класс создан TheDotNetMan   
'http://planet-source-code.com/vb/scripts/ShowCode.asp?txtCodeId=3360&lngWId=10

Imports System.IO
Imports System.Security.Cryptography

'Это пример вывода в консоль данных, собранных в классе TorrentParser
'Console.WriteLine("Announce: " & parser.Announce)
'For i As Integer = 0 To parser.AnnounceListCount - 1
'    Console.WriteLine("Announce list item " & (i + 1).ToString & ": """ & parser.AnnounceList(i) & """")
'Next
'If parser.Comment <> "" Then Console.WriteLine("Comment: " & parser.Comment)
'Console.WriteLine("Creation Date: " & parser.CreationDate & " UTC")
'If parser.Encoding <> "" Then Console.WriteLine("Encoding: " & parser.Encoding)
'Console.WriteLine("InfoHash: " & parser.InfoHash)
'If parser.IsSingleFile Then
'    Console.WriteLine("Mode: Single-file")
'    Console.WriteLine("File 1: """ & parser.Files(0).Name & """")
'Else
'    Console.WriteLine("Mode: Multi-file")
'    Console.WriteLine("File count: " & parser.FileCount)
'    For i As Integer = 0 To parser.FileCount - 1
'        Console.WriteLine("File " & (i + 1).ToString & ": """ & parser.Files(i).Path & """")
'    Next
'End If

Public Class TorrentParser
    Dim InfoHashIsFound As Boolean 'добавил, чтобы сразу после нахождения хэша выходили, а то на файле обваливается
#Region " Private variables for use with the properties "
    Private p_announce As String
    Private p_comment As String
    Private p_creationDate As Date
    Private p_encoding As String
    Private p_Files() As stFile
    Private p_InfoHash As String
    Private p_IsSingleFile As Boolean = True
    Private p_announceList() As String
#End Region

    Public Structure stFile
        Public Length As Long
        Public Path As String
        Public Name As String
        Public PieceLength As Long
        Public Pieces() As Byte
        Public md5sum As String
        Public ed2k() As Byte
        Public sha1() As Byte
    End Structure

    Private infoFile As stFile

    Public Sub New(ByVal torrentFile As BinaryReader)
        InfoHashIsFound = False 'добавил, чтобы сразу после нахождения хэша выходили, а то на файле обваливается
        If torrentFile Is Nothing Then
            Throw New Exception("Ошибка разбора файла: torrentFile cannot be null.")
        Else
            processFile(torrentFile)
        End If
    End Sub

    Private Sub processFile(ByVal torrentFile As BinaryReader)
        Do
            If torrentFile.ReadChar.ToString = "d" Then
                processDictionary(torrentFile, False, False)
            Else
                Throw New Exception("Ошибка разбора файла: Character invalid, ""d"" was expected.")
            End If
            If InfoHashIsFound = True Then Exit Sub 'добавил, чтобы сразу после нахождения хэша выходили, а то на файле обваливается
        Loop While torrentFile.ReadChar.ToString <> "e"
    End Sub

    Private Function getStringLength(ByVal torrentFile As BinaryReader) As Integer
        Dim stringLength As Integer
        Do While Char.IsDigit(Chr(torrentFile.PeekChar))
            stringLength *= 10
            stringLength += Asc(torrentFile.ReadChar) - Asc("0")
        Loop

        If torrentFile.ReadChar.ToString = ":" Then
            Return stringLength
        Else
            Throw New Exception("Ошибка разбора файла: Character invalid, "":"" was expected.")
        End If
    End Function

    Private Function getItemValue(ByVal torrentFile As BinaryReader, ByVal stringLength As Integer) As String
        Dim itemValue() As Char
        itemValue = torrentFile.ReadChars(stringLength)
        Return CStr(itemValue)
    End Function

    Private Function getItemValueByte(ByVal torrentFile As BinaryReader, ByVal stringLength As Integer) As Byte()
        Dim itemValue() As Byte
        itemValue = torrentFile.ReadBytes(stringLength)
        Return itemValue
    End Function

    Private Function getItemName(ByVal torrentFile As BinaryReader, ByVal stringLength As Integer) As String
        Dim itemName() As Char
        itemName = torrentFile.ReadChars(stringLength)
        Return CStr(itemName)
    End Function

    Private Function getIntegerNumber(ByVal torrentFile As BinaryReader) As Long
        torrentFile.ReadChar() 'the current char is "i", lets just skip this char
        Dim IsNegative As Boolean = Chr(torrentFile.PeekChar).ToString = "-"
        Dim IntegerNumber As Long
        Do While Char.IsDigit(Chr(torrentFile.PeekChar))
            IntegerNumber *= 10
            IntegerNumber += Asc(torrentFile.ReadChar) - Asc("0")
        Loop
        If torrentFile.ReadChar.ToString = "e" Then
            If IsNegative Then
                If IntegerNumber > 0 Then
                    Return -IntegerNumber
                Else
                    Throw New Exception("Ошибка разбора файла: -0 is not allowed as Integer number.")
                End If
            Else
                Return IntegerNumber
            End If
        Else
            Throw New Exception("Ошибка разбора файла: Character invalid, ""e"" was expected.")
        End If
    End Function

    Private Function getInfoHash(ByVal torrentFile As BinaryReader, ByVal infoStart As Integer, ByVal infoLength As Integer) As String
        Dim sha1 As SHA1Managed = New SHA1Managed
        Dim infoValueBytes() As Byte

        torrentFile.BaseStream.Position = infoStart
        infoValueBytes = torrentFile.ReadBytes(infoLength)

        Return BitConverter.ToString(sha1.ComputeHash(infoValueBytes)).Replace("-", "").ToLower
    End Function

    Private Sub processDictionary(ByVal torrentFile As BinaryReader, ByVal IsInfo As Boolean, ByVal IsFiles As Boolean)
        Dim stringLength As Integer
        Dim itemName As String
        Dim itemValueString As String = ""
        Dim itemValueInteger As Long
        Dim itemValueByte() As Byte = {}

        Do
            If Char.IsDigit(Chr(torrentFile.PeekChar)) Then
                stringLength = getStringLength(torrentFile)
                itemName = getItemName(torrentFile, stringLength)
                If itemName = "info" Then
                    Dim infoPositionStart As Integer = CInt(torrentFile.BaseStream.Position)
                    If torrentFile.ReadChar.ToString = "d" Then
                        processDictionary(torrentFile, True, False)
                        'Stop
                    Else
                        Throw New Exception("Ошибка разбора файла: Character invalid, ""d"" was expected.")
                    End If
                    Dim infoPositionEnd As Integer = CInt(torrentFile.BaseStream.Position)
                    p_InfoHash = getInfoHash(torrentFile, infoPositionStart, infoPositionEnd - infoPositionStart + 1)
                    InfoHashIsFound = True : Exit Sub 'добавил, чтобы сразу после нахождения хэша выходили, а то на файле обваливается
                    If p_IsSingleFile Then
                        InsertNewFile()
                    End If
                Else
                    If Chr(torrentFile.PeekChar).ToString = "i" Then
                        itemValueInteger = getIntegerNumber(torrentFile)
                    ElseIf Chr(torrentFile.PeekChar).ToString = "l" Then
                        processList(torrentFile, itemName, itemName = "path")
                        torrentFile.ReadChar()
                    ElseIf Chr(torrentFile.PeekChar).ToString = "d" Then
                        processDictionary(torrentFile, False, False)
                        torrentFile.ReadChar()
                    Else
                        stringLength = getStringLength(torrentFile)
                        Select Case itemName
                            Case "pieces", "ed2k", "sha1"
                                itemValueByte = getItemValueByte(torrentFile, stringLength)
                            Case Else
                                itemValueString = getItemValue(torrentFile, stringLength)
                        End Select
                    End If

                    If IsInfo OrElse IsFiles Then
                        Select Case itemName
                            Case "length"
                                infoFile.Length = itemValueInteger
                            Case "name"
                                infoFile.Name = itemValueString
                            Case "piece length"
                                infoFile.PieceLength = itemValueInteger
                            Case "pieces"
                                infoFile.Pieces = itemValueByte
                            Case "md5sum"
                                infoFile.md5sum = itemValueString
                            Case "ed2k"
                                infoFile.ed2k = itemValueByte
                            Case "sha1"
                                infoFile.sha1 = itemValueByte
                            Case Else
                                'TODO: Implement other info items here
                        End Select
                    Else
                        Select Case itemName
                            Case "announce"
                                p_announce = itemValueString
                            Case "comment"
                                p_comment = itemValueString
                            Case "creation date"
                                p_creationDate = DateSerial(1970, 1, 1).AddSeconds(itemValueInteger)
                            Case "encoding"
                                p_encoding = itemValueString
                            Case Else
                                'TODO: Implement other items here
                        End Select
                    End If
                End If
            ElseIf Chr(torrentFile.PeekChar).ToString = "d" Then
                torrentFile.ReadChar() 'the current char is "e", lets just skip this char
                processDictionary(torrentFile, IsInfo, IsFiles)
            ElseIf Chr(torrentFile.PeekChar).ToString = "e" Then
                Exit Do
            Else
                Throw New Exception("Ошибка разбора файла: Character invalid, a numeric character, ""d"", or ""l"" was expected.")
            End If
        Loop While Chr(torrentFile.PeekChar).ToString <> "e"
    End Sub

    Private Sub processList(ByVal torrentFile As BinaryReader, ByVal itemName As String, ByVal IsPath As Boolean)
        Dim IsFiles As Boolean
        If itemName = "files" Then
            p_IsSingleFile = False
            IsFiles = True
        End If

        Dim IsFirstTime As Boolean = True

        Do
            If IsFirstTime AndAlso Chr(torrentFile.PeekChar).ToString = "l" Then
                torrentFile.ReadChar() 'the current char is "l", lets just skip this char
            End If
            If IsPath Then
                Do
                    Dim stringLength As Integer = getStringLength(torrentFile)
                    Dim itemValue As String = getItemName(torrentFile, stringLength)
                    infoFile.Path &= "\" & itemValue
                Loop While Chr(torrentFile.PeekChar).ToString <> "e"
                InsertNewFile()
                Exit Do
                torrentFile.ReadChar()
            ElseIf Chr(torrentFile.PeekChar).ToString = "d" Then
                torrentFile.ReadChar()
                processDictionary(torrentFile, True, True)
                torrentFile.ReadChar()
            ElseIf Chr(torrentFile.PeekChar).ToString = "l" Then
                processList(torrentFile, itemName, IsPath)
            Else 'list not known, implement other here if necessary, for example, announce-list(already implemented)
                Dim stringLength As Integer
                Dim itemValue As String
                Do
                    stringLength = getStringLength(torrentFile)
                    itemValue = getItemName(torrentFile, stringLength)
                Loop While Chr(torrentFile.PeekChar).ToString <> "e"

                If itemName = "announce-list" Then
                    InsertNewAnnounce(itemValue)
                    torrentFile.ReadChar()
                End If

                Exit Do
            End If

            IsFirstTime = False
        Loop While Chr(torrentFile.PeekChar).ToString <> "e"
    End Sub

    Private Sub InsertNewFile()
        If p_Files Is Nothing Then
            ReDim p_Files(0)
        Else
            ReDim Preserve p_Files(p_Files.Length)
        End If
        If Not p_IsSingleFile Then
            infoFile.Path = infoFile.Path.Substring(1) 'Removes the "\" from start
        End If
        p_Files(p_Files.Length - 1) = infoFile
        infoFile = Nothing
    End Sub

    Private Sub InsertNewAnnounce(ByVal newAnnounce As String)
        If p_announceList Is Nothing Then
            ReDim p_announceList(0)
        Else
            ReDim Preserve p_announceList(p_announceList.Length)
        End If
        p_announceList(p_announceList.Length - 1) = newAnnounce
    End Sub

#Region " Public Properties "

    Public ReadOnly Property Announce() As String
        Get
            Return p_announce
        End Get
    End Property

    Public ReadOnly Property Comment() As String
        Get
            Return p_comment
        End Get
    End Property

    Public ReadOnly Property CreationDate() As Date
        Get
            Return p_creationDate
        End Get
    End Property

    Public ReadOnly Property Encoding() As String
        Get
            Return p_encoding
        End Get
    End Property

    Public ReadOnly Property InfoHash() As String
        Get
            Return p_InfoHash
        End Get
    End Property

    Public ReadOnly Property IsSingleFile() As Boolean
        Get
            Return p_IsSingleFile
        End Get
    End Property

    Public ReadOnly Property Files(ByVal Index As Integer) As stFile
        Get
            Return p_Files(Index)
        End Get
    End Property

    Public ReadOnly Property FileCount() As Integer
        Get
            Return p_Files.Length
        End Get
    End Property

    Public ReadOnly Property AnnounceList(ByVal Index As Integer) As String
        Get
            Return p_announceList(Index)
        End Get
    End Property

    Public ReadOnly Property AnnounceListCount() As Integer
        Get
            If p_announceList Is Nothing Then
                Return 0
            Else
                Return p_announceList.Length
            End If
        End Get
    End Property

#End Region

End Class
