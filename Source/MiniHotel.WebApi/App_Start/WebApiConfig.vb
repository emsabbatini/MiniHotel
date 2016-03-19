﻿Imports System.Linq
Imports System.Net.Http.Formatting
Imports System.Web.Http
Imports System.Web.Http.Cors

Public Class WebApiConfig
    Public Shared Sub Register(ByVal config As HttpConfiguration)

        config.EnableCors(New EnableCorsAttribute("*", "*", "*"))

        config.Routes.MapHttpRoute( _
                    name:="DefaultApi", _
                    routeTemplate:="api/{controller}/{id}", _
                    defaults:=New With {.id = RouteParameter.Optional} _
                )

    End Sub
End Class