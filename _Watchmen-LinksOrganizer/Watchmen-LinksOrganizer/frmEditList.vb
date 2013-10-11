Public Class frmEditList

    Private Sub frmEditList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = WindowsApplication1.My.Resources.Keepers
        ToolTip1.SetToolTip(btnDelete, "Удалить элемент из списка")
    End Sub
End Class