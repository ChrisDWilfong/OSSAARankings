<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ossaa/SiteOSSAA.Master" CodeBehind="SportsCheerDb.aspx.vb" Inherits="OSSAARankings.SportsCheerDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= Session("sportsCheerContent")%>
    </div>
</asp:Content>


