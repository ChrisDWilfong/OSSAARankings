<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StateScoreboardSlowPitch.aspx.vb" Inherits="OSSAARankings.StateScoreboardSlowPitch" ClientTarget="uplevel"  %>
<%@ Register Assembly="Infragistics4.Web.v10.2, Version=10.2.20102.1011, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="css/stateSB.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<link href="css/ajax.css" rel="stylesheet" type="text/css" />
</style>
<head runat="server">
    <title>OSSAA Slow-Pitch State Tournament Scoreboard</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AllowCustomErrorsRedirect="False">
    </asp:ScriptManager>
    <asp:table width="900px" Height="360px" runat="server">
        <asp:TableRow Width="100%" VerticalAlign="Bottom">
            <asp:TableCell>
                <asp:Label ID="lblHeader" runat="server" CssClass="labelHeaderMain" Text="2016 OSSAA Slow-Pitch State Championships Scoreboard" Height="30px" Font-Size="22px" Width="100%" BorderColor="Black" BorderWidth="1px"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow VerticalAlign="Top">
            <asp:TableCell>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <ig:WebTab ID="WebTab1" runat="server" width="890px" Height="315px" DisplayMode="SingleRow" SelectedIndex="0" StyleSetName="Windows7">
            <Tabs>
                <ig:ContentTabItem runat="server" Text="<span style='font-size:18px;font-weight:bold;'>Class 6A</span>" EnableAjax="True" TabSize="100px">
                    <Template>
                        <asp:table ID="Table6" width="100%" runat="server">
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                    <asp:Label ID="lblClass6AHeader" runat="server" CssClass="labelHeaderMainGray" Width="100%" Height="30px"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top">
                                    <asp:Table ID="lbl6A" runat="server">
                                        <asp:TableRow HorizontalAlign="Center">
                                            <asp:TableCell HorizontalAlign="Center" style="padding-right:10px;"><asp:Label CssClass="labelSemi" ID="lblBoys6A" runat="server" Text=""></asp:Label></asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:table>
                   </Template>
                </ig:ContentTabItem>
                
                <ig:ContentTabItem runat="server" Text="<span style='font-size:18px;font-weight:bold;'>Class 5A</span>" EnableAjax="True" TabSize="100px">
                    <Template>
                        <asp:table ID="Table5" width="100%" runat="server">
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                    <asp:Label ID="lblClass5AHeader" runat="server" CssClass="labelHeaderMainGray" Width="100%" Height="30px"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top">
                                    <asp:Table ID="lbl5A" runat="server">
                                        <asp:TableRow HorizontalAlign="Center">
                                            <asp:TableCell HorizontalAlign="Center" style="padding-right:10px;"><asp:Label CssClass="labelSemi" ID="lblBoys5A" runat="server" Text=""></asp:Label></asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:table>
                   </Template>
                </ig:ContentTabItem>

                <ig:ContentTabItem runat="server" Text="<span style='font-size:18px;font-weight:bold;'>Class 4A</span>" EnableAjax="True" TabSize="100px" Font-Size="Larger">
                    <Template>
                        <asp:table ID="Table4" width="100%" runat="server">
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                    <asp:Label ID="lblClass4AHeader" runat="server" CssClass="labelHeaderMainGray" Width="100%" Height="30px"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top">
                                    <asp:Table ID="lbl4A" runat="server">
                                        <asp:TableRow HorizontalAlign="Center">
                                            <asp:TableCell HorizontalAlign="Center" style="padding-right:10px;"><asp:Label CssClass="labelSemi" ID="lblBoys4A" runat="server" Text=""></asp:Label></asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:table>
                   </Template>
                </ig:ContentTabItem>
                
                <ig:ContentTabItem runat="server" Text="<span style='font-size:18px;font-weight:bold;'>Class 3A</span>" EnableAjax="True" TabSize="100px">
                    <Template>
                        <asp:table ID="Table3" width="100%" runat="server">
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                    <asp:Label ID="lblClass3AHeader" runat="server" CssClass="labelHeaderMainGray" Width="100%" Height="30px"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top">
                                    <asp:Table ID="lbl3A" runat="server">
                                        <asp:TableRow HorizontalAlign="Center">
                                            <asp:TableCell HorizontalAlign="Center" style="padding-right:10px;"><asp:Label CssClass="labelSemi" ID="lblBoys3A" runat="server" Text=""></asp:Label></asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:table>
                   </Template>
                </ig:ContentTabItem>

                <ig:ContentTabItem runat="server" Text="<span style='font-size:18px;font-weight:bold;'>Class 2A</span>" EnableAjax="True" TabSize="100px">
                    <Template>
                        <asp:table ID="Table2" width="100%" runat="server">
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                    <asp:Label ID="lblClass2AHeader" runat="server" CssClass="labelHeaderMainGray" Width="100%" Height="30px"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top">
                                    <asp:Table ID="lbl2A" runat="server">
                                        <asp:TableRow HorizontalAlign="Center">
                                            <asp:TableCell HorizontalAlign="Center" style="padding-right:10px;"><asp:Label CssClass="labelSemi" ID="lblBoys2A" runat="server" Text=""></asp:Label></asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:table>
                   </Template>
                </ig:ContentTabItem>

                <ig:ContentTabItem runat="server" Text="<span style='font-size:18px;font-weight:bold;'>Class A</span>" EnableAjax="True" TabSize="100px">
                    <Template>
                        <asp:table ID="Table1" width="100%" runat="server">
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                                    <asp:Label ID="lblClassAHeader" runat="server" CssClass="labelHeaderMainGray" Width="100%" Height="30px"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow VerticalAlign="Top">
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top">
                                    <asp:Table ID="tblA" runat="server">
                                        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Top">
                                            <asp:TableCell HorizontalAlign="Center" style="padding-right:10px;"><asp:Label CssClass="labelSemi" ID="lblBoysA" runat="server" Text=""></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
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
