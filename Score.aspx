<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="Score.aspx.vb" Inherits="Grade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style7
        {
            width: 60px;
        }
        .style8
        {
            width: 80px;
        }
        .style9
        {
            width: 110px;
        }
        .style10
        {
            width: 65px;
        }
        .style11
        {
            width: 35px;
        }
        .style12
        {
            height: 21px;
        }
        .style13
        {
            width: 200px;
        }
        .style14
        {
            height: 21px;
            width: 200px;
        }
        .style18
        {
            height: 21px;
            width: 85px;
        }
        .style19
        {
            width: 190px;
        }
        .style20
        {
            height: 21px;
            width: 190px;
        }
        .style22
        {
            width: 271px;
        }
        .style25
        {
            width: 50px;
        }
        .style26
        {
            width: 130px;
        }
        .style27
        {
            width: 40px;
        }
        .style29
        {
            width: 85px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h3>
        <asp:Label ID="lblTitle" runat="server" Text="Supplier Performance"></asp:Label>
    </h3>
    <br />
    <div>
        <asp:Panel ID="panSupplier" runat="server" Visible="True" Enabled="True">
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
        </asp:Panel>
        <br />
        <asp:Panel ID="panData" runat="server" Visible="False" Enabled="False">
            Plese enter the month and year of the current scorecard:
            <table class="style2">
                <tr>
                    <td class="style25">
                        Month:
                    </td>
                    <td class="style26">
                        <asp:DropDownList ID="ddlMonth" runat="server" Width="90px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="01">January</asp:ListItem>
                            <asp:ListItem Value="02">February</asp:ListItem>
                            <asp:ListItem Value="03">March</asp:ListItem>
                            <asp:ListItem Value="04">April</asp:ListItem>
                            <asp:ListItem Value="05">May</asp:ListItem>
                            <asp:ListItem Value="06">June</asp:ListItem>
                            <asp:ListItem Value="07">July</asp:ListItem>
                            <asp:ListItem Value="08">August</asp:ListItem>
                            <asp:ListItem Value="09">September</asp:ListItem>
                            <asp:ListItem Value="10">October</asp:ListItem>
                            <asp:ListItem Value="11">November</asp:ListItem>
                            <asp:ListItem Value="12">December</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style27">
                        Year:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlYear" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <h5>
                Deliveries - On Time (40% of Total Weight)</h5>
            <table class="style2">
                <tr>
                    <td class="style3" colspan="2">
                        Inbound:
                    </td>
                    <td class="style5" colspan="2">
                        Outbound:
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        Total:
                    </td>
                    <td class="style8">
                        <asp:TextBox ID="txtInTotal" runat="server" Width="40px" MaxLength="5"></asp:TextBox>
                    </td>
                    <td class="style7">
                        &nbsp;Total:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOutTotal" runat="server" Width="40px" MaxLength="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        On Time:
                    </td>
                    <td class="style8">
                        <asp:TextBox ID="txtInOT" runat="server" Width="40px" MaxLength="5"></asp:TextBox>
                    </td>
                    <td class="style7">
                        On Time:
                    </td>
                    <td>
                        <asp:TextBox ID="txtOutOT" runat="server" Width="40px" MaxLength="5"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <h5>
                Deliveries - Overall (30% of Total Weight)</h5>
            <table class="style2">
                <tr>
                    <td class="style10">
                        Damaged:
                    </td>
                    <td class="style8">
                        <asp:TextBox ID="txtDamaged" runat="server" Width="40px" MaxLength="5"></asp:TextBox>
                    </td>
                    <td class="style11">
                        Lost:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLost" runat="server" Width="40px" MaxLength="5"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <h5>
                Customer Service (15% of Total Weight)</h5>
            <h6>
                Based on a 0 to 5 rating scale</h6>
            <table class="style2">
                <tr>
                    <td class="style19">
                        Customer Service Response Time:
                    </td>
                    <td class="style29">
                        <asp:DropDownList ID="ddlCustResponse" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style13">
                        Invoicing Issues:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlInvoicing" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style20">
                        Rate Quote Response Time:
                    </td>
                    <td class="style18">
                        <asp:DropDownList ID="ddlRateResponse" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style14">
                        Distribution Department Feedback:
                    </td>
                    <td class="style12">
                        <asp:DropDownList ID="ddlDistFeedback" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <h5>
                Cost Savings (15% of Total Weight)</h5>
            <table class="style2">
                <tr>
                    <td class="style9">
                        Competitive Rates:
                    </td>
                    <td class="style29">
                        <asp:DropDownList ID="ddlCompRates" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style22">
                        Demonstrated Continuous Improvement Efforts:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlContImprovement" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <br />
            <asp:ValidationSummary ID="vsScore" runat="server" ValidationGroup="valScore" HeaderText="Please correct the following issue(s):"
                Font-Bold="True" />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100px" 
                ValidationGroup="valScore" />
            <asp:Button ID="btnBack" runat="server" Text="Cancel" Width="60px" />
        </asp:Panel>
    </div>
    <div>
        <asp:SqlDataSource ID="SupplierDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:logistics_scorecardConnectionString %>"
            SelectCommand="SELECT [supplierName] FROM [Suppliers] WHERE active = 1 ORDER BY [supplierName]">
        </asp:SqlDataSource>
        <asp:HiddenField ID="hfDate" runat="server" Value="-1" />
        <asp:HiddenField ID="hfEdit" runat="server" Value="-1" />
        <asp:HiddenField ID="hfID" runat="server" Value="-1" />
        <asp:RequiredFieldValidator ID="rfvMonth" runat="server" ControlToValidate="ddlMonth"
            Display="None" ErrorMessage="Select a Moth." ValidationGroup="valScore"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvYear" runat="server" ControlToValidate="ddlYear"
            Display="None" ErrorMessage="Select a Year," ValidationGroup="valScore"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvInTotal" runat="server" ControlToValidate="txtInTotal"
            Display="None" ErrorMessage="Enter Total Inbound Deliveries." ValidationGroup="valScore"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvInOT" runat="server" ControlToValidate="txtInOT"
            Display="None" ErrorMessage="Enter On Time Inbound Deliveries." ValidationGroup="valScore"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvOutTotal" runat="server" ControlToValidate="txtOutTotal"
            Display="None" ErrorMessage="Enter Total Outbound Deliveries." ValidationGroup="valScore"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvOutOT" runat="server" ControlToValidate="txtOutOT"
            Display="None" ErrorMessage="Enter On Time Outbound Deliveries." ValidationGroup="valScore"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvDamaged" runat="server" ControlToValidate="txtDamaged"
            Display="None" ErrorMessage="Enter Total Damaged Packages." ValidationGroup="valScore"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvLost" runat="server" ControlToValidate="txtLost"
            Display="None" ErrorMessage="Enter Total Lost Packages." ValidationGroup="valScore"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvCustResponse" runat="server" ControlToValidate="ddlCustResponse"
            Display="None" ErrorMessage="Select Customer Service Response Time Rating." ValidationGroup="valScore"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvRateResponse" runat="server" ControlToValidate="ddlRateResponse"
            Display="None" ErrorMessage="Select Rate Quote Response Time Rating." ValidationGroup="valScore"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvInvoicing" runat="server" ControlToValidate="ddlInvoicing"
            Display="None" ErrorMessage="Select Invoicing Issues Rating." ValidationGroup="valScore"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvDistFeedback" runat="server" ControlToValidate="ddlDistFeedback"
            Display="None" ErrorMessage="Select Distribution Department Feedback Rating."
            ValidationGroup="valScore"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvCompRates" runat="server" ControlToValidate="ddlCompRates"
            Display="None" ErrorMessage="Select Competitive Rates Rating." ValidationGroup="valScore"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvContImprovement" runat="server" ControlToValidate="ddlContImprovement"
            Display="None" ErrorMessage="Select Continuous Improvement Efforts Rating." ValidationGroup="valScore"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="rvInTotal" runat="server" ControlToValidate="txtInTotal"
            Display="None" ErrorMessage="Inbound Total must be a number between 0 and 30,000."
            MaximumValue="30000" MinimumValue="0" ValidationGroup="valScore" Type="Integer"></asp:RangeValidator>
        <asp:RangeValidator ID="rvInOT" runat="server" ControlToValidate="txtInOT" Display="None"
            ErrorMessage="Inbound On Time must be a number between 0 and 30,000." MaximumValue="30000"
            MinimumValue="0" ValidationGroup="valScore" Type="Integer"></asp:RangeValidator>
        <asp:RangeValidator ID="rvOutTotal" runat="server" ControlToValidate="txtOutTotal"
            Display="None" ErrorMessage="Outbound Total must be a number between 0 and 30,000."
            MaximumValue="30000" MinimumValue="0" ValidationGroup="valScore" Type="Integer"></asp:RangeValidator>
        <asp:RangeValidator ID="rvOutOT" runat="server" Display="None" ErrorMessage="Outbound On Time must be a number between 0 and 30,000."
            ValidationGroup="valScore" ControlToValidate="txtOutOT" MaximumValue="30000"
            MinimumValue="0" Type="Integer"></asp:RangeValidator>
        <asp:RangeValidator ID="rvDamaged" runat="server" Display="None" ErrorMessage="Damaged Packages must be a number between 0 and 30,000."
            ValidationGroup="valScore" ControlToValidate="txtDamaged" MaximumValue="30000"
            MinimumValue="0" Type="Integer"></asp:RangeValidator>
        <asp:RangeValidator ID="rvLost" runat="server" Display="None" ErrorMessage="Lost Packages must be a number between 0 and 30,000."
            ValidationGroup="valScore" ControlToValidate="txtLost" MaximumValue="30000" MinimumValue="0"
            Type="Integer"></asp:RangeValidator>
    </div>
</asp:Content>
