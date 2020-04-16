Imports System.Data.SqlClient
Imports System.Xml
Imports System.Data

Partial Class FBAssignors
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            RefreshAllSports()
            RefreshDetails("")
            LoadData("", False)
        Else
            LoadData(Me.txtEmail.Text, False)
        End If
    End Sub

    Public Sub ActivateAssignorDetail(ysnActivate As Boolean)

        colA002.Visible = ysnActivate
        lblSubHeader002.Visible = ysnActivate
        cbSiteMetroOKC.Visible = ysnActivate
        If ysnActivate Then cbSiteMetroOKC.Checked = False
        cbSiteMetroTulsa.Visible = ysnActivate
        If ysnActivate Then cbSiteMetroTulsa.Checked = False
        cbSiteEastern.Visible = ysnActivate
        If ysnActivate Then cbSiteEastern.Checked = False
        cbSiteLawton.Visible = ysnActivate
        If ysnActivate Then cbSiteLawton.Checked = False
        cbSiteNE.Visible = ysnActivate
        If ysnActivate Then cbSiteNE.Checked = False
        cbSiteNW.Visible = ysnActivate
        If ysnActivate Then cbSiteNW.Checked = False
        cbSitePanhandle.Visible = ysnActivate
        If ysnActivate Then cbSitePanhandle.Checked = False
        cbSiteSCentral.Visible = ysnActivate
        If ysnActivate Then cbSiteSCentral.Checked = False
        cbSiteSE.Visible = ysnActivate
        If ysnActivate Then cbSiteSE.Checked = False
        cbSiteStillwater.Visible = ysnActivate
        If ysnActivate Then cbSiteStillwater.Checked = False
        cbSiteSW.Visible = ysnActivate
        If ysnActivate Then cbSiteSW.Checked = False

        CheckBoxList1.Visible = ysnActivate
        CheckBoxList2.Visible = ysnActivate
        CheckBoxList3.Visible = ysnActivate
        CheckBoxList4.Visible = ysnActivate
        CheckBoxList5.Visible = ysnActivate
        CheckBoxList6.Visible = ysnActivate
        CheckBoxList7.Visible = ysnActivate
        CheckBoxList8.Visible = ysnActivate
        CheckBoxList9.Visible = ysnActivate
        CheckBoxList10.Visible = ysnActivate
        CheckBoxList11.Visible = ysnActivate

    End Sub

    Public Sub LoadData(strEmail As String, ysnDoCheckboxes As Boolean)
        Dim strSQL As String
        Dim ds As DataSet
        Dim intOfficialID As Integer = 0

        If strEmail = "" Then
            row001.Visible = False
            row002.Visible = False
            row003.Visible = False
            row004.Visible = False
            rowAssignorInfoHeader.Visible = False
            rowAssignorInfo.Visible = False
        Else
            ' Load Assignor Info...
            strSQL = "SELECT * FROM tblOfficialsAssignors WHERE strEmail = '" & Me.txtEmail.Text & "'"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If ds Is Nothing Then
                intOfficialID = 0
            ElseIf ds.Tables.Count = 0 Then
                intOfficialID = 0
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                intOfficialID = 0
            Else
                intOfficialID = ds.Tables(0).Rows(0).Item("Id")
            End If

            If intOfficialID = 0 Then       ' Insert new record...
                strSQL = "INSERT INTO tblOfficialsAssignors (strEmail, intYear) VALUES ('" & txtEmail.Text & "'," & clsFunctions.GetCurrentYear & ")"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                strSQL = "SELECT * FROM tblOfficialsAssignors WHERE strEmail = '" & Me.txtEmail.Text & "'"
                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                intOfficialID = ds.Tables(0).Rows(0).Item("Id")
            End If

            With ds.Tables(0).Rows(0)
                row001.Visible = True
                row002.Visible = True
                row003.Visible = True
                row004.Visible = True
                txtEmail.Enabled = False
                rowAssignorInfoHeader.Visible = True
                rowAssignorInfo.Visible = True
                If txtName.Text = "" Then
                    txtName.Text = IIf(.Item("strName") Is System.DBNull.Value, "", .Item("strName"))
                End If
                If txtOSSAAID.Text = "" Then
                    txtOSSAAID.Text = IIf(.Item("strOSSAAID") Is System.DBNull.Value, "", .Item("strOSSAAID"))
                End If
                If txtAddress.Text = "" Then
                    txtAddress.Text = IIf(.Item("strAddress") Is System.DBNull.Value, "", .Item("strAddress"))
                End If
                If txtCity.Text = "" Then
                    txtCity.Text = IIf(.Item("strCity") Is System.DBNull.Value, "", .Item("strCity"))
                End If
                If txtState.Text = "" Then
                    txtState.Text = IIf(.Item("strState") Is System.DBNull.Value, "OK", .Item("strState"))
                End If
                If txtZip.Text = "" Then
                    txtZip.Text = IIf(.Item("strZip") Is System.DBNull.Value, "", .Item("strZip"))
                End If
            End With

            Dim x As Integer
            ' Now load Assignor Detail info...
            strSQL = "SELECT * FROM tblOfficialsAssignorsDetail WHERE strEmailKey = '" & Me.txtEmail.Text & "'"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If ds Is Nothing Then
                colA002.Visible = False
            ElseIf ds.Tables.Count = 0 Then
                colA002.Visible = False
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                colA002.Visible = False
            Else
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    With ds.Tables(0).Rows(x)
                        Select Case .Item("strSport")
                            Case "Baseball"
                                If ysnDoCheckboxes Then cbBaseball.Checked = True
                                ShowDetails(.Item("strSport"), 1)
                            Case "Basketball"
                                If ysnDoCheckboxes Then cbBasketball.Checked = True
                                ShowDetails(.Item("strSport"), 1)
                            Case "Football"
                                If ysnDoCheckboxes Then cbFootball.Checked = True
                                ShowDetails(.Item("strSport"), 1)
                            Case "SoftballFP"
                                If ysnDoCheckboxes Then cbSoftballFP.Checked = True
                                ShowDetails(.Item("strSport"), 1)
                            Case "SoftballSP"
                                If ysnDoCheckboxes Then cbSoftballSP.Checked = True
                                ShowDetails(.Item("strSport"), 1)
                            Case "Soccer"
                                If ysnDoCheckboxes Then cbSoccer.Checked = True
                                ShowDetails(.Item("strSport"), 1)
                            Case "Volleyball"
                                If ysnDoCheckboxes Then cbVolleyball.Checked = True
                                ShowDetails(.Item("strSport"), 1)
                            Case "Wrestling"
                                If ysnDoCheckboxes Then cbWrestling.Checked = True
                                ShowDetails(.Item("strSport"), 1)
                        End Select
                    End With
                Next

                ' Don't show Sport Details..
                ActivateAssignorDetail(False)

            End If
        End If

    End Sub

    Public Function ShowDetail(strSport As String, strEmail As String) As String
        Dim strSQL As String = ""
        Dim dr As SqlDataReader
        Dim strReturn As String = ""

        strSQL = "SELECT * FROM tblOfficialsAssignorsDetail WHERE strEmailKey = '" & strEmail & "' AND strSport = '" & strSport & "' AND intYear = " & clsFunctions.GetCurrentYear
        dr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        While dr.Read
            strReturn += dr("strArea")
            strReturn += " - "
            If dr("intLevelElem") = 1 Then
                strReturn += ": Elem "
            End If
            If dr("intLevelMS") = 1 Then
                strReturn += ": MS "
            End If
            If dr("intLevelJH") = 1 Then
                strReturn += ": JRH "
            End If
            If dr("intLevelJV") = 1 Then
                strReturn += ": Sub-Var "
            End If
            If dr("intLevelV") = 1 Then
                strReturn += ": Varsity "
            End If
            strReturn += "<br> "
        End While

        Return strReturn
    End Function

    Public Sub ShowDetails(strSport As String, intOverride As Integer)
        Select Case strSport
            Case "Baseball"
                If cbBaseball.Checked Or intOverride = 1 Then
                    cmdBaseball.Visible = True
                    lblBaseballDetail.Text = ShowDetail("Baseball", Me.txtEmail.Text)
                Else
                    cmdBaseball.Visible = False
                    lblBaseballDetail.Text = ""
                End If
            Case "Basketball"
                If cbBasketball.Checked Or intOverride = 1 Then
                    cmdBasketball.Visible = True
                    lblBasketballDetail.Text = ShowDetail("Basketball", Me.txtEmail.Text)
                Else
                    cmdBasketball.Visible = False
                    lblBasketballDetail.Text = ""
                End If
            Case "Football"
                If cbFootball.Checked Or intOverride = 1 Then
                    cmdFootball.Visible = True
                    lblFootballDetail.Text = ShowDetail("Football", Me.txtEmail.Text)
                Else
                    cmdFootball.Visible = False
                    lblFootballDetail.Text = ""
                End If
            Case "Soccer"
                If cbSoccer.Checked Or intOverride = 1 Then
                    cmdSoccer.Visible = True
                    lblSoccerDetail.Text = ShowDetail("Soccer", Me.txtEmail.Text)
                Else
                    cmdSoccer.Visible = False
                    lblSoccerDetail.Text = ""
                End If
            Case "SoftballFP"
                If cbSoftballFP.Checked Or intOverride = 1 Then
                    cmdSoftballFP.Visible = True
                    lblSoftballFPDetail.Text = ShowDetail("SoftballFP", Me.txtEmail.Text)
                Else
                    cmdSoftballFP.Visible = False
                    lblSoftballFPDetail.Text = ""
                End If
            Case "SoftballSP"
                If cbSoftballSP.Checked Or intOverride = 1 Then
                    cmdSoftballSP.Visible = True
                    lblSoftballSPDetail.Text = ShowDetail("SoftballSP", Me.txtEmail.Text)
                Else
                    cmdSoftballSP.Visible = False
                    lblSoftballSPDetail.Text = ""
                End If
            Case "Volleyball"
                If cbVolleyball.Checked Or intOverride = 1 Then
                    cmdVolleyball.Visible = True
                    lblVolleyballDetail.Text = ShowDetail("Volleyball", Me.txtEmail.Text)
                Else
                    cmdVolleyball.Visible = False
                    lblVolleyballDetail.Text = ""
                End If
            Case "Wrestling"
                If cbWrestling.Checked Or intOverride = 1 Then
                    cmdWrestling.Visible = True
                    lblWrestlingDetail.Text = ShowDetail("Wrestling", Me.txtEmail.Text)
                Else
                    cmdWrestling.Visible = False
                    lblWrestlingDetail.Text = ""
                End If

        End Select
    End Sub

    Public Sub RefreshAllSports()
        ShowDetails("Baseball", 0)
        ShowDetails("Basketball", 0)
        ShowDetails("Football", 0)
        ShowDetails("SoftballFP", 0)
        ShowDetails("SoftballSP", 0)
        ShowDetails("Soccer", 0)
        ShowDetails("Volleyball", 0)
        ShowDetails("Wrestling", 0)
    End Sub

    Public Sub LoadAssignorDetail(strSport As String)
        Dim dr As SqlDataReader
        Dim strSQL As String
        Dim x As Integer = 0

        strSQL = "SELECT * FROM tblOfficialsAssignorsDetail WHERE strEmailKey = '" & Me.txtEmail.Text & "' AND strSport = '" & strSport & "'"
        dr = SqlHelper.ExecuteReader(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        ActivateAssignorDetail(True)
        lblSiteMetroOKC.BackColor = Drawing.Color.White
        lblSiteMetroTulsa.BackColor = Drawing.Color.White
        lblSiteEastern.BackColor = Drawing.Color.White
        lblSiteLawton.BackColor = Drawing.Color.White
        lblSiteNE.BackColor = Drawing.Color.White
        lblSiteNW.BackColor = Drawing.Color.White
        lblSitePanhandle.BackColor = Drawing.Color.White
        lblSiteSCentral.BackColor = Drawing.Color.White
        lblSiteSE.BackColor = Drawing.Color.White
        lblSiteStillwater.BackColor = Drawing.Color.White
        lblSiteSW.BackColor = Drawing.Color.White

        ' Clear all checkboxes...
        CheckBoxList1.Items(0).Selected = False
        CheckBoxList1.Items(1).Selected = False
        CheckBoxList1.Items(2).Selected = False
        CheckBoxList1.Items(3).Selected = False
        CheckBoxList1.Items(4).Selected = False

        CheckBoxList2.Items(0).Selected = False
        CheckBoxList2.Items(1).Selected = False
        CheckBoxList2.Items(2).Selected = False
        CheckBoxList2.Items(3).Selected = False
        CheckBoxList2.Items(4).Selected = False

        CheckBoxList3.Items(0).Selected = False
        CheckBoxList3.Items(1).Selected = False
        CheckBoxList3.Items(2).Selected = False
        CheckBoxList3.Items(3).Selected = False
        CheckBoxList3.Items(4).Selected = False

        CheckBoxList4.Items(0).Selected = False
        CheckBoxList4.Items(1).Selected = False
        CheckBoxList4.Items(2).Selected = False
        CheckBoxList4.Items(3).Selected = False
        CheckBoxList4.Items(4).Selected = False

        CheckBoxList5.Items(0).Selected = False
        CheckBoxList5.Items(1).Selected = False
        CheckBoxList5.Items(2).Selected = False
        CheckBoxList5.Items(3).Selected = False
        CheckBoxList5.Items(4).Selected = False

        CheckBoxList6.Items(0).Selected = False
        CheckBoxList6.Items(1).Selected = False
        CheckBoxList6.Items(2).Selected = False
        CheckBoxList6.Items(3).Selected = False
        CheckBoxList6.Items(4).Selected = False

        CheckBoxList7.Items(0).Selected = False
        CheckBoxList7.Items(1).Selected = False
        CheckBoxList7.Items(2).Selected = False
        CheckBoxList7.Items(3).Selected = False
        CheckBoxList7.Items(4).Selected = False

        CheckBoxList8.Items(0).Selected = False
        CheckBoxList8.Items(1).Selected = False
        CheckBoxList8.Items(2).Selected = False
        CheckBoxList8.Items(3).Selected = False
        CheckBoxList8.Items(4).Selected = False

        CheckBoxList9.Items(0).Selected = False
        CheckBoxList9.Items(1).Selected = False
        CheckBoxList9.Items(2).Selected = False
        CheckBoxList9.Items(3).Selected = False
        CheckBoxList9.Items(4).Selected = False

        CheckBoxList10.Items(0).Selected = False
        CheckBoxList10.Items(1).Selected = False
        CheckBoxList10.Items(2).Selected = False
        CheckBoxList10.Items(3).Selected = False
        CheckBoxList10.Items(4).Selected = False

        CheckBoxList11.Items(0).Selected = False
        CheckBoxList11.Items(1).Selected = False
        CheckBoxList11.Items(2).Selected = False
        CheckBoxList11.Items(3).Selected = False
        CheckBoxList11.Items(4).Selected = False

        While dr.Read
            Select Case dr("strArea")
                Case "Metro-OKC"
                    cbSiteMetroOKC.Checked = True
                    lblSiteMetroOKC.BackColor = Drawing.Color.DarkOrange
                    If dr("intLevelElem") = 1 Then
                        CheckBoxList1.Items(0).Selected = True
                    Else
                        CheckBoxList1.Items(0).Selected = False
                    End If
                    If dr("intLevelMS") = 1 Then
                        CheckBoxList1.Items(1).Selected = True
                    Else
                        CheckBoxList1.Items(1).Selected = False
                    End If
                    If dr("intLevelJH") = 1 Then
                        CheckBoxList1.Items(2).Selected = True
                    Else
                        CheckBoxList1.Items(2).Selected = False
                    End If
                    If dr("intLevelJV") = 1 Then
                        CheckBoxList1.Items(3).Selected = True
                    Else
                        CheckBoxList1.Items(3).Selected = False
                    End If
                    If dr("intLevelV") = 1 Then
                        CheckBoxList1.Items(4).Selected = True
                    Else
                        CheckBoxList1.Items(4).Selected = False
                    End If
                Case "Metro-Tulsa"
                    cbSiteMetroTulsa.Checked = True
                    lblSiteMetroTulsa.BackColor = Drawing.Color.DarkOrange
                    If dr("intLevelElem") = 1 Then
                        CheckBoxList2.Items(0).Selected = True
                    Else
                        CheckBoxList2.Items(0).Selected = False
                    End If
                    If dr("intLevelMS") = 1 Then
                        CheckBoxList2.Items(1).Selected = True
                    Else
                        CheckBoxList2.Items(1).Selected = False
                    End If
                    If dr("intLevelJH") = 1 Then
                        CheckBoxList2.Items(2).Selected = True
                    Else
                        CheckBoxList2.Items(2).Selected = False
                    End If
                    If dr("intLevelJV") = 1 Then
                        CheckBoxList2.Items(3).Selected = True
                    Else
                        CheckBoxList2.Items(3).Selected = False
                    End If
                    If dr("intLevelV") = 1 Then
                        CheckBoxList2.Items(4).Selected = True
                    Else
                        CheckBoxList2.Items(4).Selected = False
                    End If
                Case "Lawton Area"
                    cbSiteLawton.Checked = True
                    lblSiteLawton.BackColor = Drawing.Color.DarkOrange
                    If dr("intLevelElem") = 1 Then
                        CheckBoxList3.Items(0).Selected = True
                    Else
                        CheckBoxList3.Items(0).Selected = False
                    End If
                    If dr("intLevelMS") = 1 Then
                        CheckBoxList3.Items(1).Selected = True
                    Else
                        CheckBoxList3.Items(1).Selected = False
                    End If
                    If dr("intLevelJH") = 1 Then
                        CheckBoxList3.Items(2).Selected = True
                    Else
                        CheckBoxList3.Items(2).Selected = False
                    End If
                    If dr("intLevelJV") = 1 Then
                        CheckBoxList3.Items(3).Selected = True
                    Else
                        CheckBoxList3.Items(3).Selected = False
                    End If
                    If dr("intLevelV") = 1 Then
                        CheckBoxList3.Items(4).Selected = True
                    Else
                        CheckBoxList3.Items(4).Selected = False
                    End If
                Case "Panhandle"
                    cbSitePanhandle.Checked = True
                    lblSitePanhandle.BackColor = Drawing.Color.DarkOrange
                    If dr("intLevelElem") = 1 Then
                        CheckBoxList4.Items(0).Selected = True
                    Else
                        CheckBoxList4.Items(0).Selected = False
                    End If
                    If dr("intLevelMS") = 1 Then
                        CheckBoxList4.Items(1).Selected = True
                    Else
                        CheckBoxList4.Items(1).Selected = False
                    End If
                    If dr("intLevelJH") = 1 Then
                        CheckBoxList4.Items(2).Selected = True
                    Else
                        CheckBoxList4.Items(2).Selected = False
                    End If
                    If dr("intLevelJV") = 1 Then
                        CheckBoxList4.Items(3).Selected = True
                    Else
                        CheckBoxList4.Items(3).Selected = False
                    End If
                    If dr("intLevelV") = 1 Then
                        CheckBoxList4.Items(4).Selected = True
                    Else
                        CheckBoxList4.Items(4).Selected = False
                    End If
                Case "Stillwater Area"
                    cbSiteStillwater.Checked = True
                    lblSiteStillwater.BackColor = Drawing.Color.DarkOrange
                    If dr("intLevelElem") = 1 Then
                        CheckBoxList5.Items(0).Selected = True
                    Else
                        CheckBoxList5.Items(0).Selected = False
                    End If
                    If dr("intLevelMS") = 1 Then
                        CheckBoxList5.Items(1).Selected = True
                    Else
                        CheckBoxList5.Items(1).Selected = False
                    End If
                    If dr("intLevelJH") = 1 Then
                        CheckBoxList5.Items(2).Selected = True
                    Else
                        CheckBoxList5.Items(2).Selected = False
                    End If
                    If dr("intLevelJV") = 1 Then
                        CheckBoxList5.Items(3).Selected = True
                    Else
                        CheckBoxList5.Items(3).Selected = False
                    End If
                    If dr("intLevelV") = 1 Then
                        CheckBoxList5.Items(4).Selected = True
                    Else
                        CheckBoxList5.Items(4).Selected = False
                    End If
                Case "Northwest OK"
                    cbSiteNW.Checked = True
                    lblSiteNW.BackColor = Drawing.Color.DarkOrange
                    If dr("intLevelElem") = 1 Then
                        CheckBoxList6.Items(0).Selected = True
                    Else
                        CheckBoxList6.Items(0).Selected = False
                    End If
                    If dr("intLevelMS") = 1 Then
                        CheckBoxList6.Items(1).Selected = True
                    Else
                        CheckBoxList6.Items(1).Selected = False
                    End If
                    If dr("intLevelJH") = 1 Then
                        CheckBoxList6.Items(2).Selected = True
                    Else
                        CheckBoxList6.Items(2).Selected = False
                    End If
                    If dr("intLevelJV") = 1 Then
                        CheckBoxList6.Items(3).Selected = True
                    Else
                        CheckBoxList6.Items(3).Selected = False
                    End If
                    If dr("intLevelV") = 1 Then
                        CheckBoxList6.Items(4).Selected = True
                    Else
                        CheckBoxList6.Items(4).Selected = False
                    End If
                Case "Southwest OK"
                    cbSiteSW.Checked = True
                    lblSiteSW.BackColor = Drawing.Color.DarkOrange
                    If dr("intLevelElem") = 1 Then
                        CheckBoxList7.Items(0).Selected = True
                    Else
                        CheckBoxList7.Items(0).Selected = False
                    End If
                    If dr("intLevelMS") = 1 Then
                        CheckBoxList7.Items(1).Selected = True
                    Else
                        CheckBoxList7.Items(1).Selected = False
                    End If
                    If dr("intLevelJH") = 1 Then
                        CheckBoxList7.Items(2).Selected = True
                    Else
                        CheckBoxList7.Items(2).Selected = False
                    End If
                    If dr("intLevelJV") = 1 Then
                        CheckBoxList7.Items(3).Selected = True
                    Else
                        CheckBoxList7.Items(3).Selected = False
                    End If
                    If dr("intLevelV") = 1 Then
                        CheckBoxList7.Items(4).Selected = True
                    Else
                        CheckBoxList7.Items(4).Selected = False
                    End If
                Case "Northeast OK"
                    cbSiteNE.Checked = True
                    lblSiteNE.BackColor = Drawing.Color.DarkOrange
                    If dr("intLevelElem") = 1 Then
                        CheckBoxList8.Items(0).Selected = True
                    Else
                        CheckBoxList8.Items(0).Selected = False
                    End If
                    If dr("intLevelMS") = 1 Then
                        CheckBoxList8.Items(1).Selected = True
                    Else
                        CheckBoxList8.Items(1).Selected = False
                    End If
                    If dr("intLevelJH") = 1 Then
                        CheckBoxList8.Items(2).Selected = True
                    Else
                        CheckBoxList8.Items(2).Selected = False
                    End If
                    If dr("intLevelJV") = 1 Then
                        CheckBoxList8.Items(3).Selected = True
                    Else
                        CheckBoxList8.Items(3).Selected = False
                    End If
                    If dr("intLevelV") = 1 Then
                        CheckBoxList8.Items(4).Selected = True
                    Else
                        CheckBoxList8.Items(4).Selected = False
                    End If
                Case "Southeast OK"
                    cbSiteSE.Checked = True
                    lblSiteSE.BackColor = Drawing.Color.DarkOrange
                    If dr("intLevelElem") = 1 Then
                        CheckBoxList9.Items(0).Selected = True
                    Else
                        CheckBoxList9.Items(0).Selected = False
                    End If
                    If dr("intLevelMS") = 1 Then
                        CheckBoxList9.Items(1).Selected = True
                    Else
                        CheckBoxList9.Items(1).Selected = False
                    End If
                    If dr("intLevelJH") = 1 Then
                        CheckBoxList9.Items(2).Selected = True
                    Else
                        CheckBoxList9.Items(2).Selected = False
                    End If
                    If dr("intLevelJV") = 1 Then
                        CheckBoxList9.Items(3).Selected = True
                    Else
                        CheckBoxList9.Items(3).Selected = False
                    End If
                    If dr("intLevelV") = 1 Then
                        CheckBoxList9.Items(4).Selected = True
                    Else
                        CheckBoxList9.Items(4).Selected = False
                    End If
                Case "South Central OK"
                    cbSiteSCentral.Checked = True
                    lblSiteSCentral.BackColor = Drawing.Color.DarkOrange
                    If dr("intLevelElem") = 1 Then
                        CheckBoxList10.Items(0).Selected = True
                    Else
                        CheckBoxList10.Items(0).Selected = False
                    End If
                    If dr("intLevelMS") = 1 Then
                        CheckBoxList10.Items(1).Selected = True
                    Else
                        CheckBoxList10.Items(1).Selected = False
                    End If
                    If dr("intLevelJH") = 1 Then
                        CheckBoxList10.Items(2).Selected = True
                    Else
                        CheckBoxList10.Items(2).Selected = False
                    End If
                    If dr("intLevelJV") = 1 Then
                        CheckBoxList10.Items(3).Selected = True
                    Else
                        CheckBoxList10.Items(3).Selected = False
                    End If
                    If dr("intLevelV") = 1 Then
                        CheckBoxList10.Items(4).Selected = True
                    Else
                        CheckBoxList10.Items(4).Selected = False
                    End If
                Case "Eastern OK"
                    cbSiteEastern.Checked = True
                    lblSiteEastern.BackColor = Drawing.Color.DarkOrange
                    If dr("intLevelElem") = 1 Then
                        CheckBoxList11.Items(0).Selected = True
                    Else
                        CheckBoxList11.Items(0).Selected = False
                    End If
                    If dr("intLevelMS") = 1 Then
                        CheckBoxList11.Items(1).Selected = True
                    Else
                        CheckBoxList11.Items(1).Selected = False
                    End If
                    If dr("intLevelJH") = 1 Then
                        CheckBoxList11.Items(2).Selected = True
                    Else
                        CheckBoxList11.Items(2).Selected = False
                    End If
                    If dr("intLevelJV") = 1 Then
                        CheckBoxList11.Items(3).Selected = True
                    Else
                        CheckBoxList11.Items(3).Selected = False
                    End If
                    If dr("intLevelV") = 1 Then
                        CheckBoxList11.Items(4).Selected = True
                    Else
                        CheckBoxList11.Items(4).Selected = False
                    End If
            End Select

        End While

    End Sub

    Public Sub TurnOffCheckBox(strSport As String)
        ' When checkbox is UNCHECKED...
        Dim strSQL As String
        strSQL = "DELETE FROM tblOfficialsAssignorsDetail WHERE strEmailKey = '" & Me.txtEmail.Text & "' AND strSport = '" & strSport & "' AND intYear = " & clsFunctions.GetCurrentYear
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
    End Sub
    Public Sub RefreshDetails(strSport As String)
        ActivateAssignorDetail(True)
        Select Case strSport
            Case "Baseball"
                If cbBaseball.Checked Then
                    lblSubHeader002.Text = "Select Area(s) You Assign For Baseball"
                    LoadAssignorDetail(strSport)
                End If
            Case "Basketball"
                If cbBasketball.Checked Then
                    lblSubHeader002.Text = "Select Area(s) You Assign For Basketball"
                    LoadAssignorDetail(strSport)
                End If
            Case "Football"
                If cbFootball.Checked Then
                    lblSubHeader002.Text = "Select Area(s) You Assign For Football"
                    LoadAssignorDetail(strSport)
                End If
            Case "SoftballFP"
                If cbSoftballFP.Checked Then
                    lblSubHeader002.Text = "Select Area(s) You Assign For Fast-Pitch"
                    LoadAssignorDetail(strSport)
                End If
            Case "SoftballSP"
                If cbSoftballSP.Checked Then
                    lblSubHeader002.Text = "Select Area(s) You Assign For Slow-Pitch"
                    LoadAssignorDetail(strSport)
                End If
            Case "Soccer"
                If cbSoccer.Checked Then
                    lblSubHeader002.Text = "Select Area(s) You Assign For Soccer"
                    LoadAssignorDetail(strSport)
                End If
            Case "Volleyball"
                If cbVolleyball.Checked Then
                    lblSubHeader002.Text = "Select Area(s) You Assign For Volleyball"
                    LoadAssignorDetail(strSport)
                End If
            Case "Wrestling"
                If cbWrestling.Checked Then
                    lblSubHeader002.Text = "Select Area(s) You Assign For Wrestling"
                    LoadAssignorDetail(strSport)
                End If
            Case Else
                lblSubHeader002.Text = "Select Area(s) You Assign"
        End Select
    End Sub

    Private Sub cbBaseball_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbBaseball.CheckedChanged
        TurnOffCheckBox("Baseball")
        RefreshAllSports()
    End Sub

    Private Sub cbBasketball_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbBasketball.CheckedChanged
        TurnOffCheckBox("Basketball")
        RefreshAllSports()
    End Sub

    Private Sub cbFootball_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbFootball.CheckedChanged
        TurnOffCheckBox("Football")
        RefreshAllSports()
    End Sub

    Private Sub cbSoccer_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbSoccer.CheckedChanged
        TurnOffCheckBox("Soccer")
        RefreshAllSports()
    End Sub

    Private Sub cbSoftballFP_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbSoftballFP.CheckedChanged
        TurnOffCheckBox("SoftballFP")
        RefreshAllSports()
    End Sub

    Private Sub cbSoftballSP_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbSoftballSP.CheckedChanged
        TurnOffCheckBox("SoftballSP")
        RefreshAllSports()
    End Sub

    Private Sub cbVolleyball_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbVolleyball.CheckedChanged
        TurnOffCheckBox("Volleyball")
        RefreshAllSports()
    End Sub

    Private Sub cbWrestling_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbWrestling.CheckedChanged
        TurnOffCheckBox("Wrestling")
        RefreshAllSports()
    End Sub


    Private Sub cmdBaseball_Click(sender As Object, e As System.EventArgs) Handles cmdBaseball.Click
        If cbBaseball.Checked Then
            'SaveDetails()
            Session("SelectedSport") = "Baseball"
            RefreshDetails("Baseball")
        End If
    End Sub

    Private Sub cmdBasketball_Click(sender As Object, e As System.EventArgs) Handles cmdBasketball.Click
        If cbBasketball.Checked Then
            'SaveDetails()
            Session("SelectedSport") = "Basketball"
            RefreshDetails("Basketball")
        End If
    End Sub

    Private Sub cmdFootball_Click(sender As Object, e As System.EventArgs) Handles cmdFootball.Click
        If cbFootball.Checked Then
            'SaveDetails()
            Session("SelectedSport") = "Football"
            RefreshDetails("Football")
        End If
    End Sub

    Private Sub cmdSoccer_Click(sender As Object, e As System.EventArgs) Handles cmdSoccer.Click
        If cbSoccer.Checked Then
            'SaveDetails()
            Session("SelectedSport") = "Soccer"
            RefreshDetails("Soccer")
        End If
    End Sub

    Private Sub cmdSoftballFP_Click(sender As Object, e As System.EventArgs) Handles cmdSoftballFP.Click
        If cbSoftballFP.Checked Then
            'SaveDetails()
            Session("SelectedSport") = "SoftballFP"
            RefreshDetails("SoftballFP")
        End If
    End Sub

    Private Sub cmdSoftballSP_Click(sender As Object, e As System.EventArgs) Handles cmdSoftballSP.Click
        If cbSoftballSP.Checked Then
            'SaveDetails()
            Session("SelectedSport") = "SoftballSP"
            RefreshDetails("SoftballSP")
        End If
    End Sub

    Private Sub cmdVolleyball_Click(sender As Object, e As System.EventArgs) Handles cmdVolleyball.Click
        If cbVolleyball.Checked Then
            'SaveDetails()
            Session("SelectedSport") = "Volleyball"
            RefreshDetails("Volleyball")
        End If
    End Sub

    Private Sub cmdWrestling_Click(sender As Object, e As System.EventArgs) Handles cmdWrestling.Click
        If cbWrestling.Checked Then
            'SaveDetails()
            Session("SelectedSport") = "Wrestling"
            RefreshDetails("Wrestling")
        End If
    End Sub

    Public Sub SaveDetails()
        Dim strSQL As String = ""
        Dim ds As DataSet
        Dim x As Integer = 0
        Dim intCount As Integer = 0
        Dim objControl As System.Web.UI.WebControls.CheckBox
        Dim objControlList As System.Web.UI.WebControls.CheckBoxList

        ' Delete existing Detail records...
        strSQL = "DELETE FROM tblOfficialsAssignorsDetail WHERE strEmailKey = '" & txtEmail.Text & "' AND strSport = '" & Session("SelectedSport") & "' AND intYear = " & clsFunctions.GetCurrentYear
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        ' Save Detail selected records...
        strSQL = "SELECT * FROM tblOfficialsAssignorsAreas ORDER BY Id"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                With ds.Tables(0).Rows(x)
                    objControl = Me.FindControl(.Item("strCheckboxName"))
                    If objControl.Checked Then
                        strSQL = "INSERT INTO tblOfficialsAssignorsDetail "
                        strSQL += "(strEmailKey, strSport, strArea, intLevelElem, intLevelMS, intLevelJH, intLevelJV, intLevelV) VALUES ("
                        strSQL += "'" & Me.txtEmail.Text & "', "
                        strSQL += "'" & Session("SelectedSport") & "', "
                        strSQL += "'" & .Item("strArea") & "', "
                        objControlList = Me.FindControl(.Item("strCheckboxListName"))

                        If objControlList.Items(0).Selected Then
                            strSQL += "1, "
                            intCount += 1
                        Else
                            strSQL += "0, "
                        End If

                        If objControlList.Items(1).Selected Then
                            strSQL += "1, "
                            intCount += 1
                        Else
                            strSQL += "0, "
                        End If

                        If objControlList.Items(2).Selected Then
                            strSQL += "1, "
                            intCount += 1
                        Else
                            strSQL += "0, "
                        End If

                        If objControlList.Items(3).Selected Then
                            strSQL += "1, "
                            intCount += 1
                        Else
                            strSQL += "0, "
                        End If

                        If objControlList.Items(4).Selected Then
                            strSQL += "1"
                            intCount += 1
                        Else
                            strSQL += "0"
                        End If

                        strSQL += ")"

                        If intCount > 0 Then
                            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                        Else
                            ' Nothing was selected so don't save...
                        End If
                    End If
                End With
            Next
        End If

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As System.EventArgs) Handles cmdSave.Click
        Dim strSQL As String = ""

        If txtName.Text = "" Or txtAddress.Text = "" Or txtCity.Text = "" Or txtState.Text = "" Or txtZip.Text = "" Then
            lblMessage.Text = "Please complete the Personal Information."
        Else

            ' Save Header record...
            strSQL = "UPDATE tblOfficialsAssignors SET "
            strSQL += "strName = '" & txtName.Text & "', "
            strSQL += "strAddress = '" & txtAddress.Text & "', "
            strSQL += "strCity = '" & txtCity.Text & "', "
            strSQL += "strState = '" & Left(txtState.Text, 2) & "', "
            strSQL += "strZip = '" & txtZip.Text & "' "
            strSQL += "WHERE strEmail = '" & txtEmail.Text & "'"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            'SaveDetails()

            lblMessage.Text = "Changes saved..."

        End If
    End Sub

    Private Sub cmdSaveDetail_Click(sender As Object, e As System.EventArgs) Handles cmdSaveDetail.Click
        SaveDetails()
        RefreshAllSports()
    End Sub

    Private Sub cmdGo_Click(sender As Object, e As System.EventArgs) Handles cmdGo.Click
        LoadData(Me.txtEmail.Text, True)
    End Sub
End Class