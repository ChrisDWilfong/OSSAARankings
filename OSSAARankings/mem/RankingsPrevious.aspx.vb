﻿Public Class RankingsPrevious
    Inherits System.Web.UI.Page

    Dim strSportIDLocal As String
    Dim strSportGenderKeyLocal As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Also Update RankingsPrevious.aspx and RankingsOthers.aspx...
        If Session("event") = "RankingsPrevious1" Then
            ' Get the dual sportID...
            strSportIDLocal = Session("memgSportID1")
            strSportGenderKeyLocal = Session("memgSportGenderKey1")
            If cboAction.SelectedValue = "" Or Not IsPostBack Then
                cboAction.SelectedValue = "RankingsPrevious1"
            End If
        Else
            If Session("memgSportID") Is Nothing Then
                strSportIDLocal = ""
                strSportGenderKeyLocal = ""
            Else
                strSportIDLocal = Session("memgSportID")
                strSportGenderKeyLocal = Session("memgSportGenderKey")
            End If
            If cboAction.SelectedValue = "" Or Not IsPostBack Then
                cboAction.SelectedValue = "RankingsPrevious"
            End If
        End If


        If Session("memgSchool") = "" Then
            Response.Redirect("Login.aspx")
        End If

        If Not IsPostBack Then
            If Session("memgNoOfSports") > 1 Then
                cboSports.Visible = True
                ' Load the Sports...
                cboSports.DataSource = Session("memdsCoachesSports")
                cboSports.DataBind()
                cboSports.Items.Insert(0, "Select Sport...")
                cboSports.SelectedValue = Session("memcboSports")
            Else
                cboSports.Visible = False
                RefreshRankingsInfo()
            End If
            ' If there is no district for this team, don't show MY DISTRICT...
            If Session("memgDistrict") = 0 Then
                cboAction.Items.FindByValue("MyDistrict").Enabled = False
            End If
        End If

        If Request.UserAgent.Contains("android") Or Request.UserAgent.Contains("iphone") Or Request.UserAgent.Contains("blackberry") Or Request.UserAgent.Contains("mobile") Or Request.UserAgent.Contains("palm") Then

        Else

        End If

        ' Get Coaches Header information...
        If Not IsPostBack Then
            Me.lblCoach.Text = Session("memgCoachName")
            If Session("memgSportID") Is Nothing Then
                lblSchool.Text = Session("memgSchool")
                lblSport.Text = "No Sport Selected"
            Else
                RefreshCoachesHeader()
            End If

            LoadDropDowns()
        End If

        ' 12/2/2013 added...
        Dim sid As String = ""
        sid = Session("memgSportID")
        If sid.Contains("Wrestling") Then
            cboAction.Items.FindByValue("RankingsOthers1").Enabled = True
            cboAction.Items.FindByValue("RankingsPrevious1").Enabled = True
        Else
            cboAction.Items.FindByValue("RankingsOthers1").Enabled = False
            cboAction.Items.FindByValue("RankingsPrevious1").Enabled = False
        End If

        ' Turn ON/OFF E-W Rankings...
        If sid.Contains("Basketball") Then
            If ConfigurationManager.AppSettings("showBasketballEWRankings") = 1 Then
                If sid.Contains("BasketballBoys6A") Or sid.Contains("BasketballBoys5A") Or sid.Contains("BasketballGirls6A") Or sid.Contains("BasketballGirls5A") Then
                    cboAction.Items.FindByValue("EnterRankingsEW").Enabled = True
                Else
                    cboAction.Items.FindByValue("EnterRankingsEW").Enabled = False
                End If
            Else
                cboAction.Items.FindByValue("EnterRankingsEW").Enabled = False
            End If
        Else
            cboAction.Items.FindByValue("EnterRankingsEW").Enabled = False
        End If

    End Sub


    Public Sub RefreshRankingsInfo()
        ' 8/30/2013 added...
        ' GET RANKINGS INFO...
        If clsRankings.ShowRankingsStatus = False Then
            Session("memgCurrentWeekIDRank") = 0
            Session("memgCurrentWeekIDDisplay") = 0
            Session("memgCurrentWeekIDPeriod") = 0
            Session("memgCurrentWeekID12to4") = 0
            Session("memgRankingsThisSeason") = 0
            Session("memgCurrentWeekNoDisplay") = 0
            Session("memgCurrentWeekNoRank") = 0
            Session("memgPreviousWeekID") = 0
            Session("memgRankingsStatus") = ""
            Session("memgSplitWeek") = 0
            Session("memgSplitWeek12to4") = 0
            Session("memgSplitWeekDisplay") = 0
        Else
            If strSportIDLocal Is Nothing Then
                Session("memgCurrentWeekIDRank") = 0
                Session("memgCurrentWeekIDDisplay") = 0
                Session("memgCurrentWeekIDPeriod") = 0
                Session("memgCurrentWeekID12to4") = 0
                Session("memgRankingsThisSeason") = 0
            Else
                Session("memgCurrentWeekIDRank") = clsRankings.GetCurrentRankingWeekIDRankingWindow(strSportIDLocal, Now.ToString)
                Session("memgCurrentWeekIDDisplay") = clsRankings.GetCurrentRankingWeekIDDisplayWindow(strSportIDLocal, Now.ToString)
                Session("memgCurrentWeekIDPeriod") = clsRankings.GetCurrentRankingWeekIDPeriodWindow(strSportIDLocal, Now.ToString)
                Session("memgCurrentWeekID12to4") = clsRankings.GetCurrentRankingWeekID12to4(strSportIDLocal, Now.ToString)
                Session("memgRankingsThisSeason") = clsRankings.GetCurrentRankCount(Session("memgTeamID"))
            End If
            'Session("memgCurrentWeekID") = clsRankings.GetCurrentRankingWeekID(Session("memgSportID"), "8/17/2013")
            Session("memgCurrentWeekNoDisplay") = clsRankings.GetCurrentRankingintWeekNo(Session("memgCurrentWeekIDDisplay"))
            Session("memgCurrentWeekNoRank") = clsRankings.GetCurrentRankingintWeekNo(Session("memgCurrentWeekIDRank"))
            Session("memgPreviousWeekID") = clsRankings.GetPreviousRankingWeekID(strSportIDLocal, clsFunctions.GetCurrentYear, Session("memgCurrentWeekNoDisplay"))
            Session("memgRankingsStatus") = clsRankings.GetRankingsStatus(strSportIDLocal, Session("memgTeamID"), Session("memgCurrentWeekIDRank"), Session("memgCurrentWeekIDDisplay"), Session("memgCurrentWeekIDPeriod"), Session("memgCurrentWeekNoRank"), Session("memgCurrentWeekNoDisplay"), Session("memgPreviousWeekID"), Session("memgCurrentWeekID12to4"), Session("memgRankingsThisSeason"), Session("event"))
            Session("memgSplitWeek") = clsRankings.GetSplitWeek(Session("memgCurrentWeekIDRank"))
            Session("memgSplitWeek12to4") = clsRankings.GetSplitWeek(Session("memgCurrentWeekID12to4"))
            Session("memgSplitWeekDisplay") = clsRankings.GetSplitWeek(Session("memgCurrentWeekIDDisplay"))
        End If
    End Sub

    Public Sub RefreshCoachesHeader()
        Me.lblCoach.Text = Session("memgCoachName")
        If Session("memgSportID") Is Nothing Then
            lblSchool.Text = Session("memgSchool")
            lblSport.Text = "No Sport Selected"
        Else
            Dim strSportID As String = Session("memgSportID")
            If Session("memgShowRecord") = 1 Then
                If Session("memgShowRanking") = 0 Then
                    Me.lblSchool.Text = Session("memgSchool") & " (" & Session("memgWL") & ")"
                ElseIf Session("memgCurrentRanking") = 0 Then
                    Me.lblSchool.Text = Session("memgSchool") & " (" & Session("memgWL") & ") Not Ranked"
                Else
                    Me.lblSchool.Text = Session("memgSchool") & " (" & Session("memgWL") & ") #" & Session("memgCurrentRanking")
                End If
            Else
                If Session("memgShowRanking") = 0 Then
                    Me.lblSchool.Text = Session("memgSchool")
                ElseIf Session("memgCurrentRanking") = 0 Then
                    Me.lblSchool.Text = Session("memgSchool") & " Not Ranked"
                Else
                    Me.lblSchool.Text = Session("memgSchool") & " #" & Session("memgCurrentRanking")
                End If
            End If

            Me.lblSport.Text = Session("memgSportWithClass")

            ' 12/2/2013 added...
            If Me.lblSport.Text.Contains("Wrestling") Then
                lblSport.Text = lblSport.Text & " - " & Session("memgSportWithClass1")
            End If

        End If
    End Sub

    Public Sub LoadDropDowns()
        Dim ds As DataSet
        Dim dsW As DataSet
        Dim objItem1 As New System.Web.UI.WebControls.ListItem

        ' Load Weeks for this sport/class...
        If Request.QueryString("admin") = 1 Then
            dsW = clsRankings.GetRankingsSchedule(strSportIDLocal, clsFunctions.GetCurrentYear, True)
        Else
            dsW = clsRankings.GetRankingsSchedule(strSportIDLocal, clsFunctions.GetCurrentYear, False)
        End If
        cboSelectWeek.DataSource = dsW
        cboSelectWeek.DataBind()

        objItem1.Value = 0
        objItem1.Text = "Select..."
        cboSelectWeek.Items.Insert(0, objItem1)

        If Me.lblSport.Text.Contains("Wrestling") Then
            Dim objItem1d As New System.Web.UI.WebControls.ListItem
            objItem1d.Value = 99969
            If cboAction.SelectedItem.Text.Contains("(Dual)") Then
                objItem1d.Text = "Wrestling Dual (Final 5 weeks)"
            Else
                objItem1d.Text = "Wrestling (Final 5 weeks)"
            End If
            cboSelectWeek.Items.Add(objItem1d)
        End If

        ' Load Schools for this class...
        ds = clsTeams.GetSportTeamsForClass(strSportIDLocal, clsFunctions.GetCurrentYear, Session("memgTeamID"), Session("event"), Session("memgPlayoffsRegionals"))
        Session("memdsClassTeamsOther") = ds

    End Sub

    Private Sub cmdGo_Click(sender As Object, e As System.EventArgs) Handles cmdGo.Click
        Dim strSportID As String = ""

        strSportID = Session("memgSportID")
        If cboSelectWeek.SelectedValue = 99969 Then
            If cboAction.SelectedItem.Text.Contains("(Dual)") Then
                strSportID = strSportID.Replace("Wrestling", "WrestlingDual")
                SQLDataSource1.SelectCommand = "SELECT *, '' AS WL, TotalPoints AS Points FROM ossaauser.viewWrestlingDualLast5WeeksOfRankings WHERE (sportID = '" & strSportID & "') ORDER BY TotalPoints DESC"
            Else
                strSportID = strSportID.Replace("WrestlingDual", "Wrestling")
                SQLDataSource1.SelectCommand = "SELECT *, '' AS WL, TotalPoints AS Points FROM ossaauser.viewWrestlingLast5WeeksOfRankings WHERE (sportID = '" & strSportID & "') ORDER BY TotalPoints DESC"
            End If
            SQLDataSource1.DataBind()
        Else
            SQLDataSource1.SelectCommand = "SELECT ID, WeekID, sportID, SportIDOLD, SchoolID, School, RankDate, TeamID, Rank, Points, NumOne, intYear, WL, intWeekNo, prevWeek FROM tblRankings WHERE WeekID = @WeekID ORDER BY Rank"
            SQLDataSource1.DataBind()
        End If
        GridView1.DataBind()

        ' E/W Rankings???
        If Session("memgPlayoffsRegionals") > 0 Then
            If strSportID.Contains("Basketball") Then
                GridView2.Visible = True
                lblHeader2.Visible = True
                SQLDataSource2.SelectCommand = "SELECT ID, WeekID, sportID, SportIDOLD, SchoolID, School, RankDate, TeamID, Rank, Points, NumOne, intYear, WL, intWeekNo, prevWeek FROM tblRankingsEW WHERE WeekID = @WeekID AND EW = " & Session("memgPlayoffsRegionals") & " ORDER BY Rank"
                SQLDataSource2.DataBind()
            Else
                lblHeader2.Visible = False
                GridView2.Visible = False
            End If
        Else
            lblHeader2.Visible = False
            GridView2.Visible = False
        End If

    End Sub

    Private Sub cboAction_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboAction.SelectedIndexChanged
        LoadAction(cboAction.SelectedValue)
    End Sub

    Private Sub cboSports_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboSports.SelectedIndexChanged
        ' If you change here, change in Home.aspx...
        Session("memgTeamID") = cboSports.SelectedValue
        Dim objTeam As New clsTeam(Session("memgTeamID"))
        Session("memgClass") = objTeam.getClass
        Session("memgSportGenderKey") = objTeam.getSportGenderKey
        Session("memgSportGenderKey1") = objTeam.getSportGenderKey1
        Session("memgSportDisplay") = objTeam.getSportGenderDisplay
        Session("memgSportWithClass") = objTeam.getSportWithClass
        Session("memgSportWithClass1") = objTeam.getSportWithClass1
        Session("memgSport") = objTeam.getSport
        Session("memgSportID") = objTeam.getSportID
        Session("memgSportID1") = objTeam.getSportID1
        Session("memgWL") = objTeam.getWL
        Session("memgDistrict") = objTeam.getDistrict
        Session("memgTeamPicture") = objTeam.getTeamPicture
        Session("memgShowRecord") = objTeam.getShowRecord
        Session("memgShowRanking") = objTeam.getShowRanking
        Session("memgResults") = objTeam.getResults
        Session("memgPostGender") = objTeam.getPostGender
        Session("memgMemberID") = objTeam.getMemberID          ' 8/23/2013 added...
        Session("memgPlayoffSchedule") = objTeam.getPlayoffSchedule         ' 11/4/2013 added...
        Session("memgPlayoffsState") = objTeam.getPlayoffsState
        Session("memgPlayoffsRegionals") = objTeam.getPlayoffsRegional
        RefreshCoachesHeader()
        Session("memcboSports") = cboSports.SelectedValue
        LoadAction(cboAction.SelectedValue)
    End Sub

    Public Sub LoadAction(strAction As String)
        Session("memsel") = strAction
        Response.Redirect("Home.aspx?sel=" & strAction)
    End Sub

    Private Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowIndex + 1 = 0 Then
        Else
            e.Row.Cells(0).Text = e.Row.RowIndex + 1
        End If
    End Sub
End Class