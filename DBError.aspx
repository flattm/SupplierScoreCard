<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="DBError.aspx.vb" Inherits="DBError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h3>An error has occured between the application and the database</h3>
<p>Contact support for assistance.</p>
<br />
<div>
    <asp:Label ID="lblError" runat="server"></asp:Label>
</div>
</asp:Content>