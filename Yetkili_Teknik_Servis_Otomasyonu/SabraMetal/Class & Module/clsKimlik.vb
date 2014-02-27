Public Class clsKimlik
    Private _KimlikID As Integer
    Private _KimlikName As String
    Private _KimlikViewUser As ArrayList
    Private _KimlikViewUserQuery As String

    Public ReadOnly Property KimlikID() As Integer
        Get
            Return Me._KimlikID
        End Get
    End Property
    Public ReadOnly Property KimlikName() As String
        Get
            Return Me._KimlikName
        End Get
    End Property
    Public ReadOnly Property KimlikViewUser() As ArrayList
        Get
            Return Me._KimlikViewUser
        End Get
    End Property
    Public ReadOnly Property KimlikViewUSerQuery() As String
        Get
            Return Me._KimlikViewUserQuery
        End Get
    End Property

    ''' <summary>
    ''' Kullan�c� i�in olu�turumu� kimlik kart� nesnesi.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub

    ''' <summary>
    ''' Kullan�c�n�n g�rebildi�i kimliklerin bilgilerini tutmak i�in kullan�l�r.
    ''' </summary>
    ''' <param name="KimlikID">Kimlik ID.</param>
    ''' <param name="KimlikName">Kimlik Ismi.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal KimlikID As Integer, ByVal KimlikName As String)
        Me._KimlikID = KimlikID
        Me._KimlikName = KimlikName
    End Sub

    ''' <summary>
    ''' Kullan�c� i�in olu�turumu� kimlik kart�.
    ''' </summary>
    ''' <param name="KimlikID">Kullan�c� ID.</param>
    ''' <param name="KimlikName">Kullan�c� �smi.</param>
    ''' <param name="KimlikViewUser">Kullan�c�n�n kay�tlar�n� g�rebilece�i kullan�c� ID'leri.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal KimlikID As Integer, ByVal KimlikName As String, ByVal KimlikViewUser As ArrayList)
        Me._KimlikID = KimlikID
        Me._KimlikName = KimlikName
        Me._KimlikViewUser = KimlikViewUser
    End Sub

    ''' <summary>
    ''' Kullan�c� i�in olu�turumu� kimlik kart�.
    ''' </summary>
    ''' <param name="KimlikID">Kullan�c� ID.</param>
    ''' <param name="KimlikName">Kullan�c� �smi.</param>
    ''' <param name="KimlikViewUser">Kullan�c�n�n kay�tlar�n� g�rebilece�i kullan�c� ID'leri.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal KimlikID As Integer, ByVal KimlikName As String, ByVal KimlikViewUser As String)
        Me._KimlikID = KimlikID
        Me._KimlikName = KimlikName

        Dim Views() As String = {}
        Views = KimlikViewUser.Split("-")

        Dim ViewsUsers As ArrayList = New ArrayList

        For i As Integer = 0 To Views.Length - 1
            ViewsUsers.Add(Views(i))
        Next

        Me._KimlikViewUser = ViewsUsers

        Dim Query As String = " ("
        For Each itm As String In ViewsUsers
            Query &= "musSorumlu=" & CInt(itm) & " OR "
        Next

        Query = Query.Remove(Query.Length - 4, 4) & ")"

        Me._KimlikViewUserQuery = Query
    End Sub

    Public Overrides Function ToString() As String
        Return Me._KimlikName.ToString()
    End Function
End Class
