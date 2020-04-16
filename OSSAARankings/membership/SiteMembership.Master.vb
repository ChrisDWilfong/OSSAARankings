Partial Class SiteMembership
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") = "" Then
            Me.lblWelcome.Text = "Please login"
        Else
            Me.lblWelcome.Text = "Welcome <b>" & Session("user") & "</b> at <b>" & Session("school") & "</b>&nbsp;"
        End If

        If ConfigurationManager.AppSettings("ParticipationEntry") = 1 Then
            NavigationMenu.FindItem("Participation").Enabled = True
            NavigationMenu.FindItem("Participation").Text = "<span style='color:yellow'>Participation #</span>"
        Else
            NavigationMenu.FindItem("Participation").Enabled = False
            NavigationMenu.FindItem("Participation").Text = "<span style='color:gray'>Participation #</span>"
        End If

    End Sub

End Class