<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Basketball.Master" CodeBehind="EligibleOfficialsPlayoffsWDates.aspx.vb" Inherits="OSSAARankings.EligibleOfficialsPlayoffsWDates" %>

<%@ Register Assembly="Infragistics4.WebUI.UltraWebGrid.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager2" runat="server">
</asp:ScriptManager>
<asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server" ClientIDMode="Inherit" ViewStateMode="Enabled">
    <ProgressTemplate>            
        <img alt="progress" src="../images/ajax-loader.gif"/><span style="font-family: Arial; font-size:12px; font-style:italic;">&nbsp;&nbsp;Processing...</span></ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <table style="width: 100%">
        <tr style="background-image:url(../images/red_bg.gif)" height="30px">
            <td>
                <asp:Label ID="lblHeader" runat="server" Text="&nbsp;&nbsp;This is the list of Available Playoff officials.  These are the only officials that will be available to work playoff games." CssClass="label" ForeColor="White"></asp:Label>
            </td>
        </tr>
        <table ID="tblTemp">
            <tr>
                <td width="20%">
                    <asp:Label ID="Label2" runat="server" CssClass="label" 
                        Text="Select Sort (then press Go) : "></asp:Label>
                </td>
                <td width="10%">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Names="Verdana" 
                        Font-Size="9pt" RepeatDirection="Horizontal">
                        <asp:ListItem Value="strLastName">Name</asp:ListItem>
                        <asp:ListItem Value="intOSSAAID">OSSAAID</asp:ListItem>
                        <asp:ListItem Value="strCity">City</asp:ListItem>
                        <asp:ListItem Value="OfficialClass">Class</asp:ListItem>
                        <asp:ListItem Value="OfficialRating">Rating</asp:ListItem>
                        <asp:ListItem Value="intYearsBasketball">Years</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td align="left" width="10%">
                    <asp:Button ID="cmdGo" runat="server" Text="Go"/>
                </td>
                <td width="50%" align="left">
                    <asp:Label ID="lblMessage" runat="server" Font-Names="Verdana" Font-Size="12px" ForeColor="Red" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        </tr>
        <tr style="background-image:url(../images/blue_bg.gif)" height="30px">
            <td>
                <asp:Label ID="Label1" runat="server" Text="&nbsp;&nbsp;Availability Key (X = Anytime; N = Nights; A = Afternoon; - = Not Available)" CssClass="label" ForeColor="Navy"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <igtbl:UltraWebGrid ID="UltraWebGrid1" runat="server" 
                    Width="1600px" Browser="Auto" DataSourceID="SqlDataSource1">
                    <DisplayLayout Name="UltraWebGrid1" RowHeightDefault="20px" 
                        Version="4.00" AllowColSizingDefault="Free"
                        CellClickActionDefault="RowSelect" CellPaddingDefault="1" 
                        HeaderClickActionDefault="SortMulti" LoadOnDemand="Xml" 
                        RowSelectorsDefault="No" SelectTypeRowDefault="Single" Pager-AllowPaging="true" Pager-MinimumPagesForDisplay="3000"
                        StationaryMargins="Header" TableLayout="Fixed" AllowSortingDefault="Yes">
    <FrameStyle Width="1500px" BorderColor="#999999" BorderStyle="Solid" 
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
            IsBound="True" Key="intOSSAAID" Width="60px">
            <Header Caption="OSSAAID#" Title="OSSAAID">
                <RowLayoutColumnInfo OriginX="1" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="1" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="strFullName" IsBound="True" 
            Key="FullName" Width="150px">
            <Header Caption="Name">
                <RowLayoutColumnInfo OriginX="2" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="2" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="strCityState" IsBound="True" 
            Key="strCity" Width="125px">
            <Header Caption="City">
                <RowLayoutColumnInfo OriginX="5" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="5" />
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
        <igtbl:UltraGridColumn BaseColumnName="strClassBasketball" Key="OfficialClass" 
            Width="35px">
            <Header Caption="Class">
                <RowLayoutColumnInfo OriginX="10" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="10" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="dblRatingBasketball" DataType="System.Int32" 
            Key="OfficialRating" Width="40px">
            <Header Caption="Rating">
                <RowLayoutColumnInfo OriginX="11" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="11" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intYearsBasketball" DataType="System.Int16" 
            Key="intYears" Width="25px">
            <Header Caption="Yrs">
                <RowLayoutColumnInfo OriginX="12" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="12" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intPlayoffAvail01" Key="strPlayoffAvail01" Width="50px" ValueList-Style-HorizontalAlign="Center" >
            <Header Caption="Feb13">
                <RowLayoutColumnInfo OriginX="13" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="13" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intPlayoffAvail02" Key="strPlayoffAvail02" Width="50px">
            <Header Caption="Feb14">
                <RowLayoutColumnInfo OriginX="14" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="14" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intPlayoffAvail03" Key="strPlayoffAvail03" Width="50px">
            <Header Caption="Feb19">
                <RowLayoutColumnInfo OriginX="15" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="15" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intPlayoffAvail04" Key="strPlayoffAvail04" Width="50px">
            <Header Caption="Feb20">
                <RowLayoutColumnInfo OriginX="16" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="16" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intPlayoffAvail05" Key="strPlayoffAvail05" Width="50px">
            <Header Caption="Feb21">
                <RowLayoutColumnInfo OriginX="17" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="17" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intPlayoffAvail06" Key="strPlayoffAvail06" Width="50px">
            <Header Caption="Feb26">
                <RowLayoutColumnInfo OriginX="18" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="18" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intPlayoffAvail07" Key="strPlayoffAvail07" Width="50px">
            <Header Caption="Feb27">
                <RowLayoutColumnInfo OriginX="19" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="19" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intPlayoffAvail08" Key="strPlayoffAvail08" Width="50px">
            <Header Caption="Feb28">
                <RowLayoutColumnInfo OriginX="20" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="20" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intPlayoffAvail09" Key="strPlayoffAvail09" Width="50px">
            <Header Caption="Mar5">
                <RowLayoutColumnInfo OriginX="21" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="21" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intPlayoffAvail10" Key="strPlayoffAvail10" Width="50px">
            <Header Caption="Mar6">
                <RowLayoutColumnInfo OriginX="22" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="22" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intPlayoffAvail11" Key="strPlayoffAvail11" Width="50px">
            <Header Caption="Mar7">
                <RowLayoutColumnInfo OriginX="23" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="23" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intPlayoffAvail12" Key="strPlayoffAvail12" Width="50px">
            <Header Caption="Mar12">
                <RowLayoutColumnInfo OriginX="24" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="24" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intPlayoffAvail13" Key="strPlayoffAvail13" Width="50px">
            <Header Caption="Mar13">
                <RowLayoutColumnInfo OriginX="25" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="25" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="intPlayoffAvail14" Key="strPlayoffAvail14" Width="50px">
            <Header Caption="Mar14">
                <RowLayoutColumnInfo OriginX="26" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="26" />
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
        SelectCommand="SELECT TOP 600 * FROM viewOfficialsBasketballEligibleAvailablePlayoffs ORDER BY strLastName, strFirstName">
    </asp:SqlDataSource>
</asp:Content>
