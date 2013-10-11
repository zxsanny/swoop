<Serializable()>
Public Class Class_ListOfInfoFromTorrentFiles
    Inherits System.Collections.CollectionBase
    Private a_TorrFilesErrors As String

    Public Property Item(ByVal index As Integer) As Class_InfoFromTorrentFile
        Get
            Return CType(List.Item(index), Class_InfoFromTorrentFile)
        End Get
        Set(ByVal value As Class_InfoFromTorrentFile)
            List.Item(index) = CType(value, Class_InfoFromTorrentFile)
        End Set
    End Property

    Public Property TorrFilesErrors As String
        Get
            Return a_TorrFilesErrors
        End Get
        Set(ByVal value As String)
            a_TorrFilesErrors = value
        End Set
    End Property

    Public Sub Add(ByVal a As Class_InfoFromTorrentFile)
        List.Add(a)
    End Sub
    Public Sub New()
        a_TorrFilesErrors = ""
    End Sub
End Class
