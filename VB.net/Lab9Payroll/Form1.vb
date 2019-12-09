'Author: ALex Stevens
'Date:2/13/2018
'Assignment: lab 5 payroll
Option Strict On

Public Class Form1
    Dim hoursWorkedV As Decimal
    Dim payrateV As Decimal
    Dim grossfinalPay As Decimal
    Const taxrate As Decimal = 0.0425D
    Dim michTax As Decimal
    Dim amountEarned As Decimal
    Const socialTax As Decimal = 0.062D
    Dim finalSSTax As Decimal
    Const MedicareTaxrate As Decimal = 0.0145D
    Dim finalMedTax As Decimal
    Dim finalNetPay As Decimal
    Dim eName As String



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxEmploymentType.Items.Add("Hourly")
        cbxEmploymentType.Items.Add("Salaried")
        cbxEmploymentType.Items.Add("Commission")


    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cleartextboxes()
        cbxEmploymentType.SelectedIndex = -1
    End Sub
    Private Sub cleartextboxes()
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                ctrl.Text = String.Empty
            End If
        Next ctrl
    End Sub

    Private Function GrossPay(hoursWorked As Decimal, payrate As Decimal) As Decimal

        If hoursWorked <= 40D Then
            GrossPay = hoursWorked * payrate
        Else
            GrossPay = ((hoursWorked - 40) * (payrate * 1.5D)) + (40 * payrate)
        End If

    End Function

    Private Function MichiganTax(grossPay As Decimal, taxrate As Decimal) As Decimal
        MichiganTax = grossPay * taxrate

    End Function
    Private Function SocialSecurity(ssTax As Decimal, ytd As Decimal, grosspay As Decimal) As Decimal
        If grosspay + ytd < 118500 Then
            SocialSecurity = grosspay * ssTax
        ElseIf ytd >= 118500 Then
            SocialSecurity = 0
        Else
            SocialSecurity = (118500 - ytd) * ssTax
        End If

    End Function

    Private Function MedicareTax(medTax As Decimal, grosspay As Decimal) As Decimal
        MedicareTax = grosspay * medTax

    End Function

    Private Function NetPay(medtax As Decimal, sstax As Decimal, michtax As Decimal, grosspay As Decimal, ytd As Decimal) As Decimal
        NetPay = grosspay - medtax - sstax - michtax
    End Function
    Private Sub DisplayFinal(name As String, hoursworked As Decimal, payrate As Decimal, amountearned As Decimal, grosspay As Decimal, michtax As Decimal, sstax As Decimal, medtax As Decimal, netpay As Decimal)

        MessageBox.Show("Name: ".PadRight(20) & name.PadLeft(15) & ControlChars.NewLine & "Hours Worked: ".PadRight(20) & hoursworked.ToString("c2").PadLeft(15) & ControlChars.NewLine & "Pay Rate: ".PadRight(20) & payrate.ToString("c2").PadLeft(15) & ControlChars.NewLine & "YTD Amount: ".PadRight(20) & amountearned.ToString("c2").PadLeft(15) & ControlChars.NewLine & "Gross Pay: ".PadRight(20) & grosspay.ToString("c2").PadLeft(15) & ControlChars.NewLine & "Michigan Tax: ".PadRight(20) & michtax.ToString("c2").PadLeft(15) & ControlChars.NewLine & "Social Security: ".PadRight(20) & sstax.ToString("c2").PadLeft(15) & ControlChars.NewLine & "Medicare Tax ".PadRight(20) & medtax.ToString("c2").PadLeft(15) & ControlChars.NewLine & "Net Pay: ".PadRight(20) & netpay.ToString("c2").PadLeft(15), "Final Amounts")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClac.Click
        If txtEmpNumber.Text = Nothing Or IsNumeric(txtEmpNumber.Text) Then
            MessageBox.Show("Please enter a name", "Error")
            txtEmpNumber.Focus()
            txtEmpNumber.SelectAll()
            Exit Sub
        End If
        '  If Not IsNumeric(txtHours.Text) Then
        ' MessageBox.Show("Please enter a number for hours worked", "Error")
        ' txtHours.Focus()
        ' txtHours.SelectAll()
        '  Exit Sub
        ' End If 
        '  If Not IsNumeric(txtPayRate.Text) Then
        ' MessageBox.Show("Please enter a pay rate", "Error")
        'txtPayRate.Focus()
        'txtPayRate.SelectAll()
        'Exit Sub
        ' End If
        'If Not IsNumeric(txtAmountEarned.Text) Then
        ' MessageBox.Show("Please enter an amount earned", "Error")
        'txtAmountEarned.Focus()
        'txtAmountEarned.SelectAll()
        'Exit Sub
        ' End If
        ' hoursWorkedV = Convert.ToDecimal(txtHours.Text)
        ' payrateV = Convert.ToDecimal(txtPayRate.Text)
        ' eName = Convert.ToString(txtEmpNumber.Text)
        ' amountEarned = Convert.ToDecimal(txtAmountEarned.Text)
        ' grossfinalPay = GrossPay(hoursWorkedV, payrateV)
        ' michTax = MichiganTax(grossfinalPay, taxrate)
        ' finalSSTax = SocialSecurity(socialTax, amountEarned, grossfinalPay)
        ' finalMedTax = MedicareTax(MedicareTaxrate, grossfinalPay)
        ' finalNetPay = NetPay(finalMedTax, finalSSTax, michTax, grossfinalPay, amountEarned)
        ' DisplayFinal(eName, hoursWorkedV, payrateV, amountEarned, grossfinalPay, michTax, finalSSTax, finalMedTax, finalNetPay)
        If Validator.IsPresent(txtFirstName) AndAlso Validator.IsPresent(txtLastName) AndAlso Validator.IsPresent(txtEmpNumber) AndAlso Validator.IsPresent(txtDepartmentNumber) AndAlso Validator.IsPresent(txtStateOfWork) AndAlso Validator.IsPresent(txtWithholdingnum) AndAlso Validator.IsPresent(txtYTD) AndAlso Validator.IsInt32(txtDepartmentNumber) AndAlso Validator.IsInt32(txtWithholdingnum) AndAlso Validator.IsDecimal(txtYTD) AndAlso Validator.IsWithinRange(txtDepartmentNumber, 0, 99) AndAlso Validator.IsWithinRange(txtWithholdingnum, 0, 15) AndAlso Validator.IsWithinRange(txtYTD, 0, 500000) Then
            MessageBox.Show("First Name: " & txtFirstName.Text & ControlChars.NewLine & "Last Name: " & txtLastName.Text & ControlChars.NewLine & "Employee Number: " & txtEmpNumber.Text & ControlChars.NewLine & "Department number: " & txtDepartmentNumber.Text & ControlChars.NewLine & "State: " & txtStateOfWork.Text & ControlChars.NewLine & "Withholding Allowance: " & txtWithholdingnum.Text & ControlChars.NewLine & "YTD: " & txtYTD.Text & ControlChars.NewLine & "Employment Type: " & cbxEmploymentType.SelectedItem.ToString & ControlChars.NewLine, "Employee Record")
        End If

    End Sub

    Private Sub txtPayRate_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtAmountEarned_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class
