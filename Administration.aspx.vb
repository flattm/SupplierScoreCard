Imports Transaction.DataAccess

Partial Class Styles_Administration
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not verified() Then
            Response.Redirect("Fail.aspx")
        End If
    End Sub

    Protected Sub btnSuppliers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSuppliers.Click
        Response.Redirect("Supplier.aspx")
    End Sub

    Protected Sub btnData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnData.Click
        Response.Redirect("Data.aspx")
    End Sub
End Class
