Imports System.Collections.ObjectModel
Imports System.Net
Imports System.Text
Imports mshtml 'На будущее: чтобы это работало, не забыть импортировать в свойствах проекта пространство имён Microsoft.mshtml 
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class frmMain
    Dim IsExit As Boolean = False
    Dim whatTOstartInBWorker As Integer
    Dim WithEvents TimerSec As New System.Timers.Timer
    Dim WithEvents TimerShowStageOfWork As New System.Timers.Timer
    Dim TimerIsStarted As Boolean = False
    Dim TimerIsStartedIn As Long
    Dim elapsedtime As Long
    Dim elapsedtimeH As Long
    Dim elapsedtimeM As Long
    Dim elapsedtimeS As Long
    Dim torrList As ReadOnlyCollection(Of String)
    ''' <summary>
    ''' Здесь храним всё, включая необработанные и не того подфорума файлы. Сначала пишем название файла, затем - инфу о нём.
    ''' </summary>
    ''' <remarks></remarks>
    Dim NamesListOld As New List(Of String)
    ''' <summary>
    ''' А здесь храним список файлов, отвергнутых алгоритмами
    ''' </summary>
    ''' <remarks></remarks>
    Dim NamesListOldBadFiles As New List(Of String)
    Dim NumberOfFilesInFolder As Int32
    Dim fs As FileStream
    Dim br As BinaryReader
    'Этот блок переменных используется в процедуре CompareTorrents
    Dim IndexOfCloseBracket As Integer
    Dim firstTorrentWebNameWithoutBrackets, secondTorrentWebNameWithoutBrackets As String
    ''' <summary>
    ''' Название файла расширенного лога
    ''' </summary>
    ''' <remarks></remarks>
    Dim NameOfFile As String
    ''' <summary>
    ''' Сюда копируем данные о раздачах текущего подраздела
    ''' </summary>
    ''' <remarks></remarks>
    Dim tCTemp As New List(Of torrentInfo)
    ''' <summary>
    ''' При сборе отчёта по подразделу сюда записываются индексы раздач с кол-вом сидов = индекс в скобках
    ''' </summary>
    ''' <remarks></remarks>
    Dim ReportTablNeedToDnld(10) As List(Of Integer)
    Dim ReportListOfSeed As New List(Of Integer)
    ''' <summary>
    ''' Каждый элемент состоит из: тип (0 - текст, 1 - переменная) и значение
    ''' </summary>
    ''' <remarks></remarks>
    Dim ReportTemplateList As New List(Of String)
    'Эта пара переменных используется при дебаге для показа общей таблицы
    Dim tabpage As New TabPage
    Dim dtZero As New DateTime(1970, 1, 1, 0, 0, 0)
    Dim TorCollStopAll As New List(Of torrentInfo)
    Private Sub Start()
        'Задаём переменные
        ObrabotkaStartovala = True
        ExtendedLog = ""
        NameOfFile = NowDayTimeFull() & ".log"
        SaveExtendedLog()
        
        ''If VerifySettings_NumberOfErrors > 0 Then
        ''    MsgBox("Есть ошибки в настройках. Исправьте их и щелкните кнопу ""Проверить настройки"".", vbOKOnly, "Ошибка")
        ''    Exit Sub
        ''End If

        ''Select Case whatTOstartInBWorker
        ''    Case 0, 1, 10
        If SavI.torrentClientName = 1 Then
            'Если торрент-клиент utorrent, то проверяем наличие папки с торрент-файлами
            If My.Computer.FileSystem.DirectoryExists(SavI.torrentTorrentsPath) = False Then
                MsgBox("Папки с торрент-файлами не существует или она указана неправильно.", vbOKOnly, "Ошибка")
                Exit Sub
            End If
            TSSLabel1.Text = "Составляем список торрент-файлов"
            torrList = My.Computer.FileSystem.GetFiles(SavI.torrentTorrentsPath, FileIO.SearchOption.SearchAllSubDirectories, "*.torrent")
            ExtendedLog &= "Папка с торрент-файлами: " & SavI.torrentTorrentsPath & vbNewLine
            ExtendedLog &= "Количество найденных файлов в папке и вложенных папках: " & torrList.Count & vbNewLine : SaveExtendedLog()
            If torrList.Count < 1 Then
                MessageBox.Show("torrent-файлы не обнаружены.")
                Exit Sub
            End If
            NumberOfFilesInFolder = torrList.Count
        End If
        ''End Select

        'Обновляем/очищаем элементы
        ''Select Case whatTOstartInBWorker
        ''    Case 1, 3
        torrentsCollection.Clear()
        dgv1.Rows.Clear()
        txtReport.Text = ""
        txtReportInForum.Text = ""
        Reports.Clear()
        For i As Integer = 0 To SubForumsList.Count - 1
            Reports.Add(New Class_Report)
        Next
        cbSelectSubforum.Items.Clear()
        Dim txt2 As String
        For Each ss As Class_Subforum In SubForumsList
            txt2 = ss.Name
            If ss.InnerList IsNot Nothing Then
                If ss.InnerList.Count > 0 Then
                    txt2 = "(+) " & txt2
                End If
            End If
            cbSelectSubforum.Items.Add(txt2)
        Next
        ''End Select

        ''Select Case whatTOstartInBWorker
        ''    Case 1, 4
        'Получаем токен, и одновременно проверяем доступность торрент-клиента
        TC.ReceiveTorClientSessionToken()
        If DownloadWebPageAnswer(0) = "Error" Then
            MessageBox.Show(Me, "Недоступен торрент-клиент. Дальнейшая обработка невозможна." & vbNewLine & _
                            "Проверьте правильность настроек доступа к торрент-клиенту", "Ошибка доступа", vbOKOnly, MessageBoxIcon.Error)
            ExtendedLog &= "Недоступен торрент-клиент. Дальнейшая обработка невозможна." & vbNewLine
            ObrabotkaStartovala = False
            Exit Sub
        End If
        ''End Select
        
        'Проверяем: если приказано включить ограничения скоростей в торрент-клиенте, то притормаживаем его на время обработки
        If SavI.LimitSpeedDownloadIs = True Or SavI.LimitSpeedUploadIs = True Then TC.LimitSpeedTorrentClient("ON")
        
        ''Select Case whatTOstartInBWorker
        ''    Case 1, 3
        If ForumParser.CheckForum = False Then
            If ObrabotkaStartovalaByTimer = False Then
                MessageBox.Show("Форум в данный момент недоступен." & Environment.NewLine & _
                                "Проверьте подключение к Интернету." & Environment.NewLine & _
                                "Текст ошибки: " & DownloadWebPageAnswer(1), "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TSSLabel1.Text = "Форум в данный момент недоступен. Попробуйте позже."
            Else
                TSSLabel1.Text = "Форум в данный момент недоступен. Перезапуск таймера."
                GUI("restarttimer")
            End If
            ObrabotkaStartovala = False
            Exit Sub
        End If

        If SubForumsList.Count < 1 And whatTOstartInBWorker > 0 Then
            MsgBox("Список обрабатываемых форумов пуст. Добавьте хотя бы один подфорум для обработки", vbOKOnly, "Ошибка")
            Exit Sub
        Else 'Подсчитываем, у скольких стоит галочка "Обрабатывать подраздел"
            Dim SelectedSubforumsCount As Integer = 0
            For Each subf As Class_Subforum In SubForumsList
                If subf.InnerList_IsCreate = False Then
                    If subf.IsProcessSubforum = True Then SelectedSubforumsCount += 1
                Else
                    If subf.InnerList_ProcessParent = True Then SelectedSubforumsCount += 1
                    If subf.InnerList IsNot Nothing Then
                        If subf.InnerList.Count > 0 Then
                            For jj As Integer = 0 To subf.InnerList.Count - 1
                                If subf.InnerList.Item(jj).IsProcessSubforum = True Then SelectedSubforumsCount += 1
                            Next
                        End If
                    End If
                End If
            Next
            If SelectedSubforumsCount = 0 Then
                MsgBox("У всех подразделов (в т.ч. вложенных) в ""Настройках"" снята галочка ""Обрабатывать подраздел""." & Environment.NewLine & _
                       "Поставьте галочку хотя бы на одном из них.", vbOKOnly, "Предупреждение")
                Exit Sub
            End If
        End If
        ''End Select

        GUI("block")

        Try
            BWorker.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(Me, "В данный момент обработка невозможна. Попробуйте позже.", "Сообщение", vbOKOnly, MessageBoxIcon.Information)
            Exit Sub
        End Try

    End Sub

    Private Sub BWorker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BWorker.DoWork
        Select Case whatTOstartInBWorker
            Case 0 'Запуск -> Обработать все торрент-файлы подряд (старый способ)
                Call ReceiveInfoFromTorrentFiles()
                Call ProcessListOfLinks()
            Case 1 'Запуск -> Обработать подраздел(ы)
                ''                If IsNeedPauseBeforeWebRequests = True Then
                ''                    'Выжидаем несколько секунд, чтобы скорости пришли в норму
                ''                    StageOfWork = "Изменили скорости закачки и(или) раздачи, ждём 15 секунд" : BWorker.ReportProgress(0)
                ''#If CONFIG = "Release" Then
                ''                            Threading.Thread.Sleep(15000)
                ''#End If
                ''                End If
                If SavI.Site_Cookie.Length < 15 Then
                    StageOfWork = "Получаем кукис"
                    SaveExtendedLog(StageOfWork) : BWorker.ReportProgress(0)
                    SavI.Site_Cookie = ReceiveCookie(SavI.Site_Username, SavI.Site_Password, RefreshCredentials) 'Получаем кукис
                    Call SaveSettingsToFile()
                End If

                'Почему-то из другого класса не срабатывает процедура обращения к BWorker.ReportProgress
                TimerShowStageOfWork.Enabled = True
                Call ForumParser.ReceiveInfoFromWebPages(torrentsCollection, SavI.WebFindDateTorRegIs)
                TimerShowStageOfWork.Enabled = False

                If SavI.torrentClientName = 1 Then 'Если торрент-клиент - utorrent, то парсим торрент-файлы
                    Call AddInfosFromTorrentFiles()
                End If

                Call AddInfoFromTorrentClient(torrentsCollection)

                If SavI.WebFindDateTorRegIs = True Then
                    'Возможно, для какого-либо из форумов надо ПОСЛЕ получения инфы их торрент-файлов и торрент-клиентов
                    '.. ещё раз добрать инфу из форума. Для этого и делается этот вызов
                    TimerShowStageOfWork.Enabled = True
                    Call ForumParser.ReceiveAdditionalInfo(torrentsCollection)
                    TimerShowStageOfWork.Enabled = False
                End If

                If SavI.torrentClientWhere < 2 Then
                    Call ChangeTorrentsCollectionData()
                    StageOfWork = "Ждём 10 секунд, чтобы статусы раздач в торрент-клиенте установились и опрашиваем его снова" : BWorker.ReportProgress(0)
#If CONFIG = "Release" Then
                            Threading.Thread.Sleep(10000)
#End If
                    Call AddInfoFromTorrentClient(torrentsCollection)
                End If
                If SavI.StatRepIsSendStatRep = True Then Call CreateAndSendStatRep()
                If SavI.DontAutoShowReports = False Then Call CreateReportsOfProcessedSubforums()
            Case 2 'Запуск -> Создать и отобразить отчеты
                Call CreateReportsOfProcessedSubforums()
            Case 3 'Запуск -> Проверить пользователя на сидирование
                TimerShowStageOfWork.Enabled = True
                Call ForumParser.ReceiveInfoFromWebPages(torrentsCollection, False)
                Call ForumParser.CheckUserToSeeding(torrentsCollection)
                TimerShowStageOfWork.Enabled = False
                Call CreateReportsOfProcessedSubforums()
            Case 4 ' Запуск -> Остановить все раздачи в торрент-клиенте
                Call OprosTorrentClienta(TorCollStopAll)
                Call StopAllTorrents(TorCollStopAll)
            Case 10 'Запуск -> Получить данные из торрент-файлов
                ReceiveInfoFromTorrentFiles()
        End Select
    End Sub
    
    ''' <summary>
    ''' Управляем внешним видом и поведением элементов GUI
    ''' </summary>
    ''' <param name="input">restarttimer,block,refreshtorrfileserrors</param>
    ''' <remarks></remarks>
    Private Sub GUI(ByVal input As String)
        Select Case input.ToLower
            Case "restarttimer"
                If TimerIsStarted = True Then
                    'останавливаем
                    Timer.Enabled = False
                    TimerSec.Enabled = False
                    'и запускаем
                    Timer.Enabled = True
                    TimerIsStartedIn = Now.Ticks
                    TimerToolStripDropDownButton1.Image = WindowsApplication1.My.Resources.start
                    'TimerToolStripDropDownButton1.ToolTipText = "Таймер включен."
                    TimerSec.Enabled = True
                End If
            Case "block"
                TimerToolStripDropDownButton1.Enabled = False
                If TimerIsStarted = True Then
                    Timer.Enabled = False
                    TimerSec.Enabled = False
                End If
                ФайлToolStripMenuItem.Enabled = False
                ЗапускToolStripMenuItem.Enabled = False
                TSSTorrFilesParsing.Enabled = False : TSSTorrFilesParsing.ToolTipText = ""
            Case "unblock"
                'Пока перенёс, ибо не особенно и надо
            Case "refreshtorrfileserrors"
                If ListOfInfoFromTorrentFiles.TorrFilesErrors Is Nothing = False Then
                    If ListOfInfoFromTorrentFiles.TorrFilesErrors.Length > 0 Then
                        TSSTorrFilesParsing.Image = WindowsApplication1.My.Resources.Errorpic
                        TSSTorrFilesParsing.ToolTipText = "Ошибки при прочтении торрент-файлов. Щелкните для показа подробностей."
                    Else
                        TSSTorrFilesParsing.Image = WindowsApplication1.My.Resources.OK
                        TSSTorrFilesParsing.ToolTipText = "Торрент-файлы прочитаны без ошибок"
                    End If
                End If
        End Select
    End Sub
  
    Private Sub ReceiveInfoFromTorrentFiles()
        Dim parser As TorrentParser
        StageOfWork = "Получаем данные из торрент-файлов" : StageOfWorkShow()
        ExtendedLog &= StageOfWork & vbNewLine
        'Подготавливаем переменные
        ListOfInfoFromTorrentFiles.Clear()
        ListOfInfoFromTorrentFiles.Capacity = torrList.Count + 20
        ListOfInfoFromTorrentFiles.TorrFilesErrors = ""
        NamesListOld.Clear()
        NamesListOldBadFiles.Clear()

        Dim NumberOfProcessedFiles As Int32 = 0 'Счетчик обработанных файлов (не обязательно принадлежащих нужному трекеру)
        'теперь для каждого из торрент-файлов:
        For Each ii In torrList 'ii - полные адреса файлов
            ExtendedLog &= ii & vbTab
            Dim TorInfo As New Class_InfoFromTorrentFile

            TorInfo.FullFilename = ii '=================Добавляем полное имя файла

            Try
                fs = New FileStream(ii, FileMode.Open)
                br = New BinaryReader(fs, System.Text.Encoding.ASCII)
                parser = New TorrentParser(br) 'Вот здесь-то при создании экземпляра и происходит получение данных
                br.Close()
                fs.Close()
            Catch ex As Exception
                ListOfInfoFromTorrentFiles.TorrFilesErrors &= ii & " - " & ex.Message & Environment.NewLine
                ExtendedLog &= "ошибка получения данных из торрент-файла"
                GoTo AddToListAndNextFile
            End Try

            TorInfo.Hash = parser.InfoHash '=================Добавляем хэш

            If parser.Comment Is Nothing Then 'Если же комм. есть, но нулевой длины, то см. ниже
                NamesListOldBadFiles.Add(ii & " В торрент-файле нет комментария")
                ExtendedLog &= " В торрент-файле нет комментария"
                GoTo AddToListAndNextFile
            End If

            If parser.Comment.Length > 0 Then
                ExtendedLog &= parser.Comment & vbTab & parser.InfoHash & vbTab
                TorInfo.CommentText = parser.Comment
                If TorInfo.CommentText.Contains("torrents.ru") Then TorInfo.CommentText.Replace("torrents.ru", "rutracker.org")
                TorInfo.TrackerName = ForumParser.TrackerName(parser)
                'Этот старый If-End If оставлю, чтобы не усложнять код. Да он мало кому нужен
                If parser.Comment.Contains("rutracker.org") = False And parser.Comment.Contains("torrents.ru") = False Then
                    NamesListOldBadFiles.Add(ii & "  В торрент-файле в комментарии не найден текст  ""rutracker.org"" или ""torrents.ru""")
                Else
                    If whatTOstartInBWorker = 0 Then NamesListOld.Add(parser.Comment & "|" & ii)
                End If
            ElseIf parser.Comment.Length = 0 Then
                ExtendedLog &= "Комментарий нулевой длины" & vbTab & parser.InfoHash & vbTab
            End If
AddToListAndNextFile:
            ListOfInfoFromTorrentFiles.Add(TorInfo)
            'Отправляем инфу о количестве обработанных файлов
            NumberOfProcessedFiles += 1
            If NumberOfProcessedFiles / 10 = NumberOfProcessedFiles \ 10 Then
                StageOfWorkShow("Обработан торрент-файл № " & NumberOfProcessedFiles.ToString & " / " & torrList.Count)
            End If
            ExtendedLog &= vbNewLine
            If NumberOfProcessedFiles / 500 = NumberOfProcessedFiles \ 500 Then SaveExtendedLog()
        Next ii
        SaveExtendedLog()
        SaveSettingsToFile()
        StageOfWork = "RefreshTorrFilesErrors" : StageOfWorkShow()
    End Sub

#Region "Старая версия ReceiveInfoFromTorrentFiles"
    ''    Private Sub ReceiveInfoFromTorrentFiles()
    ''        StageOfWork = "Получаем данные из торрент-файлов" : BWorker.ReportProgress(0)
    ''        ExtendedLog &= StageOfWork & vbNewLine
    ''        'Подготавливаем переменные
    ''        ListOfInfoFromTorrentFiles.Clear()
    ''        ListOfInfoFromTorrentFiles.Capacity = torrList.Count + 20
    ''        NamesListOld.Clear()
    ''        NamesListOldBadFiles.Clear()

    ''        Dim NumberOfProcessedFiles As Int32 = 0 'Счетчик обработанных файлов (не обязательно принадлежащих rutracker.org или torrents.ru)
    ''        Dim torrentFileContent As String ' Содержимое торрент-файла в формате String
    ''        Dim torrentFileHashInString As String = "" ' хэш в виде шестнадцатеричных чисел
    ''        Dim commentAddress As Integer = -1
    ''        Dim CommentLenght As Int16 = -1
    ''        Dim CommentText As String = ""
    ''        'теперь для каждого из торрент-файлов:
    ''        For Each ii In torrList
    ''            Try
    ''                'считываем весь файл в переменную
    ''                torrentFileContent = My.Computer.FileSystem.ReadAllText(ii, System.Text.Encoding.Default)
    ''            Catch ex As Exception
    ''                GoTo NotProcessedFile
    ''            End Try
    ''            ExtendedLog &= ii & vbTab
    ''            'Проверяем наличие слова comment в файле
    ''            commentAddress = Val(torrentFileContent.IndexOf("comment"))
    ''            ' Если не нашли эту последовательность, то пишем в List о необработанном файле, чтобы его выловить и вручную обработать
    ''            If commentAddress < 0 Then
    ''                NamesListOldBadFiles.Add(ii & " В торрент-файле не найден текст ""comment""")
    ''                ExtendedLog &= " В торрент-файле не найден текст ""comment"""
    ''                GoTo NotProcessedFile
    ''            End If
    ''            If torrentFileContent.Contains("rutracker.org/ann?uk") = False And _
    ''                torrentFileContent.Contains("rutracker.net/ann?uk") = False And _
    ''                torrentFileContent.Contains("torrents.ru/announce") = False Then
    ''                NamesListOldBadFiles.Add(ii & " В торрент-файле не найден текст ""rutracker.org/ann?uk"" или ""rutracker.net/ann?uk"" или ""torrents.ru/announce""")
    ''                ExtendedLog &= " В торрент-файле не найден текст ""rutracker.org/ann?uk"" или ""rutracker.net/ann?uk"" или ""torrents.ru/announce"""
    ''                GoTo NotProcessedFile
    ''            End If
    ''            If commentAddress > 0 Then
    ''                'Если же комментарий есть, то далее записано число, в котором длина коммента
    ''                CommentLenght = CInt(Mid(torrentFileContent, commentAddress + 8, 2))
    ''                'Проверим, чтобы коммент был положительным числом
    ''                If CommentLenght < 5 Then
    ''                    NamesListOldBadFiles.Add(ii & "  В торрент-файле комментарий излишне короткий, его длина " & CommentLenght.ToString)
    ''                    ExtendedLog &= "  В торрент-файле комментарий излишне короткий, его длина " & CStr(CommentLenght)
    ''                    GoTo NotProcessedFile
    ''                End If
    ''                'а теперь копируем сам коммент
    ''                CommentText = Mid(torrentFileContent, commentAddress + 11, CommentLenght)
    ''                ExtendedLog &= CommentText & vbTab
    ''                'А теперь убедимся, что в комменте адрес на рутрекере. В противном сдучае идём на следующий файл
    ''                If CommentText.Contains("rutracker.org") = False And CommentText.Contains("torrents.ru") = False Then
    ''                    NamesListOldBadFiles.Add(ii & "  В торрент-файле в комментарии не найден текст  ""rutracker.org"" или ""torrents.ru""")
    ''                    GoTo NotProcessedFile
    ''                End If

    ''                Select Case HowToReceiveInfoAboutTorrentFiles
    ''                    Case 0
    ''                        NamesListOld.Add(CommentText)
    ''                    Case 1
    ''                        'ТЕПЕРЬ УЗНАЁМ ХЭШ ТОРРЕНТ-ФАЙЛА
    ''                        torrentFileHashInString = ComputeTorrentHash(ii)
    ''                        ExtendedLog &= torrentFileHashInString & vbTab
    ''                        'Вбрасываем данные в коллекцию
    ''                        Dim TorInfo As New Class_InfoFromTorrentFile
    ''                        TorInfo.CommentText = CommentText
    ''                        TorInfo.FullFilename = ii
    ''                        TorInfo.Hash = torrentFileHashInString
    ''                        ListOfInfoFromTorrentFiles.Add(TorInfo)
    ''                        ''For Each idg As torrentInfo In torrentsCollection
    ''                        ''    If idg.CommentText = CommentText Then
    ''                        ''        idg.Filename = ii
    ''                        ''        idg.Hash = torrentFileHashInString
    ''                        ''        ExtendedLog &= "УСПЕХ: Совпадающий адрес найден. Хэш добавлен."
    ''                        ''        'И после успешного добавления инфы уходим на другой файл.
    ''                        ''        GoTo NotProcessedFile
    ''                        ''    End If
    ''                        ''Next
    ''                End Select
    ''            End If
    ''NotProcessedFile:  'неподходящий файл: не тот подфорум, нет комментария, коммент коротковат,....
    ''            'Отправляем инфу о количестве обработанных файлов
    ''            NumberOfProcessedFiles += 1
    ''            If NumberOfProcessedFiles / 10 = NumberOfProcessedFiles \ 10 Then StageOfWork = "Получили данные из торрент-файла № " & NumberOfProcessedFiles.ToString & " / " & torrList.Count : BWorker.ReportProgress(0)
    ''            ExtendedLog &= vbNewLine
    ''            If NumberOfProcessedFiles / 100 = NumberOfProcessedFiles \ 100 Then SaveExtendedLog()
    ''            ' ''Проверяем, есть ли команда остановиться
    ''            ''If BWorker.CancellationPending Then
    ''            ''    Exit Sub
    ''            ''End If
    ''        Next ii
    ''        SaveSettingsToFile()
    ''    End Sub
#End Region

    Private Sub AddInfosFromTorrentFiles()
        Dim sovpalo As Integer = 0
        SaveExtendedLog("Добавляем информацию, собранную из торрент-файлов")
        If ListOfInfoFromTorrentFiles.Count < 1 Or SavI.torrentRefreshInfoFromTorFilesAlways = True Then
            ReceiveInfoFromTorrentFiles()
            GoTo ParseFilesAlready
        End If
        'Сравним кол-во элементов в torrList и torrentsCollection
        If ListOfInfoFromTorrentFiles.Count <> torrList.Count Then
            ReceiveInfoFromTorrentFiles()
            GoTo ParseFilesAlready
        End If
        'Теперь сравним, совпадают ли полные адреса торрент-файлов в torlist и torrentsCollection - в этом случае парсим файлы
        For i As Integer = 0 To torrList.Count - 1
            If torrList.Item(i) <> ListOfInfoFromTorrentFiles.Item(i).FullFilename Then
                ReceiveInfoFromTorrentFiles()
                GoTo ParseFilesAlready
            End If
        Next
ParseFilesAlready:
        'теперь для каждого из торрент-файлов:
        For ii = 0 To ListOfInfoFromTorrentFiles.Count - 1
            If ii / 50 = ii \ 50 Then StageOfWorkShow("Добавлена информация из " & ii.ToString & " / " & (ListOfInfoFromTorrentFiles.Count - 1).ToString & " торрент-файлов")
            If ForumParser.TrackerNameIsGood(ListOfInfoFromTorrentFiles.Item(ii).TrackerName) = True Then
                'Вбрасываем данные в коллекцию: хэш, полное имя файла, комментарий
                For Each idg As torrentInfo In torrentsCollection
                    If idg.CommentText = ListOfInfoFromTorrentFiles.Item(ii).CommentText Then
                        sovpalo += 1
                        idg.Filename = ListOfInfoFromTorrentFiles.Item(ii).FullFilename
                        idg.Hash = ListOfInfoFromTorrentFiles.Item(ii).Hash
                        ExtendedLog &= idg.CommentText & vbTab & idg.Hash & vbTab & idg.Filename & vbNewLine
                        Exit For 'и после успешного добавления инфы уходим на следующий элемент.
                    End If
                Next
            End If
        Next ii
    End Sub

    ''' <summary>
    ''' Опрашиваем торрент-клиент, наполняя список информацией
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddInfoFromTorrentClient(ByRef torDest As List(Of torrentInfo))
        Dim torColl As New List(Of torrentInfo)
        OprosTorrentClienta(torColl)
        SaveExtendedLog("Добавляем данные, собранные из торрент-клиента, в базу данных")
        StageOfWork = "Добавляем данные, собранные из торрент-клиента, в базу данных" : If ObrabotkaStartovala = True Then BWorker.ReportProgress(0)
        For iInit As Integer = 0 To torColl.Count - 1
            If iInit / 50 = iInit \ 50 Then StageOfWorkShow("Добавлена информация из " & iInit.ToString & " / " & (torColl.Count - 1).ToString & " раздач")
            Select Case SavI.torrentClientName
                Case 1
                    'Ориентируясь по хэшу, находим индекс нужной раздачи
                    For iDest As Integer = 0 To torDest.Count - 1
                        'Если есть совпадающий хэш, то заполняем данную запись коллекции
                        'ВНИМАНИЕ! Буквы в хэше раздачи должны быть маленькие, хотя это принудительно задаётся в строке ниже. Примеры:
                        ' Правильно:  "3fbb31c50912f60d385e1d69a88f97db3e7202f8"
                        ' Неправильно:"3FBB31C50912F60D385E1D69A88F97DB3E7202F8"
                        If torDest(iDest).Hash = torColl.Item(iInit).Hash.ToLower Then 'используется
                            'extract status
                            torDest(iDest).Status = torColl.Item(iInit).Status 'используется
                            'вбрасываем имя раздачи в коллекцию
                            torDest(iDest).Name = torColl.Item(iInit).Name 'используется
                            'вбрасываем label раздачи в коллекцию
                            torDest(iDest).Label = torColl.Item(iInit).Label 'используется
                            'Теперь вносим данные в коллекцию
                            torDest(iDest).Size = torColl.Item(iInit).Size 'используется
                            torDest(iDest).PercentProgress = torColl.Item(iInit).PercentProgress
                            torDest(iDest).Downloaded = torColl.Item(iInit).Downloaded
                            torDest(iDest).Uploaded = torColl.Item(iInit).Uploaded
                            torDest(iDest).Ratio = torColl.Item(iInit).Ratio
                            torDest(iDest).UploadSpeed = torColl.Item(iInit).UploadSpeed
                            torDest(iDest).DownloadSpeed = torColl.Item(iInit).DownloadSpeed
                            torDest(iDest).ETA = torColl.Item(iInit).ETA

                            torDest(iDest).PeersConnected = torColl.Item(iInit).PeersConnected
                            torDest(iDest).PeersInSwarm = torColl.Item(iInit).PeersInSwarm
                            torDest(iDest).SeedsConnected = torColl.Item(iInit).SeedsConnected
                            torDest(iDest).SeedsInSwarm = torColl.Item(iInit).SeedsInSwarm
                            torDest(iDest).Availability = torColl.Item(iInit).Availability
                            ''If torColl.Item(iInit).Hash = "C462AD2804DD24CA684D8ADEBA345EFDA56D7235".ToLower Then
                            ''    torColl.Item(iInit).Hash = "C462AD2804DD24CA684D8ADEBA345EFDA56D7235".ToLower
                            ''End If
                            torDest(iDest).TorrentQueueOrder = torColl.Item(iInit).TorrentQueueOrder 'используется
                            torDest(iDest).Remaining = torColl.Item(iInit).Remaining
                        End If
                    Next
                Case 2
                    'Ориентируясь по комментарию, находим индекс нужной раздачи
                    For iDest As Integer = 0 To torDest.Count - 1
                        If torDest(iDest).CommentText = torColl.Item(iInit).CommentText Then '+
                            torDest(iDest).DownloadDir = torColl.Item(iInit).DownloadDir '+
                            torDest(iDest).Hash = torColl.Item(iInit).Hash '+
                            torDest(iDest).TorrentQueueOrder = torColl.Item(iInit).TorrentQueueOrder  '+
                            torDest(iDest).Remaining = torColl.Item(iInit).Remaining '+
                            'вбрасываем имя раздачи в коллекцию
                            torDest(iDest).Name = torColl.Item(iInit).Name '+
                            'extract status
                            torDest(iDest).Status = torColl.Item(iInit).Status '+
                            'Теперь вносим данные в коллекцию
                            torDest(iDest).Size = torColl.Item(iInit).Size '+
                        End If
                    Next
            End Select
        Next
    End Sub

    Friend Sub OprosTorrentClienta(ByRef torColl As List(Of torrentInfo))
        SaveExtendedLog("Опрос торрент-клиента")
        StageOfWork = "Запрос о закачках из торрент-клиента" : If ObrabotkaStartovala = True Then BWorker.ReportProgress(0)
        If SavI.torrentClientWhere < 2 Then
            ' Запрашиваем из торрент-клиента инфу о раздачах
            torrentClientAnswer = TC.ReceivetorrentClientAnswer
            If DownloadWebPageAnswer(0) = "0" Then
                ExtendedLog &= "Данные из торрент-клиента получены успешно" & vbNewLine
                SaveExtendedLog()
            Else
                ExtendedLog &= "Возможно, неправильные настройки доступа к торрент-клиенту. Перезапустите программу." & vbNewLine
                SaveExtendedLog()
                MsgBox("Возможно, неправильные настройки доступа к торрент-клиенту. Перезапустите программу." & vbNewLine & vbNewLine & _
                         DownloadWebPageAnswer(1), vbOKOnly, "Ошибка обработки")
                Exit Sub
            End If
        Else
            Try
                torrentClientAnswer = My.Computer.FileSystem.ReadAllText(SavI.torrentClientAnswerFile, System.Text.Encoding.UTF8)
            Catch ex As Exception
            End Try
        End If

        ExtendedLog &= torrentClientAnswer & vbNewLine
        SaveExtendedLog()
        StageOfWork = "Полученные данные из торрент-клиента вносим в базу данных" : If ObrabotkaStartovala = True Then BWorker.ReportProgress(0)
        Call TC.ParsingResponseTorrentClient(torColl)
    End Sub

    ''' <summary>
    ''' Правка ярлыков и запуск-остановка раздач
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChangeTorrentsCollectionData()
        Dim text As String = ""
        If SavI.torrentClientName = 1 Then text = "Правка ярлыков и запуск-остановка раздач"
        If SavI.torrentClientName = 2 Then text = "Запуск-остановка раздач"
        SaveExtendedLog(text)
        StageOfWork = text : If ObrabotkaStartovala = True Then BWorker.ReportProgress(0)
        ''Создаем массив чисел: индекс в списке SubForumsList(номер подраздела) - нужен для узнавания настроек именования label в раздачах
        ''Сначала найдём максимальный номер в номерах раздач
        'Dim maxNumber As Integer = -5
        'For Each a As Class_Subforum In SubForumsList
        '    If a.Number > maxNumber Then maxNumber = a.Number
        'Next
        ''Теперь инициализируем массив
        'Dim IndexInSubForumsList(maxNumber) As Integer
        ''И в нужные индексы вгоним порядковый номер подфорума в SubForumsList
        'For i9 As Integer = 0 To SubForumsList.Count - 1
        '    IndexInSubForumsList(SubForumsList.Item(i9).Number) = i9
        'Next

        Dim IndexOfTorInTorColl As Integer

        Dim NewLabel As String = ""
        Dim Label_AllCom As String = ""
        Dim Label_CountOfAdded As Integer = 0
        Dim Start_AllCom As String = ""
        Dim Start_CountOfAdded As Integer = 0
        Dim Forcestart_AllCom As String = ""
        Dim Forcestart_CountOfAdded As Integer = 0
        Dim Stop_AllCom As String = ""
        Dim Stop_CountOfAdded As Integer = 0

        'Задаём стартовые значения индексам
        Dim CurrIndexInSFL As Integer = 0
        'Dim IndexOfFirstElemInSubf As Integer = 0, IndexOfLastElemInSubf As Integer = 0
        'IndexOfLastElemInSubf = IIf(Reports.Count > 1, Reports.Item(1).StartIndexInTorColl, torrentsCollection.Count - 1)
        
        For IndexOfTorInTorColl = 0 To torrentsCollection.Count - 1
            If IndexOfTorInTorColl / 50 = IndexOfTorInTorColl \ 50 Then StageOfWork = text & "и № " & (IndexOfTorInTorColl + 1).ToString & " / " & torrentsCollection.Count.ToString
            If ObrabotkaStartovala = True Then BWorker.ReportProgress(0)
            If torrentsCollection(IndexOfTorInTorColl).Hash.Length = 40 Then
                ''Старый вариант
                'CurrIndexInSFL = IndexInSubForumsList(torrentsCollection(IndexOfTorInTorColl).Web_SubforumNumber)
                'Новый вариант
                Do
                    If CurrIndexInSFL < Reports.Count - 1 Then
                        If IndexOfTorInTorColl < Reports.Item(CurrIndexInSFL + 1).StartIndexInTorColl Then Exit Do
                    Else
                        If IndexOfTorInTorColl < torrentsCollection.Count - 1 Then Exit Do
                    End If
                    If IndexOfTorInTorColl = torrentsCollection.Count - 1 Then Exit Do
                    CurrIndexInSFL += 1
                Loop

                'Изменяем (если надо) текст в label раздачи
                If SubForumsList.Item(CurrIndexInSFL).ChangeLabelOfTorrent = True And SavI.torrentClientName = 1 Then
                    If SubForumsList.Item(CurrIndexInSFL).ChangeLabelOfTorrent_OnlyIfLabelIsEmpty = True And _
                        torrentsCollection(IndexOfTorInTorColl).Label.Length > 0 Then
                        'В этом случае ничего не делаем
                    Else
                        If SubForumsList.Item(CurrIndexInSFL).ChangeLabelOfTorrent_ToNameSubforum = True Then
                            NewLabel = SubForumsList.Item(CurrIndexInSFL).Name
                        Else
                            NewLabel = SubForumsList.Item(CurrIndexInSFL).ChangeLabelOfTorrent_AnotherName
                        End If
                        If NewLabel <> torrentsCollection(IndexOfTorInTorColl).Label Then
                            'Заменяем ярлык в коллекции..
                            torrentsCollection(IndexOfTorInTorColl).Label = NewLabel
                            '.. и кодируем ярлык для веб-запроса
                            TC.TorrentChangeLabel(torrentsCollection(IndexOfTorInTorColl).Hash, NewLabel, Label_AllCom, Label_CountOfAdded, False)
                        End If
                    End If
                End If

                'Теперь проверим, надо ли запустить раздачу, или наоборот - остановить
                If SubForumsList.Item(CurrIndexInSFL).AutoStartStop = True And torrentsCollection(IndexOfTorInTorColl).TorrentQueueOrder = -1 Then
                    If torrentsCollection(IndexOfTorInTorColl).Web_SeedsFromSite <= SubForumsList.Item(CurrIndexInSFL).AutoStartStop_NumberOfSeedsNotMore Then
                        If SubForumsList.Item(CurrIndexInSFL).AutoStartStop_StartForced = False Then
                            TC.TorrentStart(torrentsCollection, IndexOfTorInTorColl, Start_AllCom, Start_CountOfAdded, False, False)
                        Else
                            TC.TorrentStart(torrentsCollection, IndexOfTorInTorColl, Forcestart_AllCom, Forcestart_CountOfAdded, False, True)
                        End If
                    End If

                    If torrentsCollection(IndexOfTorInTorColl).Web_SeedsFromSite >= (SubForumsList.Item(CurrIndexInSFL).AutoStartStop_NumberOfSeedsNotMore + 2) Then
                        TC.TorrentStop(torrentsCollection, IndexOfTorInTorColl, Stop_AllCom, Stop_CountOfAdded, False)
                    End If
                End If

            End If
            If IndexOfTorInTorColl = torrentsCollection.Count - 1 Then 'При последнем проходе коллекции выполняем все неотправленные команды
                TC.AddAndSendCom("", "", Label_AllCom, Label_CountOfAdded, True)
                TC.AddAndSendCom("", "", Start_AllCom, Start_CountOfAdded, True)
                TC.AddAndSendCom("", "", Forcestart_AllCom, Forcestart_CountOfAdded, True)
                TC.AddAndSendCom("", "", Stop_AllCom, Stop_CountOfAdded, True)
            End If
        Next
    End Sub

    Public Sub BWorker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BWorker.ProgressChanged
        Select Case StageOfWork
            Case "PleaseEnterCaptcha"
                frmCaptcha.ShowDialog(Me)
            Case "RefreshTorrFilesErrors"
                GUI("RefreshTorrFilesErrors")
            Case Else
                TSSLabel1.Text = StageOfWork
        End Select
    End Sub
    Private Sub StageOfWorkShow(Optional ByVal stage As String = "")
        If BWorker.IsBusy = True Then
            If stage.Length > 0 Then StageOfWork = stage
            BWorker.ReportProgress(0)
        Else
            TSSLabel1.Text = stage
        End If

    End Sub
    Private Sub BWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWorker.RunWorkerCompleted
        Select Case whatTOstartInBWorker
            Case 0
                TSSLabel1.Text = "Формируем отчёт"
                Dim frmOld As New System.Windows.Forms.Form
                frmOld.FormBorderStyle = Windows.Forms.FormBorderStyle.SizableToolWindow
                frmOld.Width = 800
                frmOld.Height = 600
                frmOld.StartPosition = FormStartPosition.CenterParent
                Dim txtBox As New System.Windows.Forms.TextBox
                txtBox.Dock = DockStyle.Fill
                txtBox.Multiline = True
                txtBox.ScrollBars = ScrollBars.Both
                frmOld.Controls.Add(txtBox)
                Dim exp1 As String = ""
                exp1 = "Список успешно обработанных торрент-файлов:" & vbNewLine
                If NamesListOld.Count > 0 Then
                    For o1 As Integer = 0 To NamesListOld.Count - 1
                        exp1 += NamesListOld(o1) & vbNewLine
                    Next
                End If
                exp1 &= vbNewLine & vbNewLine & "Теперь список отвергнутых торрент-файлов:" & vbNewLine
                If NamesListOldBadFiles.Count > 0 Then
                    For o1 As Integer = 0 To NamesListOldBadFiles.Count - 1
                        exp1 += NamesListOldBadFiles(o1) & vbNewLine
                    Next
                End If
                txtBox.Text = exp1
                frmOld.ShowDialog()
            Case 1, 3
                'Если надо, возвращаем скорости назад
                If IsNeedPauseBeforeWebRequests = True Then TC.LimitSpeedTorrentClient("OFF")
                If SubForumsList.Count > 0 And cbSelectSubforum.Items.Count > 0 Then
                    cbSelectSubforum.SelectedIndex = 0
                    cbSelectSubforum_SelectedIndexChanged(sender, e)
                End If
            Case 2
                If SubForumsList.Count > 0 And cbSelectSubforum.Items.Count > 0 Then
                    cbSelectSubforum.SelectedIndex = 0
                    cbSelectSubforum_SelectedIndexChanged(sender, e)
                End If
            Case 4
                    'Если надо, возвращаем скорости назад
                    If IsNeedPauseBeforeWebRequests = True Then TC.LimitSpeedTorrentClient("OFF")
        End Select

        TSSLabel1.Text = "Готово"
        TSSLabelTimer.Text = "               "

        TSSTorrFilesParsing.Enabled = True
        TimerToolStripDropDownButton1.Enabled = True
        If TimerIsStarted = True Then Call TimerStartONToolStripMenuItem_Click(sender, e)
        ФайлToolStripMenuItem.Enabled = True
        ЗапускToolStripMenuItem.Enabled = True
        If ObrabotkaStartovala = True Then ПоказатьОтчётыToolStripMenuItem.Enabled = True

        SaveExtendedLog("Завершено")
        ObrabotkaStartovala = False
       
    End Sub

    ''' <summary>
    ''' Создаём отчеты об обработанных подфорумах
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CreateReportsOfProcessedSubforums()
        Dim text As String = "Генерируем отчеты"
        SaveExtendedLog(text)
        StageOfWork = text : If ObrabotkaStartovala = True Then BWorker.ReportProgress(0)

        Dim TorColl_startIndex As Integer = 0
        Dim TorColl_count As Integer = 0
        Dim leechers(255) As Integer, seeders(255) As Integer ' Количество раздач (скачиваемых или раздаваемых) с тем или иным статусом
        Dim leechersName(255) As String, seedersName(255) As String
        Dim extraLog As String = "" 'Сюда будем собирать лог
        Dim ReportInForumNumOfAddedTorrents As Integer 'Сколько ВСЕГО было добавлено во все подотчёты, включая текущий
        Dim ReportInForumNumOfCurrentSubreport As Integer
        Dim ReportInForumWhereInsertNumbersOfAddedTorrents As Integer 'Индекс, куда вставлять порядковыеномера торрентов, добавленных в текущем подотчёте
        Dim ReportInForumCountOfTorrentsAddedInPrevSubreports As Integer 'Сколько было добавлено в предыдущие подотчёты
        Dim ListsOfNONLoadedTorrents(10) As List(Of String) 'Списки незагруженных торрентов с сайта
        For i As Integer = 0 To 10
            ListsOfNONLoadedTorrents(i) = New List(Of String)
        Next
        Dim iz As Integer = -1
        Dim InnerListSelItemsCount As Integer

        For i As Integer = 0 To 10
            ReportTablNeedToDnld(i) = New List(Of Integer)
        Next
        'Инициализация стартовых значений переменных
        For t As Integer = 0 To 255
            leechers(t) = 0
            seeders(t) = 0
            leechersName(t) = ""
            seedersName(t) = ""
        Next
        ''Статусы раздач от utorrent:
        ''        личер
        leechersName(136) = "Личер: остановлен"
        leechersName(138) = "Личер: согласно парсингу веб-страниц. Но может и на паузе стоять!" 'Ввёл по просьбе Tokuchi_Toua
        leechersName(152) = "Личер: ошибка загрузки (удалены файлы?)"
        leechersName(200) = "Личер: в очереди"
        leechersName(232) = "Личер: на паузе (был в очереди загрузок)"
        leechersName(201) = "Личер: загружается"
        leechersName(233) = "Личер: на паузе (был на Запустить)"
        leechersName(137) = "Личер: принудительно загружается"
        leechersName(169) = "Личер: на паузе (был на Принудительно)"
        leechersName(194) = "Личер: ожидает в очереди проверки файлов" 'Transmission
        leechersName(130) = "Личер: проверка файлов" 'Transmission
        ''        сидер
        seedersName(136) = "Сидер: остановлен"
        seedersName(138) = "Сидер: согласно парсингу веб-страниц. Но может и на паузе стоять!" 'Ввёл по просьбе Tokuchi_Toua
        seedersName(152) = "Сидер: ошибка загрузки (удалены файлы?)"
        seedersName(200) = "Сидер: в очереди"
        seedersName(232) = "Сидер: на паузе (был В очереди раздач)"
        seedersName(201) = "Сидер: раздается"
        seedersName(233) = "Сидер: на паузе (был на Запустить)"
        seedersName(137) = "Сидер: принудительно раздается"
        seedersName(169) = "Сидер: на паузе (был на Принудительно)"
        seedersName(194) = "Сидер: ожидает в очереди проверки файлов" 'Transmission
        seedersName(130) = "Сидер: проверка файлов" 'Transmission

        Dim AddLine = Sub(ByRef report As Class_Report, txt As String)
                          Dim row1 As New Class_ReportLine
                          row1.Add(New Class_ReportCell)
                          row1.Add(New Class_ReportCell)
                          row1.Add(New Class_ReportCell With {.Value = txt})
                          report.ToDnldTable.Add(row1)
                          'ReportTable(iz).Add(row1)
                      End Sub
        For iz = 0 To SubForumsList.Count - 1
            extraLog = ""
            Try
                extraLog &= "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" & vbNewLine & "Внутренний лог процедуры создания отчётов" & vbNewLine & "Заданы переменные." & vbNewLine
                extraLog &= "===========================================ПОДРАЗДЕЛ " & SubForumsList.Item(iz).Number & " " & SubForumsList.Item(iz).Name & vbNewLine
                TorColl_startIndex = Reports.Item(iz).StartIndexInTorColl ' torrentsCollectionIndexesOfSubforums(iz) 
                extraLog &= "Стартовый индекс = " & TorColl_startIndex.ToString & vbNewLine
                If SubForumsList.Item(iz).IsProcessSubforum = True Then
                    InnerListSelItemsCount = 0
                    If SubForumsList.Item(iz).InnerList_IsCreate = True Then
                        If SubForumsList.Item(iz).InnerList IsNot Nothing Then
                            If SubForumsList.Item(iz).InnerList.Count > 0 Then
                                For Each il As Class_Subforum In SubForumsList.Item(iz).InnerList
                                    If il.IsProcessSubforum = True Then InnerListSelItemsCount += 1
                                Next
                            End If
                        End If
                        If SubForumsList.Item(iz).InnerList_ProcessParent = True Then InnerListSelItemsCount += 1
                        If InnerListSelItemsCount = 0 Then 'Если и все вложенные, и метеринский НЕ обрабатываются, то
                            Reports.Item(iz).ToDnldText.Append("Согласно Настройкам, данный подраздел и вложенные подразделы не обрабатываются.")
                            Reports.Item(iz).InForumSeeding.Append("Согласно Настройкам, данный подраздел и вложенные подразделы не обрабатываются.")
                            AddLine(Reports.Item(iz), "Согласно Настройкам, данный подраздел и вложенные подразделы не обрабатываются.")
                            GoTo NextSubf
                        End If
                    End If

                    If iz < (SubForumsList.Count - 1) Then
                        TorColl_count = Reports.Item(iz + 1).StartIndexInTorColl - Reports.Item(iz).StartIndexInTorColl : extraLog &= "Кол-во (не посл.) = " & TorColl_count.ToString & vbNewLine
                    Else
                        TorColl_count = torrentsCollection.Count - TorColl_startIndex : extraLog &= "Кол-во (посл.) = " & TorColl_count.ToString & vbNewLine
                    End If
                    'Очищаем заполняемые элементы
                    extraLog &= "Очищаем заполняемые элементы:" & vbNewLine
                    tCTemp.Clear()
                    For qq As Integer = 0 To 10
                        ListsOfNONLoadedTorrents(qq).Clear()
                        ReportTablNeedToDnld(qq).Clear()
                    Next
                    For qq2 As Integer = 0 To 255
                        leechers(qq2) = 0
                        seeders(qq2) = 0
                    Next
                    Reports.Item(iz).ToDnldTable.Clear()
                    Reports.Item(iz).ToDnldText.Remove(0, Reports.Item(iz).ToDnldText.Length)
                    Reports.Item(iz).InForumSeeding.Remove(0, Reports.Item(iz).InForumSeeding.Length)
                    Reports.Item(iz).InForumLeeching.Remove(0, Reports.Item(iz).InForumLeeching.Length)
                    'Reports(0, iz) = ""
                    'Reports(1, iz) = ""
                    'Reports(2, iz) = "" 'Сюда собираем отчёт о скачиваемых раздачах, а потом прибавляем к Reports(1,iz)
                    ReportListOfSeed.Clear()

                    'Копируем торренты текущего подраздела в отдельный список
                    tCTemp = torrentsCollection.GetRange(TorColl_startIndex, TorColl_count) : extraLog &= "Скопировали часть данных по текущему подразделу в подсписок" & vbNewLine
                    tCTemp.Sort(AddressOf ForumParser.CompareTorrentsByWebName) : extraLog &= "Отсортировали их" & vbNewLine
                    extraLog &= "Раскидываем статусы:" & vbNewLine
                    Reports.Item(iz).InForumSeeding.Append(SavI.Report.ReportAddTextBeforeReport)

                    ReportInForumNumOfAddedTorrents = 0
                    ReportInForumNumOfCurrentSubreport = 1
                    ReportInForumCountOfTorrentsAddedInPrevSubreports = 0
                    ReportInForumWhereInsertNumbersOfAddedTorrents = Reports.Item(iz).InForumSeeding.Length
                    For it As Integer = 0 To tCTemp.Count - 1
                        'Подсчитываем количество сидируемых раздач, разделяя их на группы по статусам
                        If tCTemp.Item(it).TorrentQueueOrder = -1 Then seeders(tCTemp.Item(it).Status) += 1 : extraLog &= "order -1, status = " & tCTemp.Item(it).Status.ToString & vbNewLine
                        If tCTemp.Item(it).TorrentQueueOrder > 0 Then leechers(tCTemp.Item(it).Status) += 1 : extraLog &= "order = " & tCTemp.Item(it).TorrentQueueOrder.ToString & _
                            " , leecher status = " & tCTemp.Item(it).Status.ToString & vbNewLine
                        'Отчет о сидируемых раздачах
                        If tCTemp.Item(it).Status >= 128 And tCTemp.Item(it).TorrentQueueOrder = -1 Then
                            'Reports(1, iz) &= "[url=" & tCTemp.Item(it).CommentText & "]" & System.Web.HttpUtility.HtmlDecode(tCTemp.Item(it).Web_NameFromWeb) & "[/url] " & _
                            '        tCTemp.Item(it).Web_SizeKMGBytes & vbNewLine : extraLog &= "Добавлен в отчет сидируемый " & tCTemp.Item(it).CommentText & vbNewLine

                            'Если ограничитель включён, и число сидов больше указанного, то НЕ добавляем сидируемую раздачу в отчёт в форум о сидируемых раздачах
                            If SavI.prog_ReportSeeding_ShowOnlySeedsNotMoreThanIs = True And tCTemp.Item(it).Web_SeedsFromSite > SavI.prog_ReportSeeding_ShowOnlySeedsNotMoreThanValue Then GoTo NotAppendInReport
                            Reports.Item(iz).InForumSeeding.Append(ReportCreateLine(tCTemp.Item(it)) & Environment.NewLine)
NotAppendInReport:


                            ReportListOfSeed.Add(it)
                            ReportInForumNumOfAddedTorrents += 1
                            If ReportInForumNumOfAddedTorrents / SavI.Report.ReportAddTextAfterEveryXTorrentsValue = _
                                                ReportInForumNumOfAddedTorrents \ SavI.Report.ReportAddTextAfterEveryXTorrentsValue Then
                                Reports.Item(iz).InForumSeeding.Append(SavI.Report.ReportAddTextAfterEveryXTorrentsTxt)
                                If Reports.Item(iz).InForumSeeding.Length > SavI.Report.ReportAddTextAfterReportMoreThanXBytesValue * ReportInForumNumOfCurrentSubreport Then
                                    'Вствляем номера добавленных раздач
                                    Reports.Item(iz).InForumSeeding.Insert(ReportInForumWhereInsertNumbersOfAddedTorrents, _
                                        "№№ " & (ReportInForumCountOfTorrentsAddedInPrevSubreports + 1).ToString & "-" & ReportInForumNumOfAddedTorrents.ToString & Environment.NewLine)
                                    'Теперь добавляем текст между сабрепортами
                                    Reports.Item(iz).InForumSeeding.Append(SavI.Report.ReportAddTextAfterReportMoreThanXBytesTxt)
                                    ReportInForumNumOfCurrentSubreport += 1
                                    'И теперь обновляем значения переменных
                                    ReportInForumCountOfTorrentsAddedInPrevSubreports = ReportInForumNumOfAddedTorrents
                                    ReportInForumWhereInsertNumbersOfAddedTorrents = Reports.Item(iz).InForumSeeding.Length
                                End If
                            End If
                        End If

                        'Отчет о скачиваемых раздачах - это для функции "Проверить пользователя на сидирование"
                        If tCTemp.Item(it).Status >= 128 And tCTemp.Item(it).TorrentQueueOrder > 0 Then
                            'Reports(2, iz) &= "[url=" & tCTemp.Item(it).CommentText & "]" & System.Web.HttpUtility.HtmlDecode(tCTemp.Item(it).Web_NameFromWeb) & "[/url] " & _
                            '        tCTemp.Item(it).Web_SizeKMGBytes & vbNewLine
                            Reports.Item(iz).InForumLeeching.Append(ReportCreateLine(tCTemp.Item(it)) & vbNewLine)
                        End If
                        If tCTemp.Item(it).Web_SeedsFromSite <= 10 And tCTemp.Item(it).Status < 128 Then
                            'Собираем адреса торрентов, которые надо скачать, распределяя по количеству сидов
                            ListsOfNONLoadedTorrents(tCTemp.Item(it).Web_SeedsFromSite).Add(tCTemp.Item(it).CommentText) : extraLog &= "Необходимо скачать " & tCTemp.Item(it).CommentText & vbNewLine
                            ReportTablNeedToDnld(tCTemp.Item(it).Web_SeedsFromSite).Add(it)
                        End If
                    Next
                    Reports.Item(iz).InForumSeeding.Append(SavI.Report.ReportAddTextAfterReport)
                    Reports.Item(iz).InForumSeeding.Insert(ReportInForumWhereInsertNumbersOfAddedTorrents, _
                            "№№ " & (ReportInForumCountOfTorrentsAddedInPrevSubreports + 1).ToString & "-" & ReportInForumNumOfAddedTorrents.ToString & Environment.NewLine)
                    Reports.Item(iz).InForumSeeding.Insert(0, "Общий размер хранимых раздач подраздела: " & ForumParser.ReportsDGV_SumSize(ReportListOfSeed, tCTemp) & vbNewLine)
                    If whatTOstartInBWorker = 3 Then Reports.Item(iz).InForumSeeding.Append(Environment.NewLine & Environment.NewLine & "Скачиваемые в данный момент раздачи:" & _
                        Environment.NewLine & Reports.Item(iz).InForumLeeching.ToString)

                    'Теперь собираем статистический отчет
                    Dim txt2 As String = "Раздач в подразделе: "
                    If SubForumsList.Item(iz).InnerList_IsCreate = True Then
                        If SubForumsList.Item(iz).InnerList IsNot Nothing Then
                            If SubForumsList.Item(iz).InnerList.Count > 0 Then
                                If SubForumsList.Item(iz).InnerList_ProcessParent = False Then
                                    txt2 = "Раздач во вложенных подразделах: "
                                Else
                                    txt2 = "Раздач в текущем и вложенных подразделах: "
                                End If

                            End If
                        End If
                    End If

                    Reports.Item(iz).ToDnldText.Append(txt2 & tCTemp.Count.ToString & vbNewLine & vbNewLine & _
                                     "Из них добавлены в торрент-клиент и имеют статус:" & vbNewLine & vbNewLine)
                    AddLine(Reports.Item(iz), txt2 & tCTemp.Count.ToString)
                    AddLine(Reports.Item(iz), "Из них добавлены в торрент-клиент и имеют статус:")
                    extraLog &= txt2 & tCTemp.Count.ToString & vbNewLine
                    'Выводим отчет по сидируемым раздачам
                    extraLog &= "Выводим отчет по сидируемым раздачам:" & vbNewLine
                    For qq4 As Integer = 0 To 255
                        If seeders(qq4) > 0 Then
                            If seedersName(qq4).ToString.Length > 0 Then
                                Reports.Item(iz).ToDnldText.Append(seedersName(qq4) & " = " & seeders(qq4) & " шт." & vbNewLine)
                                AddLine(Reports.Item(iz), seedersName(qq4) & " = " & seeders(qq4) & " шт.")
                            Else
                                Reports.Item(iz).ToDnldText.Append("Статус " & qq4.ToString & " = " & seeders(qq4) & " шт." & vbNewLine)
                                AddLine(Reports.Item(iz), "Статус " & qq4.ToString & " = " & seeders(qq4) & " шт.")
                            End If
                        End If
                    Next
                    'Выводим отчет по скачиваемым раздачам
                    extraLog &= "Выводим отчет по скачиваемым раздачам:" & vbNewLine
                    For qq4 As Integer = 0 To 255
                        If leechers(qq4) > 0 Then
                            If leechersName(qq4).ToString.Length > 0 Then
                                Reports.Item(iz).ToDnldText.Append(leechersName(qq4) & " = " & leechers(qq4) & " шт." & vbNewLine)
                                AddLine(Reports.Item(iz), leechersName(qq4) & " = " & leechers(qq4) & " шт.")
                            Else
                                Reports.Item(iz).ToDnldText.Append("Статус " & qq4.ToString & " = " & leechers(qq4) & " шт." & vbNewLine)
                                AddLine(Reports.Item(iz), "Статус " & qq4.ToString & " = " & leechers(qq4) & " шт.")
                            End If
                        End If
                    Next
                    Reports.Item(iz).ToDnldText.Append(Environment.NewLine)
                    AddLine(Reports.Item(iz), "")
                    'Теперь о раздачах, которые необходимо скачать
                    extraLog &= "Теперь о раздачах, которые необходимо скачать:" & vbNewLine
                    For w1 As Integer = 0 To 10
                        Reports.Item(iz).ToDnldText.Append("Количество нескачанных торрент-файлов с количеством сидов " & w1.ToString & " = " & ListsOfNONLoadedTorrents(w1).Count & Environment.NewLine)
                        Dim row2 As New Class_ReportLine
                        row2.Add(New Class_ReportCell)
                        row2.Add(New Class_ReportCell With {.Value = ForumParser.ReportsDGV_SumSize(ReportTablNeedToDnld(w1), tCTemp),
                                                            .Font = New Font("Arial", 9, FontStyle.Bold)})
                        row2.Add(New Class_ReportCell With {.Value = "Количество нескачанных торрент-файлов с количеством сидов " & w1.ToString & " = " & ReportTablNeedToDnld(w1).Count.ToString,
                                                            .Font = New Font("Arial", 9, FontStyle.Bold)})
                        Reports.Item(iz).ToDnldTable.Add(row2)
                        If ListsOfNONLoadedTorrents(w1).Count > 0 Then
                            For i As Integer = 0 To ListsOfNONLoadedTorrents(w1).Count - 1
                                Reports.Item(iz).ToDnldText.Append(ListsOfNONLoadedTorrents(w1).Item(i).ToString & Environment.NewLine)
                            Next
                        End If
                        If ReportTablNeedToDnld(w1).Count > 0 Then
                            For i As Integer = 0 To ReportTablNeedToDnld(w1).Count - 1
                                'Статус раздачи
                                Dim cell0 As New Class_ReportCell With {.Value = System.Web.HttpUtility.HtmlDecode(tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_Status)}
                                If tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_StatusColorTag.Length > 2 Then
                                    Try
                                        'todo Перенести в класс rutracker
                                        cell0.ForeColor = CallByName(WebStatColors, tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_StatusColorTag, CallType.Get)
                                    Catch ex As Exception
                                    End Try
                                End If
                                'todo Перенести в класс rutracker
                                Select Case tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_Status
                                    Case "*" : cell0.ToolTipText = "не проверено"
                                    Case "%" : cell0.ToolTipText = "проверяется"
                                    Case "&radic;" : cell0.ToolTipText = "проверено"
                                    Case "?" : cell0.ToolTipText = "недооформлено"
                                    Case "!" : cell0.ToolTipText = "не оформлено"
                                    Case "D" : cell0.ToolTipText = "повтор"
                                    Case "&copy;" : cell0.ToolTipText = "закрыто правообладателем"
                                    Case "x" : cell0.ToolTipText = "закрыто"
                                    Case "T" : cell0.ToolTipText = "временная"
                                    Case "&sum;" : cell0.ToolTipText = "поглощено"
                                    Case "#" : cell0.ToolTipText = "сомнительно"
                                    Case "&#8719;" : cell0.ToolTipText = "премодерация"
                                End Select
                                'Размер раздачи
                                Dim cell1 As New Class_ReportCell With {.Value = tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_SizeKMGBytes}
                                'Имя раздачи
                                Dim cell2 As New Class_ReportCell With {.CellType = "link",
                                                                        .Value = System.Web.HttpUtility.HtmlDecode(tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_NameFromWeb),
                                                                        .Link = tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).CommentText} 'Сюда вгоняем веб-адрес
                                'Полный источник
                                Dim cell3 As New Class_ReportCell With {.Value = tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_FullSource}
                                'Дата и время регистрации торрент-файла на трекере
                                Dim cell4 As New Class_ReportCell With {.Value = tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_torrentRegistered}
                                ''Dim fp1 As Double = DateAndTime.DateDiff(DateInterval.Second, dtZero, Now)
                                ''Dim fp2 As Double = tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_torrentRegisteredUNIXTime
                                If tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_torrentRegisteredUNIXTime > 100 Then
                                    'todo Перенести в класс rutracker
                                    If tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_Status = "&radic;" Or tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_Status = "#" Then
                                        If DateAndTime.DateDiff(DateInterval.Second, dtZero, Now) - tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_torrentRegisteredUNIXTime > 86400 * 30 Then
                                            cell4.BackColor = Color.FromArgb(0, 255, 0)
                                        ElseIf DateAndTime.DateDiff(DateInterval.Second, dtZero, Now) - tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_torrentRegisteredUNIXTime > 86400 * 20 Then
                                            cell4.BackColor = Color.FromArgb(255, 255, 0)
                                        End If
                                    End If
                                End If
                                'Число сидов
                                Dim cell5 As New Class_ReportCell With {.Value = tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_SeedsFromSite}
                                'Число пиров
                                Dim cell6 As New Class_ReportCell With {.Value = tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_PeersFromSite}
                                'Сохранение в файл
                                Dim cell7 As New Class_ReportCell With {.CellType = "bitmap"}
                                If tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_TorrentFileAddress.Length > 3 Then
                                    cell7.bitmapNum = EnumBitmaps.Diskette16pixblue
                                    cell7.Link = tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_TorrentFileAddress
                                Else
                                    cell7.bitmapNum = EnumBitmaps.Diskette16pixgrayscale
                                End If
                                'Отправка в торрент-клиент
                                Dim cell8 As New Class_ReportCell With {.CellType = "bitmap"}
                                If tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_TorrentFileAddress.Length > 3 Then
                                    cell8.bitmapNum = EnumBitmaps.Bittorrent16pixblue
                                    cell8.Link = tCTemp.Item(ReportTablNeedToDnld(w1).Item(i)).Web_TorrentFileAddress
                                Else
                                    cell8.bitmapNum = EnumBitmaps.Bittorrent16pixgrayscale
                                End If
                                'Собираем в строку
                                Dim row3 As New Class_ReportLine
                                row3.Add(cell0)
                                row3.Add(cell1)
                                row3.Add(cell2)
                                row3.Add(cell3)
                                row3.Add(cell4)
                                row3.Add(cell5)
                                row3.Add(cell6)
                                row3.Add(cell7)
                                row3.Add(cell8)
                                Reports.Item(iz).ToDnldTable.Add(row3)
                            Next
                        End If

                        ''For Each ti As torrentInfo In tCTemp
                        ''    If ti.Web_SeedsFromSite = w1 And ti.Status < 128 Then
                        ''        Dim ln2 As New Class_ReportLine
                        ''        ln2.Web_Status = System.Web.HttpUtility.HtmlDecode(ti.Web_Status)
                        ''        ln2.Web_SizeKMGBytes = System.Web.HttpUtility.HtmlDecode(ti.Web_SizeKMGBytes)
                        ''        ln2.NameLink = ti.CommentText
                        ''        ln2.FullSource = ti.Web_FullSource
                        ''        ln2.Web_torrentRegistered = ti.Web_torrentRegistered
                        ''        ln2.Seeds = ti.Web_SeedsFromSite
                        ''        ln2.Peers = ti.Web_PeersFromSite
                        ''        'ln.toSave = WindowsApplication1.My.Resources.Save_blue_16pix
                        ''        'ln.toTorClnt = WindowsApplication1.My.Resources.BitTorrentLogo_16pix
                        ''        ReportsOfProcessedSubforums(iz).Add(ln2)
                        ''    End If
                        ''Next
                    Next w1
                Else
                    Reports.Item(iz).ToDnldText.Append("Согласно Настройкам, данный подраздел не обрабатывался.")
                    Reports.Item(iz).InForumSeeding.Append("Согласно Настройкам, данный подраздел не обрабатывался.")
                    AddLine(Reports.Item(iz), "Согласно Настройкам, данный подраздел не обрабатывался.")
                End If
            Catch ee As Exception
                Reports.Item(iz).ToDnldText.Insert(0, vbNewLine & vbNewLine & "ВНИМАНИЕ!!! При создании отчета по этому подразделу возникла ошибка." & vbNewLine & _
                    "Пожалуйста, пришлите лог разработчику. Лог-файл текущей обработки находится в файле: " & NameOfFile & vbNewLine & vbNewLine)
                AddLine(Reports.Item(iz), "ВНИМАНИЕ!!! При создании отчета по этому подразделу возникла ошибка.")
                AddLine(Reports.Item(iz), "Пожалуйста, пришлите лог разработчику.")
                AddLine(Reports.Item(iz), "Лог-файл текущей обработки находится в файле: " & NameOfFile)
                ExtendedLog &= extraLog & "GetBaseException.StackTrace:" & vbNewLine & ee.GetBaseException.StackTrace & vbNewLine & "-----------------------------------------------" & vbNewLine
                If SavI.ExtLogEnabled = False Then
                    SavI.ExtLogEnabled = True
                    SaveExtendedLog()
                    SavI.ExtLogEnabled = False
                Else
                    SaveExtendedLog()
                End If
                'Throw New ApplicationException(ee.GetBaseException.ToString)
            End Try
NextSubf:
        Next
    End Sub
    Friend Sub ReportTemplateParse()
        If SavI.prog_ReportTemplate.Length < 1 Then Exit Sub
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim SOURCE() As String = SavI.prog_ReportTemplate.Split(vbLf)
        Dim LineExp As String = ""
        ReportTemplateList.Clear()
        For i = 0 To SOURCE.Length - 1
            j = 0
            Do
                If j > SOURCE(i).Length - 1 Then Exit Do
                If SOURCE(i).Chars(j) = "%" Then
                    LineExp = SOURCE(i).Chars(j)
                    Do
                        j += 1
                        If j > SOURCE(i).Length - 1 Then GoTo endProCto
                        LineExp &= SOURCE(i).Chars(j)
                    Loop While SOURCE(i).Chars(j) <> "%"
endProCto:
                    If LineExp.Length > 2 Then 'Если есть что-то между знаками процента, преобразуем в переменную
                        If LineExp.EndsWith("%") Then
                            LineExp = "1" & LineExp
                        Else
                            LineExp = "0" & LineExp
                        End If
                    ElseIf LineExp.Length = 2 Then 'Если не больше двух символов, то преобразуем в константу 
                        If LineExp.EndsWith("%") Then
                            LineExp = "0%"
                        Else
                            LineExp = "0" & LineExp
                        End If
                    ElseIf LineExp.Length = 1 Then
                        LineExp = "0%"
                    End If
                    ReportTemplateList.Add(String.Copy(LineExp))
                    LineExp = ""
                    j += 1
                Else
                    LineExp = SOURCE(i).Chars(j)
                    If j = SOURCE(i).Length - 1 Then GoTo endConst
                    If SOURCE(i).Chars(j + 1) = "%" Then GoTo endConst
                    Do
                        j += 1
                        If j > SOURCE(i).Length - 1 Then GoTo endConst
                        If SOURCE(i).Chars(j) = "%" Then
                            j -= 1
                            GoTo endConst
                        End If
                        LineExp &= SOURCE(i).Chars(j)
                    Loop
endConst:
                    ReportTemplateList.Add("0" & String.Copy(LineExp))
                    LineExp = ""
                    j += 1
                End If
            Loop
            If i < SOURCE.Length - 1 Then ReportTemplateList.Add("0" & Environment.NewLine)
        Next
    End Sub
    Friend Function ReportCreateLine(ByVal inp As torrentInfo) As String
        Dim str1 As String = ""
        Dim ProcedureName As String = ""
        If ReportTemplateList.Count < 1 Then Return "Настройки - Отчёты - Формат отображения.. - введите что-либо"
        For i = 0 To ReportTemplateList.Count - 1
            If ReportTemplateList.Item(i).StartsWith("0") Then str1 &= Mid(ReportTemplateList.Item(i), 2)
            If ReportTemplateList.Item(i).StartsWith("1") Then
                ProcedureName = Mid(ReportTemplateList.Item(i), 3, ReportTemplateList.Item(i).Length - 3)
                Try
                    str1 &= CallByName(inp, ProcedureName, CallType.Get)
                Catch ex As Exception
                    str1 &= Mid(ReportTemplateList.Item(i), 2)
                End Try
            End If
        Next
        Return str1
    End Function
#Region "Возвращает суммарный ""плавающий"" размер раздач"
    '' ''' <summary>
    '' ''' Возвращает суммарный "плавающий" размер раздач
    '' ''' </summary>
    '' ''' <param name="lst">Список индексов раздач</param>
    '' ''' <returns></returns>
    '' ''' <remarks></remarks>
    ''Private Function ReportsDGV_SumSize(ByVal lst As List(Of Integer)) As String
    ''    If lst.Count < 1 Then Return ""
    ''    Dim sumSize As Double = 0
    ''    Dim size As String = ""
    ''    Dim sizeInBytes As Double = 0
    ''    For Each ind As Integer In lst
    ''        size = Trim(tCTemp(ind).Web_SizeKMGBytes)
    ''        If size.Contains("GB") Then
    ''            sizeInBytes = Val(size) * 2 ^ 30
    ''        ElseIf size.Contains("MB") Then
    ''            sizeInBytes = Val(size) * 2 ^ 20
    ''        ElseIf size.Contains("KB") Then
    ''            sizeInBytes = Val(size) * 2 ^ 10
    ''        Else
    ''            sizeInBytes = Val(size)
    ''        End If
    ''        sumSize += sizeInBytes
    ''    Next
    ''    If sumSize >= 2 ^ 30 Then
    ''        Return Math.Round((sumSize / 2 ^ 30), 2).ToString & " GB"
    ''    ElseIf sumSize >= 2 ^ 20 Then
    ''        Return Math.Round((sumSize / 2 ^ 20), 2).ToString & " MB"
    ''    ElseIf sumSize >= 2 ^ 10 Then
    ''        Return Math.Round((sumSize / 2 ^ 10), 2).ToString & " KB"
    ''    Else
    ''        Return Math.Round((sumSize), 2).ToString & " B"
    ''    End If
    ''End Function
#End Region

    Private Sub НастройкиToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles НастройкиToolStripMenuItem.Click
        frmSettings.ShowDialog()
    End Sub

#Region "Вычисление хэша торрент-файла по алгоритму - надо добиться работоспособности и использовать вместо ComputeTorrentHash"
    'Переменные для вычисления хэша
    'Dim torrentFileContentByte() As Byte = {} ' Содержимое торрент-файла в формате Byte
    'Dim torrentFileContentByteCropped() As Byte = {}  ' Часть содержимого торрент-файла в формате Byte, подлежашая хешированию
    'Dim d6length() As Byte = {100, 54, 58, 108, 101, 110, 103, 116, 104}
    'Dim d6lengthEqualSymbols As Byte = 0
    'Dim d6lengthIndex As Integer = 0
    'Dim e9publisher() As Byte = {101, 57, 58, 112, 117, 98, 108, 105, 115, 104, 101, 114}
    'Dim e9publisherEqualSymbols As Byte = 0
    'Dim e9publisherIndex As Integer = 0
    'Dim torrentFileHash As Byte() ' Хэш торрент-файла в виде массива десятичных чисел
    'Dim sha As New System.Security.Cryptography.SHA1CryptoServiceProvider

    '            torrentFileContentByte = My.Computer.FileSystem.ReadAllBytes(ii)
    '            'Находим адреса контрольных байтовых последовательностей
    '            Dim i As Integer, j As Integer
    '            For i = 0 To torrentFileContentByte.Length - 12
    '                'Находим последовательность "d6:length"
    '                If d6lengthIndex < 1 Then
    '                    For j = 0 To 8
    '                        If torrentFileContentByte(i + j) = d6length(j) Then d6lengthEqualSymbols += 1
    '                    Next
    '                    If d6lengthEqualSymbols = 9 Then
    '                        d6lengthIndex = i
    '                        GoTo IsFindd6lengthIndex
    '                    Else
    '                        d6lengthEqualSymbols = 0
    '                    End If
    '                End If
    'IsFindd6lengthIndex:
    '                'Находим последовательность "e9:publisher"
    '                If e9publisherIndex < 1 Then
    '                    For j = 0 To 11
    '                        If torrentFileContentByte(i + j) = e9publisher(j) Then e9publisherEqualSymbols += 1
    '                    Next
    '                    If e9publisherEqualSymbols = 12 Then
    '                        e9publisherIndex = i : Exit For
    '                    Else
    '                        e9publisherEqualSymbols = 0
    '                    End If
    '                End If
    '            Next
    '            'Задаём необходимую длину байтовому массиву, иначе в следующей строке будет исключение
    '            Array.Resize(torrentFileContentByteCropped, e9publisherIndex - d6lengthIndex + 1)
    '            'Теперь копируем хэшируемую часть в переменную
    '            Array.ConstrainedCopy(torrentFileContentByte, d6lengthIndex, torrentFileContentByteCropped, 0, e9publisherIndex - d6lengthIndex + 1)
    '            '...вычисляем хэш
    '            torrentFileHash = sha.ComputeHash(torrentFileContentByteCropped)
    '            '...переводим хэш в шестнадцатеричный вид
    '            torrentFileHashInString = ""
    '            For i2 As Integer = 0 To torrentFileHash.Length - 1
    '                torrentFileHashInString &= Conversion.Hex(torrentFileHash(i2))
    '            Next
    ' обмен данными с внешним процессом через функции StdIn, StdOut и StdErr
#End Region

    ''' <summary>
    ''' Скачивает веб-страницу, в т.ч. вбрасывает ошибки и результаты в DownloadWebPageWithoutCookieAnswer()
    ''' </summary>
    ''' <param name="WebAddress">Адрес скачиваемой веб-страницы</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DownloadWebPageWithoutCookie(ByVal WebAddress As String, ByVal myEncoding As System.Text.Encoding, Optional ByVal Usrname As String = "", Optional ByVal Password As String = "") As String
        'Очищаем переменные, на всякий случай
        DownloadWebPageAnswer(0) = "" : DownloadWebPageAnswer(1) = ""
        'теперь надо по найденному адресу скачать страницу
        WebClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")
        If Usrname.Length > 0 And Password.Length > 0 Then WebClient.Credentials = New System.Net.NetworkCredential(Usrname, Password)
        'теперь самое небезопасное - чтение из Инета
        Dim s As String 'сюда копируется содержимое потока
        ' Счетчик количества попыток выкачивания веб-страницы
        Dim CounterOfTriesDownloadingHTML As Int16 = 1
NextTryDownloadingHTML:
        Try
            Dim data As System.IO.Stream = WebClient.OpenRead(WebAddress)
            Dim reader As New System.IO.StreamReader(data, myEncoding)
            s = reader.ReadToEnd()
            reader.Close()
            data.Close()
            DownloadWebPageAnswer(0) = "0" : DownloadWebPageAnswer(1) = s
        Catch ex As Exception
            ' Выждем секунду-две секунды и попробуем ещё раз
            System.Threading.Thread.Sleep(1000 * CounterOfTriesDownloadingHTML)
            CounterOfTriesDownloadingHTML += 1
            If CounterOfTriesDownloadingHTML > 3 Then
                s = "Error: " & ex.Message
                DownloadWebPageAnswer(0) = "Error" : DownloadWebPageAnswer(1) = ex.Message
            Else
                GoTo NextTryDownloadingHTML
            End If
        End Try
        DownloadWebPageWithoutCookie = s
    End Function

    Public Function ReceiveCookie(ByRef Username As String, ByRef Password As String, ByRef RefrCred As Boolean) As String
        RefreshCredentials = False
        Dim sQueryString As String = ""
        Dim fp1, fp2 As Integer
#If CONFIG = "Debug-ReceiveAllInfoFromFiles" Then
        Return "TestCookie"
#Else
        Dim CounterOfTriesDownloadingCookie As Int16 = 1
NextTryDownloadingCookie:
        Try
NewRequestToSite:
            'авторизация на сайте
            myHttpWebRequest = HttpWebRequest.Create("http://login.rutracker.org/forum/login.php")
            myHttpWebRequest.Method = "POST"
            myHttpWebRequest.Accept = "text/html, application/xhtml+xml, */*"
            'Попробуем всегда сделать этот реферер
            'If sQueryString = "" Then
            '    myHttpWebRequest.Referer = "http://rutracker.org/forum/index.php" 'т.е. первый запрос
            'Else
            myHttpWebRequest.Referer = "http://login.rutracker.org/forum/login.php" 'не первый запрос, т.е. с капчей
            'End If
            myHttpWebRequest.Headers.Add("Accept-Language", "ru-RU")
            myHttpWebRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)"
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded"
            myHttpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate")
            myHttpWebRequest.KeepAlive = True 'Вот не уверен, что это правильная строка. Может и вообще не нужна, но кто тогда будет давать строчку Connection: Keep-Alive
            myHttpWebRequest.Headers.Add("Pragma", "no-cache")
            myHttpWebRequest.Headers.Add(HttpRequestHeader.Cookie, "spylog_test=1")
            myHttpWebRequest.AutomaticDecompression = DecompressionMethods.GZip

            'ставим False, чтобы при получении кода 302 не делать автоматический редирект
            myHttpWebRequest.AllowAutoRedirect = False

            'Куки-контейнер создаём
            myHttpWebRequest.CookieContainer = New CookieContainer

            'передаем параметры
            If sQueryString = "" Then
                sQueryString = "login_username=" & System.Web.HttpUtility.UrlEncode(Username, Encoding.Default) & "&" & _
                    "login_password=" & System.Web.HttpUtility.UrlEncode(Password, Encoding.Default) & "&login=%C2%F5%EE%E4"
            End If
            Dim ByteArr As Byte() = Encoding.GetEncoding(1251).GetBytes(sQueryString)
            myHttpWebRequest.ContentLength = ByteArr.Length()
            myHttpWebRequest.GetRequestStream().Write(ByteArr, 0, ByteArr.Length)
            SaveExtendedLog("Собрали HTTP-запрос кукиса. Выполняем его.")
            'выполняем запрос
            myHttpWebResponse = myHttpWebRequest.GetResponse()

            '================Выделяем саму веб-страницу
            SaveExtendedLog("Веб-запрос кукиса успешно выполнен. Разбираем ответ.")
            Dim receiveStream As Stream = myHttpWebResponse.GetResponseStream()
            Dim encode As Encoding = System.Text.Encoding.GetEncoding("windows-1251") 'Вместо "windows-1251" в примере было "utf-8"
            ' Pipes the response stream to a higher level stream reader with the required encoding format. 
            Dim readStream As New StreamReader(receiveStream, encode)
            'Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Response stream received")
            Dim textOfStream As String = readStream.ReadToEnd
            ' Releases the resources of the Stream.
            readStream.Close()
            ' Releases the resources of the response.
            myHttpWebResponse.Close()
            '/================ конец выделения веб-страницы
            'Теперь смотрим на содержимое ответа, если есть текст "http://static.rutracker.org/captcha" - то показываем юзверю капчу и просим ответить

            If textOfStream.Contains("http://static.rutracker.org/captcha") = True Then
                'Вот кусок HTML-кода обрабатываемой страницы
                '<div><img src="http://static.rutracker.org/captcha/0/36/b4baa24342b680282a8a02048472bd1c.jpg?364017591" width="120" height="72" alt="pic" /></div>
                '<div>
                '<input type="hidden" name="cap_sid" value="qPAmLkxHKgW1hZONEG37" />
                '<input type="text" name="cap_code_00c20a1ddd0d925ef10a82b1e661510b" value="" size="25" class="bold" />
                '</div>
                'Выделяем URL капчи
                Dim captchaStartOffset As Integer = textOfStream.IndexOf("http://static.rutracker.org/captcha")
                Dim captchaEndOffset As Integer = textOfStream.IndexOf("?", captchaStartOffset + 10)
                CaptchaURL = Mid(textOfStream, captchaStartOffset + 1, captchaEndOffset - captchaStartOffset)
                CaptchaUsername = Username
                CaptchaPassword = Password
                CaptchaTextIsWritten = False
                If BWorker.IsBusy = True Then
                    StageOfWork = "PleaseEnterCaptcha" : BWorker.ReportProgress(0)
                Else
                    frmCaptcha.ShowDialog()
                End If
                Do
                    System.Threading.Thread.Sleep(250)
                Loop While CaptchaTextIsWritten = False
                If CaptchaUsername <> Username Or CaptchaPassword <> Password Then RefreshCredentials = True
                Username = CaptchaUsername
                Password = CaptchaPassword
                'frmCaptcha.ShowDialog(Me)
                'собираем запрос, напр.:
                'redirect=index.php&login_username=[ИМЯ]&login_password=[ПАРОЛЬ]&cap_sid=qPAmLkxHKgW1hZONEG37&cap_code_00c20a1ddd0d925ef10a82b1e661510b=8k8dc&login=%C2%F5%EE%E4
                Dim cap_sid_start As Integer = textOfStream.IndexOf("name=""cap_sid"" value=""") + 22
                Dim cap_sid_end As Integer = textOfStream.IndexOf("""", cap_sid_start + 3)
                Dim cap_sid As String = Mid(textOfStream, cap_sid_start + 1, cap_sid_end - cap_sid_start)

                Dim cap_code_start As Integer = textOfStream.IndexOf("name=""cap_code") + 6
                Dim cap_code_end As Integer = textOfStream.IndexOf("""", cap_code_start + 3)
                Dim cap_code As String = Mid(textOfStream, cap_code_start + 1, cap_code_end - cap_code_start)

                sQueryString = "redirect=index.php&login_username=" & System.Web.HttpUtility.UrlEncode(Username, Encoding.Default) & _
                    "&" & "login_password=" & System.Web.HttpUtility.UrlEncode(Password, Encoding.Default) & _
                    "&cap_sid=" & cap_sid & _
                    "&" & cap_code & _
                    "=" & Captcha & _
                    "&login=%C2%F5%EE%E4"
                GoTo NewRequestToSite
            End If

            'получаем кукис
            If Not String.IsNullOrEmpty(myHttpWebResponse.Headers("Set-Cookie")) Then

                If myHttpWebResponse.Cookies.Count > 0 Then
                    Dim cook As Cookie
                    For Each cook In myHttpWebResponse.Cookies

                    Next
                End If

                fp1 = myHttpWebResponse.Headers("Set-Cookie").IndexOf("bb_data")
                fp2 = myHttpWebResponse.Headers("Set-Cookie").IndexOf(";", fp1 + 1)
                sQueryString = Mid(myHttpWebResponse.Headers("Set-Cookie"), fp1 + 1, fp2 + 1) & " spylog_test=1"
                SaveExtendedLog("Получен кукис: " & myHttpWebResponse.Headers("Set-Cookie"))
                Return sQueryString
            End If

        Catch exWE As System.Net.WebException
            SaveExtendedLog("Ошибка при " & CounterOfTriesDownloadingCookie.ToString & "-й попытке получения кукиса:" & vbNewLine & _
                            "Message=" & exWE.Message & vbNewLine & "Data=" & exWE.Data.ToString & vbNewLine & _
                            "Response.ContentType=" & exWE.Response.ContentType.ToString & vbNewLine & "Response.Headers=" & exWE.Response.Headers.ToString)
        Catch ex As Exception
            SaveExtendedLog("Ошибка при " & CounterOfTriesDownloadingCookie.ToString & "-й попытке получения кукиса:" & vbNewLine & _
            "Message=" & ex.Message & vbNewLine & "Data=" & ex.Data.ToString & vbNewLine)
            myHttpWebResponse.Close()
            'Возможны ошибки скачивания из-за загруженности канала
            'Выждем секунду-две секунды и попробуем ещё раз
            System.Threading.Thread.Sleep(1000 * CounterOfTriesDownloadingCookie)
            CounterOfTriesDownloadingCookie += 1
            If CounterOfTriesDownloadingCookie <= 3 Then GoTo NextTryDownloadingCookie
        End Try
        Return ""
        'todo сделать корректую остановку при 3-х неудачных попытках получения кукиса
        'If Site_IsLogged = False And ReceiveAllInfoFromFiles = False Then MsgBox("Получение cookie завершилось неудачей.", vbOKOnly) : Return
#End If
    End Function

    ''' <summary>
    ''' Скачивание файла POST-методом чанками
    ''' </summary>
    ''' <param name="URL">Веб-адрес скачиваемого файла</param>
    ''' <param name="Referer">Реферер</param>
    ''' <param name="FileName">Передаём вызывающей процедуре, под каким именем сохранять скачиваемый файл</param>
    ''' <param name="FileContent">Передаём вызывающей процедуре содержимое скачиваемого файла</param>
    ''' <remarks></remarks>
    Friend Sub ReceiveFile(ByVal URL As String, ByVal Referer As String, ByRef FileName As String, ByRef FileContent() As Byte)
        ReDim FileContent(0)
        Dim cookie As String
        Dim contentOfPage As String
NextTryDownloadingFile:
        If SavI.prog_SaveTorrFiles_DownloadByAnotherUser = False Then
            If SavI.Site_Cookie.IndexOf("bb_data") <> -1 Then
                cookie = Mid(SavI.Site_Cookie, SavI.Site_Cookie.IndexOf("bb_data") + 1, _
                                         SavI.Site_Cookie.IndexOf(";", SavI.Site_Cookie.IndexOf("bb_data") + 1) - SavI.Site_Cookie.IndexOf("bb_data") + 1)
            Else
                cookie = Mid(SavI.Site_Cookie, SavI.Site_Cookie.IndexOf("GUID") + 1, _
                                         SavI.Site_Cookie.IndexOf(";", SavI.Site_Cookie.IndexOf("GUID") + 1) - SavI.Site_Cookie.IndexOf("GUID") + 1)
            End If

        ElseIf SavI.Site_CookieAnotherUser.Length < 20 Then
            SavI.Site_CookieAnotherUser = ReceiveCookie(SavI.prog_SaveTorrFiles_DownloadByAnotherUser_Username, SavI.prog_SaveTorrFiles_DownloadByAnotherUser_Password, RefreshCredentials)
            SaveSettingsToFile()
            cookie = Mid(SavI.Site_CookieAnotherUser, SavI.Site_CookieAnotherUser.IndexOf("bb_data") + 1, _
                         SavI.Site_CookieAnotherUser.IndexOf(";", SavI.Site_CookieAnotherUser.IndexOf("bb_data") + 1) - SavI.Site_CookieAnotherUser.IndexOf("bb_data") + 1)
        Else
            cookie = Mid(SavI.Site_CookieAnotherUser, SavI.Site_CookieAnotherUser.IndexOf("bb_data") + 1, _
                         SavI.Site_CookieAnotherUser.IndexOf(";", SavI.Site_CookieAnotherUser.IndexOf("bb_data") + 1) - SavI.Site_CookieAnotherUser.IndexOf("bb_data") + 1)
        End If
        Dim bb_dl As String = Mid(URL, URL.IndexOf("=") + 2)
        cookie &= " bb_dl=" & bb_dl & "; spylog_test=1"
        Dim CounterOfTriesDownloadingCookie As Int16 = 1
        Try
            'авторизация на сайте
            myHttpWebRequest = HttpWebRequest.Create(URL)
            myHttpWebRequest.Method = "POST"
            myHttpWebRequest.Accept = "text/html, application/xhtml+xml, */*"
            myHttpWebRequest.Referer = Referer  'т.е. первый запрос
            myHttpWebRequest.Headers.Add("Accept-Language", "ru-RU")
            myHttpWebRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)"
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded"
            myHttpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate")
            myHttpWebRequest.KeepAlive = True 'Вот не уверен, что это правильная строка. Может и вообще не нужна, но кто тогда будет давать строчку Connection: Keep-Alive
            myHttpWebRequest.Headers.Add("Pragma", "no-cache")
            myHttpWebRequest.Headers.Add(HttpRequestHeader.Cookie, cookie)
            myHttpWebRequest.AutomaticDecompression = DecompressionMethods.GZip

            'ставим False, чтобы при получении кода 302 не делать автоматический редирект
            myHttpWebRequest.AllowAutoRedirect = False

            'передаем параметры
            ''If sQueryString = "" Then
            ''    sQueryString = "login_username=" & System.Web.HttpUtility.UrlEncode(Username, Encoding.Default) & "&" & _
            ''        "login_password=" & System.Web.HttpUtility.UrlEncode(Password, Encoding.Default) & "&login=%C2%F5%EE%E4"
            ''End If
            'Dim ByteArr As Byte() = Encoding.GetEncoding(1251).GetBytes(sQueryString)
            myHttpWebRequest.ContentLength = 0
            'myHttpWebRequest.GetRequestStream().Write(ByteArr, 0, ByteArr.Length)

            'выполняем запрос
            myHttpWebResponse = myHttpWebRequest.GetResponse()

            If myHttpWebResponse.ContentType.Contains("text/html") = True Then
                contentOfPage = ""
                Dim myStreamReader As New System.IO.StreamReader(myHttpWebResponse.GetResponseStream, Encoding.GetEncoding(1251))
                contentOfPage = myStreamReader.ReadToEnd()
                myHttpWebResponse.Close()
                If contentOfPage.Contains("исчерпали суточный лимит скачиваний торрент-файлов") Then
                    FileName = "DailyLimitExceeded"
                    Exit Sub
                End If
                If SavI.prog_SaveTorrFiles_DownloadByAnotherUser = False Then
                    SavI.Site_Cookie = ReceiveCookie(SavI.Site_Username, SavI.Site_Password, RefreshCredentials)
                Else
                    SavI.Site_CookieAnotherUser = ReceiveCookie(SavI.prog_SaveTorrFiles_DownloadByAnotherUser_Username, SavI.prog_SaveTorrFiles_DownloadByAnotherUser_Password, RefreshCredentials)
                End If
                SaveSettingsToFile()
                GoTo NextTryDownloadingFile
            End If

            Dim receiveStream As Stream = myHttpWebResponse.GetResponseStream()
            'todo потенциальное переполнение
            Dim buffer(2 * 10 ^ 6) As Byte
            Dim n As Integer = 0
            Dim bytesRead As Integer = 0 'Суммарный объём всех чанков
            Do
                n = receiveStream.Read(buffer, bytesRead, 5 * 10 ^ 5)
                If n = 0 Then Exit Do
                bytesRead += n
            Loop

            Dim StartInd As Integer = myHttpWebResponse.ContentType.IndexOf("name=""") + "name=""".Length
            Dim EndInd As Integer = myHttpWebResponse.ContentType.IndexOf("""", StartInd + 2)
            FileName = Mid(myHttpWebResponse.ContentType, StartInd + 1, EndInd - StartInd)
            receiveStream.Close()
            myHttpWebResponse.Close()

            ReDim FileContent(bytesRead - 1)
            Array.Copy(buffer, 0, FileContent, 0, bytesRead)

            ''Сохраняем файл
            ''If SavI.prog_SavingTorrFiles = 0 Then
            ''    Call frmSettings.SelSaveFile("Сохранить торрент-файл как", "Торрент-файл|*.torrent", NameOfFile)
            ''    If mySaveFile.ShowDialog = DialogResult.OK Then
            ''        Dim fstr As New FileStream(mySaveFile.FileName, FileMode.Create, FileAccess.Write)
            ''        fstr.Write(expbuf, 0, bytesRead)
            ''        fstr.Close()
            ''    End If
            ''End If


            'StringBuilder sb = new StringBuilder();
            'Byte[] buf = new byte[8192];
            'Stream resStream = response.GetResponseStream();
            'string tmpString = null;
            'int count = 0;
            'do
            '{
            '     count = resStream.Read(buf, 0, buf.Length);
            '     if(count != 0)
            '     {
            '          tmpString = Encoding.ASCII.GetString(buf, 0, count);
            '          sb.Append(tmpString);
            '     }
            '}while (count > 0);


            ''Dim wr As HttpWebRequest = CType(WebRequestFactory.Create("http://maps.weather.com/web/radar/us_orl_ultraradar_large_usen.jpg"), HttpWebRequest)
            ''Dim ws As HttpWebResponse = CType(wr.GetResponse(), HttpWebResponse)
            ''Dim str As Stream = ws.GetResponseStream()
            ''Dim inBuf(100000) As Byte
            ''Dim bytesToRead As Integer = CInt(inBuf.Length)
            ''Dim bytesRead As Integer = 0
            ''While bytesToRead > 0
            ''    Dim n As Integer = str.Read(inBuf, bytesRead, bytesToRead)
            ''    If n = 0 Then Exit While
            ''    bytesRead += n
            ''    bytesToRead -= n
            ''End While
            ''Dim fstr As New FileStream("weather.jpg", FileMode.OpenOrCreate, FileAccess.Write)
            ''fstr.Write(inBuf, 0, bytesRead)
            ''str.Close()
            ''fstr.Close()

        Catch ex As Exception
            'Возможны ошибки скачивания из-за загруженности канала
            'Выждем секунду-две секунды и попробуем ещё раз
            myHttpWebResponse.Close()
            System.Threading.Thread.Sleep(1000 * CounterOfTriesDownloadingCookie)
            CounterOfTriesDownloadingCookie += 1
            If CounterOfTriesDownloadingCookie <= 3 Then GoTo NextTryDownloadingFile
        End Try
    End Sub

    ''' <summary>
    ''' Загрузка веб-страницы
    ''' </summary>
    ''' <param name="WebAddressSend"></param>
    ''' <param name="Referer"></param>
    ''' <param name="WebContentSend"></param>
    ''' <param name="Modifier">0 - обычная закачка веб-страниц с сайта, 1 - utorrent, 2-Transmission</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DownloadWebPageWithCookie(ByVal WebAddressSend As String, ByVal Referer As String, ByVal myEncoding As System.Text.Encoding, _
                                              Optional ByVal WebContentSend As String = "", Optional ByVal Modifier As Byte = 0) As String
        DownloadWebPageAnswer(0) = "Error" : DownloadWebPageAnswer(1) = ""
        ' Счетчик количества попыток выкачивания веб-страницы
        Dim CounterOfTriesDownloadingHTML As Int16 = 1
NextTryDownloadHTML:
        Try
RedownloadPage:
            'формируем запрос с кукисами
            myHttpWebRequest = HttpWebRequest.Create(WebAddressSend)

            If myHttpWebRequest.Headers Is Nothing = False Then myHttpWebRequest.Headers.Clear()
            If WebContentSend.Length > 0 Then
                myHttpWebRequest.Method = "POST"
            End If
            If Referer.Length > 0 Then myHttpWebRequest.Referer = Referer
            myHttpWebRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)"
            myHttpWebRequest.Accept = "text/html, application/xhtml+xml, */*"
            myHttpWebRequest.Headers.Add("Accept-Language", "ru-RU")

            Select Case Modifier
                Case 0
                    myHttpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate")
                    myHttpWebRequest.AutomaticDecompression = DecompressionMethods.GZip
                    myHttpWebRequest.KeepAlive = True
                    'If myHttpWebRequest.Method = "POST" Then myHttpWebRequest.Connection = "keep-alive"
                    myHttpWebRequest.ContentType = "application/x-www-form-urlencoded"
                    myHttpWebRequest.Headers.Add("Pragma", "no-cache")
                Case 1, 2
                    myHttpWebRequest.Headers.Add("Accept-Encoding", "deflate")
                    myHttpWebRequest.AutomaticDecompression = DecompressionMethods.Deflate
            End Select

            If Modifier = 0 And Not String.IsNullOrEmpty(SavI.Site_Cookie) Then
                myHttpWebRequest.Headers.Add(HttpRequestHeader.Cookie, SavI.Site_Cookie)
            End If
            If Modifier = 1 Or Modifier = 2 Then
                myHttpWebRequest.Headers.Add("Authorization", "Basic " & _
                                             Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(SavI.torrentClientUsername & ":" & SavI.torrentClientPassword)))
            End If
            If Modifier = 2 And TorClientSessionToken.Length > 0 Then myHttpWebRequest.Headers.Add("X-Transmission-Session-Id", TorClientSessionToken)
            'myHttpWebRequest.AlowAutoRedirect = False

            Select Case Modifier
                Case 0
                    System.Threading.Thread.Sleep(SavI.prog_PauseBeforeDownloadWebPageWithCookie * CounterOfTriesDownloadingHTML)
                    CounterOfTriesDownloadingHTML += 1
                Case 1, 2
                    System.Threading.Thread.Sleep(SavI.prog_PauseAfterSendCommandToTorrentClient * CounterOfTriesDownloadingHTML)
                    CounterOfTriesDownloadingHTML += 1
            End Select

            'If myHttpWebRequest.Method = "POST" And Modifier = 0 Then
            '    'myHttpWebRequest.ServicePoint.Expect100Continue = False
            '    'System.Net.ServicePointManager.Expect100Continue = False
            '    'myHttpWebRequest.Timeout = 20000
            '    myHttpWebRequest.KeepAlive = True
            '    'myHttpWebRequest.Connection = "keep-alive"
            'End If

            If WebContentSend.Length > 0 Then
                'передаем параметры
                Dim ByteArr As Byte() = Encoding.GetEncoding(1251).GetBytes(WebContentSend)
                myHttpWebRequest.ContentLength = ByteArr.Length()
                Dim rsw = myHttpWebRequest.GetRequestStream()
                rsw.Write(ByteArr, 0, ByteArr.Length)
                rsw.Close()
                'старый вариант, в одну строку: myHttpWebRequest.GetRequestStream().Write(ByteArr, 0, ByteArr.Length)
            End If

            'выполняем запрос
            myHttpWebResponse = myHttpWebRequest.GetResponse()
            'получаем результат
            Dim contentOfPage As String

            'If myHttpWebRequest.Method = "GET" Then
            contentOfPage = ""
            Dim myStreamReader As New System.IO.StreamReader(myHttpWebResponse.GetResponseStream, myEncoding)
            contentOfPage = myStreamReader.ReadToEnd()
            'End If


            '            StringBuilder sb = new StringBuilder();
            'Byte[] buf = new byte[8192];
            'Stream resStream = response.GetResponseStream();
            'string tmpString = null;
            'int count = 0;
            '            Do
            '{
            '     count = resStream.Read(buf, 0, buf.Length);
            '     if(count != 0)
            '     {
            '          tmpString = Encoding.ASCII.GetString(buf, 0, count);
            '          sb.Append(tmpString);
            '     }
            '}while (count > 0);



            'If myHttpWebRequest.Method = "POST" Then
            '    Dim receiveStream As Stream = myHttpWebResponse.GetResponseStream()
            '    Dim buffer(2 * 10 ^ 6) As Byte
            '    Dim n As Integer = 0
            '    Dim bytesRead As Integer = 0 'Суммарный объём всех чанков
            '    Do
            '        n = receiveStream.Read(buffer, bytesRead, 5 * 10 ^ 5)
            '        If n = 0 Then Exit Do
            '        bytesRead += n
            '    Loop
            '    receiveStream.Close()
            '    Dim FileContent(bytesRead - 1) As Byte
            '    Array.Copy(buffer, 0, FileContent, 0, bytesRead)
            '    contentOfPage = ""
            '    contentOfPage = System.Text.Encoding.GetEncoding(1251).GetString(FileContent)
            'End If

            If Not String.IsNullOrEmpty(myHttpWebResponse.Headers("Set-Cookie")) Then
                SavI.Site_Cookie = myHttpWebResponse.Headers("Set-Cookie")
            End If

            myHttpWebResponse.Close()
            'Теперь проверяем: если находим последовательность, то кукис недействителен, тогда получаем кукис и снова
            If contentOfPage.Contains("<a href=""profile.php?mode=register""><b>Регистрация</b></a>") Then
                SaveExtendedLog("Получаем кукис")
                StageOfWork = "Получаем кукис" : If ObrabotkaStartovala = True Then BWorker.ReportProgress(0)
                SavI.Site_Cookie = ReceiveCookie(SavI.Site_Username, SavI.Site_Password, RefreshCredentials)
                Call SaveSettingsToFile()
                GoTo RedownloadPage
            End If
            DownloadWebPageAnswer(0) = "0" : DownloadWebPageAnswer(1) = contentOfPage
            If contentOfPage.ToLower.Contains("форум временно отключен") Then
                DownloadWebPageAnswer(0) = "Error" : DownloadWebPageAnswer(1) = "Форум временно отключен"
                myException = New Exception("форум временно отключен")
                Throw myException
            End If
            Return contentOfPage
            'Catch ex As System.Net.WebException
            '    Dim wr As System.Net.HttpWebResponse = ex.Response
            '    If wr.StatusCode = HttpStatusCode.Conflict Then
            '        'получаем результат
            '        Dim myStreamReader As New System.IO.StreamReader(ex.Response.GetResponseStream, myEncoding)
            '        Dim contentOfPage As String = myStreamReader.ReadToEnd()
            '        ex.Response.Close()
            '        Return contentOfPage
            '    Else
            '        Throw ex
            '    End If
        Catch ex As Exception

            If ex.Message.Contains("форум временно отключен") Then
                myException = New Exception("форум временно отключен")
                BWorker.CancelAsync()
            End If

            If ex.Message.Contains("409") Then 'Transmission именно так, ошибкой, передаёт веб-страницу с токеном
                Dim exw As System.Net.WebException = ex
                Dim myStreamReader As New System.IO.StreamReader(exw.Response.GetResponseStream, myEncoding)
                Dim contentOfPage As String = myStreamReader.ReadToEnd()
                exw.Response.Close()
                DownloadWebPageAnswer(0) = "0" : DownloadWebPageAnswer(1) = contentOfPage
                Return contentOfPage
            End If

            If Modifier > 0 Then
                If CounterOfTriesDownloadingHTML > 3 Then 'Делаем две попытки достучаться до торрент-клиентов
                    DownloadWebPageAnswer(0) = "Error" : DownloadWebPageAnswer(1) = ex.Message
                    Return "Error: " & ex.Message
                Else
                    If ex.Message.Contains("400") Then 'Надо обновить токен
                        ExtendedLog &= "Token expired. Renew." : SaveExtendedLog()
                        TC.ReceiveTorClientSessionToken()
                        Return "RenewToken"
                    End If
                    GoTo NextTryDownloadHTML
                End If
            End If

            If CounterOfTriesDownloadingHTML > 15 Then
                DownloadWebPageAnswer(0) = "Error" : DownloadWebPageAnswer(1) = ex.Message
                Return "Error: " & ex.Message
            Else
                GoTo NextTryDownloadHTML
            End If
            'MsgBox("Ошибка: " & ex.ToString, vbOKOnly)
            'DownloadWebPageWithCookie = ""
        End Try
    End Function

    Private Sub ProcessListOfLinks()
        Dim NamesListOldLineAddr As String
        Dim NamesListOldLineFilename As String
        Dim PageContent As String = ""
        Dim WebNameOfTorrent As String = ""
        Dim SubForumNumber As Integer = -1
        Dim Seeds As Integer = -1
        Dim Leech As Integer = -1

        Dim SpisokForumovStart As Integer = -1
        Dim SpisokForumovEnd As Integer = -1
        Dim croppedPageContent As String = ""
        Dim f1 As Integer = -1, f2 As Integer = -1

        For ip As Integer = 0 To NamesListOld.Count - 1
            StageOfWork = "Обрабатываем торрент-файл № " & CStr(ip + 1) : If ObrabotkaStartovala = True Then BWorker.ReportProgress(0)
            SpisokForumovStart = -1
            SpisokForumovEnd = -1
            croppedPageContent = ""
            f1 = -1
            f2 = -1

            NamesListOldLineAddr = Mid(NamesListOld(ip), 1, NamesListOld(ip).IndexOf("|"))
            NamesListOldLineFilename = Mid(NamesListOld(ip), NamesListOld(ip).IndexOf("|") + 2)

            PageContent = DownloadWebPageWithCookie(NamesListOldLineAddr, "http://rutracker.org/forum/index.php", Encoding.GetEncoding(1251))
            'Если тема удалена, то уходим
            If PageContent.Contains(">Тема не найдена</div>") = True Then
                NamesListOldBadFiles.Add(NamesListOldLineAddr & " На сайте ""Тема не найдена"" (" & NamesListOldLineFilename & ")")
                GoTo NotProcessedFile
            End If
            'Проверяем наличие и адрес последовательности "Список форумов rutracker.org"
            SpisokForumovStart = PageContent.IndexOf("Список форумов rutracker.org")
            If SpisokForumovStart < 1 Then
                NamesListOldBadFiles.Add(NamesListOldLineAddr & "На сайте не найден текст ""Список форумов rutracker.org"" (" & NamesListOldLineFilename & ")")
                GoTo NotProcessedFile
            Else
                'Находим адрес последовательности '</td>', идущей после "Список форумов rutracker.org"
                SpisokForumovEnd = PageContent.IndexOf("</td>", SpisokForumovStart)
                croppedPageContent = Mid(PageContent, SpisokForumovStart, SpisokForumovEnd - SpisokForumovStart)

                'Теперь находим адрес последней последовательности ./viewforum.php?f=
                SubForumNumber = Val(Mid(croppedPageContent, croppedPageContent.LastIndexOf("./viewforum.php?f=") + 19, 7))

                'Находим кол-во сидов
                If PageContent.Contains("<span class=""seed"">") Then
                    f1 = PageContent.IndexOf("<span class=""seed"">")
                    f2 = PageContent.IndexOf("<b>", f1)
                    Seeds = Val(Mid(PageContent, f2 + 4, 7))
                Else
                    Seeds = 0
                End If

                'Находим кол-во личей
                If PageContent.Contains("<span class=""leech"">") Then
                    f1 = PageContent.IndexOf("<span class=""leech"">")
                    f2 = PageContent.IndexOf("<b>", f1)
                    Leech = Val(Mid(PageContent, f2 + 4, 7))
                Else
                    Leech = 0
                End If

            End If
            'теперь узнаём адрес начала тега <title>
            Dim fcTitleStart As Int32 = -1
            fcTitleStart = PageContent.IndexOf("<title>") + 1
            'Если не нашли, то вписываем об этом инфу
            If fcTitleStart < 1 Then
                NamesListOldBadFiles.Add(NamesListOldLineAddr & "На сайте не найдено начало заголовка раздачи (" & NamesListOldLineFilename & ")")
                GoTo NotProcessedFile
            End If
            'а теперь добавляем к нему 7, чтобы получить уже начало заголовка
            fcTitleStart += 7
            'теперь узнаём адрес начала двух двоеточий - т.е. окончание названия раздачи
            Dim fcTitleEnd As Int32 = -1
            fcTitleEnd = PageContent.IndexOf("::", fcTitleStart) + 1
            'Если не нашли конец, то вписываем об этом инфу
            If fcTitleEnd < 1 Then
                NamesListOldBadFiles.Add(NamesListOldLineAddr & "На сайте не найдено окончание заголовка раздачи (" & NamesListOldLineFilename & ")")
                GoTo NotProcessedFile
            End If
            'а теперь выдираем уже сам текст зоголовка
            If fcTitleStart > 1 And fcTitleEnd > 1 Then WebNameOfTorrent = Mid(PageContent, fcTitleStart, fcTitleEnd - fcTitleStart - 1)
            'Убираем теги
            WebNameOfTorrent = WebNameOfTorrent.Replace("<wbr>", "")
            WebNameOfTorrent = System.Web.HttpUtility.HtmlDecode(WebNameOfTorrent)
            NamesListOld(ip) = "[url=" & NamesListOldLineAddr & "]" & WebNameOfTorrent & "[/url]" & vbTab & CStr(SubForumNumber) & vbTab & CStr(Seeds) & vbTab & CStr(Leech)

