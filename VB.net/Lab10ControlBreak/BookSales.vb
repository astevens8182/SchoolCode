'Author: Alex Stevens
'Date: 4/3/18
'Assginment: lab 10
Option Strict On

Public Class BookSales
    Public Property BookIdent As String
    Public Property DateSold As Date
    Public Property QuantitySold As Integer
    Public Sub New()

    End Sub
    Public Sub New(BookIdent As String, DateSold As Date, QuantitySold As Integer)
        Me.BookIdent = BookIdent
        Me.DateSold = DateSold
        Me.QuantitySold = QuantitySold
    End Sub
End Class
