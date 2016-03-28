Imports Newtonsoft.Json
Imports System.Xml
Imports System.Net
Imports RestSharp
Imports System.Xml.Serialization
Imports System.IO

Public Class MiniHotelPMSService
    Implements IMiniHotelPMSService

    Private ReadOnly ApiHost As String = "http://api.minihotelpms.com/GDS"

    Public Function GetAvailableRaters(ByVal Body As AvailableRaterDTO) As MiniHotelPMSModel(Of AvailableRatersModel) Implements IMiniHotelPMSService.GetAvailableRaters
        Dim Response As String
        Dim RequestBody = "<?xml version='1.0' encoding='UTF-8' ?>" + _
                        "<AvailRaterq xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>" + _
                        "<Authentication username='test' password='2222' />" + _
                        "<Hotel id='testhotel' Currency='USD' />" + _
                        "<DateRange from='" + Body.DateFrom + "' to='" + Body.DateTo + "' />" + _
                        "<Guests adults='2' child='0' babies='0' />" + _
                        "<Prices rateCode='*ALL'>" + _
                        "</Prices>" + _
                        "</AvailRaterq>"

        Using Client As New WebClient
            Response = Client.UploadString(ApiHost, RequestBody)
        End Using

        Return ProcessResponse(Of AvailableRatersModel)(Response)

    End Function

    Public Function GetReservations(ByVal Body As ReservationDTO) As MiniHotelPMSModel(Of ReservationsRSModel) Implements IMiniHotelPMSService.GetReservations

        Dim Response As String
        Dim RequestBody = "<?xml version='1.0' encoding='UTF-8' ?>" + _
                        "<ReservationsRQ>" + _
                        "<Authentication username='test' password='2222' />" + _
                        "<Hotel id='testhotel' />" + _
                        "<CreateDate From='" + Body.CreateDateFrom + "' To='" + Body.CreateDateTo + "' />" + _
                        "<ArrivalDate From='" + Body.ArrivalFrom + "' To='" + Body.ArrivalTo + "' />" + _
                        "<DepartureDate From='" + Body.DepartureFrom + "' To='" + Body.DepartureTo + "' />" + _
                        "</ReservationsRQ>"

        Using Client As New WebClient
            Response = Client.UploadString(ApiHost, RequestBody)
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
