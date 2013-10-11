Imports System.Text

Public Class frmSelectSubforum

    Public Overloads Function ShowDialog(ByRef Subf As Class_Subforum) As System.Windows.Forms.DialogResult
        Me.ShowDialog()
        'Теперь ждём изменения значения DialogResult
        'И заполняем SubF

        If Me.DialogResult = DialogResult.OK Then

            Subf.Number = CInt(TreeView1.SelectedNode.Tag)
            Subf.Name = TreeView1.SelectedNode.Text
            Subf.SubForumFullPath = TreeView1.SelectedNode.FullPath
            Subf.IsProcessSubforum = True

            If Subf.InnerList IsNot Nothing Then Subf.InnerList.Clear()
            If TreeView1.SelectedNode.GetNodeCount(False) > 0 Then
                For Each inner As TreeNode In TreeView1.SelectedNode.Nodes
                    Dim sf As New Class_Subforum
                    sf.Number = inner.Tag
                    sf.Name = inner.Text
                    sf.SubForumFullPath = inner.FullPath
                    Subf.InnerList.Add(sf)
                Next
            End If

        End If

        Return Me.DialogResult
    End Function
    'Соглашение: в Savi.div_tracker храним уже обрезанный ответ - т.е. только список подразделов от тега <select id="fs-main" до "</select>"
    Private Sub frmSelectSubforum_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'На всякий случай задаём начальное пустое значение
        If SavI.div_tracker = Nothing Then SavI.div_tracker = ""
        If SavI.div_tracker.Length < 1000 Then RefreshSubforumsList()
        btnOK.Enabled = False
        FillListOfSubforums()
        btnOK.DialogResult = DialogResult.OK
        btnCancel.DialogResult = DialogResult.Cancel
        txtSelectedSubforum.Text = "Выберите подраздел"
    End Sub

    Private Sub btnRefreshSubforumsList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshSubforumsList.Click
        RefreshSubforumsList()
        FillListOfSubforums()
    End Sub

    Public Sub RefreshSubforumsList()
        txtSelectedSubforum.Text = "Скачивается список подразделов"
#If CONFIG = "Debug-ReceiveAllInfoFromFiles" Then
        If System.IO.File.Exists(My.Application.Info.DirectoryPath & PathToWebpagesPath & "webpages\tracker") Then
            SavI.div_tracker = System.IO.File.ReadAllText(My.Application.Info.DirectoryPath & PathToWebpagesPath & "webpages\tracker")
            'Вырезаем лишнее из ответа 
            Dim f1 As Integer = SavI.div_tracker.IndexOf("<select id=""fs-main""") + 1
            Dim f2 As Integer = SavI.div_tracker.IndexOf("</select>", f1 + 10) + 1
            'Отрезаем лишнее - заодно и объём хранимого уменьшится
            SavI.div_tracker = Mid(SavI.div_tracker, f1, f2 - f1)
        Else
            SavI.div_tracker = ""
            MsgBox("список подразделов пуст, т.к. не найдет файл tracker", vbOKOnly, "Error")
            Exit Sub
        End If
#Else
        If SavI.Site_Username <> frmSettings.txtSite_Username.Text Then SavI.Site_Username = frmSettings.txtSite_Username.Text
        If SavI.Site_Password <> frmSettings.txtSite_Password.Text Then SavI.Site_Password = frmSettings.txtSite_Password.Text
        If SavI.Site_Cookie.Length < 10 Then
            frmMain.SaveExtendedLog("Получаем кукис")
            frmMain.TSSLabel1.Text = "Получаем кукис"
            SavI.Site_Cookie = frmMain.ReceiveCookie(SavI.Site_Username, SavI.Site_Password, RefreshCredentials)
            'todo Да нифига не устанавливается это в true в ReceiveCookie - доделать!
            If RefreshCredentials = True Then frmSettings.txtSite_Username.Text = SavI.Site_Username : frmSettings.txtSite_Password.Text = SavI.Site_Password
            Call frmMain.SaveSettingsToFile()
        End If
        SavI.div_tracker = frmMain.DownloadWebPageWithCookie("http://rutracker.org/forum/tracker.php", "http://rutracker.org/forum/index.php", Encoding.GetEncoding(1251))
        frmMain.TSSLabel1.Text = ""
        'Вырезаем лишнее из ответа 
        Dim f1 As Integer = SavI.div_tracker.IndexOf("<select id=""fs-main""") + 1
        Dim f2 As Integer = SavI.div_tracker.IndexOf("</select>", f1 + 10) + 1
        'Отрезаем лишнее - заодно и объём хранимого уменьшится
        SavI.div_tracker = Mid(SavI.div_tracker, f1, f2 - f1)
        ''#If CONFIG <> "Release" Then
        ''        System.IO.File.WriteAllText(My.Application.Info.DirectoryPath & PathToWebpagesPath & "webpages\tracker", SavI.div_tracker)
        ''#End If
        frmMain.SaveSettingsToFile()
