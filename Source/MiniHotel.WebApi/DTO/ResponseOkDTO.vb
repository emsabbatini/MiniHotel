Public Class ResponseOkDTO(Of T)
    Public Property Data() As T
        Get
            Return m_Data
        End Get
        Set(value As T)
            m_Data = value
        End Set
    End Property
    Private m_Data As T
End Class
