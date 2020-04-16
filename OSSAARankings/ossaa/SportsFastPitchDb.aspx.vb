Public Class SportsFastPitchDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "OSSAA Fast Pitch"
        Session("sportsFastPitchContent") = clsWebBuilder.BuildPage("OSSAA.COM", "FastPitch", "100%")

    End Sub



End Class