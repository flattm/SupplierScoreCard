<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Report.aspx.vb" Inherits="Report" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header" align="center">
    <h1>
    Supplier Scorecard Report</h1>
    </div>
    <div align="center">

        <asp:Button ID="btnExport" runat="server" Text="Export To PDF" Width="175px" 
            Enabled="False" Visible="False" />

        <asp:Button ID="btnSend" runat="server" Text="Send To Supplier" Width="175px" 
            Enabled="False" Visible="False" />

        <asp:Button ID="btnBack" runat="server" Text="Return To Reporting" 
            Width="175px" />

    </div>
    <br />
    <div align="center">
        <rsweb:ReportViewer ID="rvPerformance" runat="server" BorderStyle="Solid" 
            Font-Names="Verdana" Font-Size="8pt" Height="8.5in" 
            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" 
            WaitMessageFont-Size="14pt" Width="11in" ShowRefreshButton="False">
            <LocalReport ReportPath="Report.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="Performance" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="Suppliers" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="Dates" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
            SelectMethod="GetData" TypeName="DataSetTableAdapters.DatesTableAdapter">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetData" TypeName="DataSetTableAdapters.SuppliersTableAdapter">
            <InsertParameters>
                <asp:Parameter Name="supplierName" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            DeleteMethod="Delete" InsertMethod="Insert" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
            TypeName="DataSetTableAdapters.PerformanceTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_supplierID" Type="Int16" />
                <asp:Parameter Name="Original_date" Type="DateTime" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="supplierID" Type="Int16" />
                <asp:Parameter Name="_date" Type="DateTime" />
                <asp:Parameter Name="total" Type="Int16" />
                <asp:Parameter Name="totalIn" Type="Int16" />
                <asp:Parameter Name="totalOut" Type="Int16" />
                <asp:Parameter Name="inOT" Type="Int16" />
                <asp:Parameter Name="outOT" Type="Int16" />
                <asp:Parameter Name="damaged" Type="Int16" />
                <asp:Parameter Name="lost" Type="Int16" />
                <asp:Parameter Name="serviceRT" Type="Byte" />
                <asp:Parameter Name="quoteRT" Type="Byte" />
                <asp:Parameter Name="invoiceIssues" Type="Byte" />
                <asp:Parameter Name="distFeedback" Type="Byte" />
                <asp:Parameter Name="rates" Type="Byte" />
                <asp:Parameter Name="contImprove" Type="Byte" />
                <asp:Parameter Name="overallPercent" Type="Byte" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="total" Type="Int16" />
                <asp:Parameter Name="totalIn" Type="Int16" />
                <asp:Parameter Name="totalOut" Type="Int16" />
                <asp:Parameter Name="inOT" Type="Int16" />
                <asp:Parameter Name="outOT" Type="Int16" />
                <asp:Parameter Name="damaged" Type="Int16" />
                <asp:Parameter Name="lost" Type="Int16" />
                <asp:Parameter Name="serviceRT" Type="Byte" />
                <asp:Parameter Name="quoteRT" Type="Byte" />
                <asp:Parameter Name="invoiceIssues" Type="Byte" />
                <asp:Parameter Name="distFeedback" Type="Byte" />
                <asp:Parameter Name="rates" Type="Byte" />
                <asp:Parameter Name="contImprove" Type="Byte" />
                <asp:Parameter Name="overallPercent" Type="Byte" />
                <asp:Parameter Name="Original_supplierID" Type="Int16" />
                <asp:Parameter Name="Original_date" Type="DateTime" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    
        <asp:HiddenField ID="hfSupID" runat="server" />
        <asp:HiddenField ID="hfDate" runat="server" />
        <asp:HiddenField ID="hfName" runat="server" />
    
    </div>
    </form>
</body>
</html>
