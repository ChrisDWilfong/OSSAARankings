Public Class statsRankingsWinter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("gDateFrom") = "11/28/2013"
        Session("gDateTo") = "12/3/2013"

        lblBK6ABoys.Text = "Basketball Boys (6A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'BasketballBoys6A'")
        lblBK5ABoys.Text = "Basketball Boys (5A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'BasketballBoys5A'")
        lblBK4ABoys.Text = "Basketball Boys (4A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'BasketballBoys4A'")
        lblBK3ABoys.Text = "Basketball Boys (3A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'BasketballBoys3A'")
        lblBK2ABoys.Text = "Basketball Boys (2A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'BasketballBoys2A'")
        lblBKABoys.Text = "Basketball Boys (A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'BasketballBoysA'")
        lblBKBBoys.Text = "Basketball Boys (B) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'BasketballBoysB'")

        lblBK6AGirls.Text = "Basketball Girls (6A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'BasketballGirls6A'")
        lblBK5AGirls.Text = "Basketball Girls (5A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'BasketballGirls5A'")
        lblBK4AGirls.Text = "Basketball Girls (4A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'BasketballGirls4A'")
        lblBK3AGirls.Text = "Basketball Girls (3A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'BasketballGirls3A'")
        lblBK2AGirls.Text = "Basketball Girls (2A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'BasketballGirls2A'")
        lblBKAGirls.Text = "Basketball Girls (A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'BasketballGirlsA'")
        lblBKBGirls.Text = "Basketball Girls (B) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'BasketballGirlsB'")

        lblBKTotal.Text = "Basketball (TOTAL) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID Like 'Basketball%'")

        lblSW6ABoys.Text = "Swimming Boys (6A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'SwimmingBoys6A'")
        lblSW5ABoys.Text = "Swimming Boys (5A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'SwimmingBoys5A'")
        lblSW6AGirls.Text = "Swimming Girls (6A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'SwimmingGirls6A'")
        lblSW5AGirls.Text = "Swimming Girls (5A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'SwimmingGirls5A'")

        lblSWTotal.Text = "Swimming (TOTAL) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID Like 'Swimming%'")

        lblWR6A.Text = "Wrestling (6A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'Wrestling6A'")
        lblWR5A.Text = "Wrestling (5A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'Wrestling5A'")
        lblWR4A.Text = "Wrestling (4A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'Wrestling4A'")
        lblWR3A.Text = "Wrestling (3A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'Wrestling3A'")
        lblWRTotal.Text = "Wrestling (TOTAL) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID Like 'Wrestling%' AND Not sportID Like 'WrestlingDual%'")

        lblWRD6A.Text = "Wrestling Dual (6A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'WrestlingDual6A'")
        lblWRD5A.Text = "Wrestling Dual (5A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'WrestlingDual5A'")
        lblWRD4A.Text = "Wrestling Dual (4A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'WrestlingDual4A'")
        lblWRD3A.Text = "Wrestling Dual (3A) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID = 'WrestlingDual3A'")
        lblWRDTotal.Text = "Wrestling Dual (TOTAL) : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE sportID Like 'WrestlingDual%'")

        lblTotal.Text = "GRAND TOTAL : " & SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, CommandType.Text, "SELECT COUNT(sportID) FROM ossaauser.viewStatsSubmittedRankings WHERE (sportID Like 'Wrestling%') OR (sportID Like 'Swimming%') OR (sportID Like 'Basketball%')")

    End Sub

End Class