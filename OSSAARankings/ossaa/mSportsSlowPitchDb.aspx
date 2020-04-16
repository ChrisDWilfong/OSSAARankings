<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ossaa/mSiteOSSAA.Master" CodeBehind="mSportsSlowPitchDb.aspx.vb" Inherits="OSSAARankings.mSportsSlowPitchDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= Session("sportsSlowPitchContent")%>
    </div>
</asp:Content>


