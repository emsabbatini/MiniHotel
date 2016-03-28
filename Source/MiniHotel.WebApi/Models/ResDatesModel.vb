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
    <XmlAttribute(AttributeName:="Departue")> _
    Public Property Departue() As String
        Get
            Return m_Departue
        End Get
        Set(value As String)
            m_Departue = value
        End Set
    End Property
    Private m_Departue As String
End Class
