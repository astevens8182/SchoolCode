﻿'Author: Alex Stevens
'Assignment:Lab 9
'date: 3/27/18
Option Strict On

Public Class Employee
    Public Property EmpNo As String
    Public Property EmpFirstName As String
    Public Property EmpLastName As String
    Public Property DepartmentNo As Integer
    Public Property StateWork As String
    Public Property WithholdingAllow As Integer
    Public Property YTDPay As Decimal

    Public Sub New()

    End Sub

    Public Sub New(EmpNo As String, EmpFirstName As String, EmpLastName As String, DepartmentNo As Integer, StateWork As String, WithholdingAllow As Integer, YTDPay As Decimal)
        Me.EmpNo = EmpNo
        Me.EmpFirstName = EmpFirstName
        Me.EmpLastName = EmpLastName
        Me.DepartmentNo = DepartmentNo
        Me.StateWork = StateWork
        Me.WithholdingAllow = WithholdingAllow
        Me.YTDPay = YTDPay



    End Sub
End Class
