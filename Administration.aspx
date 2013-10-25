<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Administration.aspx.vb" Inherits="Styles_Administration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>
        Administrative Tasks</h3>
        <br />
        <div>
            <asp:Button ID="btnSuppliers" runat="server" Text="Edit Suppliers" 
                Width="120px" />
        </div>
        <br />
        <div>
            <asp:Button ID="btnData" runat="server" Text="Edit Data" Width="120px" />
        </div>
    </asp:Content>

