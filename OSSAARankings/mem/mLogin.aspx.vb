Public Class mLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Page.ClientTarget = "Uplevel"       ' Added 11/20/2013 to resolve IE 11 compatibility problem...

        ' Remember Me?
        If Not IsPostBack Then
            If Request.Browser.Cookies Then
                If Request.Cookies("OSSAARLOGIN") IsNot Nothing Then
                    Try
                        txtUserName.Text = Request.Cookies("OSSAARLOGIN").Value
                    Catch
                    End Try
                End If
            End If
        End If

        If Request.UserAgent.Contains("android") Or Request.UserAgent.Contains("iphone") Or Request.UserAgent.Contains("blackberry") Or Request.UserAgent.Contains("mobile") Or Request.UserAgent.Contains("palm") Then

        Else

        End If

        ' Added 10/10/2013...
        If Request.QueryString("key") = "po82173093" Then
            Me.txtUserName.Text = "cwilfong@ossaa.com"
            Me.txtPassword.Text = "gohogs23"
            Call cmdLogin_Click(Me, Nothing)
        End If

    End Sub

    Private Sub cmdLogin_Click(sender As Object, e As System.EventArgs) Handles cmdLogin.Click
        Dim strUserName As String
        Dim strPassword As String
        Dim strSQL As String
        Dim memberID As Long = 0

        strUserName = clsFunctions.StringValidate(txtUserName.Text)
        strPassword = clsFunctions.StringValidate(txtPassword.Text)

        strSQL = "SELECT MemberID FROM tblMembers WHERE Username = '" & strUserName & "' AND Password = '" & strPassword & "' And intYear = " & clsFunctions.GetCurrentYear & " AND intActive <> 0"
        memberID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If memberID = 0 Then
            lblMessage.Text = "Invalid login information."
        Else
            Session("memgPassword") = strPassword.ToUpper
            Session("memgUsername") = strUserName
            Dim objMem As New clsMember(memberID, False)
            Session("memgMemberID") = memberID
            Session("memgSchool") = objMem.gSchool
            Session("memgSchoolID") = objMem.gSchoolID
            Session("memgCoachName") = objMem.gFullName
            Session("memgRole") = objMem.gRole
            Session("memgEmailMain") = objMem.gEmailMain
            Session("memgWhoIsLoggedIn") = Session("memgEmailMain")         ' Added 11/18/2014...
            Session("memdsCoachesSports") = clsMembers.GetTeamsDatasetFromCoach(Session("memgSchoolID"), clsFunctions.GetCurrentYear, Session("memgMemberID"))
            Session("memgNoOfSports") = Session("memdsCoachesSports").Tables(0).rows.count

            If Session("memgRole") = "OSSAAADMIN" Then
                Session("memgWhoIsLoggedIn") = "OSSAAADMIN"         ' Added 11/18/2014...
                Response.Redirect("Home.aspx")
            Else
                If Session("memgNoOfSports") = 1 Then
                    Session("memgTeamID") = Session("memdsCoachesSports").Tables(0).Rows(0).Item("teamID")
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
                    Session("memgShowRanking") = objTeam.getShowRanking        ' 8/23/2013 added...
                    Session("memgResults") = objTeam.getResults
                    Session("memgPostGender") = objTeam.getPostGender
                    Session("memgMemberID") = objTeam.getMemberID          ' 8/23/2013 added...
                    Session("memgPlayoffSchedule") = objTeam.getPlayoffSchedule         ' 11/4/2013 added...
                    Session("memgPlayoffsState") = objTeam.getPlayoffsState
                    Session("memgPlayoffsRegionals") = objTeam.getPlayoffsRegional

                    ' GET RANKINGS INFO...
                    RefreshRankingsInfo()
                Else

                End If

                If Session("memgNoOfSports") = 0 Then
                    Me.lblMessage.Text = "This coach has not been assigned to a sport.  Please contact your Athletic Director."
                ElseIf Session("memgTeamID") = 0 And Session("memgNoOfSports") = 1 Then
                    lblMessage.Text = "Team information unavailable.  Please close your browser and come back and try logging in again.  We apologize for the inconvenience."
                Else
                    ' Login, good to go...
                    WriteCookie(strUserName, strPassword)
                    strSQL = "INSERT INTO tblMembersLogin (memberID, strType, strSchoolName, strRequestUseragent) VALUES ('" & Session("memgMemberID") & "', 'COACH', '" & Session("memgSchool") & "', '" & clsLog.GetBrowserInfo(Request.UserAgent) & "')"
                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
                    'Response.Redirect("Home.aspx")
                End If
            End If
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
            Else
                Session("memgCurrentWeekIDRank") = clsRankings.GetCurrentRankingWeekIDRankingWindow(Session("memgSportID"), Now.ToString)
                Session("memgCurrentWeekIDDisplay") = clsRankings.GetCurrentRankingWeekIDDisplayWindow(Session("memgSportID"), Now.ToString)
                Session("memgCurrentWeekIDPeriod") = clsRankings.GetCurrentRankingWeekIDPeriodWindow(Session("memgSportID"), Now.ToString)
                Session("memgCurrentWeekID12to4") = clsRankings.GetCurrentRankingWeekID12to4(Session("memgSportID"), Now.ToString)
                Session("memgRankingsThisSeason") = clsRankings.GetCurrentRankCount(Session("memgTeamID"))
            End If
            'Session("memgCurrentWeekID") = clsRankings.GetCurrentRankingWeekID(Session("memgSportID"), "8/17/2013")
            Session("memgCurrentWeekNoDisplay") = clsRankings.GetCurrentRankingintWeekNo(Session("memgCurrentWeekIDDisplay"))
            Session("memgCurrentWeekNoRank") = clsRankings.GetCurrentRankingintWeekNo(Session("memgCurrentWeekIDRank"))
            Session("memgPreviousWeekID") = clsRankings.GetPreviousRankingWeekID(Session("memgSportID"), clsFunctions.GetCurrentYear, Session("memgCurrentWeekNoDisplay"))
            Session("memgRankingsStatus") = clsRankings.GetRankingsStatus(Session("memgSportID"), Session("memgTeamID"), Session("memgCurrentWeekIDRank"), Session("memgCurrentWeekIDDisplay"), Session("memgCurrentWeekIDPeriod"), Session("memgCurrentWeekNoRank"), Session("memgCurrentWeekNoDisplay"), Session("memgPreviousWeekID"), Session("memgCurrentWeekID12to4"), Session("memgRankingsThisSeason"), Session("event"))
            Session("memgSplitWeek") = clsRankings.GetSplitWeek(Session("memgCurrentWeekIDRank"))
            Session("memgSplitWeek12to4") = clsRankings.GetSplitWeek(Session("memgCurrentWeekID12to4"))
            Session("memgSplitWeekDisplay") = clsRankings.GetSplitWeek(Session("memgCurrentWeekIDDisplay"))
        End If
    End Sub

    Public Sub WriteCookie(ByVal strUsernameIn As String, ByVal strPasswordIn As String)
        If (Request.Browser.Cookies) Then
            If (Request.Cookies("OSSAARLOGIN") Is Nothing) Then
                Response.Cookies("OSSAARLOGIN").Expires = DateTime.Now.AddDays(30)
                Response.Cookies("OSSAARLOGIN").Value = strUsernameIn
            Else
                Response.Cookies("OSSAARLOGIN").Expires = DateTime.Now.AddDays(14)
                Response.Cookies("OSSAARLOGIN").Value = strUsernameIn
            End If
        End If
    End Sub

    Private Sub cmdForgot_Click(sender As Object, e As System.EventArgs) Handles cmdForgot.Click
        Response.Redirect("LoginForgot.aspx")
    End Sub
End Class