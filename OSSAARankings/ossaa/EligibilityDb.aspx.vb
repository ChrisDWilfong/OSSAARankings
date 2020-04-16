Public Class EligibilityDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "OSSAA Eligibility"
        Session("EligibilityContent") = clsWebBuilder.BuildPage("OSSAA.COM", "Eligibility", "100%")

    End Sub



End Class