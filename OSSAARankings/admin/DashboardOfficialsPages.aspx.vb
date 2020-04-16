Public Class DashboardOfficialsPages
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Session("id") = "0"
        Else
            If Session("id") Is Nothing Then
                LoadData()
            End If
        End If

    End Sub

    Private Sub cmdGo_Click(sender As Object, e As System.EventArgs) Handles cmdGo.Click
        Dim strOK As String = ""

        strOK = VerifySelections()

        If strOK = "OK" Then
            LoadData()
            lblMessage.Text = ""
        Else
            lblMessage.Text = strOK
        End If

    End Sub

    Private Sub SaveData()
        Dim strResult As String = "OK"
        Dim strSQL As String

        strResult = VerifyData()

        If strResult = "OK" Then
            strSQL = "UPDATE tblDashboardOfficials SET "
            strSQL = strSQL & "strYear = '" & cboYear.SelectedValue & "', "
            strSQL = strSQL & "dtmStartDate = '" & RadDatePickerStart.SelectedDate & "', "
            strSQL = strSQL & "dtmEndDate = '" & RadDatePickerEnd.SelectedDate & "', "
            strSQL = strSQL & "strLoginHeader = '" & Replace(txtLoginHeading.Text, "'", "") & "', "

            strSQL = strSQL & "strTourneyName1 = '" & Replace(txtTourney1Name.Text, "'", "") & "', "
            strSQL = strSQL & "strTourney101 = '" & Replace(txtTourney1Info1.Text, "'", "") & "', "
            strSQL = strSQL & "strTourney102 = '" & Replace(txtTourney1Info2.Text, "'", "") & "', "
            strSQL = strSQL & "strTourney103 = '" & Replace(txtTourney1Info3.Text, "'", "") & "', "
            strSQL = strSQL & "strTourney104 = '" & Replace(txtTourney1Info4.Text, "'", "") & "', "
            strSQL = strSQL & "strTourney105 = '" & Replace(txtTourney1Info5.Text, "'", "") & "', "

            If txtTourney2Name.Visible = True Then
                strSQL = strSQL & "strTourneyName2 = '" & Replace(txtTourney2Name.Text, "'", "") & "', "
                strSQL = strSQL & "strTourney201 = '" & Replace(txtTourney2Info1.Text, "'", "") & "', "
                strSQL = strSQL & "strTourney202 = '" & Replace(txtTourney2Info2.Text, "'", "") & "', "
                strSQL = strSQL & "strTourney203 = '" & Replace(txtTourney2Info3.Text, "'", "") & "', "
                strSQL = strSQL & "strTourney204 = '" & Replace(txtTourney2Info4.Text, "'", "") & "', "
                strSQL = strSQL & "strTourney205 = '" & Replace(txtTourney2Info5.Text, "'", "") & "', "
            End If

            If txtTourney3Name.Visible = True Then
                strSQL = strSQL & "strTourneyName3 = '" & Replace(txtTourney3Name.Text, "'", "") & "', "
                strSQL = strSQL & "strTourney301 = '" & Replace(txtTourney3Info1.Text, "'", "") & "', "
                strSQL = strSQL & "strTourney302 = '" & Replace(txtTourney3Info2.Text, "'", "") & "', "
                strSQL = strSQL & "strTourney303 = '" & Replace(txtTourney3Info3.Text, "'", "") & "', "
                strSQL = strSQL & "strTourney304 = '" & Replace(txtTourney3Info4.Text, "'", "") & "', "
                strSQL = strSQL & "strTourney305 = '" & Replace(txtTourney3Info5.Text, "'", "") & "', "
            End If

            strSQL = strSQL & "strUpdatedDate = '" & Now & "' "
            strSQL = strSQL & "WHERE Id = " & Session("id")

            lblMessage.Text = "Changes saved."
        Else
            lblMessage.Text = strResult
        End If

    End Sub

    Private Function VerifyData() As String
        Dim strResults As String = "OK"



        Return strResults

    End Function

    Private Sub LoadData()
        Dim objDashboard As New clsDashboard(cboType.SelectedValue, cboSport.SelectedValue, cboYear.SelectedValue)

        Session("id") = objDashboard.gId
        txtLoginHeading.Text = objDashboard.gLoginHeader
        RadDatePickerStart.SelectedDate = objDashboard.gStartDate
        RadDatePickerEnd.SelectedDate = objDashboard.gEndDate

        If objDashboard.gTournaments >= 1 Then
            txtTourney1Name.Enabled = True
            txtTourney1Info1.Enabled = True
            txtTourney1Info2.Enabled = True
            txtTourney1Info3.Enabled = True
            txtTourney1Info4.Enabled = True
            txtTourney1Info5.Enabled = True

            txtTourney1Name.Text = objDashboard.gTourneyName1
            txtTourney1Info1.Text = objDashboard.gTourney101
            txtTourney1Info2.Text = objDashboard.gTourney102
            txtTourney1Info3.Text = objDashboard.gTourney103
            txtTourney1Info4.Text = objDashboard.gTourney104
            txtTourney1Info5.Text = objDashboard.gTourney105
        Else
            txtTourney1Name.Enabled = False
            txtTourney1Info1.Enabled = False
            txtTourney1Info2.Enabled = False
            txtTourney1Info3.Enabled = False
            txtTourney1Info4.Enabled = False
            txtTourney1Info5.Enabled = False
        End If

        If objDashboard.gTournaments >= 2 Then
            txtTourney2Name.Enabled = True
            txtTourney2Info1.Enabled = True
            txtTourney2Info2.Enabled = True
            txtTourney2Info3.Enabled = True
            txtTourney2Info4.Enabled = True
            txtTourney2Info5.Enabled = True

            txtTourney2Name.Text = objDashboard.gTourneyName2
            txtTourney2Info1.Text = objDashboard.gTourney201
            txtTourney2Info2.Text = objDashboard.gTourney202
            txtTourney2Info3.Text = objDashboard.gTourney203
            txtTourney2Info4.Text = objDashboard.gTourney204
            txtTourney2Info5.Text = objDashboard.gTourney205
        Else
            txtTourney2Name.Enabled = False
            txtTourney2Info1.Enabled = False
            txtTourney2Info2.Enabled = False
            txtTourney2Info3.Enabled = False
            txtTourney2Info4.Enabled = False
            txtTourney2Info5.Enabled = False

        End If

        If objDashboard.gTournaments >= 2 Then
            txtTourney3Name.Enabled = True
            txtTourney3Info1.Enabled = True
            txtTourney3Info2.Enabled = True
            txtTourney3Info3.Enabled = True
            txtTourney3Info4.Enabled = True
            txtTourney3Info5.Enabled = True

            txtTourney3Name.Text = objDashboard.gTourneyName3
            txtTourney3Info1.Text = objDashboard.gTourney301
            txtTourney3Info2.Text = objDashboard.gTourney302
            txtTourney3Info3.Text = objDashboard.gTourney303
            txtTourney3Info4.Text = objDashboard.gTourney304
            txtTourney3Info5.Text = objDashboard.gTourney305
        Else
            txtTourney3Name.Enabled = False
            txtTourney3Info1.Enabled = False
            txtTourney3Info2.Enabled = False
            txtTourney3Info3.Enabled = False
            txtTourney3Info4.Enabled = False
            txtTourney3Info5.Enabled = False
        End If

        txtLoginPage.Text = objDashboard.gLoginPage
        txtHomePage.Text = objDashboard.gHomePage
        txtLoginPageURL.Text = objDashboard.gHomePageURL

    End Sub

    Public Function VerifySelections() As String
        Dim strResult As String = "OK"

        If cboType.SelectedValue = "" Then
            strResult = "You must select a TYPE."
        ElseIf cboSport.SelectedValue = "" Then
            strResult = "You must select a SPORT."
        ElseIf cboYear.SelectedValue = "" Then
            strResult = "You must select a YEAR."
        Else
            strResult = "OK"
        End If

        Return strResult
    End Function

    Private Sub cmdSave_Click(sender As Object, e As System.EventArgs) Handles cmdSave.Click
        SaveData()
    End Sub

    Private Sub cboYear_DataBound(sender As Object, e As System.EventArgs) Handles cboYear.DataBound
        cboYear.Items.Insert(0, "Select...")
    End Sub

    Private Sub cboSport_DataBound(sender As Object, e As System.EventArgs) Handles cboSport.DataBound
        cboSport.Items.Insert(0, "Select...")
    End Sub
End Class