Public Class Schedule
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Get Scores...
        Session("BootstrapScores") = clsPageObjects.GetGamesList("Football", "09/20/2019")
        Session("BootstrapScores") = Session("BootstrapScores") & clsPageObjects.GetGamesList("BaseballFall", Now.ToShortDateString)
        Session("BootstrapScores") = Session("BootstrapScores") & clsPageObjects.GetGamesList("FPSoftball", Now.ToShortDateString)
        Session("BootstrapScores") = Session("BootstrapScores") & clsPageObjects.GetGamesList("Volleyball", Now.ToShortDateString)
    End Sub

End Class