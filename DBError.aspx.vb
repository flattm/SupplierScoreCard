
Partial Class DBError
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ex As Exception = CType(Session("error"), Exception)
        lblError.Text = ex.ToString
    End Sub
End Class
