Public Class ReservationDTO
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
    Public Property HotelId As String
        Get
            Return m_HotelId
        End Get
        Set(value As String)
            m_HotelId = value
        End Set
    End Property
    Private m_HotelId As String
    Public Property CreateDateFrom() As String
        Get
            Return m_CreateDateFrom
        End Get
        Set(value As String)
            m_CreateDateFrom = value
        End Set
    End Property
    Private m_CreateDateFrom As String
    Public Property CreateDateTo() As String
        Get
            Return m_CreateDateTo
        End Get
        Set(value As String)
            m_CreateDateTo = value
        End Set
    End Property
    Private m_CreateDateTo As String
    Public Property ArrivalFrom() As String
        Get
            Return m_ArrivalFrom
        End Get
        Set(value As String)
            m_ArrivalFrom = value
        End Set
    End Property
    Private m_ArrivalFrom As String
    Public Property ArrivalTo() As String
        Get
            Return m_ArrivalTo
        End Get
        Set(value As String)
            m_ArrivalTo = value
        End Set
    End Property
    Private m_ArrivalTo As String
    Public Property DepartureFrom() As String
        Get
            Return m_DepartureFrom
        End Get
        Set(value As String)
            m_DepartureFrom = value
        End Set
    End Property
    Private m_DepartureFrom As String
    Public Property DepartureTo() As String
        Get
            Return m_DepartureTo
        End Get
        Set(value As String)
            m_DepartureTo = value
        End Set
    End Property
    Private m_DepartureTo As String
End Class
