'Author: ALex Stevens'
'Date: 1/16/2018"
'Assignment: lab 1 part 2'
Option Strict On

Public Class Form1
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtHeatIndex.Text = String.Empty
        nudAirTemp.Value = 0
        nudHumidity.Value = 0



    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        txtHeatIndex.Text = FormatNumber(-42.379 + 2.04901523 * nudAirTemp.Value + 10.14333127 * nudHumidity.Value - 0.22475541 * nudAirTemp.Value * nudHumidity.Value - 6.83783 * 10 ^ -3 * nudAirTemp.Value ^ 2 - 5.481717 * 10 ^ -2 * nudAirTemp.Value ^ 2 + 1.22874 * 10 ^ -3 * nudAirTemp.Value ^ 2 * nudHumidity.Value + 8.5282 * 10 ^ -4 * nudAirTemp.Value * nudHumidity.Value ^ 2 - 1.99 * 10 ^ -6 * nudAirTemp.Value ^ 2 * nudHumidity.Value ^ 2, 1)


    End Sub
End Class
