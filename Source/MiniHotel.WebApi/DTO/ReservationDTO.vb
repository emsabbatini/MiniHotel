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
    Public Property CreateDateFrom() As Date
        Get
            Return m_CreateDateFrom
        End Get
        Set(value As Date)
            m_CreateDateFrom = value
        End Set
    End Property
    Private m_CreateDateFrom As Date
    Public Property CreateDateTo() As Date
        Get
            Return m_CreateDateTo
        End Get
        Set(value As Date)
            m_CreateDateTo = value
        End Set
    End Property
    Private m_CreateDateTo As Date
    Public Property ArrivalDateFrom() As Date?
        Get
            Return m_ArrivalDateFrom
        End Get
        Set(value As Date?)
            m_ArrivalDateFrom = value
        End Set
    End Property
    Private m_ArrivalDateFrom As Date?
    Public Property ArrivalDateTo() As Date?
        Get
            Return m_ArrivalDateTo
        End Get
        Set(value As Date?)
            m_ArrivalDateTo = value
        End Set
    End Property
    Private m_ArrivalDateTo As Date?
    Public Property DepartureDateFrom() As Date?
        Get
            Return m_DepartureDateFrom
        End Get
        Set(value As Date?)
            m_DepartureDateFrom = value
        End Set
    End Property
    Private m_DepartureDateFrom As Date?
    Public Property DepartureDateTo() As Date?
        Get
            Return m_DepartureDateTo
        End Get
        Set(value As Date?)
            m_DepartureDateTo = value
        End Set
    End Property
    Private m_DepartureDateTo As Date?
End Class
