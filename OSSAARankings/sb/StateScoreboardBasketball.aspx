<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StateScoreboardBasketball.aspx.vb" Inherits="OSSAARankings.StateScoreboardBasketball" ClientTarget="uplevel"  %>

<%@ Register Assembly="Infragistics4.WebUI.UltraWebTab.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebTab" TagPrefix="igtab" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="css/stateSBMOBI.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<link href="css/ajax.css" rel="stylesheet" type="text/css" />
<head runat="server">
    <title>OSSAA Basketball State Tournament Scoreboard</title>
    <link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Passion+One' rel='stylesheet' type='text/css' />
</head>
<body bgcolor="#5c5040">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AllowCustomErrorsRedirect="False">
    </asp:ScriptManager>
<div style="vertical-align:top;">
                    <asp:Table runat="server" Width="890px">
                        <asp:TableRow Width="100%" VerticalAlign="Bottom">
                        <asp:TableCell>
                            <asp:Label ID="lblHeader" runat="server" CssClass="labelHeaderMain" Font-Names="Oswald" Text="2016 OSSAA Basketball State Championships Scoreboard" Height="34px" Font-Size="22px" Width="100%" BorderColor="Black" BorderWidth="1px"></asp:Label>
                        </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Table ID="Table6" width="100%" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                            <asp:Label ID="lblClass6AHeader" runat="server" CssClass="labelHeader" Width="100%" Height="26px" Font-Names="Passion+One"></asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top">
                                            <asp:Table ID="lbl6A" runat="server">
                                                <asp:TableRow HorizontalAlign="Center">
                                                    <asp:TableCell HorizontalAlign="Center" style="padding-right:10px;"><asp:Label ID="lblBoys6A" runat="server" Text=""></asp:Label></asp:TableCell>
                                                    <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblGirls6A" runat="server" Text=""></asp:Label></asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
                                    <asp:TableRow Visible="false">
                                        <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                            <span style="font-family: Arials; font-size: 14px; color: Black; font-weight:bold;">CLASS 6A STATE CHAMPIONSHIPS BRACKETS<br />
                                            </span>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow Visible="false">
                                        <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                            <span style="font-family: arial; font-size: 14px; color: Black; font-weight:bold;">
                                             <a href="http://www.ossaarankings.com/docs/2015-16/Basketball/BK_2015-16_6AState.pdf?id=1" target="_blank">Class 6A</a>
                                            </span>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:table ID="Table5" width="100%" runat="server">
                                <asp:TableRow>
                                    <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                        <asp:Label ID="lblClass5AHeader" runat="server" CssClass="labelHeader" Width="100%" Height="26px" Font-Names="Passion+One"></asp:Label>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top">
                                        <asp:Table ID="lbl5A" runat="server">
                                            <asp:TableRow HorizontalAlign="Center">
                                                <asp:TableCell HorizontalAlign="Center" style="padding-right:10px;"><asp:Label ID="lblBoys5A" runat="server" Text=""></asp:Label></asp:TableCell>
                                                <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblGirls5A" runat="server" Text=""></asp:Label></asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
                                <asp:TableRow Visible="false">
                                    <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                        <span style="font-family: arial; font-size: 14px; color: Black; font-weight:bold;">CLASS 5A STATE CHAMPIONSHIPS BRACKETS<br />
                                        </span>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow Visible="false">
                                    <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                        <span style="font-family: arial; font-size: 14px; color: Black; font-weight:bold;">
                                        <a href="http://www.ossaarankings.com/docs/2015-16/Basketball/BK_2015-16_5AState.pdf?id=1" target="_blank">Class 5A</a>
                                        </span>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:table>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                        <asp:table ID="Table4" width="100%" runat="server">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                    <asp:Label ID="lblClass4AHeader" runat="server" CssClass="labelHeader" Width="100%" Height="26px" Font-Names="Passion+One"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top">
                                    <asp:Table ID="lbl4A" runat="server">
                                        <asp:TableRow HorizontalAlign="Center">
                                            <asp:TableCell HorizontalAlign="Center" style="padding-right:10px;"><asp:Label ID="lblBoys4A" runat="server" Text=""></asp:Label></asp:TableCell>
                                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblGirls4A" runat="server" Text=""></asp:Label></asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
                            <asp:TableRow Visible="false">
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: arial; font-size: 14px; color: Black; font-weight:bold;">CLASS 4A STATE CHAMPIONSHIPS BRACKETS<br />
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Visible="false">
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: arial; font-size: 14px; color: Black; font-weight:bold;">
                                    <a href="http://www.ossaarankings.com/docs/2015-16/Basketball/BK_2015-16_4AState.pdf?id=1" target="_blank">Class 4A</a>
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:table>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                        <asp:table ID="Table3" width="100%" runat="server">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                    <asp:Label ID="lblClass3AHeader" runat="server" CssClass="labelHeader" Width="100%" Height="26px" Font-Names="Passion+One"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top">
                                    <asp:Table ID="lbl3A" runat="server">
                                        <asp:TableRow HorizontalAlign="Center">
                                            <asp:TableCell HorizontalAlign="Center" style="padding-right:10px;"><asp:Label ID="lblBoys3A" runat="server" Text=""></asp:Label></asp:TableCell>
                                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblGirls3A" runat="server" Text=""></asp:Label></asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
                            <asp:TableRow Visible="false">
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: arial; font-size: 14px; color: Black; font-weight:bold;">CLASS 3A STATE CHAMPIONSHIPS BRACKETS<br />
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Visible="false">
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: arial; font-size: 14px; color: Black; font-weight:bold;">
                                    <a href="http://www.ossaarankings.com/docs/2015-16/Basketball/BK_2015-16_3AState.pdf?id=1" target="_blank">Class 3A</a>
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:table>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                        <asp:table ID="Table2" width="100%" runat="server">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                    <asp:Label ID="lblClass2AHeader" runat="server" CssClass="labelHeader" Width="100%" Height="26px" Font-Names="Passion+One"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top">
                                    <asp:Table ID="lbl2A" runat="server">
                                        <asp:TableRow HorizontalAlign="Center">
                                            <asp:TableCell HorizontalAlign="Center" style="padding-right:10px;"><asp:Label ID="lblBoys2A" runat="server" Text=""></asp:Label></asp:TableCell>
                                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblGirls2A" runat="server" Text=""></asp:Label></asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
                            <asp:TableRow Visible="false">
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: arial; font-size: 14px; color: Black; font-weight:bold;">CLASS 2A STATE CHAMPIONSHIPS BRACKETS<br />
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow Visible="false">
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: arial; font-size: 14px; color: Black; font-weight:bold;">
                                    <a href="http://www.ossaarankings.com/docs/2015-16/Basketball/BK_2015-16_2AState.pdf?id=1" target="_blank">Class 2A</a>
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:table>
                    </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
</div>
</form>
</body>
</html>







