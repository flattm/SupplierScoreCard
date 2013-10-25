Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
'************************************************************************************************************************************************************************
'These are used to populate the datatables used to create the dynamic report
'************************************************************************************************************************************************************************
Namespace Reporting
    Public Class DataTables
        '****************************************************************************************************************************************************************
        'Get the connection string from the web.congif
        '****************************************************************************************************************************************************************
        Private Shared Function GetConnectionString() As String
            Return ConfigurationManager.ConnectionStrings("[...]ConnectionString").ConnectionString
        End Function
        '****************************************************************************************************************************************************************
        Public Shared Function GetPerformance(ByVal supplierID As Integer, ByVal scoreDate As Date) As DataTable
            Dim sel As String = "SELECT * FROM Performance " _
                                & "WHERE supplierID = @supplierID AND date = @date"
            Dim con As New SqlConnection(GetConnectionString)
            Dim cmd As SqlCommand = New SqlCommand(sel, con)
            Dim ds As New DataTable
            cmd.Parameters.AddWithValue("supplierID", supplierID)
            cmd.Parameters.AddWithValue("date", scoreDate)
            Try
                con.Open()
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
                adapter.Fill(ds)
                con.Close()
                Return ds
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '****************************************************************************************************************************************************************
        Public Shared Function GetDates(ByVal supplierID As Integer) As DataTable
            Dim sel As String = "SELECT TOP 12 date, overallPercent FROM Performance " _
                                & "WHERE supplierID = @supplierID " _
                                & "ORDER BY date DESC"
            Dim con As New SqlConnection(GetConnectionString)
            Dim cmd As SqlCommand = New SqlCommand(sel, con)
            Dim ds As New DataTable
            cmd.Parameters.AddWithValue("supplierID", supplierID)
            Try
                con.Open()
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
                adapter.Fill(ds)
                con.Close()
                Return ds
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '****************************************************************************************************************************************************************
        Public Shared Function GetSupplier(ByVal supplierID As Integer) As DataTable
            Dim sel As String = "SELECT supplierName FROM Suppliers " _
                                & "WHERE supplierID = @supplierID"
            Dim con As New SqlConnection(GetConnectionString)
            Dim cmd As SqlCommand = New SqlCommand(sel, con)
            Dim ds As New DataTable
            cmd.Parameters.AddWithValue("supplierID", supplierID)
            Try
                con.Open()
                Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
                adapter.Fill(ds)
                con.Close()
                Return ds
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '****************************************************************************************************************************************************************
        'Public Shared Function GetSuppliers(ByVal supplierID As Integer) As DataTable
        '    Dim sel As String = "SELECT * FROM Suppliers " _
        '                        & "WHERE supplierID = @supplierID"
        '    Dim con As New SqlConnection(GetConnectionString)
        '    Dim cmd As SqlCommand = New SqlCommand(sel, con)
        '    Dim ds As New DataTable
        '    cmd.Parameters.AddWithValue("supplierID", supplierID)
        '    Try
        '        con.Open()
        '        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
        '        adapter.Fill(ds)
        '        con.Close()
        '        Return ds
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function
        '****************************************************************************************************************************************************************
        'Public Shared Function GetData(ByVal queryString As String, ByVal supplierID As Integer) As DataSet
        '    Dim con As New SqlConnection(GetConnectionString)
        '    Dim ds As New DataSet()
        '    Dim adapter As New SqlDataAdapter(queryString, con)
        '    adapter.Fill(ds)
        '    Return ds
        'End Function
        '****************************************************************************************************************************************************************
    End Class
End Namespace

