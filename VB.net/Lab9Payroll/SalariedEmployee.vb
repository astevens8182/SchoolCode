'Author: Alex Stevens
'Assignment:Lab 9
'date: 3/27/18
Option Strict On
Public Class SalariedEmployee
    Inherits Employee
    Public Property YearlySalary As Decimal
    Public Sub New()

    End Sub
    Public Sub New(EmpNo As String, EmpFirstName As String, EmpLastName As String, DepartmentNo As Integer, StateWork As String, WithholdingAllow As Integer, YTDPay As Decimal, YearlySalary As Decimal)
        MyBase.New(EmpNo, EmpFirstName, EmpLastName, DepartmentNo, StateWork, WithholdingAllow, YTDPay)
        Me.YearlySalary = YearlySalary
    End Sub
End Class
