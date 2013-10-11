''' <summary>
''' Ряд ячеек отчёта
''' </summary>
''' <remarks></remarks>
Public Class Class_ReportLine
    Inherits System.Collections.CollectionBase

    Public Property Item(ByVal index As Integer) As Class_ReportCell
        Get
            Return CType(List.Item(index), Class_ReportCell)
        End Get
        Set(ByVal value As Class_ReportCell)
            List.Item(index) = CType(value, Class_ReportCell)
        End Set
    End Property

    Public Sub Add(ByVal a As Class_ReportCell)
        List.Add(a)
    End Sub

End Class
