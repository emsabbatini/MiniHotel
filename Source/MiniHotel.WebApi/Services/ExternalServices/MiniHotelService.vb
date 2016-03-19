Imports Newtonsoft.Json
Imports System.Xml
Imports System.Net
Imports RestSharp
Imports System.Xml.Serialization
Imports System.IO

Public Class MiniHotelService
    Implements IMiniHotelService

    Private ReadOnly ApiHost As String = "http://api.minihotelpms.com/GDS"

    Public Function GetAvailableRaters(ByVal Body As AvailableRaterDTO) As AvailableRatersModel Implements IMiniHotelService.GetAvailableRaters

        'Dim Xml = New XmlDocument
        'Xml.AppendChild(Xml.CreateXmlDeclaration("1.0", "UTF-8", Nothing))

        'Dim AvailRaterqNode = Xml.CreateElement("AvailRaterq")
        'Xml.AppendChild(AvailRaterqNode)

        'Dim AuthenticationNode = Xml.CreateElement("Authentication")
        'AuthenticationNode.Attributes.Append(Xml.CreateAttribute("username")).Value = Body.Username
        'AuthenticationNode.Attributes.Append(Xml.CreateAttribute("password")).Value = Body.Password
        'AvailRaterqNode.AppendChild(AuthenticationNode)

        'Dim HotelNode = Xml.CreateElement("Hotel")
        'HotelNode.Attributes.Append(Xml.CreateAttribute("id")).Value = Body.HotelId
        'HotelNode.Attributes.Append(Xml.CreateAttribute("Currency")).Value = Body.HotelCurrency
        'AvailRaterqNode.AppendChild(HotelNode)

        'Dim DateNode = Xml.CreateElement("DateRange")
        'DateNode.Attributes.Append(Xml.CreateAttribute("from")).Value = Body.DateFrom
        'DateNode.Attributes.Append(Xml.CreateAttribute("to")).Value = Body.DateTo
        'AvailRaterqNode.AppendChild(DateNode)

        'Dim GuestsNode = Xml.CreateElement("Guests")
        'GuestsNode.Attributes.Append(Xml.CreateAttribute("adults")).Value = Body.Adults
        'GuestsNode.Attributes.Append(Xml.CreateAttribute("child")).Value = Body.Child
        'GuestsNode.Attributes.Append(Xml.CreateAttribute("babies")).Value = Body.Babies
        'AvailRaterqNode.AppendChild(GuestsNode)

        'Dim PricesNode = Xml.CreateElement("Prices")
        'PricesNode.Attributes.Append(Xml.CreateAttribute("rateCode")).Value = Body.RateCode
        'AvailRaterqNode.AppendChild(PricesNode)

        'Dim request = New RestRequest("/", Method.POST)
        'request.RequestFormat = DataFormat.Xml
        'request.AddXmlBody(Xml)
        'Dim response = New RestClient(ApiHost).Execute(request)
        'Return JsonConvert.DeserializeObject(Of AvailableRatersModel)(response.Content)

        Dim response As String
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
            response = Client.UploadString(ApiHost, RequestBody)
        End Using

        Return DeserializerResponse(response)

    End Function

    Private Function DeserializerResponse(ByVal Response As String) As AvailableRatersModel

        Dim Deserializer = New XmlSerializer(GetType(AvailableRatersModel))
        Dim Reader = New StringReader(Response)
        Dim Obj = Deserializer.Deserialize(Reader)
        Reader.Close()
        Return DirectCast(Obj, AvailableRatersModel)

    End Function

End Class
