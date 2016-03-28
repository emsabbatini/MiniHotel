Imports System.Xml.Serialization

<XmlRoot(ElementName:="ReservationsRS")> _
Public Class ReservationsRSModel
    <XmlElement(ElementName:="Hotel")> _
    Public Property Hotel() As HotelModelModel
        Get
            Return m_Hotel
        End Get
        Set(value As HotelModelModel)
            m_Hotel = value
        End Set
    End Property
    Private m_Hotel As HotelModelModel
    <XmlElement(ElementName:="Reservation")> _
    Public Property Reservation() As List(Of ReservationModel)
        Get
            Return m_Reservation
        End Get
        Set(value As List(Of ReservationModel))
            m_Reservation = value
        End Set
    End Property
    Private m_Reservation As List(Of ReservationModel)
End Class
