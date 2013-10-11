Imports System.Windows.Forms
Module Module1
    ''' <summary>
    ''' Происходит ли обработка
    ''' </summary>
    ''' <remarks></remarks>
    Public ObrabotkaStartovala As Boolean = False
    Public ObrabotkaStartovalaByTimer As Boolean = True
    Public myException As Exception
    'Блок команд, ограничивающих скорость торрент-клиента перед обработкой
    Public TorClntSettings As String
    ''' <summary>
    ''' Скорость закачки в торрент-клиенте (по умолчанию)
    ''' </summary>
    ''' <remarks></remarks>
    Public SpeedInTorrentClientDownload As Decimal
    Public SpeedInTorrentClientDownloadEnabled As Boolean
    ''' <summary>
    ''' Скорость отдачи в торрент-клиенте (по умолчанию)
    ''' </summary>
    ''' <remarks></remarks>
    Public SpeedInTorrentClientUpload As Decimal
    Public SpeedInTorrentClientUploadEnabled As Boolean
    ''' <summary>
    ''' Если применялась команда притормаживания к торрент-клиенту, то для применения скоростей необходима пауза
    ''' </summary>
    ''' <remarks></remarks>
    Public IsNeedPauseBeforeWebRequests As Boolean = False
    'End of Блок команд, ограничивающих скорость торрент-клиента перед обработкой

    Public StageOfWork As String 'Текущая стадия работы программы
    Public WebClient As New System.Net.WebClient()
    ''' <summary>
    ''' В этом текстовом массиве храним ответ функции DownloadWebPageWithoutCookie.
    ''' </summary>
    ''' <remarks>В индексе 0 - или "0", или "Error"; в индексе 1 - текст ошибки, т.е. ex.message</remarks>
    Public DownloadWebPageAnswer(1) As String
    ''' <summary>
    ''' Сохраняемые в файл настройки
    ''' </summary>
    ''' <remarks></remarks>
    Public SavI As New Class_SavedInfo

    Public myFolder As New FolderBrowserDialog
    Public myOpenFile As New OpenFileDialog
    Public mySaveFile As New SaveFileDialog
    
    ''' <summary>
    ''' ID (токен) сессии с торрент-клиентом
    ''' </summary>
    ''' <remarks></remarks>
    Public TorClientSessionToken As String = ""
    ''' <summary>
    ''' Собранный Web-адрес
    ''' </summary>
    ''' <remarks></remarks>
    Public torClientAddress As String = ""
    ''' <summary>
    ''' Прокси-сервер для доступа к сайту (и пока также к торрент-клиенту)
    ''' </summary>
    ''' <remarks></remarks>
    Public ProxyWeb As New System.Net.WebProxy
    ''' <summary>
    ''' Количество ошибок при проверке настроек в Настройках
    ''' </summary>
    ''' <remarks></remarks>
    Public VerifySettings_NumberOfErrors As Integer
    Friend ForumParser As New Class_ForumParser
    Public rutrackerorg As New Class_rutrackerorg
    Public TC As New TorClnt
    ''' <summary>
    ''' Список данных, полученных из торрент-файлов 
    ''' </summary>
    ''' <remarks></remarks>
    Public ListOfInfoFromTorrentFiles As New Class_ListOfInfoFromTorrentFiles
    'Public TorrFilesErrors As New System.Text.StringBuilder With {.Capacity = 10000}
    ''' <summary>
    ''' Ответ торрент-клиента, т.е .список со статусами раздач
    ''' </summary>
    ''' <remarks></remarks>
    Public torrentClientAnswer As String
    ''' <summary>
    ''' Массив строк, из которых состоял ответ торрент-клиента
    ''' </summary>
    ''' <remarks></remarks>
    Public torClntAnswSpld() As String
    ''' <summary>
    ''' Сюда собирается вся информация из всех источников
    ''' </summary>
    ''' <remarks></remarks>
    Public torrentsCollection As New List(Of torrentInfo)
    ''' <summary>
    ''' Сюда - информация ТОЛЬКО из торрент-клиента
    ''' </summary>
    ''' <remarks></remarks>
    Public torrentsInfoOnlyFromTorClientInfrmSaveLoad As New List(Of torrentInfo)
    
    'Этот блок переменных отвечает за вход на сайт
    Public myHttpWebRequest As System.Net.HttpWebRequest
    Public myHttpWebResponse As System.Net.HttpWebResponse
    ''' <summary>
    ''' Текст капчи, вводимый пользователем в форме frmCaptcha
    ''' </summary>
    ''' <remarks></remarks>
    Public Captcha As String
    ''' <summary>
    ''' Флаг, указывающий, что текст капчи введён и можно пробовать получить кукис
    ''' </summary>
    ''' <remarks></remarks>
    Public CaptchaURL As String
    Public CaptchaTextIsWritten As Boolean
    ''' <summary>
    ''' Имя пользователя, передаваемое в окно капчи и принимаемое из него
    ''' </summary>
    ''' <remarks></remarks>
    Public CaptchaUsername As String
    ''' <summary>
    ''' Пароль пользователя, передаваемый в окно капчи и принимаемый из него
    ''' </summary>
    ''' <remarks></remarks>
    Public CaptchaPassword As String
    ''' <summary>
    ''' Адрес обрабатываемого подраздела, напр.: http://rutracker.org/forum/viewforum.php?f=1127
    ''' </summary>
    ''' <remarks></remarks>
    Public SubForumAddress As String
    ''' <summary>
    ''' Используется при обновлении списка подфорумов, чтобы указать на необходимость обновления имени и(или) пароля в окне Настроек
    ''' </summary>
    ''' <remarks></remarks>
    Public RefreshCredentials As Boolean
    ''' <summary>
    ''' Расширенный лог
    ''' </summary>
    ''' <remarks></remarks>
    Public ExtendedLog As String
    ''' <summary>
    ''' Смещение до папок с скачанными страницами - при дебаге экономия трафика
    ''' </summary>
    ''' <remarks></remarks>
    Public PathToWebpagesPath As String
    ''' <summary>
    ''' Сохраняемые в файл настройки
    ''' </summary>
    ''' <remarks></remarks>
    Public SubForumsList As New Class_SubforumsList
    ''' <summary>
    ''' А вот с этим работаем в Настройках, и затем - в SubForumsList
    ''' </summary>
    ''' <remarks></remarks>
    Public SubForumsListTemp As New Class_SubforumsList
    ''' <summary>
    ''' Номер подраздела, кот-й необходимо выделить при открытии формы выбора подраздела. Иначе  задаём ей значение "-7"
    ''' </summary>
    ''' <remarks></remarks>
    Public ToSelectSubforum As Integer
    '===========Составляем отчёты
    ' ''' <summary>
    ' ''' Отчеты об обработанных подразделах
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Public Reports(,) As System.Text.StringBuilder
    'Public ReportTable() As List(Of Class_ReportLine)
    ' ''' <summary>
    ' ''' Индексы(нумерация с нуля), с которых начинаются подразделы
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Public torrentsCollectionIndexesOfSubforums() As Integer
    Public Reports As New List(Of Class_Report)
    Public IsfrmReportsActivated As Boolean = False
    Public WebStatColors As New WebStatusColors
    ' End of ===========Составляем отчёты
    ''' <summary>
    ''' Коллекция списков подразделов
    ''' </summary>
    ''' <remarks></remarks>
    Public SubForumsListColl As New Class_SubforumsListColl

    ''' <summary>
    ''' Список изображений, используемых в связке с EnumBitmaps
    ''' </summary>
    ''' <remarks></remarks>
    Friend Bitmaps As New List(Of Bitmap)

    ''' <summary>
    ''' Имя пользователя, которого проверяем на сидирование
    ''' </summary>
    ''' <remarks></remarks>
    Friend CheckUserToSeeding_Username As String

End Module
