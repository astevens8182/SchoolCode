'Author: Alex Stevens
'Assignment:homework 4 part 1
'date: 4/3/18
Option Strict On
Public Class SalariedEmployee
    Inherits Employee
    Public Property YearlySalary As Decimal
    Public Sub New()

    End Sub
    Public Sub New(EmpNo As String, EmpFirstName As String, EmpLastName As String, DepartmentNo As Integer, StateWork As String, WithholdingAllow As Integer, YTDPay As Decimal, EmpType As Char, YearlySalary As Decimal)
        MyBase.New(EmpNo, EmpFirstName, EmpLastName, DepartmentNo, StateWork, WithholdingAllow, YTDPay, EmpType)
        Me.YearlySalary = YearlySalary
    End Sub
End Class
