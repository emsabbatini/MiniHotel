Imports System.Net
Imports System.Net.Http
Imports System.Web
Imports System.Web.Http
Imports System.Web.Http.Cors
Imports System.Web.Routing

Namespace MiniHotel.WebApi

    Public Class MiniHotelPMSController
        Inherits BaseController

        Private _MiniHotelService As IMiniHotelPMSService

        Sub New()
            If _MiniHotelService Is Nothing Then
                _MiniHotelService = New MiniHotelPMSService
            End If
        End Sub

        <HttpPost()>
        Public Function AvailableRaters(ByVal Body As AvailableRaterDTO) As IHttpActionResult

            Return WrapOk(_MiniHotelService.GetAvailableRaters(Body))

        End Function

        <HttpPost()>
        Public Function Reservations(ByVal Body As ReservationDTO) As IHttpActionResult
            Return WrapOk(_MiniHotelService.GetReservations(Body))
        End Function


    End Class
End Namespace