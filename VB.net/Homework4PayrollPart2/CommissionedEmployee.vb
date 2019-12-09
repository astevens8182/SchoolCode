'Author: Alex Stevens
'Assignment:Lab 9
'date: 3/27/18
Option Strict On
Public Class CommissionedEmployee
    Inherits Employee
    Public Property CommisssionRate As Double
    Public Property SalesMade As Decimal
    Public Sub New()


    End Sub
    Public Sub New(EmpNo As String, EmpFirstName As String, EmpLastName As String, DepartmentNo As Integer, StateWork As String, WithholdingAllow As Integer, YTDPay As Decimal, CommissionRate As Double, SalesMade As Decimal)
        MyBase.New(EmpNo, EmpFirstName, EmpLastName, DepartmentNo, StateWork, WithholdingAllow, YTDPay)
        Me.CommisssionRate = CommisssionRate
        Me.SalesMade = SalesMade
    End Sub
End Class