NotProcessedFile:
        Next ip
    End Sub

    Private Sub CreateAndSendStatRep()
        SaveExtendedLog("Отсылаем статотчёты")
        Dim CountOfTorAlready As Decimal = 0 'Сколько торрентов УЖЕ добавлено в текущий отчёт
        Dim RepContent As String = "" 'Сюда собираем отчет
        'Dim AmountOfStatReports As Integer = Math.Ceiling(torrentsCollection.Count / SavI.StatRepNumOfTorInRep) 'Вычисляем количество отчётов
        Dim NumberOfReport As Integer = 0 'Номер текущего отчёта
        For i As Integer = 0 To torrentsCollection.Count - 1
            If torrentsCollection.Count = 0 Then Exit For
            If torrentsCollection.Item(i).Status >= 128 And torrentsCollection.Item(i).TorrentQueueOrder = -1 Then 'SavI.StatRepSendRepOnlyAboutStoredTorrents = True And
                If CountOfTorAlready = 0 Then
                    RepContent = ""
                    NumberOfReport += 1
                    StageOfWork = "Собираем и отправляем статистический отчет № " & NumberOfReport.ToString : If ObrabotkaStartovala = True Then BWorker.ReportProgress(0)
                    'StageOfWork = "Собираем и отправляем статистический отчет № " & NumberOfReport.ToString & " / " & AmountOfStatReports.ToString : BWorker.ReportProgress(0)
                End If
                If CountOfTorAlready >= 1 Then RepContent &= vbNewLine
                RepContent &= "id:" & torrentsCollection.Item(i).Web_AddressNumber.ToString & ";!;"
                RepContent &= "catid:" & torrentsCollection.Item(i).Web_SubforumNumber.ToString & ";!;"
                RepContent &= "title:" & System.Web.HttpUtility.HtmlDecode(torrentsCollection.Item(i).Web_NameFromWeb) & ";!;"
                RepContent &= "status:" & torrentsCollection.Item(i).Web_Status & ";!;"
                RepContent &= "seed:" & torrentsCollection.Item(i).Web_SeedsFromSite.ToString & ";!;"
                RepContent &= "leech:" & torrentsCollection.Item(i).Web_PeersFromSite.ToString & ";!;"
                RepContent &= "size:" & torrentsCollection.Item(i).Size.ToString & ";!;"
                RepContent &= "sizze:" & torrentsCollection.Item(i).Web_SizeKMGBytes & ";!;\n"
                CountOfTorAlready += 1
                If CountOfTorAlready = 100 Then
                    SendStatRepChapter(RepContent)
                    System.Threading.Thread.Sleep(1000) 'CInt(SavI.StatRepPauseAfterEverySendReport)
                    CountOfTorAlready = 0
                End If
            End If
            'А теперь проверим, дошли ли мы до конца коллекции
            If i = torrentsCollection.Count - 1 And CountOfTorAlready > 0 Then SendStatRepChapter(RepContent)
        Next i
    End Sub
    Private Function SizeInKMGBytes(ByVal sizeBytes As Double) As String
        If sizeBytes < 2 ^ 10 Then SizeInKMGBytes = sizeBytes.ToString & " B" : Return SizeInKMGBytes
        If sizeBytes < 2 ^ 20 Then SizeInKMGBytes = Math.Round((sizeBytes / 2 ^ 10), 2).ToString & " KB" : Return SizeInKMGBytes
        If sizeBytes < 2 ^ 30 Then SizeInKMGBytes = Math.Round((sizeBytes / 2 ^ 20), 2).ToString & " MB" : Return SizeInKMGBytes
        SizeInKMGBytes = Math.Round((sizeBytes / 2 ^ 30), 2).ToString & " GB" : Return SizeInKMGBytes
    End Function
    Private Sub SendStatRepChapter(ByVal sQueryString As String)
        sQueryString = System.Web.HttpUtility.UrlEncode(sQueryString, Encoding.GetEncoding(1251))
        sQueryString = "action=sendreport" & "&pass=" & SavI.StatRepWatchmenPass & "&send=" & sQueryString
        Dim CounterOfTriesDownloadingCookie As Int16 = 1
