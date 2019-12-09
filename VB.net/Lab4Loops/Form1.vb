'Author: Alex Stevens
'Date: 2/6/2018
'Assingment: lab 4
Option Strict On

Public Class Form1
    Dim year As Double
    Dim population As Double
    Dim txtyear As Double
    Const idaho As Double = 1700000
    Const idahopercent As Double = 37400
    Const nevada As Double = 3000000
    Const nevadapercent As Double = 60000
    Const utah As Double = 3100000
    Const utahpercent As Double = 58900
    Const washington As Double = 7400000
    Const washingtonpercetn As Double = 125800
    Const florida As Double = 21000000
    Const floridaprcent As Double = 333900
    Dim state As Double
    Dim rate As Double
    Dim textstate As String
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles radUtah.CheckedChanged

    End Sub

    Private Sub btncalc_Click(sender As Object, e As EventArgs) Handles btncalc.Click
        If txtyears.Text = String.Empty Then
            MessageBox.Show("Must enter a year", "Error")
            txtyears.SelectAll()
            Exit Sub
        End If
        If Convert.ToDouble(txtyears.Text) > 20 Then
            MessageBox.Show("Must enter a year less than 20", "Error")
            txtyears.SelectAll()
            Exit Sub
        End If
        If IsNumeric(txtyears.Text) Then
            year = Convert.ToDouble(txtyears.Text)
            If radIdaho.Checked Then
                textstate = "Idaho"
                state = idaho
                rate = idahopercent

            ElseIf radNevada.Checked Then
                textstate = "Nevada"
                state = nevada
                rate = nevadapercent

            ElseIf radUtah.Checked Then
                textstate = "Utah"

                state = utah
                rate = utahpercent
            ElseIf radWashington.Checked Then
                textstate = "Washington"
                state = washington
                rate = washingtonpercetn
            ElseIf radFlorida.Checked Then
                textstate = "Flordia"
                state = florida
                rate = floridaprcent
            End If
            Dim count As Double
            txtreport.Text = "Year" & "                " & textstate & " Population" & ControlChars.NewLine & "2017               " & state & ControlChars.NewLine
            For count = 1 To year Step 1
                population = state + rate * count
                txtyear = 2017 + count
                txtreport.Text &= txtyear & "                " & Convert.ToString(population) & ControlChars.NewLine
            Next
        Else
            MessageBox.Show("Must enter a number for years", "Error")
            txtyears.SelectAll()
            Exit Sub
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtreport.Text = Nothing
        txtyears.Text = Nothing
        radIdaho.Checked = False
        radNevada.Checked = False
        radUtah.Checked = False
        radWashington.Checked = False
        radFlorida.Checked = False


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
