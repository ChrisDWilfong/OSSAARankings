Public Class ucHomeOSSAAAdminNew
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblVotingDelegate.Text = "Your current Voting Delegate is : " & Session("votingdelegate")
        Session("membersLinksOSSAA") = clsLinks.GetLinks("OSSAAMembers", "OSSAA", clsFunctions.GetCurrentYear)
    End Sub

    Private Sub cboSchool_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSchool.DataBound

        cboSchool.Items.Insert(0, "Select...")

    End Sub

    Protected Sub cboSchool_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboSchool.SelectedIndexChanged

        If Me.cboSchool.SelectedValue = "" Then
        Else
            Session("key") = Me.cboSchool.SelectedValue
            Session("school") = clsMembership.GetSchoolNameFromKey(Session("key"))
            Session("multi") = 0
            Session("idSchool") = clsMembership.FindSchoolId(Session("key"))
            Session("votingdelegate") = clsMembership.GetVotingDelegateInfo(Session("idSchool"))
            lblVotingDelegate.Text = "Your current Voting Delegate is : " & Session("votingdelegate")
        End If

    End Sub

    Protected Sub cmdGo_Click(sender As Object, e As EventArgs) Handles cmdGo.Click
        If Me.cboSchool.SelectedValue = "" Then
        Else
            Session("key") = Me.cboSchool.SelectedValue
            Session("school") = clsMembership.GetSchoolNameFromKey(Session("key"))
            Session("multi") = 0
            Session("idSchool") = clsMembership.FindSchoolId(Session("key"))
            Session("votingdelegate") = clsMembership.GetVotingDelegateInfo(Session("idSchool"))
            lblVotingDelegate.Text = "Your current Voting Delegate is : " & Session("votingdelegate")
        End If
    End Sub
End Class