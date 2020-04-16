<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DashboardMembership.aspx.vb" Inherits="OSSAARankings.DashboardMembership" ValidateRequest="false" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Membership Upload Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <asp:Table runat="server" ID="tablename">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblHeader" runat="server" Text="OSSAA Membership Upload Dashboard" Font-Bold="true" Font-Names="Arial" Font-Size="X-Large"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblMessage" runat="server" Text="" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <telerik:RadMenu ID="RadMenu1" runat="server" ResolvedRenderMode="Classic" Skin="BlackMetroTouch">
                    <Items>
                        <telerik:RadMenuItem runat="server" Text="Superintendents" Value="SUP">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Principals" Value="PRIN">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Athletic Directors" Value="AD">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Admin" Value="OSSAA">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Board Minutes" Value="BOARD">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Board Appeals Minutes" Value="BOARDP">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Financials" Value="FIN">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="OSSAASpeech.com" Value="OSSAASPEECH">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Blasts" Value="Blasts">
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenu>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Label2" runat="server" Text="OSSAA.COM Upload Dashboard" Font-Bold="true" Font-Names="Arial" Font-Size="X-Large"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                 <telerik:RadMenu ID="RadMenu2" runat="server" ResolvedRenderMode="Classic" Skin="BlackMetroTouch">
                    <Items>
                        <telerik:RadMenuItem runat="server" Text="Postponements" Value="Postponements">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Home Column1" Value="HomeColumn1">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Home Column2" Value="HomeColumn2">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Home Column3" Value="HomeColumn3">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Classifications" Value="Classifications">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Baseball" Value="Baseball">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Basketball" Value="Basketball">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Cheer" Value="Cheer">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Cross Country" Value="CrossCountry">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Fast Pitch" Value="FastPitch">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Football" Value="Football">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Golf" Value="Golf">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Slow Pitch" Value="SlowPitch">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Soccer" Value="Soccer">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Swimming" Value="Swimming">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Tennis" Value="Tennis">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Track" Value="Track">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Volleyball" Value="Volleyball">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Wrestling" Value="Wrestling">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Academic Bowl" Value="AcademicBowl">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Music" Value="Music">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Speech/Debate" Value="SpeechDebate">
                        </telerik:RadMenuItem>

                        <telerik:RadMenuItem runat="server" Text="Eligibility" Value="Eligibility">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Media" Value="Media">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Misc Forms" Value="MiscForms">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="OSSAA Info" Value="OSSAAInfo">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Sports Medicine" Value="SportsMedicine">
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenu>           
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:HyperLink ID="hlPreview" runat="server" Visible="false" Target="True" Font-Bold="true" Font-Names="Arial" Font-Size="Large">PREVIEW PAGE</asp:HyperLink>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Panel ID="panelGrid" runat="server">
                    <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" 
                            AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
                            ResolvedRenderMode="Classic" Width="850px" 
                            AllowAutomaticInserts="false" AllowAutomaticUpdates="True" AllowAutomaticDeletes="true" PageSize="40" ShowStatusBar="true"
                            Skin="BlackMetroTouch" >       
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="id" DataSourceID="SqlDataSource1" CommandItemDisplay="Top" EditMode="PopUp" AllowAutomaticDeletes="true" >
                            <EditFormSettings UserControlName="DashboardMembershipDetails.ascx" EditFormType="WebUserControl" PopUpSettings-Width="800px"   >
                                <EditColumn UniqueName="EditCommandColumn1">
                                <ItemStyle Width="70px" />
                                <HeaderStyle Width="70px" />
                                </EditColumn>
                                <PopUpSettings Width="800px" Modal="true" />
                            </EditFormSettings> 
                            <Columns>
                                <telerik:GridEditCommandColumn UniqueName="EditCommandColumn">
                                    <ItemStyle ForeColor="Blue" />
                                </telerik:GridEditCommandColumn>
                                <telerik:GridBoundColumn DataField="id" DataType="System.Int32" ReadOnly="True" UniqueName="id" Display="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="intYear" DataType="System.Int16" 
                                    FilterControlAltText="Filter intYear column" HeaderText="Year" 
                                    SortExpression="intYear" UniqueName="intYear" DefaultInsertValue="16">
                                    <ItemStyle Width="50px" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="strLineType" UniqueName="strLineType" HeaderText="Type"  >
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="strDescription" 
                                    FilterControlAltText="Filter strDescription column" HeaderText="Description" 
                                    SortExpression="strDescription" UniqueName="strDescription" >
                                    <ItemStyle ForeColor="Yellow" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="strLink" UniqueName="strLink" Visible="false" HeaderText="URL"  >
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="intSort" DataType="System.Int16" 
                                    FilterControlAltText="Filter intSort column" HeaderText="Sort" 
                                    SortExpression="intSort" UniqueName="intSort">
                                    <ItemStyle Width="50px" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="Delete" UniqueName="DeleteButton" Text="Delete" ConfirmText="Are you sure you want to delete?">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </asp:Panel>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server" Text="<strong>SORT COLUMN :</strong> Largest number puts Link at the top : Sort = 0 will remove the link from the Membership Site." Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT [Id], [intYear], [strDescription], [intSort], [strLink], [strLineType] FROM [tblDashboardLinks] WHERE (([strSite] = @strSite) AND ([strType] = @strType) AND (intYear = 17 OR [intYear] = @intYear)) ORDER BY [intSort] DESC" 
        DeleteCommand="DELETE FROM [tblDashboardLinks] WHERE [Id] = @Id" >
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="OSSAAMembers" Name="strSite" 
                    SessionField="whereSite" Type="String" />
                <asp:SessionParameter DefaultValue="NONE" Name="strType" 
                    SessionField="whereType" Type="String" />
                <asp:SessionParameter DefaultValue="17" Name="intYear" SessionField="whereYear" 
                    Type="Int16" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
