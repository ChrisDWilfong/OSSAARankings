Public Class mNonAthleticMusicDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "OSSAA Music"
        Session("NAMusicContent") = clsWebBuilder.BuildPage("OSSAA.COM", "Music", "100%")

    End Sub



End Class