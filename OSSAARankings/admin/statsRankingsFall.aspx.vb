Public Class statsRankingsFall
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("gDateFrom") = "8/1/2013"
        Session("gDateTo") = "9/3/2013"

        'lblFP6A.Text = "Fast Pitch (6A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'FPSoftball6A'")
        'lblFP5A.Text = "Fast Pitch (5A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'FPSoftball5A'")
        'lblFP4A.Text = "Fast Pitch (4A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'FPSoftball4A'")
        lblFP3A.Text = "Fast Pitch (3A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'FPSoftball3A'")
        lblFP2A.Text = "Fast Pitch (2A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'FPSoftball2A'")
        lblFPA.Text = "Fast Pitch (A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'FPSoftballA'")
        lblFPB.Text = "Fast Pitch (B) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'FPSoftballB'")
        lblFPTotal.Text = "Fast Pitch (TOTAL) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID Like 'FPSoftball%'")

        lblVB6A.Text = "Volleyball (6A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'Volleyball6A'")
        lblVB5A.Text = "Volleyball (5A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'Volleyball5A'")
        lblVB4A.Text = "Volleyball (4A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'Volleyball4A'")
        lblVB3A.Text = "Volleyball (3A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'Volleyball3A'")
        lblVBTotal.Text = "Volleyball (TOTAL) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID Like 'Volleyball%'")

        lblFBBA.Text = "Fall Baseball (A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'BaseballFallA'")
        lblFBBB.Text = "Fall Baseball (B) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'BaseballFallB'")
        lblFBBTotal.Text = "Fall Baseball (TOTAL) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID Like 'BaseballFall%'")

        lblTotal.Text = "GRAND TOTAL : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE (sportID Like 'BaseballFall%') OR (sportID Like 'Volleyball%') OR (sportID Like 'FPSoftball%')")

    End Sub

End Class