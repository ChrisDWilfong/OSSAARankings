Public Class FBCoachInfo
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblCoachInfo.Text = "Welcome Coach : " & Session("CoachName") & " (" & Session("SchoolName") & ")"
    End Sub

End Class