NextTryDownloadingCookie:
        Try
NewRequestToSite:
            'авторизация на сайте
            myHttpWebRequest = HttpWebRequest.Create("http://save.ubstat.ru/import.php")
            myHttpWebRequest.Method = "POST"
            myHttpWebRequest.Accept = "text/html, application/xhtml+xml, */*"
            myHttpWebRequest.Referer = "http://save.ubstat.ru/import.php" 'т.е. первый запрос
            myHttpWebRequest.Headers.Add("Accept-Language", "ru-RU")
            myHttpWebRequest.Headers.Add("Accept-Charset", "windows-1251, cp-1251")
            myHttpWebRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)"
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded"
            myHttpWebRequest.Headers.Add("Accept-Encoding", "deflate")
            myHttpWebRequest.KeepAlive = True 'Вот не уверен, что это правильная строка. Может и вообще не нужна, но кто тогда будет давать строчку Connection: Keep-Alive
            myHttpWebRequest.Headers.Add("Pragma", "no-cache")

            'ставим False, чтобы при получении кода 302 не делать автоматический редирект
            myHttpWebRequest.AllowAutoRedirect = False

            'передаем параметры
            Dim ByteArr As Byte() = Encoding.GetEncoding(1251).GetBytes(sQueryString)
            myHttpWebRequest.ContentLength = ByteArr.Length()
            myHttpWebRequest.GetRequestStream().Write(ByteArr, 0, ByteArr.Length)

            'выполняем запрос
            myHttpWebResponse = myHttpWebRequest.GetResponse()

            Dim receiveStream As Stream = myHttpWebResponse.GetResponseStream()
            Dim encode As Encoding = System.Text.Encoding.GetEncoding("windows-1251") 'Вместо "windows-1251" в примере было "utf-8"
            Dim readStream As New StreamReader(receiveStream, encode)
            Dim textOfStream As String = readStream.ReadToEnd
            readStream.Close()
            myHttpWebResponse.Close()
        Catch ex As Exception
            'Возможны ошибки скачивания из-за загруженности канала. Выждем секунду-две секунды и попробуем ещё раз
            System.Threading.Thread.Sleep(1000 * CounterOfTriesDownloadingCookie)
            CounterOfTriesDownloadingCookie += 1
            If CounterOfTriesDownloadingCookie <= 3 Then GoTo NextTryDownloadingCookie
        End Try
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = WindowsApplication1.My.Resources.Keepers
        Me.Text = "Torrents-list organizer " & WindowsApplication1.My.Application.Info.Version.ToString
