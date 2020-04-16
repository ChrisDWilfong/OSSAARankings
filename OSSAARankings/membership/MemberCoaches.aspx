<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="SiteAD.Master" CodeBehind="MemberCoaches.aspx.vb" Inherits="OSSAARankings.MemberCoaches" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table id="tableDetail" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblStep" runat="server" Text="" Font-Bold="True" ForeColor="Red" Font-Size="Large" CssClass="objectTitle"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTitle" runat="server" Text="" Font-Bold="True" CssClass="objectTitle"></asp:Label>
            </td>
        </tr>
    </table>
        <table id="table1" style="width: 100%;">
        <tr>
            <td>
                <span style="font-family:Verdana; font-size:10px; color:Black;">
                    TO ADD A COACH TO YOUR LIST<br />
                    - Click the 'Add New Coach' button (this will add a blank line in your list).<br />
                    - Click 'Edit' for that line.<br />
                    - Enter the First and Last Name, select their Coaching position, type of Coach and enter the Email information.<br />
                    - Click 'Save' for that line to save your changes.<br /><br /> 
                </span>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblOfficials" runat="server" Text="" ForeColor="Maroon" font-family="Arial" Font-Size="Medium" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" 
                    Text="Coaches List&amp;nbsp;&amp;nbsp;&amp;nbsp;" Font-Bold="True" 
                    CssClass="objectTitle"></asp:Label>
                <asp:Button ID="cmdAddNewRequest" runat="server" CssClass="button" 
                    Text="Add New Coach" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" 
                    DataSourceID="SqlDataSource2" DataKeyNames="Id" PageSize="50">
                    <AlternatingRowStyle BackColor="#FFFFCC" />
                    <Columns>
                        <asp:BoundField DataField="FirstName" HeaderText="First" SortExpression="FirstName">
                            <ControlStyle CssClass="editWidth" />
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="itemWidth" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LastName" HeaderText="Last" SortExpression="LastName">
                            <ControlStyle CssClass="editWidth" />
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="itemWidth" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Position" SortExpression="Position">
                            <EditItemTemplate>
                                <asp:DropDownList ID="cboPosition1" runat="server" CssClass="dropDownList"
                                    DataSourceID="SqlDataSource4" DataTextField="Position" 
                                    DataValueField="Position" SelectedValue='<%# Bind("Position") %>'>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Position") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle CssClass="editWidth" Width="200px" />
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="itemWidth" Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Coach Type" SortExpression="CoachType">
                            <EditItemTemplate>
                                <asp:DropDownList ID="cboCoachType" runat="server" CssClass="dropDownList"
                                    DataSourceID="SqlDataSource5" DataTextField="strCoachType" 
                                    DataValueField="strCoachType" SelectedValue='<%# Bind("CoachType") %>'>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label21" runat="server" Text='<%# Eval("CoachType") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle CssClass="editWidth" Width="95px" />
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="itemWidth" Width="95px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                            <ControlStyle CssClass="editWidthEmail" Width="175px" />
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="itemWidth" Width="200px" />
                        </asp:BoundField>
                        <asp:CommandField ShowDeleteButton="True">
                            <ControlStyle CssClass="editWidth" Width="40px" />
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="itemWidth" Width="40px" />
                        </asp:CommandField>
                        <asp:CommandField ShowEditButton="True" UpdateText="Save">
                            <ControlStyle CssClass="editWidth" Width="100px" />
                            <HeaderStyle CssClass="gridHeader" />
                            <ItemStyle CssClass="itemWidth" Width="100px" />
                        </asp:CommandField>
                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
                            ReadOnly="True" ShowHeader="False" SortExpression="Id">
                            <ControlStyle CssClass="editWidth" Width="1px" ForeColor="White" Font-Size="1px" />
                            <FooterStyle Width="1px" />
                            <HeaderStyle Width="1px" CssClass="gridHeader" ForeColor="Silver" />
                            <ItemStyle CssClass="itemWidth" Width="1px" ForeColor="White" Font-Size="1px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EnteredBy" ReadOnly="True" ShowHeader="False">
                            <ControlStyle Font-Size="1px" ForeColor="White" Width="1px" />
                            <HeaderStyle CssClass="gridHeader" Width="1px" />
                            <ItemStyle Font-Size="1px" ForeColor="White" Width="1px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="intYear" ReadOnly="True" ShowHeader="False">
                            <ControlStyle Font-Size="1px" ForeColor="White" Width="1px" />
                            <HeaderStyle CssClass="gridHeader" Width="1px" />
                            <ItemStyle Font-Size="1px" ForeColor="White" Width="1px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SchoolID" ReadOnly="True" ShowHeader="False">
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
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSpaces" runat="server" Text="&nbsp;&nbsp;&nbsp;"></asp:Label>
                <asp:Label ID="lblMessage" runat="server" CssClass="content" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr><td>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
                DeleteCommand="UPDATE [tblCoaches] SET [ysnActive] = 0 WHERE [Id] = @original_Id" 
                InsertCommand="INSERT INTO [tblCoaches] ([SchoolID], [FirstName], [LastName], [Position], [CoachType], [Email], [intYear], [EnteredBy]) 
                        VALUES (@SchoolID, @FirstName, @LastName, @Position, @CoachType, @Email, @intYear, @EnteredBy)" 
                OldValuesParameterFormatString="original_{0}" 
                SelectCommand="SELECT [Id], [schoolID], [FirstName], [LastName], [Position], [CoachType], [Email], [intYear], [EnteredBy] FROM [tblCoaches] 
                    WHERE ([SchoolID] = @SchoolID AND [intYear] = 12 AND [ysnActive] = 1) ORDER BY [LastName], [FirstName]" 
                UpdateCommand="UPDATE [tblCoaches] SET [FirstName] = @FirstName, [Position] = @Position, [LastName] = @LastName, [CoachType] = @CoachType, [Email] = @Email, [EnteredBy] = @EnteredBy 
                    WHERE [Id] = @original_Id">
                <DeleteParameters>
                    <asp:Parameter Name="original_Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:SessionParameter Name="Type" SessionField="type2" Type="String" />
                    <asp:Parameter Name="SchoolID" Type="Int32" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="Position" Type="String" />
                    <asp:Parameter Name="CoachType" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="intYear" Type="Int32" />
                    <asp:Parameter Name="EnteredBy" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="0" Name="SchoolID" SessionField="key" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:SessionParameter Name="Type" SessionField="type2" Type="String" />
                    <asp:Parameter Name="SchoolID" Type="Int32" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="Position" Type="String" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="CoachType" Type="String" />
                    <asp:Parameter Name="intYear" Type="Int32" />
                    <asp:Parameter Name="EnteredBy" Type="String" />
                    <asp:Parameter Name="original_Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
                SelectCommand="SELECT [Position] FROM [tlkpSchoolPositions] WHERE ((([Type] = 'HSCOACH') AND [Position] Like 'HS Head%') OR ([Type] = 'DEFAULT')) ORDER BY [Sort], [Position]">
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
                SelectCommand="SELECT [strCoachType] FROM [tlkpCoachType] ORDER BY [intSort]">
            </asp:SqlDataSource>
    </td></tr>
    </table>
    <table id="tableFooter" style="width: 100%;">
        <tr><td align="center">&nbsp;</td></tr>
        <tr>
        <td>
            <asp:Label ID="lblFooter" runat="server" Font-Size="X-Small" Text="Copyright © 2014 OSSAA. All rights reserved.  "></asp:Label><a href="http://www.ossaa.com" target="_blank"><span style="font-family: Century Gothic; Font-Size:X-Small;">OSSAA Home Page</span></a>
        </td>
        </tr>
        <tr>
        <td>
            &nbsp;</td>
        </tr>
    </table>


</asp:Content>
