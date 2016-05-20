Imports System.Xml
Imports System.Net
Imports System.Xml.Serialization
Imports System.IO

Public Class MiniHotelPMSService
    Implements IMiniHotelPMSService

    Private ReadOnly ApiHostAvailableRaters As String = "http://api.minihotelpms.com/GDS"
    Private ReadOnly ApiHostReservations As String = " https://ssl3.motel-soft.com/miniviewer/reservations/web_reservations_query_service.aspx"

    Public Function GetAvailableRaters(ByVal Body As AvailableRaterDTO) As MiniHotelPMSModel(Of AvailableRatersModel) Implements IMiniHotelPMSService.GetAvailableRaters
        Dim Response As String
        Dim RequestBody = "<?xml version='1.0' encoding='UTF-8' ?>" + _
                        "<AvailRaterq xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>" + _
                        "<Authentication username='test' password='2222' />" + _
                        "<Hotel id='testhotel' Currency='USD' />" + _
                        "<DateRange from='" + Body.DateFrom.ToString("yyyy-MM-dd") + "' to='" + Body.DateTo.ToString("yyyy-MM-dd") + "' />" + _
                        "<Guests adults='2' child='0' babies='0' />" + _
                        "<Prices rateCode='*ALL'>" + _
                        "</Prices>" + _
                        "</AvailRaterq>"

        Using Client As New WebClient
            Response = Client.UploadString(ApiHostAvailableRaters, RequestBody)
        End Using

        Return ProcessResponse(Of AvailableRatersModel)(Response)

    End Function

    Public Function GetReservations(ByVal Body As ReservationDTO) As MiniHotelPMSModel(Of ReservationsRSModel) Implements IMiniHotelPMSService.GetReservations

        Dim Response As String

        Dim arrivalFrom As String = String.Empty
        Dim arrivalTo As String = String.Empty
        Dim departureFrom As String = String.Empty
        Dim departureTo As String = String.Empty

        If (Not IsNothing(Body.ArrivalDateFrom)) Then
            arrivalFrom = CDate(Body.ArrivalDateFrom).ToString("yyyy-MM-dd")
        End If

        If (Not IsNothing(Body.ArrivalDateTo)) Then
            arrivalTo = CDate(Body.ArrivalDateTo).ToString("yyyy-MM-dd")
        End If

        If (Not IsNothing(Body.DepartureDateFrom)) Then
            departureFrom = CDate(Body.DepartureDateFrom).ToString("yyyy-MM-dd")
        End If

        If (Not IsNothing(Body.DepartureDateTo)) Then
            departureTo = CDate(Body.DepartureDateTo).ToString("yyyy-MM-dd")
        End If

        Dim RequestBody = "<?xml version='1.0' encoding='UTF-8' ?>" + _
                        "<ReservationsRQ>" + _
                        "<Authentication username='test' password='2222' />" + _
                        "<Hotel id='demo2' />" + _
                        "<CreateDate From='' To='' />" + _
                        "<ArrivalDate From='" + arrivalFrom + "' To='" + arrivalTo + "' />" + _
                        "<DepartureDate From='" + departureFrom + "' To='" + departureTo + "' />" + _
                        "</ReservationsRQ>"

        Using Client As New WebClient
            Response = Client.UploadString(ApiHostReservations, RequestBody)
        End Using

        Return ProcessResponse(Of ReservationsRSModel)(Response)

    End Function

    Private Function ProcessResponse(Of T)(ByVal Response As String) As MiniHotelPMSModel(Of T)

        Dim MiniHotelResponse As New MiniHotelPMSModel(Of T)

        If String.Equals(Response.Substring(0, 3), "ERR") Then
            MiniHotelResponse.HasError = True
            MiniHotelResponse.ErrorMessage = Response
        Else
            MiniHotelResponse.HasError = False
            MiniHotelResponse.DataObject = DeserializerResponse(Of T)(Response)
        End If

        Return MiniHotelResponse

    End Function

    Private Function DeserializerResponse(Of T)(ByVal Response As String) As T

        Dim Deserializer = New XmlSerializer(GetType(T))
        Dim Reader = New StringReader(Response)
        Dim Obj = Deserializer.Deserialize(Reader)
        Reader.Close()
        Return DirectCast(Obj, T)

    End Function

End Class
