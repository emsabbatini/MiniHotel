Imports System.Xml.Serialization

<XmlRoot(ElementName:="Inventory")> _
Public Class InventoryModel
    <XmlAttribute(AttributeName:="Allocation")> _
    Public Property Allocation() As Int32
        Get
            Return m_Allocation
        End Get
        Set(value As Int32)
            m_Allocation = value
        End Set
    End Property
    Private m_Allocation As Int32
    <XmlAttribute(AttributeName:="maxavail")> _
    Public Property Maxavail() As Int32
        Get
            Return m_Maxavail
        End Get
        Set(value As Int32)
            m_Maxavail = value
        End Set
    End Property
    Private m_Maxavail As Int32
End Class
