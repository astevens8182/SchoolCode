'Author: ALex Stevens
'Date:4/4/18
'Assignment: homework 4 part 2
Option Strict On
Imports System.IO
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

    Dim binaryIn As New BinaryReader(New FileStream("PayrollIn.dat", FileMode.OpenOrCreate, FileAccess.Read))
    Dim emplist As New List(Of Employee)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



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
        binaryIn.Close()
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClac.Click
        Dim employee As New Employee
        Dim salary As New SalariedEmployee
        Dim hourly As New HourlyEmployee
        Dim commision As New CommissionedEmployee
        Dim count As Integer = 0
        Do While binaryIn.PeekChar <> -1

            employee.EmpNo = binaryIn.ReadString
            employee.EmpType = binaryIn.ReadChar
            lstReport.Items.Add(employee.EmpNo)
            employee.EmpFirstName = binaryIn.ReadString
            lstReport.Items(count).SubItems.Add(employee.EmpFirstName)
            employee.EmpLastName = binaryIn.ReadString
            lstReport.Items(count).SubItems.Add(employee.EmpLastName)

            employee.DepartmentNo = binaryIn.ReadUInt16
            employee.StateWork = binaryIn.ReadString
            employee.WithholdingAllow = binaryIn.ReadUInt16
            employee.YTDPay = binaryIn.ReadDecimal
            'Put break points in and it write the file correlty but when goes to read the withholding and ytd amounts are wrong?
            If employee.EmpType = "S"c Then


                salary.YearlySalary = binaryIn.ReadDecimal
                grossfinalPay = salary.YearlySalary / 52
                lstReport.Items(count).SubItems.Add((grossfinalPay).ToString("n2"))
                michTax = MichiganTax(grossfinalPay, taxrate)
                lstReport.Items(count).SubItems.Add((michTax).ToString("n2"))
                finalMedTax = MedicareTax(MedicareTaxrate, grossfinalPay)
                lstReport.Items(count).SubItems.Add((finalMedTax).ToString("n2"))
                finalSSTax = SocialSecurity(socialTax, amountEarned, grossfinalPay)
                lstReport.Items(count).SubItems.Add((finalSSTax).ToString("n2"))
                finalNetPay = NetPay(finalMedTax, finalSSTax, michTax, grossfinalPay, amountEarned)
                lstReport.Items(count).SubItems.Add((finalNetPay).ToString("c2"))
                count += 1


            End If
            If employee.EmpType = "H"c Then
                lstReport.Items.Add(employee.EmpNo)



                hourly.HoursWorked = binaryIn.ReadDouble
                hourly.PayRate = binaryIn.ReadDecimal
                grossfinalPay = GrossPay(Convert.ToDecimal(hourly.HoursWorked), hourly.PayRate)
                lstReport.Items(count).SubItems.Add((grossfinalPay).ToString("n2"))
                michTax = MichiganTax(grossfinalPay, taxrate)
                lstReport.Items(count).SubItems.Add((michTax).ToString("n2"))
                finalMedTax = MedicareTax(MedicareTaxrate, grossfinalPay)
                lstReport.Items(count).SubItems.Add((finalMedTax).ToString("n2"))
                finalSSTax = SocialSecurity(socialTax, amountEarned, grossfinalPay)
                lstReport.Items(count).SubItems.Add((finalSSTax).ToString("n2"))
                finalNetPay = NetPay(finalMedTax, finalSSTax, michTax, grossfinalPay, amountEarned)
                lstReport.Items(count).SubItems.Add((finalNetPay).ToString("c2"))
                emplist.Add(employee)
                emplist.Add(hourly)
                count += 1

            End If
            If employee.EmpType = "C"c Then
                lstReport.Items.Add(employee.EmpNo)


                commision.CommisssionRate = binaryIn.ReadDecimal
                commision.SalesMade = binaryIn.ReadDecimal
                grossfinalPay = commision.SalesMade * Convert.ToDecimal(commision.CommisssionRate)
                lstReport.Items(count).SubItems.Add((grossfinalPay).ToString("n2"))
                michTax = MichiganTax(grossfinalPay, taxrate)
                lstReport.Items(count).SubItems.Add((michTax).ToString("n2"))
                finalMedTax = MedicareTax(MedicareTaxrate, grossfinalPay)
                lstReport.Items(count).SubItems.Add((finalMedTax).ToString("n2"))
                finalSSTax = SocialSecurity(socialTax, amountEarned, grossfinalPay)
                lstReport.Items(count).SubItems.Add((finalSSTax).ToString("n2"))
                finalNetPay = NetPay(finalMedTax, finalSSTax, michTax, grossfinalPay, amountEarned)
                lstReport.Items(count).SubItems.Add((finalNetPay).ToString("c2"))
                emplist.Add(employee)
                emplist.Add(commision)
                count += 1

            End If

        Loop










    End Sub

    Private Sub txtPayRate_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtAmountEarned_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class
