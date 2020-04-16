Public Class ucFBScratchList
    Inherits System.Web.UI.UserControl

    Public objDashboard As clsDashboard

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("user") = "" Then
            Response.Redirect("LoginFBR.aspx")
        End If
        objDashboard = New clsDashboard("COACHESSCRATCH", "Football", clsFunctions.GetCurrentYear)

        If Not IsPostBack Then
            LoadData()
        End If

        lblHeader.Text = "OSSAA PLAYOFF SCRATCH LIST"

    End Sub

    Public Sub InsertNew(ByVal teamID As Integer)
        Dim strSQL As String
        strSQL = "INSERT INTO " & objDashboard.gTableSource & " (teamID, schoolID, memberID, SchoolDisplay, CoachName, intYear) VALUES ("
        strSQL = strSQL & Session("TeamID") & ", " & Session("SchoolID") & ", " & Session("MemberID") & ", '" & Session("SchoolName") & "', '" & Session("CoachName") & "', " & objDashboard.gYearInt & ")"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
    End Sub

    Public Sub LoadData()
        On Error Resume Next
        ' Load the week information...
        Dim intID As Integer = 0

        Dim ds As DataSet
        Dim strSQL As String
        strSQL = "SELECT * FROM " & objDashboard.gTableSource & " WHERE teamID = " & Session("TeamID") & " AND intYear = " & objDashboard.gYearInt

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        If ds Is Nothing Then
            InsertNew(Session("TeamID"))
        ElseIf ds.Tables.Count = 0 Then
            InsertNew(Session("TeamID"))
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            InsertNew(Session("TeamID"))
        Else

            Me.lblMessage.Text = ""
            ClearFields()
            With ds.Tables(0).Rows(0)
                ' Official #1...
                Me.txtOSSAAID1.Text = .Item("intOfficialID1")
                Me.lblOfficialName1.Text = .Item("strOfficialName1")

                ' Official #2...
                Me.txtOSSAAID2.Text = .Item("intOfficialID2")
                Me.lblOfficialName2.Text = .Item("strOfficialName2")

                ' Official #3...
                Me.txtOSSAAID3.Text = .Item("intOfficialID3")
                Me.lblOfficialName3.Text = .Item("strOfficialName3")

                ' Official #4...
                Me.txtOSSAAID4.Text = .Item("intOfficialID4")
                Me.lblOfficialName4.Text = .Item("strOfficialName4")

                ' Official #5...
                Me.txtOSSAAID5.Text = .Item("intOfficialID5")
                Me.lblOfficialName5.Text = .Item("strOfficialName5")

            End With
        End If

    End Sub

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

    End Sub

    Public Sub DoSave()
        Dim strSQL As String
        Dim intId As Long = 0
        Dim strMessage As String = ""

        strMessage = VerifyFields()

        If strMessage <> "OK" Then
            lblMessage.Text = strMessage
        Else
            strSQL = "UPDATE " & objDashboard.gTableSource & " SET "

            ' Official #1...
            If ParseString(Me.txtOSSAAID1.Text) = "" Then
                strSQL = strSQL & "intOfficialID1 = Null, "
                strSQL = strSQL & "strOfficialName1 = Null, "
            Else
                strSQL = strSQL & "intOfficialID1 = " & ParseString(Me.txtOSSAAID1.Text) & ", "
                strSQL = strSQL & "strOfficialName1 = '" & ParseString(Me.lblOfficialName1.Text) & "', "
            End If

            ' Official #2...
            If ParseString(Me.txtOSSAAID2.Text) = "" Then
                strSQL = strSQL & "intOfficialID2 = Null, "
                strSQL = strSQL & "strOfficialName2 = Null, "
            Else
                strSQL = strSQL & "intOfficialID2 = " & ParseString(Me.txtOSSAAID2.Text) & ", "
                strSQL = strSQL & "strOfficialName2 = '" & Me.lblOfficialName2.Text & "', "
            End If

            ' Official #3...
            If ParseString(Me.txtOSSAAID3.Text) = "" Then
                strSQL = strSQL & "intOfficialID3 = Null, "
                strSQL = strSQL & "strOfficialName3 = Null, "
            Else
                strSQL = strSQL & "intOfficialID3 = " & ParseString(Me.txtOSSAAID3.Text) & ", "
                strSQL = strSQL & "strOfficialName3 = '" & Me.lblOfficialName3.Text & "', "
            End If

            ' Official #4...
            If ParseString(Me.txtOSSAAID4.Text) = "" Then
                strSQL = strSQL & "intOfficialID4 = Null, "
                strSQL = strSQL & "strOfficialName4 = Null, "
            Else
                strSQL = strSQL & "intOfficialID4 = " & ParseString(Me.txtOSSAAID4.Text) & ", "
                strSQL = strSQL & "strOfficialName4 = '" & Me.lblOfficialName4.Text & "', "
            End If

            ' Official #5...
            If ParseString(Me.txtOSSAAID5.Text) = "" Then
                strSQL = strSQL & "intOfficialID5 = Null, "
                strSQL = strSQL & "strOfficialName5 = Null, "
            Else
                strSQL = strSQL & "intOfficialID5 = " & ParseString(Me.txtOSSAAID5.Text) & ", "
                strSQL = strSQL & "strOfficialName5 = '" & Me.lblOfficialName5.Text & "', "
            End If

            strSQL = strSQL.Trim
            strSQL = strSQL.Remove(strSQL.Length - 1)
            strSQL = strSQL & " WHERE teamID = " & Session("TeamId")

            If InStr(strSQL, "intOfficialID") > 0 Then
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                Me.lblMessage.Text = "Changes Saved."
                'lblMessage.Text = strSQL
            Else
                Me.lblMessage.Text = "Nothing to save."
            End If

        End If

    End Sub

    Public Function ParseString(ByVal strIn As Object) As String
        Dim strTemp As String = ""

        Try
            strTemp = strIn
            strTemp = strTemp.Replace("'", "")
            strTemp = strTemp.Replace("""", "")
            strTemp = strTemp.Replace("DELETE", "")
            strTemp = strTemp.Replace("SELECT ", "")
            strTemp = strTemp.Replace("UPDATE ", "")
            strTemp = strTemp.Replace("INSERT INTO ", "")
        Catch

        End Try

        Return strTemp
    End Function

    Public Function VerifyFields()
        Dim strReturn As String = "OK"
        Return strReturn
    End Function

    Protected Sub txtOSSAAID1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID1.TextChanged
        ' Verify that it is Numeric and get the First/Last Name...
        If Not IsNumeric(Me.txtOSSAAID1.Text) Then
            Me.lblOfficialName1.Text = ""
        Else
            Dim strFirstLast As String
            Try
                strFirstLast = clsOfficials.IsEligibleOfficialFootball(CLng(Me.txtOSSAAID1.Text), True)
            Catch
                strFirstLast = "FAILED"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblMessage.Text = clsOfficials.GetInvalidOfficialMessage
                Me.lblOfficialName1.Text = clsOfficials.GetInvalidOfficialNameMessage
            ElseIf strFirstLast = "FAILED" Then
                Me.lblMessage.Text = clsOfficials.GetInvalidOfficialMessage
                Me.lblOfficialName1.Text = clsOfficials.GetInvalidOfficialNameMessage
            Else
                Me.lblMessage.Text = ""
                Me.lblOfficialName1.Text = strFirstLast
            End If
        End If
    End Sub

    Protected Sub txtOSSAAID2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID2.TextChanged
        ' Verify that it is Numeric and get the First/Last Name...
        If Not IsNumeric(Me.txtOSSAAID2.Text) Then
            Me.lblOfficialName2.Text = ""
        Else
            Dim strFirstLast As String
            Try
                strFirstLast = clsOfficials.IsEligibleOfficialFootball(CLng(Me.txtOSSAAID2.Text), True)
            Catch
                strFirstLast = "FAILED"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblMessage.Text = clsOfficials.GetInvalidOfficialMessage
                Me.lblOfficialName2.Text = clsOfficials.GetInvalidOfficialNameMessage
            ElseIf strFirstLast = "FAILED" Then
                Me.lblMessage.Text = clsOfficials.GetInvalidOfficialMessage
                Me.lblOfficialName2.Text = clsOfficials.GetInvalidOfficialNameMessage
            Else
                Me.lblMessage.Text = ""
                Me.lblOfficialName2.Text = strFirstLast
            End If
        End If
    End Sub

    Protected Sub txtOSSAAID3_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID3.TextChanged
        ' Verify that it is Numeric and get the First/Last Name...
        If Not IsNumeric(Me.txtOSSAAID3.Text) Then
            Me.lblOfficialName3.Text = ""
        Else
            Dim strFirstLast As String
            Try
                strFirstLast = clsOfficials.IsEligibleOfficialFootball(CLng(Me.txtOSSAAID3.Text), True)
            Catch
                strFirstLast = "FAILED"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblMessage.Text = clsOfficials.GetInvalidOfficialMessage
                Me.lblOfficialName3.Text = clsOfficials.GetInvalidOfficialNameMessage
            ElseIf strFirstLast = "FAILED" Then
                Me.lblMessage.Text = clsOfficials.GetInvalidOfficialMessage
                Me.lblOfficialName3.Text = clsOfficials.GetInvalidOfficialNameMessage
            Else
                Me.lblMessage.Text = ""
                Me.lblOfficialName3.Text = strFirstLast
            End If
        End If
    End Sub

    Protected Sub txtOSSAAID4_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID4.TextChanged
        ' Verify that it is Numeric and get the First/Last Name...
        If Not IsNumeric(Me.txtOSSAAID4.Text) Then
            Me.lblOfficialName4.Text = ""
        Else
            Dim strFirstLast As String
            Try
                strFirstLast = clsOfficials.IsEligibleOfficialFootball(CLng(Me.txtOSSAAID4.Text), True)
            Catch
                strFirstLast = "FAILED"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblMessage.Text = clsOfficials.GetInvalidOfficialMessage
                Me.lblOfficialName4.Text = clsOfficials.GetInvalidOfficialNameMessage
            ElseIf strFirstLast = "FAILED" Then
                Me.lblMessage.Text = clsOfficials.GetInvalidOfficialMessage
                Me.lblOfficialName4.Text = clsOfficials.GetInvalidOfficialNameMessage
            Else
                Me.lblMessage.Text = ""
                Me.lblOfficialName4.Text = strFirstLast
            End If
        End If
    End Sub

    Protected Sub txtOSSAAID5_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID5.TextChanged
        ' Verify that it is Numeric and get the First/Last Name...
        If Not IsNumeric(Me.txtOSSAAID5.Text) Then
            Me.lblOfficialName5.Text = ""
        Else
            Dim strFirstLast As String
            Try
                strFirstLast = clsOfficials.IsEligibleOfficialFootball(CLng(Me.txtOSSAAID5.Text), True)
            Catch
                strFirstLast = "FAILED"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblMessage.Text = clsOfficials.GetInvalidOfficialMessage
                Me.lblOfficialName5.Text = clsOfficials.GetInvalidOfficialNameMessage
            ElseIf strFirstLast = "FAILED" Then
                Me.lblMessage.Text = clsOfficials.GetInvalidOfficialMessage
                Me.lblOfficialName5.Text = clsOfficials.GetInvalidOfficialNameMessage
            Else
                Me.lblMessage.Text = ""
                Me.lblOfficialName5.Text = strFirstLast
            End If
        End If
    End Sub

    Protected Sub cmdBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBack.Click
        Response.Redirect("~/Officials/FBMainMenu.aspx")
    End Sub
End Class