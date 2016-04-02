Imports System.Xml.Serialization

<XmlRoot(ElementName:="ResDates")> _
Public Class ResDatesModel
    <XmlAttribute(AttributeName:="CreateDate")> _
    Public Property CreateDate() As String
        Get
            Return m_CreateDate
        End Get
        Set(value As String)
            m_CreateDate = value
        End Set
    End Property
    Private m_CreateDate As String
    <XmlAttribute(AttributeName:="Arrival")> _
        Public Property Arrival() As String
        Get
            Return m_Arrival
        End Get
        Set(value As String)
            m_Arrival = value
        End Set
    End Property
    Private m_Arrival As String
    <XmlAttribute(AttributeName:="Departure")> _
    Public Property Departure() As String
        Get
            Return m_Departure
        End Get
        Set(value As String)
            m_Departure = value
        End Set
    End Property
    Private m_Departure As String
End Class
