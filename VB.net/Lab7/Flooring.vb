Option Strict On
Public Class Flooring
    Private m_FlooringStyle As String
    Private m_Color As String
    Private m_Price As Decimal

    Public Sub New()

    End Sub

    Public Property Flooring As String
        Get
            Return m_FlooringStyle
        End Get
        Set(value As String)
            m_FlooringStyle = value
        End Set
    End Property

    Public Property Color As String
        Get
            Return m_Color
        End Get
        Set(value As String)
            m_Color = value
        End Set
    End Property

    Public Property Price As Decimal
        Get
            Return m_Price
        End Get
        Set(value As Decimal)
            m_Price = value
        End Set
    End Property
End Class
