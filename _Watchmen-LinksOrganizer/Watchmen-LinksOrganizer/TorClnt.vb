Imports System.Text

''' <summary>
''' Через этот класс идёт непосредственое общение с торрент-клиентами
''' </summary>
''' <remarks></remarks>
Public Class TorClnt
    Dim tmp1, tmp2 As Integer
    Dim tmpString As String
    Public Sub ReceiveTorClientSessionToken()
        TorClientSessionToken = ""
        Select Case SavI.torrentClientName
            Case 1
                torClientAddress = frmMain.TorClntIPandPort() & "/gui/token.html?t=" & UnixTime()
                TorClientSessionToken = frmMain.DownloadWebPageWithCookie(torClientAddress, frmMain.TorClntIPandPort() & "/gui/", Encoding.GetEncoding(1252), "", 1)
                If DownloadWebPageAnswer(0) = "Error" Then Exit Sub
                tmp1 = TorClientSessionToken.IndexOf(">", 10) + 2
                tmp2 = TorClientSessionToken.IndexOf("<", tmp1) + 1
                TorClientSessionToken = Mid(TorClientSessionToken, tmp1, tmp2 - tmp1)
            Case 2
                torClientAddress = frmMain.TorClntIPandPort() & "/transmission/rpc"
                TorClientSessionToken = frmMain.DownloadWebPageWithCookie(torClientAddress, frmMain.TorClntIPandPort & "/transmission/web/", Encoding.GetEncoding(1252), "{""method"":""session-get""}", 2)
                If DownloadWebPageAnswer(0) = "Error" Then Exit Sub
                tmp1 = TorClientSessionToken.IndexOf("code")
                tmp1 = TorClientSessionToken.IndexOf(":", tmp1) + 2
                tmp2 = TorClientSessionToken.IndexOf("<", tmp1) + 1
                TorClientSessionToken = Trim(Mid(TorClientSessionToken, tmp1, tmp2 - tmp1))
        End Select
    End Sub
    Friend Function ReceivetorrentClientAnswer() As String
        Select Case SavI.torrentClientName
            Case 1
