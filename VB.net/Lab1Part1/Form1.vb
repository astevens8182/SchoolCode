'Author: Alex Stevens'
'Date: 1/16/2018'
'Assignment: Lab 1 Heat Index Part One;
Option Strict On

Public Class Form1
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtAirTemp.Clear()
        txtHeatIndex.Clear()
        txtRelativeHumidity.Clear()



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click

        txtHeatIndex.Text = FormatNumber(-42.379 + 2.04901523 * Convert.ToDouble(txtAirTemp.Text) + 10.14333127 * Convert.ToDouble(txtRelativeHumidity.Text) - 0.22475541 * Convert.ToDouble(txtAirTemp.Text) * Convert.ToDouble(txtRelativeHumidity.Text) - 6.83783 * 10 ^ -3 * Convert.ToDouble(txtAirTemp.Text) ^ 2 - 5.481717 * 10 ^ -2 * Convert.ToDouble(txtRelativeHumidity.Text) ^ 2 + 1.22874 * 10 ^ -3 * Convert.ToDouble(txtAirTemp.Text) ^ 2 * Convert.ToDouble(txtRelativeHumidity.Text) + 8.5282 * 10 ^ -4 * Convert.ToDouble(txtAirTemp.Text) * Convert.ToDouble(txtRelativeHumidity.Text) ^ 2 - 1.99 * 10 ^ -6 * Convert.ToDouble(txtAirTemp.Text) ^ 2 * Convert.ToDouble(txtRelativeHumidity.Text) ^ 2, 1)





    End Sub
End Class
