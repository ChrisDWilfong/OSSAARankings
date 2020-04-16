<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="WHReportEntry.aspx.vb" Inherits="OSSAARankings.WHReportEntry" %>
<%@ Register src="OfficialInfo.ascx" tagname="OfficialInfo" tagprefix="uc1" %>
<%@ Register src="OfficialWeekGrid.ascx" tagname="OfficialWeekGrid" tagprefix="uc2" %>
<%@ Register src="OfficialEdit.ascx" tagname="OfficialEdit" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:OfficialInfo ID="OfficialInfo1" runat="server" />
    
    <uc3:OfficialEdit ID="OfficialEdit1" runat="server" />
    
</asp:Content>
