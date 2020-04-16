<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ossaa/SiteOSSAA.Master" CodeBehind="EligibilityDb.aspx.vb" Inherits="OSSAARankings.EligibilityDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= Session("EligibilityContent")%>
    </div>
</asp:Content>


