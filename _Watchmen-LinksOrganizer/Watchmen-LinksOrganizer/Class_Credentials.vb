
Public Class Class_CredentialsUser
    Private m_Username As String
    Private m_Password As String
    Private m_Token As String
    Private m_Cookies As String

    Public Property Username As String
        Get
            Return m_Username
        End Get
        Set(ByVal value As String)
            m_Username = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return m_Password
        End Get
        Set(ByVal value As String)
            m_Password = value
        End Set
    End Property

    Public Property Cookies As String
        Get
            Return m_Cookies
        End Get
        Set(ByVal value As String)
            m_Cookies = value
        End Set
    End Property

    Public Property Token As String
        Get
            Return m_Token
        End Get
        Set(ByVal value As String)
            m_Token = value
        End Set
    End Property

    Public Sub New()
        m_Username = ""
        m_Password = ""
        m_Cookies = ""
        m_Token = ""
    End Sub

End Class

Public Class Class_CredentialsUsersColl
    Inherits System.Collections.CollectionBase
    Private m_DomainName As String
    Private m_IndexForWebpage As Integer
    Private m_IndexForFile As Integer

    ''' <summary>
    ''' Имя домена
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DomainName As String
        Get
            Return m_DomainName
        End Get
        Set(ByVal value As String)
            m_DomainName = value
        End Set
    End Property

    Public Property Item(ByVal index As Integer) As Class_CredentialsUser
        Get
            Return CType(List.Item(index), Class_CredentialsUser)
        End Get
        Set(ByVal value As Class_CredentialsUser)
            List.Item(index) = CType(value, Class_CredentialsUser)
        End Set
    End Property
    ''' <summary>
    ''' Индекс элемента, используемого для скачивания веб-страниц
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IndexForWebpage As Integer
        Get
            Return m_IndexForWebpage
        End Get
        Set(ByVal value As Integer)
            m_IndexForWebpage = value
        End Set
    End Property
    ''' <summary>
    ''' Индекс элемента, используемого для скачивания файла
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IndexForFile As Integer
        Get
            Return m_IndexForFile
        End Get
        Set(ByVal value As Integer)
            m_IndexForFile = value
        End Set
    End Property

    Public Sub MoveUp(ByVal ind As Integer)
        If ind > 0 And ind < List.Count Then
            Dim element As New Class_CredentialsUser
            element = List.Item(ind)
            List.Insert(ind - 1, element)
            List.RemoveAt(ind + 1)
        End If
    End Sub

    Public Sub MoveDown(ByVal ind As Integer)
        If ind >= 0 And ind < List.Count - 1 Then
            Dim element As New Class_CredentialsUser
            element = List.Item(ind)
            List.Insert(ind + 2, element)
            List.RemoveAt(ind)
        End If
    End Sub

    Public Sub Add(ByVal CredsOfUser As Class_CredentialsUser)
        List.Add(CredsOfUser)
    End Sub
    ''' <summary>
    ''' Пока тупо добавлю пару элементов, ибо для рутрекера надо до двух аккаунтов.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        IndexForWebpage = 0
        IndexForFile = 0
        List.Add(New Class_CredentialsUser)
        List.Add(New Class_CredentialsUser)
    End Sub

End Class

