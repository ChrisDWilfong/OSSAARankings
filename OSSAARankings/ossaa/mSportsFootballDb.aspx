<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ossaa/mSiteOSSAA.Master" CodeBehind="mSportsFootballDb.aspx.vb" Inherits="OSSAARankings.mSportsFootballDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= Session("sportsFootballContent")%>
    </div>
</asp:Content>


