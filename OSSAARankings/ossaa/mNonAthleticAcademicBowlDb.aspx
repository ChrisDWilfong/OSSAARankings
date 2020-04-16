<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ossaa/mSiteOSSAA.Master" CodeBehind="mNonAthleticAcademicBowlDb.aspx.vb" Inherits="OSSAARankings.mNonAthleticAcademicBowlDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= Session("NAAcademicBowlContent")%>
    </div>
</asp:Content>


