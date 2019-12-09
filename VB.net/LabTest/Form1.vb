'Alex Stevens
'Lab test
'date 4/10/18
Option Strict On
Public Class Form1
    Dim waterCostNoTax As Decimal
    Dim FinalWaterBill As Decimal
    Dim SalesTax As Decimal
    Dim TotalWaterCostNoTax As Decimal
    Dim TotalFinalWaterBill As Decimal
    Dim TotalSalesTax As Decimal
    Dim TotalCustomers As Integer
    Dim count As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtUnitsUsed_TextChanged(sender As Object, e As EventArgs) Handles txtUnitsUsed.TextChanged

    End Sub
    Public Function isValidData(vtxtCustomerNumber As TextBox, vCustomerLastName As TextBox, vCustomerAddress As TextBox, vUnitsUsed As TextBox) As Boolean
        If Validator.IsPresent(vtxtCustomerNumber) AndAlso Validator.IsPresent(vCustomerLastName) AndAlso Validator.IsPresent(vCustomerAddress) AndAlso Validator.IsPresent(vUnitsUsed) AndAlso Validator.IsInt32(vUnitsUsed) AndAlso Validator.IsWithinRange(vUnitsUsed, 0, 500) Then
            Return True

        Else
            Return False
        End If
    End Function

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click


        If isValidData(txtCustomerNumber, txtCustomerLastName, txtCustomerAddress, txtUnitsUsed) Then

            Dim WaterBillObject As New WaterBillCust
                waterCostNoTax = WaterBillObject.WaterCost(Convert.ToInt32(txtUnitsUsed.Text), waterCostNoTax)
                SalesTax = WaterBillObject.SalesTax(waterCostNoTax, SalesTax)
                FinalWaterBill = SalesTax + waterCostNoTax
                lstReport.Items.Add(txtCustomerNumber.Text)
                lstReport.Items(count).SubItems.Add(txtCustomerLastName.Text)
                lstReport.Items(count).SubItems.Add(txtCustomerAddress.Text)
                lstReport.Items(count).SubItems.Add(txtUnitsUsed.Text)
                lstReport.Items(count).SubItems.Add(waterCostNoTax.ToString("c2"))
                lstReport.Items(count).SubItems.Add(SalesTax.ToString("c2"))
                lstReport.Items(count).SubItems.Add(FinalWaterBill.ToString("c2"))
                TotalWaterCostNoTax += waterCostNoTax
                TotalSalesTax += SalesTax
                TotalFinalWaterBill += FinalWaterBill
                TotalCustomers += 1
                count += 1
                ClearTextboxes()
            lstReport.Items.Add("")
            lstReport.Items(count).SubItems.Add("")
            lstReport.Items(count).SubItems.Add("")
            lstReport.Items(count).SubItems.Add("")
            lstReport.Items(count).SubItems.Add(TotalWaterCostNoTax.ToString("c2"))
            lstReport.Items(count).SubItems.Add(TotalSalesTax.ToString("c2"))
            lstReport.Items(count).SubItems.Add(TotalFinalWaterBill.ToString("c2"))
            count += 1
            lstReport.Items.Add("Count")
            lstReport.Items(count).SubItems.Add(TotalCustomers.ToString("n0"))
            lstReport.Items(count).SubItems.Add("")
            lstReport.Items(count).SubItems.Add("")
            lstReport.Items(count).SubItems.Add("")
            lstReport.Items(count).SubItems.Add("")
            lstReport.Items(count).SubItems.Add("")
            count += 1
        Else
            Exit Sub
        End If


    End Sub
    Private Sub ClearTextboxes()
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                ctrl.Text = String.Empty

            End If

        Next ctrl
        txtCustomerNumber.Focus()
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearTextboxes()
        waterCostNoTax = 0
        FinalWaterBill = 0
        SalesTax = 0
        TotalCustomers = 0
        TotalFinalWaterBill = 0
        TotalSalesTax = 0
        TotalWaterCostNoTax = 0
        lstReport.Clear()


    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub
End Class
