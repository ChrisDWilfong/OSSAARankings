Public Class LoginChange
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.UserAgent.Contains("android") Or Request.UserAgent.Contains("iphone") Or Request.UserAgent.Contains("blackberry") Or Request.UserAgent.Contains("mobile") Or Request.UserAgent.Contains("palm") Then

        Else

        End If

        Me.txtUserName.Text = Session("memgUsername")

    End Sub

    Private Sub cmdLogin_Click(sender As Object, e As System.EventArgs) Handles cmdLogin.Click
        Dim strUserName As String
        Dim strPassword As String
        Dim strSQL As String
        Dim memberID As Long = 0

        strUserName = clsFunctions.StringValidate(txtUserName.Text)
        strPassword = clsFunctions.StringValidate(txtPassword.Text)

        ' Check then save the Changed password and log them in...
        If strPassword.ToUpper = "PASSWORD" Then
            lblMessage.Text = "Your password can not be 'password'.  Please try again."
            Exit Sub
        ElseIf strPassword.Length < 6 Then
            lblMessage.Text = "Your password is too short.  It must be atleast 6 characters long.  Please try again."
            Exit Sub
        ElseIf strPassword.Length > 20 Then
            lblMessage.Text = "Your password is too long (20+ characters).  Please try again."
            Exit Sub
        Else
            If strUserName = "cwilfong@ossaa.com" Or strUserName = "acassell@ossaa.com" Then
                lblMessage.Text = "You are from the DARK SIDE and you are not authorized to change this password - Master Yoda"
                Exit Sub
            Else
                strSQL = "UPDATE tblMembers SET Password = '" & strPassword & "' WHERE Username = '" & strUserName & "' AND intYear = " & clsFunctions.GetCurrentYear
            End If
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        End If

        ' Now, log them in...
        strSQL = "SELECT MemberID FROM tblMembers WHERE Username = '" & strUserName & "' AND Password = '" & strPassword & "' And intYear = " & clsFunctions.GetCurrentYear & " AND intActive <> 0"
        memberID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If memberID = 0 Then
            lblMessage.Text = "Invalid login information."
        Else
            Session("memgPassword") = strPassword.ToUpper
            Dim objMem As New clsMember(memberID, False)
            Session("memgMemberID") = memberID
            Session("memgSchool") = objMem.gSchool
            Session("memgSchoolID") = objMem.gSchoolID
            Session("memgCoachName") = objMem.gFullName
            Session("memgRole") = objMem.gRole
            '''''Session("memgTodaysDate") = ConfigurationManager.AppSettings("TodaysDate")
            Session("memdsCoachesSports") = clsMembers.GetTeamsDatasetFromCoach(Session("memgSchoolID"), clsFunctions.GetCurrentYear, Session("memgMemberID"))
            Session("memgNoOfSports") = Session("memdsCoachesSports").Tables(0).rows.count

            If Session("memgRole") = "OSSAAADMIN" Then
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
                    Session("memgShowRanking") = objTeam.getShowRanking
                    Session("memgResults") = objTeam.getResults
                    Session("memgPostGender") = objTeam.getPostGender
                    Session("memgMemberID") = objTeam.getMemberID          ' 8/23/2013 added...
                    Session("memgPlayoffSchedule") = objTeam.getPlayoffSchedule         ' 11/4/2013 added...
                    Session("memgPlayoffsState") = objTeam.getPlayoffsState
                    Session("memgPlayoffsRegionals") = objTeam.getPlayoffsRegional
                Else

                End If

                If Session("memgNoOfSports") = 0 Then
                    Me.lblMessage.Text = "This coach has not been assigned to a sport.  Please contact your Athletic Director."
                ElseIf Session("memgTeamID") = 0 And Session("memgNoOfSports") = 1 Then
                    lblMessage.Text = "Team information unavailable.  Please close your browser and come back and try logging in again.  We apologize for the inconvenience."
                Else
                    Response.Redirect("Home.aspx")
                End If
            End If
        End If

    End Sub

    Public Sub WriteCookie(ByVal strUsernameIn As String, ByVal strPasswordIn As String)
        If (Request.Browser.Cookies) Then
            If (Request.Cookies("OSSAARLOGIN") Is Nothing) Then
                Response.Cookies("OSSAARLOGIN").Expires = DateTime.Now.AddDays(30)
                Response.Cookies("OSSAARLOGIN")("UNAME") = strUsernameIn
                'Response.Cookies("OSSAARADLOGIN").Item("UPASS") = strPasswordIn
            Else
                Response.Cookies("OSSAARLOGIN")("UNAME") = strUsernameIn
                'Response.Cookies("OSSAARADLOGIN").Item("UPASS") = strPasswordIn
            End If
        End If
    End Sub

End Class