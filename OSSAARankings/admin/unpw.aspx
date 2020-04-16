<%@ Page Language="vb" Async="true" AutoEventWireup="false" CodeBehind="unpw.aspx.vb" Inherits="OSSAARankings.unpw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="tblName">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Position : " CssClass="content"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboPosition" runat="server" CssClass="content" Height="30px">
                        <asp:ListItem>Select...</asp:ListItem>
                        <asp:ListItem>Superintendent</asp:ListItem>
                        <asp:ListItem>High School Principal</asp:ListItem>
                        <asp:ListItem>Athletic Director</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="School : " CssClass="content"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="cboSchool" runat="server" CssClass="content" 
                        DataSourceID="SqlDataSource1" DataTextField="SchoolName" 
                        DataValueField="Id" Width="300px" Height="40px"></asp:DropDownList>
                    <asp:Button ID="cmdGo" runat="server" Text="Go" CssClass="button" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="First/Last : " CssClass="content"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="content"></asp:TextBox>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="content"></asp:TextBox>
                </td>
            </tr>      
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Email : " CssClass="content"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="content" Width="300px"></asp:TextBox>
                </td>
            </tr>    
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Phone : " CssClass="content"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="content" Width="300px"></asp:TextBox>
                </td>
            </tr>   
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Cell : " CssClass="content"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCell" runat="server" CssClass="content" Width="300px"></asp:TextBox>
                </td>
            </tr>  
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Password : " CssClass="content"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="content" Width="150px"></asp:TextBox>
                </td>
            </tr>  
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Date : " CssClass="content"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="dtmStamp" runat="server" CssClass="content" Width="300px"></asp:TextBox>
                </td>
            </tr> 
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblMessage" runat="server" Font-Size="8pt" ForeColor="Red"></asp:Label>
                </td>
            </tr>  
            <tr>
                <td colspan="2">
                    <asp:Button ID="cmdSave" runat="server" Text="Save" CssClass="button" />
                    <asp:Button ID="cmdClear" runat="server" Text="Clear" CssClass="button" />
                    <asp:Button ID="cmdSendEmail" runat="server" Text="Welcome Email" 
                        CssClass="button" />
                    <asp:Button ID="cmdTestEmail" runat="server" Text="Test Email" 
                        CssClass="button" Visible="false" />
                </td>
            </tr>   
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblOSSAARankings" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT [Id], [SchoolName], [schoolID] FROM [tblSchool] WHERE ([OrganizationType] = @OrganizationType OR [OrganizationType] = 'MULTI') ORDER BY [SchoolName]">
        <SelectParameters>
            <asp:Parameter DefaultValue="SCHOOL" Name="OrganizationType" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
