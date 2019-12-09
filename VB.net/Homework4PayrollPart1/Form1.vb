'Author: ALex Stevens
'Date:4/3/18
'Assignment: homework 4 part 1
Option Strict On
Imports System.IO

Public Class Form1

    Dim eName As String
    Dim employeeList As New List(Of Employee)


    Dim binaryOut As New BinaryWriter(New FileStream("PayrollOut.dat", FileMode.Append, FileAccess.Write))



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
         binaryOut.Close()
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

    Private Function IsVaildData(txtFirstName As TextBox, txtLastName As TextBox, txtEmpNumber As TextBox, txtDepartmentNumber As TextBox, txtStateOfWork As TextBox, txtWithholdingNumber As TextBox, txtYTD As TextBox) As Boolean
        If Validator.IsPresent(txtFirstName) AndAlso Validator.IsPresent(txtLastName) AndAlso Validator.IsPresent(txtEmpNumber) AndAlso Validator.IsPresent(txtDepartmentNumber) AndAlso Validator.IsInt32(txtDepartmentNumber) AndAlso Validator.IsWithinRange(txtDepartmentNumber, 0, 99) AndAlso Validator.IsPresent(txtStateOfWork) AndAlso Validator.IsPresent(txtWithholdingnum) AndAlso Validator.IsInt32(txtWithholdingnum) AndAlso Validator.IsWithinRange(txtWithholdingnum, 0, 15) AndAlso Validator.IsPresent(txtYTD) AndAlso Validator.IsDecimal(txtYTD) AndAlso Validator.IsWithinRange(txtYTD, 0, 500000) Then
            MessageBox.Show("First Name: " & txtFirstName.Text & ControlChars.NewLine & "Last Name: " & txtLastName.Text & ControlChars.NewLine & "Employee Number: " & txtEmpNumber.Text & ControlChars.NewLine & "Department number: " & txtDepartmentNumber.Text & ControlChars.NewLine & "State: " & txtStateOfWork.Text & ControlChars.NewLine & "Withholding Allowance: " & txtWithholdingnum.Text & ControlChars.NewLine & "YTD: " & txtYTD.Text & ControlChars.NewLine & "Employment Type: " & cbxEmploymentType.SelectedItem.ToString & ControlChars.NewLine, "Employee Record")
        End If
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClac.Click
        If cbxEmploymentType.Items.Contains(cbxEmploymentType.Text) = False Then
            MessageBox.Show("Must select a option for employment type", "Entry Error")

            Exit Sub

        End If
        IsVaildData(txtFirstName, txtLastName, txtEmpNumber, txtDepartmentNumber, txtStateOfWork, txtWithholdingnum, txtYTD)
        If cbxEmploymentType.SelectedIndex = 0 Then

            Dim employee As New HourlyEmployee

            employee.EmpNo = txtEmpNumber.Text
            binaryOut.Write(employee.EmpNo)
            employee.EmpType = "H"c
            binaryOut.Write(employee.EmpType)
            employee.EmpFirstName = txtFirstName.Text
            binaryOut.Write(employee.EmpFirstName)
            employee.EmpLastName = txtLastName.Text
            binaryOut.Write(employee.EmpLastName)
            employee.DepartmentNo = Convert.ToInt16(txtDepartmentNumber.Text)
            binaryOut.Write(employee.DepartmentNo)
            employee.StateWork = txtStateOfWork.Text
            binaryOut.Write(employee.StateWork)
            employee.WithholdingAllow = Convert.ToInt16(txtWithholdingnum.Text)
            binaryOut.Write(employee.WithholdingAllow)
            employee.YTDPay = Convert.ToDecimal(txtYTD.Text)
            binaryOut.Write(employee.YTDPay)
            employee.HoursWorked = Convert.ToDouble(txtempttpe1.Text)
            binaryOut.Write(employee.HoursWorked)
            employee.PayRate = Convert.ToDecimal(txtempltype2.Text)
            binaryOut.Write(employee.PayRate)
        End If
        If cbxEmploymentType.SelectedIndex = 2 Then
            Dim employeecomission As New CommissionedEmployee

            employeecomission.EmpNo = txtEmpNumber.Text
            binaryOut.Write(employeecomission.EmpNo)
            employeecomission.EmpType = "C"c
            binaryOut.Write(employeecomission.EmpType)
            employeecomission.EmpFirstName = txtFirstName.Text
            binaryOut.Write(employeecomission.EmpFirstName)
            employeecomission.EmpLastName = txtLastName.Text
            binaryOut.Write(employeecomission.EmpLastName)
            employeecomission.DepartmentNo = Convert.ToInt16(txtDepartmentNumber.Text)
            binaryOut.Write(employeecomission.DepartmentNo)
            employeecomission.StateWork = txtStateOfWork.Text
            binaryOut.Write(employeecomission.StateWork)
            employeecomission.WithholdingAllow = Convert.ToInt16(txtWithholdingnum.Text)
            binaryOut.Write(employeecomission.WithholdingAllow)
            employeecomission.YTDPay = Convert.ToDecimal(txtYTD.Text)
            binaryOut.Write(employeecomission.YTDPay)
            employeecomission.CommisssionRate = Convert.ToDouble(txtempttpe1.Text)
            binaryOut.Write(employeecomission.CommisssionRate)
            employeecomission.SalesMade = Convert.ToDecimal(txtempltype2.Text)
            binaryOut.Write(employeecomission.SalesMade)

        End If

        If cbxEmploymentType.SelectedIndex = 1 Then


            Dim employeeSalary As New SalariedEmployee

            employeeSalary.EmpNo = txtEmpNumber.Text
            binaryOut.Write(employeeSalary.EmpNo)
            employeeSalary.EmpType = "S"c
            binaryOut.Write(employeeSalary.EmpType)
            employeeSalary.EmpFirstName = txtFirstName.Text
            binaryOut.Write(employeeSalary.EmpFirstName)
            employeeSalary.EmpLastName = txtLastName.Text
            binaryOut.Write(employeeSalary.EmpLastName)
            employeeSalary.DepartmentNo = Convert.ToInt16(txtDepartmentNumber.Text)
            binaryOut.Write(employeeSalary.DepartmentNo)
            employeeSalary.StateWork = txtStateOfWork.Text
            binaryOut.Write(employeeSalary.StateWork)
            employeeSalary.WithholdingAllow = Convert.ToInt16(txtWithholdingnum.Text)
            binaryOut.Write(employeeSalary.WithholdingAllow)
            employeeSalary.YTDPay = Convert.ToDecimal(txtYTD.Text)
            binaryOut.Write(employeeSalary.YTDPay)
            employeeSalary.YearlySalary = Convert.ToDecimal(txtempttpe1.Text)
            binaryOut.Write(employeeSalary.YearlySalary)
        End If
    End Sub

    Private Sub txtPayRate_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtAmountEarned_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cbxEmploymentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxEmploymentType.SelectedIndexChanged
        If cbxEmploymentType.SelectedIndex = 1 Then
            Label3.Text = "Yealry Salary"
            Label4.Hide()
            txtempltype2.Hide()
        End If

        If cbxEmploymentType.SelectedIndex = 0 Then
            Label3.Text = "Hours Worked"
            Label4.Text = "Pay Rate"
            Label4.Show()
            txtempltype2.Show()
        End If
        If cbxEmploymentType.SelectedIndex = 2 Then
            Label3.Text = "Commission Made"
            Label4.Text = "Sales Made"
            Label4.Show()
            txtempltype2.Show()
        End If

    End Sub
End Class
