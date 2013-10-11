<Serializable()>
Public Class Class_SubforumsList
    Inherits System.Collections.CollectionBase
    Private a_Name As String
   
    Public Sub Add(ByVal a_Subf As Class_Subforum)
        List.Add(a_Subf)
    End Sub

    Public Sub MoveUp(ByVal ind As Integer)
        If ind > 0 And ind < List.Count Then
            Dim element As New Class_Subforum
            element = List.Item(ind)
            List.Insert(ind - 1, element)
            List.RemoveAt(ind + 1)
        End If
    End Sub
    Public Sub MoveDown(ByVal ind As Integer)
        If ind >= 0 And ind < List.Count - 1 Then
            Dim element As New Class_Subforum
            element = List.Item(ind)
            List.Insert(ind + 2, element)
            List.RemoveAt(ind)
        End If
    End Sub
    'Public Sub Insert(ByVal index As Integer, ByRef a_Subf As Class_Subforum)
    '    List.Insert(index, a_Subf)
    'End Sub
    Public Property Item(ByVal index As Integer) As Class_Subforum
        Get
            Return CType(List.Item(index), Class_Subforum)
        End Get
        Set(ByVal value As Class_Subforum)
            List.Item(index) = CType(value, Class_Subforum)

        End Set
    End Property
    ''' <summary>
    ''' Имя списка в SubForumsListColl
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

End Class