'Author: ALex Stevens
'Date: 3/20/2018
'Assignment: fileLab
Option Strict On
Imports System.IO
Public Class Form1

    Dim textIn As New StreamReader(New FileStream("Payments.txt", FileMode.Open, FileAccess.Read))
    Dim pmtList As New List(Of Payment)
    Dim name As String

    Public Function methodname(Paymentchar As Char, methname As String) As String
        If Paymentchar = "C"c Then
            methname = "Cash"
        ElseIf Paymentchar = "D"c Then
            methname = "Debit"
        ElseIf Paymentchar = "R"c Then
            methname = "Credit"
        ElseIf Paymentchar = "K"c Then
            methname = "Check"
        ElseIf Paymentchar = "T"c Then
            methname = "Transfer"
        End If
        Return methname
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub BtnExti_Click(sender As Object, e As EventArgs) Handles BtnExti.Click
        Me.Close()
        textIn.Close()

    End Sub

    Private Sub BtnReport_Click(sender As Object, e As EventArgs) Handles BtnReport.Click
        Dim totalamt As Double
        Do While textIn.Peek <> -1
            Dim row As String = textIn.ReadLine
            Dim columns() As String = row.Split(CChar("|"))
            Dim payment As New Payment
            payment.DatePaid = Convert.ToDateTime(columns(0))
            payment.Payee = columns(1)
            payment.Amount = Convert.ToDecimal(columns(2))
            payment.Method = Convert.ToChar(columns(3))
            pmtList.Add(payment)
        Loop
        textIn.Close()

        LstReport.Items.Add("Monthly Payment Report")
        LstReport.Items.Add("Date" & "Payee".PadLeft(17) & "Amount".PadLeft(17) & "Method".PadLeft(13))
        For Each Payment In (pmtList)
            name = methodname(Payment.Method, name)
            totalamt += Payment.Amount
            LstReport.Items.Add(Payment.DatePaid.ToShortDateString.PadRight(12) & Payment.Payee.PadLeft(17) & Payment.Amount.ToString("c2").PadLeft(12) & name.PadLeft(12))

        Next
        LstReport.Items.Add("TOTAL AMOUNT: " & totalamt.ToString("c2").PadLeft(27))






    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Dim searchvaule As String
        Dim totalrec As Double
        searchvaule = InputBox("Enter Payee")
        For Each Payment In (pmtList)
            If searchvaule = Payment.Payee Then
                totalrec += Payment.Amount
                LstReport.Items.Add(searchvaule & " Total: " & totalrec.ToString("c2").PadLeft(27))
            End If

        Next
    End Sub
End Class
