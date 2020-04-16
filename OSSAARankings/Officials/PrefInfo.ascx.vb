Public Class PrefInfo
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.lblPrefInfo.Text = "Welcome : " & Session("userName") & " (" & Session("DistrictSchool") & " - " & Session("userPosition") & ")"
        Me.lblPrefInfo.Text = "Welcome : " & Session("prefCoachName") & " (" & Session("DistrictSchool") & ")"
    End Sub

End Class