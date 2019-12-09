'Author: ALex Stevens
'Date: 3/20/2018
'Assignment: fileLab
Option Strict On

Public Class Payment
    Public Property DatePaid As DateTime
    Public Property Payee As String
    Public Property Amount As Decimal
    Public Property Method As Char

    Public Sub New()

    End Sub

    Public Sub New(datePaid As DateTime, payee As String, amount As Decimal, method As Char)
        Me.DatePaid = datePaid
        Me.Payee = payee
        Me.Amount = amount
        Me.Method = method
    End Sub


End Class
