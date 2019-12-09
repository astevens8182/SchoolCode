'Alex Stevens
'Lab test
'date 4/10/18
Option Strict On
Public Class WaterBillCust
    Public Property CustomerNumber As String
    Public Property CustomerLastName As String
    Public Property CustomerAddress As String
    Public Property UnitsUsed As Integer
    Public Sub New()

    End Sub
    Public Sub New(pCustomerNumber As String, pCustomerLastName As String, pCustomerAddress As String, pUnitsUsed As Integer)
        Me.CustomerNumber = pCustomerNumber
        Me.CustomerLastName = pCustomerLastName
        Me.CustomerAddress = pCustomerAddress
        Me.UnitsUsed = pUnitsUsed


    End Sub

    Public Function WaterCost(vUnitsUsed As Integer, vWaterCost As Decimal) As Decimal
        Dim BasicWaterCharge As Decimal = 39.36D
        If vUnitsUsed <= 4 Then
            vWaterCost = 39.36D * 1.108D
            Return vWaterCost
        ElseIf vUnitsUsed >= 5 And vUnitsUsed <= 24 Then
            vWaterCost = (39.36D + (4.72D * (vUnitsUsed - 4))) * 1.108D
            Return vWaterCost
        Else
            vWaterCost = (39.36D + (6.2D * (vUnitsUsed - 4))) * 1.108D
            Return vWaterCost
        End If


    End Function

    Public Function SalesTax(vWaterCost As Decimal, vSalesTax As Decimal) As Decimal
        vSalesTax = vWaterCost * 0.06D
        Return vSalesTax
    End Function
End Class
