Imports System.Xml.Serialization

<XmlRoot(ElementName:="Reservation")> _
Public Class ReservationModel
    <XmlElement(ElementName:="Resnumbers")> _
    Public Property ResNumbers() As ResNumbersModel
        Get
            Return m_ResNumbers
        End Get
        Set(value As ResNumbersModel)
            m_ResNumbers = value
        End Set
    End Property
    Private m_ResNumbers As ResNumbersModel
    <XmlElement(ElementName:="ResDates")> _
    Public Property ResDates() As ResDatesModel
        Get
            Return m_ResDates
        End Get
        Set(value As ResDatesModel)
            m_ResDates = value
        End Set
    End Property
    Private m_ResDates As ResDatesModel
    <XmlElement(ElementName:="MainGuest")> _
    Public Property MainGuest() As MainGuestModel
        Get
            Return m_MainGuest
        End Get
        Set(value As MainGuestModel)
            m_MainGuest = value
        End Set
    End Property
    Private m_MainGuest As MainGuestModel
    <XmlElement(ElementName:="Meals")> _
    Public Property Meals() As MealsModel
        Get
            Return m_Meals
        End Get
        Set(value As MealsModel)
            m_Meals = value
        End Set
    End Property
    Private m_Meals As MealsModel
End Class
