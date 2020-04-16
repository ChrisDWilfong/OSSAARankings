Public Class mSportsTrackDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "OSSAA Track"
        Session("sportsTrackContent") = clsWebBuilder.BuildPage("OSSAA.COM", "Track", "100%")

    End Sub



End Class