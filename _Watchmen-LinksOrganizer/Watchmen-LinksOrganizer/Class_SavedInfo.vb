
<Serializable()>
Public Class Class_SavedInfo
    Private a_Site_Password As String
    Private a_Site_Username As String
    Private a_torrentClientIPAddress As String
    Private a_torrentClientPassword As String
    Private a_torrentClientUsername As String
    Private a_torrentTorrentsPath As String
    Private a_prog_DiscountGenreInSort As Boolean
    Private a_torrentClientIncomingPort As Integer
    Private a_torrentClientWhere As Byte
    Private a_Site_Cookie As String
    Private a_torrentClientAnswerFile As String
    Private a_div_tracker As String

    Private a_ProxyAuthorizationName As String
    Private a_ProxyAuthorizationPassword As String
    Private a_ProxyIPAddress As String
    Private a_ProxyPort As Integer
    Private a_ProxyAuthorization As Byte
    Private a_Proxy As Byte
    Private a_ProxyAuthorizationDomain As String

    Private a_prog_TimerStart As Decimal
    Private a_prog_ReportTemplate As String
    Private a_LimitSpeedDownloadIs As Boolean
    Private a_LimitSpeedDownloadValue As Decimal
    Private a_LimitSpeedUploadIs As Boolean
    Private a_LimitSpeedUploadValue As Decimal
    Private a_prog_PauseAfterSendCommandToTorrentClient As Integer
    Private a_prog_PauseBeforeDownloadWebPageWithCookie As Integer
    Private a_StatRepWatchmenPass As String
    Private a_StatRepNumOfTorInRep As Decimal
    Private a_StatRepPauseAfterEverySendReport As Decimal
    Private a_StatRepDelimiterBetweenLineElements As String
    Private a_StatRepIsSendStatRep As Boolean
    Private a_StatRepSendRepOnlyAboutStoredTorrents As Boolean
    Private a_Interface_CloseToTray As Boolean
    Private a_Interface_MinimizeToTray As Boolean
    Private a_Interface_RequestOnExit As Boolean
    Private a_prog_SaveTorrFilesToPath As String
    Private a_prog_SavingTorrFiles As Byte
    Private a_prog_WindowDesktopLocation As Point
    Private a_prog_WindowSize As System.Drawing.Size
    Private a_prog_SaveTorrFiles_DownloadByAnotherUser As Boolean
    Private a_prog_SaveTorrFiles_DownloadByAnotherUser_Username As String
    Private a_prog_SaveTorrFiles_DownloadByAnotherUser_Password As String
    Private a_torrentClientName As Integer
    Private a_ExtLogEnabled As Boolean
    Private a_Site_CookieAnotherUser As String
    Private a_torrentRefreshInfoFromTorFilesAlways As Boolean
    Private a_WebFindDateTorRegForNotMoreSeeds As Decimal
    Private a_DontAutoShowReports As Boolean
    Private a_WebFindDateTorRegIs As Boolean
    Private a_prog_Report_NameLinkClick As Byte
    Private a_prog_Report_NameLinkClick_AltBrowserAddress As String
    Private a_Report As Class_SavedInfoReport
    Private a_prog_ReportSeeding_ShowOnlySeedsNotMoreThanIs As Boolean
    Private a_prog_ReportSeeding_ShowOnlySeedsNotMoreThanValue As Decimal


    ''' <summary>
    ''' Web-адрес подключения к torrent-клиенту, т.е. http://[IP]:[port]/gui/?list=1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property torrentClientIPAddress As String
        Get
            Return a_torrentClientIPAddress
        End Get
        Set(ByVal value As String)
            a_torrentClientIPAddress = value
        End Set
    End Property
    ''' <summary>
    ''' Имя учетной записи подключения к торрент-клиенту
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property torrentClientUsername As String
        Get
            Return a_torrentClientUsername
        End Get
        Set(ByVal value As String)
            a_torrentClientUsername = value
        End Set
    End Property
    ''' <summary>
    ''' Пароль учетной записи подключения к торрент-клиенту
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property torrentClientPassword As String
        Get
            Return a_torrentClientPassword
        End Get
        Set(ByVal value As String)
            a_torrentClientPassword = value
        End Set
    End Property
    ''' <summary>
    ''' Имя пользователя на сайте rutracker.org
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Site_Username As String
        Get
            Return a_Site_Username
        End Get
        Set(ByVal value As String)
            a_Site_Username = value
        End Set
    End Property
    ''' <summary>
    ''' Пароль пользователя на сайте rutracker.org
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Site_Password As String
        Get
            Return a_Site_Password
        End Get
        Set(ByVal value As String)
            a_Site_Password = value
        End Set
    End Property
    ''' <summary>
    ''' Папка, в которой находятся торрент-файлы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property torrentTorrentsPath As String
        Get
            Return a_torrentTorrentsPath
        End Get
        Set(ByVal value As String)
            a_torrentTorrentsPath = value
        End Set
    End Property

    ''' <summary>
    ''' Не учитывать жанр при сортировке
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property prog_DiscountGenreInSort As Boolean
        Get
            Return a_prog_DiscountGenreInSort
        End Get
        Set(ByVal value As Boolean)
            a_prog_DiscountGenreInSort = value
        End Set
    End Property

    ''' <summary>
    ''' где находится торрент-клиент: 0 - на этом компе; 1 - на другом компе; 2 - получить ответ торрент-клиента из файла.
    ''' </summary>
    Public Property torrentClientWhere As Byte
        Get
            Return a_torrentClientWhere
        End Get
        Set(ByVal value As Byte)
            a_torrentClientWhere = value
        End Set
    End Property
    ''' <summary>
    ''' Порт входящих соединений торрент-клиента
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property torrentClientIncomingPort As Integer
        Get
            Return a_torrentClientIncomingPort
        End Get
        Set(ByVal value As Integer)
            a_torrentClientIncomingPort = value
        End Set
    End Property

    Public Property Site_Cookie As String
        Get
            Return a_Site_Cookie
        End Get
        Set(ByVal value As String)
            a_Site_Cookie = value
        End Set
    End Property

    ''' <summary>
    ''' Адрес текстового файла с ответом торрент-клиента (если нет возможности напрямую запросить торрент-клиент)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property torrentClientAnswerFile As String
        Get
            Return a_torrentClientAnswerFile
        End Get
        Set(ByVal value As String)
            a_torrentClientAnswerFile = value
        End Set
    End Property
    ''' <summary>
    ''' Список разделов и подразделов трекера в виде вырезанного куска HTML-кода
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property div_tracker As String
        Get
            Return a_div_tracker
        End Get
        Set(ByVal value As String)
            a_div_tracker = value
        End Set
    End Property

#Region "Настройки прокси-сервера"
    ''' <summary>
    ''' 0-без прокси; 1-использовать настройки прокси из Internet Explorer; 2-ручная настройка прокси
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Proxy As Byte
        Get
            Return a_Proxy
        End Get
        Set(ByVal value As Byte)
            a_Proxy = value
        End Set
    End Property

    Public Property ProxyIPAddress As String
        Get
            Return a_ProxyIPAddress
        End Get
        Set(ByVal value As String)
            a_ProxyIPAddress = value
        End Set
    End Property

    Public Property ProxyPort As Integer
        Get
            Return a_ProxyPort
        End Get
        Set(ByVal value As Integer)
            a_ProxyPort = value
        End Set
    End Property
    ''' <summary>
    ''' 0-нет авторизации; 1-использовать автонастройки авторизации текущего польз-ля; 2-ручная настройка авторизации
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ProxyAuthorization As Byte
        Get
            Return a_ProxyAuthorization
        End Get
        Set(ByVal value As Byte)
            a_ProxyAuthorization = value
        End Set
    End Property

    Public Property ProxyAuthorizationName As String
        Get
            Return a_ProxyAuthorizationName
        End Get
        Set(ByVal value As String)
            a_ProxyAuthorizationName = value
        End Set
    End Property

    Public Property ProxyAuthorizationPassword As String
        Get
            Return a_ProxyAuthorizationPassword
        End Get
        Set(ByVal value As String)
            a_ProxyAuthorizationPassword = value
        End Set
    End Property

    Public Property ProxyAuthorizationDomain As String
        Get
            Return a_ProxyAuthorizationDomain
        End Get
        Set(ByVal value As String)
            a_ProxyAuthorizationDomain = value
        End Set
    End Property
#End Region

    ''' <summary>
    ''' Раз во сколько секунд должна запускаться обработка подразделов, сек.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property prog_TimerStart As Decimal
        Get
            Return a_prog_TimerStart
        End Get
        Set(ByVal value As Decimal)
            a_prog_TimerStart = value
        End Set
    End Property
    ''' <summary>
    ''' Формат отображения информации о раздаче в отчете в форум
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property prog_ReportTemplate As String
        Get
            Return a_prog_ReportTemplate
        End Get
        Set(ByVal value As String)
            a_prog_ReportTemplate = value
        End Set
    End Property

    Public Property LimitSpeedDownloadIs As Boolean
        Get
            Return a_LimitSpeedDownloadIs
        End Get
        Set(ByVal value As Boolean)
            a_LimitSpeedDownloadIs = value
        End Set
    End Property

    Public Property LimitSpeedDownloadValue As Decimal
        Get
            Return a_LimitSpeedDownloadValue
        End Get
        Set(ByVal value As Decimal)
            a_LimitSpeedDownloadValue = value
        End Set
    End Property

    Public Property LimitSpeedUploadIs As Boolean
        Get
            Return a_LimitSpeedUploadIs
        End Get
        Set(ByVal value As Boolean)
            a_LimitSpeedUploadIs = value
        End Set
    End Property

    Public Property LimitSpeedUploadValue As Decimal
        Get
            Return a_LimitSpeedUploadValue
        End Get
        Set(ByVal value As Decimal)
            a_LimitSpeedUploadValue = value
        End Set
    End Property
    ''' <summary>
    ''' Пауза ПОСЛЕ изменения статуса раздачи, мсек
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property prog_PauseAfterSendCommandToTorrentClient As Integer
        Get
            Return a_prog_PauseAfterSendCommandToTorrentClient
        End Get
        Set(ByVal value As Integer)
            a_prog_PauseAfterSendCommandToTorrentClient = value
        End Set
    End Property
    ''' <summary>
    ''' Величина паузы перед ПЕРВОЙ попыткой закачки веб-страницы, мсек
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property prog_PauseBeforeDownloadWebPageWithCookie As Integer
        Get
            Return a_prog_PauseBeforeDownloadWebPageWithCookie
        End Get
        Set(ByVal value As Integer)
            a_prog_PauseBeforeDownloadWebPageWithCookie = value
        End Set
    End Property

    ''' <summary>
    ''' Отправлять ли статистический отчет
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StatRepIsSendStatRep As Boolean
        Get
            Return a_StatRepIsSendStatRep
        End Get
        Set(ByVal value As Boolean)
            a_StatRepIsSendStatRep = value
        End Set
    End Property

    ''' <summary>
    ''' Ключ отчёта
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StatRepWatchmenPass As String
        Get
            Return a_StatRepWatchmenPass
        End Get
        Set(ByVal value As String)
            a_StatRepWatchmenPass = value
        End Set
    End Property

    ''' <summary>
    ''' При попытке выхода из программы запрашивать подтверждение
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Interface_RequestOnExit As Boolean
        Get
            Return a_Interface_RequestOnExit
        End Get
        Set(ByVal value As Boolean)
            a_Interface_RequestOnExit = value
        End Set
    End Property
    ''' <summary>
    ''' Сворачивать в лоток
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Interface_MinimizeToTray As Boolean
        Get
            Return a_Interface_MinimizeToTray
        End Get
        Set(ByVal value As Boolean)
            a_Interface_MinimizeToTray = value
        End Set
    End Property
    ''' <summary>
    ''' Закрывать в лоток
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Interface_CloseToTray As Boolean
        Get
            Return a_Interface_CloseToTray
        End Get
        Set(ByVal value As Boolean)
            a_Interface_CloseToTray = value
        End Set
    End Property
    ''' <summary>
    ''' Сохранение тор. файла: показывать запрос(0); сохранять в преднастроенную папку (1); добавлять ссылку в файл(2)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property prog_SavingTorrFiles As Byte
        Get
            Return a_prog_SavingTorrFiles
        End Get
        Set(ByVal value As Byte)
            a_prog_SavingTorrFiles = value
        End Set
    End Property
    ''' <summary>
    ''' В какую папку сохранять скачиваемые торрент-файлы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property prog_SaveTorrFilesToPath As String
        Get
            Return a_prog_SaveTorrFilesToPath
        End Get
        Set(ByVal value As String)
            a_prog_SaveTorrFilesToPath = value
        End Set
    End Property
    ''' <summary>
    ''' Координаты расположения формы на рабочем столе
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property prog_WindowDesktopLocation As Point
        Get
            Return a_prog_WindowDesktopLocation
        End Get
        Set(ByVal value As Point)
            a_prog_WindowDesktopLocation = value
        End Set
    End Property

    Public Property prog_WindowSize As System.Drawing.Size
        Get
            Return a_prog_WindowSize
        End Get
        Set(ByVal value As System.Drawing.Size)
            a_prog_WindowSize = value
        End Set
    End Property
    ''' <summary>
    ''' Скачивать торрент-файл от имени другого пользователя
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property prog_SaveTorrFiles_DownloadByAnotherUser As Boolean
        Get
            Return a_prog_SaveTorrFiles_DownloadByAnotherUser
        End Get
        Set(ByVal value As Boolean)
            a_prog_SaveTorrFiles_DownloadByAnotherUser = value
        End Set
    End Property
    ''' <summary>
    ''' Имя пользователя при скачивании торрент-файла от имени другого пользователя
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property prog_SaveTorrFiles_DownloadByAnotherUser_Username As String
        Get
            Return a_prog_SaveTorrFiles_DownloadByAnotherUser_Username
        End Get
        Set(ByVal value As String)
            a_prog_SaveTorrFiles_DownloadByAnotherUser_Username = value
        End Set
    End Property
    ''' <summary>
    ''' Пароль пользователя при скачивании торрент-файла от имени другого пользователя
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property prog_SaveTorrFiles_DownloadByAnotherUser_Password As String
        Get
            Return a_prog_SaveTorrFiles_DownloadByAnotherUser_Password
        End Get
        Set(ByVal value As String)
            a_prog_SaveTorrFiles_DownloadByAnotherUser_Password = value
        End Set
    End Property
    ''' <summary>
    ''' Какой торрент-клиент: 1 - utorrent, 2 - Transmission
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property torrentClientName As Integer
        Get
            Return a_torrentClientName
        End Get
        Set(ByVal value As Integer)
            a_torrentClientName = value
        End Set
    End Property
    ''' <summary>
    ''' Записывать расширенный лог работы в папку с программой 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ExtLogEnabled As Boolean
        Get
            Return a_ExtLogEnabled
        End Get
        Set(ByVal value As Boolean)
            a_ExtLogEnabled = value
        End Set
    End Property
    ''' <summary>
    ''' Кукис другого пользователя, применяемый при скачивании торрент-файлов
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Site_CookieAnotherUser As String
        Get
            Return a_Site_CookieAnotherUser
        End Get
        Set(ByVal value As String)
            a_Site_CookieAnotherUser = value
        End Set
    End Property
    ''' <summary>
    ''' Получать информацию из торрент-файлов при каждой обработке
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property torrentRefreshInfoFromTorFilesAlways As Boolean
        Get
            Return a_torrentRefreshInfoFromTorFilesAlways
        End Get
        Set(ByVal value As Boolean)
            a_torrentRefreshInfoFromTorFilesAlways = value
        End Set
    End Property
    ''' <summary>
    ''' В отчёте выяснять даты регистрации торрент-файлов для количества сидов не более
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WebFindDateTorRegForNotMoreSeeds As Decimal
        Get
            Return a_WebFindDateTorRegForNotMoreSeeds
        End Get
        Set(ByVal value As Decimal)
            a_WebFindDateTorRegForNotMoreSeeds = value
        End Set
    End Property
    ''' <summary>
    ''' Не показывать отчёты автоматически
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DontAutoShowReports As Boolean
        Get
            Return a_DontAutoShowReports
        End Get
        Set(ByVal value As Boolean)
            a_DontAutoShowReports = value
        End Set
    End Property
    ''' <summary>
    ''' Выяснять даты регистрации торрент-файлов на трекере
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WebFindDateTorRegIs As Boolean
        Get
            Return a_WebFindDateTorRegIs
        End Get
        Set(ByVal value As Boolean)
            a_WebFindDateTorRegIs = value
        End Set
    End Property
    ''' <summary>
    ''' При щелчке по названию раздачи в отчёте открывать веб-страницу раздачи
    ''' </summary>
    ''' <value>0 - в браузере по умолчанию, 1 - в другом браузере (надо указать)</value>
    ''' <returns>0 - в браузере по умолчанию, 1 - в другом браузере</returns>
    ''' <remarks>Сначала думал сделать булевым, но вдруг потом ещё варианты добавятся?</remarks>
    Public Property prog_Report_NameLinkClick As Byte
        Get
            Return a_prog_Report_NameLinkClick
        End Get
        Set(ByVal value As Byte)
            a_prog_Report_NameLinkClick = value
        End Set
    End Property
    ''' <summary>
    ''' Адрес исполняемого файла альтернативного браузера
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property prog_Report_NameLinkClick_AltBrowserAddress As String
        Get
            Return a_prog_Report_NameLinkClick_AltBrowserAddress
        End Get
        Set(ByVal value As String)
            a_prog_Report_NameLinkClick_AltBrowserAddress = value
        End Set
    End Property

    Public Property Report As Class_SavedInfoReport
        Get
            Return a_Report
        End Get
        Set(ByVal value As Class_SavedInfoReport)
            a_Report = value
        End Set
    End Property
    ''' <summary>
    ''' В отчёте о сидируемых раздачах отображать только раздачи с количеством сидов не более
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property prog_ReportSeeding_ShowOnlySeedsNotMoreThanIs As Boolean
        Get
            Return a_prog_ReportSeeding_ShowOnlySeedsNotMoreThanIs
        End Get
        Set(ByVal value As Boolean)
            a_prog_ReportSeeding_ShowOnlySeedsNotMoreThanIs = value
        End Set
    End Property
    
    Public Property prog_ReportSeeding_ShowOnlySeedsNotMoreThanValue As Decimal
        Get
            Return a_prog_ReportSeeding_ShowOnlySeedsNotMoreThanValue
        End Get
        Set(ByVal value As Decimal)
            a_prog_ReportSeeding_ShowOnlySeedsNotMoreThanValue = value
        End Set
    End Property

    Public Sub New()
        a_Report = New Class_SavedInfoReport
    End Sub
End Class
