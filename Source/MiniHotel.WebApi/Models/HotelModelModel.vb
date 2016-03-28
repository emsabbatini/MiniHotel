Imports System.Xml.Serialization

<XmlRoot(ElementName:="Hotel")> _
Public Class HotelModelModel
    <XmlAttribute(AttributeName:="id")> _
    Public Property Id() As String
        Get
            Return m_Id
        End Get
        Set(value As String)
            m_Id = value
        End Set
    End Property
    Private m_Id As String
    <XmlAttribute(AttributeName:="Name_h")> _
    Public Property Name_h() As String
        Get
            Return m_Name_h
        End Get
        Set(value As String)
            m_Name_h = value
        End Set
    End Property
    Private m_Name_h As String
    <XmlAttribute(AttributeName:="Name_e")> _
    Public Property Name_e() As String
        Get
            Return m_Name_e
        End Get
        Set(value As String)
            m_Name_e = value
        End Set
    End Property
    Private m_Name_e As String
    <XmlAttribute(AttributeName:="Currency")> _
    Public Property Currency() As String
        Get
            Return m_Currency
        End Get
        Set(value As String)
            m_Currency = value
        End Set
    End Property
    Private m_Currency As String
End Class
