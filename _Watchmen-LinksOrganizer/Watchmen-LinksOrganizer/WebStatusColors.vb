''' <summary>
''' Цвета статуса раздачи. ВНИМАНИЕ! Убраны дефисы
''' </summary>
''' <remarks></remarks>
Public Class WebStatusColors

    Public Property torapproved As Color
        Get
            Return Color.FromArgb(0, 128, 0)
        End Get
        Set(ByVal value As Color)

        End Set
    End Property

    Public Property torclosed As Color
        Get
            Return Color.FromArgb(255, 69, 0)
        End Get
        Set(ByVal value As Color)

        End Set
    End Property

    Public Property torclosedcp As Color
        Get
            Return Color.FromArgb(206, 56, 0)
        End Get
        Set(ByVal value As Color)

        End Set
    End Property

    Public Property torconsumed As Color
        Get
            Return Color.FromArgb(210, 105, 0)
        End Get
        Set(ByVal value As Color)

        End Set
    End Property

    Public Property tordup As Color
        Get
            Return Color.FromArgb(0, 0, 255)
        End Get
        Set(ByVal value As Color)

        End Set
    End Property

    Public Property torneededit As Color
        Get
            Return Color.FromArgb(255, 0, 0)
        End Get
        Set(ByVal value As Color)

        End Set
    End Property

    Public Property tornodesc As Color
        Get
            Return Color.FromArgb(255, 69, 0)
        End Get
        Set(ByVal value As Color)

        End Set
    End Property

    Public Property tornotapproved As Color
        Get
            Return Color.FromArgb(199, 21, 133)
        End Get
        Set(ByVal value As Color)

        End Set
    End Property

    Public Property torchecking As Color
        Get
            Return Color.FromArgb(36, 36, 255)
        End Get
        Set(ByVal value As Color)

        End Set
    End Property

End Class
