Imports AjaxControlToolkit

Public Class ucDistrictStandingsBaseball
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadGrids(cboClass1.SelectedValue, 0)
    End Sub

    Public Sub LoadGrids(ByVal strClass As String, ByVal intDistrict As Integer)
        Dim objRow1 As Object = FindControl("grid1")
        Dim objRow2 As Object = FindControl("grid2")
        Dim objRow3 As Object = FindControl("grid3")
        Dim objRow4 As Object = FindControl("grid4")
        Dim objRow5 As Object = FindControl("grid5")
        Dim objRow6 As Object = FindControl("grid6")
        Dim objRow7 As Object = FindControl("grid7")
        Dim objRow8 As Object = FindControl("grid8")

        Select Case strClass
            Case "6A"
                objRow1.Visible = True
                objRow2.Visible = True
                objRow3.Visible = True
                objRow4.Visible = True
                objRow5.Visible = False
                objRow6.Visible = False
                objRow7.Visible = False
                objRow8.Visible = False
                GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 6A-1</b></span>"
                GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 6A-2</b></span>"
                GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 6A-3</b></span>"
                GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 6A-4</b></span>"
            Case "5A"
                objRow1.Visible = True
                objRow2.Visible = True
                objRow3.Visible = True
                objRow4.Visible = True
                objRow5.Visible = False
                objRow6.Visible = False
                objRow7.Visible = False
                objRow8.Visible = False
                GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 5A-1</b></span>"
                GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 5A-2</b></span>"
                GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 5A-3</b></span>"
                GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 5A-4</b></span>"
			Case "4A"
				objRow1.Visible = True
                objRow2.Visible = True
                objRow3.Visible = True
                objRow4.Visible = True
                objRow5.Visible = True
                objRow6.Visible = True
                objRow7.Visible = True
                objRow8.Visible = True
                GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-1</b></span>"
                GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-2</b></span>"
                GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-3</b></span>"
                GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-4</b></span>"
                GridView5.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-5</b></span>"
                GridView6.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-6</b></span>"
                GridView7.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-7</b></span>"
				GridView8.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-8</b></span>"
			Case "3A"
				objRow1.Visible = True
				objRow2.Visible = True
				objRow3.Visible = True
				objRow4.Visible = True
				objRow5.Visible = True
				objRow6.Visible = True
				objRow7.Visible = True
				objRow8.Visible = True
				GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 3A-1</b></span>"
				GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 3A-2</b></span>"
				GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 3A-3</b></span>"
				GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 3A-4</b></span>"
				GridView5.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 3A-5</b></span>"
				GridView6.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 3A-6</b></span>"
				GridView7.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 3A-7</b></span>"
				GridView8.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 3A-8</b></span>"
			Case "2A"
				objRow1.Visible = True
				objRow2.Visible = True
				objRow3.Visible = True
				objRow4.Visible = True
				objRow5.Visible = True
				objRow6.Visible = True
				objRow7.Visible = True
				objRow8.Visible = True
				GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 2A-1</b></span>"
				GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 2A-2</b></span>"
				GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 2A-3</b></span>"
				GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 2A-4</b></span>"
				GridView5.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 2A-5</b></span>"
				GridView6.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 2A-6</b></span>"
				GridView7.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 2A-7</b></span>"
				GridView8.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 2A-8</b></span>"

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