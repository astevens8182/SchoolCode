'Author: Alex Stevens
'Date: 1/30/2018
'project: lab3
Option Strict On
Public Class Form1
    Dim taxIncome As Decimal
    Dim finalIncomeTax As Decimal
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtTaxIncome.Text = ""
        txtTaxOwed.Text = ""
        txtTaxIncome.Focus()
        txtTaxIncome.SelectAll()


    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        If txtTaxIncome.Text = "" Then
            MessageBox.Show("Must enter a value", "Error")
            txtTaxIncome.Focus()
            txtTaxIncome.SelectAll()
            Exit Sub
        End If
        If Not IsNumeric((txtTaxIncome.Text)) Then
            MessageBox.Show("Must enter a number", "Error")
            txtTaxIncome.Focus()
            txtTaxIncome.SelectAll()
            Exit Sub
        End If

        taxIncome = Convert.ToDecimal(txtTaxIncome.Text)
        If taxIncome < 0 Then
            MessageBox.Show("Must enter a value", "Error")
            txtTaxIncome.Focus()
            txtTaxIncome.SelectAll()
            Exit Sub
        End If
        If taxIncome > 1000000 Then
            MessageBox.Show("Must enter a value less than 1000000", "Error")
            txtTaxIncome.Focus()
            txtTaxIncome.SelectAll()
            Exit Sub
        End If

        If taxIncome >= 0 And taxIncome < 8700 Then
            finalIncomeTax = taxIncome * 0.1D
        ElseIf taxIncome >= 8700 And taxIncome < 35350 Then
            finalIncomeTax = 870 + (taxIncome - 8700) * 0.15D
        ElseIf taxIncome >= 35350 And taxIncome < 85650 Then
            finalIncomeTax = 4867 + (taxIncome - 35650) * 0.25D
        ElseIf taxIncome >= 85650 And taxIncome < 178650 Then
            finalIncomeTax = 17442 + (taxIncome - 85650) * 0.28D
        ElseIf taxIncome >= 178650 And taxIncome < 388350 Then
            finalIncomeTax = 43482 + (taxIncome - 178650) * 0.33D
        ElseIf taxIncome >= 388350 Then
            finalIncomeTax = 112683 + (taxIncome - 388350) * 0.35D
        End If
        txtTaxOwed.Text = finalIncomeTax.ToString("c2")

    End Sub
End Class
