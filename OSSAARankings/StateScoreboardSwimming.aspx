<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StateScoreboardSwimming.aspx.vb" Inherits="OSSAARankings.StateScoreboardSwimming" %>

<%@ Register Assembly="Infragistics4.Web.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="css/stateSB.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<link href="ajax.css" rel="stylesheet" type="text/css" />
<style type="text/css">
  .body
  {
      background-color: #5c5040;
  }  
    .style1
    {
        width: 59%;
    }
   
#UpdateProgress1 {
    top: 100px; left: 100px;
    position: absolute;
    background-repeat: repeat-x;
}    
</style>
<head runat="server">
    <title></title>
</head>

<body bgcolor="#5c5040">
    <form id="frmSwimming" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table class="sbTableWidth">
        <tr><td>
        &nbsp;<a href="StateScoreboardSwimmingMOBI.aspx" class="linkHeader" style="color:Yellow; background:#5C5040;" target="_parent" id="A9">IPhone Scoreboard</a>
        </td></tr>
        <tr><td>
            <asp:Label ID="lblHeader" runat="server" CssClass="labelHeaderMain" 
                Text="2011 OSSAA Swimming Championship Scoreboard" Width="100%" 
                BorderColor="Black" BorderWidth="1px"></asp:Label>
        </td></tr>
        <tr><td>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <ig:WebTab ID="WebTab1" runat="server" CssClasses-CssClass="sbWebTabWidth" 
                BackColor="#5C5040" DisplayMode="SingleRow" SelectedIndex="2">
            <Tabs>
                <ig:ContentTabItem runat="server" Text="Class 6A Girls" EnableAjax="True" TabSize="145px">
                    <Template>
                        <table id="tbl6AG" width="100%">
                            <tr>
                                <td class="style1">
                                    <asp:DropDownList ID="cbo6AG" runat="server" CssClass="labelHeader" 
                                        style="color:Black; vertical-align:middle;" Width="50%"
                                        AutoPostBack="True" DataTextField="strTeam1"
                                        DataValueField="strTeam1" BackColor="#FFFF99">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;<a href="http://www.ossaa.net/Playoffs/2010-11/Swimming/2011StateResultsPrelims6A.htm" class="linkHeader" target="_blank" id="link6AG">Prelims</a>
                                    &nbsp;&nbsp;<a href="ChampionshipResults.aspx?id=57" class="linkHeader" target="_blank" id="A1">Finals</a>
                                    &nbsp;&nbsp;<a href="http://www.ossaa.net/Playoffs/2010-11/Swimming/2011StateResultsFinals6A.pdf" class="linkHeader" target="_blank" id="A3">PDF</a>
                                    &nbsp;&nbsp;<a href="http://www.ossaa.net/Playoffs/2010-11/Swimming/2011StateResultsTeamScores6A.pdf" class="linkHeader" target="_blank" id="A4">Team</a>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="8" class="style1">
                                    <asp:Panel ID="panel6AGInd" runat="server">
                                        <asp:TextBox ID="txtClass6AGInd" runat="server" CssClass="labelSemi" 
                                            ReadOnly="True" Rows="9" TextMode="MultiLine" Width="98%"></asp:TextBox>
                                        <asp:Image ID="Image1" ImageUrl="http://www.ossaa.net/images/ossaaLogoSmall.gif" Width="150px" Height="150px" runat="server" />
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </Template>
                </ig:ContentTabItem>
                <ig:ContentTabItem runat="server" Text="Class 6A Boys" EnableAjax="True" TabSize="145px">
                    <Template>
                        <table id="tbl6AB" width="100%">
                            <tr>
                                <td class="style1">
                                    <asp:DropDownList ID="cbo6AB" runat="server" CssClass="labelHeader" 
                                        style="color:Black; vertical-align:middle;" Width="50%"
                                        AutoPostBack="True" DataTextField="strTeam1" EnableViewState="true"
                                        DataValueField="strTeam1" BackColor="#FFFF99">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;<a href="http://www.ossaa.net/Playoffs/2010-11/Swimming/2011StateResultsPrelims6A.htm" class="linkHeader" target="_blank" id="A2">Prelims</a>
                                    &nbsp;&nbsp;<a href="ChampionshipResults.aspx?id=56" class="linkHeader" target="_blank" id="A5">Finals</a>
                                    &nbsp;&nbsp;<a href="http://www.ossaa.net/Playoffs/2010-11/Swimming/2011StateResultsFinals6A.pdf" class="linkHeader" target="_blank" id="A6">PDF</a>
                                    &nbsp;&nbsp;<a href="http://www.ossaa.net/Playoffs/2010-11/Swimming/2011StateResultsTeamScores6A.pdf" class="linkHeader" target="_blank" id="A7">Team</a>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="8" class="style1">
                                    <asp:Panel ID="panel6ABInd" runat="server">
                                        <asp:TextBox ID="txtClass6ABInd" runat="server" CssClass="labelSemi" 
                                            ReadOnly="True" Rows="9" TextMode="MultiLine" Width="98%"></asp:TextBox>
                                            <asp:Image ID="Image2" ImageUrl="http://www.ossaa.net/images/ossaaLogoSmall.gif" Width="150px" Height="150px" runat="server" />
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>                   
		</Template>
                </ig:ContentTabItem>
                <ig:ContentTabItem runat="server" Text="Class 5A Girls" EnableAjax="True" TabSize="145px">
                    <Template>
                        <table id="tbl5AG" width="100%">
                            <tr>
                                <td class="style1">
                                    <asp:DropDownList ID="cbo5AG" runat="server" CssClass="labelHeader" 
                                        style="color:Black; vertical-align:middle;" Width="50%"
                                        AutoPostBack="True" DataTextField="strTeam1" EnableViewState="true"
                                        DataValueField="strTeam1" BackColor="#FFFF99">
                                    </asp:DropDownList>
                                    &nbsp;<a href="http://www.ossaa.net/Playoffs/2010-11/Swimming/2011StateResultsPrelims5A.htm" class="linkHeader" target="_blank" id="link5AG">Prelims</a>
                                    &nbsp;&nbsp;<a href="ChampionshipResults.aspx?id=59" class="linkHeader" target="_blank" id="A8">Finals</a>
                                    &nbsp;&nbsp;<a href="http://www.ossaa.net/Playoffs/2010-11/Swimming/2011StateResultsFinals5A.pdf" class="linkHeader" target="_blank" id="A10">PDF</a>
                                    &nbsp;&nbsp;<a href="http://www.ossaa.net/Playoffs/2010-11/Swimming/2011StateResultsTeamScores5A.pdf" class="linkHeader" target="_blank" id="A11">Team</a>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="8" class="style1">
                                    <asp:Panel ID="panel5AGInd" runat="server">
                                        <asp:TextBox ID="txtClass5AGInd" runat="server" CssClass="labelSemi" 
                                            ReadOnly="True" Rows="9" TextMode="MultiLine" Width="98%"></asp:TextBox>
                                            <asp:Image ID="Image3" ImageUrl="http://www.ossaa.net/images/ossaaLogoSmall.gif" Width="150px" Height="150px" runat="server" />
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </Template>
                </ig:ContentTabItem>
                <ig:ContentTabItem runat="server" Text="Class 5A Boys" EnableAjax="True" TabSize="145px">
                    <Template>
                        <table id="tbl5AB" width="100%">
                            <tr>
                                <td class="style1">
                                    <asp:DropDownList ID="cbo5AB" runat="server" CssClass="labelHeader" 
                                        style="color:Black; vertical-align:middle;" Width="50%"
                                        AutoPostBack="True" DataTextField="strTeam1" EnableViewState="true"
                                        DataValueField="strTeam1" BackColor="#FFFF99">
                                    </asp:DropDownList>
                                    &nbsp;<a href="http://www.ossaa.net/Playoffs/2010-11/Swimming/2011StateResultsPrelims5A.htm" class="linkHeader" target="_blank" id="link5AB">Prelim Results</a>
                                    &nbsp;&nbsp;<a href="ChampionshipResults.aspx?id=58" class="linkHeader" target="_blank" id="A12">Finals</a>
                                    &nbsp;&nbsp;<a href="http://www.ossaa.net/Playoffs/2010-11/Swimming/2011StateResultsFinals5A.pdf" class="linkHeader" target="_blank" id="A13">PDF</a>
                                    &nbsp;&nbsp;<a href="http://www.ossaa.net/Playoffs/2010-11/Swimming/2011StateResultsTeamScores5A.pdf" class="linkHeader" target="_blank" id="A14">Team</a>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="8" class="style1">
                                    <asp:Panel ID="panel5ABInd" runat="server">
                                        <asp:TextBox ID="txtClass5ABInd" runat="server" CssClass="labelSemi" 
                                            ReadOnly="True" Rows="9" TextMode="MultiLine" Width="98%"></asp:TextBox>
                                            <asp:Image ID="Image4" ImageUrl="http://www.ossaa.net/images/ossaaLogoSmall.gif" Width="150px" Height="150px" runat="server" />
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </Template>
                </ig:ContentTabItem>
            </Tabs>
            <ContentPane>
                <RoundedBackground Enabled="True" />
            </ContentPane>
            <PostBackOptions EnableAjax="True" />
        </ig:WebTab>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:OSSAAOnlineConnectionString %>" 
                SelectCommand="SELECT [strTeam1] FROM [tblPlayoffDetail] WHERE ([intEvent] = @intEvent) And intActive > 0 ORDER BY [intSort]">
                <SelectParameters>
                    <asp:Parameter DefaultValue="56" Name="intEvent" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:OSSAAOnlineConnectionString %>" 
                SelectCommand="SELECT [strTeam1] FROM [tblPlayoffDetail] WHERE ([intEvent] = @intEvent) And intActive > 0 ORDER BY [intSort]">
                <SelectParameters>
                    <asp:Parameter DefaultValue="57" Name="intEvent" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:OSSAAOnlineConnectionString %>" 
                SelectCommand="SELECT [strTeam1] FROM [tblPlayoffDetail] WHERE ([intEvent] = @intEvent) And intActive > 0 ORDER BY [intSort]">
                <SelectParameters>
                    <asp:Parameter DefaultValue="58" Name="intEvent" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                ConnectionString="<%$ ConnectionStrings:OSSAAOnlineConnectionString %>" 
                SelectCommand="SELECT [strTeam1] FROM [tblPlayoffDetail] WHERE ([intEvent] = @intEvent) And intActive > 0 ORDER BY [intSort]">
                <SelectParameters>
                    <asp:Parameter DefaultValue="59" Name="intEvent" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                <ProgressTemplate>
                    <img src="/images/loadinggears.gif" />
                </ProgressTemplate>
            </asp:UpdateProgress> 
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        </tr>
    </table>
    </form>
</body>
</html>
