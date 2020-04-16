Public Class SportsCrossCountryDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "OSSAA Cross Country"
        Session("sportsCrossCountryContent") = clsWebBuilder.BuildPage("OSSAA.COM", "CrossCountry", "100%")

    End Sub



End Class