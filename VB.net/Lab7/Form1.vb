'Author: Alex Stevens
' Date: 3/13
'Lab 7
Option Strict On

Public Class Form1
    Dim myFlooring As New Flooring()
    Dim myRectangle As New Rectangle()
    Dim area As Double
    Dim totalcost As Double


    Private Function IsDouble(text As String, name As String) _
            As Boolean
        Dim number As Double = 0
        If Double.TryParse(text, number) Then



            Return True
        Else

            MessageBox.Show(name & " must be greater than 0.", "Entry Error")
            Return False
        End If



    End Function

    Private Function IsPresent(text As String, name As String) _
            As Boolean
        If text = "" Then
            MessageBox.Show(name & " is a required field.", "Entry Error")

            Return False
        Else
            Return True
        End If
    End Function
    Private Function IsDecimal(text As String, name As String) _
            As Boolean
        Dim number As Decimal = 0D
        If Decimal.TryParse(text, number) Then



            Return True

        Else

            MessageBox.Show(name & " must be a Deciaml #.##", "Entry Error")
            Return False
        End If



    End Function

    Private Function isGreaterThan(text As Double, name As String) As Boolean

        If text >= 0 Then
            Return True

        Else
            MessageBox.Show(name & " must be greater than zero")
            Return False
        End If
    End Function

    Private Function IsVaild() As Boolean

        If IsDouble(txtRoomLength.Text, "length") AndAlso IsDouble(txtRoomWidth.Text, "width") AndAlso IsDecimal(txtPrice.Text, "Price") AndAlso isGreaterThan(Convert.ToDouble(txtRoomWidth.Text), "width") AndAlso isGreaterThan(Convert.ToDouble(txtRoomLength.Text), "length") Then
            Return True
        Else Return False


        End If
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        If IsVaild() = False Then
            Exit Sub
        End If
        myFlooring.Flooring = txtStyle.Text
        myFlooring.Color = txtColor.Text
        myFlooring.Price = Convert.ToDecimal(txtPrice.Text)
        myRectangle.Width = Convert.ToDecimal(txtRoomWidth.Text)
        myRectangle.Length = Convert.ToDecimal(txtRoomLength.Text)
        myRectangle.CalculateArea()
        area = myRectangle.Area
        totalcost = area * myFlooring.Price
        MessageBox.Show("Total cost: " & totalcost.ToString("c2"))
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class
