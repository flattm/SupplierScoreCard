Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Principal

Namespace Transaction
    <DataObject(True)> _
    Public Class DataAccess
        '****************************************************************************************************************************************************************
        'Only members of the LogScoreCard security group will have access
        'This is added to the page_load event of each page
        '****************************************************************************************************************************************************************
        Public Shared Function verified() As Boolean
            Dim user As New ApplicationServices.User
            Return user.IsInRole("[...]")
        End Function
        '****************************************************************************************************************************************************************
        'Gets the connection string from the web.config
        '****************************************************************************************************************************************************************
        Private Shared Function GetConnectionString() As String
            Return ConfigurationManager.ConnectionStrings("[...]ConnectionString").ConnectionString
        End Function
        '****************************************************************************************************************************************************************
        'Adds a new supplier
        '****************************************************************************************************************************************************************
        <DataObjectMethod(DataObjectMethodType.Insert)> _
        Public Shared Sub InsertSupplier(ByVal supplierName As String)
            Dim con As New SqlConnection(GetConnectionString)
            Dim ins As String = "INSERT INTO Suppliers " _
                                & "(supplierName)" _
                                & "VALUES (@supplierName)"
            Dim cmd As New SqlCommand(ins, con)
            cmd.Parameters.AddWithValue("supplierName", supplierName)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Sub
        '****************************************************************************************************************************************************************
        'Removes a supplier - Sets active to false rather than deleating the record from the database
        'Active flag -- 1 = True (Active); 0 = Flase (Inactive)
        '****************************************************************************************************************************************************************
        <DataObjectMethod(DataObjectMethodType.Update)> _
        Public Shared Function RmvSupplier(ByVal supplierName As String) As Integer
            Dim con As New SqlConnection(GetConnectionString)
            Dim upd As String = "UPDATE Suppliers " _
                                & "SET active = @active " _
                                & "WHERE supplierName = @supplierName"
            Dim cmd As New SqlCommand(upd, con)
            cmd.Parameters.AddWithValue("active", 0)
            cmd.Parameters.AddWithValue("supplierName", supplierName)
            con.Open()
            Dim i As Integer = cmd.ExecuteNonQuery()
            con.Close()
            Return i
        End Function
        '****************************************************************************************************************************************************************
        'Re-add a supplier - Will set a supplier that was previously removed back to active
        'Active flag -- 1 = True (Active); 0 = Flase (Inactive)
        '****************************************************************************************************************************************************************
        <DataObjectMethod(DataObjectMethodType.Update)> _
        Public Shared Function UpdateActive(ByVal supplierName As String) As Integer
            Dim con As New SqlConnection(GetConnectionString)
            Dim upd As String = "UPDATE Suppliers " _
                                & "SET active = @active " _
                                & "WHERE supplierName = @supplierName"
            Dim cmd As New SqlCommand(upd, con)
            cmd.Parameters.AddWithValue("active", 1)
            cmd.Parameters.AddWithValue("supplierName", supplierName)
            con.Open()
            Dim i As Integer = cmd.ExecuteNonQuery()
            con.Close()
            Return i
        End Function
        '****************************************************************************************************************************************************************
        'Update a supplier (Change the suppliers name)
        '****************************************************************************************************************************************************************
        <DataObjectMethod(DataObjectMethodType.Update)> _
        Public Shared Sub UpdSupplier(ByVal newName As String, ByVal supplierName As String)
            Dim con As New SqlConnection(GetConnectionString)
            Dim upd As String = "UPDATE Suppliers " _
                                & "SET supplierName = @newName " _
                                & "WHERE supplierName = @supplierName "
            Dim cmd As New SqlCommand(upd, con)
            cmd.Parameters.AddWithValue("newName", newName)
            cmd.Parameters.AddWithValue("supplierName", supplierName)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Sub
        '****************************************************************************************************************************************************************
        'Used to see if a supplier already exists to prevent duplicates.
        '****************************************************************************************************************************************************************
        <DataObjectMethod(DataObjectMethodType.Select)> _
        Public Shared Function GetSupplier(ByVal supplierName As String) As IEnumerable
            Dim con As New SqlConnection(GetConnectionString)
            Dim sel As String = "SELECT supplierName " _
                                & "FROM Suppliers " _
                                & "WHERE supplierName = @supplierName " _
                                & "AND active = 1"
            Dim cmd As New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("supplierName", supplierName)
            con.Open()
            Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return rdr
        End Function
        '****************************************************************************************************************************************************************
        'Used to see if a data entry already exists to prevent errors.
        '****************************************************************************************************************************************************************
        <DataObjectMethod(DataObjectMethodType.Select)> _
        Public Shared Function CheckKey(ByVal supplierID As Integer, ByVal scoreDate As Date) As IEnumerable
            Dim con As New SqlConnection(GetConnectionString)
            Dim sel As String = "SELECT * " _
                                & "FROM performance " _
                                & "WHERE supplierID = @supplierID " _
                                & "AND date = @date"
            Dim cmd As New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("supplierID", supplierID)
            cmd.Parameters.AddWithValue("date", scoreDate)
            con.Open()
            Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return rdr
        End Function
        '****************************************************************************************************************************************************************
        'Checks suppliers table to see if a user is trying to add a supplier that was previously deleated
        '****************************************************************************************************************************************************************
        <DataObjectMethod(DataObjectMethodType.Select)> _
        Public Shared Function DeleatedSupplier(ByVal supplierName As String) As IEnumerable
            Dim con As New SqlConnection(GetConnectionString)
            Dim sel As String = "SELECT supplierName " _
                                & "FROM Suppliers " _
                                & "WHERE supplierName = @supplierName " _
                                & "AND active = 0"
            Dim cmd As New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("supplierName", supplierName)
            con.Open()
            Dim rdr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Return rdr
        End Function
        '****************************************************************************************************************************************************************
        'Used to populate the controls when editing an entry
        '****************************************************************************************************************************************************************
        <DataObjectMethod(DataObjectMethodType.Select)> _
        Public Shared Function EditSupplier(ByVal supplierID As Integer, ByVal scoreDate As Date) As DataTable
            Dim con As New SqlConnection(GetConnectionString)
            Dim sel As String = "SELECT * " _
                                & "FROM Performance " _
                                & "WHERE supplierID = @supplierID " _
                                & "AND date = @date"
            Dim cmd As New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("supplierID", supplierID)
            cmd.Parameters.AddWithValue("date", scoreDate)
            con.Open()
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            adapter.Fill(dt)
            Return dt
        End Function
        '****************************************************************************************************************************************************************
        'Updates a performance rating
        '****************************************************************************************************************************************************************
        <DataObjectMethod(DataObjectMethodType.Update)> _
        Public Shared Function UpdatePerformance(ByVal supplierID As Integer, ByVal scoreDate As Date, ByVal total As Integer,
                                  ByVal totalIn As Integer, ByVal totalOut As Integer, ByVal inOT As Integer,
                                  ByVal outOT As Integer, ByVal damaged As Integer, ByVal lost As Integer,
                                  ByVal serviceRT As Integer, ByVal quoteRT As Integer, ByVal invoiceIssues As Integer,
                                  ByVal distFeedback As Integer, ByVal rates As Integer, ByVal contImprove As Integer,
                                  ByVal overallPercent As Integer) As Integer
            Dim con As New SqlConnection(GetConnectionString)
            Dim upd As String = "UPDATE Performance " _
                                & "SET total = @total, totalIn = @totalIn, " _
                                & "totalOut = @totalOut, inOT = @inOT, outOT = @outOT, damaged = @damaged, lost = @lost, " _
                                & "serviceRT = @serviceRT, quoteRT = @quoteRT, invoiceIssues = @invoiceIssues, " _
                                & "distFeedback = @distFeedback, rates = @rates, contImprove = @contImprove, " _
                                & "overallPercent = @overallPercent " _
                                & "WHERE supplierID = @supplierID AND date = @date"
            Dim cmd As New SqlCommand(upd, con)
            cmd.Parameters.AddWithValue("supplierID", supplierID)
            cmd.Parameters.AddWithValue("date", scoreDate)
            cmd.Parameters.AddWithValue("total", total)
            cmd.Parameters.AddWithValue("totalIn", totalIn)
            cmd.Parameters.AddWithValue("totalOut", totalOut)
            cmd.Parameters.AddWithValue("inOT", inOT)
            cmd.Parameters.AddWithValue("outOT", outOT)
            cmd.Parameters.AddWithValue("damaged", damaged)
            cmd.Parameters.AddWithValue("lost", lost)
            cmd.Parameters.AddWithValue("serviceRT", serviceRT)
            cmd.Parameters.AddWithValue("quoteRT", quoteRT)
            cmd.Parameters.AddWithValue("invoiceIssues", invoiceIssues)
            cmd.Parameters.AddWithValue("distFeedback", distFeedback)
            cmd.Parameters.AddWithValue("rates", rates)
            cmd.Parameters.AddWithValue("contImprove", contImprove)
            cmd.Parameters.AddWithValue("overallPercent", overallPercent)
            con.Open()
            Dim i As Integer = cmd.ExecuteNonQuery()
            con.Close()
            Return i
        End Function
        '****************************************************************************************************************************************************************
        'SCORE Insert Statement
        '****************************************************************************************************************************************************************
        <DataObjectMethod(DataObjectMethodType.Insert)> _
        Public Shared Sub InsertScore(ByVal supplierID As Integer, ByVal scoreDate As String, ByVal total As Integer,
                                  ByVal totalIn As Integer, ByVal totalOut As Integer, ByVal inOT As Integer,
                                  ByVal outOT As Integer, ByVal damaged As Integer, ByVal lost As Integer,
                                  ByVal serviceRT As Integer, ByVal quoteRT As Integer, ByVal invoiceIssues As Integer,
                                  ByVal distFeedback As Integer, ByVal rates As Integer, ByVal contImprove As Integer,
                                  ByVal overallPercent As Integer)
            Dim con As New SqlConnection(GetConnectionString)
            Dim ins As String = "INSERT INTO Performance " _
                                & "(supplierID, date, total, totalIn, totalOut, inOT, outOT, damaged, lost, serviceRT, " _
                                & "quoteRT, invoiceIssues, distFeedback, rates, contImprove, overallPercent)" _
                                & "VALUES (@supplierID, @date, @total, @totalIn, @totalOut, @inOT, @outOT, @damaged, @lost, " _
                                & "@serviceRT, @quoteRT, @invoiceIssues, @distFeedback, @rates, @contImprove, @overallPercent)"
            Dim cmd As New SqlCommand(ins, con)
            cmd.Parameters.AddWithValue("supplierID", supplierID)
            cmd.Parameters.AddWithValue("date", scoreDate)
            cmd.Parameters.AddWithValue("total", total)
            cmd.Parameters.AddWithValue("totalIn", totalIn)
            cmd.Parameters.AddWithValue("totalOut", totalOut)
            cmd.Parameters.AddWithValue("inOT", inOT)
            cmd.Parameters.AddWithValue("outOT", outOT)
            cmd.Parameters.AddWithValue("damaged", damaged)
            cmd.Parameters.AddWithValue("lost", lost)
            cmd.Parameters.AddWithValue("serviceRT", serviceRT)
            cmd.Parameters.AddWithValue("quoteRT", quoteRT)
            cmd.Parameters.AddWithValue("invoiceIssues", invoiceIssues)
            cmd.Parameters.AddWithValue("distFeedback", distFeedback)
            cmd.Parameters.AddWithValue("rates", rates)
            cmd.Parameters.AddWithValue("contImprove", contImprove)
            cmd.Parameters.AddWithValue("overallPercent", overallPercent)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Sub
        '****************************************************************************************************************************************************************
        'Get supplier ID from name - used to add ID into performance table when only the name is available (from a dropdownlist)
        '****************************************************************************************************************************************************************
        <DataObjectMethod(DataObjectMethodType.Select)> _
        Public Shared Function GetSupplierID(ByVal supplierName As String) As Integer
            Dim con As New SqlConnection(GetConnectionString)
            Dim sel As String = "SELECT supplierID " _
                                & "FROM Suppliers " _
                                & "WHERE supplierName = @supplierName"
            Dim cmd As New SqlCommand(sel, con)
            cmd.Parameters.AddWithValue("supplierName", supplierName)
            con.Open()
            Dim ID = cmd.ExecuteScalar()
            Return ID
        End Function

        '****************************************************************************************************************************************************************
        'The following functions will calculate the weighted average
        '****************************************************************************************************************************************************************
        Public Shared Function CalcPercentage(ByVal totalIn As Integer, ByVal totalOut As Integer, ByVal inOT As Integer,
                                      ByVal outOT As Integer, ByVal damaged As Integer, ByVal lost As Integer,
                                      ByVal serviceRT As Integer, ByVal quoteRT As Integer, ByVal invoiceIssues As Integer,
                                      ByVal distFeedback As Integer, ByVal rates As Integer, ByVal contImprove As Integer) As Integer
            Dim ans As Decimal
            ans = CalcOnTime(totalIn, totalOut, inOT, outOT) +
                  CalcDamLost(totalIn, totalOut, damaged, lost) +
                  CalcCustServ(serviceRT, quoteRT, invoiceIssues, distFeedback) +
                  CalcCost(rates, contImprove)
            Return CType(Math.Round(ans, 0), Integer)
        End Function
        '****************************************************************************************************************************************************************
        Public Shared Function CalcOnTime(ByVal totalIn As Integer, ByVal totalOut As Integer, ByVal inOT As Integer, ByVal outOT As Integer) As Integer
            Dim ans As Decimal
            If totalIn = 0 Then
                ans = (50 + (((outOT / totalOut) * 100) * 0.5)) * 0.4
            ElseIf totalOut = 0 Then
                ans = ((((inOT / totalIn) * 100) * 0.5) + 50) * 0.4
            Else
                ans = ((((inOT / totalIn) * 100) * 0.5) + (((outOT / totalOut) * 100) * 0.5)) * 0.4
            End If
            Return CType(Math.Round(ans, 0), Integer)
        End Function
        '****************************************************************************************************************************************************************
        Public Shared Function CalcDamLost(ByVal totalIn As Integer, ByVal totalOut As Integer, ByVal damaged As Integer, ByVal lost As Integer) As Integer
            Dim total As Integer = totalIn + totalOut
            Dim ans As Decimal
            ans = (((((total - damaged) / total) * 100) * 0.5) + ((((total - lost) / total) * 100) * 0.5)) * 0.3
            Return CType(Math.Round(ans, 0), Integer)
        End Function
        '****************************************************************************************************************************************************************
        Public Shared Function CalcCustServ(ByVal serviceRT As Integer, ByVal quoteRT As Integer, ByVal invoiceIssues As Integer, ByVal distFeedback As Integer) As Integer
            Dim ans As Decimal
            ans = ((((serviceRT / 5) * 100) * 0.4) + (((quoteRT / 5) * 100) * 0.1) + (((invoiceIssues / 5) * 100) * 0.1) + (((distFeedback / 5) * 100) * 0.4)) * 0.15
            Return CType(Math.Round(ans, 0), Integer)
        End Function
        '****************************************************************************************************************************************************************
        Public Shared Function CalcCost(ByVal rates As Integer, ByVal contImprove As Integer) As Integer
            Dim ans As Decimal
            ans = ((((rates / 5) * 100) * 0.75) + (((contImprove / 5) * 100) * 0.25)) * 0.15
            Return CType(Math.Round(ans, 0), Integer)
        End Function
        '****************************************************************************************************************************************************************
    End Class
End Namespace
