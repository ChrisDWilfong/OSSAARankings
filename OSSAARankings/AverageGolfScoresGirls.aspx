<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AverageGolfScoresGirls.aspx.vb" Inherits="OSSAARankings.AverageGolfScoresGirls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>  
    <asp:Label runat="server" Text="Girls Golf Scores" Font-Names="Arial" Font-Size="Large" ForeColor="Maroon"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AverageGolfScoresBoys.aspx" Font-Names="Arial" Font-Size="Small">Go to Boys Scores...</asp:HyperLink><br />
    <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="150px" AutoPostBack="true" Font-Names="Arial" Font-Size="Large" >
        <asp:ListItem Selected="True">Select Class...</asp:ListItem>
        <asp:ListItem>6A</asp:ListItem>
        <asp:ListItem>5A</asp:ListItem>
        <asp:ListItem>4A</asp:ListItem>
        <asp:ListItem>3A</asp:ListItem>
        <asp:ListItem>2A</asp:ListItem>
    </asp:DropDownList>
    <div>
    <asp:GridView ID="GridView1" runat="server" 
        AllowSorting="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
        BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" 
        ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" 
            Width="350px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="School" HeaderText="School" >
            <ItemStyle Font-Names="Arial" Font-Size="X-Small" />
            <HeaderStyle Font-Names="Arial" Font-Size="X-Small" />
            </asp:BoundField>
            <asp:BoundField DataField="avgGolfScore" HeaderText="Score" >
             <ItemStyle Font-Names="Arial" Font-Size="X-Small" />
            <HeaderStyle Font-Names="Arial" Font-Size="X-Small" />
            </asp:BoundField>
            <asp:BoundField DataField="strClass" HeaderText="Class" >
            <ItemStyle Font-Names="Arial" Font-Size="X-Small" />
            <HeaderStyle Font-Names="Arial" Font-Size="X-Small" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>  
    </div>
    </form>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT * FROM [viewAverageGolfScoreGirls] WHERE avgGolfScore > 0 AND strClass = @Class ORDER BY avgGolfScore, SchoolName">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="Select Class..." 
                Name="Class" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</body>
</html>
