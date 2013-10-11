
Public Class torrentInfo
    Private a_Availability As Double 'from torrent-client
    Private a_Downloaded As Double 'from torrent-client
    Private a_DownloadSpeed As Integer 'from torrent-client
    Private a_ETA As Double 'from torrent-client
    Private a_Hash As String 'from torrent-client
    Private a_Label As String 'from torrent-client
    Private a_Name As String 'from torrent-client
    Private a_PeersConnected As Integer 'from torrent-client
    Private a_PeersInSwarm As Integer 'from torrent-client
    Private a_PersentProgress As Integer 'from torrent-client
    Private a_Ratio As Integer 'from torrent-client
    Private a_Remaining As Double 'from torrent-client
    Private a_SeedsConnected As Integer 'from torrent-client
    Private a_SeedsInSwarm As Integer 'from torrent-client
    Private a_Size As Double 'from torrent-client
    Private a_Status As Integer 'from torrent-client
    Private a_TorrentQueueOrder As Integer 'from torrent-client
    Private a_Uploaded As Double 'from torrent-client
    Private a_UploadSpeed As Integer 'from torrent-client

    Private a_Filename As String
    Private a_CommentText As String
    Private a_Web_AddressNumber As Integer
    Private a_Web_NameFromWeb As String
    Private a_Web_PeersFromSite As Integer
    Private a_Web_SeedsFromSite As Integer
    Private a_Web_SubforumNumber As Integer
    Private a_Web_Status As String
    Private a_Web_SizeKMGBytes As String
    Private a_Web_FullSource As String
    Private a_Web_TorrentFileAddress As String
    Private a_Web_torrentRegistered As String
    Private a_Web_StatusColorTag As String
    Private a_DownloadDir As String
    Private a_Web_torrentRegisteredUNIXTime As Double

    Private ReadOnly dtZero As New DateTime(1970, 1, 1, 0, 0, 0)
    Private dt As New DateTime(1970, 1, 1, 0, 0, 0)

