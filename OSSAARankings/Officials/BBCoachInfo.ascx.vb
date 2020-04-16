Public Class BBCoachInfo
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CoachIDGirls") > 0 And Session("CoachIDBoys") > 0 Then
            Me.lblCoachInfo.Text = "Welcome Coach : " & Session("CoachName") & " (" & Session("SchoolName") & ") - Head Boys and Girls Basketball Coach"
        ElseIf Session("CoachIDGirls") > 0 Then
            Me.lblCoachInfo.Text = "Welcome Coach : " & Session("CoachName") & " (" & Session("SchoolName") & ") - Head Girls Basketball Coach"
        ElseIf Session("CoachIDBoys") > 0 Then
            Me.lblCoachInfo.Text = "Welcome Coach : " & Session("CoachName") & " (" & Session("SchoolName") & ") - Head Boys Basketball Coach"
        Else
            Me.lblCoachInfo.Text = "Welcome Coach : " & Session("CoachName") & " (" & Session("SchoolName") & ")"
        End If
    End Sub

End Class