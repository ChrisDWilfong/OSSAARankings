<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="SiteAD.Master" CodeBehind="MemberRules.aspx.vb" Inherits="OSSAARankings.MemberRules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table id="tableDetail" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblStep" runat="server" Text="" Font-Bold="True" ForeColor="Red" Font-Size="Large"
                    CssClass="objectTitle"></asp:Label>
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
            </td>
        </tr>
        <tr>
            <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Vertical" Width="250px">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:BoundField DataField="strRules" HeaderText="2019-20 Rules Meetings" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
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
    </td></tr>
    </table>
    <table id="tableFooter" style="width: 100%;">
        <tr><td align="center">&nbsp;</td></tr>
        <tr>
        <td>
            <asp:Label ID="lblCopyright" runat="server" Font-Size="X-Small" Text="Copyright © 2017 OSSAA. All rights reserved.  "></asp:Label><a href="http://www.ossaa.com" target="_blank"><span style="font-family: Century Gothic; Font-Size:X-Small;">OSSAA Home Page</span></a>
        </td>
        </tr>
        <tr>
            
        <td>
            &nbsp;</td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAServerConnectionString %>" 
        SelectCommand="SELECT [schoolID], [SchoolAbb], [strRules] FROM [viewRulesMembers] WHERE ([schoolID] = @schoolID)">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="schoolID" SessionField="idSchool" 
                Type="Int16" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