Public Class Class_CredentialsDomainsColl
    Inherits System.Collections.CollectionBase

    Public Property Item(ByVal index As Integer) As Class_CredentialsUsersColl
        Get
            Return CType(List.Item(index), Class_CredentialsUsersColl)
        End Get
        Set(ByVal value As Class_CredentialsUsersColl)
            List.Item(index) = CType(value, Class_CredentialsUsersColl)
        End Set
    End Property

    ''' <summary>
    ''' Получаем значение свойства записи, применяемой для получения веб-страниц
    ''' </summary>
    ''' <param name="DomainName">Название домена, например rutracker.org</param>
    ''' <param name="PropertyName">Свойство пользователя</param>
    ''' <remarks></remarks>
    Public Function GetPropForWebpage(ByVal DomainName As String, ByVal PropertyName As CredsDomainsCollPropertyList) As String
        Return GetSetProp(DomainName, PropertyName, "", CallType.Get, "webpage")
    End Function

    ''' <summary>
    ''' Задаём значение свойства записи, применяемой для получения веб-страниц
    ''' </summary>
    ''' <param name="DomainName">Название домена, например rutracker.org</param>
    ''' <param name="PropertyName">Свойство пользователя</param>
    ''' <remarks></remarks>
    Public Sub SetPropForWebpage(ByVal DomainName As String, ByVal PropertyName As CredsDomainsCollPropertyList, ByVal PropertyValue As String)
        GetSetProp(DomainName, PropertyName, PropertyValue, CallType.Set, "webpage")
    End Sub

    ''' <summary>
    ''' Получаем значение свойства записи, применяемой для получения файлов
    ''' </summary>
    ''' <param name="DomainName">Название домена, например rutracker.org</param>
    ''' <param name="PropertyName">Свойство пользователя</param>
    ''' <remarks></remarks>
    Public Function GetPropForFile(ByVal DomainName As String, ByVal PropertyName As CredsDomainsCollPropertyList) As String
        Return GetSetProp(DomainName, PropertyName, "", CallType.Get, "file")
    End Function

    ''' <summary>
    ''' Задаём значение свойства записи, применяемой для получения файлов
    ''' </summary>
    ''' <param name="DomainName">Название домена, например rutracker.org</param>
    ''' <param name="PropertyName">Свойство пользователя</param>
    ''' <remarks></remarks>
    Public Sub SetPropForFile(ByVal DomainName As String, ByVal PropertyName As CredsDomainsCollPropertyList, ByVal PropertyValue As String)
        GetSetProp(DomainName, PropertyName, PropertyValue, CallType.Set, "file")
    End Sub
    ''' <summary>
    ''' Ищем  УЖЕ существующую запись!!!
    ''' </summary>
    ''' <param name="DomainName"></param>
    ''' <param name="PropertyName"></param>
    ''' <param name="PropertyValue"></param>
    ''' <param name="CalType"></param>
    ''' <param name="WebpageOrFile">"webpage", "file"</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSetProp(ByVal DomainName As String, ByVal PropertyName As CredsDomainsCollPropertyList, ByVal PropertyValue As String, _
                                ByVal CalType As CallType, ByVal WebpageOrFile As String) As String
        'По номеру определяем название свойства
        Dim name1 As String = ""
        Select Case PropertyName
            Case 1 : name1 = "Username"
            Case 2 : name1 = "Password"
            Case 4 : name1 = "Cookies"
            Case 8 : name1 = "Token"
            Case Else : Return ""
        End Select

        If List.Count > 0 Then
            For Each dom As Class_CredentialsUsersColl In List
                If dom.DomainName = DomainName Then
                    Try
                        Select Case CalType
                            Case CallType.Get
                                Select Case WebpageOrFile
                                    Case "webpage" : Return CallByName(dom.Item(dom.IndexForWebpage), name1, CallType.Get)
                                    Case "file" : Return CallByName(dom.Item(dom.IndexForFile), name1, CallType.Get)
                                End Select
                            Case CallType.Set
                                Select Case WebpageOrFile
                                    Case "webpage" : CallByName(dom.Item(dom.IndexForWebpage), name1, CallType.Set, PropertyValue)
                                    Case "file" : CallByName(dom.Item(dom.IndexForFile), name1, CallType.Set, PropertyValue)
                                End Select
                        End Select
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If

        Return ""
    End Function

    Public Sub MoveUserUp(ByVal Domain As String, ByVal ind As Integer)
        'Для начала проверим, что УЖЕ есть домен с нужным именем
        If List.Count > 0 Then
            For Each dom As Class_CredentialsUsersColl In List
                If dom.DomainName = Domain Then
                    dom.MoveUp(ind)
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Public Sub MoveUserDown(ByVal Domain As String, ByVal ind As Integer)
        'Для начала проверим, что УЖЕ есть домен с нужным именем
        If List.Count > 0 Then
            For Each dom As Class_CredentialsUsersColl In List
                If dom.DomainName = Domain Then
                    dom.MoveDown(ind)
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Public Sub AddNewUser(ByVal DomainName As String, ByVal Username As String, ByVal Password As String)
        Dim aa As New Class_CredentialsUser With {.Username = Username, .Password = Password}
        'Для начала проверим, может уже есть домен с нужным именем
        If List.Count > 0 Then
            For Each dom As Class_CredentialsUsersColl In List
                If dom.DomainName = DomainName Then
                    dom.Add(aa)
                    Exit Sub
                End If
            Next
        End If
        'Если домен не нашли, то создаём его и добавляем в него нашу запись
        Dim NewDom As New Class_CredentialsUsersColl
        NewDom.Add(aa)
        List.Add(NewDom)
    End Sub

    Public Sub ClearUsers(ByVal DomainName As String)
        If List.Count > 0 Then
            For Each dom As Class_CredentialsUsersColl In List
                If dom.DomainName = DomainName Then
                    dom.Clear()
                    Exit Sub
                End If
            Next
        End If
    End Sub

End Class

''' <summary>
''' Перечисление свойств пользователя
''' </summary>
''' <remarks></remarks>
Public Enum CredsDomainsCollPropertyList As Integer
    Cookies = 4
    Password = 2
    Token = 8
    Username = 1
End Enum
'' ''' <summary>
'' ''' Тип информации: веб-страница или файл
'' ''' </summary>
'' ''' <remarks></remarks>
''Public Enum CredsDomainsCollTypeOfInfo
''    Webpage = 1
''    File = 2
''End Enum
'' ''' <summary>
'' ''' Тип задачи, выполняемой с инфой: запись или чтение
'' ''' </summary>
'' ''' <remarks></remarks>
''Public Enum CredsDomainsCollCalType
''    'Числовые значения делаю теже, что и в оригинальных элементах CallType.Get и CallType.Set
''    Seet = 8
''    Geet = 2
''End Enum
