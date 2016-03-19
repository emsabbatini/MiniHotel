Imports System.Web
Imports System.Web.Http
Imports System.Web.Mvc

Public Class MvcApplication
    Inherits HttpApplication

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()

        WebApiConfig.Register(GlobalConfiguration.Configuration)
    End Sub
End Class
