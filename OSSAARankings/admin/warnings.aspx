<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="warnings.aspx.vb" Inherits="OSSAARankings.warnings" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataKeyNames="Id" Font-Names="Verdana" Font-Size="8pt" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="gameDate" HeaderText="gameDate" 
                    SortExpression="gameDate" />
                <asp:BoundField DataField="sportID" HeaderText="sportID" 
                    SortExpression="sportID" />
                <asp:BoundField DataField="schoolName" HeaderText="schoolName" 
                    SortExpression="schoolName" />
                <asp:BoundField DataField="osportID" HeaderText="osportID" 
                    SortExpression="osportID" />
                <asp:BoundField DataField="oschoolName" HeaderText="oschoolName" 
                    SortExpression="oschoolName" />
                <asp:BoundField DataField="warningLevel" HeaderText="warningLevel" 
                    SortExpression="warningLevel" />
                <asp:BoundField DataField="dtmSubmitted" HeaderText="dtmSubmitted" 
                    SortExpression="dtmSubmitted" />
                <asp:BoundField DataField="submittedBy" HeaderText="submittedBy" 
                    SortExpression="submittedBy" />
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
                    ReadOnly="True" SortExpression="Id" Visible="False" />
                <asp:BoundField DataField="teamID" HeaderText="teamID" SortExpression="teamID" 
                    Visible="False" />
                <asp:BoundField DataField="oteamID" HeaderText="oteamID" 
                    SortExpression="oteamID" Visible="False" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT [gameDate], [sportID], [schoolName], [osportID], [oschoolName], [warningLevel], [dtmSubmitted], [submittedBy], [Id], [teamID], [oteamID] FROM [tblWarnings] ORDER BY [gameDate], [schoolName]"></asp:SqlDataSource>
    </form>
</body>
</html>
