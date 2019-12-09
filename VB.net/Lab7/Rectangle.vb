Option Strict On

Public Class Rectangle
    Private m_Width As Double
    Private m_Length As Double
    Private m_Area As Double

    Public Sub New()

    End Sub

    Public Property Width As Double
        Get
            Return m_Width
        End Get
        Set(value As Double)
            m_Width = value
        End Set
    End Property

    Public Property Length As Double
        Get
            Return m_Length
        End Get
        Set(value As Double)
            m_Length = value
        End Set
    End Property

    Public ReadOnly Property Area As Double
        Get
            Return m_Area
        End Get
    End Property

    Public Sub CalculateArea()
        m_Area = Length * Width
    End Sub

End Class
