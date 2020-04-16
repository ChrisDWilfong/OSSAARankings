Public Class ucSportsListSchedulesPlayoffs
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' TURN THESE ON FOR THE PLAYOFFS : SCOREBOARD LINKS...

        If Not IsPostBack Then

            Dim objGroupBar1 As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
            objGroupBar1.Value = "FootballWeek1"
            objGroupBar1.Text = "Football Playoffs Week #1"
            objGroupBar1.NavigateUrl = "?sel=schedulesPlayoffs&spGK=FootballWeek1"
            ExplorerBarSportsListPlayoffs.Groups.Add(objGroupBar1)

            Dim objGroupBar2 As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
            objGroupBar2.Value = "FootballWeek2"
            objGroupBar2.Text = "Football Playoffs Week #2"
            objGroupBar2.NavigateUrl = "?sel=schedulesPlayoffs&spGK=FootballWeek2"
            ExplorerBarSportsListPlayoffs.Groups.Add(objGroupBar2)

            Dim objGroupBar3 As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
            objGroupBar3.Value = "FootballWeek3"
            objGroupBar3.Text = "Football Playoffs Week #3"
            objGroupBar3.NavigateUrl = "?sel=schedulesPlayoffs&spGK=FootballWeek3"
            ExplorerBarSportsListPlayoffs.Groups.Add(objGroupBar3)

            Dim objGroupBar4 As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
            objGroupBar4.Value = "FootballWeek4"
            objGroupBar4.Text = "Football Playoffs Week #4"
            objGroupBar4.NavigateUrl = "?sel=schedulesPlayoffs&spGK=FootballWeek4"
            ExplorerBarSportsListPlayoffs.Groups.Add(objGroupBar4)

            ' FALL SPORTS...
            'Dim objGroupBar As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
            'objGroupBar.Value = "FPSoftballDistricts"
            'objGroupBar.Text = "Fast-Pitch Districts"
            'objGroupBar.NavigateUrl = "?sel=schedulesPlayoffs&spGK=FPSoftballD"
            'ExplorerBarSportsListPlayoffs.Groups.Add(objGroupBar)

            'Dim objGroupBarA As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
            'objGroupBarA.Value = "FPSoftballRegionals"
            'objGroupBarA.Text = "Fast-Pitch Regionals"
            'objGroupBarA.NavigateUrl = "?sel=schedulesPlayoffs&spGK=FPSoftballR"
            'ExplorerBarSportsListPlayoffs.Groups.Add(objGroupBarA)

            'Dim objGroupBarA1 As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
            'objGroupBarA1.Value = "FPSoftballState"
            'objGroupBarA1.Text = "Fast-Pitch State"
            'objGroupBarA1.NavigateUrl = "http://www.ossaarankings.com/StateScoreboardFastPitch.aspx"
            'objGroupBarA1.Target = "_blank"
            'ExplorerBarSportsListPlayoffs.Groups.Add(objGroupBarA1)

            'Dim objGroupBar1 As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
            'objGroupBar1.Value = "BaseballFallDistricts"
            'objGroupBar1.Text = "Baseball (Fall) Districts"
            'objGroupBar1.NavigateUrl = "?sel=schedulesPlayoffs&spGK=BaseballFallD"
            'ExplorerBarSportsListPlayoffs.Groups.Add(objGroupBar1)

            'Dim objGroupBar1A As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
            'objGroupBar1A.Value = "BaseballFallRegionals"
            'objGroupBar1A.Text = "Baseball (Fall) Regionals"
            'objGroupBar1A.NavigateUrl = "?sel=schedulesPlayoffs&spGK=BaseballFallR"
            'ExplorerBarSportsListPlayoffs.Groups.Add(objGroupBar1A)

            'Dim objGroupBar1B As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
            'objGroupBar1B.Value = "BaseballFallState"
            'objGroupBar1B.Text = "Baseball (Fall) State"
            'objGroupBar1B.NavigateUrl = "http://www.ossaarankings.com/StateScoreboardFallBaseball.aspx"
            'objGroupBar1B.Target = "_blank"
            'ExplorerBarSportsListPlayoffs.Groups.Add(objGroupBar1B)

            'Dim objGroupBarVB As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
            'objGroupBarVB.Value = "VolleyballState"
            'objGroupBarVB.Text = "Volleyball State"
            'objGroupBarVB.NavigateUrl = "http://www.ossaarankings.com/StateScoreboardVolleyball.aspx"
            'objGroupBarVB.Target = "_blank"
            'ExplorerBarSportsListPlayoffs.Groups.Add(objGroupBarVB)

        End If
    End Sub

End Class