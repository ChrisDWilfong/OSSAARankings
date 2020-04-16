<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ossaa/mSiteOSSAA.Master" CodeBehind="mNonAthleticSpeechDebateDb.aspx.vb" Inherits="OSSAARankings.mNonAthleticSpeechDebateDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= Session("NASpeechContent")%>
    </div>
</asp:Content>


