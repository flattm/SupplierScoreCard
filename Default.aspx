<%@ Page Title="Supplier Scorecard - Reporting" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Reporting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style9
        {
            width: 110px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>
    Supplier Reporting</h3>
    <br />
    <div>
        <table class="style2">
            <tr>
                <td class="style9">
                    Select a Supplier:
                </td>
                <td>
                    <asp:DropDownList ID="ddlSupplier" runat="server" DataSourceID="SupplierDataSource"
                        DataTextField="supplierName" DataValueField="supplierName" AutoPostBack="True"
                        Width="255px" AppendDataBoundItems="true">
                        <asp:ListItem Text="Select..." Value="" />
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        </div>
        <asp:Panel ID="panReport" runat="server" Visible="False" Enabled="False">
            <asp:GridView ID="gvReporting" runat="server" CellPadding="5" 
                ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True" 
                AutoGenerateColumns="False" DataSourceID="ReportingDataSource" 
                PageSize="12" Font-Size="X-Small">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" 
                        DataFormatString="{0:MM/yy}" />
                    <asp:BoundField DataField="total" HeaderText="Total Product" 
                        SortExpression="total" />
                    <asp:BoundField DataField="totalIn" HeaderText="Total Inbound Product" 
                        SortExpression="totalIn" />
                    <asp:BoundField DataField="totalOut" HeaderText="Total Outbound Product" 
                        SortExpression="totalOut" />
                    <asp:BoundField DataField="inOT" HeaderText="Inbound Product On Time" 
                        SortExpression="inOT" />
                    <asp:BoundField DataField="outOT" HeaderText="Outbound Product On Time" 
                        SortExpression="outOT" />
                    <asp:BoundField DataField="damaged" HeaderText="Damaged Product" 
                        SortExpression="damaged" />
                    <asp:BoundField DataField="lost" HeaderText="Lost Product" 
                        SortExpression="lost" />
                    <asp:BoundField DataField="serviceRT" 
                        HeaderText="Cust. Service Response Time" SortExpression="serviceRT" />
                    <asp:BoundField DataField="quoteRT" HeaderText="Rate Quote Response Time" 
                        SortExpression="quoteRT" />
                    <asp:BoundField DataField="invoiceIssues" HeaderText="Invoicing Issues" 
                        SortExpression="invoiceIssues" />
                    <asp:BoundField DataField="distFeedback" 
                        HeaderText="Distribution Dept. Feedback" SortExpression="distFeedback" />
                    <asp:BoundField DataField="rates" HeaderText="Competitive Rates" 
                        SortExpression="rates" />
                    <asp:BoundField DataField="contImprove" 
                        HeaderText="Continuous Improvement Efforts" SortExpression="contImprove" />
                    <asp:BoundField DataField="overallPercent" HeaderText="Overall Percent" 
                        SortExpression="overallPercent" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="False" ForeColor="White" Font-Size="Medium" />
                <HeaderStyle BackColor="#4b6c9e" Font-Bold="False" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </asp:Panel>

        <asp:Panel ID="panLabel" runat="server" Visible="False" Enabled="False">
            No data has been found.&nbsp; Either there is no data for the current supplier, or 
            the connection ot the database has failed.<br /> If the problem persists please 
            contact support.</asp:Panel>
        <div>
        <asp:SqlDataSource ID="SupplierDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:logistics_scorecardConnectionString %>"
            SelectCommand="SELECT [supplierName] FROM [Suppliers] WHERE active = 1 ORDER BY [supplierName]">
        </asp:SqlDataSource>
            <asp:SqlDataSource ID="ReportingDataSource" runat="server" 
                ConnectionString="<%$ ConnectionStrings:logistics_scorecardConnectionString %>" 
                SelectCommand="SELECT [date], [total], [totalIn], [totalOut], [inOT], [outOT], [damaged], [lost], [serviceRT], [quoteRT], [invoiceIssues], [distFeedback], [rates], [contImprove], [overallPercent] FROM [performance] WHERE ([supplierID] = @supplierID) ORDER BY [date] DESC">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hfID" Name="supplierID" PropertyName="Value" 
                        Type="Int16" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:HiddenField ID="hfID" runat="server" />
        </div>
</asp:Content>

