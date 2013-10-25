Imports Transaction.DataAccess

Partial Class ErrorPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not verified() Then
            Response.Redirect("Fail.aspx")
        End If
    End Sub
End Class
