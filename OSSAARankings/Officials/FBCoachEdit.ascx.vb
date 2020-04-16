Public Class FBCoachEdit
    Inherits System.Web.UI.UserControl

    Public gInvalidMessage As String = "Invalid OSSAAID# entered.  Please type a comment for this Official indicating why."
    Public gInvalidName As String = "INVALID OSSAAID#"

    Public objDashboard As clsDashboard

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("user") = "" Then
            Response.Redirect("LoginFBR.aspx")
        End If

        objDashboard = New clsDashboard("COACHESRATING", "Football", clsFunctions.GetCurrentYear)
        Session("gYear") = clsFunctions.GetCurrentYear

        If Not IsPostBack Then
            Session("CrewRatingID") = 0
        End If

        lblHeader.Text = ConfigurationManager.AppSettings("CurrentYearFall") & " RATE GAME CREW PERFORMANCE"

    End Sub

    Protected Sub cmdAddNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAddNew.Click
        Session("CrewRatingID") = 0
        cboWeekNew.Visible = True
        cboWeekNew.Enabled = True
        Me.txtWeek.Visible = False

        'SqlDataSource7.SelectCommand = "SELECT [intKey], [strDescriptionCoach] As [strDescription] FROM [tblOfficialsWeeksFootball] WHERE intKey <> ALL (SELECT intKey FROM tblOfficialsRatingByCoachesFB WHERE intCoachID=" & Session("CoachID") & ") AND (intKey <= 11 OR intKey > 22)"
        'cboWeekNew.DataSourceID = "SqlDataSource7"
        SqlDataSource7.DataBind()
        cboWeekNew.DataBind()

        ClearFields()
        Me.lblMessage.Text = "Update New Week Information."
    End Sub

    Protected Sub cmdEditWeek_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEditWeek.Click
        On Error Resume Next
        ' Load the week information...
        Dim intID As Integer = 0

        intID = Me.cboWeek.SelectedValue

        If intID = 0 Then
            lblMessage.Text = "You must select a week."
        Else
            Dim ds As DataSet
            Dim strSQL As String
            strSQL = "SELECT * FROM " & objDashboard.gTableSource & " WHERE Id = " & intID

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                'If CheckTime(ds.Tables(0).Rows(0).Item("dtmStamp")) <> "OK" Then
                If 1 = 2 Then
                    Me.lblMessage.Text = "You cannot change a game 72 hours after it was created."
                Else
                    Me.lblMessage.Text = ""
                    ClearFields()
                    Me.cboWeekNew.Enabled = False
                    With ds.Tables(0).Rows(0)
                        Session("CrewRatingID") = .Item("Id")
                        'Me.cboWeekNew.SelectedValue = .Item("intWeek")
                        Me.cboWeekNew.Visible = False
                        Me.txtWeek.Visible = True
                        Me.txtWeek.Text = .Item("intWeek")
                        Me.txtKey.Text = .Item("intWeekKey")

                        Me.cboHomeAway.SelectedValue = .Item("strHomeAway")

                        ' Official #1...
                        Me.txtOSSAAID1.Text = .Item("intOfficialID1")
                        Me.lblOfficialName1.Text = .Item("strOfficialName1")
                        Me.rb1.SelectedValue = .Item("intOfficialRating1")
                        Me.txtComments1.Text = .Item("strComments1")

                        ' Official #2...
                        Me.txtOSSAAID2.Text = .Item("intOfficialID2")
                        Me.lblOfficialName2.Text = .Item("strOfficialName2")
                        Me.rb2.SelectedValue = .Item("intOfficialRating2")
                        Me.txtComments2.Text = .Item("strComments2")

                        ' Official #3...
                        Me.txtOSSAAID3.Text = .Item("intOfficialID3")
                        Me.lblOfficialName3.Text = .Item("strOfficialName3")
                        Me.rb3.SelectedValue = .Item("intOfficialRating3")
                        Me.txtComments3.Text = .Item("strComments3")

                        ' Official #4...
                        Me.txtOSSAAID4.Text = .Item("intOfficialID4")
                        Me.lblOfficialName4.Text = .Item("strOfficialName4")
                        Me.rb4.SelectedValue = .Item("intOfficialRating4")
                        Me.txtComments4.Text = .Item("strComments4")

                        ' Official #5...
                        Me.txtOSSAAID5.Text = .Item("intOfficialID5")
                        Me.lblOfficialName5.Text = .Item("strOfficialName5")
                        Me.rb5.SelectedValue = .Item("intOfficialRating5")
                        Me.txtComments5.Text = .Item("strComments5")

                    End With
                End If
            End If
        End If


    End Sub

    Protected Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave.Click
        DoSave()
    End Sub

    Public Sub ClearFields()
        Me.cboWeekNew.SelectedValue = 0
        Me.txtKey.Text = ""

        Me.txtOSSAAID1.Text = ""
        Me.lblOfficialName1.Text = ""
        Me.rb1.ClearSelection()
        Me.txtComments1.Text = ""

        Me.txtOSSAAID2.Text = ""
        Me.lblOfficialName2.Text = ""
        Me.rb2.ClearSelection()
        Me.txtComments2.Text = ""

        Me.txtOSSAAID3.Text = ""
        Me.lblOfficialName3.Text = ""
        Me.rb3.ClearSelection()
        Me.txtComments3.Text = ""

        Me.txtOSSAAID4.Text = ""
        Me.lblOfficialName4.Text = ""
        Me.rb4.ClearSelection()
        Me.txtComments4.Text = ""

        Me.txtOSSAAID5.Text = ""
        Me.lblOfficialName5.Text = ""
        Me.rb5.ClearSelection()
        Me.txtComments5.Text = ""

        Me.cboHomeAway.SelectedIndex = 0

    End Sub

    Public Sub DoSave()
        Dim strSQL As String
        Dim intId As Long = 0
        Dim strMessage As String = ""

        ' Only allow to save Week #10...

        strMessage = VerifyFields()

        If strMessage <> "OK" Then
            lblMessage.Text = strMessage
        Else
            If Session("CrewRatingID") = 0 Then
                strSQL = "SELECT Id FROM " & objDashboard.gTableSource & " WHERE intWeekKey = " & cboWeekNew.SelectedValue & " And intCoachID = " & Session("CoachID")
                intId = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If intId > 0 Then
                    Me.lblMessage.Text = "Duplicate week."
                Else
                    strSQL = "INSERT INTO " & objDashboard.gTableSource & " (intSchoolID, schoolID, teamID, SchoolName, CoachName, intWeekKey, intWeek, "
                    strSQL = strSQL & "intOfficialID1, strOfficialName1, intOfficialRating1, strComments1, "
                    strSQL = strSQL & "intOfficialID2, strOfficialName2, intOfficialRating2, strComments2, "
                    strSQL = strSQL & "intOfficialID3, strOfficialName3, intOfficialRating3, strComments3, "
                    strSQL = strSQL & "intOfficialID4, strOfficialName4, intOfficialRating4, strComments4, "
                    strSQL = strSQL & "intOfficialID5, strOfficialName5, intOfficialRating5, strComments5, "
                    strSQL = strSQL & "strHomeAway, intCoachID, strSubmittedBy"

                    strSQL = strSQL & ") VALUES ("
                    strSQL = strSQL & Session("intSchoolID") & ", "
                    strSQL = strSQL & Session("SchoolID") & ", "
                    strSQL = strSQL & Session("TeamID") & ", "
                    strSQL = strSQL & "'" & Session("SchoolName") & "', "
                    strSQL = strSQL & "'" & ParseString(Session("CoachName")) & "', "
                    strSQL = strSQL & Me.cboWeekNew.SelectedValue & ", "
                    strSQL = strSQL & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT intWeek FROM tblOfficialsWeeksFootball WHERE intKey = " & Me.cboWeekNew.SelectedValue) & ", "

                    ' Official #1...
                    strSQL = strSQL & ParseString(Me.txtOSSAAID1.Text) & ", "
                    strSQL = strSQL & "'" & Me.lblOfficialName1.Text & "', "
                    strSQL = strSQL & Me.rb1.SelectedValue & ", "
                    If Me.txtComments1.Text Is Nothing Then
                        strSQL = strSQL & "'',"
                    Else
                        strSQL = strSQL & "'" & ParseString(Me.txtComments1.Text) & "', "
                    End If

                    ' Official #2...
                    strSQL = strSQL & ParseString(Me.txtOSSAAID2.Text) & ", "
                    strSQL = strSQL & "'" & Me.lblOfficialName2.Text & "', "
                    strSQL = strSQL & Me.rb2.SelectedValue & ", "
                    If Me.txtComments2.Text Is Nothing Then
                        strSQL = strSQL & "'',"
                    Else
                        strSQL = strSQL & "'" & ParseString(Me.txtComments2.Text) & "', "
                    End If

                    ' Official #3...
                    strSQL = strSQL & ParseString(Me.txtOSSAAID3.Text) & ", "
                    strSQL = strSQL & "'" & Me.lblOfficialName3.Text & "', "
                    strSQL = strSQL & Me.rb3.SelectedValue & ", "
                    If Me.txtComments3.Text Is Nothing Then
                        strSQL = strSQL & "'',"
                    Else
                        strSQL = strSQL & "'" & ParseString(Me.txtComments3.Text) & "', "
                    End If

                    ' Official #4...
                    strSQL = strSQL & ParseString(Me.txtOSSAAID4.Text) & ", "
                    strSQL = strSQL & "'" & Me.lblOfficialName4.Text & "', "
                    strSQL = strSQL & Me.rb4.SelectedValue & ", "
                    If Me.txtComments4.Text Is Nothing Then
                        strSQL = strSQL & "'',"
                    Else
                        strSQL = strSQL & "'" & ParseString(Me.txtComments4.Text) & "', "
                    End If

                    ' Official #5...
                    strSQL = strSQL & ParseString(Me.txtOSSAAID5.Text) & ", "
                    strSQL = strSQL & "'" & Me.lblOfficialName5.Text & "', "
                    strSQL = strSQL & Me.rb1.SelectedValue & ", "
                    If Me.txtComments5.Text Is Nothing Then
                        strSQL = strSQL & "'',"
                    Else
                        strSQL = strSQL & "'" & ParseString(Me.txtComments5.Text) & "', "
                    End If

                    strSQL = strSQL & "'" & Me.cboHomeAway.SelectedValue & "', "
                    strSQL = strSQL & Session("CoachID") & ", "
                    strSQL = strSQL & "'" & Session("user") & "')"

                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                    Me.cboWeek.DataBind()
                    Me.lblMessage.Text = "New Week Added."

                    ClearFields()
                End If
            Else
                ' Only allow updating of Week #10...
                'If cboWeek.SelectedItem.Text = "Week #10" Then
                If cboWeek.SelectedItem.Text = "Week #11" Or cboWeek.SelectedItem.Text = "Week #12" Or cboWeek.SelectedItem.Text = "Week #13" Or cboWeek.SelectedItem.Text = "Week #14" Or cboWeek.SelectedItem.Text = "Week #15" Then
                    strSQL = "UPDATE " & objDashboard.gTableSource & " SET "

                    ' Official #1...
                    strSQL = strSQL & "intOfficialID1 = " & ParseString(Me.txtOSSAAID1.Text) & ", "
                    strSQL = strSQL & "strOfficialName1 = '" & ParseString(Me.lblOfficialName1.Text) & "', "
                    strSQL = strSQL & "intOfficialRating1 = " & Me.rb1.SelectedValue & ", "
                    If Me.txtComments1.Text = "" Then
                        strSQL = strSQL & "strComments1 = '', "
                    Else
                        strSQL = strSQL & "strComments1 = '" & ParseString(Me.txtComments1.Text) & "', "
                    End If

                    ' Official #1...
                    strSQL = strSQL & "intOfficialID2 = " & ParseString(Me.txtOSSAAID2.Text) & ", "
                    strSQL = strSQL & "strOfficialName2 = '" & Me.lblOfficialName2.Text & "', "
                    strSQL = strSQL & "intOfficialRating2 = " & Me.rb2.SelectedValue & ", "
                    If Me.txtComments2.Text = "" Then
                        strSQL = strSQL & "strComments2 = '', "
                    Else
                        strSQL = strSQL & "strComments2 = '" & ParseString(Me.txtComments2.Text) & "', "
                    End If

                    ' Official #3...
                    strSQL = strSQL & "intOfficialID3 = " & ParseString(Me.txtOSSAAID3.Text) & ", "
                    strSQL = strSQL & "strOfficialName3 = '" & Me.lblOfficialName3.Text & "', "
                    strSQL = strSQL & "intOfficialRating3 = " & Me.rb3.SelectedValue & ", "
                    If Me.txtComments3.Text = "" Then
                        strSQL = strSQL & "strComments3 = '', "
                    Else
                        strSQL = strSQL & "strComments3 = '" & ParseString(Me.txtComments3.Text) & "', "
                    End If

                    ' Official #4...
                    strSQL = strSQL & "intOfficialID4 = " & ParseString(Me.txtOSSAAID4.Text) & ", "
                    strSQL = strSQL & "strOfficialName4 = '" & Me.lblOfficialName4.Text & "', "
                    strSQL = strSQL & "intOfficialRating4 = " & Me.rb4.SelectedValue & ", "
                    If Me.txtComments4.Text = "" Then
                        strSQL = strSQL & "strComments4 = '', "
                    Else
                        strSQL = strSQL & "strComments4 = '" & ParseString(Me.txtComments4.Text) & "', "
                    End If

                    ' Official #5...
                    strSQL = strSQL & "intOfficialID5 = " & ParseString(Me.txtOSSAAID5.Text) & ", "
                    strSQL = strSQL & "strOfficialName5 = '" & Me.lblOfficialName5.Text & "', "
                    strSQL = strSQL & "intOfficialRating5 = " & Me.rb5.SelectedValue & ", "
                    If Me.txtComments5.Text = "" Then
                        strSQL = strSQL & "strComments5 = '', "
                    Else
                        strSQL = strSQL & "strComments5 = '" & ParseString(Me.txtComments5.Text) & "', "
                    End If

                    strSQL = strSQL & "strSubmittedBy = '" & Session("user") & "' "


                    strSQL = strSQL & "WHERE Id = " & Session("CrewRatingID")

                    SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                    Me.cboWeek.DataBind()

                    Me.lblMessage.Text = "Changes Saved."
                    ClearFields()
                Else
                    'Me.lblMessage.Text = "You can not change Weeks #1 - #9."
                    Me.lblMessage.Text = "You can not change Weeks #1 - #10."
                End If

            End If
        End If

    End Sub

    Public Function CheckTime(ByVal dtmIn As Date) As String
        Dim strReturn As String = "OK"

        'If DateDiff(DateInterval.Hour, dtmIn, Now) > 72 Then
        'strReturn = "FAILED"
        'End If

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

    Public Function VerifyFields()
        Dim strReturn As String = "OK"

        If cboWeekNew.SelectedValue = 0 And txtWeek.Text = "" Then
            strReturn = "You must select a WEEK."
        ElseIf Me.cboHomeAway.SelectedValue <> "H" And Me.cboHomeAway.SelectedValue <> "A" Then
            strReturn = "You must select HOME or AWAY."
        ElseIf Me.txtOSSAAID1.Text = "" Then
            strReturn = "You must enter the OSSAA ID# for Official #1."
        ElseIf Me.txtOSSAAID2.Text = "" Then
            strReturn = "You must enter the OSSAA ID# for Official #2."
        ElseIf Me.txtOSSAAID3.Text = "" Then
            strReturn = "You must enter the OSSAA ID# for Official #3."
        ElseIf Me.txtOSSAAID4.Text = "" Then
            strReturn = "You must enter the OSSAA ID# for Official #4."
        ElseIf Me.txtOSSAAID5.Text = "" Then
            strReturn = "You must enter the OSSAA ID# for Official #5."
        ElseIf Me.rb1.SelectedValue = "" Then
            strReturn = "You must select a rating for Official #1."
        ElseIf Me.rb2.SelectedValue = "" Then
            strReturn = "You must select a rating for Official #2."
        ElseIf Me.rb3.SelectedValue = "" Then
            strReturn = "You must select a rating for Official #3."
        ElseIf Me.rb4.SelectedValue = "" Then
            strReturn = "You must select a rating for Official #4."
        ElseIf Me.rb5.SelectedValue = "" Then
            strReturn = "You must select a rating for Official #5."
        ElseIf Me.rb1.SelectedValue = "5" And Me.txtComments1.Text = "" Then
            strReturn = "You must enter a Comment for Official #1 (POOR rating)."
        ElseIf Me.rb2.SelectedValue = "5" And Me.txtComments2.Text = "" Then
            strReturn = "You must enter a Comment for Official #2 (POOR rating)."
        ElseIf Me.rb3.SelectedValue = "5" And Me.txtComments3.Text = "" Then
            strReturn = "You must enter a Comment for Official #3 (POOR rating)."
        ElseIf Me.rb4.SelectedValue = "5" And Me.txtComments4.Text = "" Then
            strReturn = "You must enter a Comment for Official #4 (POOR rating)."
        ElseIf Me.rb5.SelectedValue = "5" And Me.txtComments5.Text = "" Then
            strReturn = "You must enter a Comment for Official #5 (POOR rating)."
        ElseIf Me.lblOfficialName1.Text = gInvalidName And Me.txtComments1.Text = "" Then
            strReturn = "You must enter a Comment for Official #1 (INVALID OSSAAID#)."
        ElseIf Me.lblOfficialName2.Text = gInvalidName And Me.txtComments2.Text = "" Then
            strReturn = "You must enter a Comment for Official #2 (INVALID OSSAAID#)."
        ElseIf Me.lblOfficialName3.Text = gInvalidName And Me.txtComments3.Text = "" Then
            strReturn = "You must enter a Comment for Official #3 (INVALID OSSAAID#)."
        ElseIf Me.lblOfficialName4.Text = gInvalidName And Me.txtComments4.Text = "" Then
            strReturn = "You must enter a Comment for Official #4 (INVALID OSSAAID#)."
        ElseIf Me.lblOfficialName5.Text = gInvalidName And Me.txtComments5.Text = "" Then
            strReturn = "You must enter a Comment for Official #5 (INVALID OSSAAID#)."
        Else
            strReturn = "OK"
        End If
        Return strReturn
    End Function

    Public Function IsEligibleOfficialFootball(ByVal intOfficialID As Long) As String
        Dim strReturn As String = "FAILED"
        Dim strSQL As String

        strSQL = "SELECT strFirstName + ' ' + strLastName FROM prodOfficials WHERE (([ysnCurrentFootball] = -1) And (intTestFootball >= 74) And (intOSSAAID = " & intOfficialID & ") AND (strState = 'OK'))"
        ' Added 10/13/2014...
        strSQL = strSQL & " OR (([ysnCurrentFootball] = -1) And (intOSSAAID = " & intOfficialID & ") AND (strState <> 'OK'))"

        Try
            strReturn = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        Catch
            strReturn = "FAILED"
        End Try

        Return strReturn
    End Function

    Protected Sub txtOSSAAID1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID1.TextChanged
        ' Verify that it is Numeric and get the First/Last Name...
        If Not IsNumeric(Me.txtOSSAAID1.Text) Then
            Me.lblMessage.Text = "You must enter a Number."
        Else
            Dim strFirstLast As String
            Try
                strFirstLast = IsEligibleOfficialFootball(CLng(Me.txtOSSAAID1.Text))
            Catch
                strFirstLast = "FAILED"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblMessage.Text = gInvalidMessage
                Me.lblOfficialName1.Text = gInvalidName
            ElseIf strFirstLast = "FAILED" Then
                Me.lblMessage.Text = gInvalidMessage
                Me.lblOfficialName1.Text = gInvalidName
            Else
                Me.lblMessage.Text = ""
                Me.lblOfficialName1.Text = strFirstLast
            End If
        End If
    End Sub

    Protected Sub txtOSSAAID2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID2.TextChanged
        ' Verify that it is Numeric and get the First/Last Name...
        If Not IsNumeric(Me.txtOSSAAID2.Text) Then
            Me.lblMessage.Text = "You must enter a Number."
        Else
            Dim strFirstLast As String
            Try
                strFirstLast = IsEligibleOfficialFootball(CLng(Me.txtOSSAAID2.Text))
            Catch
                strFirstLast = "FAILED"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblMessage.Text = gInvalidMessage
                Me.lblOfficialName2.Text = gInvalidName
            ElseIf strFirstLast = "FAILED" Then
                Me.lblMessage.Text = gInvalidMessage
                Me.lblOfficialName2.Text = gInvalidName
            Else
                Me.lblMessage.Text = ""
                Me.lblOfficialName2.Text = strFirstLast
            End If
        End If
    End Sub

    Protected Sub txtOSSAAID3_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID3.TextChanged
        ' Verify that it is Numeric and get the First/Last Name...
        If Not IsNumeric(Me.txtOSSAAID3.Text) Then
            Me.lblMessage.Text = "You must enter a Number."
        Else
            Dim strFirstLast As String
            Try
                strFirstLast = IsEligibleOfficialFootball(CLng(Me.txtOSSAAID3.Text))
            Catch
                strFirstLast = "FAILED"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblMessage.Text = gInvalidMessage
                Me.lblOfficialName3.Text = gInvalidName
            ElseIf strFirstLast = "FAILED" Then
                Me.lblMessage.Text = gInvalidMessage
                Me.lblOfficialName3.Text = gInvalidName
            Else
                Me.lblMessage.Text = ""
                Me.lblOfficialName3.Text = strFirstLast
            End If
        End If
    End Sub

    Protected Sub txtOSSAAID4_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID4.TextChanged
        ' Verify that it is Numeric and get the First/Last Name...
        If Not IsNumeric(Me.txtOSSAAID4.Text) Then
            Me.lblMessage.Text = "You must enter a Number."
        Else
            Dim strFirstLast As String
            Try
                strFirstLast = IsEligibleOfficialFootball(CLng(Me.txtOSSAAID4.Text))
            Catch
                strFirstLast = "FAILED"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblMessage.Text = gInvalidMessage
                Me.lblOfficialName4.Text = gInvalidName
            ElseIf strFirstLast = "FAILED" Then
                Me.lblMessage.Text = gInvalidMessage
                Me.lblOfficialName4.Text = gInvalidName
            Else
                Me.lblMessage.Text = ""
                Me.lblOfficialName4.Text = strFirstLast
            End If
        End If
    End Sub

    Protected Sub txtOSSAAID5_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtOSSAAID5.TextChanged
        ' Verify that it is Numeric and get the First/Last Name...
        If Not IsNumeric(Me.txtOSSAAID5.Text) Then
            Me.lblMessage.Text = "You must enter a Number."
        Else
            Dim strFirstLast As String
            Try
                strFirstLast = IsEligibleOfficialFootball(CLng(Me.txtOSSAAID5.Text))
            Catch
                strFirstLast = "FAILED"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblMessage.Text = gInvalidMessage
                Me.lblOfficialName5.Text = gInvalidName
            ElseIf strFirstLast = "FAILED" Then
                Me.lblMessage.Text = gInvalidMessage
                Me.lblOfficialName5.Text = gInvalidName
            Else
                Me.lblMessage.Text = ""
                Me.lblOfficialName5.Text = strFirstLast
            End If
        End If
    End Sub

    'Protected Sub cmdBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBack.Click
    '    Response.Redirect("~/Officials/FBMainMenu.aspx")
    'End Sub
End Class