Public Class frmSelectInnerSubforums
    Private InList As New List(Of Class_Subforum)
    ''' <summary>
    ''' передавать InnerList
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ShowDialog(ByRef InnerList As List(Of Class_Subforum)) As System.Windows.Forms.DialogResult
        If InnerList IsNot Nothing Then
            If InnerList.Count > 0 Then
                FillListOfInnerSubforums(InnerList)
                InList = InnerList
            End If
        End If
        Me.ShowDialog()
        'Ждём изменения значения DialogResult
        If Me.DialogResult = DialogResult.OK Then
            For i As Integer = 0 To clb.Items.Count - 1
                InnerList.Item(i).IsProcessSubforum = clb.GetItemChecked(i)
            Next
        End If
        Return Me.DialogResult
    End Function

    Private Sub FillListOfInnerSubforums(ByVal InnerList As List(Of Class_Subforum), Optional ByVal SelIndex As Integer = -5)
        clb.Items.Clear()
        If InnerList IsNot Nothing Then
            If InnerList.Count > 0 Then
                For Each sf As Class_Subforum In InnerList
                    clb.Items.Add(sf.Name, sf.IsProcessSubforum)
                Next
                If SelIndex >= 0 And SelIndex < clb.Items.Count Then clb.SelectedIndex = SelIndex
            End If
        End If
    End Sub

    Private Sub frmSelectInnerSubforums_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = WindowsApplication1.My.Resources.Keepers
        btnOK.DialogResult = DialogResult.OK
        btnCancel.DialogResult = DialogResult.Cancel
        If clb.Items.Count > 0 Then clb.SelectedIndex = 0
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        For i As Integer = 0 To clb.Items.Count - 1
            clb.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub btnDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeselectAll.Click
        For i As Integer = 0 To clb.Items.Count - 1
            clb.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub btnMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveUp.Click
        btnMoveUp.Enabled = False
        ListOfSubforumMoveUp(InList, clb.SelectedIndex)
        FillListOfInnerSubforums(InList, clb.SelectedIndex - 1)
    End Sub

    Private Sub btnMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveDown.Click
        btnMoveDown.Enabled = False
        ListOfSubforumMoveDown(InList, clb.SelectedIndex)
        FillListOfInnerSubforums(InList, clb.SelectedIndex + 1)
    End Sub

    Public Sub ListOfSubforumMoveUp(ByRef SubF As List(Of Class_Subforum), ByVal ind As Integer)
        If ind > 0 And ind < SubF.Count Then
            Dim element As New Class_Subforum
            element = SubF.Item(ind)
            SubF.Insert(ind - 1, element)
            SubF.RemoveAt(ind + 1)
        End If
    End Sub
    Public Sub ListOfSubforumMoveDown(ByRef SubF As List(Of Class_Subforum), ByVal ind As Integer)
        If ind >= 0 And ind < SubF.Count - 1 Then
            Dim element As New Class_Subforum
            element = SubF.Item(ind)
            SubF.Insert(ind + 2, element)
            SubF.RemoveAt(ind)
        End If
    End Sub


    Private Sub clb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clb.SelectedIndexChanged
        btnMoveUp.Enabled = clb.SelectedIndex > 0
        btnMoveDown.Enabled = clb.SelectedIndex > -1 And clb.SelectedIndex < clb.Items.Count - 1
    End Sub
End Class