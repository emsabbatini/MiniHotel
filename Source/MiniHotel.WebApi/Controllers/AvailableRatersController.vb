Imports System.Net
Imports System.Net.Http
Imports System.Web
Imports System.Web.Http
Imports System.Web.Http.Cors

Namespace MiniHotel.WebApi

    Public Class AvailableRatersController
        Inherits ApiController

        Private _MiniHotelService As IMiniHotelService

        Sub New()
            If _MiniHotelService Is Nothing Then
                _MiniHotelService = New MiniHotelService
            End If
        End Sub

        <HttpPost()>
        Public Function GetAvailableRaters(ByVal Body As AvailableRaterDTO) As AvailableRatersModel

            Return _MiniHotelService.GetAvailableRaters(Body)

        End Function


    End Class
End Namespace