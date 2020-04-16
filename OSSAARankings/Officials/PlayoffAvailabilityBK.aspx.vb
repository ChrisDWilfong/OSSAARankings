Public Class PlayoffAvailabilityBK
    Inherits System.Web.UI.Page

    Public objDashboard As clsDashboard

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("OSSAAID") Is Nothing Then
            Response.Redirect("LoginBBO.aspx")
        ElseIf Session("user") = "" Then
            Response.Redirect("LoginBBO.aspx")
        End If

        objDashboard = New clsDashboard("PLAYOFFAVAIL", "Basketball", clsFunctions.GetCurrentYear)

        If Not IsPostBack Then
            Session.Timeout = 60
            LoadData(Session("OSSAAID"))
            Me.lblMessage.Text = ""
            'Me.lblMessage.Text = "The OSSAA must have your Part 1 (>=74) and Part 2 scores, Concussion and Heat certificates in order for you to be eligible for playoffs."
        End If

        ' Added 1/3/2017...
        If ConfigurationManager.AppSettings("OfficialAvailabilityActiveBKPeriod1") = 1 Then
            cboSessionW1D1.Enabled = True
            cboSessionW1D2.Enabled = True
            cboSessionW2D1.Enabled = True
            cboSessionW2D2.Enabled = True
            cboSessionW2D3.Enabled = True
        Else
            cboSessionW1D1.Enabled = False
            cboSessionW1D2.Enabled = False
            cboSessionW2D1.Enabled = False
            cboSessionW2D2.Enabled = False
            cboSessionW2D3.Enabled = False
        End If

        If ConfigurationManager.AppSettings("OfficialAvailabilityActiveBKPeriod2") = 1 Then
            cboSessionW3D1.Enabled = True
            cboSessionW3D2.Enabled = True
            cboSessionW3D3.Enabled = True
            cboSessionW4D1.Enabled = True
            cboSessionW4D2.Enabled = True
            cboSessionW4D3.Enabled = True
            cboSessionW5D1.Enabled = True
            cboSessionW5D2.Enabled = True
            cboSessionW5D3.Enabled = True
        Else
            cboSessionW3D1.Enabled = False
            cboSessionW3D2.Enabled = False
            cboSessionW3D3.Enabled = False
            cboSessionW4D1.Enabled = False
            cboSessionW4D2.Enabled = False
            cboSessionW4D3.Enabled = False
            cboSessionW5D1.Enabled = False
            cboSessionW5D2.Enabled = False
            cboSessionW5D3.Enabled = False
        End If

        ' Added 1/27/2017...
        If ConfigurationManager.AppSettings("BasketballOfficialsLockWeek1") = 1 Then
            cboSessionW1D1.Enabled = False
            cboSessionW1D2.Enabled = False
        End If

        If ConfigurationManager.AppSettings("BasketballOfficialsLockWeek2") = 1 Then
            cboSessionW2D1.Enabled = False
            cboSessionW2D2.Enabled = False
            cboSessionW2D3.Enabled = False
        End If

        If ConfigurationManager.AppSettings("BasketballOfficialsLockWeek3") = 1 Then
            cboSessionW3D1.Enabled = False
            cboSessionW3D2.Enabled = False
            cboSessionW3D3.Enabled = False
        End If

        If ConfigurationManager.AppSettings("BasketballOfficialsLockWeek4") = 1 Then
            cboSessionW4D1.Enabled = False
            cboSessionW4D2.Enabled = False
            cboSessionW4D3.Enabled = False
        End If

        If ConfigurationManager.AppSettings("BasketballOfficialsLockWeek5") = 1 Then
            cboSessionW5D1.Enabled = False
            cboSessionW5D2.Enabled = False
            cboSessionW5D3.Enabled = False
        End If

    End Sub

    Private Sub cboTeamConflict1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTeamConflict1.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboTeamConflict1.Items.Insert(0, objItem)
    End Sub

    Private Sub cboTeamConflict2_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTeamConflict2.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboTeamConflict2.Items.Insert(0, objItem)
    End Sub

    Private Sub cboTeamConflict3_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTeamConflict3.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboTeamConflict3.Items.Insert(0, objItem)
    End Sub

    Private Sub cboTeamConflict4_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTeamConflict4.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboTeamConflict4.Items.Insert(0, objItem)
    End Sub

    Private Sub cboTeamConflict5_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTeamConflict5.DataBound
        Dim objItem As New System.Web.UI.WebControls.ListItem
        objItem.Value = 0
        objItem.Text = "Select Team..."
        cboTeamConflict5.Items.Insert(0, objItem)
    End Sub

    Protected Sub cmdSave1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave1.Click
        Dim strReturn As String
        strReturn = SaveData(Session("OSSAAID"))
        If strReturn = "OK" Then
        Else
            Me.lblMessage.Text = strReturn
        End If
    End Sub

    Protected Sub cmdSave2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave2.Click
        Dim strReturn As String
        strReturn = SaveData(Session("OSSAAID"))
        If strReturn = "OK" Then
        Else
            Me.lblMessage.Text = strReturn
        End If
    End Sub

    Protected Sub cmdGoBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdGoBack.Click
        Response.Redirect("BBMainMenu.aspx")
    End Sub

