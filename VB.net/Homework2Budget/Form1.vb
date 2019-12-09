'Author: Alex Stevens'
'Date: 01/18/2018'
'Assignment: Homework 1'
Option Strict On

Public Class Form1
    Dim totalExpenses As Decimal
    Dim totalIncome As Decimal
    Dim balance As Decimal
    Dim percenttuition As Double
    Dim percentHousing As Double
    Dim percentBooks As Double
    Dim percentTransportation As Double
    Dim percentFood As Double
    Dim percentUtilities As Double
    Dim percentDebt As Double
    Dim percentInsurance As Double
    Dim percentEntertainment As Double
    Dim percentClothing As Double
    Dim percentMisc As Double
    Dim percentSalary As Double
    Dim percentScholarships As Double
    Dim percentParents As Double
    Dim percentSavings As Double
    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles grpExpenses.Enter

    End Sub

    Private Sub lblDebt_Click(sender As Object, e As EventArgs) Handles lblDebt.Click

    End Sub

    Private Sub lblHousing_Click(sender As Object, e As EventArgs) Handles lblHousing.Click

    End Sub

    Private Sub lblTransportaion_Click(sender As Object, e As EventArgs) Handles lblTransportaion.Click

    End Sub

    Private Sub lblUtilities_Click(sender As Object, e As EventArgs) Handles lblUtilities.Click

    End Sub

    Private Sub lblInsurance_Click(sender As Object, e As EventArgs) Handles lblInsurance.Click

    End Sub

    Private Sub txtTuition_TextChanged(sender As Object, e As EventArgs) Handles txtTuition.TextChanged

    End Sub

    Private Sub lblClothing_Click(sender As Object, e As EventArgs) Handles lblClothing.Click

    End Sub

    Private Sub lblMisc_Click(sender As Object, e As EventArgs) Handles lblMisc.Click

    End Sub

    Private Sub txtHousing_TextChanged(sender As Object, e As EventArgs) Handles txtHousing.TextChanged

    End Sub

    Private Sub txtTransportation_TextChanged(sender As Object, e As EventArgs) Handles txtTransportation.TextChanged

    End Sub

    Private Sub txtFood_TextChanged(sender As Object, e As EventArgs) Handles txtFood.TextChanged

    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles lblScholarships.Click

    End Sub

    Private Sub lblParents_Click(sender As Object, e As EventArgs) Handles lblParents.Click

    End Sub

    Private Sub txtDebt_TextChanged(sender As Object, e As EventArgs) Handles txtDebt.TextChanged

    End Sub

    Private Sub txtClothing_TextChanged(sender As Object, e As EventArgs) Handles txtClothing.TextChanged

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        If txtTuition.Text Is String.Empty OrElse Not IsNumeric(txtTuition.Text) OrElse Convert.ToDecimal(txtTuition.Text) < 0 Then
            MessageBox.Show("Must enter  vaild number greater than zero for tuition field", "Error")
            txtTuition.Focus()
            txtTuition.SelectAll()
            Exit Sub
        End If
        If txtHousing.Text Is String.Empty OrElse Not IsNumeric(txtHousing.Text) OrElse Convert.ToDecimal(txtHousing.Text) < 0 Then
            MessageBox.Show("Must enter  vaild number greater than zero for housing field", "Error")
            txtHousing.Focus()
            txtHousing.SelectAll()
            Exit Sub
        End If
        If txtBooksAndSupplies.Text Is String.Empty OrElse Not IsNumeric(txtBooksAndSupplies.Text) OrElse Convert.ToDecimal(txtBooksAndSupplies.Text) < 0 Then
            MessageBox.Show("Must enter  vaild number greater than zero for books and supplies field", "Error")
            txtBooksAndSupplies.Focus()
            txtBooksAndSupplies.SelectAll()
            Exit Sub
        End If
        If txtTransportation.Text Is String.Empty OrElse Not IsNumeric(txtTransportation.Text) OrElse Convert.ToDecimal(txtTransportation.Text) < 0 Then
            MessageBox.Show("Must enter  vaild number greater than zero for Transportation field", "Error")
            txtTransportation.Focus()
            txtTransportation.SelectAll()
            Exit Sub
        End If
        If txtFood.Text Is String.Empty OrElse Not IsNumeric(txtFood.Text) OrElse Convert.ToDecimal(txtFood.Text) < 0 Then
            MessageBox.Show("Must enter  vaild number greater than zero for food field", "Error")
            txtFood.Focus()
            txtFood.SelectAll()
            Exit Sub
        End If
        If txtUtilities.Text Is String.Empty OrElse Not IsNumeric(txtUtilities.Text) OrElse Convert.ToDecimal(txtUtilities.Text) < 0 Then
            MessageBox.Show("Must enter  vaild number greater than zero for utilites field", "Error")
            txtUtilities.Focus()
            txtUtilities.SelectAll()
            Exit Sub
        End If
        If txtDebt.Text Is String.Empty OrElse Not IsNumeric(txtDebt.Text) OrElse Convert.ToDecimal(txtDebt.Text) < 0 Then
            MessageBox.Show("Must enter  vaild number greater than zero for debt field", "Error")
            txtDebt.Focus()
            txtDebt.SelectAll()
            Exit Sub
        End If
        If txtInsurance.Text Is String.Empty OrElse Not IsNumeric(txtInsurance.Text) OrElse Convert.ToDecimal(txtInsurance.Text) < 0 Then
            MessageBox.Show("Must enter  vaild number greater than zero for insurance field", "Error")
            txtInsurance.Focus()
            txtInsurance.SelectAll()
            Exit Sub
        End If
        If txtEntertainment.Text Is String.Empty OrElse Not IsNumeric(txtEntertainment.Text) OrElse Convert.ToDecimal(txtEntertainment.Text) < 0 Then
            MessageBox.Show("Must enter  vaild number greater than zero for entertainment field", "Error")
            txtEntertainment.Focus()
            txtEntertainment.SelectAll()
            Exit Sub
        End If
        If txtClothing.Text Is String.Empty OrElse Not IsNumeric(txtClothing.Text) OrElse Convert.ToDecimal(txtClothing.Text) < 0 Then
            MessageBox.Show("Must enter  vaild number greater than zero for clothing field", "Error")
            txtClothing.Focus()
            txtClothing.SelectAll()
            Exit Sub
        End If
        If txtMisc.Text Is String.Empty OrElse Not IsNumeric(txtMisc.Text) OrElse Convert.ToDecimal(txtMisc.Text) < 0 Then
            MessageBox.Show("Must enter  vaild number greater than zero for miscellaneous field", "Error")
            txtMisc.Focus()
            txtMisc.SelectAll()
            Exit Sub
        End If
        If txtSalary.Text Is String.Empty OrElse Not IsNumeric(txtSalary.Text) OrElse Convert.ToDecimal(txtSalary.Text) < 0 Then
            MessageBox.Show("Must enter  vaild number greater than zero for salary field", "Error")
            txtSalary.Focus()
            txtSalary.SelectAll()
            Exit Sub
        End If
        If txtScholarships.Text Is String.Empty OrElse Not IsNumeric(txtScholarships.Text) OrElse Convert.ToDecimal(txtScholarships.Text) < 0 Then
            MessageBox.Show("Must enter  vaild number greater than zero for scholarships/grants field", "Error")
            txtScholarships.Focus()
            txtScholarships.SelectAll()
            Exit Sub
        End If
        If txtParents.Text Is String.Empty OrElse Not IsNumeric(txtParents.Text) OrElse Convert.ToDecimal(txtParents.Text) < 0 Then
            MessageBox.Show("Must enter  vaild number greater than zero for parents/family field", "Error")
            txtParents.Focus()
            txtParents.SelectAll()
            Exit Sub
        End If
        If txtSavings.Text Is String.Empty OrElse Not IsNumeric(txtSavings.Text) OrElse Convert.ToDecimal(txtSavings.Text) < 0 Then
            MessageBox.Show("Must enter  vaild number greater than zero for saving field", "Error")
            txtSavings.Focus()
            txtSavings.SelectAll()
            Exit Sub
        End If
        totalExpenses = Convert.ToDecimal(txtTuition.Text) + Convert.ToDecimal(txtHousing.Text) + Convert.ToDecimal(txtBooksAndSupplies.Text) + Convert.ToDecimal(txtTransportation.Text) + Convert.ToDecimal(txtFood.Text) + Convert.ToDecimal(txtUtilities.Text) + Convert.ToDecimal(txtDebt.Text) + Convert.ToDecimal(txtInsurance.Text) + Convert.ToDecimal(txtEntertainment.Text) + Convert.ToDecimal(txtClothing.Text) + Convert.ToDecimal(txtMisc.Text)
        txtTotalExpenses.Text = totalExpenses.ToString("C2")


        totalIncome = Convert.ToDecimal(txtSalary.Text) + Convert.ToDecimal(txtScholarships.Text) + Convert.ToDecimal(txtParents.Text) + Convert.ToDecimal(txtSavings.Text)
        txtTotalIncome.Text = totalIncome.ToString("C2")


        balance = totalIncome - totalExpenses
        If (balance >= 0) Then

            txtBalance.Text = balance.ToString("c2")
            txtBalance.BackColor = Color.White
            txtBalance.ForeColor = Color.Green
        Else
            txtBalance.Text = balance.ToString("c2")
            txtBalance.BackColor = Color.White
            txtBalance.ForeColor = Color.Red
        End If
        percenttuition = Convert.ToDouble(txtTuition.Text) / totalExpenses
        txtPercentTuition.Text = percenttuition.ToString("p2")

        percentHousing = Convert.ToDouble(txtHousing.Text) / totalExpenses
        txtPercentHousing.Text = percentHousing.ToString("p2")

        percentBooks = Convert.ToDouble(txtBooksAndSupplies.Text) / totalExpenses
        txtPercentBooks.Text = percentBooks.ToString("p2")

        percentTransportation = Convert.ToDouble(txtTransportation.Text) / totalExpenses
        txtPercentTrans.Text = percentTransportation.ToString("p2")

        percentFood = Convert.ToDouble(txtFood.Text) / totalExpenses
        txtPercentFood.Text = percentFood.ToString("p2")

        percentUtilities = Convert.ToDouble(txtUtilities.Text) / totalExpenses
        txtPercentUtil.Text = percentUtilities.ToString("p2")

        percentDebt = Convert.ToDouble(txtDebt.Text) / totalExpenses
        txtPercentDebt.Text = percentDebt.ToString("p2")

        percentInsurance = Convert.ToDouble(txtInsurance.Text) / totalExpenses
        txtPercentInsur.Text = percentInsurance.ToString("p2")

        percentEntertainment = Convert.ToDouble(txtEntertainment.Text) / totalExpenses
        txtPercentEnt.Text = percentEntertainment.ToString("p2")

        percentClothing = Convert.ToDouble(txtClothing.Text) / totalExpenses
        txtPercentCloth.Text = percentClothing.ToString("p2")

        percentMisc = Convert.ToDouble(txtMisc.Text) / totalExpenses
        txtPercentMisc.Text = percentMisc.ToString("p2")

        percentSalary = Convert.ToDouble(txtSalary.Text) / totalIncome
        txtPercentSalary.Text = percentSalary.ToString("p2")

        percentScholarships = Convert.ToDouble(txtScholarships.Text) / totalIncome
        txtPercentSchol.Text = percentScholarships.ToString("p2")

        percentParents = Convert.ToDouble(txtParents.Text) / totalIncome
        txtPercentParents.Text = percentParents.ToString("p2")

        percentSavings = Convert.ToDouble(txtSavings.Text) / totalIncome
        txtPercentSaving.Text = percentSavings.ToString("p2")

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim clear As Control
        For Each clear In grpExpenses.Controls
            If TypeOf clear Is TextBox Then
                clear.Text = Nothing
            End If
        Next
        For Each clear In grpIncome.Controls
            If TypeOf clear Is TextBox Then
                clear.Text = Nothing
            End If
        Next
        txtBalance.Text = Nothing
        txtBalance.BackColor = Nothing
    End Sub
End Class
