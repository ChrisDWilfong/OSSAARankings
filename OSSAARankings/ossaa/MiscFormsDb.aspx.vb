Public Class MiscFormsDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "OSSAA Misc Forms"
        Session("MiscFormsContent") = clsWebBuilder.BuildPage("OSSAA.COM", "MiscForms", "100%")

    End Sub



End Class