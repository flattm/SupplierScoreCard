Imports Transaction.DataAccess

Partial Class RemoveSupplier
    Inherits System.Web.UI.Page
    '****************************************************************************************************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Authentication
        If Not verified() Then
            Response.Redirect("Fail.aspx")
        End If

        If Not IsPostBack Then
            rblSupplier.SelectedIndex = -1
        End If
    End Sub
    '****************************************************************************************************************************************************************
    'Activate / deactivate pannels depending on what radio button is selected
    '****************************************************************************************************************************************************************
    Protected Sub rblSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblSupplier.SelectedIndexChanged
        If rblSupplier.SelectedIndex = 0 Then
            panAddSupplier.Visible = True
            panAddSupplier.Enabled = True
            panRemoveSupplier.Visible = False
            panRemoveSupplier.Enabled = False
            panEditSupplier.Visible = False
            panEditSupplier.Enabled = False
        ElseIf rblSupplier.SelectedIndex = 1 Then
            panAddSupplier.Visible = False
            panAddSupplier.Enabled = False
            panRemoveSupplier.Visible = True
            panRemoveSupplier.Enabled = True
            panEditSupplier.Visible = False
            panEditSupplier.Enabled = False
        ElseIf rblSupplier.SelectedIndex = 2 Then
            panAddSupplier.Visible = False
            panAddSupplier.Enabled = False
            panRemoveSupplier.Visible = False
            panRemoveSupplier.Enabled = False
            panEditSupplier.Visible = True
            panEditSupplier.Enabled = True
        End If
    End Sub
    '****************************************************************************************************************************************************************
    Protected Sub ddlEditSup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEditSup.SelectedIndexChanged
        lblEditName.Visible = True
        txtUpdateSup.Visible = True
        btnUpdate.Visible = True
    End Sub
    '****************************************************************************************************************************************************************
    'If Supplier does not already exist add, if the supplier was previously deleated it will change flag to active
    '****************************************************************************************************************************************************************
    Protected Sub dtnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtnAdd.Click
        Dim supName As String = Trim(txtAddSup.Text)
        Try
            If (Not Exists(supName)) Then
                If (Not Deleated(supName)) Then
                    InsertSupplier(supName)
                Else
                    UpdateActive(supName)
                End If
                Session("location") = "add"
                Session("name") = supName
                Response.Redirect("Confirmation.aspx")
            Else
                Session("location") = "exists"
                Session("name") = supName
                Response.Redirect("Confirmation.aspx")
            End If
        Catch ex As Exception
            If ex.Message.ToString.StartsWith("Thread") Then
                Session("location") = "exists"
                Session("name") = supName
                Response.Redirect("Confirmation.aspx")
            Else
                Session("error") = ex
                Response.Redirect("DBError.aspx")
            End If
        End Try
    End Sub
    '****************************************************************************************************************************************************************
    'Change supplier flag to inactive
    '****************************************************************************************************************************************************************
    Protected Sub btnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            RmvSupplier(ddlRemoveSup.SelectedValue)
        Catch ex As Exception
            Session("error") = ex
            Response.Redirect("DBError.aspx")
        End Try
        Session("location") = "remove"
        Session("name") = ddlRemoveSup.SelectedValue
        Response.Redirect("Confirmation.aspx")
    End Sub
    '****************************************************************************************************************************************************************
    'Change the name of a supplier
    '****************************************************************************************************************************************************************
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim supName As String = Trim(txtUpdateSup.Text)
        Try
            If (Not Exists(supName)) Then
                UpdSupplier(txtUpdateSup.Text, ddlEditSup.SelectedValue)
                Session("location") = "edit"
                Session("name") = txtUpdateSup.Text
                Session("oldName") = ddlEditSup.SelectedValue
                Response.Redirect("Confirmation.aspx")
            Else
                Session("location") = "notchanged"
                Session("name") = supName
                Response.Redirect("Confirmation.aspx")
            End If
        Catch ex As Exception
            If ex.Message.ToString.StartsWith("Thread") Then
                Session("location") = "notchanged"
                Session("name") = supName
                Response.Redirect("Confirmation.aspx")
            Else
                Session("error") = ex
                Response.Redirect("DBError.aspx")
            End If
        End Try
    End Sub
    '****************************************************************************************************************************************************************
    'Check to see if a supplier already exists
    '****************************************************************************************************************************************************************'****************************************************************************************************************************************************************
    Protected Function Exists(ByRef supplierName As String) As Boolean
        Dim result As IEnumerable = GetSupplier(supplierName)
        Dim count As Integer = 0
        For Each item In result
            count += 1
        Next
        If count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    '****************************************************************************************************************************************************************
    'Check to see if a suppleir was previously deleated
    '****************************************************************************************************************************************************************
    Protected Function Deleated(ByRef supplierName As String) As Boolean
        Dim result As IEnumerable = DeleatedSupplier(supplierName)
        Dim count As Integer = 0
        For Each item In result
            count += 1
        Next
        If count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

End Class
