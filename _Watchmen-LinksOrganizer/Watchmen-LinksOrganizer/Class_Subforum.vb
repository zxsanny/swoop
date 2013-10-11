<Serializable()>
Public Class Class_Subforum
    Implements ICloneable

    Private a_IsProcessSubforum As Boolean
    Private a_Name As String
    Private a_Number As Integer
    Private a_SubForumFullPath As String
    Private a_ChangeLabelOfTorrent As Boolean
    Private a_ChangeLabelOfTorrent_AnotherName As String
    Private a_ChangeLabelOfTorrent_AnotherNamesList As List(Of String)
    Private a_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty As Boolean
    Private a_ChangeLabelOfTorrent_ToNameSubforum As Boolean
    Private a_AutoStartStop As Boolean
    Private a_AutoStartStop_NumberOfSeedsNotMore As Integer
    Private a_AutoStartStop_StartForced As Boolean
    Private a_AD_DownloadIfSeedsNotMore As Boolean
    Private a_AD_cbNumberOfSeeds As Integer
    Private a_InnerList As List(Of Class_Subforum)
    Private a_InnerList_ProcessParent As Boolean
    Private a_InnerList_IsCreate As Boolean

    ''' <summary>
    ''' Номер подфорума, например "855"
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Number As Integer
        Get
            Return a_Number
        End Get
        Set(ByVal value As Integer)
            a_Number = value
        End Set
    End Property
    ''' <summary>
    ''' Название подфорума, например "Звуки природы"
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
    ''' Обрабатывать ли форум, или пропустить его?
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsProcessSubforum As Boolean
        Get
            Return a_IsProcessSubforum
        End Get
        Set(ByVal value As Boolean)
            a_IsProcessSubforum = value
        End Set
    End Property
    ''' <summary>
    ''' Полный путь к подразделу, например Музыка » New Age, Relax, Meditative and Flamenco
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubForumFullPath As String
        Get
            Return a_SubForumFullPath
        End Get
        Set(ByVal value As String)
            a_SubForumFullPath = value
        End Set
    End Property
    ''' <summary>
    ''' В торрент-клиентах изменять ярлык для раздач подраздела на:
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ChangeLabelOfTorrent As Boolean
        Get
            Return a_ChangeLabelOfTorrent
        End Get
        Set(ByVal value As Boolean)
            a_ChangeLabelOfTorrent = value
        End Set
    End Property

    ''' <summary>
    ''' Переименовывать ли метки раздач на название подраздела?
    ''' </summary>
    Public Property ChangeLabelOfTorrent_ToNameSubforum As Boolean
        Get
            Return a_ChangeLabelOfTorrent_ToNameSubforum
        End Get
        Set(ByVal value As Boolean)
            a_ChangeLabelOfTorrent_ToNameSubforum = value
        End Set
    End Property
    ''' <summary>
    ''' Текст новой метки для раздач подраздела
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ChangeLabelOfTorrent_AnotherName As String
        Get
            Return a_ChangeLabelOfTorrent_AnotherName
        End Get
        Set(ByVal value As String)
            a_ChangeLabelOfTorrent_AnotherName = value
        End Set
    End Property
    ''' <summary>
    ''' Список текстов меток для раздач подраздела
    ''' </summary>
    Public Property ChangeLabelOfTorrent_AnotherNamesList As List(Of String)
        Get
            Return a_ChangeLabelOfTorrent_AnotherNamesList
        End Get
        Set(ByVal value As List(Of String))
            a_ChangeLabelOfTorrent_AnotherNamesList = value
        End Set
    End Property
    ''' <summary>
    ''' Менять ярлык, только если он пустой
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ChangeLabelOfTorrent_OnlyIfLabelIsEmpty As Boolean
        Get
            Return a_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty
        End Get
        Set(ByVal value As Boolean)
            a_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty = value
        End Set
    End Property
    ''' <summary>
    ''' Автоматически запускать и останавливать сидируемые раздачи
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AutoStartStop As Boolean
        Get
            Return a_AutoStartStop
        End Get
        Set(ByVal value As Boolean)
            a_AutoStartStop = value
        End Set
    End Property
    ''' <summary>
    ''' Запускать раздачу, если сидов не более: (причем здесь НЕ индекс, а уже число сидов)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AutoStartStop_NumberOfSeedsNotMore As Integer
        Get
            Return a_AutoStartStop_NumberOfSeedsNotMore
        End Get
        Set(ByVal value As Integer)
            a_AutoStartStop_NumberOfSeedsNotMore = value
        End Set
    End Property
    ''' <summary>
    ''' Запускать принудительно
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AutoStartStop_StartForced As Boolean
        Get
            Return a_AutoStartStop_StartForced
        End Get
        Set(ByVal value As Boolean)
            a_AutoStartStop_StartForced = value
        End Set
    End Property
    ''' <summary>
    ''' Автоматически скачивать раздачи при количестве сидов не более
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AD_DownloadIfSeedsNotMore As Boolean
        Get
            Return a_AD_DownloadIfSeedsNotMore
        End Get
        Set(ByVal value As Boolean)
            a_AD_DownloadIfSeedsNotMore = value
        End Set
    End Property

    Public Property AD_cbNumberOfSeeds As Integer
        Get
            Return a_AD_cbNumberOfSeeds
        End Get
        Set(ByVal value As Integer)
            a_AD_cbNumberOfSeeds = value
        End Set
    End Property
    ''' <summary>
    ''' ListOf вложенных подразделов (если таковые имеются)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InnerList As List(Of Class_Subforum)
        Get
            Return a_InnerList
        End Get
        Set(ByVal value As List(Of Class_Subforum))
            a_InnerList = value
        End Set
    End Property
    ''' <summary>
    ''' True, если вместо обычного отчёта создаём объединённый отчёт по вложенным подразделам
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InnerList_IsCreate As Boolean
        Get
            Return a_InnerList_IsCreate
        End Get
        Set(ByVal value As Boolean)
            a_InnerList_IsCreate = value
        End Set
    End Property
    ''' <summary>
    ''' True, если вместе с вложенными обрабатывать и текущий подраздел
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InnerList_ProcessParent As Boolean
        Get
            Return a_InnerList_ProcessParent
        End Get
        Set(ByVal value As Boolean)
            a_InnerList_ProcessParent = value
        End Set
    End Property

    Public Sub New()
        a_Number = 0
        a_Name = ""
        a_SubForumFullPath = ""
        a_InnerList = New List(Of Class_Subforum)

        a_IsProcessSubforum = False

        a_ChangeLabelOfTorrent = False
        a_ChangeLabelOfTorrent_ToNameSubforum = True
        a_ChangeLabelOfTorrent_AnotherName = ""
        a_ChangeLabelOfTorrent_OnlyIfLabelIsEmpty = False

        a_AutoStartStop = False
        a_AutoStartStop_NumberOfSeedsNotMore = 3
        a_AutoStartStop_StartForced = False
    End Sub

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Return Me.MemberwiseClone
    End Function
    ''<Serializable()>
    ''Public Class Class_NamesList
    ''    Implements ICloneable
    ''    Private slist As New List(Of String)
    ''    Public Sub AddString(ByVal value As String)
    ''        If slist.Contains(value) = False Then slist.Add(value)
    ''    End Sub
    ''    Public ReadOnly Property GetList
    ''        Get
    ''            Return slist
    ''        End Get
    ''    End Property
    ''    Public Sub Clear()
    ''        slist.Clear()
    ''    End Sub
    ''    Public ReadOnly Property Count As Integer
    ''        Get
    ''            Return slist.Count
    ''        End Get
    ''    End Property
    ''    Public Function Clone() As Object Implements System.ICloneable.Clone
    ''        Return Me.MemberwiseClone
    ''    End Function
    ''End Class
End Class
