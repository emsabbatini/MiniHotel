Imports System.Xml.Serialization

<XmlRoot(ElementName:="DateRange")> _
Public Class DateRangeModel
    <XmlAttribute(AttributeName:="from")> _
    Public Property From() As String
        Get
            Return m_From
        End Get
        Set(value As String)
            m_From = value
        End Set
    End Property
    Private m_From As String
    <XmlAttribute(AttributeName:="to")> _
    Public Property [To]() As String
        Get
            Return m_To
        End Get
        Set(value As String)
            m_To = value
        End Set
    End Property
    Private m_To As String
End Class
