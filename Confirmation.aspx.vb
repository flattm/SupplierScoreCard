Imports Transaction.DataAccess

Partial Class AdminConfirmation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not verified() Then
            Response.Redirect("Fail.aspx")
        End If

        Dim location As String = CType(Session.Item("location"), String)
        Dim name As String = CType(Session.Item("name"), String)

        If location = "add" Then
            lblMessage.Text = name & " has successfully been added."
        ElseIf location = "exists" Then
            lblMessage.Text = name & " already exists."
        ElseIf location = "notchanged" Then
            lblMessage.Text = "You need to actually change the name."
        ElseIf location = "remove" Then
            lblMessage.Text = name & " has successfully been removed."
        ElseIf location = "edit" Then
            Dim oldName As String = CType(Session.Item("oldName"), String)
            lblMessage.Text = oldName & " has been successfully changed to " & name & "."
        ElseIf location = "score" Then
            lblMessage.Text = "You have successfully added perfomance ratings for " & name & "."
        ElseIf location = "editentry" Then
            lblMessage.Text = "The entry for " & name & " has been updated."
        ElseIf location = "hasdata" Then
            lblMessage.Text = "There is already an entry for the Supplier and Date.  To view / edit the data go to the Administration Page."
        Else
            lblMessage.Text = "Somthing stange has happened. Please contact support."
        End If

    End Sub
End Class
