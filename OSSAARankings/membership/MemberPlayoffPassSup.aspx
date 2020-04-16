<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="SiteMembership.Master" CodeBehind="MemberPlayoffPassSup.aspx.vb" Inherits="OSSAARankings.MemberPlayoffPassSup" %>
<%@ Register src="ucPlayoffsWinter.ascx" tagname="ucPlayoffs" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/SiteMembership.css" rel="stylesheet" type="text/css" />
    <table id="tableDetail" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblStep" runat="server" Text="" Font-Bold="True" ForeColor="Red" Font-Size="Large"
                    CssClass="objectTitle"></asp:Label>
            </td>
        </tr>
    </table>
    <table id="tableHeader" style="width: 100%;">
        <tr><td>&nbsp;</td></tr>
        <tr><td>
            <asp:Label ID="lblDetails" ForeColor="Navy" runat="server" Text="The OSSAA Playoff Passes are for Board Members, Superintendent and spouses/guests of both.  All are complimentary with the exception of the spouse/guest of the Superintendent which can be purchased for $10.<br>&nbsp;&nbsp;- Please do not list school age children as a guest (passes are not valid for students grades K-12).<br>&nbsp;&nbsp;- There is a $10 charge for replacement of lost passes."></asp:Label>
            </td></tr>
        <tr><td>&nbsp;</td></tr>
    </table>
    <table id="table1" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblTitle" runat="server" 
                    Text="Playoff Pass Request List&amp;nbsp;&amp;nbsp;&amp;nbsp;" Font-Bold="True" 
                    CssClass="objectTitle"></asp:Label>
                <asp:Button ID="Button1" runat="server" CssClass="button" 
                    Text="Add New Request" />
                <asp:Label ID="lblInvoiceTotal" runat="server" CssClass="headerHeader" 
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="Id">
                    <AlternatingRowStyle BackColor="#FFFFCC" />
                    <Columns>
                        <asp:BoundField DataField="FirstName" HeaderText="First" 
                            SortExpression="FirstName">
                        <ControlStyle CssClass="editWidth" />
                        <HeaderStyle CssClass="gridHeader" />
                        <ItemStyle CssClass="itemWidth" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LastName" HeaderText="Last" 
                            SortExpression="LastName">
                        <ControlStyle CssClass="editWidth" />
                        <HeaderStyle CssClass="gridHeader" />
                        <ItemStyle CssClass="itemWidth" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Position" HeaderText="Position" ReadOnly="True" 
                            SortExpression="Position">
                        <ControlStyle CssClass="editWidth" Width="100px" />
                        <HeaderStyle CssClass="gridHeader" />
                        <ItemStyle CssClass="itemWidth" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SpouseFirstName" HeaderText="Guest First" 
                            SortExpression="SpouseFirstName">
                        <ControlStyle CssClass="editWidth" />
                        <HeaderStyle CssClass="gridHeader" />
                        <ItemStyle CssClass="itemWidth" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SpouseLastName" HeaderText="Guest Last" 
                            SortExpression="SpouseLastName">
                        <ControlStyle CssClass="editWidth" />
                        <HeaderStyle CssClass="gridHeader" />
                        <ItemStyle CssClass="itemWidth" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SpouseStatus" HeaderText="Pass Status" 
                            ReadOnly="True" SortExpression="SpouseStatus">
                        <ControlStyle CssClass="editWidth" />
                        <HeaderStyle CssClass="gridHeader" />
                        <ItemStyle CssClass="itemWidth" />
                        </asp:BoundField>
                        <asp:BoundField DataField="intCost" HeaderText="Cost" ReadOnly="True" 
                            SortExpression="intCost">
                        <ControlStyle CssClass="editWidth" Width="50px" />
                        <HeaderStyle CssClass="gridHeader" />
                        <ItemStyle CssClass="itemWidth" Width="50px" />
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
                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
                            ReadOnly="True" ShowHeader="False" SortExpression="Id">
                        <ControlStyle CssClass="editWidth" Width="1px" ForeColor="White" 
                            Font-Size="1px" />
                        <FooterStyle Width="1px" />
                        <HeaderStyle Width="1px" CssClass="gridHeader" ForeColor="Silver" />
                        <ItemStyle CssClass="itemWidth" Width="1px" ForeColor="White" Font-Size="1px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SpousePaidStatus" ReadOnly="True" ShowHeader="False">
                        <ControlStyle Font-Size="1px" ForeColor="White" Width="1px" />
                        <HeaderStyle CssClass="gridHeader" Width="1px" />
                        <ItemStyle Font-Size="1px" ForeColor="White" Width="1px" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMessage" runat="server" CssClass="content" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr><td>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
                DeleteCommand="DELETE FROM [tblPassDetails] WHERE [Id] = @original_Id" 
                InsertCommand="INSERT INTO [tblPassDetails] ([Type], [FirstName], [LastName], [Position], [SpouseFirstName], [SpouseLastName], [SpouseStatus], [SpousePaidStatus], [intCost]) VALUES (@Type, @FirstName, @LastName, @Position, @SpouseFirstName, @SpouseLastName, @SpouseStatus, @SpousePaidStatus, @intCost)" 
                OldValuesParameterFormatString="original_{0}" 
                SelectCommand="SELECT [Id], [Type], [FirstName], [LastName], [Position], [SpouseFirstName], [SpouseLastName], [SpouseStatus], [SpousePaidStatus], [intCost] FROM [tblPassDetails] WHERE ([PassHeaderId] = @PassHeaderId)" 
                
                UpdateCommand="UPDATE [tblPassDetails] SET [Type] = @Type, [FirstName] = @FirstName, [LastName] = @LastName, [SpouseFirstName] = @SpouseFirstName, [SpouseLastName] = @SpouseLastName, [SpouseStatus] = @SpouseStatus, [SpousePaidStatus] = @SpousePaidStatus, [intCost] = @intCost WHERE [Id] = @original_Id">
                <DeleteParameters>
                    <asp:Parameter Name="original_Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:SessionParameter Name="Type" SessionField="type" Type="String" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="Position" Type="String" />
                    <asp:Parameter Name="SpouseFirstName" Type="String" />
                    <asp:Parameter Name="SpouseLastName" Type="String" />
                    <asp:Parameter Name="SpouseStatus" Type="String" />
                    <asp:Parameter Name="SpousePaidStatus" Type="String" />
                    <asp:Parameter Name="intCost" Type="Int32" />
                </InsertParameters>
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="PassHeaderId" SessionField="key" 
                        Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:SessionParameter Name="Type" SessionField="type" Type="String" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="Position" Type="String" />
                    <asp:Parameter Name="SpouseFirstName" Type="String" />
                    <asp:Parameter Name="SpouseLastName" Type="String" />
                    <asp:Parameter Name="SpouseStatus" Type="String" />
                    <asp:Parameter Name="SpousePaidStatus" Type="String" />
                    <asp:Parameter Name="intCost" Type="Int32" />
                    <asp:Parameter Name="original_Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            </td></tr>
    </table>
    <table id="tableFooter" style="width: 100%;">
        <tr><td>&nbsp;</td></tr>
        <tr>
        <td>
            <asp:Label ID="lblCopyright" runat="server" Font-Size="X-Small" Text="Copyright © 2014 OSSAA. All rights reserved.  "></asp:Label><a href="http://www.ossaa.com" target="_blank"><span style="font-family: Century Gothic; Font-Size:X-Small;">OSSAA Home Page</span></a>
        </td>
        </tr>
        <tr>
        <td>
            &nbsp;</td>
        </tr>
    </table>
</asp:Content>
