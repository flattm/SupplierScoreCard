<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="ErrorPage.aspx.vb" Inherits="ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h3>
An Error Has Occured</h3>
<div>
<asp:Label ID="lblMessage" runat="server">Contact support for assistamce.  Please be prepared to provide as much detial as possible about what you were doing prior to this error.</asp:Label>

</div>
</asp:Content>

