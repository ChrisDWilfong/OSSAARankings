Public Class OfficialInfo
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblOfficialInfo.Text = "Welcome : " & Session("OfficialName") & " (" & Session("OSSAAID") & ")"
    End Sub

End Class