renewtoken:
                'Собираем Web-адрес подключения к торрент-клиенту
                torClientAddress = frmMain.TorClntIPandPort() & "/gui/?token=" & TorClientSessionToken & "&list=1&t=" & UnixTime()
                'Пытаемся получить данные из торрент-клиента
                tmpString = frmMain.DownloadWebPageWithCookie(torClientAddress, frmMain.TorClntIPandPort() & "/gui/", Encoding.UTF8, "", 1)
                If tmpString = "RenewToken" Then GoTo renewtoken
                Return tmpString
            Case 2
                torClientAddress = frmMain.TorClntIPandPort() & "/transmission/rpc"

                ''"comment":"http://rutracker.org/forum/viewtopic.php?t=3469674"
                ''"downloadDir":"/home/user/\u0417\u0430\u0433\u0440\u0443\u0437\u043a\u0438"
                '' --? "downloadedEver":5513570 - это, видимо, загружено всего, включая ошибки и тех.инфа
                ''"hashString":"3f8f658bfbdfc2af003eef69cfee9b8b9f10a061"
                '' --? "haveValid":5436055
                ''"leftUntilDone":97714176
                ''"name":"\u041a\u0443\u0440\u0441\u043a\u0438\u0435 \u0441\u043e\u043b\u043e\u0432\u044c\u0438"
                'todo: проверку размера добавить, и прописать проверки для всех клиентов:
                ' ---!!!!!  "sizeWhenDone":103215767
                ''"status":4
                ''"totalSize":103215767

                Return frmMain.DownloadWebPageWithCookie(torClientAddress, "", Encoding.GetEncoding(1252), _
                "{""tag"":2,""method"":""torrent-get"",""arguments"":{""fields"":[""comment"",""downloadDir"",""hashString"",""leftUntilDone"",""name"",""status"",""totalSize""]}}", 2)
        End Select
        Return ""
    End Function
    Friend Function UnixTime() As String
        Return Math.Round((Date.UtcNow.Ticks - New Date(1970, 1, 1, 0, 0, 0, 0).Ticks) / 10000)
    End Function
    Friend Sub ParsingResponseTorrentClient(ByRef torColl As List(Of torrentInfo))
        Select Case SavI.torrentClientName
            Case 1 : Call ParsingResponseTorrentClientUtorrent(torColl)
            Case 2 : Call ParsingResponseTorrentClientTransmission(torColl)
        End Select
    End Sub

    Private Sub ParsingResponseTorrentClientUtorrent(ByRef torColl As List(Of torrentInfo))
        '=========================Получили информацию, теперь вбрасываем в torrentsInfoOnlyFromTorClient===========================
        'Очищаем список, куда будем собирать инфу из торрент-клиента
        torColl.Clear() ' torrentsInfoOnlyFromTorClient.Clear()

        'Разбиваем построчно ответ торрент-клиента
        torClntAnswSpld = torrentClientAnswer.Split(vbLf)
        'Находим первую строку с инфой о торрентах
        Dim FirstLineWithTorrentInfo As Integer = -1
        For ii As Integer = 3 To torClntAnswSpld.Length - 1
            If torClntAnswSpld(ii - 3) = "]" And torClntAnswSpld(ii - 2).Contains("torrents") And _
                    torClntAnswSpld(ii - 1) = "" Then
                FirstLineWithTorrentInfo = ii
                Exit For
            End If
        Next
        If FirstLineWithTorrentInfo < 1 Then Exit Sub
        'Находим последнюю строчку с инфой о торрентах
        Dim LastLineWithTorrentInfo As Integer = -1
        For ii As Integer = torClntAnswSpld.Length - 1 To 3 Step -1
            If torClntAnswSpld(ii).Contains(",""torrentc"":") Then
                LastLineWithTorrentInfo = ii - 1
                Exit For
            End If
        Next
        If LastLineWithTorrentInfo < 1 Then Exit Sub
        Dim CurInd As Integer
        Dim Stroka As String ' сюда копируется текущее значение torClntAnswSpld(ii)
        '========Соглашение: во всех четырёх нижеследующих индексах считается, что курсор стоит слева от соответствующей кавычки=========
        Dim IndexOfFirstOpenBracket As Integer = 0
        Dim IndexOfFirstCloseBracket As Integer = 0
        Dim IndexOfSecondOpenBracket As Integer = 0
        Dim IndexOfSecondCloseBracket As Integer = 0
        Dim FirstNumbersBlock(7) As String
        Dim SecondNumbersBlock(6) As String
        '==================Соглашение об адресации: все адреса символов нумеруются с ЕДИНИЦЫ, т.е. в IndexOf в каждом случае будет добавляться  единичка=================
        'Распихиваем строки по коллекции, пример строки:
        '["933D715C55905E82728C9EA088B19AB72F17C618",137,"Dan Tharp - \"Face Down in a Pool of Dreams\" - 2007, MP3 (tracks), 192 kbps",81357250,0,0,0,0,0,0,-1,"_Фламенко и акустическая гитара (mp3)",0,1,0,0,0,150,81357250],
        'Построчно парсим ответ торрент-клиента
        For ii As Integer = FirstLineWithTorrentInfo To LastLineWithTorrentInfo
            Dim torInfo As New torrentInfo
            Stroka = torClntAnswSpld(ii)
            'Отcекаем с обоих сторон квадратные скобки и запятую в конце
            Stroka = Mid(Stroka, 2, Stroka.Length - 3)
            'extract Hash
            torInfo.Hash = Mid(Stroka, 2, 40).ToLower
            'extract status
            torInfo.Status = Val(Mid(Stroka, 44, 3))
            'Вылавливаем открывающую кавычку, после которой идёт название раздачи
            IndexOfFirstOpenBracket = Stroka.IndexOf("""", 44) + 1
            'Находим первую закрывающую кавычку
            CurInd = IndexOfFirstOpenBracket + 1
            Do
                If Mid(Stroka, CurInd, 2) = """," And Mid(Stroka, CurInd - 1, 1) <> "\" Then
                    IndexOfFirstCloseBracket = CurInd
                    Exit Do
                ElseIf Mid(Stroka, CurInd, 2) = """," And Mid(Stroka, CurInd - 2, 2) = "\\" Then
                    IndexOfFirstCloseBracket = CurInd
                    Exit Do
                Else
                    CurInd += 1
                End If
            Loop
            'вбрасываем имя раздачи
            torInfo.Name = Mid(Stroka, IndexOfFirstOpenBracket + 1, IndexOfFirstCloseBracket - IndexOfFirstOpenBracket - 1)
            'Находим вторую открывающую кавычку
            CurInd += 3
            Do
                If Mid(Stroka, CurInd, 2) = ",""" Then
                    'Смещаемся на один, чтобы получить индекс не запятой, а непосредственно кавычки
                    IndexOfSecondOpenBracket = CurInd + 1
                    Exit Do
                Else
                    CurInd += 1
                End If
            Loop
            'Находим вторую закрывающую кавычку
            CurInd += 1
            Do
                If Mid(Stroka, CurInd, 2) = """," And Mid(Stroka, CurInd - 1, 1) <> "\" Then
                    IndexOfSecondCloseBracket = CurInd
                    Exit Do
                ElseIf Mid(Stroka, CurInd, 2) = """," And Mid(Stroka, CurInd - 2, 2) = "\\" Then
                    IndexOfSecondCloseBracket = CurInd
                    Exit Do
                Else
                    CurInd += 1
                End If
            Loop

            'вбрасываем label раздачи
            torInfo.Label = Mid(Stroka, IndexOfSecondOpenBracket + 1, IndexOfSecondCloseBracket - IndexOfSecondOpenBracket - 1)

            'Теперь остались два блока одних чисел. Выделяем их в текст и сплиттим по запятым
            FirstNumbersBlock = Mid(Stroka, IndexOfFirstCloseBracket + 2, IndexOfSecondOpenBracket - IndexOfFirstCloseBracket - 3).Split(",")
            SecondNumbersBlock = Mid(Stroka, IndexOfSecondCloseBracket + 2).Split(",")
            'Теперь вносим данные
            torInfo.Size = Val(FirstNumbersBlock(0))
            torInfo.PercentProgress = Val(FirstNumbersBlock(1))
            torInfo.Downloaded = Val(FirstNumbersBlock(2))
            torInfo.Uploaded = Val(FirstNumbersBlock(3))
            torInfo.Ratio = Val(FirstNumbersBlock(4))
            torInfo.UploadSpeed = Val(FirstNumbersBlock(5))
            torInfo.DownloadSpeed = Val(FirstNumbersBlock(6))
            torInfo.ETA = Val(FirstNumbersBlock(7))

            torInfo.PeersConnected = Val(SecondNumbersBlock(0))
            torInfo.PeersInSwarm = Val(SecondNumbersBlock(1))
            torInfo.SeedsConnected = Val(SecondNumbersBlock(2))
            torInfo.SeedsInSwarm = Val(SecondNumbersBlock(3))
            torInfo.Availability = Val(SecondNumbersBlock(4))
            torInfo.TorrentQueueOrder = Val(SecondNumbersBlock(5))
            'Для тестов, можно выкинуть
            ''If torInfo.Hash = "C462AD2804DD24CA684D8ADEBA345EFDA56D7235".ToLower Then
            ''    torInfo.Hash = "C462AD2804DD24CA684D8ADEBA345EFDA56D7235".ToLower
            ''End If
            torInfo.Remaining = Val(SecondNumbersBlock(6))
            'Закончили, добавляем заполненный элемент в список
            torColl.Add(torInfo) ' torrentsInfoOnlyFromTorClient.Add(torInfo)
        Next
    End Sub

    Private Sub ParsingResponseTorrentClientTransmission(ByRef torColl As List(Of torrentInfo))
        torColl.Clear()
        Dim tmp1, tmp2 As Integer
        'Обрезаем лишнее
        tmp1 = torrentClientAnswer.IndexOf("[") + 1 '+3 'Адрес после "[{"
        tmp2 = torrentClientAnswer.LastIndexOf("]") + 2 'Адрес перед "}]"
        torrentClientAnswer = Mid(torrentClientAnswer, tmp1, tmp2 - tmp1)
        'Новый вариант парсинга - библиотекой json.net
        Dim myList As New List(Of JSONelement)
        myList = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of JSONelement))(torrentClientAnswer)


        For i As Integer = 0 To myList.Count - 1
            Dim torInfo As New torrentInfo
            torInfo.CommentText = myList(i).comment
            torInfo.DownloadDir = myList(i).downloadDir
            torInfo.Hash = myList(i).hashString
            If myList(i).leftUntilDone = 0 Then torInfo.TorrentQueueOrder = -1
            If myList(i).leftUntilDone > 0 Then torInfo.TorrentQueueOrder = 10 'Здесь можно поставить любое положительное число, просто чтобы показать, что торрент ещё закачивается
            torInfo.Remaining = myList(i).leftUntilDone
            torInfo.Name = myList(i).name
            'версия 2.22 - здесь степени двойки
            'TR_STATUS_CHECK_WAIT   = ( 1 << 0 ), /* Waiting in queue to check files */
            'TR_STATUS_CHECK        = ( 1 << 1 ), /* Checking files */
            'TR_STATUS_DOWNLOAD     = ( 1 << 2 ), /* Downloading */
            'TR_STATUS_SEED         = ( 1 << 3 ), /* Seeding */
            'TR_STATUS_STOPPED      = ( 1 << 4 )  /* Torrent is stopped */ || return finished ? _( "Finished" ) : _( "Paused" );
            'версия 2.42 - здесь непосредственно цифры
            'TR_STATUS_STOPPED        = 0, /* Torrent is stopped */       +136
            'TR_STATUS_CHECK_WAIT     = 1, /* Queued to check files */    +194
            'TR_STATUS_CHECK          = 2, /* Checking files */           +130
            'TR_STATUS_DOWNLOAD_WAIT  = 3, /* Queued to download */       +200
            'TR_STATUS_DOWNLOAD       = 4, /* Downloading */              +201
            'TR_STATUS_SEED_WAIT      = 5, /* Queued to seed */           +200
            'TR_STATUS_SEED           = 6  /* Seeding */                  +201

            Select Case myList(i).status
                Case "1" : torInfo.Status = 194
                Case "2" : torInfo.Status = 130
                Case "3", "5" : torInfo.Status = 200
                Case "4" : torInfo.Status = 201
                Case "6", "8" : torInfo.Status = 201
                Case "0", "16" : torInfo.Status = 136
            End Select

            torInfo.Size = myList(i).totalSize

            torColl.Add(torInfo)
        Next



        '======Старый вариант============================================
        'Dim ansSplit() As String = torrentClientAnswer.Split("},{")
        'Dim i, j As Integer
        'If ansSplit.Length > 1 Then
        '    'Отрежем ",{" в начале элементов
        '    For i = 1 To ansSplit.Length - 1
        '        ansSplit(i) = Mid(ansSplit(i), 3)
        '    Next
        'End If
        'Dim SplitLine() As String, SplitElem(1) As String
        'For i = 0 To ansSplit.Length - 1
        '    Dim torInfo As New torrentInfo
        '    Dim splStr As String = ","""
        '    SplitLine = ansSplit(i).Split(splStr)
        '    'у первого элемента отрежем открывающую кавычку
        '    SplitLine(0) = Mid(SplitLine(0), 2)
        '    For j = 0 To SplitLine.Length - 1
        '        'Нарастим кавычку в начале
        '        SplitElem(0) = """" & Mid(SplitLine(j), 1, SplitLine(j).IndexOf(":"))
        '        SplitElem(1) = Mid(SplitLine(j), SplitLine(j).IndexOf(":") + 2)
        '        Select Case SplitElem(0)
        '            Case """comment""" ' "comment":"http://rutracker.org/forum/viewtopic.php?t=3359412"
        '                torInfo.CommentText = Mid(SplitElem(1), 2, SplitElem(1).Length - 2)
        '            Case """downloadDir""" ' "downloadDir":"/home/user/Hranitel"
        '                torInfo.DownloadDir = Mid(SplitElem(1), 2, SplitElem(1).Length - 2).Replace("\", "%")
        '                torInfo.DownloadDir = System.Web.HttpUtility.UrlDecode(torInfo.DownloadDir)
        '            Case """hashString""" ' "hashString":"27d0b62dad7650c2fd261ea0c4b32693a58c7a49"
        '                torInfo.Hash = Mid(SplitElem(1), 2, SplitElem(1).Length - 2)
        '            Case """leftUntilDone"""
        '                If Val(SplitElem(1)) = 0 Then torInfo.TorrentQueueOrder = -1
        '                If Val(SplitElem(1)) > 0 Then torInfo.TorrentQueueOrder = 10 'Здесь можно поставить любое положительное число, просто чтобы показать, что торрент ещё закачивается
        '                torInfo.Remaining = Val(SplitElem(1))
        '            Case """name""" ' "name":"OVA - \u041d\u0435\u0436\u043d\u043e\u0441\u0442\u044c (2010)"
        '                torInfo.Name = Mid(SplitElem(1), 2, SplitElem(1).Length - 2).Replace("\", "%")
        '                torInfo.Name = System.Web.HttpUtility.UrlDecode(torInfo.Name)
        '            Case """status""" ' "status":8
        '                'TR_STATUS_CHECK_WAIT   = ( 1 << 0 ), /* Waiting in queue to check files */
        '                'TR_STATUS_CHECK        = ( 1 << 1 ), /* Checking files */
        '                'TR_STATUS_DOWNLOAD     = ( 1 << 2 ), /* Downloading */
        '                'TR_STATUS_SEED         = ( 1 << 3 ), /* Seeding */
        '                'TR_STATUS_STOPPED      = ( 1 << 4 )  /* Torrent is stopped */ || return finished ? _( "Finished" ) : _( "Paused" );
        '                Select Case SplitElem(1)
        '                    Case "1" : torInfo.Status = 194
        '                    Case "2" : torInfo.Status = 130
        '                    Case "4" : torInfo.Status = 201
        '                    Case "8" : torInfo.Status = 201
        '                    Case "16" : torInfo.Status = 136
        '                End Select
        '            Case """totalSize""" ' "totalSize":35810753
        '                torInfo.Size = Val(SplitElem(1))
        '        End Select
        '    Next
        '    torColl.Add(torInfo)
        'Next
    End Sub

    ''' <summary>
    ''' Изменяем метку раздачи (в клиентах, поддерживающих это)
    ''' </summary>
    ''' <param name="Hash"></param>
    ''' <param name="NewLabel"></param>
    ''' <param name="AllCom"></param>
    ''' <param name="CountOfAdded"></param>
    ''' <param name="IsFinal"></param>
    ''' <remarks></remarks>
    Friend Sub TorrentChangeLabel(ByVal Hash As String, ByVal NewLabel As String, ByRef AllCom As String, ByRef CountOfAdded As Integer, ByVal IsFinal As Boolean)
        Select Case SavI.torrentClientName
            Case 1 'http://192.168.0.102:56238/gui/?token=ТОКЕН&action=setprops&s=label&hash=ХЭШ&v=test&t=1299501811246
                AddAndSendCom(frmMain.TorClntIPandPort() & "/gui/?token=" & TorClientSessionToken & "&action=setprops" & "&t=" & UnixTime(), _
                              "&hash=" & Hash & "&s=label&v=" & System.Web.HttpUtility.UrlEncode(NewLabel), _
                              AllCom, CountOfAdded, IsFinal) 'Последний параметр жестко задан False, чтобы последний прогон гарантированно был один раз в конце цикла
        End Select
    End Sub
    Friend Sub TorrentStart(ByVal torColl As List(Of torrentInfo), ByVal IndexOfTorInTorColl As Integer, ByRef AllCom As String, ByRef CountOfAdded As Integer, ByVal IsFinal As Boolean, ByVal ForceStart As Boolean)
        Select Case SavI.torrentClientName
            Case 1 'http://192.168.0.102:56238/gui/?token=ТОКЕН&action=start&hash=ХЭШ&list=1&getmsg=1&t=1299509973663
                AddAndSendCom(frmMain.TorClntIPandPort() & "/gui/?token=" & TorClientSessionToken & IIf(ForceStart = True, "&action=forcestart", "&action=start") & "&t=" & UnixTime(), _
                              "&hash=" & torColl(IndexOfTorInTorColl).Hash, _
                              AllCom, CountOfAdded, IsFinal) 'Последний параметр жестко задан False, чтобы последний прогон гарантированно был один раз в конце цикла
            Case 2 '{"method":"torrent-start","arguments":{"ids":[
                AddAndSendCom("{""method"":""torrent-start"",""arguments"":{""ids"":[", _
                              CStr(IIf(CountOfAdded > 0, ",", "")) & """" & torColl(IndexOfTorInTorColl).Hash & """", _
                              AllCom, CountOfAdded, IsFinal) 'Последний параметр жестко задан False, чтобы последний прогон гарантированно был один раз в конце цикла
                ''AddAndSendCom("{""tag"":0,""method"":""torrent-start"",""arguments"":{", _
                ''              CStr(IIf(CountOfAdded > 0, ",", "")) & """" & torColl(IndexOfTorInTorColl).Hash & """", _
                ''              AllCom, CountOfAdded, IsFinal) 'Последний параметр жестко задан False, чтобы последний прогон гарантированно был один раз в конце цикла
        End Select
    End Sub
    Friend Sub TorrentStop(ByVal torColl As List(Of torrentInfo), ByVal IndexOfTorInTorColl As Integer, ByRef AllCom As String, ByRef CountOfAdded As Integer, ByVal IsFinal As Boolean)
        Select Case SavI.torrentClientName
            Case 1 'http://192.168.0.102:56238/gui/?token=ТОКЕН&action=stop&hash=ХЭШ&list=1&getmsg=1&t=1299509973663
                AddAndSendCom(frmMain.TorClntIPandPort() & "/gui/?token=" & TorClientSessionToken & "&action=stop" & "&t=" & UnixTime(), _
                              "&hash=" & torColl(IndexOfTorInTorColl).Hash, _
                              AllCom, CountOfAdded, IsFinal) 'Последний параметр жестко задан False, чтобы последний прогон гарантированно был один раз в конце цикла
            Case 2
                AddAndSendCom("{""method"":""torrent-stop"",""arguments"":{""ids"":[", _
                              CStr(IIf(CountOfAdded > 0, ",", "")) & """" & torColl(IndexOfTorInTorColl).Hash & """", _
                              AllCom, CountOfAdded, IsFinal) 'Последний параметр жестко задан False, чтобы последний прогон гарантированно был один раз в конце цикла
                ''AddAndSendCom("{""tag"":0,""method"":""torrent-stop"",""arguments"":{", _
                ''         CStr(IIf(CountOfAdded > 0, ",", "")) & """" & torColl(IndexOfTorInTorColl).Hash & """", _
                ''         AllCom, CountOfAdded, IsFinal) 'Последний параметр жестко задан False, чтобы последний прогон гарантированно был один раз в конце цикла
        End Select
    End Sub
    Friend Sub AddAndSendCom(ByRef StartCom As String, ByRef AddedCom As String, ByRef AllCom As String, ByRef CountOfAdded As Integer, ByRef IsFinal As Boolean)
        If CountOfAdded = 0 Then AllCom = StartCom
        AllCom &= AddedCom
        If AddedCom.Length > 0 Then CountOfAdded += 1 'Нужно при последнем прогоне, когда IsFinal = True, но AddedCom = ""
        If CountOfAdded = 50 Or IsFinal = True Then
            If CountOfAdded > 0 Then 'Если есть, что посылать, то посылаем
                Select Case SavI.torrentClientName
                    Case 1 : frmMain.DownloadWebPageWithCookie(AllCom, frmMain.TorClntIPandPort & "/gui/", Encoding.Default, "", 1)
                    Case 2 : frmMain.DownloadWebPageWithCookie(frmMain.TorClntIPandPort() & "/transmission/rpc", frmMain.TorClntIPandPort & "/transmission/web/", Encoding.Default, AllCom & "]}}", 2)
                End Select
            End If
            CountOfAdded = 0
            System.Threading.Thread.Sleep(SavI.prog_PauseAfterSendCommandToTorrentClient)
        End If
    End Sub

    ''' <summary>
    ''' ON - включить, OFF - вернуть назад
    ''' </summary>
    ''' <param name="input"></param>
    ''' <remarks></remarks>
    Friend Sub LimitSpeedTorrentClient(ByVal input As String)
        If input = "ON" Then
            '1) выясняем текущие настройки скоростей торрент-клиента
            Select Case SavI.torrentClientName
                Case 1 'http://192.168.100.75:56238/gui/?token=ТОКЕН&action=getsettings&t=1299309988555
                    torClientAddress = frmMain.TorClntIPandPort() & "/gui/?token=" & TorClientSessionToken & "&action=getsettings&t=" & UnixTime()
                    TorClntSettings = frmMain.DownloadWebPageWithCookie(torClientAddress, frmMain.TorClntIPandPort() & "/gui/", Encoding.UTF8, "", 1)
                    SpeedInTorrentClientDownload = CDec(Val(Mid(TorClntSettings, TorClntSettings.IndexOf("""max_dl_rate""") + 18)))
                    SpeedInTorrentClientUpload = CDec(Val(Mid(TorClntSettings, TorClntSettings.IndexOf("""max_ul_rate""") + 18)))
                Case 2
                    torClientAddress = frmMain.TorClntIPandPort() & "/transmission/rpc"
                    TorClntSettings = frmMain.DownloadWebPageWithCookie(torClientAddress, "", Encoding.UTF8, "{""tag"":0,""method"":""session-get"",""arguments"":{}}", 2)
                    SpeedInTorrentClientDownload = Val(Mid(TorClntSettings, TorClntSettings.IndexOf("speed-limit-down") + 19, 15))
                    SpeedInTorrentClientDownloadEnabled = CBool(IIf(Mid(TorClntSettings, TorClntSettings.IndexOf("speed-limit-down-enabled") + 27, 5).Contains("true"), True, False))
                    SpeedInTorrentClientUpload = Val(Mid(TorClntSettings, TorClntSettings.IndexOf("speed-limit-up") + 17, 15))
                    SpeedInTorrentClientUploadEnabled = CBool(IIf(Mid(TorClntSettings, TorClntSettings.IndexOf("speed-limit-up-enabled") + 25, 5).Contains("true"), True, False))
            End Select
            '2) Собираем и применяем управляющую команду
            Select Case SavI.torrentClientName
                Case 1 'Пример команды: http://[IP]:[PORT]/gui/?token=ТОКЕН&action=setsetting&t=UNIXTIME&s=max_ul_rate&v=10&s=max_dl_rate&v=40
                    torClientAddress = frmMain.TorClntIPandPort() & "/gui/?token=" & TorClientSessionToken & "&action=setsetting&t=" & UnixTime()
                    IsNeedPauseBeforeWebRequests = False
                    If SavI.LimitSpeedUploadIs = True Then
                        If SpeedInTorrentClientUpload > 0D And SpeedInTorrentClientUpload <= SavI.LimitSpeedUploadValue Then
                            'В этом случае ничего не делаем, скорость и так укладывается в рамки
                        Else
                            torClientAddress &= "&s=max_ul_rate&v=" & Trim(SavI.LimitSpeedUploadValue.ToString)
                            IsNeedPauseBeforeWebRequests = True
                        End If
                    End If
                    If SavI.LimitSpeedDownloadIs = True Then
                        If SpeedInTorrentClientDownload > 0D And SpeedInTorrentClientDownload <= SavI.LimitSpeedDownloadValue Then
                            'В этом случае ничего не делаем, скорость и так укладывается в рамки
                        Else
                            torClientAddress &= "&s=max_dl_rate&v=" & Trim(SavI.LimitSpeedDownloadValue.ToString)
                            IsNeedPauseBeforeWebRequests = True
                        End If
                    End If
                    'Применяем, если надо
                    If IsNeedPauseBeforeWebRequests = True Then
                        frmMain.DownloadWebPageWithCookie(torClientAddress, frmMain.TorClntIPandPort() & "/gui/", Encoding.GetEncoding(1252), "", 1)
                    End If
                Case 2 '       {"tag":0,"method":"session-set","arguments":{"speed-limit-down":100,"speed-limit-down-enabled":true,"speed-limit-up":100,"speed-limit-up-enabled":true}}
                    '{"tag":2,"method":"session-set","arguments":{"fields":["speed-limit-down":70,"speed-limit-down-enabled":true,"speed-limit-up":70,"speed-limit-up-enabled":rue]}}
                    torClientAddress = "{""tag"":0,""method"":""session-set"",""arguments"":{"
                    IsNeedPauseBeforeWebRequests = False
                    If SavI.LimitSpeedUploadIs = True Then
                        If SpeedInTorrentClientUpload > 0D And SpeedInTorrentClientUpload <= SavI.LimitSpeedUploadValue And SpeedInTorrentClientUploadEnabled = True Then
                            'В этом случае ничего не делаем, скорость и так укладывается в рамки
                        Else
                            torClientAddress &= """speed-limit-up"":" & Trim(SavI.LimitSpeedUploadValue.ToString) & ","
                            torClientAddress &= """speed-limit-up-enabled"":true"
                            IsNeedPauseBeforeWebRequests = True
                        End If
                    End If
                    If SavI.LimitSpeedDownloadIs = True Then
                        torClientAddress &= IIf(IsNeedPauseBeforeWebRequests = True, ",", "")
                        If SpeedInTorrentClientDownload > 0D And SpeedInTorrentClientDownload <= SavI.LimitSpeedDownloadValue And SpeedInTorrentClientDownloadEnabled = True Then
                            'В этом случае ничего не делаем, скорость и так укладывается в рамки
                        Else
                            torClientAddress &= """speed-limit-down"":" & Trim(SavI.LimitSpeedDownloadValue.ToString) & ","
                            torClientAddress &= """speed-limit-down-enabled"":true"
                            IsNeedPauseBeforeWebRequests = True
                        End If
                    End If
                    torClientAddress &= "}}"
                    'Применяем, если надо
                    If IsNeedPauseBeforeWebRequests = True Then
                        frmMain.DownloadWebPageWithCookie(frmMain.TorClntIPandPort() & "/transmission/rpc", "", Encoding.GetEncoding(1252), torClientAddress, 2)
                    End If
            End Select
        End If

        If input = "OFF" Then
            If IsNeedPauseBeforeWebRequests = True Then
                Select Case SavI.torrentClientName
                    Case 1
                        torClientAddress = frmMain.TorClntIPandPort() & "/gui/?token=" & TorClientSessionToken & "&t=" & UnixTime() & _
                            "&action=setsetting&s=max_ul_rate&v=" & Trim(SpeedInTorrentClientUpload) & "&s=max_dl_rate&v=" & Trim(SpeedInTorrentClientDownload)
                        frmMain.DownloadWebPageWithoutCookie(torClientAddress, System.Text.Encoding.UTF8, SavI.torrentClientUsername, SavI.torrentClientPassword)
                    Case 2
                        torClientAddress = "{""tag"":0,""method"":""session-set"",""arguments"":{"
                        torClientAddress &= """speed-limit-up"":" & SpeedInTorrentClientUpload & ","
                        torClientAddress &= """speed-limit-up-enabled"":" & SpeedInTorrentClientDownloadEnabled.ToString.ToLower & ","
                        torClientAddress &= """speed-limit-down"":" & SpeedInTorrentClientDownload & ","
                        torClientAddress &= """speed-limit-down-enabled"":" & SpeedInTorrentClientDownloadEnabled.ToString.ToLower & "}}"
                        frmMain.DownloadWebPageWithCookie(frmMain.TorClntIPandPort() & "/transmission/rpc", "", Encoding.GetEncoding(1252), torClientAddress, 2)
                End Select
            End If
        End If
    End Sub
End Class
