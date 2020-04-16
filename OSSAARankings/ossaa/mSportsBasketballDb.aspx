<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ossaa/mSiteOSSAA.Master" CodeBehind="mSportsBasketballDb.aspx.vb" Inherits="OSSAARankings.mSportsBasketballDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= Session("sportsBasketballContent")%>
    </div>
</asp:Content>


