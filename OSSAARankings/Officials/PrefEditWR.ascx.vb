Imports System
Imports System.IO
Imports System.Net
Imports System.Text

Partial Class PrefEditWR
    Inherits System.Web.UI.UserControl

    Public gInvalidMessage As String = "Invalid OSSAAID# entered."
    Public gInvalidName As String = "INVALID OSSAAID#"
    Dim intYear As Integer = clsFunctions.GetCurrentYear

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

        Me.txtOSSAAID12.Text = ""
        Me.lblOfficialName12.Text = ""

        Me.txtOSSAAID13.Text = ""
        Me.lblOfficialName13.Text = ""

        Me.txtOSSAAID14.Text = ""
        Me.lblOfficialName14.Text = ""

        Me.txtOSSAAID15.Text = ""
        Me.lblOfficialName15.Text = ""

        Me.txtOSSAAID16.Text = ""
        Me.lblOfficialName16.Text = ""

        Me.txtOSSAAID17.Text = ""
        Me.lblOfficialName17.Text = ""

        Me.txtOSSAAID18.Text = ""
        Me.lblOfficialName18.Text = ""

        Me.txtOSSAAID19.Text = ""
        Me.lblOfficialName19.Text = ""

        Me.txtOSSAAID20.Text = ""
        Me.lblOfficialName20.Text = ""

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
        ElseIf Me.txtOSSAAID1.Text = "" Or Me.lblOfficialCity1.Text = "" Then
            strReturn = "You must select a Regional #1 OSSAA ID#"
        ElseIf Me.txtOSSAAID2.Text = "" Or Me.lblOfficialCity2.Text = "" Then
            strReturn = "You must select a Regional #2 OSSAA ID#"
        ElseIf Me.txtOSSAAID3.Text = "" Or Me.lblOfficialCity3.Text = "" Then
            strReturn = "You must select a Regional #3 OSSAA ID#"
        ElseIf Me.txtOSSAAID4.Text = "" Or Me.lblOfficialCity4.Text = "" Then
            strReturn = "You must select a Regional #4 OSSAA ID#"
        ElseIf Me.txtOSSAAID5.Text = "" Or Me.lblOfficialCity5.Text = "" Then
            strReturn = "You must select a Regional #5 OSSAA ID#"
        ElseIf Me.txtOSSAAID6.Text = "" Or Me.lblOfficialCity6.Text = "" Then
            strReturn = "You must select a Regional #6 OSSAA ID#"
        ElseIf Me.txtOSSAAID11.Text = "" Or Me.lblOfficialCity11.Text = "" Then
            strReturn = "You must select a State #1 OSSAA ID#"
        ElseIf Me.txtOSSAAID12.Text = "" Or Me.lblOfficialCity12.Text = "" Then
            strReturn = "You must select a State #2 OSSAA ID#"
        ElseIf Me.txtOSSAAID13.Text = "" Or Me.lblOfficialCity13.Text = "" Then
            strReturn = "You must select a State #3 OSSAA ID#"
        ElseIf Me.txtOSSAAID14.Text = "" Or Me.lblOfficialCity14.Text = "" Then
            strReturn = "You must select a State #4 OSSAA ID#"
        ElseIf Me.txtOSSAAID15.Text = "" Or Me.lblOfficialCity15.Text = "" Then
            strReturn = "You must select a State #5 OSSAA ID#"
        ElseIf Me.txtOSSAAID16.Text = "" Or Me.lblOfficialCity16.Text = "" Then
            strReturn = "You must select a State #6 OSSAA ID#"
        End If
        Return strReturn
    End Function

    Public Function IsEligibleOfficialWrestlingByValue(intOfficialID As Long) As String
        Dim strReturn As String = "FAILED"
        Dim strSQL As String

        strSQL = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID

        Try
            strReturn = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        Catch
            strReturn = "FAILED"
        End Try

        Return strReturn
    End Function

    Public Sub MessageLoad(strMessage As String)
        Me.lblMessage.Text = strMessage
        Me.lblMessage1.Text = strMessage
        Me.lblMessage4.Text = strMessage
    End Sub

    Protected Sub txtOSSAAID1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID1.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginWRPref.aspx")
        End If

        If Not IsNumeric(Me.txtOSSAAID1.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID1.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
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
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID2.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID2.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
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
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID3.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID3.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
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
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID4.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID4.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
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
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID5.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID5.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
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
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID6.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID6.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
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
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID7.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID7.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
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
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID8.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID8.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
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
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID9.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID9.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
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
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID10.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID10.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
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
                txtOSSAAID11.Focus()
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID11_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID11.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID11.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID11.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
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
                'Me.lblOfficialMiles11.Text = intMiles
                txtOSSAAID12.Focus()
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID12_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID12.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID12.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID12.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName12.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName12.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName12.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName12.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity12.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip12.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles12.Text = intMiles
                txtOSSAAID13.Focus()
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID13_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID13.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID13.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID13.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName13.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName13.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName13.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName13.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity13.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip13.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles13.Text = intMiles
                txtOSSAAID14.Focus()
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID14_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID14.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID14.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID14.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName14.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName14.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName14.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName14.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity14.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip14.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles14.Text = intMiles
                txtOSSAAID15.Focus()
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID15_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID15.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID15.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID15.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName15.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName15.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName15.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName15.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity15.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip15.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles15.Text = intMiles
                txtOSSAAID16.Focus()
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID16_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID16.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID16.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID16.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName16.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName16.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName16.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName16.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity16.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip16.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles16.Text = intMiles
                txtOSSAAID17.Focus()
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID17_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID17.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID17.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID17.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName17.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName17.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName17.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName17.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity17.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip17.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles17.Text = intMiles
                txtOSSAAID18.Focus()
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID18_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID18.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID18.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID18.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName18.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName18.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName18.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName18.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity18.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip18.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles18.Text = intMiles
                txtOSSAAID19.Focus()
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID19_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID19.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID19.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID19.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName19.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName19.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName19.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName19.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity19.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip19.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles19.Text = intMiles
                txtOSSAAID20.Focus()
            End If
        End If

    End Sub

    Protected Sub txtOSSAAID20_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID20.TextChanged
        If Session("prefUser") = "" Then
            Response.Redirect("LoginWRPref.aspx")
        End If
        If Not IsNumeric(Me.txtOSSAAID20.Text) Then
            MessageLoad("You must enter a Number.")
        Else
            Dim ds As DataSet
            Dim intOfficialID As Long = CLng(Me.txtOSSAAID20.Text)
            Dim strSQL As String = "SELECT * FROM viewOfficialsWrestlingEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
            Dim strZipCode As String
            Dim intMiles As Integer = 9999

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If ds Is Nothing Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName20.Text = gInvalidName
            ElseIf ds.Tables.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName20.Text = gInvalidName
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                MessageLoad(gInvalidMessage)
                Me.lblOfficialName20.Text = gInvalidName
            Else
                MessageLoad("")
                Me.lblOfficialName20.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                Me.lblOfficialCity20.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                strZipCode = Left(strZipCode, 5)
                Me.lblOfficialZip20.Text = strZipCode
                'intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                'Me.lblOfficialMiles20.Text = intMiles
                txtOSSAAID1.Focus()
            End If
        End If

    End Sub

    Protected Sub cmdBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBack.Click
        Response.Redirect("~/Officials/LoginWRPref.aspx")
    End Sub

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Server.ScriptTimeout = 3600
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ''Response.Redirect("LoginWRPref.aspx")       ' added 10/17/2017...
        ''If Session("prefUser") = "" Then
        ''    '''''Response.Redirect("LoginWRPref.aspx")
        ''End If

        If Not IsPostBack Then
            LoadData()
            Dim strText As String
            strText = "In the spaces below, select your preference of officials to be used in the regional and championship tournaments.  The regional officials should be based on <strong>realistic geographics</strong>.  The state tournament officials may be listed from any location.<br><br>"
            strText = strText & "Coaches that do not submit their entries on time, will be placed on warning for one year.  If a wrestling coach is placed on warning for two consecutive years for not turning in his wrestling officials preferenitial list, that coach must write a letter to the OSSAA Board of Directors and explain his actions.  This letter must be signed by the coach and high school principal."

            lblMiles.Text = strText

            lblPrefHeader.Text = "PREFERENTIAL LISTS RECEIVED AFTER NOON " & ConfigurationManager.AppSettings("PrefListDueDateWR") & " WILL NOT BE CONSIDERED."

            Dim strSQL As String = "SELECT * FROM tblPlayoffPrefsWR WHERE strEmail = '" & Session("userEmail") & "' AND intYear = " & clsFunctions.GetCurrentYear
            Dim strEmail As String = ""
            strEmail = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If strEmail = "" Then
                strSQL = "INSERT INTO tblPlayoffPrefsWR (intYear, strEmail) VALUES (" & clsFunctions.GetCurrentYear & ", '" & Session("userEmail") & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If

        End If
        lblHeader.Text = ConfigurationManager.AppSettings("CurrentYearFull") & " WRESTLING PREFERENTIAL OFFICIALS LIST (STEP 1)"
    End Sub

    Public Sub DoSave()
        Dim strSQL As String
        Dim intId As Long = 0
        Dim strMessage As String = ""

        If Session("prefUser") = "" Then
            '''''Response.Redirect("LoginWRPref.aspx")
        End If

        strMessage = VerifyFields()

        If strMessage <> "OK" Then
            MessageLoad(strMessage)
        Else


            strSQL = "UPDATE tblPlayoffPrefsWR SET "

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
            strSQL = "DELETE FROM tblPlayoffPrefsDetailWR WHERE strEmail = '" & Session("userEmail") & "' AND intYear = " & clsFunctions.GetCurrentYear
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            ' Now UPDATE this list...
            strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
            strSQL = strSQL & "'" & Session("userEmail") & "', "
            strSQL = strSQL & "'" & Me.txtOSSAAID1.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialName1.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialZip1.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialCity1.Text & "', "
            strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
            strSQL = strSQL & "1, "
            strSQL = strSQL & "'0')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
            strSQL = strSQL & "'" & Session("userEmail") & "', "
            strSQL = strSQL & "'" & Me.txtOSSAAID2.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialName2.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialZip2.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialCity2.Text & "', "
            strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
            strSQL = strSQL & "2, "
            strSQL = strSQL & "'0')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
            strSQL = strSQL & "'" & Session("userEmail") & "', "
            strSQL = strSQL & "'" & Me.txtOSSAAID3.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialName3.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialZip3.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialCity3.Text & "', "
            strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
            strSQL = strSQL & "3, "
            strSQL = strSQL & "'0')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
            strSQL = strSQL & "'" & Session("userEmail") & "', "
            strSQL = strSQL & "'" & Me.txtOSSAAID4.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialName4.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialZip4.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialCity4.Text & "', "
            strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
            strSQL = strSQL & "4, "
            strSQL = strSQL & "'0')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
            strSQL = strSQL & "'" & Session("userEmail") & "', "
            strSQL = strSQL & "'" & Me.txtOSSAAID5.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialName5.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialZip5.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialCity5.Text & "', "
            strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
            strSQL = strSQL & "5, "
            strSQL = strSQL & "'0')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
            strSQL = strSQL & "'" & Session("userEmail") & "', "
            strSQL = strSQL & "'" & Me.txtOSSAAID6.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialName6.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialZip6.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialCity6.Text & "', "
            strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
            strSQL = strSQL & "6, "
            strSQL = strSQL & "'0')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If Me.txtOSSAAID7.Text = "" Then

            Else
                strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
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
                strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
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
                strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
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
                strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
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

            strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
            strSQL = strSQL & "'" & Session("userEmail") & "', "
            strSQL = strSQL & "'" & Me.txtOSSAAID11.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialName11.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialZip11.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialCity11.Text & "', "
            strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
            strSQL = strSQL & "11, "
            strSQL = strSQL & "'0')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
            strSQL = strSQL & "'" & Session("userEmail") & "', "
            strSQL = strSQL & "'" & Me.txtOSSAAID12.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialName12.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialZip12.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialCity12.Text & "', "
            strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
            strSQL = strSQL & "12, "
            strSQL = strSQL & "'0')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
            strSQL = strSQL & "'" & Session("userEmail") & "', "
            strSQL = strSQL & "'" & Me.txtOSSAAID13.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialName13.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialZip13.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialCity13.Text & "', "
            strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
            strSQL = strSQL & "13, "
            strSQL = strSQL & "'0')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
            strSQL = strSQL & "'" & Session("userEmail") & "', "
            strSQL = strSQL & "'" & Me.txtOSSAAID14.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialName14.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialZip14.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialCity14.Text & "', "
            strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
            strSQL = strSQL & "14, "
            strSQL = strSQL & "'0')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
            strSQL = strSQL & "'" & Session("userEmail") & "', "
            strSQL = strSQL & "'" & Me.txtOSSAAID15.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialName15.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialZip15.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialCity15.Text & "', "
            strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
            strSQL = strSQL & "15, "
            strSQL = strSQL & "'0')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
            strSQL = strSQL & "'" & Session("userEmail") & "', "
            strSQL = strSQL & "'" & Me.txtOSSAAID16.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialName16.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialZip16.Text & "', "
            strSQL = strSQL & "'" & Me.lblOfficialCity16.Text & "', "
            strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
            strSQL = strSQL & "16, "
            strSQL = strSQL & "'0')"
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            If Me.txtOSSAAID17.Text = "" Then

            Else
                strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
                strSQL = strSQL & "'" & Session("userEmail") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID17.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName17.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip17.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity17.Text & "', "
                strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
                strSQL = strSQL & "17, "
                strSQL = strSQL & "'0')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If

            If Me.txtOSSAAID18.Text = "" Then

            Else
                strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
                strSQL = strSQL & "'" & Session("userEmail") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID18.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName18.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip18.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity18.Text & "', "
                strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
                strSQL = strSQL & "18, "
                strSQL = strSQL & "'0')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If

            If Me.txtOSSAAID17.Text = "" Then

            Else
                strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
                strSQL = strSQL & "'" & Session("userEmail") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID19.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName19.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip19.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity19.Text & "', "
                strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
                strSQL = strSQL & "19, "
                strSQL = strSQL & "'0')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If

            If Me.txtOSSAAID20.Text = "" Then

            Else
                strSQL = "INSERT INTO tblPlayoffPrefsDetailWR (strEmail, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intYear, intRank, intMiles) VALUES ("
                strSQL = strSQL & "'" & Session("userEmail") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID20.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName20.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip20.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity20.Text & "', "
                strSQL = strSQL & clsFunctions.GetCurrentYear & ", "
                strSQL = strSQL & "20, "
                strSQL = strSQL & "'0')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            End If

            ' Send Email to Us and to User...
            Dim strSubject As String = "OSSAA Wrestling Preferential Information"
            Dim strContent As String = "Your Officials Playoff Preferential information has been submitted to the OSSAA.  Any additional information about playoffs can be found at our OSSAA.com website under the Sports / Wrestling tab.  If you have any questions regarding Officals, contact sriddell@ossaa.com.  Wrestling Playoffs questions, contact tgoolsby@ossaa.com."
            Dim strEmailTo As String = "cwilfong@ossaa.com"

            strEmailTo = Session("userEmail")
            ' CDW changed 3/5/2019...
            '''''clsEmail.SendEmail(Me, strContent, strEmailTo, "", strSubject)
            clsEmail.SendEmailNew(strEmailTo, "", strSubject, strContent, False, "")

            ' Now send info to us...
            strEmailTo = "cwilfong@ossaa.com"
            strSubject = "OSSAA Wrestling Preferential Information : " & txtSchool.Text
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
        strSQL = "SELECT TOP 1 * FROM tblPlayoffPrefsWR WHERE strEmail = '" & Session("userEmail") & "' AND intYear = " & clsFunctions.GetCurrentYear
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
        strSQL = "SELECT * FROM tblPlayoffPrefsDetailWR WHERE strEmail = '" & Session("userEmail") & "' AND intYear = " & clsFunctions.GetCurrentYear
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
                    Case 12
                        Me.txtOSSAAID12.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName12.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity12.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles12.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip12.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try
                    Case 13
                        Me.txtOSSAAID13.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName13.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity13.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles13.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip13.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try
                    Case 14
                        Me.txtOSSAAID14.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName14.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity14.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles14.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip14.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try

                    Case 15
                        Me.txtOSSAAID15.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName15.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity15.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles15.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip15.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try

                    Case 16
                        Me.txtOSSAAID16.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName16.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity16.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles16.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip16.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try

                    Case 17
                        Me.txtOSSAAID17.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName17.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity17.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles17.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip17.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try

                    Case 18
                        Me.txtOSSAAID18.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName18.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity18.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles18.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip18.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try

                    Case 19
                        Me.txtOSSAAID19.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName19.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity19.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles19.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip19.Text = ds.Tables(0).Rows(x).Item("strZip")
                        Catch
                        End Try

                    Case 20
                        Me.txtOSSAAID20.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName20.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity20.Text = ds.Tables(0).Rows(x).Item("strCity")
                        'Me.lblOfficialMiles20.Text = ds.Tables(0).Rows(x).Item("intMiles")
                        Try
                            Me.lblOfficialZip20.Text = ds.Tables(0).Rows(x).Item("strZip")
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