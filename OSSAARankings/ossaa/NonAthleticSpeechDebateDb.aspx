<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ossaa/SiteOSSAA.Master" CodeBehind="NonAthleticSpeechDebateDb.aspx.vb" Inherits="OSSAARankings.NonAthleticSpeechDebateDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= Session("NASpeechContent")%>
    </div>
</asp:Content>


