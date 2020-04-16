<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pitchCount.aspx.vb" Inherits="OSSAARankings.pitchCount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Rankings (Pitch Count)</title>
</head>
<body style="background-color:LightGray;">
    <form id="form1" runat="server">
    <div style="font-family:Verdana;font-size:small;">
        <asp:Label ID="lblHeader" runat="server" Text="SPRING BASEBALL PITCH COUNT - OSSAARankings.com" Font-Bold="true" ForeColor="Maroon" Font-Size="X-Large"></asp:Label><br /><br />
        <asp:Label ID="lblHeader1" runat="server" Text="Select Team : " Font-Bold="true" ForeColor="Maroon" Font-Size="Medium"></asp:Label>
        <asp:DropDownList ID="cboTeams" runat="server" Font-Size="Medium" Width="200px" DataTextField="strDisplay" DataValueField="teamID" BackColor="LightYellow" DataSourceID="SqlDataSource1" AutoPostBack="true">
        </asp:DropDownList><br />
        <asp:Label ID="Label4" runat="server" Text="NOTE : Only teams that have entered pitch counts will be available to select." Font-Italic="true" Font-Size="Small" Visible="false"></asp:Label><br /><br />
        <asp:Label runat="server" Text="<u>TOTAL PITCH COUNTS - Player - # Pitches (Games)</u>" Font-Bold="true" ForeColor="Maroon"></asp:Label><br />
        <%= Session("pitchCountTotals")%>
        <br /><asp:Label ID="Label1" runat="server" Text="<u>PITCH COUNT DETAILS</u>" Font-Bold="true" ForeColor="Maroon"></asp:Label><br />
        <%= Session("pitchCountDetails")%>
    </div>
    </form>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT [strDisplay], [teamID] FROM [viewSpringBaseballTeams] WHERE intRecords > 0 ORDER BY [SchoolName]">
    </asp:SqlDataSource>
</body>
</html>
