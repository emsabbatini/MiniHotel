Imports System.Xml.Serialization

<XmlRoot(ElementName:="Meals")> _
Public Class MealsModel
    <XmlAttribute(AttributeName:="Arrangment")> _
    Public Property Arrangment() As String
        Get
            Return m_Arrangment
        End Get
        Set(value As String)
            m_Arrangment = value
        End Set
    End Property
    Private m_Arrangment As String
End Class
