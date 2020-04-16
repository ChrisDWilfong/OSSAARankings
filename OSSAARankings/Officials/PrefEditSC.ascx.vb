Imports System
Imports System.IO
Imports System.Net
Imports System.Text

Partial Class PrefEditSC
    Inherits System.Web.UI.UserControl

    Public gInvalidMessage As String = "Invalid OSSAAID# entered."
    Public gInvalidName As String = "INVALID OSSAAID#"
    Dim intYear As Integer = clsFunctions.GetCurrentYear
    Public gEligibleOfficialsView As String = "viewOfficialsSoccerEligiblePlayoffsDetail"

    Protected Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave.Click
        DoSave()
    End Sub

    Public Sub ClearFields()

        Me.txtOSSAAID1.Text = ""
        Me.lblOfficialName1.Text = ""

        Me.txtOSSAAID2.Text = ""
        Me.lblOfficialName2.Text = ""

        Me.txtOSSAAID3.Text = ""
        Me.lblOfficialName3.Text = ""

        Me.txtOSSAAID4.Text = ""
        Me.lblOfficialName4.Text = ""

        Me.txtOSSAAID5.Text = ""
        Me.lblOfficialName5.Text = ""

        Me.txtOSSAAID6.Text = ""
        Me.lblOfficialName6.Text = ""

        Me.txtOSSAAID7.Text = ""
        Me.lblOfficialName7.Text = ""

        Me.txtOSSAAID8.Text = ""
        Me.lblOfficialName8.Text = ""

        Me.txtOSSAAID9.Text = ""
        Me.lblOfficialName9.Text = ""

        Me.txtOSSAAID10.Text = ""
        Me.lblOfficialName10.Text = ""

        Me.txtOSSAAID11.Text = ""
        Me.lblOfficialName11.Text = ""

    End Sub

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

    Public Function VerifyFields()
        Dim strReturn As String = "OK"
        Dim strVerifyBrackets As String = "OK"

        If Me.txtSignature11.Text = "" Then
            strReturn = "You must enter a COACHES name (at the bottom)."
        ElseIf Me.txtSignature21.Text = "" Then
            strReturn = "You must enter a PRINCIPALS name (at the bottom)."
        ElseIf Me.txtOSSAAID1.Text = "" Or Me.lblOfficialCity1.Text = "" Or Me.lblOfficialCity1.Text = "0" Then
            strReturn = "You must select a #1 OSSAA ID#"
        ElseIf Me.txtOSSAAID2.Text = "" Or Me.lblOfficialCity2.Text = "" Or Me.lblOfficialCity2.Text = "0" Then
            strReturn = "You must select a #2 OSSAA ID#"
        ElseIf Me.txtOSSAAID3.Text = "" Or Me.lblOfficialCity3.Text = "" Or Me.lblOfficialCity3.Text = "0" Then
            strReturn = "You must select a #3 OSSAA ID#"
            'ElseIf Me.txtOSSAAID4.Text = "" Or Me.lblOfficialCity4.Text = "" Then
            '    strReturn = "You must select a Regional #4 OSSAA ID#"
            'ElseIf Me.txtOSSAAID5.Text = "" Or Me.lblOfficialCity5.Text = "" Then
            '    strReturn = "You must select a Regional #5 OSSAA ID#"
            'ElseIf Me.txtOSSAAID6.Text = "" Or Me.lblOfficialCity6.Text = "" Then
            '    strReturn = "You must select a Regional #6 OSSAA ID#"
        End If
        Return strReturn
    End Function

    'Public Function IsEligibleOfficialWrestlingByValue(intOfficialID As Long) As String
    '    Dim strReturn As String = "FAILED"
    '    Dim strSQL As String

    '    strSQL = "SELECT * FROM " & gEligibleOfficialsView & " WHERE intOSSAAID = " & intOfficialID

    '    Try
    '        strReturn = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
    '    Catch
    '        strReturn = "FAILED"
    '    End Try

    '    Return strReturn
    'End Function

    Public Sub MessageLoad(strMessage As String)
        Me.lblMessage.Text = strMessage
        Me.lblMessage1.Text = strMessage
        Me.lblMessage4.Text = strMessage
    End Sub

    Protected Sub txtOSSAAID1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID1.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginSCPref.aspx")
        End If

        If Not IsNumeric(Me.txtOSSAAID1.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID1.Text)
            Dim strSQL As String = "SELECT * FROM " & gEligibleOfficialsView & " WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName1.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName1.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName1.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName1.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity1.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip1.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles1.Text = intMiles
                txtOSSAAID2.Focus()
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID2.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginSCPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID2.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID2.Text)
            Dim strSQL As String = "SELECT * FROM " & gEligibleOfficialsView & " WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName2.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName2.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName2.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName2.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity2.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip2.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles2.Text = intMiles
                txtOSSAAID3.Focus()
            End If
        End If
    End Sub

    Protected Sub txtOSSAAID3_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID3.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginSCPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID3.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID3.Text)
            Dim strSQL As String = "SELECT * FROM " & gEligibleOfficialsView & " WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName3.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName3.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName3.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName3.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity3.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip3.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles3.Text = intMiles
                txtOSSAAID4.Focus()
            End If
        End If
    End Sub

    Protected Sub txtOSSAAID4_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID4.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginSCPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID4.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID4.Text)
            Dim strSQL As String = "SELECT * FROM " & gEligibleOfficialsView & " WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName4.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName4.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName4.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName4.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity4.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip4.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles4.Text = intMiles
                txtOSSAAID5.Focus()
            End If
        End If
    End Sub

    Protected Sub txtOSSAAID5_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID5.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginSCPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID5.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID5.Text)
            Dim strSQL As String = "SELECT * FROM " & gEligibleOfficialsView & " WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName5.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName5.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName5.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName5.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity5.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip5.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles5.Text = intMiles
                txtOSSAAID6.Focus()
            End If
        End If
    End Sub

    Protected Sub txtOSSAAID6_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID6.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginSCPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID6.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID6.Text)
            Dim strSQL As String = "SELECT * FROM " & gEligibleOfficialsView & " WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName6.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName6.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName6.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName6.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity6.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip6.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles6.Text = intMiles
                txtOSSAAID7.Focus()
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID7_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID7.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginSCPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID7.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID7.Text)
            Dim strSQL As String = "SELECT * FROM " & gEligibleOfficialsView & " WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName7.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName7.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName7.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName7.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity7.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip7.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles7.Text = intMiles
                txtOSSAAID8.Focus()
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID8_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID8.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginSCPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID8.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID8.Text)
            Dim strSQL As String = "SELECT * FROM " & gEligibleOfficialsView & " WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName8.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName8.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName8.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName8.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity8.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip8.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles8.Text = intMiles
                txtOSSAAID9.Focus()
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID9_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID9.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginSCPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID9.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID9.Text)
            Dim strSQL As String = "SELECT * FROM " & gEligibleOfficialsView & " WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName9.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName9.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName9.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName9.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity9.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip9.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles9.Text = intMiles
                txtOSSAAID10.Focus()
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID10_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID10.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginSCPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID10.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID10.Text)
            Dim strSQL As String = "SELECT * FROM " & gEligibleOfficialsView & " WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName10.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName10.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName10.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName10.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity10.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip10.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles10.Text = intMiles
                txtOSSAAID1.Focus()
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID11_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID11.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginSCPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID11.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID11.Text)
            Dim strSQL As String = "SELECT * FROM " & gEligibleOfficialsView & " WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName11.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName11.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName11.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName11.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity11.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip11.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles10.Text = intMiles
                txtOSSAAID1.Focus()
            End If
        End If

    End Sub

    'Protected Sub cmdBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBack.Click
    '    Response.Redirect("~/Officials/LoginSCPref.aspx")
    'End Sub

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Server.ScriptTimeout = 3600
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            LoadData()
            Dim strText As String
            'strText = "In the spaces below, select your preference of officials to be used in the regional and championship tournaments.  The regional officials should be based on <strong>realistic geographics</strong>.  The state tournament officials may be listed from any location.<br><br>"
            strText = "Coaches that do not submit their entries on time, will be placed on warning for one year.  If a soccer coach is placed on warning for two consecutive years for not turning in his soccer officials preferenitial list, that coach must write a letter to the OSSAA Board of Directors and explain his actions.  This letter must be signed by the coach and high school principal."

            lblMiles.Text = strText

            lblPrefHeader.Text = "PREFERENTIAL LISTS RECEIVED AFTER 4PM " & ConfigurationManager.AppSettings("PrefListDueDateSC") & " WILL NOT BE CONSIDERED."

            Dim strSQL As String = "SELECT * FROM tblPlayoffPrefsSC WHERE strEmail = '" & Session("userEmail") & "' AND intYear = " & clsFunctions.GetCurrentYear
            Dim strEmail As String = ""
            strEmail = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If strEmail = "" Then
                strSQL = "INSERT INTO tblPlayoffPrefsSC (intYear, strEmail) VALUES (" & clsFunctions.GetCurrentYear & ", '" & Session("userEmail") & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If

        End If
        lblHeader.Text = ConfigurationManager.AppSettings("CurrentYearFull") & " SOCCER PREFERENTIAL OFFICIALS LIST (STEP 1)"
    End Sub

    Public Sub DoSave()
        Dim strSQL As String
        Dim intId As Long = 0
        Dim strMessage As String = ""

        If Session("prefUser") = "" Then
            '''''Response.Redirect("LoginSCPref.aspx")
        End If

        strMessage = VerifyFields()

        If strMessage <> "OK" Then
            MessageLoad(strMessage)
        Else

            strSQL = "UPDATE tblPlayoffPrefsSC SET "

            strSQL = strSQL & "strCoachName = '" & Session("userName") & "', "

            If Not txtSignature11.Text = "" Then
                strSQL = strSQL & "strSchoolRep1 = '" & Replace(Me.txtSignature11.Text, "'", "") & "', "
            End If
            If Not txtSignature21.Text = "" Then
                strSQL = strSQL & "strSchoolRep2 = '" & Replace(Me.txtSignature21.Text, "'", "") & "', "
            End If
            If Not txtSchool.Text = "" Then
                strSQL = strSQL & "strSchool = '" & Replace(Me.txtSchool.Text, "'", "") & "', "
            End If
            If Not txtClass.Text = "" Then
                strSQL = strSQL & "strClass = '" & Replace(Me.txtClass.Text, "'", "") & "', "
            End If

            strSQL = strSQL & "dtmPosted = '" & Now & "' "
            strSQL = strSQL & "WHERE intYear = " & clsFunctions.GetCurrentYear & " AND strEmail = '" & Session("userEmail") & "'"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            Dim strSQL2 As String
            strSQL2 = strSQL

            Dim strSQL1 As String
            strSQL1 = strSQL

            ' Now save the District Prefs officials...
            ' DELETE THE EXISTING LIST...
            strSQL = "DELETE FROM tblPlayoffPrefsDetailSC WHERE strEmail = '" & Session("userEmail") & "' AND intYear = " & clsFunctions.GetCurrentYear
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            ' Now UPDATE this list...
            strSQL = "INSERT INTO tblPlayoffPrefsDetailSC (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
            strSQL = strSQL & "'" & Session("userEmail") & "', "
            strSQL = strSQL & "'" & Me.txtOSSAAID1.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialName1.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialZip1.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialCity1.Text & "', "
            strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
            strSQL = strSQL & "1, "
            strSQL = strSQL & "'0')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            strSQL = "INSERT INTO tblPlayoffPrefsDetailSC (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
            strSQL = strSQL & "'" & Session("userEmail") & "', "
            strSQL = strSQL & "'" & Me.txtOSSAAID2.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialName2.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialZip2.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialCity2.Text & "', "
            strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
            strSQL = strSQL & "2, "
            strSQL = strSQL & "'0')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            strSQL = "INSERT INTO tblPlayoffPrefsDetailSC (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
            strSQL = strSQL & "'" & Session("userEmail") & "', "
            strSQL = strSQL & "'" & Me.txtOSSAAID3.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialName3.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialZip3.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialCity3.Text & "', "
            strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
            strSQL = strSQL & "3, "
            strSQL = strSQL & "'0')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If Me.txtOSSAAID4.Text = "" Then

            Else
                strSQL = "INSERT INTO tblPlayoffPrefsDetailSC (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
                strSQL = strSQL & "'" & Session("userEmail") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID4.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName4.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip4.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity4.Text & "', "
                strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
                strSQL = strSQL & "4, "
                strSQL = strSQL & "'0')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If

            If Me.txtOSSAAID5.Text = "" Then

            Else
                strSQL = "INSERT INTO tblPlayoffPrefsDetailSC (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
                strSQL = strSQL & "'" & Session("userEmail") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID5.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName5.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip5.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity5.Text & "', "
                strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
                strSQL = strSQL & "5, "
                strSQL = strSQL & "'0')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If

            If Me.txtOSSAAID6.Text = "" Then

            Else
                strSQL = "INSERT INTO tblPlayoffPrefsDetailSC (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
                strSQL = strSQL & "'" & Session("userEmail") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID6.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName6.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip6.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity6.Text & "', "
                strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
                strSQL = strSQL & "6, "
                strSQL = strSQL & "'0')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If

            If Me.txtOSSAAID7.Text = "" Then

            Else
                strSQL = "INSERT INTO tblPlayoffPrefsDetailSC (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
                strSQL = strSQL & "'" & Session("userEmail") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID7.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName7.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip7.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity7.Text & "', "
                strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
                strSQL = strSQL & "7, "
                strSQL = strSQL & "'0')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If

            If Me.txtOSSAAID8.Text = "" Then

            Else
                strSQL = "INSERT INTO tblPlayoffPrefsDetailSC (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
                strSQL = strSQL & "'" & Session("userEmail") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID8.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName8.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip8.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity8.Text & "', "
                strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
                strSQL = strSQL & "8, "
                strSQL = strSQL & "'0')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If

            If Me.txtOSSAAID9.Text = "" Then

            Else
                strSQL = "INSERT INTO tblPlayoffPrefsDetailSC (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
                strSQL = strSQL & "'" & Session("userEmail") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID9.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName9.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip9.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity9.Text & "', "
                strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
                strSQL = strSQL & "9, "
                strSQL = strSQL & "'0')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If

            If Me.txtOSSAAID10.Text = "" Then

            Else
                strSQL = "INSERT INTO tblPlayoffPrefsDetailSC (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
                strSQL = strSQL & "'" & Session("userEmail") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID10.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName10.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip10.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity10.Text & "', "
                strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
                strSQL = strSQL & "10, "
                strSQL = strSQL & "'0')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If

            strSQL = "INSERT INTO tblPlayoffPrefsDetailSC (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
            strSQL = strSQL & "'" & Session("userEmail") & "', "
            strSQL = strSQL & "'" & Me.txtOSSAAID11.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialName11.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialZip11.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialCity11.Text & "', "
            strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
            strSQL = strSQL & "11, "
            strSQL = strSQL & "'0')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            ' Send Email to Us and to User...
            Dim strSubject As String = "OSSAA SOCCER Preferential Information"
            Dim strContent As String = "Your Officials Playoff Preferential information has been submitted to the OSSAA.  Any additional information about playoffs can be found at our OSSAA.com website under the Sports / Soccer tab.  If you have any questions regarding Officals, contact sriddell@ossaa.com.  Soccer Playoffs questions, contact tgoolsby@ossaa.com."
            Dim strEmailTo As String = "cwilfong@ossaa.com"

            strEmailTo = Session("userEmail")
            ' CDW 3/5/2019 changed...
            '''''clsEmail.SendEmail(Me, strContent, strEmailTo, "", strSubject)
            clsEmail.SendEmailNew(strEmailTo, "", strSubject, strContent, False, "")

            ' Now send info to us...
            strEmailTo = "cwilfong@ossaa.com"
            strSubject = "OSSAA SOCCER Preferential Information : " & txtSchool.Text
            strContent = "Submitted By : " & Session("userName") & " " & Session("userEmail") & "<br><br>"
            strContent = strContent & strSQL1 & "<br><br>"
            strContent = strContent & strSQL2

            ' CDW changed 3/5/2019...
            '''''clsEmail.SendEmail(Me, strContent, strEmailTo, "", strSubject)
            '''''clsEmail.SendEmail(Me, strContent, "cwilfong@ossaa.com", "", strSubject)
            clsEmail.SendEmailNew(strEmailTo, "", strSubject, strContent, False, "")
            clsEmail.SendEmailNew("cwilfong@ossaa.com", "", strSubject, strContent, False, "")

            MessageLoad("Changes Saved (confirmation email sent to : " & Session("userName") & " and the OSSAA OFFICE)")

        End If

    End Sub

    Public Sub LoadData()
        Dim strSQL As String
        Dim ds As DataSet
        Dim ds1 As DataSet
        Dim x As Integer

        ' Load from tblDistrictPrefsBB (load school reps) and schools......
        strSQL = "SELECT TOP 1 * FROM tblPlayoffPrefsSC WHERE strEmail = '" & Session("userEmail") & "' AND intYear = " & clsFunctions.GetCurrentYear
        ds1 = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds1 Is Nothing Then
        ElseIf ds1.Tables.Count = 0 Then
        ElseIf ds1.Tables(0).Rows.Count = 0 Then
        Else
            With ds1.Tables(0).Rows(0)
                ' School Reps...
                If Not .Item("strSchoolRep1") Is System.DBNull.Value Then
                    Me.txtSignature11.Text = .Item("strSchoolRep1")
                End If
                If Not .Item("strSchoolRep2") Is System.DBNull.Value Then
                    Me.txtSignature21.Text = .Item("strSchoolRep2")
                End If
                If Not .Item("strClass") Is System.DBNull.Value Then
                    Me.txtClass.Text = .Item("strClass")
                End If
                If Not .Item("strSchool") Is System.DBNull.Value Then
                    Me.txtSchool.Text = .Item("strSchool")
                End If
            End With
        End If

        ' Load the District Pref Officials Already Entered 1-20...
        strSQL = "SELECT * FROM tblPlayoffPrefsDetailSC WHERE strEmail = '" & Session("userEmail") & "' AND intYear = " & clsFunctions.GetCurrentYear
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To (ds.Tables(0).Rows.Count - 1)
                Select Case ds.Tables(0).Rows(x).Item("intRank")
                    Case 1
                        Me.txtOSSAAID1.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName1.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity1.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles1.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip1.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try
                    Case 2
                        Me.txtOSSAAID2.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName2.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity2.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles2.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip2.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try
                    Case 3
                        Me.txtOSSAAID3.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName3.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity3.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles3.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip3.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try
                    Case 4
                        Me.txtOSSAAID4.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName4.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity4.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles4.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip4.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try
                    Case 5
                        Me.txtOSSAAID5.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName5.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity5.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles5.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip5.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try

                    Case 6
                        Me.txtOSSAAID6.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName6.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity6.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles6.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip6.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try
                    Case 7
                        Me.txtOSSAAID7.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName7.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity7.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles7.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip7.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try
                    Case 8
                        Me.txtOSSAAID8.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName8.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity8.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles8.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip8.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try
                    Case 9
                        Me.txtOSSAAID9.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName9.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity9.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles9.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip9.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try
                    Case 10
                        Me.txtOSSAAID10.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName10.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity10.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles10.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip10.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try
                    Case 11
                        Me.txtOSSAAID11.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName11.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity11.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles11.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip11.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try
                End Select
            Next
        End If

    End Sub


    Public Function GetSiteIDFromSchoolID(ByVal schoolId As Long) As String
        Dim siteID As Long = 0
        On Error Resume Next

        If schoolId = 0 Then
            siteID = 0
        Else
            siteID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT Id FROM prodSchools WHERE schoolID = " & schoolId)
        End If

        Return siteID
    End Function



End Class