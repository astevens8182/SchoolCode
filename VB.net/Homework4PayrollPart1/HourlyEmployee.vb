'Author: Alex Stevens
'Assignment:homework 4 part 1
'date: 4/3/18
Option Strict On
Public Class HourlyEmployee
    Inherits Employee
    Public Property HoursWorked As Double
    Public Property PayRate As Decimal

    Public Sub New()

    End Sub
    Public Sub New(EmpNo As String, EmpFirstName As String, EmpLastName As String, DepartmentNo As Integer, StateWork As String, WithholdingAllow As Integer, YTDPay As Decimal, EmpType As Char, HoursWorked As Double, PayRate As Decimal)
        MyBase.New(EmpNo, EmpFirstName, EmpLastName, DepartmentNo, StateWork, WithholdingAllow, YTDPay, EmpType)
        Me.HoursWorked = HoursWorked
        Me.PayRate = PayRate
    End Sub
End Class
