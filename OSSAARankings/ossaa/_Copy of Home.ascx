<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Home.ascx.vb" Inherits="OSSAARankings.Home2" %>
    <asp:Table ID="Table1" runat="server" Width="100%">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                  <asp:Label runat="server" Text="CLASS 6A-2A STATE BRACKETS" Font-Bold="true" Font-Names="Arial" Font-Size="Large"></asp:Label>
                  <img alt="" width="10" height="10" src="bps.png" />&nbsp;<a href="http://ossaarankings.mobi/docs/2015-16/Basketball/BK_2015-16_6AState.pdf?id=11" target="_blank" ><span style="font-family: Arial; font-size:medium;">CLASS 6A</span></a>&nbsp;
                  <img alt="" width="10" height="10" src="bps.png" />&nbsp;<a href="http://ossaarankings.mobi/docs/2015-16/Basketball/BK_2015-16_5AState.pdf?id=11" target="_blank" ><span style="font-family: Arial; font-size:medium;">CLASS 5A</span></a>&nbsp;
                  <img alt="" width="10" height="10" src="bps.png" />&nbsp;<a href="http://ossaarankings.mobi/docs/2015-16/Basketball/BK_2015-16_4AState.pdf?id=11" target="_blank" ><span style="font-family: Arial; font-size:medium;">CLASS 4A</span></a>&nbsp;
                  <img alt="" width="10" height="10" src="bps.png" />&nbsp;<a href="http://ossaarankings.mobi/docs/2015-16/Basketball/BK_2015-16_3AState.pdf?id=11" target="_blank" ><span style="font-family: Arial; font-size:medium;">CLASS 3A</span></a>&nbsp;
                  <img alt="" width="10" height="10" src="bps.png" />&nbsp;<a href="http://ossaarankings.mobi/docs/2015-16/Basketball/BK_2015-16_2AState.pdf?id=11" target="_blank" ><span style="font-family: Arial; font-size:medium;">CLASS 2A</span></a>&nbsp;
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <a href="http://ossaarankings.mobi" target="_blank"><h1><span style="color:Blue;">TO GO TO OSSAARANKINGS.COM (Click Here)</span></h1></a>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <iframe scrolling="auto" height="450px" src="../sb/StateScoreboardBasketball.aspx" width="920px" frameborder="0"></iframe>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <a href="http://ossaarankings.mobi/membership/MemberLogin.aspx" target="_blank"><h2><span style="color:Blue;">CLICK HERE FOR OSSAA MEMBERSHIP LOGIN</span></h2></a>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Width="98%">
            <asp:TableCell ColumnSpan="3">
                <h2>CLASS 6A-2A STATE TOURNAMENT INFORMATION</h2>
                <img alt="" width="10" height="10" src="bps.png" style="border:none;" />&nbsp;<span style="font-family: Arial; font-size: 13px;">Class 6A-5A : On-line Ticket Sales at the ORU Mabee Center (Tulsa) <a href="https://mabeecenter.com/event/ossaa-state-basketball-tournament/" target="_blank">Order Tickets</a></span><br />
                <img alt="" width="10" height="10" src="bps.png" style="border:none;" />&nbsp;<span style="font-family: Arial; font-size: 13px;">Class 4A-3A-2A : You may purchase Advance Online Tickets (print at home) for any session at the State Fair Arena only at <a href="http://www.okstatefair.com" target="_blank">www.okstatefair.com</a> You may purchase  a three-day all session or two-day (Friday & Saturday) all session ticket at the State Fair Arena Box Office that is only good at the State Fair Arena.</span><br />
                <h2>CLASS 6A-2A STATE TOURNAMENT BROADCAST SCHEDULE</h2>
                <h3>FRIDAY GAMES</h3>
                <img alt="" width="10" height="10" src="bps.png" style="border:none;" />&nbsp;<span style="font-family: Arial; font-size: 13px;">All Class 4A and Class 2A Boys and Girls games from the State Fair Arena will be Live Streamed on <a href="http://www.coxhshub.com" target="_blank">www.coxhshub.com</a></span><br />
                <img alt="" width="10" height="10" src="bps.png" style="border:none;" />&nbsp;<span style="font-family: Arial; font-size: 13px;">All Class 6A and Class 5A Boys and Girls games from Oral Roberts University will be live Streamed on <a href="http://www.coxhshub.com" target="_blank">www.coxhshub.com</a> and the 4:30, 6:00, 7:30 and 9:00 games televised live on the Cox channel.</span><br />
                <img alt="" width="10" height="10" src="bps.png" style="border:none;" />&nbsp;<span style="font-family: Arial; font-size: 13px;">Both Class 3A Boys games at Yukon High School will be Live Streamed on pay-per-view at <a href="http://www.NFHSNetwork.com" target="_blank">www.NFHSNetwork.com</a></span><br />
                <img alt="" width="10" height="10" src="bps.png" style="border:none;" />&nbsp;<span style="font-family: Arial; font-size: 13px;">Both Class 3A Girls games at Carl Albert High School will be Live Streamed on pay-per-view at <a href="http://www.NFHSNetwork.com" target="_blank">www.NFHSNetwork.com</a></span>
                <h3>SATURDAY GAMES</h3>
                <img alt="" width="10" height="10" src="bps.png" style="border:none;" />&nbsp;<span style="font-family: Arial; font-size: 13px;">All Class 6A and Class 5A Boys and Girls State Finals at Oral Roberts University will be televised live on the Cox Channel and Live Streamed on <a href="http://www.coxhshub.com" target="_blank">www.coxhshub.com</a></span><br />
                <img alt="" width="10" height="10" src="bps.png" style="border:none;" />&nbsp;<span style="font-family: Arial; font-size: 13px;">All Class 4A, Class 3A and Class 2A Boys and Girls State Finals at State Fair Arena will be televised live on FOX Sports Oklahoma.</span>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Width="98%">
            <asp:TableCell Width="33%" VerticalAlign="Top">
                <asp:PlaceHolder ID="PlaceHolder1a" runat="server"  >
                </asp:PlaceHolder>
            </asp:TableCell>
            <asp:TableCell Width="33%" VerticalAlign="Top">
                <asp:PlaceHolder ID="PlaceHolder2a" runat="server" >
                </asp:PlaceHolder>
            </asp:TableCell>
            <asp:TableCell Width="33%" VerticalAlign="Top">
                <asp:PlaceHolder ID="PlaceHolder3a" runat="server" >
                </asp:PlaceHolder>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>