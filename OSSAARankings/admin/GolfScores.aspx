<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GolfScores.aspx.vb" Inherits="OSSAARankings.GolfScores" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblGolf" runat="server" Text="OSSAA Golf Scores" Font-Names="Verdana" Font-Size="Large" Font-Bold="true"></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            BackColor="#FFFF99" Font-Bold="False" Font-Names="Verdana" Font-Size="14px" 
            Height="28px" Width="200px">
            <asp:ListItem>Select Golf Class...</asp:ListItem>
            <asp:ListItem>GolfBoys6A</asp:ListItem>
            <asp:ListItem>GolfGirls6A</asp:ListItem>
            <asp:ListItem>GolfBoys5A</asp:ListItem>
            <asp:ListItem>GolfGirls5A</asp:ListItem>
            <asp:ListItem>GolfBoys4A</asp:ListItem>
            <asp:ListItem>GolfGirls4A</asp:ListItem>
            <asp:ListItem>GolfBoys3A</asp:ListItem>
            <asp:ListItem>GolfGirls3A</asp:ListItem>
        </asp:DropDownList>
        <br /><br />    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" DataSourceID="SqlDataSource1" ForeColor="Black" 
            GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="SchoolName" HeaderText="School" 
                    SortExpression="SchoolName">
                <HeaderStyle Font-Names="Verdana" Font-Size="11px" />
                <ItemStyle Font-Names="Verdana" Font-Size="11px" Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="GrandTotalScore" HeaderText="Total" 
                    SortExpression="GrandTotalScore">
                <HeaderStyle Font-Names="Verdana" Font-Size="11px" HorizontalAlign="Right" />
                <ItemStyle Font-Names="Verdana" Font-Size="11px" HorizontalAlign="Right" 
                    Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="NumOfScores" HeaderText="#" 
                    SortExpression="NumOfScores">
                <HeaderStyle Font-Names="Verdana" Font-Size="11px" HorizontalAlign="Right" />
                <ItemStyle Font-Names="Verdana" Font-Size="11px" HorizontalAlign="Right" 
                    Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="AvgScore" HeaderText="Avg" ReadOnly="True" 
                    SortExpression="AvgScore">
                <HeaderStyle Font-Names="Verdana" Font-Size="11px" HorizontalAlign="Right" />
                <ItemStyle Font-Names="Verdana" Font-Size="11px" HorizontalAlign="Right" 
                    Width="50px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
            SelectCommand="SELECT [SchoolName], [sportID], [GrandTotalScore], [NumOfScores], [AvgScore] FROM [viewGolfScoresReport] WHERE ([sportID] = @sportID) ORDER BY [AvgScore]">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="sportID" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
