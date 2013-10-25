Imports Transaction.DataAccess
Imports System.Data

Partial Class Grade
    Inherits System.Web.UI.Page
    '****************************************************************************************************************************************************************
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'First check for appropriate privelages
        If Not verified() Then
            Response.Redirect("Fail.aspx")
        End If

        If Not (IsPostBack) Then

            Dim isEdit As Boolean = CType(Session("edit"), Boolean)
            Session("edit") = False
            'If session edit is has the value "edit" it will set the score page to update a score rather than add a new score
            If isEdit Then
                'Pull in the keys
                Dim supID As Integer = CType(Session("id"), Integer)
                hfID.Value = supID
                Dim scoreDate As Date = CType(Session("date"), Date)
                hfDate.Value = scoreDate
                'Flag to UPDATE rather than INSERT
                hfEdit.Value = 1
                'Rename page title
                lblTitle.Text = "Edit Supplier Performance"
                'Enable the correct panel and disable unused controls
                panData.Enabled = True
                panData.Visible = True
                panSupplier.Visible = False
                panSupplier.Enabled = False
                ddlMonth.Enabled = False
                ddlYear.Enabled = False
                rfvMonth.Enabled = False
                rfvYear.Enabled = False


                'Populate a datatable with the existing values
                Dim dt As DataTable = New DataTable
                Try
                    dt = EditSupplier(supID, scoreDate)
                Catch ex As Exception
                    Session("error") = ex
                    Response.Redirect("DBError.aspx")
                End Try
                'Populate the controls with the existing values
                txtInTotal.Text = dt.Rows(0).Item("totalIn")
                txtOutTotal.Text = dt.Rows(0).Item("totalOut")
                txtInOT.Text = dt.Rows(0).Item("inOT")
                txtOutOT.Text = dt.Rows(0).Item("outOT")
                txtDamaged.Text = dt.Rows(0).Item("damaged")
                txtLost.Text = dt.Rows(0).Item("lost")
                ddlCustResponse.SelectedValue = dt.Rows(0).Item("serviceRT")
                ddlRateResponse.SelectedValue = dt.Rows(0).Item("quoteRT")
                ddlInvoicing.SelectedValue = dt.Rows(0).Item("invoiceIssues")
                ddlDistFeedback.SelectedValue = dt.Rows(0).Item("distFeedback")
                ddlCompRates.SelectedValue = dt.Rows(0).Item("rates")
                ddlContImprovement.SelectedValue = dt.Rows(0).Item("contImprove")
            Else
                'Setup page for adding a new score
                ddlYear.Items.Add("")
                Dim scoreDate As String = CType(Today, String)
                Dim year As Integer = CType(scoreDate.Substring(scoreDate.Length - 4), Integer)
                ddlYear.Items.Add(year)
                ddlYear.Items.Add(year - 1)
            End If
        End If
    End Sub
    '****************************************************************************************************************************************************************
    Protected Sub ddlSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSupplier.SelectedIndexChanged
        If Not ddlSupplier.SelectedIndex = 0 Then
            panData.Visible = True
            panData.Enabled = True
        Else
            panData.Visible = False
            panData.Enabled = False
        End If
    End Sub
    '****************************************************************************************************************************************************************
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        'Set initial values
        Dim total As Integer = CType(txtInTotal.Text, Integer) + CType(txtOutTotal.Text, Integer)
        Dim totalIn As Integer = txtInTotal.Text
        Dim totalOut As Integer = txtOutTotal.Text
        Dim inOT As Integer = txtInOT.Text
        Dim outOT As Integer = txtOutOT.Text
        Dim damaged As Integer = txtDamaged.Text
        Dim lost As Integer = txtLost.Text
        'Validate to make sure there are no typos / user errors
        If inOT > totalIn Then
            txtInOT.BackColor = Drawing.Color.Yellow
            txtInOT.Focus()
        ElseIf outOT > totalOut Then
            txtInOT.BackColor = Drawing.Color.White
            txtOutOT.BackColor = Drawing.Color.Yellow
            txtOutOT.Focus()
        ElseIf damaged > total Then
            txtOutOT.BackColor = Drawing.Color.White
            txtDamaged.BackColor = Drawing.Color.Yellow
            txtDamaged.Focus()
        ElseIf lost > total Then
            txtDamaged.BackColor = Drawing.Color.White
            txtLost.BackColor = Drawing.Color.Yellow
            txtLost.Focus()
        Else
            'Set remaining control values
            Dim serviceRT As Integer = ddlCustResponse.SelectedValue
            Dim quoteRT As Integer = ddlRateResponse.SelectedValue
            Dim invoiceIssues As Integer = ddlInvoicing.SelectedValue
            Dim distFeedback As Integer = ddlDistFeedback.SelectedValue
            Dim rates As Integer = ddlCompRates.SelectedValue
            Dim contImprove As Integer = ddlContImprovement.SelectedValue
            'Calcualte overall percent value
            Dim overallPercent As Integer = -1
            overallPercent = CalcPercentage(totalIn, totalOut, inOT, outOT, damaged, lost, serviceRT, quoteRT, invoiceIssues, distFeedback, rates, contImprove)
            'INSERT the data
            If hfEdit.Value = 1 Then
                'Get the keys from the hidden values that were set on the page_load
                Dim supplierID As Integer = CType(hfID.Value, Integer)
                Dim combinedDate As Date = CType(hfDate.Value, Date)
                'Update the specified entry
                Try
                    UpdatePerformance(supplierID, combinedDate, total, totalIn, totalOut, inOT, outOT, damaged, lost,
                                      serviceRT, quoteRT, invoiceIssues, distFeedback, rates, contImprove, overallPercent)
                Catch ex As Exception
                    Session("error") = ex
                    Response.Redirect("DBError.aspx")
                End Try

                Session("name") = CType(Session("name"), String)
                Session("location") = "editentry"
                hfEdit.Value = -1
                Response.Redirect("Confirmation.aspx")
            Else
                'Set new compund key
                Dim supplierID As Integer = GetSupplierID(ddlSupplier.SelectedValue)
                Dim combinedDate As Date = ddlMonth.SelectedValue & "/" & ddlYear.SelectedValue
                'Insert new entry
                Try
                    If Not Exists(supplierID, combinedDate) Then
                        InsertScore(supplierID, combinedDate, total, totalIn, totalOut, inOT, outOT, damaged, lost,
                                    serviceRT, quoteRT, invoiceIssues, distFeedback, rates, contImprove, overallPercent)
                    Else
                        Session("location") = "hasdata"
                        Response.Redirect("Confirmation.aspx")
                    End If
                Catch ex As Exception
                    Session("error") = ex
                    If ex.Message.ToString.StartsWith("Thread") Then
                        Session("location") = "hasdata"
                        Response.Redirect("Confirmation.aspx")
                    Else
                        Response.Redirect("DBError.aspx")
                    End If
                End Try
                'Save values for custom response page
                Session("name") = ddlSupplier.SelectedValue
                Session("location") = "score"
                Response.Redirect("Confirmation.aspx")
            End If
        End If
    End Sub
    '****************************************************************************************************************************************************************
    'This will check to prevent a key constraint error
    '****************************************************************************************************************************************************************
    Protected Function Exists(ByVal supplierID As Integer, ByVal scoreDate As Date) As Boolean
        Dim res As IEnumerable = CheckKey(supplierID, scoreDate)
        Dim count As Integer = 0
        For Each Item In res
            count += 1
        Next
        If count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    '****************************************************************************************************************************************************************
    'Return to data admin without making changes
    '****************************************************************************************************************************************************************
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Data.aspx")
    End Sub
    '****************************************************************************************************************************************************************
End Class
