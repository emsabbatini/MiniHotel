Imports System.Xml.Serialization

<XmlRoot(ElementName:="AvailRaters")> _
Public Class AvailableRatersModel
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
    <XmlElement(ElementName:="DateRange")> _
    Public Property DateRange() As DateRangeModel
        Get
            Return m_DateRange
        End Get
        Set(value As DateRangeModel)
            m_DateRange = value
        End Set
    End Property
    Private m_DateRange As DateRangeModel
    <XmlElement(ElementName:="Guests")> _
    Public Property Guests() As GuestsModel
        Get
            Return m_Guests
        End Get
        Set(value As GuestsModel)
            m_Guests = value
        End Set
    End Property
    Private m_Guests As GuestsModel
    <XmlElement(ElementName:="RoomType")> _
    Public Property RoomType() As List(Of RoomTypeModel)
        Get
            Return m_RoomType
        End Get
        Set(value As List(Of RoomTypeModel))
            m_RoomType = value
        End Set
    End Property
    Private m_RoomType As List(Of RoomTypeModel)
End Class

