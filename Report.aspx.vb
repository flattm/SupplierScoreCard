Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WebForms
Imports System.IO
Imports Transaction.DataAccess
Imports System.Diagnostics
Imports Microsoft.Office.Interop

Partial Class Report
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Check for appropriate permissions
        If Not verified() Then
            Response.Redirect("Fail.aspx")
        End If

        If Not IsPostBack Then
            Dim con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("logistics_scorecardConnectionString").ConnectionString)
            Dim scoreDate As String = CType(Session.Item("date"), String)
            scoreDate = scoreDate.Replace("/", "-")
            hfDate.Value = scoreDate
            Dim supID As String = CType(Session.Item("id"), String)
            hfSupID.Value = supID
            Dim name As String = CType(Session.Item("name"), String)
            hfName.Value = name
            con.Open()

            ObjectDataSource1.TypeName = "Reporting.DataTables"
            ObjectDataSource1.SelectMethod = "GetPerformance"
            ObjectDataSource1.SelectParameters.Add(New Parameter("supplierID", TypeCode.Int16, supID))
            ObjectDataSource1.SelectParameters.Add(New Parameter("scoreDate", TypeCode.DateTime, scoreDate))

            ObjectDataSource2.TypeName = "Reporting.DataTables"
            ObjectDataSource2.SelectMethod = "GetSupplier"
            ObjectDataSource2.SelectParameters.Add(New Parameter("supplierID", TypeCode.Int16, supID))

            ObjectDataSource3.TypeName = "Reporting.DataTables"
            ObjectDataSource3.SelectMethod = "GetDates"
            ObjectDataSource3.SelectParameters.Add(New Parameter("supplierID", TypeCode.Int16, supID))

        End If
    End Sub

    'Return to Reporting
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Default.aspx")
    End Sub
    '****************************************************************************************************************************************************************
    'Export to PDF - This button as been disabled - Have not found a way to make this work client side.
    '****************************************************************************************************************************************************************
    'Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
    '    Dim path As String = "C:\Reports\"
    '    Dim name As String = hfName.Value & "_" & hfDate.Value & ".pdf"

    '    If Not Directory.Exists(path) Then
    '        Directory.CreateDirectory(path)
    '    End If

    '    Dim warnings As Warning() = Nothing
    '    Dim streamids As String() = Nothing
    '    Dim mimeType As String = Nothing
    '    Dim encoding As String = Nothing
    '    Dim extension As String = Nothing
    '    Dim bytes As Byte()

    '    bytes = rvPerformance.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings)

    '    Dim fs As New FileStream(path & name, FileMode.Create)
    '    fs.Write(bytes, 0, bytes.Length)
    '    fs.Close()
    '    Response.Redirect(path & name)
    'End Sub
    '****************************************************************************************************************************************************************
    'Export to PDF and open Outlook message - disabled - as far as I know this cant be done without installing outlook on the server
    '****************************************************************************************************************************************************************
    'Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSend.Click
    '    Dim path As String = "C:\Reports\"
    '    Dim name As String = hfName.Value & "_" & hfDate.Value & ".pdf"

    '    If Not Directory.Exists(path) Then
    '        Directory.CreateDirectory(path)
    '    End If

    '    If Not Directory.Exists(path & name) Then

    '        Dim warnings As Warning() = Nothing
    '        Dim streamids As String() = Nothing
    '        Dim mimeType As String = Nothing
    '        Dim encoding As String = Nothing
    '        Dim extension As String = Nothing
    '        Dim bytes As Byte()

    '        bytes = rvPerformance.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings)

    '        Dim fs As New FileStream(path & name, FileMode.Create)
    '        fs.Write(bytes, 0, bytes.Length)
    '        fs.Close()
    '    End If

    '    Dim oApp As Outlook._Application = New Outlook.Application()
    '    Dim oMsg As Outlook._MailItem
    '    oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
    '    oMsg.Subject = "Irwin Seating Supplier Scorecard"
    '    oMsg.Body = "Attached is the supplier"
    '    'Attach Generated PDF
    '    Dim sPath As String = path & name
    '    Dim sDisplay As String = "SupplierScorecard_" & hfDate.Value & ".pdf"
    '    Dim oAttachment As Outlook.Attachments = oMsg.Attachments
    '    Dim oAttach As Outlook.Attachment
    '    oAttach = oAttachment.Add(sPath, , , sDisplay)
    '    oMsg.Display()

    'End Sub
End Class
