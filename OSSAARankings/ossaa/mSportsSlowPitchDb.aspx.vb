Public Class mSportsSlowPitchDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("sportsSlowPitchContent") = clsWebBuilder.BuildPage("OSSAA.COM", "SlowPitch", "100%")

    End Sub



End Class