#Region "Functions"

    Public Function SaveData(ByVal intOSSAAID As Integer) As String
        Dim strReturn As String = "OK"
        Dim strSQL As String

        strReturn = VerifyData()

        If strReturn = "OK" Then
            strSQL = "UPDATE " & objDashboard.gTableSource & " SET "

            ' Experience Level This Season...
            strSQL = strSQL & "dtmSaved = '" & Now() & "', "
            strSQL = strSQL & "strExperienceThisSeason = '" & Me.cboExperienceThisSeason.SelectedValue & "', "

            strSQL = strSQL & "strPreferToWork = '" & Me.cboPreferToWork.SelectedValue & "', "

            If cbLevel1.Checked Then
                strSQL = strSQL & "intLevel1None = 1, "
            Else
                strSQL = strSQL & "intLevel1None = 0, "
            End If
            If cbLevel2.Checked Then
                strSQL = strSQL & "intLevel2District = 1, "
            Else
                strSQL = strSQL & "intLevel2District = 0, "
            End If
            If cbLevel3.Checked Then
                strSQL = strSQL & "intLevel3Regional = 1, "
            Else
                strSQL = strSQL & "intLevel3Regional = 0, "
            End If
            If cbLevel4.Checked Then
                strSQL = strSQL & "intLevel4Area = 1, "
            Else
                strSQL = strSQL & "intLevel4Area = 0, "
            End If
            If cbLevel5.Checked Then
                strSQL = strSQL & "intLevel5State = 1, "
            Else
                strSQL = strSQL & "intLevel5State = 0, "
            End If

            strSQL = strSQL & "strHSGames = '" & Me.cboHSGames.SelectedValue & "', "
            strSQL = strSQL & "strCOLLevel = '" & Me.cboCollegeExp.SelectedValue & "', "
            strSQL = strSQL & "strDayNight = '" & Me.cboDayNight.SelectedValue & "', "

            ' Availability...
            strSQL = strSQL & "intPlayoffAvail01 = " & cboSessionW1D1.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail02 = " & cboSessionW1D2.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail03 = " & cboSessionW2D1.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail04 = " & cboSessionW2D2.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail05 = " & cboSessionW2D3.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail06 = " & cboSessionW3D1.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail07 = " & cboSessionW3D2.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail08 = " & cboSessionW3D3.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail09 = " & cboSessionW4D1.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail10 = " & cboSessionW4D2.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail11 = " & cboSessionW4D3.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail12 = " & cboSessionW5D1.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail13 = " & cboSessionW5D2.SelectedValue & ", "
            strSQL = strSQL & "intPlayoffAvail14 = " & cboSessionW5D3.SelectedValue & ", "

            ' Added 1/5/2018...
            If txtPartners.Text = "" Then
            Else
                strSQL = strSQL & "strPartners = '" & clsFunctions.StringValidate(txtPartners.Text) & "', "
            End If

            strSQL = strSQL & "intSchoolIDConflict1 = " & Me.cboTeamConflict1.SelectedValue & ", "
            If Me.cboTeamConflict1.SelectedValue > 0 Then
                strSQL = strSQL & "strSchoolConflict1 = '" & Me.cboTeamConflict1.SelectedItem.ToString & "', "
            End If
            strSQL = strSQL & "intSchoolIDConflict2 = " & Me.cboTeamConflict2.SelectedValue & ", "
            If Me.cboTeamConflict2.SelectedValue > 0 Then
                strSQL = strSQL & "strSchoolConflict2 = '" & Me.cboTeamConflict2.SelectedItem.ToString & "', "
            End If
            strSQL = strSQL & "intSchoolIDConflict3 = " & Me.cboTeamConflict3.SelectedValue & ", "
            If Me.cboTeamConflict3.SelectedValue > 0 Then
                strSQL = strSQL & "strSchoolConflict3 = '" & Me.cboTeamConflict3.SelectedItem.ToString & "', "
            End If
            strSQL = strSQL & "intSchoolIDConflict4 = " & Me.cboTeamConflict4.SelectedValue & ", "
            If Me.cboTeamConflict4.SelectedValue > 0 Then
                strSQL = strSQL & "strSchoolConflict4 = '" & Me.cboTeamConflict4.SelectedItem.ToString & "', "
            End If
            If Me.cboTeamConflict5.SelectedValue > 0 Then
                strSQL = strSQL & "strSchoolConflict5 = '" & Me.cboTeamConflict5.SelectedItem.ToString & "', "
            End If
            strSQL = strSQL & "intSchoolIDConflict5 = " & Me.cboTeamConflict5.SelectedValue & " "

            strSQL = strSQL & " WHERE intOSSAAID = " & intOSSAAID & " AND intYear = " & clsFunctions.GetCurrentYear

            Try
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                strReturn = "Changes Saved."
            Catch
                strReturn = "FAILED"
            End Try

            If 1 = 2 Then
                clsEmail.SendEmail(Me, strReturn & " : " & strSQL, "cwilfong@ossaa.com", "", "Officials Availability : " & intOSSAAID & " (" & Session("OfficialName") & ")")
            End If

        Else
                ' Return message...
            End If

        Return strReturn

    End Function

    Public Function LoadData(ByVal intOSSAAID As Integer) As String
        On Error Resume Next
        Dim strReturn As String = "OK"
        Dim strSQL As String
        Dim ds As DataSet
        Dim e As Object

        lblHeaderW1.Text = objDashboard.gTourneyName1
        lblHeaderW2.Text = objDashboard.gTourneyName2
        lblHeaderW3.Text = objDashboard.gTourneyName3
        lblHeaderW4.Text = objDashboard.gTourneyName4
        lblHeaderW5.Text = objDashboard.gTourneyName5

        lblSessionW1D1.Text = objDashboard.gTourney101
        lblSessionW1D2.Text = objDashboard.gTourney102

        lblSessionW2D1.Text = objDashboard.gTourney201
        lblSessionW2D2.Text = objDashboard.gTourney202
        lblSessionW2D3.Text = objDashboard.gTourney203

        lblSessionW3D1.Text = objDashboard.gTourney301
        lblSessionW3D2.Text = objDashboard.gTourney302
        lblSessionW3D3.Text = objDashboard.gTourney303

        lblSessionW4D1.Text = objDashboard.gTourney401
        lblSessionW4D2.Text = objDashboard.gTourney402
        lblSessionW4D3.Text = objDashboard.gTourney403

        lblSessionW5D1.Text = objDashboard.gTourney501
        lblSessionW5D2.Text = objDashboard.gTourney502
        lblSessionW5D3.Text = objDashboard.gTourney503

        strSQL = "SELECT * FROM " & objDashboard.gTableSource & " WHERE intOSSAAID = " & intOSSAAID & " AND intYear = " & clsFunctions.GetCurrentYear
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
            CreateRecord(Session("OSSAAID"), Session("OfficialName"))
        ElseIf ds.Tables.Count = 0 Then
            CreateRecord(Session("OSSAAID"), Session("OfficialName"))
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            CreateRecord(Session("OSSAAID"), Session("OfficialName"))
        Else
            ' Load info...
            With ds.Tables(0).Rows(0)
                ' Playoff Level...
                Me.cboExperienceThisSeason.SelectedValue = .Item("strExperienceThisSeason")
                Me.cboPreferToWork.SelectedValue = .Item("strPreferToWork")

                ' Playoff Level...
                Me.cbLevel1.Checked = .Item("intLevel1None")
                Me.cbLevel2.Checked = .Item("intLevel2District")
                Me.cbLevel3.Checked = .Item("intLevel3Regional")
                Me.cbLevel4.Checked = .Item("intLevel4Area")
                Me.cbLevel5.Checked = .Item("intLevel5State")

                Me.cboHSGames.SelectedValue = .Item("strHSGames")
                Me.cboCollegeExp.SelectedValue = .Item("strCOLLevel")
                Me.cboDayNight.SelectedValue = .Item("strDayNight")

                Me.cboSessionW1D1.SelectedValue = .Item("intPlayoffAvail01")
                Me.cboSessionW1D2.SelectedValue = .Item("intPlayoffAvail02")
                Me.cboSessionW2D1.SelectedValue = .Item("intPlayoffAvail03")
                Me.cboSessionW2D2.SelectedValue = .Item("intPlayoffAvail04")
                Me.cboSessionW2D3.SelectedValue = .Item("intPlayoffAvail05")
                Me.cboSessionW3D1.SelectedValue = .Item("intPlayoffAvail06")
                Me.cboSessionW3D2.SelectedValue = .Item("intPlayoffAvail07")
                Me.cboSessionW3D3.SelectedValue = .Item("intPlayoffAvail08")
                Me.cboSessionW4D1.SelectedValue = .Item("intPlayoffAvail09")
                Me.cboSessionW4D2.SelectedValue = .Item("intPlayoffAvail10")
                Me.cboSessionW4D3.SelectedValue = .Item("intPlayoffAvail11")
                Me.cboSessionW5D1.SelectedValue = .Item("intPlayoffAvail12")
                Me.cboSessionW5D2.SelectedValue = .Item("intPlayoffAvail13")
                Me.cboSessionW5D3.SelectedValue = .Item("intPlayoffAvail14")

                ' Added 1/5/2018... 
                If Not .Item("strPartners") Is System.DBNull.Value Then
                    txtPartners.Text = .Item("strParners")
                End If

                If .Item("intSchoolIDConflict1") > 0 Then
                    Me.cboTeamConflict1.SelectedValue = .Item("intSchoolIDConflict1")
                End If
                If .Item("intSchoolIDConflict2") > 0 Then
                    Me.cboTeamConflict2.SelectedValue = .Item("intSchoolIDConflict2")
                End If
                If .Item("intSchoolIDConflict3") > 0 Then
                    Me.cboTeamConflict3.SelectedValue = .Item("intSchoolIDConflict3")
                End If
                If .Item("intSchoolIDConflict4") > 0 Then
                    Me.cboTeamConflict4.SelectedValue = .Item("intSchoolIDConflict4")
                End If
                If .Item("intSchoolIDConflict5") > 0 Then
                    Me.cboTeamConflict5.SelectedValue = .Item("intSchoolIDConflict5")
                End If

            End With

        End If

        Return strReturn

    End Function

    Public Sub CreateRecord(ByVal intOSSAAID As Integer, ByVal strPlayoffCrewName As String)
        Dim strSQL As String

        strSQL = "INSERT INTO " & objDashboard.gTableSource & " (intOSSAAID, strSport, intYear) VALUES (" & intOSSAAID & ", 'BB', " & clsOfficials.GetDefaultYear & ")"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

    End Sub

    Public Function VerifyData() As String
        Dim strReturn As String = "OK"

        If cboExperienceThisSeason.SelectedValue = "Select..." Then
            strReturn = "You must select : Regular Season Experience for THIS SEASON."
        ElseIf cboPreferToWork.SelectedValue = "Select..." Then
            strReturn = "You must select : I prefer to work"
        ElseIf cboHSGames.SelectedValue = "Select..." Then
            strReturn = "You must select : Number of High School Dates worked THIS SEASON."
        ElseIf cboCollegeExp.SelectedValue = "Select..." Then
            strReturn = "You must select : Jr College/College Basketball THIS SEASON"
        ElseIf cboDayNight.SelectedValue = "Select..." Then
            strReturn = "You must select Work an afternoon Session AND evening session."
        Else
            strReturn = "OK"
        End If


        Return strReturn
    End Function

    Public Function ParseString(ByVal strIn As Object) As String
        Dim strTemp As String = ""

        Try
            strTemp = strIn
            strTemp = strTemp.Replace("'", "")
            strTemp = strTemp.Replace("""", "")
            strTemp = strTemp.Replace("DELETE", "")
            strTemp = strTemp.Replace("SELECT ", "")
            strTemp = strTemp.Replace("INSERT INTO ", "")
        Catch

        End Try

        Return strTemp
    End Function
#End Region

End Class