Public Class SportsTennisDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "OSSAA Tennis"
        Session("sportsTennisContent") = clsWebBuilder.BuildPage("OSSAA.COM", "Tennis", "100%")

    End Sub



End Class