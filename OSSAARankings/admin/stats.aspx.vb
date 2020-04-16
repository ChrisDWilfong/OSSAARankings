Public Class stats
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intCount As Integer
        Me.lblDate.Text = Now().Date
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(*) FROM tblMembersLogin WHERE strType = 'AD'")
        Me.lblMemberLoginsAD.Text = "# of Member Logins (AD) : " & intCount
        intCount = 0
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(*) FROM tblMembersLogin WHERE strType = 'COACH'")
        Me.lblMemberLoginsCoaches.Text = "# of Member Logins (Coaches) : " & intCount
        intCount = 0
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(*) FROM tblRosters")
        Me.lblRosters.Text = "# on Rosters : " & intCount
        intCount = 0
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(*) FROM tblMembers WHERE schoolID > 0 AND intActive <> 0")
        Me.lblCoachesNo.Text = "# of Coaches Entered : " & intCount
        intCount = 0
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(DISTINCT SchoolID) AS NoCoaches FROM tblMembers WHERE schoolID > 0 AND intActive <> 0")
        Me.lblSchoolSubmittedCoaches.Text = "# of Schools that have entered Coaches : " & intCount
        intCount = 0
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(*) AS NoCoaches FROM tblTeams WHERE memberID > 0")
        Me.lblCoachesAssignedToTeams.Text = "# of Coaches Assigned to Teams : " & intCount
        intCount = 0
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(*) AS NoCoaches FROM tblSchedules WHERE sportID Like 'Football%'")
        Me.lblSchedulesFootball.Text = "# of Games on Schedule (Football) : " & intCount
        intCount = 0
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(*) AS NoCoaches FROM tblSchedules WHERE sportID Like 'Volleyball%'")
        Me.lblSchedulesVolleyball.Text = "# of Games on Schedule (Volleyball) : " & intCount
        intCount = 0
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(*) AS NoCoaches FROM tblSchedules WHERE sportID Like 'FPSoftball%'")
        Me.lblSchedulesFPSoftball.Text = "# of Games on Schedule (Fast Pitch) : " & intCount
        intCount = 0
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(*) AS NoCoaches FROM tblSchedules WHERE sportID Like 'BasketballBoys%'")
        Me.lblSchedulesBasketballBoys.Text = "# of Games on Schedule (Basketball Boys) : " & intCount
        intCount = 0
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(*) AS NoCoaches FROM tblSchedules WHERE sportID Like 'BasketballGirls%'")
        Me.lblSchedulesBasketballGirls.Text = "# of Games on Schedule (Basketball Girls) : " & intCount
        intCount = 0
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(*) AS NoCoaches FROM tblSchedules WHERE sportID Like 'Wrestling%'")
        Me.lblSchedulesWrestling.Text = "# of Games on Schedule (Wrestling) : " & intCount
        intCount = 0
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(*) AS NoCoaches FROM tblSchedules")
        Me.lblSchedulesTotal.Text = "# of Games on Schedule (TOTAL) : " & intCount
        intCount = 0
        intCount = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(*) AS NoCoaches FROM Errors")
        Me.lblErrors.Text = intCount
    End Sub

End Class