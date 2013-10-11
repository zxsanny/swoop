
Imports System.Text

Public Class Class_rutrackerorg

    Dim str1 As String
    Dim txts() As String
    Dim dt As New DateTime(1970, 1, 1, 0, 0, 0)
    Dim dtZero As New DateTime(1970, 1, 1, 0, 0, 0)

    Dim IndexOfCloseBracket As Integer
    Dim firstTorrentWebNameWithoutBrackets As String
    Dim secondTorrentWebNameWithoutBrackets As String
    
    Public Sub ReceiveInfoFromWebPages(ByRef torColl As List(Of torrentInfo), ByVal IsNeedFindDatesTorReg As Boolean)
        'Получаем основную массу инфы о раздачах
        ReceiveInfoFromForum(torColl)
        'Теперь обрабатываем запрос к трекеру, получая даты регистрации торрент-файлов
        If IsNeedFindDatesTorReg = True Then ReceiveInfoFromTracker(torColl)
    End Sub

    Private Sub ReceiveInfoFromForum(ByRef torColl As List(Of torrentInfo))
        frmMain.SaveExtendedLog("Скачиваем и разбираем страницы подраздела")
        Dim IndexIn_torrentsCollectionIndexesOfSubforums As Integer = 0
        For Each asf As Class_Subforum In SubForumsList
            Reports.Item(IndexIn_torrentsCollectionIndexesOfSubforums).StartIndexInTorColl = torColl.Count
            IndexIn_torrentsCollectionIndexesOfSubforums += 1
            If asf.IsProcessSubforum = True Then
                If asf.InnerList_IsCreate = False Then
                    ParseForum(torColl, asf.Number)
                Else

                    If asf.InnerList_ProcessParent = True Then ParseForum(torColl, asf.Number)

                    If asf.InnerList IsNot Nothing Then

                        If asf.InnerList.Count > 0 Then
                            For j As Integer = 0 To asf.InnerList.Count - 1
                                If asf.InnerList.Item(j).IsProcessSubforum = True Then ParseForum(torColl, asf.InnerList.Item(j).Number)
                            Next
                        End If

                    End If

                End If
            End If
        Next
    End Sub


    ''' <summary>
    ''' Разбираем страницы подраздела, получая инфу с них
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ParseForum(ByRef torColl As List(Of torrentInfo), ByVal Web_SubforumNumber As Integer)

        'Разбираем страницы
        Dim PageOfSubforum As String 'содержимое веб-страницы.

        Dim OffsetOfFirstTorrentInLastPageOfSubforum As String = ""
        Dim NumberOfPagesInSubForum As Integer = 0

        Dim NumberOfTorrentOnPage As Integer = 0 'Номер текущей раздачи на странице
        Dim tor_Index_tr_id_tr As Integer = 1 '  адрес блока "<tr id="tr-"
        Dim startIndexOfPage As Integer = 1 'Стартовый адрес, с которого начинается поиск блока "<tr id="tr-"

        Dim tor_slash_tr As Integer = -1 'адрес блока </tr>

        Dim tor_span_class_tor_icon As Integer = -1 'адрес блока "<span class="tor-icon"
        Dim tor_span_class_tor_icon_open As Integer = -1 'адрес ">" после "<span class="tor-icon"
        Dim tor_span_class_tor_icon_close As Integer = -1 'адрес "<" после "<span class="tor-icon"
        Dim web_Status As String = "" 'Статус раздачи
        Dim Web_StatusColorTag As String = "" 'Цвет статуса раздачи

        Dim tor_div_class_torTopic As Integer = -1 'адрес блока div class="torTopic"
        Dim tor_href_viewtopic As Integer = -1 'адрес блока href="./viewtopic.php?t=
        Dim web_AddressNumber As Integer = 0 'часть адреса раздачи, идущая после знака равенства
        Dim web_AddressFull As String = "" 'А здесь уже полный адрес торрента
        Dim torTopic_tt_text As Integer = -1 ' адрес блока "class="torTopic bold tt-text""
        Dim webTopic As String = "" 'Название раздачи
        Dim tor_slash_a As Integer = 0 'Адрес блока </a>
        Dim tor_title_Seeders As Integer = 1 'Адрес блока title="Seeders">
        Dim web_Seeders As Integer = -1 ' Количество сидов
        Dim tor_title_Leechers As Integer = 1 'Адрес блока title="Leechers">
        Dim web_Leechers As Integer = -1 ' Количество личеров

        Dim WebPageCroppedSizze As String = "" 'Сюда вырезаем строку с размером раздачи и адресом торрент-файла
        Dim tor_sizze_ind1 As Integer = -1
        Dim tor_sizze_ind2 As Integer = -1
        Dim Web_TorrentFileAddress As String = ""
        Dim Web_SizeKMGBytes As String = ""

        Dim PageOfSubforumCropped As String
        ''Dim FindFullSource_Page As String
        ''Dim FindFullSource_int1 As Integer
        ''Dim FindFullSource_int2 As Integer

        'Переменные для варианта с разбором DOM-дерева
        'Dim WebBrowser1 As New WebBrowser

        SubForumAddress = "http://rutracker.org/forum/viewforum.php?f=" & Trim(CStr(Web_SubforumNumber))
        '=========УЗНАЁМ КОЛИЧЕСТВО СТРАНИЦ ПОДРАЗДЕЛА===============
        ForumParser.StageOfWork = "Подраздел " & SubForumAddress & " Скачиваем Web-страницу № 1" ': frmMain.TSSLabelSet()
        'Выкачиваем первую страницу подраздела, чтобы выяснить количество страниц в нём.
        ExtendedLog &= ForumParser.StageOfWork & vbNewLine : frmMain.SaveExtendedLog()
        PageOfSubforum = frmMain.DownloadWebPageWithCookie(SubForumAddress, "http://rutracker.org/forum/index.php", System.Text.Encoding.GetEncoding(1251))
        ForumParser.StageOfWork = "Подраздел " & SubForumAddress & " Разбираем Web-страницу № 1" ': frmMain.TSSLabelSet()
        ExtendedLog &= ForumParser.StageOfWork & vbNewLine
        NumberOfPagesInSubForum = NumberOfPages(PageOfSubforum)
        ExtendedLog &= "Подраздел " & SubForumAddress & " Количество страниц подраздела: " & NumberOfPagesInSubForum & vbNewLine
        '=============
        For i As Integer = 1 To NumberOfPagesInSubForum
            If i > 1 Then
                ForumParser.StageOfWork = "Подраздел " & SubForumAddress & " Скачиваем Web-страницу № " & CStr(i) & " / " & NumberOfPagesInSubForum.ToString
                ExtendedLog &= ForumParser.StageOfWork & vbNewLine
                frmMain.SaveExtendedLog()
                PageOfSubforum = frmMain.DownloadWebPageWithCookie(SubForumAddress & "&start=" & Trim(Str((i - 1) * 50)), "http://rutracker.org/forum/index.php", System.Text.Encoding.GetEncoding(1251))
            End If
            'Вариант с разбором DOM-дерева - это надо потом реализовать вместо простых mid-ов
            'WebBrowser1.Document = PageOfSubforum '   .Navigate(New Uri("httр://rutracker.org/forum/viewforum.php?f=1126"))
            'Dim sArray As New ArrayList
            'If (Not (WebBrowser1.Document Is Nothing)) Then
            '    Dim CurrentDocument As mshtml.IHTMLDocument2 = WebBrowser1.Document.DomDocument
            '    Dim allTables As IHTMLElementCollection = CurrentDocument.all.tags("table")
            '    Dim iTable As IHTMLElement
            '    For Each iTable In allTables
            '        sArray.Add(iTable.outerHTML)
            '    Next
            'Else
            'End If
            '======================================================
            'Вариант с разбором mid-ами
            startIndexOfPage = 1
            NumberOfTorrentOnPage = 0
            Do
                'Сообщаем о номере обрабатываемой раздачи на странице
                NumberOfTorrentOnPage += 1
                'ForumParser.StageOfWork = "Подраздел " & SubForumAddress & " На Web-странице № " & CStr(i) & " разбираем раздачу № " & CStr(NumberOfTorrentOnPage) ': frmMain.TSSLabelSet()
                'сначала находим блок "<tr id="tr-"
                tor_Index_tr_id_tr = PageOfSubforum.IndexOf("<tr id=""tr-", startIndexOfPage)
                If tor_Index_tr_id_tr = -1 Then Exit Do Else startIndexOfPage = tor_Index_tr_id_tr + 10
                'теперь блок </tr>
                tor_slash_tr = PageOfSubforum.IndexOf("</tr>", tor_Index_tr_id_tr)
                If tor_slash_tr = -1 Then Exit Do
                'Теперь вырезаем описание одной раздачи, и уже работаем с ним
                PageOfSubforumCropped = Mid(PageOfSubforum, tor_Index_tr_id_tr, tor_slash_tr - tor_Index_tr_id_tr)
                'Проверяем наличие блока с числом сидов и пиров. Если нет - уходим на след. раздачу
                If PageOfSubforumCropped.Contains("title=""Seeders""") = False Then GoTo nextTr_Id_Tr
                'Статус раздачи
                tor_span_class_tor_icon = PageOfSubforumCropped.IndexOf("<span class=""tor-icon") '<span class="tor-icon
                tor_span_class_tor_icon_open = PageOfSubforumCropped.IndexOf(">", tor_span_class_tor_icon + 5)
                tor_span_class_tor_icon_close = PageOfSubforumCropped.IndexOf("<", tor_span_class_tor_icon_open)
                web_Status = Mid(PageOfSubforumCropped, tor_span_class_tor_icon_open + 2, tor_span_class_tor_icon_close - tor_span_class_tor_icon_open - 1)
                'Цвет статуса раздачи
                tor_span_class_tor_icon = PageOfSubforumCropped.IndexOf("<span class=""tor-icon") '<span class="tor-icon
                tor_span_class_tor_icon_open = PageOfSubforumCropped.IndexOf(" ", tor_span_class_tor_icon + 20)
                tor_span_class_tor_icon_close = PageOfSubforumCropped.IndexOf("""", tor_span_class_tor_icon_open)
                Web_StatusColorTag = Mid(PageOfSubforumCropped, tor_span_class_tor_icon_open + 2, tor_span_class_tor_icon_close - tor_span_class_tor_icon_open - 1).Replace("-", "")

                'вылавливаем блок div class="torTopic"
                tor_div_class_torTopic = PageOfSubforumCropped.IndexOf("div class=""torTopic""")
                'сразу за ним вылавливаем блок href="./viewtopic.php?t=
                tor_href_viewtopic = PageOfSubforumCropped.IndexOf("href=""./viewtopic.php?t=", tor_div_class_torTopic)
                'И теперь вылавливаем номер раздачи, который затем соберём в полный адрес
                web_AddressNumber = Val(Mid(PageOfSubforumCropped, tor_href_viewtopic + 25, 10))
                web_AddressFull = "http://rutracker.org/forum/viewtopic.php?t=" & CStr(web_AddressNumber)
                'теперь отлавливаем адрес блока class="torTopic bold tt-text"
                torTopic_tt_text = PageOfSubforumCropped.IndexOf("tt-text"">", tor_href_viewtopic + 10)
                'вылавливаем адрес блока </a>
                tor_slash_a = PageOfSubforumCropped.IndexOf("</a>", torTopic_tt_text + 10)
                'и, наконец, получаем название раздачи
                webTopic = Mid(PageOfSubforumCropped, torTopic_tt_text + 10, tor_slash_a - (torTopic_tt_text + 9))
                'Вырезаем тэг <wbr>
                webTopic = webTopic.Replace("<wbr>", "")
                'Теперь ловим блок title="Seeders">
                tor_title_Seeders = PageOfSubforumCropped.IndexOf("title=""Seeders"">", tor_slash_a + 10)
                web_Seeders = Val(Mid(PageOfSubforumCropped, tor_title_Seeders + 20, 7))
                'Теперь ловим блок title="Leechers">
                tor_title_Leechers = PageOfSubforumCropped.IndexOf("title=""Leechers"">", tor_title_Seeders + 10)
                web_Leechers = Val(Mid(PageOfSubforumCropped, tor_title_Leechers + 21, 7))
                'Размер раздачи и адрес торрент-файла
                tor_sizze_ind1 = PageOfSubforumCropped.IndexOf("<div", tor_title_Leechers)
                tor_sizze_ind2 = PageOfSubforumCropped.IndexOf("</div>", tor_sizze_ind1) + 5
                WebPageCroppedSizze = Mid(PageOfSubforumCropped, tor_sizze_ind1 + 1, tor_sizze_ind2 - tor_sizze_ind1)
                tor_sizze_ind1 = WebPageCroppedSizze.IndexOf("http://dl.rutracker.org/forum/dl.php?t")
                If tor_sizze_ind1 > -1 Then
                    tor_sizze_ind2 = WebPageCroppedSizze.IndexOf("""", tor_sizze_ind1 + 3)
                    Web_TorrentFileAddress = Mid(WebPageCroppedSizze, tor_sizze_ind1 + 1, tor_sizze_ind2 - tor_sizze_ind1)
                    tor_sizze_ind1 = WebPageCroppedSizze.IndexOf(">", tor_sizze_ind2 + 1)
                    tor_sizze_ind2 = WebPageCroppedSizze.IndexOf("<", tor_sizze_ind1 + 1)
                    Web_SizeKMGBytes = Mid(WebPageCroppedSizze, tor_sizze_ind1 + 2, tor_sizze_ind2 - tor_sizze_ind1 - 1)
                Else
                    Web_TorrentFileAddress = ""
                    tor_sizze_ind1 = WebPageCroppedSizze.IndexOf(">")
                    tor_sizze_ind2 = WebPageCroppedSizze.IndexOf("<", tor_sizze_ind1 + 1)
                    Web_SizeKMGBytes = Mid(WebPageCroppedSizze, tor_sizze_ind1 + 2, tor_sizze_ind2 - tor_sizze_ind1 - 1)
                End If
                'создаём новый член коллекции и добавляем в неё
                Dim tmpTorrentInfo As New torrentInfo(web_AddressFull, web_AddressNumber, webTopic, web_Seeders, web_Leechers, Web_SubforumNumber)
                tmpTorrentInfo.Web_Status = web_Status
                tmpTorrentInfo.Web_StatusColorTag = Web_StatusColorTag
                tmpTorrentInfo.Web_TorrentFileAddress = Web_TorrentFileAddress
                tmpTorrentInfo.Web_SizeKMGBytes = Web_SizeKMGBytes.Replace("&nbsp;", " ")
                ''If web_Seeders = 0 Then 'Если число сидов = 0, то находим, когда сид был последний раз
                ''    FindFullSource_Page = frmMain.DownloadWebPageWithCookie(web_AddressFull, "http://rutracker.org/forum/index.php", System.Text.Encoding.GetEncoding(1251))
                ''    If FindFullSource_Page.IndexOf("Полный источник") < 10 Then GoTo NoFindData
                ''    FindFullSource_int1 = FindFullSource_Page.IndexOf("Полный источник")
                ''    FindFullSource_int1 = FindFullSource_Page.IndexOf(">", FindFullSource_int1 + 5)
                ''    FindFullSource_int2 = FindFullSource_Page.IndexOf("<", FindFullSource_int1)
                ''    tmpTorrentInfo.Web_FullSource = Mid(FindFullSource_Page, FindFullSource_int1 + 2, FindFullSource_int2 - FindFullSource_int1 - 1)
                ''    'Теперь заодно находим дату и время регистрации торрент-файла на трекере
                ''    FindFullSource_int1 = FindFullSource_Page.IndexOf("<span title=""Зарегистрирован"">")
                ''    If FindFullSource_int1 < 1 Then GoTo NoFindData
                ''    FindFullSource_int1 = FindFullSource_Page.IndexOf(">", FindFullSource_int1 + 5)
                ''    FindFullSource_int2 = FindFullSource_Page.IndexOf("<", FindFullSource_int1)
                ''    tmpTorrentInfo.Web_torrentRegistered = Mid(FindFullSource_Page, FindFullSource_int1 + 2, FindFullSource_int2 - FindFullSource_int1 - 1)
                ''End If
NoFindData:
                ExtendedLog &= web_AddressFull & vbTab & web_AddressNumber & vbTab & webTopic & vbTab & web_Seeders & vbTab & web_Leechers & vbNewLine
                torColl.Add(tmpTorrentInfo)
nextTr_Id_Tr:
            Loop While tor_Index_tr_id_tr > 0
        Next

    End Sub
    Private Function NumberOfPages(ByVal PageSourceText As String) As Integer
        Dim fp1, fp2, fp3, fp4 As Integer
        Dim PageOfSubforumCropped As String
        'Узнаём адрес текста    class="maintitle"
        fp1 = PageSourceText.IndexOf("class=""maintitle""")
        'Теперь узнаём адрес первого вхождения последовательности "</p>" после адреса fp1
        fp2 = PageSourceText.IndexOf("</p>", fp1 + 1)
        PageOfSubforumCropped = Mid(PageSourceText, fp1, fp2 - fp1)
        'Теперь находим последнее вхождение текста "start=" между fp1 и fp2
        fp3 = PageOfSubforumCropped.LastIndexOf("start=")
        'Если не нашли, значит одна страница
        If fp3 = -1 Then Return 1
        'Теперь находим предпоследнее вхождение текста "start=" между fp1 и fp2
        PageOfSubforumCropped = Mid(PageOfSubforumCropped, 1, fp3 - 2)
        fp4 = PageOfSubforumCropped.LastIndexOf("start=")
        'И, наконец, узнаем стартовое смещение первого торрента последней страницы
        fp1 = Val(Mid(PageOfSubforumCropped, (fp4 + 7), 5))
        Return fp1 / 50 + 1
    End Function

    Private Sub ReceiveInfoFromTracker(ByRef torColl As List(Of torrentInfo))
        ForumParser.StageOfWork = "Теперь обрабатываем запрос к трекеру, получая даты регистрации торрент-файлов"
        frmMain.SaveExtendedLog(ForumParser.StageOfWork)
        For Each asf As Class_Subforum In SubForumsList
            If asf.IsProcessSubforum = True Then
                If asf.InnerList_IsCreate = False Then
                    ParseTracker(torColl, asf.Number)
                Else

                    If asf.InnerList_ProcessParent = True Then ParseTracker(torColl, asf.Number)

                    If asf.InnerList IsNot Nothing Then

                        If asf.InnerList.Count > 0 Then
                            For j As Integer = 0 To asf.InnerList.Count - 1
                                If asf.InnerList.Item(j).IsProcessSubforum = True Then ParseTracker(torColl, asf.InnerList.Item(j).Number)
                            Next
                        End If

                    End If

                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' Теперь собираем даты заливки торрент-файлов на форум
    ''' </summary>
    ''' <param name="torColl"></param>
    ''' <remarks></remarks>
    Private Sub ParseTracker(ByRef torColl As List(Of torrentInfo), ByVal Web_SubforumNumber As Integer)
        'Разбираем страницы
        Dim PageOfSubforum As String 'содержимое веб-страницы.
        Dim NumberOfPagesInSubForum As Integer
        Dim search_id As String = ""

        Dim NumberOfTorrentOnPage As Integer  'Номер текущей раздачи на странице
        Dim tor_BlockStart As Integer '  адрес начала блока
        Dim startIndexOfPage As Integer  'Стартовый адрес, с которого начинается поиск начала блока
        Dim tor_BlockEnd As Integer 'адрес блока </tr>

        Dim web_AddressNumber As Integer  'Номер раздачи
        Dim Web_torrentRegisteredUnixTime As Double    'UNIX-время регистрации торрент-файла
        'Dim Web_torrentRegistered As String
        'Dim dt As New DateTime(1970, 1, 1, 0, 0, 0, 0)
        'Переменные для варианта с разбором DOM-дерева
        'Dim WebBrowser1 As New WebBrowser

        Dim sovpalo1 As String = 0
        Dim sovpalo2 As String = 0
        Dim fp1, fp2 As Integer
        Dim PageOfSubforumCropped As String


        SubForumAddress = "http://rutracker.org/forum/tracker.php?f=" & Web_SubforumNumber.ToString & "&tm=-1&o=10&s=1"
        '=========УЗНАЁМ КОЛИЧЕСТВО СТРАНИЦ ПОДРАЗДЕЛА===============
        ForumParser.StageOfWork = "Подраздел трекера № " & Web_SubforumNumber.ToString & " Скачиваем Web-страницу № 1" ': frmMain.TSSLabelSet()
        'Выкачиваем первую страницу подраздела, чтобы выяснить количество страниц в нём.
        ExtendedLog &= ForumParser.StageOfWork & vbNewLine : frmMain.SaveExtendedLog()
        'http://rutracker.org/forum/tracker.php?f=1126&tm=-1&o=10&s=1
        PageOfSubforum = frmMain.DownloadWebPageWithCookie(SubForumAddress, "http://rutracker.org/forum/tracker.php", Encoding.GetEncoding(1251), "", 0)
        ForumParser.StageOfWork = "Подраздел трекера " & Web_SubforumNumber.ToString & " Разбираем Web-страницу № 1" ': frmMain.TSSLabelSet()
        ExtendedLog &= ForumParser.StageOfWork & vbNewLine
        NumberOfPagesInSubForum = NumberOfPages(PageOfSubforum)
        ExtendedLog &= "Подраздел трекера " & "http://rutracker.org/forum/tracker.php?f=" & Web_SubforumNumber.ToString & _
                       " Количество страниц подраздела: " & NumberOfPagesInSubForum & vbNewLine
        'Выясняем search_id
        'Пример: http://rutracker.org/forum/tracker.php?search_id=tmFTZdtoN3IV&start=50
        fp1 = PageOfSubforum.IndexOf("search_id=") + 11
        If fp1 > 15 Then
            fp2 = PageOfSubforum.IndexOf("start=") + 1
            If fp2 > 10 Then search_id = Mid(PageOfSubforum, fp1, fp2 - fp1)
        Else
            search_id = ""
        End If

        For i As Integer = 1 To NumberOfPagesInSubForum
            If i > 1 Then
                ForumParser.StageOfWork = "Подраздел трекера № " & Web_SubforumNumber.ToString & " Скачиваем Web-страницу № " & CStr(i) & " / " & NumberOfPagesInSubForum.ToString  ': frmMain.TSSLabelSet()
                ExtendedLog &= ForumParser.StageOfWork & vbNewLine
                frmMain.SaveExtendedLog()
                'Пример: http://rutracker.org/forum/tracker.php?search_id=WbvkLjq2ORWX&start=50
                PageOfSubforum = frmMain.DownloadWebPageWithCookie("http://rutracker.org/forum/tracker.php?search_id=" & search_id & "&start=" & Trim(Str((i - 1) * 50)), "http://rutracker.org/forum/index.php", Encoding.GetEncoding(1251))
            End If
            startIndexOfPage = 1
            NumberOfTorrentOnPage = 0
            Do
                'Сообщаем о номере обрабатываемой раздачи на странице
                NumberOfTorrentOnPage += 1
                'ForumParser.StageOfWork = "Подраздел " & SubForumAddress & " На Web-странице № " & CStr(i) & " разбираем раздачу № " & CStr(NumberOfTorrentOnPage) ': frmMain.TSSLabelSet()
                'сначала находим начало блока с раздачей "<tr class="tCenter hl-tr">"
                tor_BlockStart = PageOfSubforum.IndexOf("<tr class=""tCenter hl-tr"">", startIndexOfPage)
                If tor_BlockStart = -1 Then Exit Do Else startIndexOfPage = tor_BlockStart + 10
                'теперь блок </tr>
                tor_BlockEnd = PageOfSubforum.IndexOf("</tr>", tor_BlockStart)
                If tor_BlockEnd = -1 Then Exit Do
                'Теперь вырезаем описание одной раздачи, и уже работаем с ним
                PageOfSubforumCropped = Mid(PageOfSubforum, tor_BlockStart, tor_BlockEnd - tor_BlockStart)

                'Номер раздачи
                'сразу за ним вылавливаем блок href="./viewtopic.php?t=
                fp1 = PageOfSubforumCropped.IndexOf("href=""./viewtopic.php?t=")
                'И теперь вылавливаем номер раздачи
                web_AddressNumber = Val(Mid(PageOfSubforumCropped, fp1 + 25, 10))
                'Вылавливаем UNIX-время регистрации торрент-файла
                fp1 = PageOfSubforumCropped.LastIndexOf("<u>")
                Web_torrentRegisteredUnixTime = Val(Mid(PageOfSubforumCropped, fp1 + 4, 15))
                dt = dt.AddSeconds(Web_torrentRegisteredUnixTime)
                ''Web_torrentRegistered = dt.Year.ToString & "-" & dt.Month.ToString & "-" & dt.Day.ToString & " " & dt.Hour.ToString & ":" & dt.Minute.ToString
                Dim Web_torrentRegistered As String = dt.Day.ToString & "-" & MonthName(dt.Month, True) & "-" & Mid(dt.Year.ToString, 3) '& " " & dt.Hour.ToString & ":" & dt.Minute.ToString
                dt = dt.AddSeconds(-Web_torrentRegisteredUnixTime) 'Откатываюсь назад, чтобы и для следующей раздачи эту же переменную использовать
                'Находим соответствующую раздачу и вписываем в неё данные
                If torColl.Count > 0 Then
                    For i2 As Integer = 0 To torColl.Count - 1
                        If torColl.Item(i2).Web_AddressNumber = web_AddressNumber Then
                            If torColl.Item(i2).Web_SeedsFromSite > SavI.WebFindDateTorRegForNotMoreSeeds Then sovpalo1 += 1 : GoTo NextTor
                            torColl.Item(i2).Web_torrentRegisteredUNIXTime = Web_torrentRegisteredUnixTime
                            sovpalo2 += 1
                            GoTo NextTor
                        End If
                    Next
                End If
NextTor:
                ' ''создаём новый член коллекции и добавляем в неё
                ''Dim tmpTorrentInfo As New torrentInfo() With {.Web_AddressNumber = web_AddressNumber, .Web_torrentRegistered = Web_torrentRegistered}
                ''ExtendedLog &= web_AddressNumber & Web_torrentRegistered & vbNewLine
                ''torColl.Add(tmpTorrentInfo)
            Loop While tor_BlockStart > 0
        Next

    End Sub

    ''' <summary>
    ''' Находим даты регистрации торрент-файлов и когда последний раз был полный источник
    ''' </summary>
    ''' <param name="torColl"></param>
    ''' <remarks></remarks>
    Public Sub ReceiveAdditionalInfo(ByRef torColl As List(Of torrentInfo))
        Dim fp1, fp2, fp3, fp4 As Integer
        Dim PageOfSubforumCropped As String
        'Сначала подсчитаем кол-во страниц, которые необходимо выкачать и разобрать
        fp4 = 0
        fp3 = 1
        For i As Integer = 0 To torColl.Count - 1
            If torColl.Item(i).Web_SeedsFromSite <= SavI.WebFindDateTorRegForNotMoreSeeds And torColl.Item(i).Web_torrentRegistered.Length < 3 And torColl.Item(i).Status < 128 Then
                fp4 += 1
            ElseIf torColl.Item(i).Web_SeedsFromSite = 0 And torColl.Item(i).Status < 128 Then
                fp4 += 1
            End If
        Next i

        For i As Integer = 0 To torColl.Count - 1
            If torColl.Item(i).Web_SeedsFromSite <= SavI.WebFindDateTorRegForNotMoreSeeds And torColl.Item(i).Web_torrentRegistered.Length < 3 And torColl.Item(i).Status < 128 Then
                ForumParser.StageOfWork = "Скачиваем и разбираем веб-страницу № " & fp3.ToString & " / " & fp4.ToString & " ( " & torColl.Item(i).CommentText & " )" : fp3 += 1
                PageOfSubforumCropped = frmMain.DownloadWebPageWithCookie(torColl.Item(i).CommentText, _
                                                                          "http://rutracker.org/forum/viewforum.php?f=" & torColl.Item(i).Web_SubforumNumber.ToString, _
                                                                          System.Text.Encoding.GetEncoding(1251))
                'Теперь находим дату и время регистрации торрент-файла на трекере
                fp1 = PageOfSubforumCropped.IndexOf("<span title=""Зарегистрирован"">")
                If fp1 < 10 Then GoTo NoFindData
                fp1 = PageOfSubforumCropped.IndexOf(">", fp1 + 5)
                fp2 = PageOfSubforumCropped.IndexOf("<", fp1)
                str1 = Trim(Mid(PageOfSubforumCropped, fp1 + 3, fp2 - fp1 - 3))
                torColl.Item(i).Web_torrentRegisteredUNIXTime = ReturnUNIXTime(str1)
                'Если число сидов = 0, то находим, когда сид был последний раз
                If torColl.Item(i).Web_SeedsFromSite = 0 Then Call FindFullSourceDate(torColl, i, PageOfSubforumCropped)
            ElseIf torColl.Item(i).Web_SeedsFromSite = 0 And torColl.Item(i).Status < 128 Then 'Если число сидов = 0, то находим, когда сид был последний раз
                ForumParser.StageOfWork = "Скачиваем и разбираем веб-страницу № " & fp3.ToString & " / " & fp4.ToString & " ( " & torColl.Item(i).CommentText & " )" : fp3 += 1
                PageOfSubforumCropped = frmMain.DownloadWebPageWithCookie(torColl.Item(i).CommentText, _
                                                                          "http://rutracker.org/forum/viewforum.php?f=" & torColl.Item(i).Web_SubforumNumber.ToString, _
                                                                          System.Text.Encoding.GetEncoding(1251))
                Call FindFullSourceDate(torColl, i, PageOfSubforumCropped)
            End If
