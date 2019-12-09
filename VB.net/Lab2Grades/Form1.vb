'Author:Alex Stevens'
'Date: 1/23/2018'
'Assignment: lab 2'
Option Strict On
Public Class Form1
    Dim testScore As Double
    Dim count As Integer
    Dim bestScore As Double
    Dim worstScore As Double = 100
    Dim avgScore As Double
    Dim testScoreSum As Double

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        If txtTestScores.Text = String.Empty Then
            MsgBox("Must enter a grade")

        Else

            testScore = Convert.ToDecimal(txtTestScores.Text)
            bestScore = Math.Max(bestScore, testScore)


            worstScore = Math.Min(worstScore, testScore)
            txtWorstScore.Text = Convert.ToString(worstScore)
            testScoreSum += testScore
            count += 1

            avgScore = testScoreSum / count
            avgScore = Math.Round(avgScore, 2)
            txtNumScore.Text = Convert.ToString(count)
            txtBestScore.Text = Convert.ToString(bestScore)

            txtAvgScore.Text = Convert.ToString(avgScore)
            If avgScore >= 93 Then
                txtletterGrade.Text = "A"
            ElseIf avgScore >= 90 And avgScore < 93 Then
                txtletterGrade.Text = "A-"
            ElseIf avgScore >= 86.5 And avgScore < 89 Then
                txtletterGrade.Text = "B+"
            ElseIf avgScore >= 83 And avgScore < 86.5 Then
                txtletterGrade.Text = "B"
            ElseIf avgScore >= 80 And avgScore < 83 Then
                txtletterGrade.Text = "B-"
            ElseIf avgScore >= 76.5 And avgScore < 80 Then
                txtletterGrade.Text = "C+"
            ElseIf avgScore >= 73 And avgScore < 76.5 Then
                txtletterGrade.Text = "C"
            ElseIf avgScore >= 70 And avgScore < 73 Then
                txtletterGrade.Text = "C-"
            ElseIf avgScore >= 60 And avgScore < 70 Then
                txtletterGrade.Text = "D"
            ElseIf avgScore > 0 And avgScore < 60 Then
                txtletterGrade.Text = "F"
            End If

            txtTestScores.Focus()
            txtTestScores.SelectAll()

        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtTestScores.Text = String.Empty
        txtNumScore.Text = String.Empty
        txtBestScore.Text = String.Empty
        txtWorstScore.Text = String.Empty
        txtAvgScore.Text = String.Empty
        testScoreSum = 0
        testScore = 0
        count = 0
        bestScore = 0
        worstScore = 100
        avgScore = 0
        txtletterGrade.Text = ""


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub

    Private Sub txtTestScores_TextChanged(sender As Object, e As EventArgs) Handles txtTestScores.TextChanged

    End Sub

    Private Sub txtWorstScore_TextChanged(sender As Object, e As EventArgs) Handles txtWorstScore.TextChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class
