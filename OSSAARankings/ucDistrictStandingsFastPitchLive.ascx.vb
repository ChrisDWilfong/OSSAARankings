Public Class ucDistrictStandingsFastPitchLive
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cboClass1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClass1.SelectedIndexChanged
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
                GridView5.Visible = True
                GridView6.Visible = True
                GridView7.Visible = True
                GridView8.Visible = True
                GridView1.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-1</b></span>"
                GridView2.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-2</b></span>"
                GridView3.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-3</b></span>"
                GridView4.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-4</b></span>"
                GridView5.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-5</b></span>"
                GridView6.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-6</b></span>"
                GridView7.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-7</b></span>"
                GridView8.Caption = "<span style='font-family: Century Gothic; font-size: 14px; color:Navy;'><b>District 4A-8</b></span>"
            Case "3A"
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
            Case Else
        End Select

        GridView1.SelectedIndex = -1
        GridView2.SelectedIndex = -1
        GridView3.SelectedIndex = -1
        GridView4.SelectedIndex = -1

        Session("schoolID") = -1
    End Sub


End Class