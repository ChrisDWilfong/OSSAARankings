Public Class Test1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Dim intRanking As Integer = 0
        Session("memgCurrentWeekIDDisplay") = 7138
        intRanking = clsRankings.GetRankingByDate("BasketballGirls3A", 18689, "2015-01-12", Session("memgCurrentWeekIDDisplay"))
        lblMessage.Text = "Ranking : " & intRanking
    End Sub

    Private Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        Dim strResult As String
        strResult = clsTeams.GetTop20Record(53321, 20, 16)
        lblMessage.Text = strResult
    End Sub

    Private Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        Dim strResult As String = ""
        'strResult = clsEmail.SendEmail(Me, "Content", "cwilfong@ossaa.com", "", "Subject : Test Email", False)
        strResult = clsEmail.SendEmailNew("cwilfong@ossaa.com", "", "Test SUBJECT", "Test BODY", False, "OSSAA Test Email")
        lblMessage.Text = strResult
    End Sub
End Class