NoFindData:
        Next
    End Sub
    Private Sub FindFullSourceDate(ByRef torColl As List(Of torrentInfo), ByVal index As Integer, ByVal webpage As String)
        Dim fp1, fp2 As Integer
        'ByVal webpage As String, ByRef FullSource As String, ByRef seeds As Integer, ByRef peers As Integer
        If webpage.IndexOf("Полный источник") > 10 Then
            fp1 = webpage.IndexOf("Полный источник")
            fp1 = webpage.IndexOf(">", fp1 + 5)
            fp2 = webpage.IndexOf("<", fp1)
            torColl.Item(index).Web_FullSource = Mid(webpage, fp1 + 2, fp2 - fp1 - 1)
        Else ' За это короткое время успел появиться сид. Значит, обновляем данные по сидам и пирам
            'Разбираем строку <span class="seed">Сиды:&nbsp; <b>1</b>
            fp1 = webpage.IndexOf("span class=""seed""")
            If fp1 > 10 Then fp1 = webpage.IndexOf("<b>", fp1) Else GoTo NofindData
            If fp1 > 10 Then fp2 = webpage.IndexOf("</b>", fp1) Else GoTo NofindData
            If fp2 > 10 Then torColl.Item(index).Web_SeedsFromSite = Val(Mid(webpage, fp1 + 4, fp2 - fp1 - 3)) Else GoTo NofindData
            'Разбираем строку <span class="leech">Личи:&nbsp; <b>1</b>
            fp1 = webpage.IndexOf("span class=""leech""")
            If fp1 > 10 Then fp1 = webpage.IndexOf("<b>", fp1) Else GoTo NofindData
            If fp1 > 10 Then fp2 = webpage.IndexOf("</b>", fp1) Else GoTo NofindData
            If fp2 > 10 Then torColl.Item(index).Web_PeersFromSite = Val(Mid(webpage, fp1 + 4, fp2 - fp1 - 3)) Else GoTo NofindData
