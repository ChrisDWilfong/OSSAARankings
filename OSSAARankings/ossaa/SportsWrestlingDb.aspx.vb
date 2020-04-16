Public Class SportsWrestlingDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "OSSAA Wrestling"
        Session("sportsWrestlingContent") = clsWebBuilder.BuildPage("OSSAA.COM", "Wrestling", "100%")

    End Sub



End Class