<Serializable()>
Public Class Class_SavedInfoReport
    Private a_ReportAddTextBeforeReport As String
    Private a_ReportAddTextAfterEveryXTorrentsValue As Decimal
    Private a_ReportAddTextAfterEveryXTorrentsTxt As String
    Private a_ReportAddTextAfterReportMoreThanXBytesValue As Decimal
    Private a_ReportAddTextAfterReportMoreThanXBytesTxt As String
    Private a_ReportAddTextAfterReport As String
    Private a_Template As String

    ''' <summary>
    ''' Перед началом отчёта в форум добавлять следующий текст:
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReportAddTextBeforeReport As String
        Get
            Return a_ReportAddTextBeforeReport
        End Get
        Set(ByVal value As String)
            a_ReportAddTextBeforeReport = value
        End Set
    End Property
    ''' <summary>
    ''' После каждых Х раздач...
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReportAddTextAfterEveryXTorrentsValue As Decimal
        Get
            Return a_ReportAddTextAfterEveryXTorrentsValue
        End Get
        Set(ByVal value As Decimal)
            a_ReportAddTextAfterEveryXTorrentsValue = value
        End Set
    End Property
    ''' <summary>
    ''' ... добавлять следующий текст:
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReportAddTextAfterEveryXTorrentsTxt As String
        Get
            Return a_ReportAddTextAfterEveryXTorrentsTxt
        End Get
        Set(ByVal value As String)
            a_ReportAddTextAfterEveryXTorrentsTxt = value
        End Set
    End Property
    ''' <summary>
    ''' По достижении отчётом размера Х байт...
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReportAddTextAfterReportMoreThanXBytesValue As Decimal
        Get
            Return a_ReportAddTextAfterReportMoreThanXBytesValue
        End Get
        Set(ByVal value As Decimal)
            a_ReportAddTextAfterReportMoreThanXBytesValue = value
        End Set
    End Property
    ''' <summary>
    ''' ...добавлять следующий текст:
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReportAddTextAfterReportMoreThanXBytesTxt As String
        Get
            Return a_ReportAddTextAfterReportMoreThanXBytesTxt
        End Get
        Set(ByVal value As String)
            a_ReportAddTextAfterReportMoreThanXBytesTxt = value
        End Set
    End Property
    ''' <summary>
    ''' В конце отчета добавлять следующий текст:
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReportAddTextAfterReport As String
        Get
            Return a_ReportAddTextAfterReport
        End Get
        Set(ByVal value As String)
            a_ReportAddTextAfterReport = value
        End Set
    End Property
    ''' <summary>
    ''' Формат отображения информации о раздаче в отчете в форум
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Template As String
        Get
            Return a_Template
        End Get
        Set(ByVal value As String)
            a_Template = value
        End Set
    End Property

    Public Sub New()
        a_ReportAddTextBeforeReport = "[spoiler=""Раздачи, взятые на хранение""]" & Environment.NewLine
        a_ReportAddTextAfterEveryXTorrentsValue = 10
        a_ReportAddTextAfterEveryXTorrentsTxt = Environment.NewLine
        a_ReportAddTextAfterReportMoreThanXBytesValue = 100000
        a_ReportAddTextAfterReportMoreThanXBytesTxt = _
            "[/spoiler]" & Environment.NewLine & Environment.NewLine & _
            "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" & Environment.NewLine & Environment.NewLine & _
            "[spoiler=""Раздачи, взятые на хранение""]"
        a_ReportAddTextAfterReport = "[/spoiler]"
        a_Template = ""

    End Sub
End Class
