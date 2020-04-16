Public Class ucHomePNew
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblVotingDelegate.Text = "Your current Voting Delegate is : " & Session("votingdelegate")
        Session("membersLinksPRIN") = clsLinks.GetLinks("OSSAAMembers", "PRIN", clsFunctions.GetCurrentYear)
    End Sub

End Class