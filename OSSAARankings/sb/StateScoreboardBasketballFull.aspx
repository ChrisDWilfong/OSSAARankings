<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StateScoreboardBasketballFull.aspx.vb" Inherits="OSSAARankings.StateScoreboardBasketballFull" ClientTarget="uplevel"  %>
<%@ Register Assembly="Infragistics4.Web.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="css/stateSBMOBI.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<link href="css/ajax.css" rel="stylesheet" type="text/css" />
</style>
<head runat="server">
    <title>OSSAA Basketball State Tournament Scoreboard</title>
    <link href='http://fonts.googleapis.com/css?family=Oswald' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Exo' rel='stylesheet' type='text/css' />
</head>
<body bgcolor="#5c5040">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AllowCustomErrorsRedirect="False">
    </asp:ScriptManager>
    <asp:table width="800px" Height="680px" runat="server">
        <asp:TableRow Width="100%" VerticalAlign="Bottom">
            <asp:TableCell>
                <asp:Label ID="lblHeader" runat="server" CssClass="labelHeaderMain" Text="2016 OSSAA BASKETBALL STATE CHAMPIONSHIPS SCOREBOARD" Height="30px" Font-Size="22px" Width="100%" BorderColor="Black" BorderWidth="1px"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow VerticalAlign="Top">
            <asp:TableCell>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <ig:WebTab ID="WebTab1" runat="server" width="790px" Height="450px" DisplayMode="MultiRow" BackColor="#5C5040" SelectedIndex="0" StyleSetName="Windows7">
            <Tabs>
                <ig:ContentTabItem runat="server" Text="CLASS 6A" EnableAjax="True" TabSize="100px" Enabled="True">
                    <Template>
                        <asp:table ID="Table6" width="100%" runat="server">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                    <asp:Label ID="lblClass6AHeader" runat="server" CssClass="labelHeader" Width="100%" Height="30px"></asp:Label>
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
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: Exo; font-size: 12px; color: Black; font-weight:bold;">CLASS 6A STATE CHAMPIONSHIPS BRACKETS<br />
                                    <asp:Label ID="Label14" runat="server" Text="Boys : "></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_6ABEast.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">East</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_6ABWest.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">West</a>&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label15" runat="server" Text="Girls : "></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_6AGEast.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">East</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_6AGWest.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">West</a>&nbsp;&nbsp;&nbsp;
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: arial; font-size: 12px; color: Black; font-weight:bold;">
                                    <asp:Label ID="Label18" runat="server" Text="STATE BRACKETS : " Font-Names="Exo" Font-Size="12px"></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_6AStateBrackets.pdf" target="_blank" style="font-family:Exo;font-size:12px;">Class 6A</a>
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:table>
                   </Template>
                </ig:ContentTabItem>

                <ig:ContentTabItem runat="server" Text="CLASS 5A" EnableAjax="True" TabSize="100px" Enabled="True">
                    <Template>
                        <asp:table ID="Table5" width="100%" runat="server">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                    <asp:Label ID="lblClass5AHeader" runat="server" CssClass="labelHeader" Width="100%" Height="30px"></asp:Label>
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
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: Exo; font-size: 12px; color: Black; font-weight:bold;">CLASS 5A STATE CHAMPIONSHIPS BRACKETS<br />
                                    <asp:Label ID="Label12" runat="server" Text="Boys : "></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_5ABEast.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">East</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_5ABWest.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">West</a>&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label13" runat="server" Text="Girls : "></asp:Label>
                                    <a href="http://www.ossaaonline.com/docs/2014-15/Basketball/BK_2014-15_5AGEast.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">East</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaaonline.com/docs/2014-15/Basketball/BK_2014-15_5AGWest.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">West</a>&nbsp;&nbsp;&nbsp;
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: arial; font-size: 12px; color: Black; font-weight:bold;">
                                    <asp:Label ID="Label17" runat="server" Text="STATE BRACKETS : " Font-Names="Exo" Font-Size="12px"></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_5AStateBrackets.pdf" target="_blank" style="font-family:Exo;font-size:12px;">Class 5A</a>
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:table>
                   </Template>
                </ig:ContentTabItem>

                <ig:ContentTabItem runat="server" Text="CLASS 4A" EnableAjax="True" TabSize="100px" Enabled="True">
                    <Template>
                        <asp:table ID="Table4" width="100%" runat="server">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                    <asp:Label ID="lblClass4AHeader" runat="server" CssClass="labelHeader" Width="100%" Height="30px"></asp:Label>
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
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: Exo; font-size: 12px; color: Black; font-weight:bold;">CLASS 4A STATE CHAMPIONSHIPS BRACKETS<br />
                                    <asp:Label ID="Label10" runat="server" Text="Boys : "></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_4ABArea1.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">Area I</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_4ABArea2.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">Area II</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_4ABArea3.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">Area III</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_4ABArea4.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">Area IV</a>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label11" runat="server" Text="Girls : "></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_4AGArea1.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">Area I</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_4ABArea2.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">Area II</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_4ABArea3.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">Area III</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_4ABArea4.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">Area IV</a>&nbsp;&nbsp;
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: arial; font-size: 12px; color: Black; font-weight:bold;">
                                    <asp:Label ID="Label21" runat="server" Text="STATE BRACKET : " Font-Names="Exo" Font-Size="12px"></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_4AStateBrackets.pdf" target="_blank" style="font-family:Exo;font-size:12px;">Class 4A</a>
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:table>
                   </Template>
                </ig:ContentTabItem>


                <ig:ContentTabItem runat="server" Text="CLASS 3A" EnableAjax="True" TabSize="100px" Enabled="True">
                    <Template>
                        <asp:table ID="Table3" width="100%" runat="server">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                    <asp:Label ID="lblClass3AHeader" runat="server" CssClass="labelHeader" Width="100%" Height="30px"></asp:Label>
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
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: Exo; font-size: 12px; color: Black; font-weight:bold;">CLASS 3A STATE CHAMPIONSHIPS BRACKETS<br />
                                    <asp:Label ID="Label8" runat="server" Text="Boys : "></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_3ABArea1.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">Area I</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_3ABArea2.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">Area II</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_3ABArea3.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">Area III</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_3ABArea4.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">Area IV</a>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label9" runat="server" Text="Girls : "></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_3AGArea1.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">Area I</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_3AGArea2.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">Area II</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_3AGArea3.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">Area III</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_3AGArea4.pdf" target="_blank" target="_blank" style="font-family:Exo;font-size:12px;">Area IV</a>&nbsp;&nbsp;
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: arial; font-size: 12px; color: Black; font-weight:bold;">
                                    <asp:Label ID="Label20" runat="server" Text="STATE BRACKET : " Font-Names="Exo" Font-Size="12px"></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_3AStateBrackets.pdf" target="_blank" style="font-family:Exo;font-size:12px;">Class 3A</a>
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:table>
                   </Template>
                </ig:ContentTabItem>

                <ig:ContentTabItem runat="server" Text="CLASS 2A" EnableAjax="True" TabSize="100px" Enabled="True">
                    <Template>
                        <asp:table ID="Table2" width="100%" runat="server">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                    <asp:Label ID="lblClass2AHeader" runat="server" CssClass="labelHeader" Width="100%" Height="30px"></asp:Label>
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
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: Exo; font-size: 12px; color: Black; font-weight:bold;">CLASS 2A STATE CHAMPIONSHIPS BRACKETS<br />
                                    <asp:Label ID="Label6" runat="server" Text="Boys : "></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_2ABArea1.pdf" target="_blank" style="font-family:Exo;font-size:12px;">Area I</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_2ABArea2.pdf" target="_blank" style="font-family:Exo;font-size:12px;">Area II</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_2ABArea3.pdf" target="_blank" style="font-family:Exo;font-size:12px;">Area III</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_2ABArea4.pdf" target="_blank" style="font-family:Exo;font-size:12px;">Area IV</a>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label7" runat="server" Text="Girls : "></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_2AGArea1.pdf" target="_blank" style="font-family:Exo;font-size:12px;">Area I</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_2AGArea2.pdf" target="_blank" style="font-family:Exo;font-size:12px;">Area II</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_2AGArea3.pdf" target="_blank" style="font-family:Exo;font-size:12px;">Area III</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_2AGArea4.pdf" target="_blank" style="font-family:Exo;font-size:12px;">Area IV</a>&nbsp;&nbsp;
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: arial; font-size: 12px; color: Black; font-weight:bold;">
                                    <asp:Label ID="Label19" runat="server" Text="STATE BRACKET : " Font-Names="Exo" Font-Size="12px"></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_2AStateBrackets.pdf" target="_blank" style="font-family:Exo;font-size:12px;">Class 2A</a>
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:table>
                   </Template>
                </ig:ContentTabItem>


                <ig:ContentTabItem runat="server" Text="CLASS A" EnableAjax="True" TabSize="90px" Enabled="true" Font-Size="Large">
                    <Template>
                        <asp:table ID="Table1" width="100%" runat="server">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                    <asp:Label ID="lblClassAHeader" runat="server" CssClass="labelHeader" Width="100%" Height="30px"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top">
                                    <asp:Table ID="tblA" runat="server">
                                        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Top">
                                            <asp:TableCell HorizontalAlign="Center" style="padding-right:10px;"><asp:Label ID="lblBoysA" runat="server" Text=""></asp:Label></asp:TableCell>
                                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblGirlsA" runat="server" Text=""></asp:Label></asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: Exo; font-size: 12px; color: Black; font-weight:bold;">CLASS A STATE CHAMPIONSHIPS BRACKETS<br />
                                    <asp:Label ID="Label1" runat="server" Text="Boys : " Font-Names="Exo" Font-Size="12px"></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_ABArea1.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Area I</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_ABArea2.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Area II</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_ABArea3.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Area III</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_ABArea4.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Area IV</a>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label3" runat="server" Text="Girls : " Font-Names="Exo" Font-Size="14px"></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_AGArea1.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Area I</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_AGArea1.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Area II</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_AGArea1.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Area III</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_AGArea1.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Area IV</a>&nbsp;&nbsp;
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: Exo; font-size: 12px; color: Black; font-weight:bold;">
                                    <asp:Label ID="Label2" runat="server" Text="STATE BRACKET : " Font-Names="Exo" Font-Size="12px"></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_AStateBrackets.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Class A</a>
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:table>
                   </Template>
                </ig:ContentTabItem>
                <ig:ContentTabItem runat="server" Text="CLASS B" EnableAjax="True" TabSize="90px" Enabled="true">
                    <Template>
                        <asp:table ID="Table7" width="100%" runat="server">
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                    <asp:Label ID="lblClassBHeader" runat="server" CssClass="labelHeader" Width="100%" Height="30px"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top">
                                    <asp:Table ID="lblB" runat="server">
                                        <asp:TableRow HorizontalAlign="Center">
                                            <asp:TableCell HorizontalAlign="Center" style="padding-right:10px;"><asp:Label ID="lblBoysB" runat="server" Text=""></asp:Label></asp:TableCell>
                                            <asp:TableCell HorizontalAlign="Center"><asp:Label ID="lblGirlsB" runat="server" Text=""></asp:Label></asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow><asp:TableCell ColumnSpan="2"><hr /></asp:TableCell></asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: Exo; font-size: 12px; color: Black; font-weight:bold;">CLASS B STATE CHAMPIONSHIPS BRACKETS<br />
                                    <asp:Label ID="Label4" runat="server" Text="Boys : " Font-Names="Exo" Font-Size="12px"></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_BBArea1.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Area I</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_BBArea2.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Area II</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_BBArea3.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Area III</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_BBArea4.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Area IV</a>&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label5" runat="server" Text="Girls : " Font-Names="Exo" Font-Size="14px"></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_BGArea1.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Area I</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_BGArea2.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Area II</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_BGArea3.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Area III</a>&nbsp;&nbsp;&nbsp;
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_BGArea4.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Area IV</a>&nbsp;&nbsp;&nbsp;
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" style="padding-left:20px;" HorizontalAlign="Center">
                                    <span style="font-family: Exo; font-size: 12px; color: Black; font-weight:bold;">
                                    <asp:Label ID="Label16" runat="server" Text="STATE BRACKET : " Font-Names="Exo" Font-Size="12px"></asp:Label>
                                    <a href="http://www.ossaa.net/docs/2016-17/Basketball/BK_2016-17_BStateBrackets.pdf?id=24" target="_blank" style="font-family:Exo;font-size:12px;">Class B</a>
                                    </span>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:table>
                   </Template>
                </ig:ContentTabItem>

            </Tabs>
            <ContentPane>
                <RoundedBackground Enabled="True" />
            </ContentPane>
            <PostBackOptions EnableAjax="True" />
        </ig:WebTab>
    </ContentTemplate>
    </asp:UpdatePanel>
    </asp:TableCell>
    </asp:TableRow>
     </asp:table>
    </form>
</body>
</html>
