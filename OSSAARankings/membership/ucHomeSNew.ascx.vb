Public Class ucHomeSNew
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblVotingDelegate.Text = "Your current Voting Delegate is : " & Session("votingdelegate")
        Session("membersLinksSUP") = clsLinks.GetLinks("OSSAAMembers", "SUP", clsFunctions.GetCurrentYear)
    End Sub

End Class