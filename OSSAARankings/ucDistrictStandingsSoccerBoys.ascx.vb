Imports AjaxControlToolkit

Public Class ucDistrictStandingsSoccerBoys
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'LoadGrids(cboClass1.SelectedValue, 0)
    End Sub

    Public Sub LoadGrids(ByVal strClass As String, ByVal intDistrict As Integer)

        Select Case cboClass1.SelectedValue
            Case "6A"
                GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 6A-1</b></span>"
                GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 6A-2</b></span>"
                GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 6A-3</b></span>"
                GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 6A-4</b></span>"
                GridView5.Visible = False
                GridView6.Visible = False
                GridView7.Visible = False
                GridView8.Visible = False
            Case "5A"
                GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 5A-1</b></span>"
                GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 5A-2</b></span>"
                GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 5A-3</b></span>"
                GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 5A-4</b></span>"
                GridView5.Visible = False
                GridView6.Visible = False
                GridView7.Visible = False
                GridView8.Visible = False
            Case "4A"
                GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-1</b></span>"
                GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-2</b></span>"
                GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-3</b></span>"
                GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-4</b></span>"
                GridView5.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-5</b></span>"
                GridView6.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-6</b></span>"
                GridView7.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-7</b></span>"
                GridView8.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-8</b></span>"
                GridView5.Visible = True
                GridView6.Visible = True
                GridView7.Visible = True
                GridView8.Visible = True
            Case Else
        End Select

        GridView1.SelectedIndex = -1
        GridView2.SelectedIndex = -1
        GridView3.SelectedIndex = -1
        GridView4.SelectedIndex = -1
        GridView5.SelectedIndex = -1
        GridView6.SelectedIndex = -1
        GridView7.SelectedIndex = -1
        GridView8.SelectedIndex = -1

        Session("schoolID") = -1

    End Sub

    Protected Sub cboClass1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClass1.SelectedIndexChanged
        LoadGrids(cboClass1.SelectedValue, 0)
    End Sub

    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim pce As PopupControlExtender = TryCast(e.Row.FindControl("PopupControlExtender1"), PopupControlExtender)

            Dim behaviorID As String = "pce_" & e.Row.RowIndex
            pce.BehaviorID = behaviorID

            Dim lblLabel As Label = DirectCast(e.Row.FindControl("lblSchool1"), Label)

            Dim OnMouseOverScript As String = String.Format("$find('{0}').showPopup();", behaviorID)
            Dim OnMouseOutScript As String = String.Format("$find('{0}').hidePopup();", behaviorID)

            lblLabel.Attributes.Add("onmouseover", OnMouseOverScript)
            lblLabel.Attributes.Add("onmouseout", OnMouseOutScript)
        End If

    End Sub
End Class