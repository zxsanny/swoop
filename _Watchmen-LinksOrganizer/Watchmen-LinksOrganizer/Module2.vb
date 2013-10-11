Option Strict On
Module Module2
    Sub Main()
        Dim aLinkedList As New LinkedList("first link")
        Dim aLink As LinkedList.Link
        aLink = aLinkedList.MakeLink(aLinkedList.GetFirstLink, "second link")
        aLink = aLinkedList.MakeLink(aLink, "third link")
        Console.WriteLine(aLinkedList.GetFirstLink.MyData)
        aLink = aLinkedList.GetNextLink(aLinkedList.GetFirstLink)
        Console.WriteLine(aLink.MyData)
        Console.WriteLine(aLink.NextLink.MyData)
        Console.ReadLine()
    End Sub
    Public Class LinkedList
        Private m_CurrentLink As Link
        Private m_FirstLink As Link
        Sub New(ByVal theData As String)
            m_CurrentLink = New Link(theData)
            m_FirstLink = m_CurrentLink
        End Sub
        Public Function MakeLink(ByVal currentLink As Link, ByVal theData As String) As Link
            m_CurrentLink = New Link(currentLink, theData)
            Return m_CurrentLink
        End Function
        Public ReadOnly Property GetNextLink(ByVal aLink As Link) As Link
            Get
                Return aLink.NextLink()
            End Get
        End Property
        Public ReadOnly Property GetCurrentLink() As Link
            Get
                Return m_CurrentLink
            End Get
        End Property
        Public ReadOnly Property GetFirstLink As Link
            Get
                Return m_FirstLink
            End Get
        End Property

        ' Вложенный класс для ссылок
        Friend Class Link
            Private m_MyData As String
            Private m_NextLink As Link
            Friend Sub New(ByVal myParent As Link, ByVal theData As String)
                m_MyData = theData
                myParent.m_NextLink = Me
            End Sub
            Friend Sub New(ByVal theData As String)
                m_MyData = theData
            End Sub
            Friend ReadOnly Property MyData() As String
                Get
                    Return m_MyData
                End Get
            End Property
            Friend ReadOnly Property NextLink() As Link
                Get
                    Return m_NextLink
                End Get
            End Property
        End Class
    End Class
End Module

