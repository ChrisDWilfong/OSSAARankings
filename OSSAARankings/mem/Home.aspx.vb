Partial Class Home
    Inherits System.Web.UI.Page

    Private Sub Home_Error(sender As Object, e As System.EventArgs) Handles Me.Error
        On Error Resume Next
        Dim objErr As Exception = Server.GetLastError.GetBaseException
        Dim strSQL As String

        strSQL = "INSERT INTO dbo.Errors (errDescription, URL, RequestMethod, HostAddress, UserAgent, AllHTTP) VALUES ('" & objErr.Message.Replace("'", "") & "', '" & Request.Url.ToString & "', '" & Request.ServerVariables("REQUEST_METHOD") & "', '" & Request.ServerVariables("REMOTE_ADDR") & "', '" & Session("memgUserName") & "', '" & objErr.StackTrace.ToString & "')"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Page.ClientTarget = "Uplevel"           ' Added 11/20/2013 to resolve IE 11 compatibility problem...

        ' Footer content for Coaches...
        Dim strFooter As String = ""
        'strFooter = strFooter & "<strong>FIRST RANKINGS FOR SWIMMING : </strong>OPEN Friday NOVEMBER 11th @ NOON<br>"
        'strFooter = strFooter & "<strong>FIRST RANKINGS FOR BASKETBALL : </strong>OPEN Friday NOVEMBER 18th @ NOON<br>"
        'strFooter = strFooter & "<strong>FIRST RANKINGS FOR WRESTLING : </strong>OPEN Friday NOVEMBER 25th @ NOON<br>"
        'strFooter = strFooter & "<strong>FOR A COMPLETE SCHEDULE, SELECT <i>Rankings Schedule</i> ABOVE.<br><br>"
        Me.lblFooter.Text = strFooter

        If Session("memgSchool") = "" Then
            Response.Redirect("Login.aspx")
        ElseIf Session("memgPassword") = "PASSWORD" Then
            Response.Redirect("LoginChange.aspx")
        End If

        If Not IsPostBack Then

            Session("RefreshRankingsList") = 0

            If Session("memgNoOfSports") > 1 Then
                cboSports.Visible = True
                ' Load the Sports...
                cboSports.DataSource = Session("memdsCoachesSports")
                cboSports.DataBind()
                cboSports.Items.Insert(0, "Select Sport...")
                cboSports.SelectedValue = Session("memcboSports")
                HideShowActions(Session("memgTeamID"))                  ' Added 12/17/2014...
            Else
                cboSports.Visible = False
                Session("memgCurrentRanking") = clsRankings.GetCurrentRank(Session("memgSportID"), Session("memgTeamID"), Now)
                HideShowActions(Session("memgTeamID"))
            End If

            ' If there is no district for this team, don't show MY DISTRICT...
            If Session("memgDistrict") = 0 Then
                cboAction.Items.FindByValue("MyDistrict").Enabled = False
            End If

            ' Added 10/10/2013...
            ' Added 11/26/2013 (Enter Rankings (Dual))...
            Dim sid As String = ""
            sid = Session("memgSportID")
            If sid Is Nothing Then sid = "Ellen"

            GetOfficialsHyperlink(sid)

            If clsRankings.ShowRankingsStatus Then
                If sid.Contains("Golf") Or sid.Contains("Track") Or sid.Contains("Soccer") Or sid.Contains("Tennis") Then    ' CDW added 3/30/2017...

                Else
                    cboAction.Items.FindByValue("EnterRankings").Enabled = True
                End If
                If InStr(Session("memgSportID"), "Wrestling") > 0 Then
                    If Session("memgSplitWeek") = 1 Then
                        cboAction.Items.FindByValue("EnterRankings1").Enabled = False
                        cboAction.Items.FindByValue("EnterRankings8").Enabled = True
                        cboAction.Items.FindByValue("EnterRankings8").Text = "Enter Rankings (Dual-8)"
                        cboAction.Items.FindByValue("EnterRankings").Text = "Enter Rankings (Tournament)"
                    Else
                        cboAction.Items.FindByValue("EnterRankings8").Enabled = False
                        cboAction.Items.FindByValue("EnterRankings1").Enabled = True
                        cboAction.Items.FindByValue("EnterRankings1").Text = "Enter Rankings (Dual)"
                        cboAction.Items.FindByValue("EnterRankings").Text = "Enter Rankings (Tournament)"
                    End If
                    cboAction.Items.FindByValue("RankingsOthers").Enabled = True
                    cboAction.Items.FindByValue("RankingsOthers1").Enabled = True
                    cboAction.Items.FindByValue("RankingsPrevious").Enabled = True
                    cboAction.Items.FindByValue("RankingsPrevious1").Enabled = True

                ElseIf InStr(Session("memgSportID"), "Volleyball") > 0 Or InStr(Session("memgSportID"), "FPSoftball") > 0 Then         ' CDW added 9/17/2018... added FPSoftball 9/26/2019...

                    If Session("memgSplitWeek") = 1 Then
                        cboAction.Items.FindByValue("EnterRankings").Enabled = False
                        cboAction.Items.FindByValue("EnterRankings1").Enabled = False
                        cboAction.Items.FindByValue("EnterRankings8").Enabled = True
                        cboAction.Items.FindByValue("EnterRankings8").Text = "Enter Rankings (State Tourney)"
                    Else
                        cboAction.Items.FindByValue("EnterRankings8").Enabled = False
                        cboAction.Items.FindByValue("EnterRankings1").Enabled = False
                        cboAction.Items.FindByValue("EnterRankings").Enabled = True
                    End If
                    cboAction.Items.FindByValue("RankingsOthers").Enabled = True
                    cboAction.Items.FindByValue("RankingsOthers1").Enabled = False
                    cboAction.Items.FindByValue("RankingsPrevious").Enabled = True
                    cboAction.Items.FindByValue("RankingsPrevious1").Enabled = False

                Else
                    cboAction.Items.FindByValue("EnterRankings1").Enabled = False
                    cboAction.Items.FindByValue("EnterRankings8").Enabled = False
                End If

                ' Added 1/29/2014...
                If sid.Contains("BasketballBoys6A") Or sid.Contains("BasketballBoys5A") Or sid.Contains("BasketballGirls6A") Or sid.Contains("BasketballGirls5A") Then
                    If ConfigurationManager.AppSettings("showBasketballEWRankings") = 1 Then
                        cboAction.Items.FindByValue("EnterRankingsEW").Enabled = True
                        imgFooter.Visible = True
                    Else
                        cboAction.Items.FindByValue("EnterRankingsEW").Enabled = False
                        imgFooter.Visible = False
                    End If

                Else
                    cboAction.Items.FindByValue("EnterRankingsEW").Enabled = False
                    imgFooter.Visible = False
                End If

            Else
                cboAction.Items.FindByValue("EnterRankings").Enabled = False
                cboAction.Items.FindByValue("EnterRankings1").Enabled = False
                cboAction.Items.FindByValue("EnterRankings8").Enabled = False
                cboAction.Items.FindByValue("RankingsOthers").Enabled = False
                cboAction.Items.FindByValue("RankingsOthers1").Enabled = False
                cboAction.Items.FindByValue("RankingsPrevious").Enabled = False
                cboAction.Items.FindByValue("RankingsPrevious1").Enabled = False
                cboAction.Items.FindByValue("EnterRankingsEW").Enabled = False
            End If

            If sid.Contains("BaseballFall") Or sid.Contains("Baseball") Then            ' Added 8/3/2016...
                cboAction.Items.FindByValue("PitchCount").Enabled = True
            End If

            If sid.Contains("Swimming") Then            ' Added 11/4/2016...
                cboAction.Items.FindByValue("SwimResults").Enabled = True
            End If

            If Session("memgRole") = "OSSAAADMIN" Then

                    Dim strSQL As String
                    Dim ds As DataSet
                    Dim objItem1 As New System.Web.UI.WebControls.ListItem
                    If Session("memdsSchools") Is Nothing Then
                        ' Load the list of schools for Admin?
                        strSQL = "SELECT DISTINCT SchoolName AS SchoolDisplay, schoolID FROM tblSchool WHERE OrganizationType = 'SCHOOL' ORDER BY SchoolName"
                        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                        Session("memdsSchools") = ds
                    End If
                    cboSchools.DataSource = Session("memdsSchools")
                    cboSchools.DataBind()

                    objItem1.Value = 0
                    objItem1.Text = "Select..."
                    cboSchools.Items.Insert(0, objItem1)
                    cboSchools.Visible = True
                    rowSchools.Visible = True
                    cboSchools.SelectedValue = Session("memcboSchools")

                    ' Load All Sports for this school...
                    cboSports.Visible = True
                    cboSports.DataSource = Session("memdsCoachesSports")
                    cboSports.DataBind()

                    ' Add 'Athletic Director' to Sports...
                    cboSports.Items.Insert(0, "Athletic Director")
                    cboSports.Items.Insert(0, "Select Sport...")
                    cboSports.SelectedValue = Session("memcboSports")

                    cboAction.Items.FindByValue("MemberLoginLog").Enabled = True        ' Added 11/21/2014...

                Else
                    cboSchools.Visible = False
                    rowSchools.Visible = False
                End If

            End If

            ' Get Coaches Header information...
            If Not IsPostBack Then
                Me.lblCoach.Text = Session("memgCoachName")
                If Session("memgSportID") Is Nothing Then
                    lblSchool.Text = Session("memgSchool")
                    lblSport.Text = "No Sport Selected"
                    lblRankingsStatus.Text = ""
                Else
                    RefreshRankingsInfo()
                    RefreshCoachesHeader()
                End If
            End If

            ' TODO : Load the Sports for this coach...
            If Not IsPostBack Then
                Session("memsel") = Request.QueryString("sel")
                LoadAction(Request.QueryString("sel"))
            End If

    End Sub

    Protected Sub cboAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAction.SelectedIndexChanged
        LoadAction(cboAction.SelectedValue)
    End Sub

    Public Sub LoadAction(strAction As String)
        Dim objControl1 As UserControl

        ' Hide first...
        ucSchedule1.Visible = False
        ucRoster1.Visible = False
        ucRankings1.Visible = False
        ucPersonalInfo1.Visible = False
        ucTeamUpdate1.Visible = False
        ucTeamUpdate2.Visible = False

        ' Now turn on the correct one...
        Select Case strAction
            Case "EntryForms"
                Me.ucEntryFormsList2.Visible = True
                Me.cboAction.SelectedValue = "EntryForms"
            Case "MemberLoginLog"           ' Added 11/21/2014...
                PlaceHolder.Visible = True
                objControl1 = CType(LoadControl("ucMemberLoginLog.ascx"), UserControl)
                objControl1.Session.Add("memgMemberID", Session("memgMemberID"))
                PlaceHolder.Controls.Add(objControl1)
                Me.cboAction.SelectedValue = "MemberLoginLog"
            Case "SelectSport"
                PlaceHolder.Visible = True
                objControl1 = CType(LoadControl("ucCoachesSports.ascx"), UserControl)
                PlaceHolder.Controls.Add(objControl1)
            Case "Schedule", "ScheduleAdd", "ScheduleTeam", "ScheduleEdit", "ScheduleEditT"
                Me.ucSchedule1.Visible = True
                Me.cboAction.SelectedValue = "Schedule"
            Case "Roster", "RosterAdd", "RosterEdit"
                Me.ucRoster1.Visible = True
                Me.cboAction.SelectedValue = "Roster"
            Case "EnterRankings", "RankingsTeam"
                Me.ucRankings1.Visible = True
                Session("Event") = "EnterRankings"
                Session("RefreshRankingsList") = 1
                Me.ucRankings1.Page_Load(ucRankings1, Nothing)
                Session("memarrTeamID") = Nothing
                cboAction.SelectedValue = "EnterRankings"
            Case "EnterRankings1"
                ' Added 11/26/2013...
                Me.ucRankings1.Visible = True
                Session("Event") = "EnterRankings1"
                Session("RefreshRankingsList") = 1
                Me.ucRankings1.Page_Load(ucRankings1, Nothing)
                Session("memarrTeamID") = Nothing
                cboAction.SelectedValue = "EnterRankings1"
            Case "EnterRankings8"
                Me.ucRankings1.Visible = True
                Session("Event") = "EnterRankings8"
                Session("RefreshRankingsList") = 1
                Me.ucRankings1.Page_Load(ucRankings1, Nothing)
                Session("memarrTeamID") = Nothing
                cboAction.SelectedValue = "EnterRankings8"
            Case "PitchCount"
                ' Added 8/3/2016...
                Session("Event") = "PitchCount"
                Dim sid As String = ""
                sid = Session("memgSportID")
                If sid.Contains("Baseball") And Not sid.Contains("BaseballFall") Then
                    Response.Redirect("PitchCount.aspx")
                Else
                    Response.Redirect("PitchCountFall.aspx")
                End If
            Case "EnterRankingsEW"
                ' Added 1/29/2014...
                Me.ucRankings1.Visible = True
                Session("Event") = "EnterRankingsEW"
                Session("RefreshRankingsList") = 1          ' 11/27/2013 added...
                Me.ucRankings1.Page_Load(ucRankings1, Nothing)
                Session("memarrTeamID") = Nothing
                cboAction.SelectedValue = "EnterRankingsEW"
            Case "PersonalInfo"
                Me.ucPersonalInfo1.Visible = True
                cboAction.SelectedValue = "PersonalInfo"
            Case "TeamUpdate"
                ' Added 10/11/2016...
                Me.ucTeamUpdate1.Visible = True
                cboAction.SelectedValue = "TeamUpdate"
            Case "TeamUpdateAll"
                ' Added 10/18/2016...
                ucTeamUpdate2.Visible = True
                cboAction.SelectedValue = "TeamUpdateAll"
            Case "MyDistrict"
                cboAction.SelectedValue = "MyDistrict"
                PlaceHolder.Visible = True
                objControl1 = CType(LoadControl("ucDistrictStandings1.ascx"), UserControl)
                objControl1.Session.Add("memgSportID", Session("memgSportID"))
                objControl1.Session.Add("memgClass", Session("memgClass"))
                objControl1.Session.Add("memgDistrict", Session("memgDistrict"))
                PlaceHolder.Controls.Add(objControl1)
            Case "RankingsSchedule"
                cboAction.SelectedValue = "RankingsSchedule"
                PlaceHolder.Visible = True
                objControl1 = CType(LoadControl("ucRankingsSchedule.ascx"), UserControl)
                PlaceHolder.Controls.Add(objControl1)
            Case "RankingsOthers"
                Session("Event") = "RankingsOthers"
                Response.Redirect("RankingsOthers.aspx")
            Case "RankingsOthers1"
                Session("Event") = "RankingsOthers1"
                Response.Redirect("RankingsOthers.aspx")
            Case "RankingsPrevious"
                Session("Event") = "RankingsPrevious"
                Response.Redirect("RankingsPrevious.aspx")
            Case "RankingsPrevious1"
                Session("Event") = "RankingsPrevious1"
                Response.Redirect("RankingsPrevious.aspx")
            Case "ContactUs"
                cboAction.SelectedValue = "ContactUs"
                PlaceHolder.Visible = True
                objControl1 = CType(LoadControl("ucContactUs.ascx"), UserControl)
                PlaceHolder.Controls.Add(objControl1)
            Case "SwimResults"          ' 11/4/2016...
                cboAction.SelectedValue = "SwimResults"
                PlaceHolder.Visible = True
                objControl1 = CType(LoadControl("ucSwimResults.ascx"), UserControl)
                PlaceHolder.Controls.Add(objControl1)
            Case "Logout"
                Session("memgSchool") = ""
                Session("memgMemberID") = 0
                Session("memgSchoolID") = 0
                Session("memgTeamID") = 0
                Response.Redirect("Login.aspx")
            Case Else
        End Select

        Session("Event") = strAction            ' 11/21/2013 added...

    End Sub

    Private Sub cboSports_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboSports.SelectedIndexChanged

        Session("RefreshRankingsList") = 1          ' 11/15/2013 added...

        ' Get Selected Sport information for this coach... 
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

        Session("entryFormSchoolName") = objTeam.getSchool          ' 7/19/2017...
        Session("entryFormSchoolID") = objTeam.getSchoolID
        Session("entryFormMemberID") = objTeam.getMemberID

        If Session("memgRole") = "OSSAAADMIN" Then
            Dim objMem As New clsMember(objTeam.getMemberID, False)
            Session("memgMemberID") = objTeam.getMemberID
            Session("memgCoachName") = objMem.gFullName
            Session("memgEmailMain") = objMem.gEmailMain
            Session("memgWhoIsLoggedIn") = "OSSAAADMIN"         ' Added 11/18/2014...
        End If

        Session("memgCurrentRanking") = clsRankings.GetCurrentRank(Session("memgSportID"), Session("memgTeamID"), Now)
        RefreshRankingsInfo()
        RefreshCoachesHeader()
        Session("memcboSports") = cboSports.SelectedValue
        cboAction.SelectedIndex = 0
        HideShowActions(cboSports.SelectedValue)

        ' Get the list of teams from sports...]
        Dim intYear As Integer
        Dim ds As DataSet
        intYear = clsFunctions.GetCurrentYear()
        ds = clsTeams.GetSportTeamsForSport(Session("memgSportGenderKey"), intYear, Session("memgTeamID"))
        Session("memdsTeams") = ds

        ' Get the Roster...

        ' HIDE OBJECTS :  all of the existing objects...
        ucSchedule1.Visible = False
        ucRankings1.Visible = False
        ucRoster1.Visible = False
        ucPersonalInfo1.Visible = False
        ucTeamUpdate1.Visible = False
        ucTeamUpdate2.Visible = False

        Dim strSportID As String = ""
        strSportID = Session("memgSportID")
        If strSportID.Contains("BasketballBoys6A") Or strSportID.Contains("BasketballBoys5A") Or strSportID.Contains("BasketballGirls6A") Or strSportID.Contains("BasketballGirls5A") Then
            imgFooter.Visible = True
        Else
            imgFooter.Visible = False
        End If

        ' Let's clear all of the Temp Rankings for this Sport...
        If Not Session("memarrTeamID") Is Nothing Then
            Session("memarrTeamID") = Nothing
            Session("memarrSchool") = Nothing
        End If

        ' Added 9/18/2014...
        Dim sid As String = "Ellen"
        sid = Session("memgSportID")
        GetOfficialsHyperlink(sid)

    End Sub


    Public Sub HideShowActions(intTeamID As Long)
        ' Hide or show the rankings in the dropdown...
        Dim strSQL As String
        Dim intShowRankings As Integer = 0
        Dim intShowRankingsSchedule As Integer = 0
        Dim intDistrictStandings As Integer = 0
        Dim strSportID As String = ""
        Dim ds As DataSet

        strSQL = "Select sportID FROM tblTeams WHERE teamID = " & intTeamID
        strSportID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If strSportID = "" Then
            cboAction.Items.FindByValue("EnterRankings").Enabled = False
            cboAction.Items.FindByValue("EnterRankings1").Enabled = False
            cboAction.Items.FindByValue("EnterRankings8").Enabled = False
            cboAction.Items.FindByValue("EnterRankingsEW").Enabled = False
            cboAction.Items.FindByValue("RankingsSchedule").Enabled = False
            cboAction.Items.FindByValue("RankingsOthers").Enabled = False
            cboAction.Items.FindByValue("RankingsPrevious").Enabled = False
            cboAction.Items.FindByValue("MyDistrict").Enabled = False
        Else
            strSQL = "Select TOP 1 intRankings, intDistrictStandings, intRankingsSchedule FROM tblSports WHERE sportID = '" & strSportID & "'"

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

            ' Rankings...
            Try
                intShowRankings = ds.Tables(0).Rows(0).Item("intRankings")
            Catch ex As Exception
                intShowRankings = 0
            End Try

            If intShowRankings = 1 Then
                cboAction.Items.FindByValue("EnterRankings").Enabled = True
                cboAction.Items.FindByValue("RankingsOthers").Enabled = True
                cboAction.Items.FindByValue("RankingsPrevious").Enabled = True
                If strSportID.Contains("Wrestling") Then
                    If Session("memgSplitWeek") = 1 Then
                        cboAction.Items.FindByValue("EnterRankings8").Enabled = True
                        cboAction.Items.FindByValue("EnterRankings1").Enabled = False
                    Else
                        cboAction.Items.FindByValue("EnterRankings8").Enabled = False
                        cboAction.Items.FindByValue("EnterRankings1").Enabled = True
                    End If
                ElseIf strSportID.Contains("Volleyball") Or strSportID.Contains("FPSoftball") Then      ' CDW added FPSoftball on 9/26/2019...
                    If Session("memgSplitWeek") = 1 Then
                        cboAction.Items.FindByValue("EnterRankings").Enabled = False
                        cboAction.Items.FindByValue("EnterRankings1").Enabled = False
                        cboAction.Items.FindByValue("EnterRankings8").Enabled = True
                        cboAction.Items.FindByValue("EnterRankings8").Text = "Enter Rankings (State Tourney)"
                    Else
                        cboAction.Items.FindByValue("EnterRankings8").Enabled = False
                        cboAction.Items.FindByValue("EnterRankings1").Enabled = False
                        cboAction.Items.FindByValue("EnterRankings").Enabled = True
                    End If
                ElseIf strSportID.Contains("BasketballBoys6A") Or strSportID.Contains("BasketballBoys5A") Or strSportID.Contains("BasketballGirls6A") Or strSportID.Contains("BasketballGirls5A") Then
                    If ConfigurationManager.AppSettings("showBasketballEWRankings") = 1 Then
                        cboAction.Items.FindByValue("EnterRankingsEW").Enabled = True
                        imgFooter.Visible = True
                        cboAction.Items.FindByValue("EnterRankings1").Enabled = False
                        cboAction.Items.FindByValue("EnterRankings8").Enabled = False
                    Else
                        cboAction.Items.FindByValue("EnterRankingsEW").Enabled = False
                        imgFooter.Visible = False
                        cboAction.Items.FindByValue("EnterRankings8").Enabled = False
                        cboAction.Items.FindByValue("EnterRankings1").Enabled = False
                    End If
                Else
                    cboAction.Items.FindByValue("EnterRankings1").Enabled = False
                    cboAction.Items.FindByValue("EnterRankings8").Enabled = False
                    cboAction.Items.FindByValue("EnterRankingsEW").Enabled = False
                    imgFooter.Visible = False
                    cboAction.Items.FindByValue("RankingsOthers1").Enabled = False
                    cboAction.Items.FindByValue("RankingsPrevious1").Enabled = False
                End If
            Else
                cboAction.Items.FindByValue("EnterRankings").Enabled = False
                cboAction.Items.FindByValue("EnterRankings1").Enabled = False
                cboAction.Items.FindByValue("EnterRankings8").Enabled = False
                cboAction.Items.FindByValue("EnterRankingsEW").Enabled = False
                cboAction.Items.FindByValue("RankingsOthers").Enabled = False
                cboAction.Items.FindByValue("RankingsOthers1").Enabled = False
                cboAction.Items.FindByValue("RankingsPrevious").Enabled = False
                cboAction.Items.FindByValue("RankingsPrevious1").Enabled = False
            End If

            ' Added 8/3/2016...
            If strSportID.Contains("Baseball") Then
                cboAction.Items.FindByValue("PitchCount").Enabled = True
            End If

            ' Added 11/4/2016...
            If strSportID.Contains("Swimming") Then
                cboAction.Items.FindByValue("SwimResults").Enabled = True
            End If

            ' Rankings Schedule... (added 8/5/2013)...
            Try
                intShowRankingsSchedule = ds.Tables(0).Rows(0).Item("intRankingsSchedule")
            Catch ex As Exception
                intShowRankingsSchedule = 0
            End Try

            If intShowRankingsSchedule = 1 Then
                cboAction.Items.FindByValue("RankingsSchedule").Enabled = True
                cboAction.Items.FindByValue("TeamUpdate").Enabled = True
                cboAction.Items.FindByValue("TeamUpdateAll").Enabled = True
            Else
                cboAction.Items.FindByValue("RankingsSchedule").Enabled = False
                cboAction.Items.FindByValue("TeamUpdate").Enabled = False
                cboAction.Items.FindByValue("TeamUpdateAll").Enabled = False
            End If

            ' District...
            Try
                intDistrictStandings = ds.Tables(0).Rows(0).Item("intDistrictStandings")
            Catch ex As Exception
                intDistrictStandings = 0
            End Try

            If intDistrictStandings = 1 Then
                cboAction.Items.FindByValue("MyDistrict").Enabled = True
            Else
                cboAction.Items.FindByValue("MyDistrict").Enabled = False
            End If

        End If

    End Sub

    Public Sub RefreshCoachesHeader()
        Me.lblCoach.Text = Session("memgCoachName")
        If Session("memgSportID") Is Nothing Then
            lblSchool.Text = Session("memgSchool")
            lblSport.Text = "No Sport Selected"
            lblRankingsStatus.Text = ""
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
            lblRankingsStatus.Text = Session("memgRankingsStatus")
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
            If Session("memgSportID") Is Nothing Then
                Session("memgCurrentWeekIDRank") = 0
                Session("memgCurrentWeekIDDisplay") = 0
                Session("memgCurrentWeekIDPeriod") = 0
                Session("memgCurrentWeekID12to4") = 0
                Session("memgRankingsThisSeason") = 0
                Session("memgSplitWeek") = 0
                Session("memgSplitWeek12to4") = 0
                Session("memgSplitWeekDisplay") = 0
            Else
                Session("memgCurrentWeekIDRank") = clsRankings.GetCurrentRankingWeekIDRankingWindow(Session("memgSportID"), Now.ToString)
                Session("memgCurrentWeekIDDisplay") = clsRankings.GetCurrentRankingWeekIDDisplayWindow(Session("memgSportID"), Now.ToString)
                Session("memgCurrentWeekIDPeriod") = clsRankings.GetCurrentRankingWeekIDPeriodWindow(Session("memgSportID"), Now.ToString)
                Session("memgCurrentWeekID12to4") = clsRankings.GetCurrentRankingWeekID12to4(Session("memgSportID"), Now.ToString)
                Session("memgRankingsThisSeason") = clsRankings.GetCurrentRankCount(Session("memgTeamID"))
            End If
            Session("memgCurrentWeekNoDisplay") = clsRankings.GetCurrentRankingintWeekNo(Session("memgCurrentWeekIDDisplay"))
            Session("memgCurrentWeekNoRank") = clsRankings.GetCurrentRankingintWeekNo(Session("memgCurrentWeekIDRank"))
            Session("memgPreviousWeekID") = clsRankings.GetPreviousRankingWeekID(Session("memgSportID"), clsFunctions.GetCurrentYear, Session("memgCurrentWeekNoDisplay"))
            Session("memgRankingsStatus") = clsRankings.GetRankingsStatus(Session("memgSportID"), Session("memgTeamID"), Session("memgCurrentWeekIDRank"), Session("memgCurrentWeekIDDisplay"), Session("memgCurrentWeekIDPeriod"), Session("memgCurrentWeekNoRank"), Session("memgCurrentWeekNoDisplay"), Session("memgPreviousWeekID"), Session("memgCurrentWeekID12to4"), Session("memgRankingsThisSeason"), Session("event"))
            Session("memgSplitWeek") = clsRankings.GetSplitWeek(Session("memgCurrentWeekIDRank"))
            Session("memgSplitWeek12to4") = clsRankings.GetSplitWeek(Session("memgCurrentWeekID12to4"))
            Session("memgSplitWeekDisplay") = clsRankings.GetSplitWeek(Session("memgCurrentWeekIDDisplay"))
        End If
    End Sub

    Private Sub cboSchools_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboSchools.SelectedIndexChanged
        ' Load School Info...
        Dim objSchoolInfo As New clsSchool("", cboSchools.SelectedValue)
        Session("memgSchoolID") = cboSchools.SelectedValue
        Session("memgSchool") = objSchoolInfo.getSchool

        Session("memdsTeams") = Nothing

        ' Load All Sports for this school...
        Session("memdsCoachesSports") = clsSports.GetSportsForSchoolDS(cboSchools.SelectedValue, clsFunctions.GetCurrentYear)
        cboSports.DataSource = Session("memdsCoachesSports")
        cboSports.DataBind()

        ' Add 'Athletic Director' to Sports...
        If cboSports.Items.FindByValue("Select...") Is Nothing Then
            cboSports.Items.Insert(0, "Athletic Director")
            cboSports.Items.Insert(0, "Select...")
        End If

        Session("memcboSchools") = cboSchools.SelectedValue

        cboAction.SelectedIndex = 0

        ' HIDE OBJECTS :  all of the existing objects...
        ucSchedule1.Visible = False
        ucRankings1.Visible = False
        ucPersonalInfo1.Visible = False
        ucRoster1.Visible = False
        ucTeamUpdate1.Visible = False
        ucTeamUpdate2.Visible = False

    End Sub

    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()> _
    Public Shared Function GetDynamicContentTeamUpdate(ByVal contextKey As String) As String

        Dim b As New StringBuilder()

        Dim strTeamUpdate As String
        strTeamUpdate = clsTeams.GetTeamUpdate(contextKey)
        Dim strSchoolName As String
        strSchoolName = clsTeams.GetSchoolNameFromTeamID(contextKey)

        b.Append("<table style='background-color:#f3f3f3; border: #336699 3px solid; ")
        b.Append("width:650px; font-size:8pt; font-family:Segoe UI, Helvetica, Helvetica Neue, Lucida Grande, Arial, Verdana, Sans-serif;' cellspacing='0' cellpadding='4'>")
        b.Append("<tr><td colspan='4' style='background-color:LightYellow;'>")
        b.Append("<b>" & strSchoolName & "<br><br><b>" & strTeamUpdate & "<br>")
        b.Append("</td></tr>")

        b.Append("</table>")
        Return b.ToString()

    End Function

    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()> _
    Public Shared Function GetDynamicContent(ByVal contextKey As String) As String
        ' Added 11/27/2013...
        Dim strSQL As String = ""
        Dim ds As DataSet
        Dim x As Integer
        Dim strDashes As String = "--------------------------------------------------------------------------------------"

        If contextKey Is Nothing Then
            Return ""
            Exit Function
        End If

        If contextKey = "" Then
            Return ""
            Exit Function
        End If

        ' Added 10/11/2016...
        Dim strTeamUpdate As String
        strTeamUpdate = clsTeams.GetTeamUpdate(contextKey)
        'strTeamUpdate = clsTeams.GetTeamUpdate(64437)

        strSQL = clsSchedules.GetScheduleTeamSQL(contextKey)
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        ds = clsSchedules.ChangeDatasetSchedule(ds, True, 0, False, False)

        Dim b As New StringBuilder()

        b.Append("<table style='background-color:#f3f3f3; border: #336699 3px solid; ")
        b.Append("width:650px; font-size:8pt; font-family:Verdana;' cellspacing='0' cellpadding='4'>")
        b.Append("<tr><td colspan='4' style='background-color:Maroon; color:white;'>")
        b.Append("<b>View Schedule : " & clsTeams.GetSchoolNameFromTeamID(contextKey) & "</b>")
        b.Append("</td></tr>")

        ' Add Team Update...
        If strTeamUpdate = "" Then
            ' Do nothing...
        Else
            b.Append("<tr><td style='width:97%;' colspan='4'><strong>MY TEAM UPDATE</strong><br>" & strDashes & "<br>" & strTeamUpdate & "<br>" & strDashes & "<br></td></tr>")
        End If

        Try
            If clsTeams.GetSportIDForTeam(contextKey).Contains("Basketball") Then
                Dim strRecords As String = ""
                Dim SQLCon As New SqlClient.SqlConnection
                SQLCon.ConnectionString = SqlHelper.SQLConnection
                SQLCon.Open()

                Dim SQLDA As New SqlClient.SqlDataAdapter("spGetTeamRecordInfo", SQLCon)
                SQLDA.SelectCommand.CommandType = CommandType.StoredProcedure
                SQLDA.SelectCommand.Parameters.AddWithValue("@TeamID", CInt(contextKey))
                Dim objSQLParam As New SqlClient.SqlParameter("@strResult", SqlDbType.VarChar, 255)
                SQLDA.SelectCommand.Parameters.Add(objSQLParam)
                SQLDA.SelectCommand.Parameters("@strResult").Direction = ParameterDirection.Output
                Dim ds1 As New DataSet
                SQLDA.Fill(ds1, "RecordInfo")
                strRecords = SQLDA.SelectCommand.Parameters(1).Value

                b.Append("<tr><td style='width:320px;' colspan='3'><strong>Record Detail</strong><br>" & strRecords.Replace("|", "<br>") & "</td>")
            End If
        Catch

        End Try

        b.Append("<tr><td style='width:150px;'><b>Date</b></td>")
        b.Append("<td style='width:200px;'><b>Opponent</b></td>")
        b.Append("<td style='width:120px;'><b>Results</b></td>")
        ' Added GetTop20Record 8/24/2015...
        b.Append("<td rowspan='100' style='width:200px;vertical-align:top;'><b>RECORDS</b><br>" & clsTeams.GetTop20Record(contextKey, 20, clsFunctions.GetCurrentYear) & "</td>")
        b.Append("</tr>")

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                b.Append("<tr>")
                b.Append("<td>" & ds.Tables(0).Rows(x).Item("Date").ToString() & "</td>")
                b.Append("<td>" & ds.Tables(0).Rows(x).Item("Opposing Team").ToString() & "</td>")
                b.Append("<td>" & ds.Tables(0).Rows(x).Item("Results").ToString() & "</td>")
                b.Append("</tr>")
            Next
        End If

        b.Append("</table>")
        Return b.ToString()

    End Function

    Public Sub GetOfficialsHyperlink(sid As String)
        'Exit Sub
        If sid.Contains("Football") And ConfigurationManager.AppSettings("showRatingOfOfficialsFootball") = 1 Then
            hlSport.Visible = True
            If Session("memgRole") = "OSSAAADMIN" Then
                hlSport.NavigateUrl = "http://www.ossaarankings.com/officials/LoginFBR.aspx?l=ossaacoach&id=" & Session("memgEmailMain") & "&sid=" & (Session("memgSchoolID") + 1234)
            Else
                hlSport.NavigateUrl = "http://www.ossaarankings.com/officials/LoginFBR.aspx?l=ossaacoach&id=" & Session("memgUsername") & "&sid=" & (Session("memgSchoolID") + 1234)
            End If
            hlSport.Text = "Rating of Officials and Scratch List (click here)"

            If ConfigurationManager.AppSettings("ShowPlayoffOfficialsList") = 1 Then
                hlPrefs.Text = "Round 5 Football Playoff Officials"
                hlPrefs.NavigateUrl = "http://www.ossaa.net/docs/2019-20/Round5_Football_Officials_Schools.pdf"
                hlPrefs.Visible = True
            End If

            'ElseIf sid.Contains("Golf") Then
            '    hlSport.Visible = True
            '    hlSport.NavigateUrl = "http://www.ossaarankings.com/averageGolfScoresBoys.aspx"
            '    hlSport.Text = "Average Golf Scores"

        ElseIf sid.Contains("Basketball") And ConfigurationManager.AppSettings("showRatingOfOfficialsBasketball") = 1 Then      ' Added 12/9/2014...
                Dim sSportKey As String = ""
                If Session("memgRole") = "OSSAAADMIN" Then
                    sSportKey = clsMembers.DoesMemberCoachBoysAndGirlsBasketball(Session("memgMemberID"), sid)
                    hlSport.Visible = True
                    hlSport.NavigateUrl = "http://www.ossaarankings.com/officials/LoginBBR.aspx?l=ossaacoach&id=" & Session("memgEmailMain") & "&sid=" & ((Session("memgMemberID") + 1234) & "&g=" & sSportKey.Replace("BOTH", "Girls"))
                    hlSport.Text = "Rating of Officials (click here)"
                    If ConfigurationManager.AppSettings("showBBPrefsLink") = 1 Then
                        hlPrefs.Visible = True
                        hlPrefs.NavigateUrl = "http://www.ossaarankings.com/officials/LoginBBPref.aspx?l=ossaacoach&id=" & Session("memgEmailMain") & "&sid=" & ((Session("memgMemberID") + 1234) & "&g=" & sSportKey.Replace("BOTH", "Girls"))
					'hlPrefs.Text = "Preferential Officials List and Bracket Entry Site (click here)"
					hlPrefs.Text = "Officials Assignments (click here)"
				Else
                        hlPrefs.Visible = False
                    End If
                    ' Added 2/13/2018...
                    If ConfigurationManager.AppSettings("showBBPrefsInstructionsLink") = 1 Then
                        hlInstructions.Visible = True
                        If ConfigurationManager.AppSettings("PrefClassBasketball") = "AB" Then
                            hlInstructions.NavigateUrl = "http://www.ossaarankings.com/docs/InstructionsAB.pdf"
                        ElseIf ConfigurationManager.AppSettings("PrefClassBasketball") = "4A2A" Then
                            hlInstructions.NavigateUrl = "http://www.ossaarankings.com/docs/Instructions4A2A.pdf"
                        ElseIf ConfigurationManager.AppSettings("PrefClassBasketball") = "6A5A" Then
                            hlInstructions.NavigateUrl = "http://www.ossaarankings.com/docs/Instructions6A5A.pdf"
                        End If
                        hlInstructions.Text = " - Directions for Accessing the Preferential Officials Lists Site"
                    Else
                        hlInstructions.Visible = False
                    End If
                Else
                    sSportKey = clsMembers.DoesMemberCoachBoysAndGirlsBasketball(Session("memgMemberID"), sid)
                    hlSport.Visible = True
                    hlSport.NavigateUrl = "http://www.ossaarankings.com/officials/LoginBBR.aspx?l=ossaacoach&id=" & Session("memgUsername") & "&sid=" & ((Session("memgMemberID") + 1234) & "&g=" & sSportKey.Replace("BOTH", "Girls"))
                    hlSport.Text = "Rating of Officials (click here)"
                    If ConfigurationManager.AppSettings("showBBPrefsLink") = 1 Then
                        hlPrefs.Visible = True
                        hlPrefs.NavigateUrl = "http://www.ossaarankings.com/officials/LoginBBPref.aspx?l=ossaacoach&id=" & Session("memgUsername") & "&sid=" & ((Session("memgMemberID") + 1234) & "&g=" & sSportKey.Replace("BOTH", "Girls"))
					'hlPrefs.Text = "Preferential Officials List and Bracket Entry Site (click here)"
					hlPrefs.Text = "Officials Assignments (click here)"
				Else
                        hlPrefs.Visible = False
                    End If
                    ' Added 2/13/2018...
                    If ConfigurationManager.AppSettings("showBBPrefsInstructionsLink") = 1 Then
                        hlInstructions.Visible = True
                        If ConfigurationManager.AppSettings("PrefClassBasketball") = "AB" Then
                            hlInstructions.NavigateUrl = "http://www.ossaarankings.com/docs/InstructionsAB.pdf"
                        ElseIf ConfigurationManager.AppSettings("PrefClassBasketball") = "4A2A" Then
                            hlInstructions.NavigateUrl = "http://www.ossaarankings.com/docs/Instructions4A2A.pdf"
                        ElseIf ConfigurationManager.AppSettings("PrefClassBasketball") = "6A5A" Then
                            hlInstructions.NavigateUrl = "http://www.ossaarankings.com/docs/Instructions6A5A.pdf"
                        End If
                        hlInstructions.Text = " - Directions for Accessing the Preferential Officials Lists Site"
                    Else
                        hlInstructions.Visible = False
                    End If
                End If
            ElseIf sid.Contains("Wrestling") Then
                If ConfigurationManager.AppSettings("showWRPrefsLink") = 1 Then
                    hlPrefs.Visible = True
                Else
                    hlPrefs.Visible = False
                End If
                hlPrefs.NavigateUrl = "http://www.ossaarankings.com/officials/LoginWRPref.aspx?l=ossaacoach&id=" & Session("memgEmailMain") & "&sid=" & ((Session("memgMemberID") + 1234))
                hlPrefs.Text = "Preferential Officials List Entry (click here)"

            ElseIf sid.Contains("Soccer") Then
                If ConfigurationManager.AppSettings("showSCPrefsLink") = 1 Then
                    hlPrefs.Visible = True
                Else
                    hlPrefs.Visible = False
                End If
                hlPrefs.NavigateUrl = "http://www.ossaarankings.com/officials/LoginSCPref.aspx?l=ossaacoach&id=" & Session("memgEmailMain") & "&sid=" & ((Session("memgMemberID") + 1234))
                hlPrefs.Text = "Preferential Officials List Entry (click here)"

            ElseIf sid.Contains("Volleyball") Then

                If Now > ConfigurationManager.AppSettings("OfficialsRecommendationFormsVB_Start") Then
                    If (Now < ConfigurationManager.AppSettings("OfficialsRecommendationFormsVB_End4A3A") And (sid.Contains("Volleyball3A") Or sid.Contains("Volleyball4A"))) Or (Now < ConfigurationManager.AppSettings("OfficialsRecommendationFormsVB_End6A5A") And (sid.Contains("Volleyball6A") Or sid.Contains("Volleyball5A"))) Then
                        hlPrefs.Visible = True
                        hlPrefs.NavigateUrl = ConfigurationManager.AppSettings("OfficialsRecommendationFormsVB") & "?id=" & Session("memgUsername")
                        hlPrefs.Text = ConfigurationManager.AppSettings("OfficialsRecommendationFormsVB_Title")

                        hlInstructions.Visible = True
                        hlInstructions.NavigateUrl = "http://www.ossaa.net/docs/2019-20/rptOfficialsVolleyballAvailabilityReportPUBLIC926.pdf?id=" & Session("memgUsername")
                        hlInstructions.Text = "2019 State Tournament Officials Available for Playoffs (click here)"
                    End If
                Else
                    hlPrefs.Visible = False
                End If

            ElseIf sid.Contains("SPSoftball") Or sid.Contains("SoftballSP") Then          ' Added 4/10/2017 ...
                hlSport.Visible = False
                hlSport.NavigateUrl = "http://www.ossaa.net/docs/2017-18/SlowPitch/2018CoachesRecommendationListOfOfficials.pdf"
                hlSport.Text = "2018 Slow Pitch Umpire Recommendation Form"
                hlSport.Target = "_blank"

            ElseIf sid.Contains("Softball") Then

                If Now >= ConfigurationManager.AppSettings("OfficialsRecommendationFormsFP_Start") And Now <= ConfigurationManager.AppSettings("OfficialsRecommendationFormsFP_End") Then
                    hlSport.Visible = True
                    hlSport.NavigateUrl = ConfigurationManager.AppSettings("OfficialsRecommendationFormsFP") & "?id=" & Session("memgUsername")
                    hlSport.Text = ConfigurationManager.AppSettings("OfficialsRecommendationFormsFP_Title")

                    hlInstructions.Visible = True
                    hlInstructions.NavigateUrl = ConfigurationManager.AppSettings("OfficialsRecommendationFormsFP_OffAvail") & "?id=" & Session("memgUsername")
                    hlInstructions.Text = ConfigurationManager.AppSettings("OfficialsRecommendationFormsFP_OffAvailTitle")
                Else
                    hlSport.Visible = False
                End If

            ElseIf sid.Contains("Swimming") And ConfigurationManager.AppSettings("showSwimmingMeetsList") = 1 Then
                hlSport.Visible = True
                hlSport.NavigateUrl = "http://www.ossaa.com/SportsSwimmingDb.aspx"
                hlSport.Text = "2018-2019 OSSAA Swim Meet Results (click here)"
            ElseIf sid.Contains("Soccer") Then          ' Added 4/10/2017 ...
                hlSport.Visible = False
                hlSport.NavigateUrl = "http://www.ossaa.net/docs/2016-17/Soccer/SO_2016-17_PrefOfficialsList.pdf"
                hlSport.Text = "2019 Soccer Coaches Preferential Officials List Form"
                hlSport.Target = "_blank"
            Else
                hlSport.Visible = False
            hlPrefs.Visible = False
        End If
    End Sub

End Class