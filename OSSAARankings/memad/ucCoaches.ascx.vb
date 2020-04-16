Public Class ucCoaches
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("madgCoachName") = "" Then
            Response.Redirect("adLogin.aspx")
        End If

        Select Case Session("madsel")
            Case "CoachAdd"
                PanelCoachAdd.Visible = True
                Session("madgCoachID") = 0
            Case "CoachEdit"
                If Request.QueryString("c") = "" Then
                Else
                    PanelCoachAdd.Visible = True
                    Session("madgCoachID") = Request.QueryString("c")
                End If
            Case "CoachesList"
                PanelCoachAdd.Visible = False
            Case Else
                PanelCoachAdd.Visible = False
        End Select

        If ucCoachAdd1.Visible Then
            PanelCoachList.Visible = False
        Else
        End If

    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As System.EventArgs) Handles cmdAdd.Click
        Response.Redirect("adHome.aspx?sel=CoachAdd")
    End Sub

End Class