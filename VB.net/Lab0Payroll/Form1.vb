'Author: Alex Stevens'
'Date 1/9/2018'
'Assigment: Lab 0'
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        TxtPay.Text = TxtHoursWorked.Text * TxtPayRate.Text

    End Sub
End Class
