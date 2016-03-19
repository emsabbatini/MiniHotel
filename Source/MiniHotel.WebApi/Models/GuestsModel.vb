Imports System.Xml.Serialization

<XmlRoot(ElementName:="Guests")> _
Public Class GuestsModel
    <XmlAttribute(AttributeName:="adults")> _
    Public Property Adults() As String
        Get
            Return m_Adults
        End Get
        Set(value As String)
            m_Adults = value
        End Set
    End Property
    Private m_Adults As String
    <XmlAttribute(AttributeName:="child")> _
    Public Property Child() As String
        Get
            Return m_Child
        End Get
        Set(value As String)
            m_Child = value
        End Set
    End Property
    Private m_Child As String
    <XmlAttribute(AttributeName:="babies")> _
    Public Property Babies() As String
        Get
            Return m_Babies
        End Get
        Set(value As String)
            m_Babies = value
        End Set
    End Property
    Private m_Babies As String
End Class
