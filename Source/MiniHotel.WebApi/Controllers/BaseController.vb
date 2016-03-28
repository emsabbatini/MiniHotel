Imports System.Net
Imports System.Web.Http

Public Class BaseController
    Inherits ApiController

    Protected Function WrapOk(Of T)(Content As T) As IHttpActionResult
        Return Ok(New ResponseOkDTO(Of T)() With {.Data = Content})
    End Function

End Class
