''' <summary>
''' При парсинге JSON библиотекой JSON.NET создаётся и заполняется очередной экземпляр
''' </summary>
''' <remarks></remarks>
Public Class JSONelement
    Private a_comment As String
    Private a_downloadDir As String
    Private a_hashString As String
    Private a_leftUntilDone As Double
    Private a_name As String
    Private a_status As Integer
    Private a_totalSize As Double

    Public Property comment As String
        Get
            Return a_comment
        End Get
        Set(ByVal value As String)
            a_comment = value
        End Set
    End Property

    Public Property downloadDir As String
        Get
            Return a_downloadDir
        End Get
        Set(ByVal value As String)
            a_downloadDir = value
        End Set
    End Property

    Public Property hashString As String
        Get
            Return a_hashString
        End Get
        Set(ByVal value As String)
            a_hashString = value
        End Set
    End Property

    Public Property leftUntilDone As Double
        Get
            Return a_leftUntilDone
        End Get
        Set(ByVal value As Double)
            a_leftUntilDone = value
        End Set
    End Property

    Public Property name As String
        Get
            Return a_name
        End Get
        Set(ByVal value As String)
            a_name = value
        End Set
    End Property

    Public Property status As Integer
        Get
            Return a_status
        End Get
        Set(ByVal value As Integer)
            a_status = value
        End Set
    End Property

    Public Property totalSize As Double
        Get
            Return a_totalSize
        End Get
        Set(ByVal value As Double)
            a_totalSize = value
        End Set
    End Property
End Class
