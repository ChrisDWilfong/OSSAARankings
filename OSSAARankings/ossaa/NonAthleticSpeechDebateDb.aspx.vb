Public Class NonAthleticSpeechDebateDb
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Title = "OSSAA Speech and Debate"
        Session("NASpeechContent") = clsWebBuilder.BuildPage("OSSAA.COM", "SpeechDebate", "100%")

    End Sub



End Class