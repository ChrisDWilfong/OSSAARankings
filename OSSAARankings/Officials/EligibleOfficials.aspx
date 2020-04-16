<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Officials.Master" CodeBehind="EligibleOfficials.aspx.vb" Inherits="OSSAARankings.EligibleOfficials" %>

<%@ Register Assembly="Infragistics4.WebUI.UltraWebGrid.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
</asp:ScriptManager>
<asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server" ClientIDMode="Inherit" ViewStateMode="Enabled">
    <ProgressTemplate>            
        <img alt="progress" src="../images/ajax-loader.gif"/><span style="font-family: Arial; font-size:12px; font-style:italic;">&nbsp;&nbsp;Processing...</span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <table style="width: 100%">
        <tr>
            <td><asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="9pt" Font-Bold="true" 
                    Text="Select Sport : "></asp:Label>
                <asp:DropDownList ID="cboSports" runat="server" DataSourceID="SqlDataSource2" 
                    DataTextField="strSport" DataValueField="strSport" Font-Names="Verdana" 
                    Font-Size="9pt">
                </asp:DropDownList>
                <asp:Button ID="cmdGo" runat="server" Text="Go" />
                <asp:Label ID="lblMessage" runat="server" Font-Names="Verdana" Font-Size="9pt" 
                    ForeColor="Navy" Text="&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;"></asp:Label>

                <asp:Label ID="Label2" runat="server" Font-Names="Verdana" Font-Size="9pt" Font-Bold="True" 
                    Text="&nbsp;&nbsp;&nbsp;&nbsp;Your Zip Code : " Visible="False"></asp:Label>

                <asp:TextBox ID="txtYourZipCode" runat="server" Width="75px" Visible="False"></asp:TextBox>

                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Verdana" 
                    Font-Size="9pt" 
                    Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Less than " 
                    Visible="False"></asp:Label>

                <asp:TextBox ID="txtMiles" runat="server" Width="75px" Visible="False"></asp:TextBox>

                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Verdana" 
                    Font-Size="9pt" Text="miles " Visible="False"></asp:Label>

            </td>
        </tr>
        <tr>
            <td>
                 <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Names="Verdana" 
                    Font-Size="9pt" RepeatDirection="Horizontal">
                    <asp:ListItem Value="strLastName">Name</asp:ListItem>
                    <asp:ListItem Value="intOSSAAID">OSSAAID</asp:ListItem>
                    <asp:ListItem Value="strCity">City</asp:ListItem>
                    <asp:ListItem Value="strZip">Zip</asp:ListItem>
                    <asp:ListItem Value="OfficialClass">Class</asp:ListItem>
                    <asp:ListItem Value="OfficialRating">Rating</asp:ListItem>
                    <asp:ListItem Value="intYears">Years</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <igtbl:UltraWebGrid ID="UltraWebGrid1" runat="server" DisplayLayout-NullTextDefault=""
                    Width="1246px" Browser="DownLevel" DataSourceID="SqlDataSource1" >
                    <DisplayLayout Name="UltraWebGrid1" RowHeightDefault="20px" 
                        Version="4.00" AllowColSizingDefault="Free"
                        CellClickActionDefault="RowSelect" CellPaddingDefault="1" 
                        HeaderClickActionDefault="SortMulti" 
                        RowSelectorsDefault="No" SelectTypeRowDefault="Single" 
                        Pager-AllowPaging="true" Pager-MinimumPagesForDisplay="3000"
                        StationaryMargins="Header" TableLayout="Fixed" AllowSortingDefault="Yes">
    <FrameStyle Width="1246px" BorderColor="#999999" BorderStyle="Solid" 
        BorderWidth="3px" Cursor="Default" Font-Names="Verdana" Font-Size="8pt">
    </FrameStyle>
    <RowAlternateStyleDefault BackColor="Gainsboro">
        <BorderDetails ColorLeft="Gainsboro" ColorTop="Gainsboro" />
    </RowAlternateStyleDefault>

<Pager AllowPaging="True" MinimumPagesForDisplay="3000"></Pager>

    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" 
            WidthTop="1px" />
    </FooterStyleDefault>
    <HeaderStyleDefault BackColor="DarkGray" BorderColor="Black" 
        BorderStyle="Solid" Font-Bold="True" ForeColor="White">
        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" 
            WidthTop="1px" />
    </HeaderStyleDefault>
    <RowSelectorStyleDefault BorderStyle="Solid">
    </RowSelectorStyleDefault>
    <RowStyleDefault BackColor="White" BorderColor="Gray" BorderStyle="Solid" 
        BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black">
        <Padding Left="3px" />
        <BorderDetails ColorLeft="White" ColorTop="White" />
    </RowStyleDefault>
    <SelectedRowStyleDefault BackColor="Silver" Font-Bold="True" ForeColor="Black">
    </SelectedRowStyleDefault>
    <AddNewBox>
        <BoxStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
            <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" 
                WidthTop="1px" />
        </BoxStyle>
    </AddNewBox>
