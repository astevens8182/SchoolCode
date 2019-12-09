'Author: Alex Stevens
'Date: 2/20/2018
'Assginment: Lab 6
Option Strict On
Public Class Form1
    Private Function IsDouble(grade As String) _
            As Boolean
        Dim number As Double = 0
        If Double.TryParse(grade, number) Then
            Convert.ToDouble(grade)
            If Convert.ToDouble(grade) <= 100 And Convert.ToDouble(grade) > 0 Then
                Convert.ToDouble(grade)

                Return True
            Else

                MessageBox.Show(" must be between 0 - 100.", "Entry Error")
            End If
        Else
            MessageBox.Show(" must be a valid Grade.", "Entry Error")
            Return False
        End If
    End Function

    Private Function IsInt32(ClassSize As String) _
            As Boolean
        Dim number As Integer = 0
        If Int32.TryParse(ClassSize, number) Then
            Convert.ToInt32(ClassSize)
            If Convert.ToInt32(ClassSize) <= 100 And Convert.ToInt32(ClassSize) >= 1 Then
                Convert.ToInt32(ClassSize)

                Return True
            Else
                MessageBox.Show("Class Size" & " must be between 1-100.", "Entry Error")
            End If
        Else
                MessageBox.Show("Class Size" & " must be an integer.", "Entry Error")

            Return False
        End If
    End Function
    Private Function IsPresent(grade As String, name As String) _
            As Boolean
        If grade = "" Then
            MessageBox.Show(name & " is a required field.", "Entry Error")

            Return False
        Else
            Return True
        End If
    End Function
    Private Function classSizeVal(classSize As String) As Boolean
        If IsPresent(classSize, "Class Size") And IsInt32(classSize) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function isvalidGrade(grade As String) As Boolean
        If IsPresent(grade, "Grade") And IsDouble(grade) Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Function isletterGrade(grade As Double) As String
        Dim lettergrade As String = Nothing
        If grade >= 94 And grade <= 100 Then
            lettergrade = "A"
        ElseIf grade >= 90 And grade < 94 Then
            lettergrade = "A-"
        ElseIf grade >= 87 And grade < 90 Then
            lettergrade = "B+"
        ElseIf grade >= 83 And grade < 87 Then
            lettergrade = "B"
        ElseIf grade >= 80 And grade < 83 Then
            lettergrade = "B-"
        ElseIf grade >= 77 And grade < 80 Then
            lettergrade = "C+"
        ElseIf grade >= 73 And grade < 77 Then
            lettergrade = "C"
        ElseIf grade >= 70 And grade < 73 Then
            lettergrade = "C-"
        ElseIf grade >= 67 And grade < 70 Then
            lettergrade = "D+"
        ElseIf grade >= 63 And grade < 67 Then
            lettergrade = "D"
        ElseIf grade < 63 Then
            lettergrade = "F"
        End If
        Return lettergrade
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Dim stringGrade As String = Nothing
        Dim stringNumGrades As String = Nothing
        Dim totalGrades As Int32
        Dim averageScore As Double
        Dim bestScore As Double
        Dim worstScore As Double
        Dim letterAvg As String = Nothing
        Dim letterBest As String = Nothing
        Dim letterWorst As String = Nothing
        Do
            stringNumGrades = (InputBox("How many grades are you entering?", "Number of Grades",, 0))
        Loop Until classSizeVal(stringNumGrades)

        totalGrades = Convert.ToInt32(stringNumGrades)
        Dim grades(totalGrades) As Double

        For i As Integer = 0 To totalGrades - 1
            Do
                stringGrade = InputBox("Enter grade", "Grade Entry",, 0)

            Loop Until isvalidGrade(stringGrade)
            grades(i) = Convert.ToDouble(stringGrade)
            Next


        For x As Integer = 0 To totalGrades
            averageScore += grades(x)
        Next
        averageScore = averageScore / (totalGrades)
        worstScore = grades(0)
        For y As Integer = 0 To totalGrades - 1
            If grades(y) <= worstScore Then
                worstScore = grades(y)
            End If
        Next

        For z As Integer = 0 To totalGrades - 1
            bestScore = 0
            If grades(z) >= bestScore Then
                bestScore = grades(z)
            End If
        Next
        letterAvg = isletterGrade(averageScore)
        letterBest = isletterGrade(bestScore)
        letterWorst = isletterGrade(worstScore)


        MessageBox.Show("Totals".PadLeft(15) & "Grade Percent".PadLeft(15) & "Letter Grade".PadLeft(15) & "Average score: " & ControlChars.NewLine & averageScore & letterAvg.PadLeft(15) & ControlChars.NewLine & "Best score: " & bestScore & letterBest.PadLeft(15) & ControlChars.NewLine & "Worst score: " & worstScore & letterWorst.PadLeft(15), "Grade Report")

    End Sub
End Class
