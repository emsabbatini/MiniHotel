Imports System.Xml.Serialization

<XmlRoot(ElementName:="MainGuest")> _
Public Class MainGuestModel
    <XmlAttribute(AttributeName:="FirstName")> _
    Public Property FirstName() As String
        Get
            Return m_FirstName
        End Get
        Set(value As String)
            m_FirstName = value
        End Set
    End Property
    Private m_FirstName As String
    <XmlAttribute(AttributeName:="LastName")> _
    Public Property LastName() As String
        Get
            Return m_LastName
        End Get
        Set(value As String)
            m_LastName = value
        End Set
    End Property
    Private m_LastName As String
    <XmlAttribute(AttributeName:="Passport")> _
    Public Property Passport() As String
        Get
            Return m_Passport
        End Get
        Set(value As String)
            m_Passport = value
        End Set
    End Property
    Private m_Passport As String
End Class