NofindData:
        End If
    End Sub

    ''' <summary>
    ''' Возвращает время в UNIX-времени
    ''' </summary>
    ''' <param name="DateSource">Пример входных данных: 28-Фев-10 20:16</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ReturnUNIXTime(ByVal DateSource As String) As Double
        DateSource = DateSource.Replace(" ", "-")
        DateSource = DateSource.Replace(":", "-")
        txts = DateSource.Split("-")
        'Для начала на всякий случай обнулим переменную даты-времени
        If dt.CompareTo(dtZero) <> 0 Then
            dt = dt.AddSeconds(-DateAndTime.DateDiff(DateInterval.Second, dtZero, dt))
        End If
        'Добавляем дни
        dt = dt.AddDays(Val(txts(0)) - 1)
        'Добавляем месяцы
        Select Case txts(1).ToLower
            Case "янв" ' : dt.AddMonths(0)
            Case "фев" : dt = dt.AddMonths(1)
            Case "мар" : dt = dt.AddMonths(2)
            Case "апр" : dt = dt.AddMonths(3)
            Case "май" : dt = dt.AddMonths(4)
            Case "июн" : dt = dt.AddMonths(5)
            Case "июл" : dt = dt.AddMonths(6)
            Case "авг" : dt = dt.AddMonths(7)
            Case "сен" : dt = dt.AddMonths(8)
            Case "окт" : dt = dt.AddMonths(9)
            Case "ноя" : dt = dt.AddMonths(10)
            Case "дек" : dt = dt.AddMonths(11)
        End Select
        'Добавляем годы
        dt = dt.AddYears(100 + Val(txts(2)) - 70)
        'Добавляем часы
        dt = dt.AddHours(Val(txts(3)))
        'Добавляем минуты
        dt = dt.AddMinutes(Val(txts(4)))
        Return DateAndTime.DateDiff(DateInterval.Second, dtZero, dt)
    End Function

    Public Function CompareTorrentsByWebName(ByVal firstTorrent As torrentInfo, ByVal secondTorrent As torrentInfo) As Integer

        If SavI.prog_DiscountGenreInSort = True Then
            If Mid(firstTorrent.Web_NameFromWeb, 1, 1) = "(" Then
                IndexOfCloseBracket = firstTorrent.Web_NameFromWeb.IndexOf(")")
                firstTorrentWebNameWithoutBrackets = Trim(Mid(firstTorrent.Web_NameFromWeb, IndexOfCloseBracket + 2))
            Else
                firstTorrentWebNameWithoutBrackets = Trim(firstTorrent.Web_NameFromWeb)
            End If
            If Mid(secondTorrent.Web_NameFromWeb, 1, 1) = "(" Then
                IndexOfCloseBracket = secondTorrent.Web_NameFromWeb.IndexOf(")")
                secondTorrentWebNameWithoutBrackets = Trim(Mid(secondTorrent.Web_NameFromWeb, IndexOfCloseBracket + 2))
            Else
                secondTorrentWebNameWithoutBrackets = Trim(secondTorrent.Web_NameFromWeb)
            End If
            Return String.Compare(firstTorrentWebNameWithoutBrackets, secondTorrentWebNameWithoutBrackets)
        Else
            Return String.Compare(Trim(firstTorrent.Web_NameFromWeb), Trim(secondTorrent.Web_NameFromWeb))
        End If
    End Function

    Public Function ReportsDGV_SumSize(ByVal lst As List(Of Integer), ByVal tCTemp As List(Of torrentInfo)) As String
        If lst.Count < 1 Then Return ""
        Dim sumSize As Double = 0
        Dim size As String = ""
        Dim sizeInBytes As Double = 0
        For Each ind As Integer In lst
            size = Trim(tCTemp(ind).Web_SizeKMGBytes)
            If size.Contains("GB") Then
                sizeInBytes = Val(size) * 2 ^ 30
            ElseIf size.Contains("MB") Then
                sizeInBytes = Val(size) * 2 ^ 20
            ElseIf size.Contains("KB") Then
                sizeInBytes = Val(size) * 2 ^ 10
            Else
                sizeInBytes = Val(size)
            End If
            sumSize += sizeInBytes
        Next
        If sumSize >= 2 ^ 30 Then
            Return Math.Round((sumSize / 2 ^ 30), 2).ToString & " GB"
        ElseIf sumSize >= 2 ^ 20 Then
            Return Math.Round((sumSize / 2 ^ 20), 2).ToString & " MB"
        ElseIf sumSize >= 2 ^ 10 Then
            Return Math.Round((sumSize / 2 ^ 10), 2).ToString & " KB"
        Else
            Return Math.Round((sumSize), 2).ToString & " B"
        End If
    End Function

    Public Sub CheckUserToSeeding(ByRef torColl As List(Of torrentInfo))
        Dim fp1, fp2 As Integer
        Dim PageOfSubforumCropped As String
        For i As Integer = 0 To torColl.Count - 1

            ForumParser.StageOfWork = "Скачиваем и разбираем веб-страницу № " & (i + 1).ToString & " / " & torColl.Count & _
                                      " ( " & torColl.Item(i).CommentText & " )"
            PageOfSubforumCropped = frmMain.DownloadWebPageWithCookie(torColl.Item(i).CommentText & "&spmode=full", _
                                                                      "http://rutracker.org/forum/viewforum.php?f=" & torColl.Item(i).Web_SubforumNumber.ToString, _
                                                                      System.Text.Encoding.GetEncoding(1251))
            'Выделяем раздел с таблицей сидов и ищем там имя пользователя
            fp1 = PageOfSubforumCropped.IndexOf("id=""seeders-tbl""") : If fp1 < 100 Then GoTo NoFindDataSeed
            fp2 = PageOfSubforumCropped.IndexOf("</table>", fp1) : If fp2 < 100 Then GoTo NoFindDataSeed
            str1 = Mid(PageOfSubforumCropped, fp1, fp2 - fp1).Replace("<wbr>", "") : If str1.Length < 1 Then GoTo NoFindDataSeed
            System.Web.HttpUtility.HtmlDecode(str1)
            If str1.IndexOf(CheckUserToSeeding_Username) > 50 Then
                torColl.Item(i).TorrentQueueOrder = -1
                torColl.Item(i).Status = 138
            End If
NoFindDataSeed:
            'Выделяем раздел с таблицей личей и ищем там имя пользователя
            fp1 = PageOfSubforumCropped.IndexOf("id=""leechers-tbl""") : If fp1 < 100 Then GoTo NoFindDataLeech
            fp2 = PageOfSubforumCropped.IndexOf("</table>", fp1) : If fp2 < 100 Then GoTo NoFindDataLeech
            str1 = Mid(PageOfSubforumCropped, fp1, fp2 - fp1).Replace("<wbr>", "") : If str1.Length < 1 Then GoTo NoFindDataLeech
            If str1.IndexOf(CheckUserToSeeding_Username) > 50 Then
                torColl.Item(i).TorrentQueueOrder = 5 'Здесь может быть любой число, главное больше нуля
                torColl.Item(i).Status = 138
            End If
NoFindDataLeech:
        Next

    End Sub
    Public Function CheckForum() As Boolean
        Dim testpage As String = frmMain.DownloadWebPageWithCookie("http://rutracker.org/forum/index.php", "", System.Text.Encoding.GetEncoding(1251))
        If DownloadWebPageAnswer(0) = "0" Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
