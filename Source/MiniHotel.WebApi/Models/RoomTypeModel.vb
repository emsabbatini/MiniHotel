Imports System.Xml.Serialization

<XmlRoot(ElementName:="RoomType")> _
Public Class RoomTypeModel
    <XmlAttribute(AttributeName:="id")> _
    Public Property ID() As String
        Get
            Return m_ID
        End Get
        Set(value As String)
            m_ID = value
        End Set
    End Property
    Private m_ID As String
    <XmlAttribute(AttributeName:="Name_h")> _
    Public Property Name_H() As String
        Get
            Return m_Name_H
        End Get
        Set(value As String)
            m_Name_H = value
        End Set
    End Property
    Private m_Name_H As String
    <XmlAttribute(AttributeName:="Name_e")> _
    Public Property Name_E() As String
        Get
            Return m_Name_E
        End Get
        Set(value As String)
            m_Name_E = value
        End Set
    End Property
    Private m_Name_E As String
    <XmlElement(ElementName:="Inventory")> _
    Public Property Inventory() As InventoryModel
        Get
            Return m_Inventory
        End Get
        Set(value As InventoryModel)
            m_Inventory = value
        End Set
    End Property
    Private m_Inventory As InventoryModel
    <XmlElement(ElementName:="price")> _
    Public Property Price() As List(Of PriceModel)
        Get
            Return m_Price
        End Get
        Set(value As List(Of PriceModel))
            m_Price = value
        End Set
    End Property
    Private m_Price As List(Of PriceModel)
End Class