#End If

    End Sub

    Private Sub FillListOfSubforums()
        TreeView1.Nodes.Clear()
        TreeView1.BeginUpdate()
        Dim optgroupIndexOpen As Integer = 0 'Индекс найденного тега "<optgroup"
        Dim optgroupIndexClose As Integer = 0 'Индекс найденного тега "</optgroup>"
        Dim subtracker As String = ""
        optgroupIndexOpen = SavI.div_tracker.IndexOf("<optgroup") + 1
        Dim i1 = 0, i2 = 0, i3 = 0, i4 = 0, i5 = 0, i6 As Integer = 0 'Вспомогательные числовые переменные
        Dim line As String = "" 'Текущий блок в разделе, например "<option id="fs-2092" value="2092"> |- Фильмы 2006-2009&nbsp;</option>"
        Dim LineValue As Integer = 0 ' Номер раздела, в примере выше это "2092"
        Dim LineName As String = "" 'Название в текущем блоке, в примере выше это " |- Фильмы 2006-2009&nbsp;"
        Do
            optgroupIndexClose = SavI.div_tracker.IndexOf("</optgroup>", optgroupIndexOpen + 2) + 1
            'Вырезаем теперь уже один раздел, и в нём работаем
            subtracker = Mid(SavI.div_tracker, optgroupIndexOpen, optgroupIndexClose - optgroupIndexOpen)
            'Вырезаем название раздела
            i1 = subtracker.IndexOf("""") + 1
            i2 = subtracker.IndexOf("""", i1 + 2) + 1
            LineName = Mid(subtracker, i1 + 1, i2 - i1 - 1).Replace("&nbsp;", "")
            Dim node1 As New TreeNode
            node1.Text = LineName
            node1.Tag = -1
            node1.ForeColor = Color.Gray
            node1.NodeFont = New Font("Courier New", 10, FontStyle.Italic)
            Dim Nod1Index As Integer = TreeView1.Nodes.Add(node1) 'Получаем индекс добавленного раздела верхнего уровня
            Dim Nod2Index As Integer = -11 ' А это будет индекс раздела промежуточного уровня (с тегом "root_forum_has_sf")
            i1 = subtracker.IndexOf("<option", i2) + 1
            If i1 > 0 Then
                Do
                    i2 = subtracker.IndexOf("</option>", i1) + 1 'Выделили адрес конца элемента
                    line = Mid(subtracker, i1, i2 - i1) 'выделили элемент
                    i3 = line.IndexOf("value=") + 1 'Нашли адрес номера раздела
                    LineValue = Val(Mid(line, i3 + 7, 10)) 'Выделили номер раздела
                    i4 = line.IndexOf(">", i3) + 1 'Выделили адрес начала названия, концом будет конец элемента
                    LineName = Mid(line, i4 + 1).Replace("|-", "") ' Выделили название раздела и обрезали лишнее
                    LineName = LineName.Replace("&nbsp;", "") ' Убрали тэг пробела, т.к. функция HTMLDecode этот тэг заменяет пробелом, который Trim не убирает
                    LineName = Trim(System.Web.HttpUtility.HtmlDecode(LineName))
                    Dim node2 As New TreeNode
                    node2.Text = LineName
                    node2.Tag = LineValue
                    node2.NodeFont = New Font("Courier New", 10)
                    If line.Contains("root_forum has_sf") Then
                        Nod2Index = TreeView1.Nodes(Nod1Index).Nodes.Add(node2)
                    Else
                        If Nod2Index = -11 Then 'Эта проверка нужна, если после раздела первого уровня сразу идёт раздел третьего уровня
                            TreeView1.Nodes(Nod1Index).Nodes.Add(node2)
                        Else
                            TreeView1.Nodes(Nod1Index).Nodes(Nod2Index).Nodes.Add(node2)
                        End If
                    End If

                    i1 = subtracker.IndexOf("<option", i2) + 1
                Loop While i1 > 0
            End If
            optgroupIndexOpen = SavI.div_tracker.IndexOf("<optgroup", optgroupIndexClose + 2) + 1
        Loop While optgroupIndexOpen > 3

        txtSelectedSubforum.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control)
        If ToSelectSubforum - 7 Then
            TreeView1.SelectedNode = Nothing
            txtSelectedSubforum.Text = "Выберите подраздел"
        Else

        End If

        TreeView1.EndUpdate()
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        If TreeView1.SelectedNode.Tag = -1 Then
            btnOK.Enabled = False
            txtSelectedSubforum.BackColor = Color.Fuchsia
            txtSelectedSubforum.Text = "Главные разделы нельзя выбирать. Выберите вложенный подраздел"
        Else
            txtSelectedSubforum.Text = TreeView1.SelectedNode.FullPath
            txtSelectedSubforum.BackColor = Color.FromKnownColor(System.Drawing.KnownColor.Control)
            btnOK.Enabled = True
        End If
        'Проверяем, может быть этот подраздел уже в списке выбранных подразделов
        Dim ThisSubforumAlreadyInSubforumsList As Boolean = False
        If SubForumsListTemp.Count > 0 Then
            For i As Integer = 0 To SubForumsListTemp.Count - 1
                If SubForumsListTemp.Item(i).Number = TreeView1.SelectedNode.Tag Then ThisSubforumAlreadyInSubforumsList = True
            Next
        End If
        If ThisSubforumAlreadyInSubforumsList = True Then
            btnOK.Enabled = False
            txtSelectedSubforum.BackColor = Color.Fuchsia
            txtSelectedSubforum.Text = "Этот подраздел уже в списке выбранных подразделов. Выберите другой подраздел."
        End If
    End Sub

    Private Sub frmSelectSubforum_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = WindowsApplication1.My.Resources.Keepers
    End Sub

End Class