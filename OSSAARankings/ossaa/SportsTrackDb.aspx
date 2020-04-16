<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ossaa/SiteOSSAA.Master" CodeBehind="SportsTrackDb.aspx.vb" Inherits="OSSAARankings.SportsTrackDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= Session("sportsTrackContent")%>
    </div>
</asp:Content>


