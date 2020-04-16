Public Class NonAthleticAcademicBowlDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "OSSAA Academic Bowl"
        Session("NAAcademicBowlContent") = clsWebBuilder.BuildPage("OSSAA.COM", "AcademicBowl", "100%")

    End Sub



End Class