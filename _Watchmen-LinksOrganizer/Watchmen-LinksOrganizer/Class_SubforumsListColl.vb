<Serializable()>
Public Class Class_SubforumsListColl
    Inherits System.Collections.CollectionBase

    Public Sub Add(ByVal a_SFL As Class_SubforumsList, ByVal name As String)
        a_SFL.Name = name
        List.Add(a_SFL)
    End Sub

    Public Property Item(ByVal index As Integer) As Class_SubforumsList
        Get
            Return CType(List.Item(index), Class_SubforumsList)
        End Get
        Set(ByVal value As Class_SubforumsList)
            List.Item(index) = CType(value, Class_SubforumsList)
        End Set
    End Property

End Class
