Imports AjaxControlToolkit

Public Class ucDistrictStandingsFootball
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadGrids(cboClass1.SelectedValue, 0)
    End Sub

    Protected Sub cboClass1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cboClass1.SelectedIndexChanged
        LoadGrids(cboClass1.SelectedValue, 0)
    End Sub

    Public Sub LoadGrids(ByVal strClass As String, ByVal intDistrict As Integer)
        Select Case strClass
            Case "6A"
                GridView1.Visible = True
                GridView2.Visible = True
                GridView3.Visible = True
                GridView4.Visible = True
                GridView5.Visible = False
                GridView6.Visible = False
                GridView7.Visible = False
                GridView8.Visible = False
                GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 6A Div I - 1</b></span>"
                GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 6A Div I - 2</b></span>"
                GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 6A Div II - 1</b></span>"
                GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 6A Div II - 2</b></span>"
            Case "5A"
                GridView1.Visible = True
                GridView2.Visible = True
                GridView3.Visible = True
                GridView4.Visible = True
                GridView5.Visible = False
                GridView6.Visible = False
                GridView7.Visible = False
                GridView8.Visible = False
                GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 5A-1</b></span>"
                GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 5A-2</b></span>"
                GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 5A-3</b></span>"
                GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 5A-4</b></span>"
            Case "4A"
                GridView1.Visible = True
                GridView2.Visible = True
                GridView3.Visible = True
                GridView4.Visible = True
                GridView5.Visible = False
                GridView6.Visible = False
                GridView7.Visible = False
                GridView8.Visible = False
                GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-1</b></span>"
                GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-2</b></span>"
                GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-3</b></span>"
                GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-4</b></span>"
            Case "3A"
                GridView1.Visible = True
                GridView2.Visible = True
                GridView3.Visible = True
                GridView4.Visible = True
                GridView5.Visible = True
                GridView6.Visible = True
                GridView7.Visible = True
                GridView8.Visible = True
                GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 3A-1</b></span>"
                GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 3A-2</b></span>"
                GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 3A-3</b></span>"
                GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 3A-4</b></span>"
                GridView5.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 3A-5</b></span>"
                GridView6.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 3A-6</b></span>"
                GridView7.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 3A-7</b></span>"
                GridView8.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 3A-8</b></span>"
            Case "2A"
                GridView1.Visible = True
                GridView2.Visible = True
                GridView3.Visible = True
                GridView4.Visible = True
                GridView5.Visible = True
                GridView6.Visible = True
                GridView7.Visible = True
                GridView8.Visible = True
                GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 2A-1</b></span>"
                GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 2A-2</b></span>"
                GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 2A-3</b></span>"
                GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 2A-4</b></span>"
                GridView5.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 2A-5</b></span>"
                GridView6.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 2A-6</b></span>"
                GridView7.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 2A-7</b></span>"
                GridView8.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 2A-8</b></span>"
            Case "A"
                GridView1.Visible = True
                GridView2.Visible = True
                GridView3.Visible = True
                GridView4.Visible = True
                GridView5.Visible = True
                GridView6.Visible = True
                GridView7.Visible = True
                GridView8.Visible = True
                GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District A-1</b></span>"
                GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District A-2</b></span>"
                GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District A-3</b></span>"
                GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District A-4</b></span>"
                GridView5.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District A-5</b></span>"
                GridView6.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District A-6</b></span>"
                GridView7.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District A-7</b></span>"
                GridView8.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District A-8</b></span>"
            Case "B"
                GridView1.Visible = True
                GridView2.Visible = True
                GridView3.Visible = True
                GridView4.Visible = True
                GridView5.Visible = True
                GridView6.Visible = True
                GridView7.Visible = True
                GridView8.Visible = True
                GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District B-1</b></span>"
                GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District B-2</b></span>"
                GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District B-3</b></span>"
                GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District B-4</b></span>"
                GridView5.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District B-5</b></span>"
                GridView6.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District B-6</b></span>"
                GridView7.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District B-7</b></span>"
                GridView8.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District B-8</b></span>"
            Case "C"
                GridView1.Visible = True
                GridView2.Visible = True
                GridView3.Visible = True
                GridView4.Visible = True
                GridView5.Visible = False
                GridView6.Visible = False
                GridView7.Visible = False
                GridView8.Visible = False
                GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District C-1</b></span>"
                GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District C-2</b></span>"
                GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District C-3</b></span>"
                GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District C-4</b></span>"
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