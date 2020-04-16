Public Class PrefInfoSC
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblPrefInfo.Text = "Welcome : " & Session("prefCoachName")
    End Sub

End Class