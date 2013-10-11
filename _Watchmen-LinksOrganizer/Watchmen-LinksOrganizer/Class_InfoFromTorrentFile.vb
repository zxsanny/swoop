<Serializable()>
Public Class Class_InfoFromTorrentFile
    Private a_CommentText As String
    Private a_FullFilename As String
    Private a_Hash As String
    Private a_TrackerName As String

    Public Property CommentText As String
        Get
            Return a_CommentText
        End Get
        Set(ByVal value As String)
            a_CommentText = value
        End Set
    End Property

    Public Property Hash As String
        Get
            Return a_Hash
        End Get
        Set(ByVal value As String)
            a_Hash = value
        End Set
    End Property

    Public Property FullFilename As String
        Get
            Return a_FullFilename
        End Get
        Set(ByVal value As String)
            a_FullFilename = value
        End Set
    End Property
    ''' <summary>
    ''' Имя торрент-трекера, напр. rutracker.org
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrackerName As String
        'Думаю, здесь сделать так:
        'При создании ListOf отправлять экземпляр parser и получать имя трекера
        'А уже при добавлении отправлять значение свойства и получать True(наш трекер, добавляем в коллекцию данные) или False
        'Такое разделение делаетя для того, что, когда будут обрабатываться несколько трекеров, и их торрент-файлы вперемешку,
        'вот тогда это отделение парсинга и вовда данных и поможет - даже если сменили трекер, всё равно можно утвердить или отклонить файл
        Get
            Return a_TrackerName
        End Get
        Set(ByVal value As String)
            a_TrackerName = value
        End Set
    End Property

    Public Sub New()
        a_CommentText = ""
        a_FullFilename = ""
        a_Hash = ""
        a_TrackerName = ""
    End Sub
End Class
