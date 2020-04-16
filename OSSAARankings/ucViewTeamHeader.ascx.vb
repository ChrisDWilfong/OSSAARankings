Public Class ucViewTeamHeader
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim objTeamInfo As New clsTeam(Session("gTeamID"))
        Session("gTeamPicture") = objTeamInfo.getTeamPicture
        If objTeamInfo.getTeamPictureShow = False Then
            Session("gTeamPicture") = ""
        End If
        Dim intCurrentRank As Integer = 0
        intCurrentRank = clsRankings.GetCurrentRank(Session("gSportID"), Session("gTeamID"), Now)

        lblSchool.Text = objTeamInfo.getSchool & " TEAM PAGE"

        If intCurrentRank > 0 Then
            If Session("gSportID") = "FPSoftball6A" Or Session("gSportID") = "FPSoftball5A" Then
                lblTeamSport.Text = "Class " & objTeamInfo.getClass & " " & objTeamInfo.getSportGenderDisplay & " (" & objTeamInfo.getWL & ")"
            Else
                lblTeamSport.Text = "Class " & objTeamInfo.getClass & " " & objTeamInfo.getSportGenderDisplay & " (" & objTeamInfo.getWL & ") #" & intCurrentRank
            End If
        Else
            lblTeamSport.Text = "Class " & objTeamInfo.getClass & " " & objTeamInfo.getSportGenderDisplay & " (" & objTeamInfo.getWL & ")"
        End If
            lblHeadCoach.Text = "Head Coach : " & objTeamInfo.getHeadCoach

    End Sub

End Class