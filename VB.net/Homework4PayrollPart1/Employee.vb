'Author: Alex Stevens
'Assignment:homework 4 part 1
'date: 4/2/18
Option Strict On

Public Class Employee
    Public Property EmpNo As String
    Public Property EmpFirstName As String
    Public Property EmpLastName As String
    Public Property DepartmentNo As Integer
    Public Property StateWork As String
    Public Property WithholdingAllow As Integer
    Public Property YTDPay As Decimal
    Public Property EmpType As Char


    Public Sub New()

    End Sub

    Public Sub New(EmpNo As String, EmpFirstName As String, EmpLastName As String, DepartmentNo As Integer, StateWork As String, WithholdingAllow As Integer, YTDPay As Decimal, EmpType As Char)
        Me.EmpNo = EmpNo
        Me.EmpFirstName = EmpFirstName
        Me.EmpLastName = EmpLastName
        Me.DepartmentNo = DepartmentNo
        Me.StateWork = StateWork
        Me.WithholdingAllow = WithholdingAllow
        Me.YTDPay = YTDPay
        Me.EmpType = EmpType



    End Sub
End Class
