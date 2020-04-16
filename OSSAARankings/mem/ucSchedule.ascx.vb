Public Class ucSchedule
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Session("memgSport") = "Volleyball" Then
            lblMessageSpecial.Text = "<a href='https://vimeo.com/72465777' target='_blank'>Click here to see how to enter your game/match information.</a>"
        End If

        If Session("memgDistrict") > 0 Then
            lblDistrict.Visible = True
        Else
            lblDistrict.Visible = False
        End If

        Select Case Session("memsel")
            Case "ScheduleAdd"
                Session("memgScheduleID") = 0
                PanelScheduleAdd.Visible = True
                PanelScheduleTeam.Visible = False
            Case "ScheduleEdit", "ScheduleEditT"
                If Request.QueryString("g") = "" Then

                Else
                    PanelScheduleAdd.Visible = True
                    PanelScheduleTeam.Visible = False
                    Session("memgScheduleID") = Request.QueryString("g")
                End If
            Case "ScheduleTeam"
                PanelScheduleTeam.Visible = True
                PanelScheduleAdd.Visible = False
            Case "Schedule"
                PanelScheduleTeam.Visible = False
                PanelScheduleAdd.Visible = False
            Case Else
        End Select

        If ucScheduleAdd1.Visible Then
            PanelScheduleTeam.Enabled = False
            PanelScheduleList.Enabled = False
        Else
            PanelScheduleTeam.Enabled = True
            PanelScheduleList.Enabled = True
            ' Set the Add Button text...
            Select Case Session("memgSport")
                Case "Track", "CrossCountry", "Swimming"
                    cmdAdd.Text = "Add New Meet"
                Case "Wrestling"
                    cmdAdd.Text = "Add New Dual/Tourney"
                Case "Tennis", "Volleyball"
                    cmdAdd.Text = "Add New Match"
                Case Else
                    cmdAdd.Text = "Add New Game"
            End Select
        End If

    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("Home.aspx?sel=ScheduleAdd")
    End Sub

    Protected Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Response.Redirect("Home.aspx?sel=Schedule")
    End Sub
End Class