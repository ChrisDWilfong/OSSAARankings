﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ossaa/mSiteOSSAA.Master" CodeBehind="mNonAthleticMusicDb.aspx.vb" Inherits="OSSAARankings.mNonAthleticMusicDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= Session("NAMusicContent")%>
    </div>
</asp:Content>


