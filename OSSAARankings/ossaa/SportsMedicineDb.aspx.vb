Public Class SportsMedicineDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "OSSAA Sports Medicine"
        Session("SportsMedicineContent") = clsWebBuilder.BuildPage("OSSAA.COM", "SportsMedicine", "100%")

    End Sub



End Class