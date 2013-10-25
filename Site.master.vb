
Partial Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim page = System.IO.Path.GetFileName(Request.Url.ToString()).Replace(".aspx", String.Empty)
            If page = "Administration" Then
                lblPageHeader.Text = "Perform Administrative Tasks"
            ElseIf page = "Default" Then
                lblPageHeader.Text = "Reporting"
            ElseIf page = "Grade" Then
                lblPageHeader.Text = "Update Supplier Ratings"
            ElseIf page = "Reporting" Then
                lblPageHeader.Text = "View Historical Data"
            ElseIf page = "Score" Then
                lblPageHeader.Text = "Score Performance"
            ElseIf page = "Data" Then
                lblPageHeader.Text = "Edit Data"
            ElseIf page = "Supplier" Then
                lblPageHeader.Text = "Supplier Administration"
            Else
                lblPageHeader.Text = ""
            End If
        End If
    End Sub
End Class

