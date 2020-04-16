<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ossaa/mSiteOSSAA.Master" CodeBehind="mSportsVolleyballDb.aspx.vb" Inherits="OSSAARankings.mSportsVolleyballDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= Session("sportsVolleyballContent")%>
    </div>
</asp:Content>


