<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Contacts.aspx.vb" Inherits="OSSAARankings.Contacts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contacts</title>
</head>
<body>
<form id="form1" runat="server">
<asp:Table ID="tblHeader" runat="server">
<asp:TableRow>
    <asp:TableCell>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource2" DataTextField="SchoolName" 
            DataValueField="SchoolName" Font-Size="Medium" Font-Bold="true" BackColor="LightSalmon">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource3" DataTextField="GenderSport" 
            DataValueField="SportGenderKey" Font-Size="Medium" Font-Bold="true" BackColor="LightGreen">
        </asp:DropDownList>
    </asp:TableCell>
</asp:TableRow>
<asp:TableRow><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
<asp:TableRow>
    <asp:TableCell>
        <asp:Label ID="lblAD" runat="server" Text="" Font-Names="Arial" Font-Size="Medium" ForeColor="Maroon"></asp:Label>
    </asp:TableCell>
</asp:TableRow>
<asp:TableRow>
    <asp:TableCell>
        <asp:Label ID="lblHSP" runat="server" Text="" Font-Names="Arial" Font-Size="Medium" ForeColor="Maroon" ></asp:Label>
    </asp:TableCell>
</asp:TableRow>
<asp:TableRow><asp:TableCell><hr /></asp:TableCell></asp:TableRow>
<asp:TableRow><asp:TableCell>
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" Font-Size="Medium" Font-Names="Arial">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="sportID" HeaderText="sportID" 
                SortExpression="sportID" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" 
                SortExpression="LastName" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                SortExpression="FirstName" />
            <asp:BoundField DataField="emailMain" HeaderText="emailMain" 
                SortExpression="emailMain" />
            <asp:BoundField DataField="phoneMain" HeaderText="phoneMain" 
                SortExpression="phoneMain" />
            <asp:BoundField DataField="SchoolName" HeaderText="SchoolName" 
                SortExpression="SchoolName" />
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
</asp:TableCell></asp:TableRow>
</asp:Table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT [sportID], [LastName], [FirstName], [emailMain], [phoneMain], [SchoolName] FROM [allCoachesDetail] WHERE ([SchoolName] = @SchoolName) ORDER BY [sportID]">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="None" 
                Name="SchoolName" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT DISTINCT [SchoolName] FROM [allCoachesDetail] ORDER BY [SchoolName]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT DISTINCT SportGenderKey, GenderSport FROM [tblSports] ORDER BY [GenderSport]">
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        SelectCommand="SELECT [sportID], [LastName], [FirstName], [emailMain], [phoneMain], [SchoolName] FROM [allCoachesDetail] WHERE ([SportGenderKey] = @SportGenderKey) AND intYear = 15 ORDER BY [SchoolName]">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList2" DefaultValue="None" 
                Name="SportGenderKey" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
