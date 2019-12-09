'Author: Alex Stevens
'Date: 4/3/18
'Assginment: lab 10
Option Strict On

Public Class Books
    Public Property BookID As String
    Public Property Title As String
    Public Property Author As String
    Public Property Price As Decimal

    Public Sub New()

    End Sub

    Public Sub New(BookID As String, Title As String, Author As String, Price As Decimal)
        Me.BookID = BookID
        Me.Title = Title
        Me.Author = Author
        Me.Price = Price
    End Sub
End Class
