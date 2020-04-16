<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="adPictures.aspx.vb" Inherits="OSSAARankings.adPictures" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>  
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox runat="server" ID="txtLogin" BackColor="Yellow"></asp:TextBox>&nbsp;<asp:Button
        ID="cmdGo" runat="server" Text="Go" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" DataKeyNames="teamID" DataSourceID="SqlDataSource1" 
            ForeColor="Black" GridLines="Vertical" Font-Size="8pt" 
            Font-Names="Verdana" HeaderStyle-Font-Names="Verdana" 
            HeaderStyle-Font-Size="8pt" AllowPaging="True" AllowSorting="True" 
            AutoGenerateEditButton="True">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="teamID" HeaderText="teamID" ReadOnly="True" 
                    SortExpression="teamID" InsertVisible="False" />
                <asp:BoundField DataField="sportID" HeaderText="sportID" 
                    SortExpression="sportID" ReadOnly="true" />
                <asp:BoundField DataField="TeamPicture" HeaderText="TeamPicture" 
                    SortExpression="TeamPicture" ReadOnly="true" Visible="false" />
                <asp:BoundField DataField="SchoolName" HeaderText="SchoolName" 
                    SortExpression="SchoolName" ReadOnly="true" />
                <asp:CheckBoxField DataField="TeamPictureView" HeaderText="TeamPictureView" 
                    SortExpression="TeamPictureView" />
                <asp:HyperLinkField DataNavigateUrlFields="strURL" DataTextField="strURL" 
                    HeaderText="URL" Target="_blank" />
                <asp:BoundField DataField="strURL" ReadOnly="True" Visible="False" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" 
                Font-Names="Verdana" Font-Size="8pt" />
            <PagerStyle BackColor="#999999" ForeColor="Yellow" Font-Bold="true" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAARANKINGSConnectionString %>" 
        
        SelectCommand="SELECT [teamID], [schoolID], [sportID], [TeamPicture], [SchoolName], [TeamPictureView], 'http://www.ossaarankings.com/images/TeamPix/' + [TeamPicture] AS strURL FROM [tblTeams] WHERE ([TeamPicture] IS NOT NULL) AND ([TeamPicture] <> '') AND ([TeamPictureView] = 0)" 
        DeleteCommand="DELETE FROM [tblTeams] WHERE [teamID] = @teamID" 
        InsertCommand="INSERT INTO [tblTeams] ([schoolID], [sportID], [TeamPicture], [SchoolName], [TeamPictureView]) VALUES (@schoolID, @sportID, @TeamPicture, @SchoolName, @TeamPictureView)" 
        UpdateCommand="UPDATE [tblTeams] SET [TeamPictureView] = @TeamPictureView WHERE [teamID] = @teamID">
        <DeleteParameters>
            <asp:Parameter Name="teamID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="schoolID" Type="Int32" />
            <asp:Parameter Name="sportID" Type="String" />
            <asp:Parameter Name="TeamPicture" Type="String" />
            <asp:Parameter Name="SchoolName" Type="String" />
            <asp:Parameter Name="TeamPictureView" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="schoolID" Type="Int32" />
            <asp:Parameter Name="sportID" Type="String" />
            <asp:Parameter Name="TeamPicture" Type="String" />
            <asp:Parameter Name="SchoolName" Type="String" />
            <asp:Parameter Name="TeamPictureView" Type="Boolean" />
            <asp:Parameter Name="teamID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