#If CONFIG <> "Release" Then
        Me.Text &= "      DEBUG!!!!!!!!!!!!!!!!!!!!!!!!!!!"
        Me.BackColor = Color.YellowGreen
#End If
#If CONFIG = "Release" Then
        dgv1.Columns.Item(8).Visible = False
#End If

        TSSLabelTimer.Text = ""
        TimerSec.AutoReset = True
        TimerSec.Interval = 1000
        TimerShowStageOfWork.Interval = 500
        Call TimerStartOFFToolStripMenuItem_Click(sender, e)
        ПоказатьОтчётыToolStripMenuItem.Enabled = False
        'Добавляем в список битмапы согласно с Enum Bitmaps
        Bitmaps.Add(WindowsApplication1.My.Resources.white_4pix)
        Bitmaps.Add(WindowsApplication1.My.Resources.Save_blue_16pix)
        Bitmaps.Add(WindowsApplication1.My.Resources.Save_blue_16pix_grayscale)
        Bitmaps.Add(WindowsApplication1.My.Resources.BitTorrentLogo_16pix)
        Bitmaps.Add(WindowsApplication1.My.Resources.BitTorrentLogo_16pix_grayscale)
        If File.Exists(IO.Path.Combine(My.Application.Info.DirectoryPath, "checkSeeding.TT")) = False Then
            ПроверитьПользователяНаСидированиеToolStripMenuItem.Visible = False
        End If
    End Sub
    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized And SavI.Interface_MinimizeToTray = True Then
            Me.WindowState = FormWindowState.Minimized
            Me.Visible = False
            NotifyIcon1.Visible = True
        End If
    End Sub
    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        SavI.prog_WindowDesktopLocation = Me.DesktopLocation
        SavI.prog_WindowSize = Me.Size
        'При выборе меню "Выход"
        If IsExit = True Then SaveSettingsToFile() : Application.Exit() : Exit Sub

        'Проверяем настройку "Закрывать в лоток"
        If IsExit = False And SavI.Interface_CloseToTray = True Then
            e.Cancel = True
            Me.WindowState = FormWindowState.Minimized
            Me.Visible = False
            NotifyIcon1.Visible = True
            Exit Sub
        Else
            If SavI.Interface_RequestOnExit = False Then SaveSettingsToFile() : Application.Exit() : Exit Sub
            If MessageBox.Show(Me, "Вы действительно хотите закрыть программу?", "Запрос", vbOKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                IsExit = True
                SaveSettingsToFile()
                Application.Exit()
            Else
                e.Cancel = True
                Exit Sub
            End If
        End If
        'Если же настрока "Сворачивать в лоток" выключена, то
        ''If MessageBox.Show(Me, "Вы действительно хотите закрыть программу?", "Запрос", vbOKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
        ''    Application.Exit()
        ''    Exit Sub
        ''Else
        ''    e.Cancel = True
        ''End If

    End Sub
    Private Sub ВыходToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ВыходToolStripMenuItem.Click
        If SavI.Interface_RequestOnExit = False Then IsExit = True : Application.Exit()
        If MessageBox.Show(Me, "Вы действительно хотите закрыть программу?", "Запрос", vbOKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
            IsExit = True
            Application.Exit()
        End If
    End Sub
    Private Sub NotifyIcon1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False
    End Sub

    Private Sub NotifyIcon1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDown
        'Пока этот код не нужен, но потом может понадобится
        ''If Button.MouseButtons = MouseButtons.Left Then
        ''    Me.Show()
        ''    Me.WindowState = FormWindowState.Normal
        ''    NotifyIcon1.Visible = False
        ''End If
    End Sub

    Private Sub NotifyIcon1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseMove
        If TimerIsStarted = True Then
            NotifyIcon1.Text = "До запуска обработки " & TSSLabelTimer.Text
        Else
            NotifyIcon1.Text = "Таймер выключен"
        End If
    End Sub

    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
#If CONFIG = "Debug" Then
        PathToWebpagesPath = "\..\..\"
#End If
#If CONFIG = "Debug-ReceiveAllInfoFromFiles" Then
        PathToWebpagesPath = "\..\..\..\"
#End If
        If File.Exists(IO.Path.Combine(My.Application.Info.DirectoryPath, "settings.wlo")) Then
            Try
                ' Получите файловый поток, выполняющий чтение из файла.
                Dim fs As New FileStream(IO.Path.Combine(My.Application.Info.DirectoryPath, "settings.wlo"), FileMode.Open)
                ' Получите экземпляр модуля форматирования.
                Dim sf As New BinaryFormatter
                ' Выполните десериализацию из файла, создав экземпляр SerializableClass.
                ' Десериализованный объект необходимо привести к подходящему типу.
                SavI = CType(sf.Deserialize(fs), Class_SavedInfo)
                SubForumsList = CType(sf.Deserialize(fs), Class_SubforumsList)
                SubForumsListColl = CType(sf.Deserialize(fs), Class_SubforumsListColl)
                ListOfInfoFromTorrentFiles = CType(sf.Deserialize(fs), Class_ListOfInfoFromTorrentFiles)
                ' Закройте файл и освободите ресурсы.
                fs.Close()
            Catch
                MsgBox("Ошибка загрузки части сохранённых данных." & vbNewLine & "Просьба проверить настройки.", vbOKOnly, "Сообщение")
            End Try

            'Задаем значения по умолчанию, если таковых нет в файле с сохранениями
            If SavI.div_tracker = Nothing Then SavI.div_tracker = ""
            If SavI.prog_DiscountGenreInSort = Nothing Then SavI.prog_DiscountGenreInSort = False
            If SavI.prog_TimerStart = Nothing Then SavI.prog_TimerStart = 3600
            If SavI.LimitSpeedUploadIs = Nothing Then SavI.LimitSpeedUploadIs = False
            If SavI.LimitSpeedUploadValue = Nothing Then SavI.LimitSpeedUploadValue = 200
            If SavI.LimitSpeedDownloadIs = Nothing Then SavI.LimitSpeedDownloadIs = False
            If SavI.LimitSpeedDownloadValue = Nothing Then SavI.LimitSpeedDownloadValue = 200
            If SavI.prog_PauseBeforeDownloadWebPageWithCookie = Nothing Then SavI.prog_PauseBeforeDownloadWebPageWithCookie = 200
            If SavI.prog_PauseAfterSendCommandToTorrentClient = Nothing Then SavI.prog_PauseAfterSendCommandToTorrentClient = 250

            If SavI.Proxy = Nothing Then SavI.Proxy = 0
            If SavI.ProxyIPAddress = Nothing Then SavI.ProxyIPAddress = ""
            If SavI.ProxyPort = Nothing Then SavI.ProxyPort = 0
            If SavI.ProxyAuthorization = Nothing Then SavI.ProxyAuthorization = 0
            If SavI.ProxyAuthorizationName = Nothing Then SavI.ProxyAuthorizationName = ""
            If SavI.ProxyAuthorizationPassword = Nothing Then SavI.ProxyAuthorizationPassword = ""
            If SavI.ProxyAuthorizationDomain = Nothing Then SavI.ProxyAuthorizationDomain = ""

            If SavI.Site_Cookie = Nothing Then SavI.Site_Cookie = ""
            If SavI.Site_CookieAnotherUser Is Nothing Then SavI.Site_CookieAnotherUser = ""
            If SavI.Site_Password = Nothing Then SavI.Site_Password = ""
            If SavI.Site_Username = Nothing Then SavI.Site_Username = ""

            If SavI.torrentClientAnswerFile = Nothing Then SavI.torrentClientAnswerFile = ""
            If SavI.torrentClientIncomingPort = Nothing Then SavI.torrentClientIncomingPort = 0
            If SavI.torrentClientIPAddress = Nothing Then SavI.torrentClientIPAddress = ""
            If SavI.torrentClientPassword = Nothing Then SavI.torrentClientPassword = ""
            If SavI.torrentClientUsername = Nothing Then SavI.torrentClientUsername = ""
            If SavI.torrentClientWhere = Nothing Then SavI.torrentClientWhere = 0
            If SavI.torrentClientName = Nothing Then SavI.torrentClientName = 1

            If SavI.torrentTorrentsPath = Nothing Then SavI.torrentTorrentsPath = ""
            If SavI.prog_SaveTorrFilesToPath = Nothing Then SavI.prog_SaveTorrFilesToPath = ""
            If SavI.prog_SaveTorrFiles_DownloadByAnotherUser_Username = Nothing Then SavI.prog_SaveTorrFiles_DownloadByAnotherUser_Username = ""
            If SavI.prog_SaveTorrFiles_DownloadByAnotherUser_Password = Nothing Then SavI.prog_SaveTorrFiles_DownloadByAnotherUser_Password = ""

            If SavI.StatRepWatchmenPass Is Nothing Then SavI.StatRepWatchmenPass = "guest"
            If SavI.prog_Report_NameLinkClick = Nothing Then SavI.prog_Report_NameLinkClick = 0
            If SavI.prog_Report_NameLinkClick_AltBrowserAddress = Nothing Then SavI.prog_Report_NameLinkClick_AltBrowserAddress = ""
            If SavI.prog_ReportSeeding_ShowOnlySeedsNotMoreThanValue = Nothing Then SavI.prog_ReportSeeding_ShowOnlySeedsNotMoreThanValue = 10

            If ListOfInfoFromTorrentFiles Is Nothing Then ListOfInfoFromTorrentFiles.Clear()
            If ListOfInfoFromTorrentFiles.TorrFilesErrors = Nothing Then ListOfInfoFromTorrentFiles.TorrFilesErrors = ""

            GUI("RefreshTorrFilesErrors")
            If SavI.prog_WindowDesktopLocation <> Nothing Then Me.DesktopLocation = SavI.prog_WindowDesktopLocation
            If SavI.prog_WindowSize <> Nothing Then Me.Size = SavI.prog_WindowSize
            If SavI.WebFindDateTorRegForNotMoreSeeds = Nothing Then SavI.WebFindDateTorRegForNotMoreSeeds = 3

            If SavI.prog_ReportTemplate Is Nothing Then SavI.prog_ReportTemplate = ""

            If SavI.Report Is Nothing Then SavI.Report = New Class_SavedInfoReport

            TSSLabel1.Text = ""
            ProxyBuilder()
            If SubForumsList.Count > 0 Then
                'ReDim Reports(SubForumsList.Count - 1)
                Reports.Clear()
                For i = 0 To SubForumsList.Count - 1
                    Reports.Add(New Class_Report)
                Next
            End If
            Timer.Interval = SavI.prog_TimerStart * 1000
            'Находим, есть ли хоть один подраздел с установленным флагом "Обрабатывать подраздел"
            TimerToolStripDropDownButton1.Enabled = False
            For Each ssf As Class_Subforum In SubForumsList
                If ssf.IsProcessSubforum = True Then TimerToolStripDropDownButton1.Enabled = True : Exit For
            Next
            If SavI.prog_ReportTemplate.Length > 0 Then ReportTemplateParse()
        Else
            'Задаем значения по умолчанию
            SavI.div_tracker = ""
            SavI.prog_DiscountGenreInSort = False
            SavI.prog_TimerStart = 3600
            SavI.prog_ReportTemplate = ""
            SavI.LimitSpeedUploadIs = False
            SavI.LimitSpeedUploadValue = 200
            SavI.LimitSpeedDownloadIs = False
            SavI.LimitSpeedDownloadValue = 200
            SavI.prog_PauseBeforeDownloadWebPageWithCookie = 200
            SavI.prog_PauseAfterSendCommandToTorrentClient = 250

            SavI.Proxy = 0
            SavI.ProxyIPAddress = ""
            SavI.ProxyPort = 0
            SavI.ProxyAuthorization = 0
            SavI.ProxyAuthorizationName = ""
            SavI.ProxyAuthorizationPassword = ""
            SavI.ProxyAuthorizationDomain = ""

            SavI.Site_Cookie = ""
            SavI.Site_CookieAnotherUser = ""
            SavI.Site_Password = ""
            SavI.Site_Username = ""

            SavI.torrentClientAnswerFile = ""
            SavI.torrentClientIncomingPort = 0
            SavI.torrentClientIPAddress = ""
            SavI.torrentClientPassword = ""
            SavI.torrentClientUsername = ""
            SavI.torrentClientWhere = 0
            SavI.torrentClientName = 1

            SavI.torrentTorrentsPath = ""
            SavI.prog_SaveTorrFilesToPath = ""
            SavI.prog_SaveTorrFiles_DownloadByAnotherUser_Username = ""
            SavI.prog_SaveTorrFiles_DownloadByAnotherUser_Password = ""
            SavI.prog_Report_NameLinkClick = 0
            SavI.prog_Report_NameLinkClick_AltBrowserAddress = ""
            SavI.prog_ReportSeeding_ShowOnlySeedsNotMoreThanValue = 10

            SavI.StatRepWatchmenPass = "guest"
            SavI.StatRepIsSendStatRep = True
            SavI.WebFindDateTorRegForNotMoreSeeds = 3

            SavI.Report = New Class_SavedInfoReport

            ListOfInfoFromTorrentFiles.Clear()

            TSSLabel1.Text = "Файл с настройками не обнаружен."
            MsgBox("Файл с настройками не обнаружен." & vbNewLine & _
                   "После щелчка по кнопке ОК откроется окно настроек программы," & vbNewLine & _
                   "в котором необходимо настроить параметры доступа", vbOKOnly, "Ошибка")
            frmSettings.ShowDialog(Me)
        End If
    End Sub
    Public Sub SaveSettingsToFile()
        Try
            'Список мест, откуда вызывается эта процедура:
            ' - после обновления кукиса;
            ' - после обновления списка подразделов
            ' - cmd_OK в этой этой форме
            'ReceiveInfoFromTorrentFiles - получили инфу из торрент-файлов
            Dim fStreamSave As New FileStream(IO.Path.Combine(My.Application.Info.DirectoryPath, "settings.wlo"), FileMode.OpenOrCreate)
            ' Получите экземпляр модуля форматирования Binary.
            Dim BinFormter As New BinaryFormatter
            ' Сериализация экземпляра.
            BinFormter.Serialize(fStreamSave, SavI)
            BinFormter.Serialize(fStreamSave, SubForumsList)
            BinFormter.Serialize(fStreamSave, SubForumsListColl)
            BinFormter.Serialize(fStreamSave, ListOfInfoFromTorrentFiles)
            ' Закройте файл и освободите ресурсы.
            fStreamSave.Close()
        Catch

        End Try
    End Sub
    ''' <summary>
    ''' ВНИМАНИЕ! Эту процедуру не вызывать по таймеру!
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ОбработатьПодразделToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ОбработатьПодразделToolStripMenuItem.Click
        whatTOstartInBWorker = 1
        ObrabotkaStartovalaByTimer = False
        Call Start()
    End Sub

    Private Sub ОПрограммеToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ОПрограммеToolStripMenuItem.Click
        AboutBox1.ShowDialog()
        'MsgBox("Потом что-либо накатаю сюда", vbOKOnly, "О программе")
    End Sub

    Private Sub ОбработатьВсеТоррентфайлыПодрядToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ОбработатьВсеТоррентфайлыПодрядToolStripMenuItem.Click
        whatTOstartInBWorker = 0
        Call Start()
    End Sub
    Friend Sub SaveExtendedLog(Optional ByVal StageText As String = "")
        'If ObrabotkaStartovala = True Then
        If StageText.Length > 0 Then
            ExtendedLog &= "============================================" & vbNewLine & _
                           NowDayTimeFull() & " " & StageText & vbNewLine &
                           "============================================" & vbNewLine
        End If

        Try
            If SavI.ExtLogEnabled = True Then My.Computer.FileSystem.WriteAllText(IO.Path.Combine(My.Application.Info.DirectoryPath, NameOfFile), ExtendedLog, False)
        Catch

        End Try
        'End If
    End Sub
    ''' <summary>
    ''' Настраиваем прокси-серверы согласно настройкам
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ProxyBuilder()
        'В этом лямбда-выражении задаём настройки аутентификации
        Dim selAuth = Sub(xx As Byte)
                          Select Case xx
                              Case 0
                                  ProxyWeb.UseDefaultCredentials = False
                                  ProxyWeb.Credentials = Nothing
                              Case 1
                                  'только если UseDefaultCredentials = False, можно изменять значение Credentials, и ...
                                  ProxyWeb.UseDefaultCredentials = False
                                  '...только если Credentials = Nothing, можно задать UseDefaultCredentials = True, ...
                                  ProxyWeb.Credentials = Nothing
                                  '...иначе - ошибка
                                  ProxyWeb.UseDefaultCredentials = True
                              Case 2
                                  ProxyWeb.UseDefaultCredentials = False
                                  If SavI.ProxyAuthorizationDomain.Length > 0 Then
                                      ProxyWeb.Credentials = _
                                          New NetworkCredential(SavI.ProxyAuthorizationName, SavI.ProxyAuthorizationPassword, SavI.ProxyAuthorizationDomain)
                                  Else
                                      ProxyWeb.Credentials = _
                                          New NetworkCredential(SavI.ProxyAuthorizationName, SavI.ProxyAuthorizationPassword)
                                  End If
                          End Select
                      End Sub

        Select Case SavI.Proxy
            Case 0
                ProxyWeb.Address = Nothing
            Case 1
                'ProxyWeb = WebRequest.GetSystemWebProxy
                'todo проверить работоспособность с проксей с авторизацией, при IP-адресах, выданных DHCP
                ProxyWeb = WebProxy.GetDefaultProxy
                selAuth(SavI.ProxyAuthorization)
            Case 2
                ProxyWeb = New WebProxy(SavI.ProxyIPAddress, SavI.ProxyPort)
                selAuth(SavI.ProxyAuthorization)
        End Select
    End Sub

    Private Sub cbSelectSubforum_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelectSubforum.SelectedIndexChanged
        If Reports.Item(cbSelectSubforum.SelectedIndex) Is Nothing = False Then
            txtReportInForum.Text = Reports.Item(cbSelectSubforum.SelectedIndex).InForumSeeding.ToString
            txtReport.Text = Reports.Item(cbSelectSubforum.SelectedIndex).ToDnldText.ToString
            txtSubforumFullPath.Text = SubForumsList.Item(cbSelectSubforum.SelectedIndex).SubForumFullPath
            ReportTableSendToDGV(cbSelectSubforum.SelectedIndex)
            ''dgv1.DataSource = ReportsOfProcessedSubforums(cbSelectSubforum.SelectedIndex)
            'dgv1.Rows.Clear()
            'For i As Integer = 0 To ReportsDGV(cbSelectSubforum.SelectedIndex).Rows.Count - 1
            '    dgv1.Rows.Add(ReportsDGV(cbSelectSubforum.SelectedIndex).Rows(i).Clone)
            'Next
        End If
    End Sub
    Private Sub ReportTableSendToDGV(ByVal ind As Integer)
        If Reports.Item(ind).ToDnldTable.Count = 0 Then Exit Sub
        Dim i As Integer, j As Integer
        dgv1.Rows.Clear()
        For i = 0 To Reports.Item(ind).ToDnldTable.Count - 1 ' i - line index
            'With Reports.Item(ind).ToDnldTable
            Dim row As New DataGridViewRow 'Собираем строку таблицы
            For j = 0 To Reports.Item(ind).ToDnldTable.Item(i).Count - 1 ' j - cell index
                Select Case Reports.Item(ind).ToDnldTable.Item(i).Item(j).CellType
                    Case "text"
                        Dim cel As New DataGridViewTextBoxCell
                        cel.Value = Reports.Item(ind).ToDnldTable.Item(i).Item(j).Value
                        Dim style As New DataGridViewCellStyle
                        If Reports.Item(ind).ToDnldTable.Item(i).Item(j).Font Is Nothing = False Then style.Font = Reports.Item(ind).ToDnldTable.Item(i).Item(j).Font
                        If Reports.Item(ind).ToDnldTable.Item(i).Item(j).ForeColor <> Color.Empty Then style.ForeColor = Reports.Item(ind).ToDnldTable.Item(i).Item(j).ForeColor
                        If Reports.Item(ind).ToDnldTable.Item(i).Item(j).BackColor <> Color.Empty Then
                            style.BackColor = Reports.Item(ind).ToDnldTable.Item(i).Item(j).BackColor
                        End If

                        cel.Style = style
                        cel.ToolTipText = Reports.Item(ind).ToDnldTable.Item(i).Item(j).ToolTipText
                        row.Cells.Add(cel)
                    Case "link"
                        Dim cel As New DataGridViewLinkCell With {.Value = Reports.Item(ind).ToDnldTable.Item(i).Item(j).Value,
                                                                  .Tag = Reports.Item(ind).ToDnldTable.Item(i).Item(j).Link}
                        If Reports.Item(ind).ToDnldTable.Item(i).Item(j).Font Is Nothing = False Then
                            Dim style As New DataGridViewCellStyle With {.Font = Reports.Item(ind).ToDnldTable.Item(i).Item(j).Font}
                            cel.Style = style
                        End If
                        row.Cells.Add(cel)
                    Case "bitmap"
                        Dim cel As New DataGridViewImageCell With {.Value = Bitmaps.Item(Reports.Item(ind).ToDnldTable.Item(i).Item(j).bitmapNum),
                                                                   .Tag = Reports.Item(ind).ToDnldTable.Item(i).Item(j).Link}
                        'Dim cel As New DataGridViewTextBoxCell With {.Tag = ReportTable(ind).Item(i).Item(j).Link}
                        row.Cells.Add(cel)
                End Select
            Next
            dgv1.Rows.Add(row)
            'End With
        Next
    End Sub
    Friend Sub TimerStartONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerStartONToolStripMenuItem.Click
        Timer.Enabled = True
        TimerIsStarted = True
        TimerIsStartedIn = Now.Ticks
        TimerToolStripDropDownButton1.Image = WindowsApplication1.My.Resources.start
        TimerToolStripDropDownButton1.ToolTipText = "Таймер включен."
        TimerSec.Enabled = True
    End Sub

    Friend Sub TimerStartOFFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerStartOFFToolStripMenuItem.Click
        Timer.Enabled = False
        TimerToolStripDropDownButton1.Image = WindowsApplication1.My.Resources.stoppic
        TimerToolStripDropDownButton1.ToolTipText = "Таймер выключен."
        TimerSec.Enabled = False
        TimerIsStarted = False
        TSSLabelTimer.Text = "Таймер выключен"
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        TimerSec.Enabled = False
        ObrabotkaStartovalaByTimer = True
        whatTOstartInBWorker = 1
        Call Start()
        'ОбработатьПодразделToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub TimerSec_Tick() Handles TimerSec.Elapsed
        elapsedtime = (CLng(Timer.Interval) * 10000 - (Now.Ticks - TimerIsStartedIn)) / (10 ^ 7)
        elapsedtimeH = elapsedtime \ 3600
        elapsedtimeM = (elapsedtime - 3600 * elapsedtimeH) \ 60
        elapsedtimeS = elapsedtime - 3600 * elapsedtimeH - 60 * elapsedtimeM
        TSSLabelTimer.Text = elapsedtimeH.ToString & ":" & elapsedtimeM.ToString & ":" & elapsedtimeS.ToString
    End Sub

    Private Sub TimerShowStageOfWork_Tick() Handles TimerShowStageOfWork.Elapsed
        TSSLabel1.Text = ForumParser.StageOfWork
    End Sub

    Public Function TorClntIPandPort() As String
        'Собираем Web-адрес подключения к торрент-клиенту
        If SavI.torrentClientWhere = 0 Then
            TorClntIPandPort = "http://127.0.0.1:" & SavI.torrentClientIncomingPort
        ElseIf SavI.torrentClientWhere = 1 Then
            TorClntIPandPort = "http://" & SavI.torrentClientIPAddress & ":" & SavI.torrentClientIncomingPort
        Else
            TorClntIPandPort = ""
        End If
    End Function

    Public Function NowDayTimeFull() As String
        NowDayTimeFull = ""
        Dim AddNull = Sub(ss As Integer)
                          If ss < 10 Then
                              NowDayTimeFull &= "0"
                          End If
                          NowDayTimeFull &= ss.ToString
                      End Sub
        NowDayTimeFull = Now.Year.ToString & "-"
        AddNull(Now.Month)
        NowDayTimeFull &= "-"
        AddNull(Now.Day)
        NowDayTimeFull &= "_"
        AddNull(Now.Hour)
        NowDayTimeFull &= "-"
        AddNull(Now.Minute)
        NowDayTimeFull &= "-"
        AddNull(Now.Second)
    End Function

    Private Sub ОтдельнаяОбработкаМетокРаздачВТоррентклиентуToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ОтдельнаяОбработкаМетокРаздачВТоррентклиентуToolStripMenuItem.Click
        frmSaveRestoreTorrentsLabels.ShowDialog(Me)
    End Sub

    Private Sub ПолучитьДанныеИзТоррентфайловToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПолучитьДанныеИзТоррентфайловToolStripMenuItem.Click
        ExtendedLog = "Получаем данные из торрент-файлов" & vbNewLine
        NameOfFile = NowDayTimeFull() & "_ПолучитьДанныеИзТоррентфайлов" & ".log"
        SaveExtendedLog("Получаем данные из торрент-файлов")

        'Проверяем наличие папки с торрент-файлами
        If My.Computer.FileSystem.DirectoryExists(SavI.torrentTorrentsPath) = False Then
            MsgBox("Папки с торрент-файлами не существует", vbOKOnly, "Ошибка")
            Exit Sub
        End If
        TSSLabel1.Text = "Составляем список торрент-файлов"
        torrList = My.Computer.FileSystem.GetFiles(SavI.torrentTorrentsPath, FileIO.SearchOption.SearchAllSubDirectories, "*.torrent")
        ExtendedLog &= "Количество найденных файлов в папке и вложенных папках: " & torrList.Count & vbNewLine : SaveExtendedLog()
        If torrList.Count < 1 Then
            MessageBox.Show("torrent-файлов не обнаружено. Проверьте папку.")
            Exit Sub
        End If

        GUI("block")

        TSSLabel1.Text = "Список торрент-файлов составлен успешно. Запуск получения информации из них."
        whatTOstartInBWorker = 10

        BWorker.RunWorkerAsync()
    End Sub

    Private Sub dgv1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellContentClick
        Dim FileContent() As Byte = {}
        Dim FileName As String = ""
        Dim DlgResult As DialogResult
        If e.RowIndex < 0 Then Exit Sub
        Select Case e.ColumnIndex
            Case 2
                If dgv1.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag Is Nothing = False Then
                    If dgv1.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag.ToString.Length > 10 Then
                        Select Case SavI.prog_Report_NameLinkClick
                            Case 0
                                System.Diagnostics.Process.Start(dgv1.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag.ToString)
                            Case 1
                                If My.Computer.FileSystem.FileExists(SavI.prog_Report_NameLinkClick_AltBrowserAddress) = False Then
                                    MessageBox.Show(Me, "Во вкладке ""Отчеты"" неправильно указан браузер для открытия ссылок из отчёта." & Environment.NewLine & _
                                                     "Пожалуйста, укажите правильный браузер или выберите опцию ""в браузере по умолчанию""", "Предупреждение", vbOKOnly, MessageBoxIcon.Stop)
                                    Exit Sub
                                End If
                                System.Diagnostics.Process.Start("""" & SavI.prog_Report_NameLinkClick_AltBrowserAddress & """", _
                                                                 dgv1.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag.ToString)
                        End Select
                    End If
                End If
            Case 7
                Select Case SavI.prog_SavingTorrFiles
                    Case 0, 1
                        'Проверяем наличие папки, в которую сохраняются скачиваемые торрент-файлы
                        If My.Computer.FileSystem.DirectoryExists(SavI.torrentTorrentsPath) = False Then
                            MsgBox("Папки, в которую должны сохраняться торрент-файлы, не существует", vbOKOnly, "Ошибка")
                            Exit Sub
                        End If
                        If dgv1.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag IsNot Nothing Then
                            If dgv1.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag.ToString.Length > 10 Then
                                ReceiveFile(dgv1.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag.ToString, "http://rutracker.org/forum/tracker.php", FileName, FileContent)
                                If FileName = "DailyLimitExceeded" Then
                                    MessageBox.Show(Me, "Вы уже исчерпали суточный лимит скачиваний торрент-файлов." & Environment.NewLine & _
                                           "Для продолжения скачивания торент-файлов введите другие" & Environment.NewLine & _
                                           "регистрационные данные в настройках сохранения торрент-файлов.", "Сообщение", vbOKOnly, MessageBoxIcon.Information)
                                    Exit Sub
                                End If
                                If SavI.prog_SaveTorrFiles_DownloadByAnotherUser = True Then
                                    FileName = Mid(FileName, 1, FileName.IndexOf(".torrent")) & "_" & SavI.prog_SaveTorrFiles_DownloadByAnotherUser_Username & ".torrent"
                                End If
                                Try
                                    'Сохраняем файл
                                    If SavI.prog_SavingTorrFiles = 0 Then
NewTrySaveFile:
                                        Call frmSettings.SelSaveFile("Сохранить торрент-файл как", "Торрент-файл|*.torrent", FileName, "torrent")
                                        If mySaveFile.ShowDialog = DialogResult.OK Then
                                            If My.Computer.FileSystem.FileExists(mySaveFile.FileName) Then
                                                DlgResult = MessageBox.Show(mySaveFile.FileName & " уже существует." & Environment.NewLine & "Заменить?", _
                                                                            "Сохранить как", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, _
                                                                            MessageBoxDefaultButton.Button2)
                                                If DlgResult = Windows.Forms.DialogResult.OK Then
                                                    Dim fstr As New FileStream(mySaveFile.FileName, FileMode.Create, FileAccess.Write)
                                                    fstr.Write(FileContent, 0, FileContent.Length)
                                                    fstr.Close()
                                                Else
                                                    GoTo NewTrySaveFile
                                                End If
                                            Else
                                                Dim fstr As New FileStream(mySaveFile.FileName, FileMode.Create, FileAccess.Write)
                                                fstr.Write(FileContent, 0, FileContent.Length)
                                                fstr.Close()
                                            End If
                                        End If
                                    ElseIf SavI.prog_SavingTorrFiles = 1 Then
                                        Dim fstr As New FileStream(IO.Path.Combine(SavI.prog_SaveTorrFilesToPath, FileName), FileMode.Create, FileAccess.Write)
                                        fstr.Write(FileContent, 0, FileContent.Length)
                                        fstr.Close()
                                    End If
                                Catch ex As Exception

                                End Try
                            End If
                        End If
                    Case 2
                        If dgv1.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag IsNot Nothing Then
                            If dgv1.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag.ToString.Length > 10 Then
                                Try
                                    My.Computer.FileSystem.WriteAllText(IO.Path.Combine(My.Application.Info.DirectoryPath, "links.txt"), _
                                                                        dgv1.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag.ToString & Environment.NewLine, True)
                                Catch ex As Exception
                                    MsgBox("Ошибка записи ссылки в файл links.txt.", vbOKOnly, "Ошибка")
                                End Try

                            End If
                        End If
                End Select

            Case 8


        End Select

    End Sub

    Private Sub ПоказатьОтчётыToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПоказатьОтчётыToolStripMenuItem.Click
        ExtendedLog = "Показываем отчёты" & vbNewLine
        NameOfFile = NowDayTimeFull() & "_показываем отчёты" & ".log"
        SaveExtendedLog("Показываем отчёты")

        GUI("block")
        whatTOstartInBWorker = 2
        BWorker.RunWorkerAsync()
    End Sub

    Private Sub ПроверитьПользователяНаСидированиеToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПроверитьПользователяНаСидированиеToolStripMenuItem.Click
        Do
            CheckUserToSeeding_Username = InputBox("Введите имя пользователя, которого проверяем на сидирование." & Environment.NewLine & _
                                                   "Длина имени - не менее 2 символов." & Environment.NewLine & _
                                                   "Если хотите отменить проверку - щелкните Отмена." & Environment.NewLine & _
                                                   "Осторожно, вводите точно, проверяйте на наличие случайных пробелов." & Environment.NewLine & _
                                                   "Также вместо имени можно вводить ID пользователя - это число " & Environment.NewLine & _
                                                   "в конце веб-адреса профиля пользователя." & Environment.NewLine & _
                                                   " ", "Ввод данных")
            If CheckUserToSeeding_Username.Length = 0 Then Exit Sub
        Loop While CheckUserToSeeding_Username.Length < 2
        whatTOstartInBWorker = 3

        'Задаём переменные
        ObrabotkaStartovala = True
        ExtendedLog = ""
        NameOfFile = NowDayTimeFull() & ".log"
        SaveExtendedLog()

        If SubForumsList.Count < 1 And whatTOstartInBWorker > 0 Then
            MsgBox("Список обрабатываемых форумов пуст. Добавьте хотя бы один подфорум для обработки", vbOKOnly, "Ошибка")
            Exit Sub
        Else
            Dim SelectedSubforumsCount As Integer = 0
            For Each subf As Class_Subforum In SubForumsList
                If subf.IsProcessSubforum = True Then SelectedSubforumsCount += 1
            Next
            If SelectedSubforumsCount = 0 Then
                MsgBox("У всех подразделов в ""Настройках"" снята галочка ""Обрабатывать подраздел"". Поставьте галочку хотя бы на одном из них.", vbOKOnly, "Предупреждение")
                Exit Sub
            End If
        End If

        ''If VerifySettings_NumberOfErrors > 0 Then
        ''    MsgBox("Есть ошибки в настройках. Исправьте их и щелкните кнопу ""Проверить настройки"".", vbOKOnly, "Ошибка")
        ''    Exit Sub
        ''End If

        'Обновляем/очищаем элементы
        torrentsCollection.Clear()
        dgv1.Rows.Clear()
        txtReport.Text = ""
        txtReportInForum.Text = ""
        Reports.Clear()
        For i As Integer = 0 To SubForumsList.Count - 1
            Reports.Add(New Class_Report)
        Next
        cbSelectSubforum.Items.Clear()
        Dim txt2 As String
        For Each ss As Class_Subforum In SubForumsList
            txt2 = ss.Name
            If ss.InnerList IsNot Nothing Then
                If ss.InnerList.Count > 0 Then
                    txt2 = "(+) " & txt2
                End If
            End If
            cbSelectSubforum.Items.Add(txt2)
        Next

        'Проверяем: если торрент-клиент на нашем компе, то притормаживаем его на время веб-запросов
        TC.ReceiveTorClientSessionToken()
        If DownloadWebPageAnswer(0) = "Error" Then
            MessageBox.Show(Me, "Недоступен торрент-клиент. Дальнейшая обработка невозможна." & vbNewLine & _
                            "Проверьте правильность настроек доступа к торрент-клиенту", "Ошибка доступа", vbOKOnly, MessageBoxIcon.Error)
            ExtendedLog &= "Недоступен торрент-клиент. Дальнейшая обработка невозможна." & vbNewLine
            ObrabotkaStartovala = False
            Exit Sub
        End If
        If SavI.LimitSpeedDownloadIs = True Or SavI.LimitSpeedUploadIs = True Then TC.LimitSpeedTorrentClient("ON")
        GUI("block")
        Try
            BWorker.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(Me, "В данный момент обработка невозможна. Попробуйте позже.", "Сообщение", vbOKOnly, MessageBoxIcon.Information)
            Exit Sub
        End Try

    End Sub

    Private Sub ОстановитьВсеРаздачиВТоррентклиентеToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ОстановитьВсеРаздачиВТоррентклиентеToolStripMenuItem.Click
        whatTOstartInBWorker = 4
        'Задаём переменные
        ObrabotkaStartovala = True
        ExtendedLog = ""
        NameOfFile = NowDayTimeFull() & "_ОстановитьВсеРаздачиВТоррентклиенте.log"
        SaveExtendedLog()

        'Обновляем/очищаем элементы
        TorCollStopAll.Clear()

        'Проверяем: если торрент-клиент на нашем компе, то притормаживаем его на время веб-запросов
        TC.ReceiveTorClientSessionToken()
        If DownloadWebPageAnswer(0) = "Error" Then
            MessageBox.Show(Me, "Недоступен торрент-клиент. Дальнейшая обработка невозможна." & vbNewLine & _
                            "Проверьте правильность настроек доступа к торрент-клиенту", "Ошибка доступа", vbOKOnly, MessageBoxIcon.Error)
            ExtendedLog &= "Недоступен торрент-клиент. Дальнейшая обработка невозможна." & vbNewLine
            ObrabotkaStartovala = False
            Exit Sub
        End If
        If SavI.LimitSpeedDownloadIs = True Or SavI.LimitSpeedUploadIs = True Then TC.LimitSpeedTorrentClient("ON")
        GUI("block")
        Try
            BWorker.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(Me, "В данный момент обработка невозможна. Попробуйте позже.", "Сообщение", vbOKOnly, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub
    Private Sub StopAllTorrents(ByRef torColl As List(Of torrentInfo))
        Dim text As String = ""
        If SavI.torrentClientName = 1 Then text = "Правка ярлыков и запуск-остановка раздач"
        If SavI.torrentClientName = 2 Then text = "Запуск-остановка раздач"
        Dim Stop_AllCom As String = ""
        Dim Stop_CountOfAdded As Integer = 0
        For IndexOfTorInTorColl = 0 To torColl.Count - 1


            'leechersName(136) = "Личер: остановлен"
            'leechersName(138) = "Личер: согласно парсингу веб-страниц. Но может и на паузе стоять!" 'Ввёл по просьбе Tokuchi_Toua
            '   leechersName(152) = "Личер: ошибка загрузки (удалены файлы?)"
            '   leechersName(200) = "Личер: в очереди"
            '   leechersName(232) = "Личер: на паузе (был в очереди загрузок)"
            '   leechersName(201) = "Личер: загружается"
            '   leechersName(233) = "Личер: на паузе (был на Запустить)"
            '   leechersName(137) = "Личер: принудительно загружается"
            '   leechersName(169) = "Личер: на паузе (был на Принудительно)"
            '   leechersName(194) = "Личер: ожидает в очереди проверки файлов" 'Transmission
            '   leechersName(130) = "Личер: проверка файлов" 'Transmission

            'If torColl(IndexOfTorInTorColl).Status = 152 Or _
            '    torColl(IndexOfTorInTorColl).Status = 200 Or _
            '    torColl(IndexOfTorInTorColl).Status = 232 Or _
            '    torColl(IndexOfTorInTorColl).Status = 201 Or _
            '    torColl(IndexOfTorInTorColl).Status = 233 Or _
            '    torColl(IndexOfTorInTorColl).Status = 137 Or _
            '    torColl(IndexOfTorInTorColl).Status = 169 Or _
            '    torColl(IndexOfTorInTorColl).Status = 194 Or _
            '    torColl(IndexOfTorInTorColl).Status = 130 Then
            '    TC.TorrentStop(torColl, IndexOfTorInTorColl, Stop_AllCom, Stop_CountOfAdded, False)
            'End If

            If torColl(IndexOfTorInTorColl).Status <> 136 Then
                TC.TorrentStop(torColl, IndexOfTorInTorColl, Stop_AllCom, Stop_CountOfAdded, False)
            End If

            If IndexOfTorInTorColl = torColl.Count - 1 Then 'При последнем проходе коллекции выполняем все неотправленные команды
                TC.AddAndSendCom("", "", Stop_AllCom, Stop_CountOfAdded, True)
            End If
            If IndexOfTorInTorColl / 50 = IndexOfTorInTorColl \ 50 Or IndexOfTorInTorColl = torColl.Count - 1 Then
                StageOfWorkShow(text & "и № " & (IndexOfTorInTorColl + 1).ToString & " / " & torColl.Count.ToString)
            End If
        Next
    End Sub

    Private Sub TSSTorrFilesParsing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSSTorrFilesParsing.Click
        If ListOfInfoFromTorrentFiles.TorrFilesErrors.Length > 0 Then
            Dim txt As New TextBox With {.Dock = DockStyle.Fill, _
                                         .Text = ListOfInfoFromTorrentFiles.TorrFilesErrors.ToString, _
                                         .Multiline = True, _
                                         .ReadOnly = True}
            Dim tfe As New Form With {.Width = 800, _
                                      .Height = 500, _
                                      .StartPosition = FormStartPosition.CenterParent, _
                                      .Text = "Ошибки при разборе торрент-файлов", _
                                     .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow, _
                                      .Icon = WindowsApplication1.My.Resources.Keepers}
            tfe.Controls.Add(txt)
            tfe.ShowDialog(Me)
        End If
    End Sub

    Private Sub СкачиваниеТорентфайловПоСпискуИРаботаСПасскеямиToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles СкачиваниеТорентфайловПоСпискуИРаботаСПасскеямиToolStripMenuItem.Click
        frmLinksListsAndTorFiles.ShowDialog(Me)
    End Sub

End Class
