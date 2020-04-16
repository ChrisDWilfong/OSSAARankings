<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ossaa/mSiteOSSAA.Master" CodeBehind="mSportsSoccerDb.aspx.vb" Inherits="OSSAARankings.mSportsSoccerDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= Session("sportsSoccerContent")%>
    </div>
</asp:Content>


