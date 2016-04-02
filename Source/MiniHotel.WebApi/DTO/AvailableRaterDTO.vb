Public Class AvailableRaterDTO
    Public Property Username() As String
        Get
            Return m_Username
        End Get
        Set(value As String)
            m_Username = value
        End Set
    End Property
    Private m_Username As String
    Public Property Password() As String
        Get
            Return m_Password
        End Get
        Set(value As String)
            m_Password = value
        End Set
    End Property
    Private m_Password As String
    Public Property HotelId() As String
        Get
            Return m_HotelId
        End Get
        Set(value As String)
            m_HotelId = value
        End Set
    End Property
    Private m_HotelId As String
    Public Property HotelCurrency() As String
        Get
            Return m_HotelCurrency
        End Get
        Set(value As String)
            m_HotelCurrency = value
        End Set
    End Property
    Private m_HotelCurrency As String
    Public Property DateFrom() As Date
        Get
            Return m_DateFrom
        End Get
        Set(value As Date)
            m_DateFrom = value
        End Set
    End Property
    Private m_DateFrom As Date
    Public Property DateTo() As Date
        Get
            Return m_DateTo
        End Get
        Set(value As Date)
            m_DateTo = value
        End Set
    End Property
    Private m_DateTo As Date
    Public Property Adults() As Integer
        Get
            Return m_Adults
        End Get
        Set(value As Integer)
            m_Adults = value
        End Set
    End Property
    Private m_Adults As Integer
    Public Property Child() As Integer
        Get
            Return m_Child
        End Get
        Set(value As Integer)
            m_Child = value
        End Set
    End Property
    Private m_Child As Integer
    Public Property Babies() As Integer
        Get
            Return m_Babies
        End Get
        Set(value As Integer)
            m_Babies = value
        End Set
    End Property
    Private m_Babies As Integer
    Public Property RateCode() As String
        Get
            Return m_RateCode
        End Get
        Set(value As String)
            m_RateCode = value
        End Set
    End Property
    Private m_RateCode As String
End Class