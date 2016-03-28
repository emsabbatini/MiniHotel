Public Class MiniHotelPMSModel(Of T)
    Public Property DataObject() As T
        Get
            Return m_DataObject
        End Get
        Set(value As T)
            m_DataObject = value
        End Set
    End Property
    Private m_DataObject As T
    Public Property HasError() As Boolean
        Get
            Return m_HasError
        End Get
        Set(value As Boolean)
            m_HasError = value
        End Set
    End Property
    Private m_HasError As Boolean
    Public Property ErrorMessage() As String
        Get
            Return m_ErrorMessage
        End Get
        Set(value As String)
            m_ErrorMessage = value
        End Set
    End Property
    Private m_ErrorMessage As String
End Class