#Region "Данные из торрент-клиента"
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Hash As String
        Get
            Return a_Hash
        End Get
        Set(ByVal value As String)
            a_Hash = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Status As Integer
        Get
            Return a_Status
        End Get
        Set(ByVal value As Integer)
            a_Status = value
        End Set
    End Property
    ''' <summary>
    ''' Из торрент-клиента - Имя раздачи, НЕ имя файла
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name As String
        Get
            Return a_Name
        End Get
        Set(ByVal value As String)
            a_Name = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Size As Double
        Get
            Return a_Size
        End Get
        Set(ByVal value As Double)
            a_Size = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы - но, думаю, надо высчитывать, а не брать из клиента
    ''' </summary>
    Public Property PercentProgress As Integer
        Get
            Return a_PersentProgress
        End Get
        Set(ByVal value As Integer)
            a_PersentProgress = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Downloaded As Double
        Get
            Return a_Downloaded
        End Get
        Set(ByVal value As Double)
            a_Downloaded = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Uploaded As Double
        Get
            Return a_Uploaded
        End Get
        Set(ByVal value As Double)
            a_Uploaded = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Ratio As Integer
        Get
            Return a_Ratio
        End Get
        Set(ByVal value As Integer)
            a_Ratio = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UploadSpeed As Integer
        Get
            Return a_UploadSpeed
        End Get
        Set(ByVal value As Integer)
            a_UploadSpeed = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DownloadSpeed As Integer
        Get
            Return a_DownloadSpeed
        End Get
        Set(ByVal value As Integer)
            a_DownloadSpeed = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ETA As Double
        Get
            Return a_ETA
        End Get
        Set(ByVal value As Double)
            a_ETA = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Label As String
        Get
            Return a_Label
        End Get
        Set(ByVal value As String)
            a_Label = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PeersConnected As Integer
        Get
            Return a_PeersConnected
        End Get
        Set(ByVal value As Integer)
            a_PeersConnected = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PeersInSwarm As Integer
        Get
            Return a_PeersInSwarm
        End Get
        Set(ByVal value As Integer)
            a_PeersInSwarm = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SeedsConnected As Integer
        Get
            Return a_SeedsConnected
        End Get
        Set(ByVal value As Integer)
            a_SeedsConnected = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SeedsInSwarm As Integer
        Get
            Return a_SeedsInSwarm
        End Get
        Set(ByVal value As Integer)
            a_SeedsInSwarm = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Availability As Double
        Get
            Return a_Availability
        End Get
        Set(ByVal value As Double)
            a_Availability = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TorrentQueueOrder As Integer
        Get
            Return a_TorrentQueueOrder
        End Get
        Set(ByVal value As Integer)
            a_TorrentQueueOrder = value
        End Set
    End Property
    ''' <summary>
    ''' Из программы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Remaining As Double
        Get
            Return a_Remaining
        End Get
        Set(ByVal value As Double)
            a_Remaining = value
        End Set
    End Property
#End Region
    '==================================================================================================================
    ''' <summary>
    ''' Полный путь к файлу с совпадающим хэшем
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Filename As String
      Get
            Return a_Filename
        End Get
        Set(ByVal value As String)
            a_Filename = value
        End Set
    End Property
    ''' <summary>
    ''' Комментарий из торрент-файла
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CommentText As String
        Get
            Return a_CommentText
        End Get
        Set(ByVal value As String)
            a_CommentText = value
        End Set
    End Property
    ''' <summary>
    ''' Название раздачи, полученное из Web-страницы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Web_NameFromWeb As String
        Get
            Return a_Web_NameFromWeb
        End Get
        Set(ByVal value As String)
            a_Web_NameFromWeb = value
        End Set
    End Property

    ''' <summary>
    ''' Из Web-страницы
    ''' </summary>
    Public Property Web_PeersFromSite As Integer
        Get
            Return a_Web_PeersFromSite
        End Get
        Set(ByVal value As Integer)
            a_Web_PeersFromSite = value
        End Set
    End Property

    ''' <summary>
    ''' Из Web-страницы
    ''' </summary>
    Public Property Web_SeedsFromSite As Integer
        Get
            Return a_Web_SeedsFromSite
        End Get
        Set(ByVal value As Integer)
            a_Web_SeedsFromSite = value
        End Set
    End Property
    ''' <summary>
    ''' Номер раздачи, т.е. число в адресе раздачи, идущее после знака равенства
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Web_AddressNumber As Integer
        Get
            Return a_Web_AddressNumber
        End Get
        Set(ByVal value As Integer)
            a_Web_AddressNumber = value
        End Set
    End Property
    ''' <summary>
    ''' Номер подраздела, к которому принадлежит данная раздача
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Web_SubforumNumber As Integer
        Get
            Return a_Web_SubforumNumber
        End Get
        Set(ByVal value As Integer)
            a_Web_SubforumNumber = value
        End Set
    End Property
    ''' <summary>
    ''' Статус раздачи
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Web_Status As String
        Get
            Return a_Web_Status
        End Get
        Set(ByVal value As String)
            a_Web_Status = value
        End Set
    End Property
    ''' <summary>
    ''' Размер раздачи - копия текста из веб-страницы
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Web_SizeKMGBytes As String
        Get
            Return a_Web_SizeKMGBytes
        End Get
        Set(ByVal value As String)
            a_Web_SizeKMGBytes = value
        End Set
    End Property
    ''' <summary>
    ''' Для раздач с нулевым количеством сидов определяем, когда сид был последний раз
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Web_FullSource As String
        Get
            Return a_Web_FullSource
        End Get
        Set(ByVal value As String)
            a_Web_FullSource = value
        End Set
    End Property
    ''' <summary>
    ''' Веб-адрес торрент-файла
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Web_TorrentFileAddress As String
        Get
            Return a_Web_TorrentFileAddress
        End Get
        Set(ByVal value As String)
            a_Web_TorrentFileAddress = value
        End Set
    End Property
    ''' <summary>
    ''' Дата и время регистрации торрент-файла на трекере
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Web_torrentRegistered As String
        Get
            Return a_Web_torrentRegistered
        End Get
        'Set(ByVal value As String)
        '    a_Web_torrentRegistered = value
        'End Set
    End Property
    ''' <summary>
    ''' Тег, описывающий цвет статуса раздачи
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Web_StatusColorTag As String
        Get
            Return a_Web_StatusColorTag
        End Get
        Set(ByVal value As String)
            a_Web_StatusColorTag = value
        End Set
    End Property
    ''' <summary>
    ''' Папка, в которую загружаются файлы торрента
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DownloadDir As String
        Get
            Return a_DownloadDir
        End Get
        Set(ByVal value As String)
            a_DownloadDir = value
        End Set
    End Property
    ''' <summary>
    ''' Дата и время регистрации торрент-файла на трекере в UNIX-времени
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Web_torrentRegisteredUNIXTime As Double
        Get
            Return a_Web_torrentRegisteredUNIXTime
        End Get
        Set(ByVal value As Double)
            a_Web_torrentRegisteredUNIXTime = value
            'Теперь вычисляем дату для a_Web_torrentRegistered
            'Для начала на всякий случай обнулим переменную даты-времени
            If dt.CompareTo(dtZero) <> 0 Then
                dt = dt.AddSeconds(-DateAndTime.DateDiff(DateInterval.Second, dtZero, dt))
            End If
            dt = dt.AddSeconds(a_Web_torrentRegisteredUNIXTime)
            a_Web_torrentRegistered = dt.Day.ToString & "-" & MonthName(dt.Month, True) & "-" & Mid(dt.Year.ToString, 3) '& " " & dt.Hour.ToString & ":" & dt.Minute.ToString
            'И в конце обнулим дату-время
            'dt.AddSeconds(-a_Web_torrentRegisteredUNIXTime)
        End Set
    End Property
   
    ''' <summary>
    ''' Создаем пустой экземпляр класса
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        a_Availability = 0
        a_Downloaded = 0
        a_DownloadSpeed = 0
        a_ETA = 0
        a_Hash = ""
        a_Label = ""
        a_Name = ""
        a_PeersConnected = 0
        a_PeersInSwarm = 0
        a_PersentProgress = 0
        a_Ratio = 0
        a_Remaining = 0
        a_SeedsConnected = 0
        a_SeedsInSwarm = 0
        a_Size = 0
        a_Status = 0
        a_TorrentQueueOrder = 0
        a_Uploaded = 0
        a_UploadSpeed = 0

        a_Filename = ""
        a_CommentText = ""
        a_Web_AddressNumber = 0
        a_Web_NameFromWeb = ""
        a_Web_PeersFromSite = 0
        a_Web_SeedsFromSite = 0
        a_Web_SubforumNumber = 0
        a_Web_Status = ""
        a_Web_SizeKMGBytes = ""
        a_Web_FullSource = ""
        a_Web_TorrentFileAddress = ""
        a_Web_torrentRegistered = ""
        a_Web_StatusColorTag = ""
    End Sub
    ''' <summary>
    ''' Новый член коллекции
    ''' </summary>
    ''' <param name="nx_CommentText">Текст комментария к торренту, т.е. в нашем случае адрес раздачи</param>
    ''' <param name="nx_Web_AddressNumber">Номер раздачи, т.е. число в адресе раздачи, идущее после знака равенства</param>
    ''' <param name="nx_Web_NameFromWeb">Имя раздачи с веб-страницы</param>
    ''' <param name="nx_Web_SeedsFromSite">Количество сидов</param>
    ''' <param name="nx_Web_PeersFromSite">Количество пиров</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal nx_CommentText As String, ByVal nx_Web_AddressNumber As Integer, _
                   ByVal nx_Web_NameFromWeb As String, ByVal nx_Web_SeedsFromSite As Integer, _
                   ByVal nx_Web_PeersFromSite As Integer, ByVal nx_Web_SubforumNumber As Integer)
        a_Availability = 0
        a_Downloaded = 0
        a_DownloadSpeed = 0
        a_ETA = 0
        a_Hash = ""
        a_Label = ""
        a_Name = ""
        a_PeersConnected = 0
        a_PeersInSwarm = 0
        a_PersentProgress = 0
        a_Ratio = 0
        a_Remaining = 0
        a_SeedsConnected = 0
        a_SeedsInSwarm = 0
        a_Size = 0
        a_Status = 0
        a_TorrentQueueOrder = 0
        a_Uploaded = 0
        a_UploadSpeed = 0

        a_Filename = ""
        a_CommentText = nx_CommentText
        a_Web_AddressNumber = nx_Web_AddressNumber
        a_Web_NameFromWeb = nx_Web_NameFromWeb
        a_Web_PeersFromSite = nx_Web_PeersFromSite
        a_Web_SeedsFromSite = nx_Web_SeedsFromSite
        a_Web_SubforumNumber = nx_Web_SubforumNumber
        a_Web_Status = ""
        a_Web_SizeKMGBytes = ""
        a_Web_FullSource = ""
        a_Web_TorrentFileAddress = ""
        a_Web_torrentRegistered = ""
        a_Web_StatusColorTag = ""
    End Sub
End Class
