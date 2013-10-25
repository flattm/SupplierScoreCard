<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="Supplier.aspx.vb" Inherits="RemoveSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 100px;
        }
        .style5
        {
        }
        .style7
        {
            width: 270px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h3>
        What would you like to do?</h3>
    <br />
    <div>
        <asp:RadioButtonList ID="rblSupplier" runat="server" AutoPostBack="True">
            <asp:ListItem>Add Supplier</asp:ListItem>
            <asp:ListItem>Remove Supplier</asp:ListItem>
            <asp:ListItem>Edit Supplier</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div visible="False">
        <asp:Panel ID="panAddSupplier" runat="server" Visible="False" Enabled="False">
            <h4>
                Add a Supplier</h4>
            <table class="style1">
                <tr>
                    <td class="style2">
                        Supplier Name:
                    </td>
                    <td class="style7">
                        <asp:TextBox ID="txtAddSup" runat="server" MaxLength="30" Width="250px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvAddSup" runat="server" ControlToValidate="txtAddSup"
                            ErrorMessage="Enter a supplier." Font-Bold="True" ForeColor="#666666"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="revAddSup" runat="server" 
                            ControlToValidate="txtAddSup" ErrorMessage="Only use letters and numbers." 
                            Font-Bold="True" ForeColor="#666666" ValidationExpression="[a-zA-Z0-9 ]*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;
                    </td>
                    <td colspan="2">
                        <asp:Button ID="dtnAdd" runat="server" Font-Bold="False" ForeColor="Black" Text="Add"
                            Width="80px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="panRemoveSupplier" runat="server" Visible="False" Enabled="False">
            <h4>
                Remove a Supplier</h4>
            <table class="style1">
                <tr>
                    <td class="style2">
                        Select Supplier:
                    </td>
                    <td class="style7">
                        <asp:DropDownList ID="ddlRemoveSup" runat="server" DataSourceID="sdsSupplier" DataTextField="supplierName"
                            DataValueField="supplierName" Width="255px" AppendDataBoundItems="true">
                            <asp:ListItem Text="Select..." Value="" />
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvRemoveSup" runat="server" ControlToValidate="ddlRemoveSup"
                            ErrorMessage="Select a supplier." Font-Bold="True" ForeColor="#666666"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnRemove" runat="server" Text="Remove" Width="80px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="panEditSupplier" runat="server" Visible="False" Enabled="False">
            <h4>
                Edit a Supplier</h4>
            <table class="style1">
                <tr>
                    <td class="style2">
                        Select Supplier:
                    </td>
                    <td class="style7">
                        <asp:DropDownList ID="ddlEditSup" runat="server" AutoPostBack="True" 
                            Width="255px" DataSourceID="sdsSupplier" DataTextField="supplierName" 
                            DataValueField="supplierName" AppendDataBoundItems="true">
                            <asp:ListItem Text="Select..." Value="" />
                        </asp:DropDownList>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="lblEditName" runat="server" Text="Update Name:" Visible="False"></asp:Label>
                    </td>
                    <td class="style7">
                        <asp:TextBox ID="txtUpdateSup" runat="server" Visible="False" Width="250px" 
                            MaxLength="30"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEditSup" runat="server" 
                            ControlToValidate="txtUpdateSup" ErrorMessage="Enter new name." 
                            Font-Bold="True" ForeColor="#666666"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="revEditSup" runat="server" 
                            ControlToValidate="txtUpdateSup" ErrorMessage="Only use letters and numbers." 
                            Font-Bold="True" ForeColor="#666666" 
                            ValidationExpression="[a-zA-Z0-9 ' , .]*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="False" 
                            Width="80px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <asp:SqlDataSource ID="sdsSupplier" runat="server" ConnectionString="<%$ ConnectionStrings:logistics_scorecardConnectionString %>"
        SelectCommand="SELECT [supplierName] FROM [Suppliers] WHERE active = 1 ORDER BY [supplierName]">
    </asp:SqlDataSource>
</asp:Content>
