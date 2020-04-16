Public Class mMediaDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "OSSAA Media Information"
        Session("MediaContent") = clsWebBuilder.BuildPage("OSSAA.COM", "Media", "100%")

    End Sub



End Class