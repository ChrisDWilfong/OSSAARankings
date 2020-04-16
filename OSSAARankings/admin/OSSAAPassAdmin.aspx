<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OSSAAPassAdmin.aspx.vb" Inherits="OSSAARankings.OSSAAPassAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Van Shea's Playoff Pass Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <link href="Site.css" rel="stylesheet" type="text/css" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table id="Table1">
        <tr height="24px" style="background-color: Black;">
            <td>
                <asp:Label ID="lblSchool" runat="server" Text="&nbsp;&nbsp;Select Organization" Font-Bold="True" style="color: White;" CssClass="objectTitle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSelectOrganization" runat="server" Text="Select Organization" Width="300px"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="" Width="230px"></asp:Label>&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Organization (required)" Width="220px"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" Text="Address" Width="220px"></asp:Label>
                <asp:Label ID="Label6" runat="server" Text="City" Width="100px"></asp:Label>
                <asp:Label ID="Label7" runat="server" Text="ST" Width="20px"></asp:Label>
                <asp:Label ID="Label8" runat="server" Text="Zip" Width="60px"></asp:Label>
                <asp:Label ID="Label9" runat="server" Text="Attn" Width="60px"></asp:Label>
            </td>
        </tr>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <tr>
            <td>
                <asp:DropDownList ID="cboSchools" runat="server" CssClass="dropDownList" 
                    Width="300px" DataSourceID="SqlDataSource1" DataTextField="strSchool" 
                    DataValueField="Id" AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="cmdAddNewOrganization" runat="server" CssClass="button" Text="Add New Organization" Width="230px" />
                &nbsp;&nbsp;
                <asp:TextBox ID="txtOrganization" runat="server" Height="18px" Width="220px" ToolTip="Organization Name"></asp:TextBox>
                <asp:TextBox ID="txtAddress" runat="server" Height="18px" Width="220px" ToolTip="Address"></asp:TextBox>
                <asp:TextBox ID="txtCity" runat="server" Height="18px" Width="100px" ToolTip="City"></asp:TextBox>
                <asp:TextBox ID="txtState" runat="server" Height="18px" Width="20px" ToolTip="State"></asp:TextBox>
                <asp:TextBox ID="txtZip" runat="server" Height="18px" Width="60px" ToolTip="Zip"></asp:TextBox>
                <asp:TextBox ID="txtAttn" runat="server" Height="18px" Width="100px" ToolTip="ATTN"></asp:TextBox>
                <asp:Button ID="cmdSaveChanges" runat="server" CssClass="button" Text="Save Changes" />
                
                <asp:CompareValidator ID="CompareValidator2" runat="server" 
                    ControlToValidate="cboSchools" ErrorMessage="You must select your Organization" 
                    ForeColor="Red" Operator="NotEqual" ValueToCompare="Select..."></asp:CompareValidator>
            </td>
        </tr>
        </ContentTemplate>
        </asp:UpdatePanel>
        <tr>
            <td>
                <asp:Button ID="cmdAddNew" runat="server" CssClass="button" Text="Add New Request" />
                <asp:Button ID="cmdInvoice" runat="server" CssClass="button" Text="Print Invoice" />
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="16px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" 
                    DataSourceID="SqlDataSource2" DataKeyNames="Id" BackColor="White" PageSize="20">
                    <AlternatingRowStyle BackColor="#FFFFCC" />
                    <Columns>
                        <asp:BoundField DataField="FirstName" HeaderText="First" 
                            SortExpression="FirstName">
                        <ControlStyle CssClass="editWidth" />
                        <HeaderStyle CssClass="gridHeader" />
                        <ItemStyle CssClass="itemWidth" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LastName" HeaderText="Last" SortExpression="LastName">
                            <ControlStyle CssClass="editWidth" />
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="itemWidth" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                            <EditItemTemplate>
                                <asp:DropDownList ID="cboStatus" runat="server" CssClass="dropDownList" DataTextField="Status" 
                                    DataValueField="Status" SelectedValue='<%# Bind("Status") %>'>
                                    <asp:ListItem Text="None" Value="None"></asp:ListItem>
                                    <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
                                    <asp:ListItem Text="Printed" Value="Printed"></asp:ListItem>
                                    <asp:ListItem Text="Billed" Value="Billed"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle CssClass="editWidth" Width="125px" />
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="itemWidth" Width="125px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="intCost" HeaderText="Cost" SortExpression="intCost">
                            <ControlStyle CssClass="editWidth" />
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="itemWidth" />
                        </asp:BoundField>
                        <asp:CommandField ShowDeleteButton="True">
                            <ControlStyle CssClass="editWidth" Width="40px" />
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="itemWidth" Width="40px" />
                        </asp:CommandField>
                        <asp:CommandField ShowEditButton="True" UpdateText="Save">
                            <ControlStyle CssClass="editWidth" Width="75px" />
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="itemWidth" Width="75px" />
                        </asp:CommandField>
                        <asp:BoundField DataField="dtmInvoicePrinted" HeaderText="Printed" SortExpression="dtmInvoicePrinted" ReadOnly="true">
                            <ControlStyle CssClass="editWidth" />
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="itemWidth150" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" ShowHeader="False" SortExpression="Id">
                            <ControlStyle CssClass="editWidth" Width="1px" ForeColor="White" Font-Size="1px" />
                            <FooterStyle Width="1px" />
                            <HeaderStyle Width="1px" CssClass="gridHeader" ForeColor="Silver" />
                            <ItemStyle CssClass="itemWidth" Width="1px" ForeColor="White" Font-Size="1px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PassHeaderId" HeaderText="" InsertVisible="False" ReadOnly="True" ShowHeader="False" SortExpression="PassHeaderId">
                            <ControlStyle CssClass="editWidth" Width="1px" ForeColor="White" Font-Size="1px" />
                            <FooterStyle Width="1px" />
                            <HeaderStyle Width="1px" CssClass="gridHeader" ForeColor="Silver" />
                            <ItemStyle CssClass="itemWidth" Width="1px" ForeColor="White" Font-Size="1px" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                </td>
        </tr>
        <tr><td>
            <asp:Panel Visible="true" runat="server">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=A">A</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=B">B</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=C">C</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=D">D</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=E">E</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=F">F</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=G">G</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=H">H</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=I">I</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=J">J</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=K">K</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=L">L</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=M">M</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=N">N</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=O">O</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=P">P</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=Q">Q</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=R">R</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink19" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=S">S</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink20" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=T">T</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink21" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=U">U</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink22" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=V">V</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink23" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=W">W</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink24" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=X">X</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink25" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=Y">Y</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink26" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=Z">Z</asp:HyperLink>&nbsp;
            <asp:HyperLink ID="HyperLink27" runat="server" NavigateUrl="~/Admin/OSSAAPassAdmin.aspx?sort=%">ALL</asp:HyperLink>&nbsp;
            </asp:Panel>
        </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="cmdRefresh" runat="server" CssClass="button" Text="Refresh Page" />
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr height="24px" style="background-color: Black;">
            <td>
                <asp:Label ID="Label2" runat="server" Text="&nbsp;&nbsp;Search for Name..." Font-Bold="True" style="color: White;" CssClass="objectTitle"></asp:Label>
            </td>
        </tr>
        <tr><td>
            <asp:Label ID="lblFirstName" runat="server" Text="First Name : "></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>&nbsp;&nbsp;
            <asp:Label ID="lblLastName" runat="server" Text="Last Name : "></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>&nbsp;&nbsp;
            <asp:Button ID="cmdSearch" runat="server" Text="Search..." />
            <asp:Label ID="lblMessageSearch" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="14px"></asp:Label>
        </td></tr>
        <tr><td>&nbsp;</td></tr>
        <tr><td>
            <asp:Label ID="Label1" runat="server" Font-Size="X-Small" Text="Copyright © 2016 OSSAA. All rights reserved."></asp:Label>
        </td></tr>
        <tr>
            <td>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
                    SelectCommand="SELECT [Id], [strSchool] FROM [tblPassHeader] WHERE [strCategory] = 'OSSAA' AND [intYear] = @sessionYear ORDER BY [strSchool]">
                    <SelectParameters>
                        <asp:SessionParameter Type="Int16" SessionField="sessionYear" DefaultValue="0" Name="sessionYear" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
                    DeleteCommand="DELETE FROM [tblPassDetails] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblPassDetails] ([PassHeaderId], [FirstName], [LastName], [Type], [Status], [Position], [strCategory]) VALUES (@PassHeaderId, @FirstName, @LastName, @Type, @Status, @Position, @strCategory)" 
                    SelectCommand="SELECT [Id], [PassHeaderId], [FirstName], [LastName], [Type], [Status], [Position], [strCategory], [Status], [dtmInvoicePrinted], [intCost] FROM [tblPassDetails] WHERE ([PassHeaderId] = @PassHeaderId) AND ([LastName] Like @LastNameSort + '%' OR [LastName] Is Null) AND intYear = @sessionYear ORDER BY [LastName], [FirstName]" 
                    UpdateCommand="UPDATE [tblPassDetails] SET [PassHeaderId] = @PassHeaderId, [FirstName] = @FirstName, [LastName] = @LastName, [Type] = @Type, [Status] = @Status, [Position] = @Position, [strCategory] = @strCategory, [intCost] = @intCost, [PaidStatus] = 'UNPAID', [dtmStamp] = GETDATE() WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="PassHeaderId" Type="Int32" />
                        <asp:Parameter Name="FirstName" Type="String" />
                        <asp:Parameter Name="LastName" Type="String" />
                        <asp:Parameter Name="intCost" Type="Int16" />
                        <asp:Parameter Name="Type" Type="String" />
                        <asp:Parameter Name="Status" Type="String" />
                        <asp:Parameter Name="Position" Type="String" />
                        <asp:Parameter Name="strCategory" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="cboSchools" Name="PassHeaderId" PropertyName="SelectedValue" Type="Int32" />
                        <asp:SessionParameter Type="String" SessionField="sort" DefaultValue="%" Name="LastNameSort" />
                        <asp:SessionParameter Type="Int16" SessionField="sessionYear" DefaultValue="0" Name="sessionYear" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="FirstName" Type="String" />
                        <asp:Parameter Name="LastName" Type="String" />
                        <asp:Parameter Name="Type" Type="String" DefaultValue="OSSAA" />
                        <asp:Parameter Name="Status" Type="String" DefaultValue="Approved" />
                        <asp:Parameter Name="Position" Type="String" DefaultValue="None" />
                        <asp:Parameter Name="strCategory" Type="String" DefaultValue="OSSAA" />
                        <asp:Parameter Name="Id" Type="Int32" />
                        <asp:ControlParameter ControlID="cboSchools" Name="PassHeaderId" PropertyName="SelectedValue" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </td>
        </tr>            
    </table>
    </form>
</body>
</html>

