<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DashboardOfficialsPages.aspx.vb" Inherits="OSSAARankings.DashboardOfficialsPages" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSAA Officials Web Page Administration</title>
</head>
<style type="text/css">
.header 
{
    font-family: Verdana;
    font-size:14px;
    color: Maroon;    
}
.labelLabel 
{
    font-family: Verdana;
    font-size:9px;
    color: Gray;
}
.textContent 
{
    font-family: Verdana;
    font-size:11px;
}

</style>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <div>
        <asp:Table runat="server" ID="tblOfficialsPages" Width="400px">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblHeader" runat="server" Text="Officials Web Page Administration" CssClass="header" Font-Bold="true" ></asp:Label><br />
                    <asp:Label ID="lblMessage" runat="server" Text="" Font-Names="Verdana" ForeColor="Red" Font-Size="Small" ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblType" runat="server" Text="TYPE" CssClass="labelLabel"></asp:Label><br />
                    <asp:DropDownList ID="cboType" runat="server" CssClass="textContent">
                        <asp:ListItem Value="PLAYOFFAVAIL" Text="PLAYOFFAVAIL"></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblSport" runat="server" Text="SPORT" CssClass="labelLabel"></asp:Label><br />
                    <asp:DropDownList ID="cboSport" runat="server" CssClass="textContent" DataSourceID="SqlDataSource2" DataTextField="strSportKey" DataValueField="strSportKey">
                    </asp:DropDownList>                
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblYear" runat="server" Text="YEAR" CssClass="labelLabel"></asp:Label><br />
                    <asp:DropDownList ID="cboYear" runat="server" CssClass="textContent" DataSourceID="SqlDataSource1" DataValueField="strYear" DataTextField="strYear" >
                    </asp:DropDownList>&nbsp;
                    <asp:Button ID="cmdGo" runat="server" Text="Load" />                   
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="cmdSave" runat="server" Text="Save Changes" BackColor="Green" Font-Size="Medium" ForeColor="Yellow" Font-Bold="true" />
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblLoginHeading" runat="server" Text="LOGIN HEADING" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtLoginHeading" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblDateStart" runat="server" Text="START DATE" CssClass="labelLabel"></asp:Label><br />
                    <telerik:RadDatePicker ID="RadDatePickerStart" runat="server">
                    </telerik:RadDatePicker>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblDateEnd" runat="server" Text="END DATE" CssClass="labelLabel"></asp:Label><br />
                    <telerik:RadDatePicker ID="RadDatePickerEnd" runat="server">
                    </telerik:RadDatePicker>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><hr /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney1Name" runat="server" Text="TOURNEY #1 NAME : (ex : 6A-4A Fast Pitch State Tournament)" CssClass="labelLabel" Font-Bold="true" ForeColor="Navy"></asp:Label><br />
                    <asp:TextBox ID="txtTourney1Name" runat="server" CssClass="textContent" Width="100%" BackColor="Yellow"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney1Info1" runat="server" Text="INFO DAY #1 : (ex : Wednesday (PM), Oct 7, Hall of Fame)" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtTourney1Info1" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney1Info2" runat="server" Text="INFO DAY #2 : (ex : Thursday, Oct 8, Hall of Fame)" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtTourney1Info2" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney1Info3" runat="server" Text="INFO DAY #3" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtTourney1Info3" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney1Info4" runat="server" Text="INFO DAY #4" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtTourney1Info4" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney1Info5" runat="server" Text="INFO DAY #5" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtTourney1Info5" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><hr /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney2Name" runat="server" Text="TOURNEY #2 NAME : (ex : 3A-B Fast Pitch State Tournament)" CssClass="labelLabel" Font-Bold="true" ForeColor="Navy"></asp:Label><br />
                    <asp:TextBox ID="txtTourney2Name" runat="server" CssClass="textContent" Width="100%" BackColor="Yellow"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney2Info1" runat="server" Text="INFO DAY #1" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtTourney2Info1" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney2Info2" runat="server" Text="INFO DAY #2" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtTourney2Info2" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney2Info3" runat="server" Text="INFO DAY #3" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtTourney2Info3" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney2Info4" runat="server" Text="INFO DAY #4" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtTourney2Info4" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney2Info5" runat="server" Text="INFO DAY #5" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtTourney2Info5" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><hr /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney3Name" runat="server" Text="TOURNEY #3 NAME" CssClass="labelLabel" Font-Bold="true" ForeColor="Navy"></asp:Label><br />
                    <asp:TextBox ID="txtTourney3Name" runat="server" CssClass="textContent" Width="100%" BackColor="Yellow"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney3Info1" runat="server" Text="INFO DAY #1" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtTourney3Info1" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney3Info2" runat="server" Text="INFO DAY #2" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtTourney3Info2" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney3Info3" runat="server" Text="INFO DAY #3" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtTourney3Info3" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney3Info4" runat="server" Text="INFO DAY #4" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtTourney3Info4" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblTourney3Info5" runat="server" Text="INFO DAY #5" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtTourney3Info5" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2"><hr /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblLoginPage" runat="server" Text="LOGIN PAGE (ex: LoginFPO.aspx)" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtLoginPage" runat="server" CssClass="textContent" Width="90%"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblHomePage" runat="server" Text="HOME PAGE (ex: PlayoffAvailabilityFP.aspx)" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtHomePage" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblLoginPageURL" runat="server" Text="LOGIN PAGE URL : (ex: http://ossaawebsite.ossaa.net/Officials/LoginFPO.aspx)" CssClass="labelLabel"></asp:Label><br />
                    <asp:TextBox ID="txtLoginPageURL" runat="server" CssClass="textContent" Width="100%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

        </asp:Table>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT DISTINCT [strYear] FROM [tblDashboardOfficials] ORDER BY strYear">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OSSAAConnectionString %>" 
        SelectCommand="SELECT DISTINCT [strSportKey] FROM [tblDashboardOfficials] WHERE intYear = @currentYear ORDER BY strSportKey">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="20" Name="currentYear" SessionField="gYear" Type="Int16" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
