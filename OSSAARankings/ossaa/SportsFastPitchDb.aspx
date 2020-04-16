<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ossaa/SiteOSSAA.Master" CodeBehind="SportsFastPitchDb.aspx.vb" Inherits="OSSAARankings.SportsFastPitchDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= Session("sportsFastPitchContent")%>
    </div>
</asp:Content>