<ActivationObject BorderColor="Black" BorderWidth="" BorderStyle="Dotted"></ActivationObject>
    <FilterOptionsDefault>
        <FilterDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" 
            BorderWidth="1px" CustomRules="overflow:auto;" 
            Font-Names="Verdana,Arial,Helvetica,sans-serif" Font-Size="11px" Width="200px">
            <Padding Left="2px" />
        </FilterDropDownStyle>
        <FilterHighlightRowStyle BackColor="#151C55" ForeColor="White">
        </FilterHighlightRowStyle>
        <FilterOperandDropDownStyle BackColor="White" BorderColor="Silver" 
            BorderStyle="Solid" BorderWidth="1px" CustomRules="overflow:auto;" 
            Font-Names="Verdana,Arial,Helvetica,sans-serif" Font-Size="11px">
            <Padding Left="2px" />
        </FilterOperandDropDownStyle>
    </FilterOptionsDefault>
</DisplayLayout>
<Bands>
<igtbl:UltraGridBand>
    <Columns>
        <igtbl:UltraGridColumn BaseColumnName="Id" DataType="System.Int32" Hidden="True" IsBound="True" Key="Id">
            <Header Caption="Id">
            </Header>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intOSSAAID" DataType="System.Int32" 
            IsBound="True" Key="intOSSAAID" Width="75px">
            <Header Caption="OSSAAID#" Title="OSSAAID">
                <RowLayoutColumnInfo OriginX="1" />
            </Header>
            <CellStyle ForeColor="Black">
            </CellStyle>
            <Footer>
                <RowLayoutColumnInfo OriginX="1" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="FullName" IsBound="True" 
            Key="FullName" Width="150px">
            <Header Caption="Name">
                <RowLayoutColumnInfo OriginX="2" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="2" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="strEmail" IsBound="True" 
            Key="strEmail" Width="200px">
            <Header Caption="Email">
                <RowLayoutColumnInfo OriginX="3" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="3" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="strAddress" IsBound="True" Key="strAddress" 
            Width="170px">
            <Header Caption="Address">
                <RowLayoutColumnInfo OriginX="4" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="4" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="strCity" IsBound="True" 
            Key="strCity" Width="100px">
            <Header Caption="City">
                <RowLayoutColumnInfo OriginX="5" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="5" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="strState" IsBound="True" Key="strState" 
            Width="25px">
            <Header Caption="St">
                <RowLayoutColumnInfo OriginX="6" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="6" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="strZip" IsBound="True" Key="strZip" 
            Width="80px">
            <Header Caption="Zip">
                <RowLayoutColumnInfo OriginX="7" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="7" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="strPhone1" IsBound="True" Key="strPhone1" 
            Width="110px">
            <Header Caption="Contact 1">
                <RowLayoutColumnInfo OriginX="8" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="8" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="strPhone2" IsBound="True" 
            Key="strPhone2" Width="110px">
            <Header Caption="Contact 2">
                <RowLayoutColumnInfo OriginX="9" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="9" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="OfficialClass" Key="OfficialClass" 
            Width="30px">
            <Header Caption="Class">
                <RowLayoutColumnInfo OriginX="10" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="10" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="OfficialRating" DataType="System.Int32" 
            Key="OfficialRating" Width="40px">
            <Header Caption="Rating">
                <RowLayoutColumnInfo OriginX="11" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="11" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intYears" DataType="System.Int16" 
            Key="intYears" Width="25px">
            <Header Caption="Yrs">
                <RowLayoutColumnInfo OriginX="12" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="12" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="Miles" DataType="System.Int32" Hidden="true"
            Key="Miles" Width="35px">
            <Header Caption="Miles">
                <RowLayoutColumnInfo OriginX="13" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="13" />
            </Footer>
        </igtbl:UltraGridColumn>

    </Columns>
<AddNewRow Visible="NotSet" View="NotSet"></AddNewRow>
</igtbl:UltraGridBand>
</Bands>
                </igtbl:UltraWebGrid>
            </td>
        </tr>
    </table>
</ContentTemplate>
</asp:UpdatePanel>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT [Id], [intOSSAAID], [strEmail], [strLastName], [strFirstName], [strLastName] + ', ' + [strFirstName] AS [FullName], [strAddress], [strCity], [strState], [strZip], [strPhone1], [strPhone2], [ysnCurrentBaseball], [ysnCurrentBasketball], [ysnCurrentFootball], [ysnCurrentSoftball], [ysnCurrentSoftballSP], [ysnCurrentSoccer], [ysnCurrentVolleyball], [ysnCurrentWrestling], '-' AS [OfficialClass], 0 AS [OfficialRating], [intYearsFootball] As [intYears], 0 AS [Miles] FROM [prodOfficials] WHERE ([ysnPrintedFootball] = @ysnPrintedFootball)">
        <SelectParameters>
            <asp:Parameter DefaultValue="100" Name="ysnPrintedFootball" Type="Int16" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT [strSport] FROM [Arbiter_Sports] WHERE [ysnShowEligibleOfficials] = 1 ORDER BY [intSort], [strSport]">
    </asp:SqlDataSource>
</asp:Content>

