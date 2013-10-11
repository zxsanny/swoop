Public Class Class_Report

    Private a_ToDnldTable As System.Collections.Generic.List(Of WindowsApplication1.Class_ReportLine)
    Private a_ToDnldText As System.Text.StringBuilder
    Private a_InForumSeeding As System.Text.StringBuilder
    Private a_InForumLeeching As System.Text.StringBuilder
    Private a_StartIndexInTorColl As Integer

    ''' <summary>
    ''' Данные для DataGridView с отчётом о малосидирумых нескачанных раздачах
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ToDnldTable As List(Of Class_ReportLine)
        Get
            Return a_ToDnldTable
        End Get
        Set(ByVal value As List(Of Class_ReportLine))
            a_ToDnldTable = value
        End Set
    End Property
    ''' <summary>
    ''' Данные для текстового отчёта о малосидирумых нескачанных раздачах
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ToDnldText As System.Text.StringBuilder
        Get
            Return a_ToDnldText
        End Get
        Set(ByVal value As System.Text.StringBuilder)
            a_ToDnldText = value
        End Set
    End Property
    ''' <summary>
    ''' Отчёт в форум о сидируемых раздачах
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InForumSeeding As System.Text.StringBuilder
        Get
            Return a_InForumSeeding
        End Get
        Set(ByVal value As System.Text.StringBuilder)
            a_InForumSeeding = value
        End Set
    End Property
    ''' <summary>
    ''' Отчёт в форум о скачиваемых раздачах
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InForumLeeching As System.Text.StringBuilder
        Get
            Return a_InForumLeeching
        End Get
        Set(ByVal value As System.Text.StringBuilder)
            a_InForumLeeching = value
        End Set
    End Property

    ''' <summary>
    ''' Индекс массива в torrentsCollection, с которого начинаются торренты текущего подраздела
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StartIndexInTorColl As Integer
        Get
            Return a_StartIndexInTorColl
        End Get
        Set(ByVal value As Integer)
            a_StartIndexInTorColl = value
        End Set
    End Property

    Public Sub New()
        a_ToDnldTable = New System.Collections.Generic.List(Of WindowsApplication1.Class_ReportLine)
        a_ToDnldText = New System.Text.StringBuilder With {.Capacity = 300000}
        a_InForumSeeding = New System.Text.StringBuilder With {.Capacity = 500000}
        a_InForumLeeching = New System.Text.StringBuilder With {.Capacity = 200000}
        a_StartIndexInTorColl = 0
    End Sub

End Class