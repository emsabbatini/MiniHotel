Imports System.Xml.Serialization

<XmlRoot(ElementName:="Resnumbers")> _
Public Class ResNumbersModel
    <XmlAttribute(AttributeName:="Number")> _
    Public Property Number() As String
        Get
            Return m_Number
        End Get
        Set(value As String)
            m_Number = value
        End Set
    End Property
    Private m_Number As String
    <XmlAttribute(AttributeName:="OtaNumber")> _
    Public Property OtaNumber() As String
        Get
            Return m_OtaNumber
        End Get
        Set(value As String)
            m_OtaNumber = value
        End Set
    End Property
    Private m_OtaNumber As String

End Class
