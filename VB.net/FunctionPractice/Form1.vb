'Author: Alex Stevens
'Date: 2/12/18
'Assignment: function practice
Option Strict On
Public Class Form1
    Private Function isOdd(num As Integer) As Boolean
        If num Mod 2 = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function IsVowel(letter As Char) As Boolean

        If (letter = "A"c Or letter = "E"c Or letter = "I"c Or letter = "O"c Or letter = "U"c) Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Sub btnisodd_Click(sender As Object, e As EventArgs) Handles btnisodd.Click

        Dim count As Integer
        count = Convert.ToInt32(txtOddInput.Text)
        Do While count <= 100
            If isOdd(count) Then
                txtOut.Text &= count.ToString
            Else
            End If
            count += 1
        Loop
    End Sub

    Private Sub btnVowel_Click(sender As Object, e As EventArgs) Handles btnVowel.Click
        Dim letter As Char
        letter = Convert.ToChar(txtvowelInput.Text)
        If (IsVowel(letter)) Then

            txtOut.Text = letter & " is a vowel"
        Else
            txtOut.Text = letter & " is a not vowel"
        End If
    End Sub
End Class
