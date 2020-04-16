Imports System
Imports System.IO
Imports System.Net
Imports System.Text

Partial Class PrefEdit6A5ANoAJAX
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

        'strVerifyBrackets = VerifyBrackets()

        'If strVerifyBrackets = "OK" Then

        If Me.txtSiteManagerEmail.Text = "" Then
            strReturn = "You must enter a Site Manager Email address (at the top)."
        ElseIf Me.txtSiteManagerPhone.Text = "" Then
            strReturn = "You must enter a Site Manager Phone Number (at the top)."
        ElseIf Me.txtSignature11.Text = "" Then
            strReturn = "You must enter a Site Manager signature (at the bottom)."
        ElseIf Me.txtSignature12.Text = "" Then
            strReturn = "You must enter a Site Manager school (at the bottom)."
        ElseIf Me.txtSignature21.Text = "" Or Me.txtSignature31.Text = "" Or Me.txtSignature41.Text = "" Then
            strReturn = "There must be at least 4 School Representative Signatures."
        ElseIf Me.txtSignature22.Text = "" Or Me.txtSignature32.Text = "" Or Me.txtSignature42.Text = "" Then
            strReturn = "There must be at least 4 School Representative Schools."
        ElseIf Me.txtOSSAAID1.Text = "" Or Me.lblOfficialCity1.Text = "" Then
            strReturn = "You must select a #1 OSSAA ID#"
        ElseIf Me.txtOSSAAID2.Text = "" Or Me.lblOfficialCity2.Text = "" Then
            strReturn = "You must select a #2 OSSAA ID#"
        ElseIf Me.txtOSSAAID3.Text = "" Or Me.lblOfficialCity3.Text = "" Then
            strReturn = "You must select a #3 OSSAA ID#"
        ElseIf Me.txtOSSAAID4.Text = "" Or Me.lblOfficialCity4.Text = "" Then
            strReturn = "You must select a #4 OSSAA ID#"
        ElseIf Me.txtOSSAAID5.Text = "" Or Me.lblOfficialCity5.Text = "" Then
            strReturn = "You must select a #5 OSSAA ID#"
        ElseIf Me.txtOSSAAID6.Text = "" Or Me.lblOfficialCity6.Text = "" Then
            strReturn = "You must select a #6 OSSAA ID#"
        ElseIf Me.txtOSSAAID7.Text = "" Or Me.lblOfficialCity7.Text = "" Then
            strReturn = "You must select a #7 OSSAA ID#"
        ElseIf Me.txtOSSAAID8.Text = "" Or Me.lblOfficialCity8.Text = "" Then
            strReturn = "You must select a #8 OSSAA ID#"
        ElseIf Me.txtOSSAAID9.Text = "" Or Me.lblOfficialCity9.Text = "" Then
            strReturn = "You must select a #9 OSSAA ID#"
        ElseIf Me.txtOSSAAID10.Text = "" Or Me.lblOfficialCity10.Text = "" Then
            strReturn = "You must select a #10 OSSAA ID#"
        ElseIf Me.txtOSSAAID11.Text = "" Or Me.lblOfficialCity11.Text = "" Then
            strReturn = "You must select a #11 OSSAA ID#"
        ElseIf Me.txtOSSAAID12.Text = "" Or Me.lblOfficialCity12.Text = "" Then
            strReturn = "You must select a #12 OSSAA ID#"
        ElseIf Me.txtOSSAAID13.Text = "" Or Me.lblOfficialCity13.Text = "" Then
            strReturn = "You must select a #13 OSSAA ID#"
        ElseIf Me.txtOSSAAID14.Text = "" Or Me.lblOfficialCity14.Text = "" Then
            strReturn = "You must select a #14 OSSAA ID#"
        ElseIf Me.txtOSSAAID15.Text = "" Or Me.lblOfficialCity15.Text = "" Then
            strReturn = "You must select a #15 OSSAA ID#"
        ElseIf Me.txtOSSAAID16.Text = "" Or Me.lblOfficialCity16.Text = "" Then
            strReturn = "You must select a #16 OSSAA ID#"
        ElseIf Me.txtOSSAAID17.Text = "" Or Me.lblOfficialCity17.Text = "" Then
            strReturn = "You must select a #17 OSSAA ID#"
        ElseIf Me.txtOSSAAID18.Text = "" Or Me.lblOfficialCity18.Text = "" Then
            strReturn = "You must select a #18 OSSAA ID#"
        ElseIf Me.txtOSSAAID19.Text = "" Or Me.lblOfficialCity19.Text = "" Then
            strReturn = "You must select a #19 OSSAA ID#"
        ElseIf Me.txtOSSAAID20.Text = "" Or Me.lblOfficialCity20.Text = "" Then
            strReturn = "You must select a #20 OSSAA ID#"
        ElseIf CheckDuplicates() <> "OK" Then
            strReturn = "You have entered an OFFICIAL twice."
        End If
        Return strReturn
    End Function

    Public Function CheckDuplicates() As String
        ' Added 1/26/2018...
        Dim strReturn As String = "OK"

        If (txtOSSAAID1.Text = txtOSSAAID2.Text) Or (txtOSSAAID1.Text = txtOSSAAID3.Text) Or (txtOSSAAID1.Text = txtOSSAAID4.Text) Or (txtOSSAAID1.Text = txtOSSAAID5.Text) Or (txtOSSAAID1.Text = txtOSSAAID6.Text) Or (txtOSSAAID1.Text = txtOSSAAID7.Text) Or (txtOSSAAID1.Text = txtOSSAAID8.Text) Or (txtOSSAAID1.Text = txtOSSAAID9.Text) Or (txtOSSAAID1.Text = txtOSSAAID10.Text) Or (txtOSSAAID1.Text = txtOSSAAID11.Text) Or (txtOSSAAID1.Text = txtOSSAAID12.Text) Or (txtOSSAAID1.Text = txtOSSAAID13.Text) Or (txtOSSAAID1.Text = txtOSSAAID14.Text) Or (txtOSSAAID1.Text = txtOSSAAID15.Text) Then
            strReturn = "FAILED"
        ElseIf (txtOSSAAID2.Text = txtOSSAAID3.Text) Or (txtOSSAAID2.Text = txtOSSAAID4.Text) Or (txtOSSAAID2.Text = txtOSSAAID5.Text) Or (txtOSSAAID2.Text = txtOSSAAID6.Text) Or (txtOSSAAID2.Text = txtOSSAAID7.Text) Or (txtOSSAAID2.Text = txtOSSAAID8.Text) Or (txtOSSAAID2.Text = txtOSSAAID9.Text) Or (txtOSSAAID2.Text = txtOSSAAID10.Text) Or (txtOSSAAID2.Text = txtOSSAAID11.Text) Or (txtOSSAAID2.Text = txtOSSAAID12.Text) Or (txtOSSAAID2.Text = txtOSSAAID13.Text) Or (txtOSSAAID2.Text = txtOSSAAID14.Text) Or (txtOSSAAID2.Text = txtOSSAAID15.Text) Then
            strReturn = "FAILED"
        ElseIf (txtOSSAAID3.Text = txtOSSAAID4.Text) Or (txtOSSAAID3.Text = txtOSSAAID5.Text) Or (txtOSSAAID3.Text = txtOSSAAID6.Text) Or (txtOSSAAID3.Text = txtOSSAAID7.Text) Or (txtOSSAAID3.Text = txtOSSAAID8.Text) Or (txtOSSAAID3.Text = txtOSSAAID9.Text) Or (txtOSSAAID3.Text = txtOSSAAID10.Text) Or (txtOSSAAID3.Text = txtOSSAAID11.Text) Or (txtOSSAAID3.Text = txtOSSAAID12.Text) Or (txtOSSAAID3.Text = txtOSSAAID13.Text) Or (txtOSSAAID3.Text = txtOSSAAID14.Text) Or (txtOSSAAID3.Text = txtOSSAAID15.Text) Then
            strReturn = "FAILED"
        ElseIf (txtOSSAAID4.Text = txtOSSAAID5.Text) Or (txtOSSAAID4.Text = txtOSSAAID6.Text) Or (txtOSSAAID4.Text = txtOSSAAID7.Text) Or (txtOSSAAID4.Text = txtOSSAAID8.Text) Or (txtOSSAAID4.Text = txtOSSAAID9.Text) Or (txtOSSAAID4.Text = txtOSSAAID10.Text) Or (txtOSSAAID4.Text = txtOSSAAID11.Text) Or (txtOSSAAID4.Text = txtOSSAAID12.Text) Or (txtOSSAAID4.Text = txtOSSAAID13.Text) Or (txtOSSAAID4.Text = txtOSSAAID14.Text) Or (txtOSSAAID4.Text = txtOSSAAID15.Text) Then
            strReturn = "FAILED"
        ElseIf (txtOSSAAID5.Text = txtOSSAAID6.Text) Or (txtOSSAAID5.Text = txtOSSAAID7.Text) Or (txtOSSAAID5.Text = txtOSSAAID8.Text) Or (txtOSSAAID5.Text = txtOSSAAID9.Text) Or (txtOSSAAID5.Text = txtOSSAAID10.Text) Or (txtOSSAAID5.Text = txtOSSAAID11.Text) Or (txtOSSAAID5.Text = txtOSSAAID12.Text) Or (txtOSSAAID5.Text = txtOSSAAID13.Text) Or (txtOSSAAID5.Text = txtOSSAAID14.Text) Or (txtOSSAAID5.Text = txtOSSAAID15.Text) Then
            strReturn = "FAILED"
        ElseIf (txtOSSAAID6.Text = txtOSSAAID7.Text) Or (txtOSSAAID6.Text = txtOSSAAID8.Text) Or (txtOSSAAID6.Text = txtOSSAAID9.Text) Or (txtOSSAAID6.Text = txtOSSAAID10.Text) Or (txtOSSAAID6.Text = txtOSSAAID11.Text) Or (txtOSSAAID6.Text = txtOSSAAID12.Text) Or (txtOSSAAID6.Text = txtOSSAAID13.Text) Or (txtOSSAAID6.Text = txtOSSAAID14.Text) Or (txtOSSAAID6.Text = txtOSSAAID15.Text) Then
            strReturn = "FAILED"
        ElseIf (txtOSSAAID7.Text = txtOSSAAID8.Text) Or (txtOSSAAID7.Text = txtOSSAAID9.Text) Or (txtOSSAAID7.Text = txtOSSAAID10.Text) Or (txtOSSAAID7.Text = txtOSSAAID11.Text) Or (txtOSSAAID7.Text = txtOSSAAID12.Text) Or (txtOSSAAID7.Text = txtOSSAAID13.Text) Or (txtOSSAAID7.Text = txtOSSAAID14.Text) Or (txtOSSAAID7.Text = txtOSSAAID15.Text) Then
            strReturn = "FAILED"
        ElseIf (txtOSSAAID8.Text = txtOSSAAID9.Text) Or (txtOSSAAID8.Text = txtOSSAAID10.Text) Or (txtOSSAAID8.Text = txtOSSAAID11.Text) Or (txtOSSAAID8.Text = txtOSSAAID12.Text) Or (txtOSSAAID8.Text = txtOSSAAID13.Text) Or (txtOSSAAID8.Text = txtOSSAAID14.Text) Or (txtOSSAAID8.Text = txtOSSAAID15.Text) Then
            strReturn = "FAILED"
        ElseIf (txtOSSAAID9.Text = txtOSSAAID10.Text) Or (txtOSSAAID9.Text = txtOSSAAID11.Text) Or (txtOSSAAID9.Text = txtOSSAAID12.Text) Or (txtOSSAAID9.Text = txtOSSAAID13.Text) Or (txtOSSAAID9.Text = txtOSSAAID14.Text) Or (txtOSSAAID9.Text = txtOSSAAID15.Text) Then
            strReturn = "FAILED"
        ElseIf (txtOSSAAID10.Text = txtOSSAAID11.Text) Or (txtOSSAAID10.Text = txtOSSAAID12.Text) Or (txtOSSAAID10.Text = txtOSSAAID13.Text) Or (txtOSSAAID10.Text = txtOSSAAID14.Text) Or (txtOSSAAID10.Text = txtOSSAAID15.Text) Then
            strReturn = "FAILED"
        ElseIf (txtOSSAAID11.Text = txtOSSAAID12.Text) Or (txtOSSAAID11.Text = txtOSSAAID13.Text) Or (txtOSSAAID11.Text = txtOSSAAID14.Text) Or (txtOSSAAID11.Text = txtOSSAAID15.Text) Then
            strReturn = "FAILED"
        ElseIf (txtOSSAAID12.Text = txtOSSAAID13.Text) Or (txtOSSAAID12.Text = txtOSSAAID14.Text) Or (txtOSSAAID12.Text = txtOSSAAID15.Text) Then
            strReturn = "FAILED"
        ElseIf (txtOSSAAID13.Text = txtOSSAAID14.Text) Or (txtOSSAAID13.Text = txtOSSAAID15.Text) Then
            strReturn = "FAILED"
        ElseIf (txtOSSAAID14.Text = txtOSSAAID15.Text) Then
            strReturn = "FAILED"
        End If

        Return strReturn
    End Function

    Public Function IsEligibleOfficialBasketball(ByVal intOfficialID As Long) As String
        Dim strReturn As String = "FAILED"
        Dim strSQL As String

        strSQL = "SELECT strFirstName + ' ' + strLastName FROM prodOfficials WHERE ([ysnCurrentBasketball] = -1) And (intTestBasketball >= " & ConfigurationManager.AppSettings("GetOfficialsPassingScore") & ") And (intOSSAAID = " & intOfficialID & ")"
        strSQL = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID

        Try
            strReturn = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        Catch
            strReturn = "FAILED"
        End Try

        Return strReturn
    End Function

    Protected Sub txtOSSAAID1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID1.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID1.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID1.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName1.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName1.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName1.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName1.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity1.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip1.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles1.Text = intMiles
                    txtOSSAAID2.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID2.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID2.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID2.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName2.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName2.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName2.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName2.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity2.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip2.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles2.Text = intMiles
                    txtOSSAAID3.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID3_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID3.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID3.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID3.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName3.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName3.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName3.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName3.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity3.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip3.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles3.Text = intMiles
                    txtOSSAAID4.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID4_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID4.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID4.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID4.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName4.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName4.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName4.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName4.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity4.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip4.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles4.Text = intMiles
                    txtOSSAAID5.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID5_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID5.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID5.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID5.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName5.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName5.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName5.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName5.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity5.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip5.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles5.Text = intMiles
                    txtOSSAAID6.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID6_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID6.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID6.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID6.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName6.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName6.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName6.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName6.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity6.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip6.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles6.Text = intMiles
                    txtOSSAAID7.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID7_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID7.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID7.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID7.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName7.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName7.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName7.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName7.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity7.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip7.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles7.Text = intMiles
                    txtOSSAAID8.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID8_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID8.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID8.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID8.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName8.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName8.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName8.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName8.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity8.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip8.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles8.Text = intMiles
                    txtOSSAAID9.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID9_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID9.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID9.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID9.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName9.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName9.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName9.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName9.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity9.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip9.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles9.Text = intMiles
                    txtOSSAAID10.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID10_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID10.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID10.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID10.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName10.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName10.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName10.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName10.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity10.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip10.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles10.Text = intMiles
                    txtOSSAAID11.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID11_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID11.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID11.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID11.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName11.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName11.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName11.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName11.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity11.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip11.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles11.Text = intMiles
                    txtOSSAAID12.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID12_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID12.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID12.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID12.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName12.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName12.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName12.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName12.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity12.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip12.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles12.Text = intMiles
                    txtOSSAAID13.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID13_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID13.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID13.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID13.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName13.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName13.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName13.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName13.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity13.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip13.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles13.Text = intMiles
                    txtOSSAAID14.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID14_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID14.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID14.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID14.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName14.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName14.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName14.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName14.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity14.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip14.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles14.Text = intMiles
                    txtOSSAAID15.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID15_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID15.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID15.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID15.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName15.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName15.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName15.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName15.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity15.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip15.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles15.Text = intMiles
                    txtOSSAAID17.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    ' ADDED...................
    Protected Sub txtOSSAAID16_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID16.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID16.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID16.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName16.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName16.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName16.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName16.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity16.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip16.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles16.Text = intMiles
                    txtOSSAAID17.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID17_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID17.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID17.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID17.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName17.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName17.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName17.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName17.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity17.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip17.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles17.Text = intMiles
                    txtOSSAAID18.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID18_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID18.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID18.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID18.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName18.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName18.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName18.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName18.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity18.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip18.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles18.Text = intMiles
                    txtOSSAAID19.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID19_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID19.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID19.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID19.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName19.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName19.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName19.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName19.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity19.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip19.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles19.Text = intMiles
                    txtOSSAAID20.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    Protected Sub txtOSSAAID20_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID20.TextChanged

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        Try
            If Not IsNumeric(Me.txtOSSAAID20.Text) Then
                Me.lblMessage.Text = "You must enter a Number."
            Else
                Dim ds As DataSet
                Dim intOfficialID As Long = CLng(Me.txtOSSAAID20.Text)
                Dim strSQL As String = "SELECT * FROM viewOfficialsBasketballEligibleAvailablePlayoffs WHERE intOSSAAID = " & intOfficialID
                Dim strZipCode As String
                Dim intMiles As Integer = 9999

                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If ds Is Nothing Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName20.Text = gInvalidName
                ElseIf ds.Tables.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName20.Text = gInvalidName
                ElseIf ds.Tables(0).Rows.Count = 0 Then
                    Me.lblMessage.Text = gInvalidMessage
                    Me.lblOfficialName20.Text = gInvalidName
                Else
                    Me.lblMessage.Text = ""
                    Me.lblOfficialName20.Text = UCase(ds.Tables(0).Rows(0).Item("strFullName"))
                    Me.lblOfficialCity20.Text = UCase(ds.Tables(0).Rows(0).Item("strCity"))
                    strZipCode = ds.Tables(0).Rows(0).Item("strZip")
                    strZipCode = Left(strZipCode, 5)
                    Me.lblOfficialZip20.Text = strZipCode
                    intMiles = clsZipCodes.CalcDistance(Session("DistrictHostZip"), strZipCode)
                    Me.lblOfficialMiles20.Text = intMiles
                    txtSignature11.Focus()
                End If
            End If
        Catch ex As Exception
            Me.lblMessage.Text = ex.Message.ToString
        End Try

    End Sub

    ' ENDED...................

    Protected Sub cmdBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBack.Click
        Response.Redirect("~/Officials/LoginBBPref.aspx")
    End Sub

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Server.ScriptTimeout = 3600
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        If Not IsPostBack Then
            LoadData()

            Select Case Session("DistrictClass")
                Case "A", "B"
                    lblDueDate.Text = "PREFERENTIAL LISTS RECEIVED AFTER NOON " & ConfigurationManager.AppSettings("PrefListDueDateAB") & " WILL NOT BE CONSIDERED."
                    lblDistrictInfo.Text = "DISTRICT SITE : " & Session("DistrictHostSchool") & " - Class " & Session("DistrictClass") & " - Area " & Session("DistrictArea") & " - District " & Session("DistrictDistrict") & "<br>TEAMS : " & Mid(Session("DistrictTeams"), 1, Len(Session("DistrictTeams")) - 2)
                    lblMiles.Text = "To be considered, 20 officials MUST be listed.  The list may only contain officials " & Session("DistrictDistance") & " miles from the tournament."
                Case "2A", "3A", "4A"
                    lblDueDate.Text = "PREFERENTIAL LISTS RECEIVED AFTER NOON " & ConfigurationManager.AppSettings("PrefListDueDate4A2A") & " WILL NOT BE CONSIDERED."
                    lblDistrictInfo.Text = "DISTRICT SITE : " & Session("DistrictHostSchool") & " - Class " & Session("DistrictClass") & " - Area " & Session("DistrictArea") & " - District " & Session("DistrictDistrict") & "<br>TEAMS : " & Mid(Session("DistrictTeams"), 1, Len(Session("DistrictTeams")) - 2)
                    lblMiles.Text = "To be considered, 20 officials MUST be listed.  The list may only contain officials " & Session("DistrictDistance") & " miles from the tournament."
                Case "5A", "6A"
                    lblDueDate.Text = "PREFERENTIAL LISTS RECEIVED AFTER NOON " & ConfigurationManager.AppSettings("PrefListDueDate6A5A") & " WILL NOT BE CONSIDERED."
                    If Session("DistrictArea") = "E" Then
                        lblDistrictInfo.Text = "REGIONAL SITE : " & Session("DistrictHostSchool") & " - CLASS : " & Session("DistrictClass") & " - AREA : East - REGIONAL : " & Session("DistrictDistrict") & " " & Session("DistrictGender") & "<br>TEAMS : " & Mid(Session("DistrictTeams"), 1, Len(Session("DistrictTeams")) - 2)
                    Else
                        lblDistrictInfo.Text = "REGIONAL SITE : " & Session("DistrictHostSchool") & " - CLASS : " & Session("DistrictClass") & " - AREA : West - REGIONAL : " & Session("DistrictDistrict") & " " & Session("DistrictGender") & "<br>TEAMS : " & Mid(Session("DistrictTeams"), 1, Len(Session("DistrictTeams")) - 2)
                    End If
                    lblMiles.Text = "To be considered, 20 officials MUST be listed.  The list may only contain officials " & Session("DistrictDistance") & " miles from the tournament."
            End Select

        End If

    End Sub

    Public Sub DoSave()
        Dim strSQL As String = ""
        Dim intId As Long = 0
        Dim strMessage As String = ""

        If Session("prefUser") = "" Then
            Response.Redirect("LoginBBPref.aspx")
        End If

        strMessage = VerifyFields()

        If strMessage <> "OK" Then
            lblMessage.Text = strMessage
        Else
            Try
                strSQL = "UPDATE tblDistrictPrefsBB SET "
                strSQL = strSQL & "strSiteManagerEmail = '" & Replace(Me.txtSiteManagerEmail.Text, "'", "") & "', "
                strSQL = strSQL & "strSiteManagerPhone = '" & Replace(Me.txtSiteManagerPhone.Text, "'", "") & "', "

                If Not txtSignature11.Text = "" Then
                    strSQL = strSQL & "strSchoolRep1 = '" & Replace(Me.txtSignature11.Text, "'", "") & "', "
                    strSQL = strSQL & "strSiteManagerName = '" & Replace(Me.txtSignature11.Text, "'", "") & "', "
                End If
                If Not txtSignature21.Text = "" Then
                    strSQL = strSQL & "strSchoolRep2 = '" & Replace(Me.txtSignature21.Text, "'", "") & "', "
                End If
                If Not txtSignature31.Text = "" Then
                    strSQL = strSQL & "strSchoolRep3 = '" & Replace(Me.txtSignature31.Text, "'", "") & "', "
                End If
                If Not txtSignature41.Text = "" Then
                    strSQL = strSQL & "strSchoolRep4 = '" & Replace(Me.txtSignature41.Text, "'", "") & "', "
                End If
                If Not txtSignature51.Text = "" Then
                    strSQL = strSQL & "strSchoolRep5 = '" & Replace(Me.txtSignature51.Text, "'", "") & "', "
                End If
                If Not txtSignature61.Text = "" Then
                    strSQL = strSQL & "strSchoolRep6 = '" & Replace(Me.txtSignature61.Text, "'", "") & "', "
                End If

                If Not txtSignature12.Text = "" Then
                    strSQL = strSQL & "strSchoolRepSchool1 = '" & Replace(Me.txtSignature12.Text, "'", "") & "', "
                End If
                If Not txtSignature22.Text = "" Then
                    strSQL = strSQL & "strSchoolRepSchool2 = '" & Replace(Me.txtSignature22.Text, "'", "") & "', "
                End If
                If Not txtSignature32.Text = "" Then
                    strSQL = strSQL & "strSchoolRepSchool3 = '" & Replace(Me.txtSignature32.Text, "'", "") & "', "
                End If
                If Not txtSignature42.Text = "" Then
                    strSQL = strSQL & "strSchoolRepSchool4 = '" & Replace(Me.txtSignature42.Text, "'", "") & "', "
                End If
                If Not txtSignature52.Text = "" Then
                    strSQL = strSQL & "strSchoolRepSchool5 = '" & Replace(Me.txtSignature52.Text, "'", "") & "', "
                End If
                If Not txtSignature62.Text = "" Then
                    strSQL = strSQL & "strSchoolRepSchool6 = '" & Replace(Me.txtSignature62.Text, "'", "") & "', "
                End If

                strSQL = strSQL & "dtmPosted = '" & Now & "' "
                strSQL = strSQL & "WHERE intYear = " & Session("DistrictYear") & " AND strClass = '" & Session("DistrictClass") & "' AND strArea = '" & Session("DistrictArea") & "' AND intDistrict = " & Session("DistrictDistrict") & " AND strGender = '" & Session("DistrictGender") & "'"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Dim strSQL2 As String
            strSQL2 = strSQL

            Dim intTeamTop As Integer = 0
            Dim strTeamTop As String = ""
            Dim intTeamBottom As Integer = 0
            Dim strTeamBottom As String = ""
            Dim strArbiterSchoolTop As String = ""
            Dim strArbiterSchoolBottom As String = ""
            Dim strArbiterSite As String = "NONE"
            Dim intSiteID As Long = 0

            'strArbiterSite = GetArbiterSchoolName(Session("userSchoolID"))
            strArbiterSite = GetArbiterSchoolName(Session("DistrictHostSchoolID"))
            intSiteID = GetSiteIDFromSchoolID(Session("DistrictHostSchoolID"))

            ' Now save the District Prefs officials...
            ' DELETE THE EXISTING LIST...
            Try
                strSQL = "DELETE FROM tblDistrictPrefsDetailBB WHERE idDistrictPrefs = " & Session("DistrictKey") & " AND intYear = " & Session("DistrictYear") & " AND strClass = '" & Session("DistrictClass") & "' AND strArea = '" & Session("DistrictArea") & "'"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            ' Now UPDATE this list...
            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID1.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName1.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip1.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity1.Text & "', "
                strSQL = strSQL & "1, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                'strSQL = strSQL & "'0')"
                strSQL = strSQL & "'" & Me.lblOfficialMiles1.Text & "')"
                'clsLog.LogSQL(strSQL, "None", "Official #1")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID2.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName2.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip2.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity2.Text & "', "
                strSQL = strSQL & "2, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                'strSQL = strSQL & "'0')"
                strSQL = strSQL & "'" & Me.lblOfficialMiles2.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID3.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName3.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip3.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity3.Text & "', "
                strSQL = strSQL & "3, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                'strSQL = strSQL & "'0')"
                strSQL = strSQL & "'" & Me.lblOfficialMiles3.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID4.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName4.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip4.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity4.Text & "', "
                strSQL = strSQL & "4, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                'strSQL = strSQL & "'0')"
                strSQL = strSQL & "'" & Me.lblOfficialMiles4.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID5.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName5.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip5.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity5.Text & "', "
                strSQL = strSQL & "5, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                'strSQL = strSQL & "'0')"
                strSQL = strSQL & "'" & Me.lblOfficialMiles5.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID6.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName6.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip6.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity6.Text & "', "
                strSQL = strSQL & "6, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                'strSQL = strSQL & "'0')"
                strSQL = strSQL & "'" & Me.lblOfficialMiles6.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID7.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName7.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip7.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity7.Text & "', "
                strSQL = strSQL & "7, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                'strSQL = strSQL & "'0')"
                strSQL = strSQL & "'" & Me.lblOfficialMiles7.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID8.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName8.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip8.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity8.Text & "', "
                strSQL = strSQL & "8, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                'strSQL = strSQL & "'0')"
                strSQL = strSQL & "'" & Me.lblOfficialMiles8.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID9.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName9.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip9.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity9.Text & "', "
                strSQL = strSQL & "9, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                'strSQL = strSQL & "'0')"
                strSQL = strSQL & "'" & Me.lblOfficialMiles9.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID10.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName10.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip10.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity10.Text & "', "
                strSQL = strSQL & "10, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                'strSQL = strSQL & "'0')"
                strSQL = strSQL & "'" & Me.lblOfficialMiles10.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID11.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName11.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip11.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity11.Text & "', "
                strSQL = strSQL & "11, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                'strSQL = strSQL & "'0')"
                strSQL = strSQL & "'" & Me.lblOfficialMiles11.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID12.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName12.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip12.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity12.Text & "', "
                strSQL = strSQL & "12, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                'strSQL = strSQL & "'0')"
                strSQL = strSQL & "'" & Me.lblOfficialMiles12.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID13.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName13.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip13.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity13.Text & "', "
                strSQL = strSQL & "13, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                'strSQL = strSQL & "'0')"
                strSQL = strSQL & "'" & Me.lblOfficialMiles13.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID14.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName14.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip14.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity14.Text & "', "
                strSQL = strSQL & "14, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                'strSQL = strSQL & "'0')"
                strSQL = strSQL & "'" & Me.lblOfficialMiles14.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID15.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName15.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip15.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity15.Text & "', "
                strSQL = strSQL & "15, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                'strSQL = strSQL & "'0')"
                strSQL = strSQL & "'" & Me.lblOfficialMiles15.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            ' Added.......
            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID16.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName16.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip16.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity16.Text & "', "
                strSQL = strSQL & "16, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                strSQL = strSQL & "'" & Me.lblOfficialMiles16.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID17.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName17.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip17.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity17.Text & "', "
                strSQL = strSQL & "17, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                strSQL = strSQL & "'" & Me.lblOfficialMiles17.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID18.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName18.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip18.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity18.Text & "', "
                strSQL = strSQL & "18, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                strSQL = strSQL & "'" & Me.lblOfficialMiles18.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID19.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName19.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip19.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity19.Text & "', "
                strSQL = strSQL & "19, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                strSQL = strSQL & "'" & Me.lblOfficialMiles19.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                strSQL = "INSERT INTO tblDistrictPrefsDetailBB (idDistrictPrefs, strAreaEW, strGender, intOSSAAID, strOSSAAName, strOSSAAZip, strCity, intRank, strClass, intYear, intMiles) VALUES ("
                strSQL = strSQL & Session("DistrictKey") & ", "
                strSQL = strSQL & "'" & Session("DistrictArea") & "', "
                strSQL = strSQL & "'" & Session("DistrictGender") & "', "
                strSQL = strSQL & "'" & Me.txtOSSAAID20.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialName20.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialZip20.Text & "', "
                strSQL = strSQL & "'" & Me.lblOfficialCity20.Text & "', "
                strSQL = strSQL & "20, "
                strSQL = strSQL & "'" & Session("DistrictClass") & "', "
                strSQL = strSQL & Session("DistrictYear") & ", "
                strSQL = strSQL & "'" & Me.lblOfficialMiles20.Text & "')"
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            ' Ended.......

            Dim strArea As String

            If Session("DistrictArea") = "E" Then
                strArea = "East"
            Else
                strArea = "West"
            End If

            ' Send Email to Us and to User...
            Dim strSubject As String = "Regional Playoff information for Class " & Session("DistrictClass") & " - Area " & strArea & " - Regional " & Session("DistrictDistrict") & " " & Session("DistrictGender")
            Dim strContent As String = "Your Playoff information has been submitted to the OSSAA.  Any additional information about playoffs can be found at our OSSAA.com website under the Sports / Basketball tab.  If you have any questions regarding Officals, contact sriddell@ossaa.com.  Basketball Playoffs questions, contact djackson@ossaa.com."
            Dim strEmailTo As String = "cwilfong@ossaa.com"
            Try
                strEmailTo = Session("prefUser")
                ' CDW 3/5/2019 changed...
                '''''clsEmail.SendEmail(Me, strContent, strEmailTo, "", strSubject)
                clsEmail.SendEmailNew(strEmailTo, "", strSubject, strContent, False, "")
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            ' Now send info to us...
            strEmailTo = "cwilfong@ossaa.com"
            strSubject = "REGIONAL " & Session("DistrictClass") & Session("DistrictKey") & " " & Session("DistrictHostSchool") & " : Regional Playoff information for Class " & Session("DistrictClass") & " - Area " & strArea & " - Regional " & Session("DistrictDistrict") & " " & Session("DistrictGender")
            strContent = "Submitted By : " & Session("userName") & "<br>"
            strContent = strContent & Session("userPosition") & " from : " & Session("userSchoolName") & "<br>"
            strContent = strContent & "Email : " & Session("prefUser") & "<br>"
            strContent = strContent & "Host School : " & Session("DistrictHostSchool") & "<br><br>"
            strContent = strContent & strSQL2

            Try
                ' CDW changed 3/5/2019...
                '''''clsEmail.SendEmail(Me, strContent, strEmailTo, "", strSubject)
                clsEmail.SendEmailNew(strEmailTo, "", strSubject, strContent, False, "")
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Try
                clsEmail.SendEmailNew("cwilfong@ossaa.com", "", strSubject, strContent, False, "")
                clsEmail.SendEmailNew("ggower@ossaa.com", "", strSubject, strContent, False, "")
            Catch ex As Exception
                Me.lblMessage.Text = ex.Message.ToString
            End Try

            Me.lblMessage.Text = "Changes Saved (confirmation email sent to : " & Session("prefUser") & " and the OSSAA OFFICE)"

        End If

    End Sub

    Public Function GetGameNumber(ByVal strClass As String, ByVal intRound As Integer, ByVal intDistrict As Integer, ByVal intGameNo As Integer) As Integer
        Dim intGame As Integer = 0

        Select Case strClass
            Case "2A", "A", "B"
                If intRound = 2 Then
                    intGame = intDistrict
                Else
                    If intGameNo = 1 Then
                        Select Case intDistrict
                            Case 1
                                intGame = 1
                            Case 2
                                intGame = 3
                            Case 3
                                intGame = 5
                            Case 4
                                intGame = 7
                            Case 5
                                intGame = 9
                            Case 6
                                intGame = 11
                            Case 7
                                intGame = 13
                            Case 8
                                intGame = 15
                            Case Else
                        End Select
                    Else            ' Game # 2...
                        Select Case intDistrict
                            Case 1
                                intGame = 2
                            Case 2
                                intGame = 4
                            Case 3
                                intGame = 6
                            Case 4
                                intGame = 8
                            Case 5
                                intGame = 10
                            Case 6
                                intGame = 12
                            Case 7
                                intGame = 14
                            Case 8
                                intGame = 16
                            Case Else
                        End Select
                    End If
                End If
            Case "4A", "3A"
                intGame = intDistrict
            Case "6A", "5A"
                intGame = 9999
        End Select

        GetGameNumber = intGame

    End Function

    Public Sub LoadData()
        Dim strSQL As String
        Dim ds As DataSet
        Dim ds1 As DataSet
        Dim x As Integer

        ' Load from tblDistrictPrefsBB (load school reps) and schools......
        strSQL = "SELECT TOP 1 * FROM tblDistrictPrefsBB WHERE intYear = " & Session("DistrictYear") & " AND strClass = '" & Session("DistrictClass") & "' AND strArea = '" & Session("DistrictArea") & "' AND intDistrict = " & Session("DistrictDistrict") & " AND strGender = '" & Session("DistrictGender") & "'"
        ds1 = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds1 Is Nothing Then
        ElseIf ds1.Tables.Count = 0 Then
        ElseIf ds1.Tables(0).Rows.Count = 0 Then
        Else
            With ds1.Tables(0).Rows(0)
                ' Site Manager Info...
                Try
                    Me.txtSiteManagerEmail.Text = .Item("strSiteManagerEmail")
                Catch
                End Try
                Try
                    Me.txtSiteManagerPhone.Text = .Item("strSiteManagerPhone")
                Catch
                End Try
                ' School Reps...
                If Not .Item("strSchoolRep1") Is System.DBNull.Value Then
                    Me.txtSignature11.Text = .Item("strSchoolRep1")
                End If
                If Not .Item("strSchoolRep2") Is System.DBNull.Value Then
                    Me.txtSignature21.Text = .Item("strSchoolRep2")
                End If
                If Not .Item("strSchoolRep3") Is System.DBNull.Value Then
                    Me.txtSignature31.Text = .Item("strSchoolRep3")
                End If
                If Not .Item("strSchoolRep4") Is System.DBNull.Value Then
                    Me.txtSignature41.Text = .Item("strSchoolRep4")
                End If
                If Not .Item("strSchoolRep5") Is System.DBNull.Value Then
                    Me.txtSignature51.Text = .Item("strSchoolRep5")
                End If
                If Not .Item("strSchoolRep6") Is System.DBNull.Value Then
                    Me.txtSignature61.Text = .Item("strSchoolRep6")
                End If
                If Not .Item("strSchoolRepSchool1") Is System.DBNull.Value Then
                    Me.txtSignature12.Text = .Item("strSchoolRepSchool1")
                End If
                If Not .Item("strSchoolRepSchool2") Is System.DBNull.Value Then
                    Me.txtSignature22.Text = .Item("strSchoolRepSchool2")
                End If
                If Not .Item("strSchoolRepSchool3") Is System.DBNull.Value Then
                    Me.txtSignature32.Text = .Item("strSchoolRepSchool3")
                End If
                If Not .Item("strSchoolRepSchool4") Is System.DBNull.Value Then
                    Me.txtSignature42.Text = .Item("strSchoolRepSchool4")
                End If
                If Not .Item("strSchoolRepSchool5") Is System.DBNull.Value Then
                    Me.txtSignature52.Text = .Item("strSchoolRepSchool5")
                End If
                If Not .Item("strSchoolRepSchool6") Is System.DBNull.Value Then
                    Me.txtSignature62.Text = .Item("strSchoolRepSchool6")
                End If

                PopulateDistrictTeams(ds1)

            End With
        End If

        ' Load the District Pref Officials Already Entered 1-15...
        strSQL = "SELECT * FROM tblDistrictPrefsDetailBB WHERE idDistrictPrefs = " & Session("DistrictKey") & " AND intYear = " & Session("DistrictYear") & " AND strClass = '" & Session("DistrictClass") & "'"
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
                        Me.lblOfficialZip1.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles1.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 2
                        Me.txtOSSAAID2.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName2.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity2.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip2.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles2.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 3
                        Me.txtOSSAAID3.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName3.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity3.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip3.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles3.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 4
                        Me.txtOSSAAID4.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName4.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity4.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip4.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles4.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 5
                        Me.txtOSSAAID5.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName5.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity5.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip5.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles5.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 6
                        Me.txtOSSAAID6.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName6.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity6.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip6.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles6.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 7
                        Me.txtOSSAAID7.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName7.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity7.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip7.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles7.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 8
                        Me.txtOSSAAID8.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName8.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity8.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip8.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles8.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 9
                        Me.txtOSSAAID9.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName9.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity9.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip9.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles9.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 10
                        Me.txtOSSAAID10.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName10.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity10.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip10.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles10.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 11
                        Me.txtOSSAAID11.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName11.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity11.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip11.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles11.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 12
                        Me.txtOSSAAID12.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName12.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity12.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip12.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles12.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 13
                        Me.txtOSSAAID13.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName13.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity13.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip13.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles13.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 14
                        Me.txtOSSAAID14.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName14.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity14.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip14.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles14.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 15
                        Me.txtOSSAAID15.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName15.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity15.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip15.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles15.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 16
                        Me.txtOSSAAID16.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName16.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity16.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip16.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles16.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 17
                        Me.txtOSSAAID17.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName17.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity17.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip17.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles17.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 18
                        Me.txtOSSAAID18.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName18.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity18.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip18.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles18.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 19
                        Me.txtOSSAAID19.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName19.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity19.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip19.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles19.Text = ds.Tables(0).Rows(x).Item("intMiles")
                    Case 20
                        Me.txtOSSAAID20.Text = ds.Tables(0).Rows(x).Item("intOSSAAID")
                        Me.lblOfficialName20.Text = ds.Tables(0).Rows(x).Item("strOSSAAName")
                        Me.lblOfficialCity20.Text = ds.Tables(0).Rows(x).Item("strCity")
                        Me.lblOfficialZip20.Text = ds.Tables(0).Rows(x).Item("strOSSAAZip")
                        Me.lblOfficialMiles20.Text = ds.Tables(0).Rows(x).Item("intMiles")

                End Select
            Next
        End If

    End Sub

    Public Sub PopulateDistrictTeams(ByVal ds As DataSet)
        Session("DistrictTeams") = ""
        Session("DistrictTeam1") = ""
        Session("DistrictTeam2") = ""
        Session("DistrictTeam3") = ""
        Session("DistrictTeam4") = ""

        If ds.Tables(0).Rows(0).Item("SchoolID1") Is System.DBNull.Value Then
        Else
            Session("DistrictTeams") = Session("DistrictTeams") & ds.Tables(0).Rows(0).Item("strSchool1") & " - "
            Session("DistrictTeam1") = ds.Tables(0).Rows(0).Item("strSchool1")
        End If

        If ds.Tables(0).Rows(0).Item("SchoolID2") Is System.DBNull.Value Then
        Else
            Session("DistrictTeams") = Session("DistrictTeams") & ds.Tables(0).Rows(0).Item("strSchool2") & " - "
            Session("DistrictTeam2") = ds.Tables(0).Rows(0).Item("strSchool2")
        End If

        If ds.Tables(0).Rows(0).Item("SchoolID3") Is System.DBNull.Value Then
        Else
            Session("DistrictTeams") = Session("DistrictTeams") & ds.Tables(0).Rows(0).Item("strSchool3") & " - "
            Session("DistrictTeam3") = ds.Tables(0).Rows(0).Item("strSchool3")
        End If

        If ds.Tables(0).Rows(0).Item("SchoolID4") Is System.DBNull.Value Then
        Else
            Session("DistrictTeams") = Session("DistrictTeams") & ds.Tables(0).Rows(0).Item("strSchool4") & " - "
            Session("DistrictTeam4") = ds.Tables(0).Rows(0).Item("strSchool4")
        End If

    End Sub

    Public Function GetArbiterLocation(ByVal Id As Long, ByVal strSchool As String) As String
        Dim strLocation As String
        Dim schoolID As Long

        On Error Resume Next

        strLocation = ""

        If Id = 0 Then
            strLocation = strSchool
        Else
            schoolID = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT schoolID FROM prodSchools WHERE Id = " & Id)
            strLocation = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT SchoolArbiter FROM tblSchool WHERE schoolID = " & schoolID)
        End If

        If strLocation = "" Then
            strLocation = strSchool
        End If

        GetArbiterLocation = strLocation

    End Function

    Public Function GetArbiterSchoolName(ByVal Id As Long) As String
        Dim strSchoolName As String
        On Error Resume Next

        strSchoolName = ""
        strSchoolName = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT SchoolArbiter FROM tblSchool WHERE schoolID = " & Id)
        Return strSchoolName

    End Function

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