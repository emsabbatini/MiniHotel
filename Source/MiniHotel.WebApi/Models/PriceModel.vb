Imports System.Xml.Serialization

<XmlRoot(ElementName:="price")> _
Public Class PriceModel
    <XmlAttribute(AttributeName:="board")> _
    Public Property Board() As String
        Get
            Return m_Board
        End Get
        Set(value As String)
            m_Board = value
        End Set
    End Property
    Private m_Board As String
    <XmlAttribute(AttributeName:="boardDesc")> _
    Public Property BoardDesc() As String
        Get
            Return m_BoardDesc
        End Get
        Set(value As String)
            m_BoardDesc = value
        End Set
    End Property
    Private m_BoardDesc As String
    <XmlAttribute(AttributeName:="value")> _
    Public Property Value() As Int32
        Get
            Return m_Value
        End Get
        Set(value As Int32)
            m_Value = value
        End Set
    End Property
    Private m_Value As Int32
End Class