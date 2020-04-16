Public Class SportsCheerDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "OSSAA Cheer"
        Session("sportsCheerContent") = clsWebBuilder.BuildPage("OSSAA.COM", "Cheer", "100%")

    End Sub



End Class