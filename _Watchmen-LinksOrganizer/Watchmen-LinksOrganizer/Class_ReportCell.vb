''' <summary>
''' Свойства ячейки отчёта
''' </summary>
''' <remarks></remarks>
Public Class Class_ReportCell
    Private a_Font As Font
    Private a_Link As String
    Private a_Value As String
    Private a_CellType As String
    Private a_bitmapNum As Integer
    Private a_ForeColor As Color
    Private a_ToolTipText As String
    Private a_BackColor As Color
    ''' <summary>
    ''' Шрифт ячейки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Font As Font
        Get
            Return a_Font
        End Get
        Set(ByVal value As Font)
            a_Font = value
        End Set
    End Property
    ''' <summary>
    ''' Текст ячейки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Value As String
        Get
            Return a_Value
        End Get
        Set(ByVal value As String)
            a_Value = value
        End Set
    End Property
    ''' <summary>
    ''' Гиперссылка ячейки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Link As String
        Get
            Return a_Link
        End Get
        Set(ByVal value As String)
            a_Link = value
        End Set
    End Property
    ''' <summary>
    ''' Тип ячейки: "text", "link", "bitmap"
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CellType As String
        Get
            Return a_CellType
        End Get
        Set(ByVal value As String)
            a_CellType = value
        End Set
    End Property
    ''' <summary>
    ''' Если ячейка типа bitmap, то здесь номер изображения
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property bitmapNum As Integer
        Get
            Return a_bitmapNum
        End Get
        Set(ByVal value As Integer)
            a_bitmapNum = value
        End Set
    End Property
    ''' <summary>
    ''' Цвет текста ячейки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ForeColor As Color
        Get
            Return a_ForeColor
        End Get
        Set(ByVal value As Color)
            a_ForeColor = value
        End Set
    End Property

    Public Property ToolTipText As String
        Get
            Return a_ToolTipText
        End Get
        Set(ByVal value As String)
            a_ToolTipText = value
        End Set
    End Property
    ''' <summary>
    ''' Цвет фона ячейки
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BackColor As Color
        Get
            Return a_BackColor
        End Get
        Set(ByVal value As Color)
            a_BackColor = value
        End Set
    End Property
    Public Sub New()
        a_Font = Nothing
        a_Link = ""
        a_Value = ""
        a_CellType = "text"
        a_bitmapNum = 0
        a_ForeColor = Nothing
        a_ToolTipText = ""
        a_BackColor = Nothing
    End Sub

End Class
