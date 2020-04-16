<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ossaa/SiteOSSAA.Master" CodeBehind="SportsSlowPitchDb.aspx.vb" Inherits="OSSAARankings.SportsSlowPitchDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= Session("sportsSlowPitchContent")%>
    </div>
</asp:Content>


