''' <summary>
''' В этом классе пока жёстко заданы вызовы под трекер rutracker.org, но в будущем надо это кастомизировать
''' </summary>
''' <remarks></remarks>
Public Class Class_ForumParser
    Private a_StageOfWork As String

    Public Property StageOfWork As String
        Get
            Return a_StageOfWork
        End Get
        Set(ByVal value As String)
            a_StageOfWork = value
        End Set
    End Property

    Public Sub ReceiveInfoFromWebPages(ByRef torColl As List(Of torrentInfo), ByVal IsNeedFindDatesTorReg As Boolean)
        Call rutrackerorg.ReceiveInfoFromWebPages(torColl, IsNeedFindDatesTorReg)
    End Sub

    Public Sub ReceiveAdditionalInfo(ByRef torColl As List(Of torrentInfo))
        Call rutrackerorg.ReceiveAdditionalInfo(torColl)
    End Sub
    Public Function CompareTorrentsByWebName(ByVal firstTorrent As torrentInfo, ByVal secondTorrent As torrentInfo) As Integer
        Return rutrackerorg.CompareTorrentsByWebName(firstTorrent, secondTorrent)
    End Function
    ''' <summary>
    ''' Возвращает суммарный "плавающий" размер раздач
    ''' </summary>
    ''' <param name="lst">Список индексов раздач</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReportsDGV_SumSize(ByVal lst As List(Of Integer), ByVal tCTemp As List(Of torrentInfo)) As String
        Return rutrackerorg.ReportsDGV_SumSize(lst, tCTemp)
    End Function

    Public Sub CheckUserToSeeding(ByRef torColl As List(Of torrentInfo))
        Call rutrackerorg.CheckUserToSeeding(torColl)
    End Sub
#Region "Эти две функции позволяют без обновления торрент-файлов менять обрабатываемые трекеры и смотреть, подходят ли торрент-файлы к текущим трекерам"
    ''' <summary>
    ''' Возвращает имя трекера. Здесь перебираем все известные трекеры и находим, кому принадлежит
    ''' </summary>
    ''' <param name="parser"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TrackerName(ByVal parser As TorrentParser) As String 'При парсинге торрент-файлов получаем имя трекера...
        'Проверим на принадлежность рутрекеру
        If parser.Comment.Contains("rutracker.org") = True Or parser.Comment.Contains("torrents.ru") = True Then Return "rutracker.org"
        'Здесь будут проверки на другие трекеры

        Return "" ' Если ни один трекер не подошёл, возвращаем пустую строку
    End Function

    ''' <summary>
    ''' Подходит ли этот трекер текущим настройкам
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TrackerNameIsGood(ByVal trackerName As String) As Boolean '... а затем при добавлении в общую коллекцию смотрим, подходит ли трекер - если нет, то не добавляем
        'Пока жёстко ставим для рутрекера
        If trackerName = "rutracker.org" Then Return True
        Return False
    End Function
#End Region
    Public Function CheckForum() As Boolean
        Return rutrackerorg.CheckForum
    End Function
End Class
