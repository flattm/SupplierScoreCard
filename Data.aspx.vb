Imports Transaction.DataAccess
Imports System.Data

Partial Class Reporting
    Inherits System.Web.UI.Page
    '****************************************************************************************************************************************************************
    Protected Sub ddlSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSupplier.SelectedIndexChanged
        Try
            hfID.Value = GetSupplierID(ddlSupplier.SelectedValue)
            panReport.Visible = True
            panReport.Enabled = True
        Catch ex As Exception
            Session("error") = ex
            Response.Redirect("DBError.aspx")
        End Try
    End Sub
    '****************************************************************************************************************************************************************
    Protected Sub gvReporting_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvReporting.SelectedIndexChanged
        Session("date") = gvReporting.SelectedRow.Cells(1).Text.Substring(0, 2) & "/01/" & gvReporting.SelectedRow.Cells(1).Text.Substring(3)
        Session("id") = GetSupplierID(ddlSupplier.SelectedValue)
        Session("edit") = True
        Session("name") = ddlSupplier.SelectedValue
        Response.Redirect("Score.aspx")
    End Sub
    '****************************************************************************************************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Check for appropriate permissions
        If Not verified() Then
            Response.Redirect("Fail.aspx")
        End If
    End Sub
End Class
