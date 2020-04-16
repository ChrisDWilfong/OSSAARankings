Partial Class BBCoachEdit
    Inherits System.Web.UI.UserControl

    Public gInvalidMessage As String = "Invalid OSSAAID# entered.  Please type a comment for this Official indicating why."
    Public gInvalidName As String = "INVALID OSSAAID#"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblHeader.Text = clsFunctions.GetCurrentYear() & " RATE GAME CREW PERFORMANCE"

        If Session("user") = "" Then
            Response.Redirect("LoginBBR.aspx")
        End If

        If Not IsPostBack Then
            Session("CrewRatingID") = 0
        End If

        If Not IsPostBack Then
            If Session("CoachIDGirls") > 0 And Session("CoachIDBoys") > 0 Then
                cboGender.Items.Add("Both")
                cboGender.SelectedIndex = 1
            ElseIf Session("CoachIDGirls") > 0 Then
                cboGender.Items.Add("Girls")
                cboGender.SelectedIndex = 1
            ElseIf Session("CoachIDBoys") > 0 Then
                cboGender.Items.Add("Boys")
                cboGender.SelectedIndex = 1
            End If
            If Session("AddEdit") Is Nothing Then
                Response.Redirect("BBMainMenu.aspx")
            ElseIf Session("AddEdit") = "EDIT" Then
                DoEdit()
            ElseIf Session("AddEdit") = "ADD" Then
                Me.txtGame.Text = Session("GameCount")
            Else
                Response.Redirect("BBMainMenu.aspx")
            End If
            ' Added... 11/5/2014...
            If Session("txtComments1") Is System.DBNull.Value Then
                Session("txtComments1") = ""
                Session("txtComments2") = ""
                Session("txtComments3") = ""
            End If
        End If

    End Sub


    Public Sub DoEdit()
        On Error Resume Next
        ' Load the week information...
        Dim intID As Integer = 0

        intID = Session("cboGame")

        If intID = 0 Then
            lblMessage.Text = "You must select a game."
            Response.Redirect("BBMainMenu.aspx")
        Else
            Dim ds As DataSet
            Dim strSQL As String
            strSQL = "SELECT * FROM tblOfficialsRatingByCoachesBB WHERE Id = " & intID

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else

                '                If CheckTime(ds.Tables(0).Rows(0).Item("dtmStamp")) <> "OK" Then
                '                Me.lblMessage.Text = "You cannot change a game 72 hours after it was created."
                '               Else

                ' Added... 11/5/2014...
                Session("txtComments1") = ""
                Session("txtComments2") = ""
                Session("txtComments3") = ""

                Me.lblMessage.Text = ""
                ClearFields()
                Me.txtGame.Enabled = False
                With ds.Tables(0).Rows(0)
                    Session("CrewRatingID") = .Item("Id")
                    Me.txtGame.Visible = True
                    Me.txtGame.Text = .Item("intGame")
                    Me.txtKey.Text = .Item("intGameKey")

                    Me.cboHomeAway.SelectedValue = .Item("strHomeAway")

                    ' Official #1...
                    Me.txtOSSAAID1.Text = .Item("intOfficialID1")
                    Me.lblOfficialName1.Text = .Item("strOfficialName1")
                    Me.rb1.SelectedValue = .Item("intOfficialRating1")
                    If .Item("strComments1") Is System.DBNull.Value Then
                        Session("txtComments1") = ""
                    Else
                        'If Me.rb1.SelectedValue = 5 Then
                        Session("txtComments1") = .Item("strComments1")
                        'Else
                        Me.txtComments1.Text = .Item("strComments1")
                        'End If
                    End If


            ' Official #2...
            Me.txtOSSAAID2.Text = .Item("intOfficialID2")
            Me.lblOfficialName2.Text = .Item("strOfficialName2")
            Me.rb2.SelectedValue = .Item("intOfficialRating2")
            If .Item("strComments2") Is System.DBNull.Value Then
                Session("txtComments2") = ""
            Else
                        'If rb2.SelectedValue = 5 Then
                        Session("txtComments2") = .Item("strComments2")
                        'Else
                        Me.txtComments2.Text = .Item("strComments2")
                        'End If
                    End If

            ' Official #3...
            Me.txtOSSAAID3.Text = .Item("intOfficialID3")
            Me.lblOfficialName3.Text = .Item("strOfficialName3")
            Me.rb3.SelectedValue = .Item("intOfficialRating3")
            If .Item("strComments3") Is System.DBNull.Value Then
                Session("txtComments3") = ""
            Else
                        'If rb3.SelectedValue = 5 Then
                        Session("txtComments3") = .Item("strComments3")
                        'Else
                        Me.txtComments3.Text = .Item("strComments3")
                        'End If
                    End If

            Me.cboGender.SelectedValue = .Item("strGender")
            Me.txtGameDate1.Text = .Item("strGameDate")

                End With
            End If
        End If

    End Sub

    Protected Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave.Click
        DoSave()
    End Sub

    Public Sub ClearFields()
        ''        Me.cboWeekNew.SelectedValue = 0
        Me.txtGame.Text = ""
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

        Me.cboHomeAway.SelectedIndex = 0
        Try
            Me.cboGender.SelectedValue = 0
        Catch
        End Try

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
                If Session("CoachIDGirls") > 0 And Session("CoachIDBoys") > 0 Then
                    strSQL = "SELECT Id FROM tblOfficialsRatingByCoachesBB WHERE intGameKey = " & Me.txtGame.Text & " And intCoachID = " & Session("CoachID")
                ElseIf Session("CoachIDGirls") > 0 Then
                    strSQL = "SELECT Id FROM tblOfficialsRatingByCoachesBB WHERE intGameKey = " & Me.txtGame.Text & " And intCoachID = " & Session("CoachIDGirls")
                Else
                    strSQL = "SELECT Id FROM tblOfficialsRatingByCoachesBB WHERE intGameKey = " & Me.txtGame.Text & " And intCoachID = " & Session("CoachIDBoys")
                End If
                intId = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                If intId > 0 Then
                    Me.lblMessage.Text = "Duplicate game."
                Else
                    strSQL = "INSERT INTO tblOfficialsRatingByCoachesBB (intSchoolID, schoolID, SchoolName, CoachName, intGameKey, intGame, "
                    strSQL = strSQL & "intOfficialID1, strOfficialName1, intOfficialRating1, strComments1, "
                    strSQL = strSQL & "intOfficialID2, strOfficialName2, intOfficialRating2, strComments2, "
                    If Me.txtOSSAAID3.Text = "" Then
                    Else
                        strSQL = strSQL & "intOfficialID3, strOfficialName3, intOfficialRating3, strComments3, "
                    End If
                    strSQL = strSQL & "strGender, "
                    strSQL = strSQL & "strGameDate, "
                    strSQL = strSQL & "strHomeAway, intCoachID, strSubmittedBy"

                    strSQL = strSQL & ") VALUES ("
                    strSQL = strSQL & Session("intSchoolID") & ", "
                    strSQL = strSQL & Session("SchoolID") & ", "
                    strSQL = strSQL & "'" & Session("SchoolName") & "', "
                    strSQL = strSQL & "'" & ParseString(Session("CoachName")) & "', "
                    strSQL = strSQL & Me.txtGame.Text & ", "
                    strSQL = strSQL & Me.txtGame.Text & ", "
                    ''strSQL = strSQL & SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT intWeek FROM tblOfficialsWeeksFootball WHERE intKey = " & Me.cboWeekNew.SelectedValue) & ", "

                    ' Official #1...
                    strSQL = strSQL & ParseString(Me.txtOSSAAID1.Text) & ", "
                    strSQL = strSQL & "'" & Me.lblOfficialName1.Text & "', "
                    strSQL = strSQL & Me.rb1.SelectedValue & ", "
                    If Me.txtComments1.Text Is Nothing Then
                        strSQL = strSQL & "'',"
                    Else
                        If rb1.SelectedValue = 5 Then
                            strSQL = strSQL & "'" & ParseString(Me.txtComments1.Text) & "', "
                        Else
                            strSQL = strSQL & "'',"
                        End If
                    End If

                        ' Official #2...
                    strSQL = strSQL & ParseString(Me.txtOSSAAID2.Text) & ", "
                        strSQL = strSQL & "'" & Me.lblOfficialName2.Text & "', "
                        strSQL = strSQL & Me.rb2.SelectedValue & ", "
                        If Me.txtComments2.Text Is Nothing Then
                            strSQL = strSQL & "'',"
                        Else
                            If rb2.SelectedValue = 5 Then
                            strSQL = strSQL & "'" & ParseString(Me.txtComments2.Text) & "', "
                        Else
                            strSQL = strSQL & "'',"
                        End If
                        End If

                        ' Official #3...
                        If Me.txtOSSAAID3.Text = "" Then
                        Else
                            strSQL = strSQL & ParseString(Me.txtOSSAAID3.Text) & ", "
                            strSQL = strSQL & "'" & Me.lblOfficialName3.Text & "', "
                            strSQL = strSQL & Me.rb3.SelectedValue & ", "
                            If Me.txtComments3.Text Is Nothing Then
                                strSQL = strSQL & "'',"
                            Else
                                If rb3.SelectedValue = 5 Then
                                strSQL = strSQL & "'" & ParseString(Me.txtComments3.Text) & "', "
                            Else
                                strSQL = strSQL & "'',"
                            End If
                        End If
                    End If

                        strSQL = strSQL & "'" & Me.cboGender.SelectedValue & "', "
                        strSQL = strSQL & "'" & Me.txtGameDate1.Text & "', "
                        strSQL = strSQL & "'" & Me.cboHomeAway.SelectedValue & "', "
                        If Session("CoachIDGirls") > 0 And Session("CoachIDBoys") > 0 Then
                            strSQL = strSQL & Session("CoachIDBoys") & ", "
                        ElseIf Session("CoachIDGirls") > 0 Then
                            strSQL = strSQL & Session("CoachIDGirls") & ", "
                        Else
                            strSQL = strSQL & Session("CoachIDBoys") & ", "
                        End If
                        strSQL = strSQL & "'" & Session("user") & "')"

                        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)


                    '''''Me.cboGame.DataBind()
                    Me.lblMessage.Text = "New Game Added."
                    '''''ClearFields()
                    Response.Redirect("BBMainMenu.aspx")
                End If
            Else
                strSQL = "UPDATE tblOfficialsRatingByCoachesBB SET "

                ' Official #1...
                strSQL = strSQL & "intOfficialID1 = " & ParseString(Me.txtOSSAAID1.Text) & ", "
                strSQL = strSQL & "strOfficialName1 = '" & ParseString(Me.lblOfficialName1.Text) & "', "
                strSQL = strSQL & "intOfficialRating1 = " & Me.rb1.SelectedValue & ", "
                If rb1.SelectedValue = 5 Then
                    If Me.txtComments1.Text = "" Then
                        If Session("txtComments1") = "" Then
                            strSQL = strSQL & "strComments1 = '', "
                        Else
                            strSQL = strSQL & "strComments1 = '" & ParseString(Session("txtComments1")) & "', "
                        End If
                    Else
                        strSQL = strSQL & "strComments1 = '" & ParseString(Me.txtComments1.Text) & "', "
                    End If
                End If

                ' Official #1...
                strSQL = strSQL & "intOfficialID2 = " & ParseString(Me.txtOSSAAID2.Text) & ", "
                strSQL = strSQL & "strOfficialName2 = '" & Me.lblOfficialName2.Text & "', "
                strSQL = strSQL & "intOfficialRating2 = " & Me.rb2.SelectedValue & ", "
                If rb2.SelectedValue = 5 Then
                    If Me.txtComments2.Text = "" Then
                        If Session("txtComments2") = "" Then
                            strSQL = strSQL & "strComments2 = '', "
                        Else
                            strSQL = strSQL & "strComments2 = '" & ParseString(Session("txtComments2")) & "', "
                        End If
                    Else
                        strSQL = strSQL & "strComments2 = '" & ParseString(Me.txtComments2.Text) & "', "
                    End If
                End If

                ' Official #3...
                If Me.txtOSSAAID3.Text = "" Then

                Else
                    strSQL = strSQL & "intOfficialID3 = " & ParseString(Me.txtOSSAAID3.Text) & ", "
                    strSQL = strSQL & "strOfficialName3 = '" & Me.lblOfficialName3.Text & "', "
                    strSQL = strSQL & "intOfficialRating3 = " & Me.rb3.SelectedValue & ", "
                    If rb3.SelectedValue = 5 Then
                        If Me.txtComments3.Text = "" Then
                            If Session("txtComments3") = "" Then
                                strSQL = strSQL & "strComments3 = '', "
                            Else
                                strSQL = strSQL & "strComments3 = '" & ParseString(Session("txtComments3")) & "', "
                            End If
                        Else
                            strSQL = strSQL & "strComments3 = '" & ParseString(Me.txtComments3.Text) & "', "
                        End If
                    End If
                End If

                strSQL = strSQL & "strGameDate = '" & Me.txtGameDate1.Text & "', "
                strSQL = strSQL & "dtmStampUpdate = '" & Now & "', "                    ' Added 11/5/2014...
                strSQL = strSQL & "strSubmittedBy = '" & Session("user") & "' "

                strSQL = strSQL & "WHERE Id = " & Session("CrewRatingID")

                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

                Me.lblMessage.Text = "Changes Saved."
                '''''ClearFields()

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

        If txtGame.Text = "" Then
            strReturn = "You must select a GAME."
        ElseIf Me.txtGameDate1.Text = Nothing Then
            strReturn = "You must select a GAME DATE."
        ElseIf Me.txtGameDate1.Text = "" Then
            strReturn = "You must select a GAME DATE."
        ElseIf Me.cboHomeAway.SelectedValue <> "H" And Me.cboHomeAway.SelectedValue <> "A" And Me.cboHomeAway.SelectedValue <> "N" Then
            strReturn = "You must select HOME or AWAY."
        ElseIf Me.txtOSSAAID1.Text = "" Then
            strReturn = "You must enter the OSSAA ID# for Official #1."
        ElseIf Me.txtOSSAAID2.Text = "" Then
            strReturn = "You must enter the OSSAA ID# for Official #2."
        ElseIf Me.txtOSSAAID3.Text <> "" And Me.rb3.SelectedValue = "" Then
            strReturn = "You must select a rating for Official #3."
        ElseIf Me.txtOSSAAID3.Text <> "" And Me.rb3.SelectedValue = "5" And Me.txtComments3.Text = "" And Session("txtComments3") = "" Then
            strReturn = "You must enter a Comment for Official #3 (POOR rating)."
        ElseIf Me.rb1.SelectedValue = "" Then
            strReturn = "You must select a rating for Official #1."
        ElseIf Me.rb2.SelectedValue = "" Then
            strReturn = "You must select a rating for Official #2."
        ElseIf Me.rb1.SelectedValue = "5" And Me.txtComments1.Text = "" And Session("txtComments1") = "" Then
            strReturn = "You must enter a Comment for Official #1 (POOR rating)."
        ElseIf Me.rb2.SelectedValue = "5" And Me.txtComments2.Text = "" And Session("txtComments2") = "" Then
            strReturn = "You must enter a Comment for Official #2 (POOR rating)."
        ElseIf Me.lblOfficialName1.Text = gInvalidName And Me.txtComments1.Text = "" Then
            strReturn = "You must enter a Comment for Official #1 (INVALID OSSAAID#)."
        ElseIf Me.lblOfficialName2.Text = gInvalidName And Me.txtComments2.Text = "" Then
            strReturn = "You must enter a Comment for Official #2 (INVALID OSSAAID#)."
        ElseIf Me.cboGender.SelectedValue <> "Both" And Me.cboGender.SelectedValue <> "Boys" And Me.cboGender.SelectedValue <> "Girls" Then
            strReturn = "You must select a Gender."
        Else
            strReturn = "OK"
        End If
        Return strReturn
    End Function

    Public Function IsEligibleOfficialBasketball(ByVal intOfficialID As Long) As String
        Dim strReturn As String = "FAILED (5)"
        Dim strSQL As String

        strSQL = "SELECT strFirstName + ' ' + strLastName FROM prodOfficials WHERE ([ysnCurrentBasketball] = -1) And (intTestBasketball >= " & ConfigurationManager.AppSettings("GetOfficialsPassingScore") & ") And (intOSSAAID = " & intOfficialID & ")"

        Try
            strReturn = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        Catch
            strReturn = "FAILED (6)"
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
                strFirstLast = IsEligibleOfficialBasketball(CLng(Me.txtOSSAAID1.Text))
            Catch
                strFirstLast = "FAILED (7)"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblMessage.Text = gInvalidMessage
                Me.lblOfficialName1.Text = gInvalidName
            ElseIf strFirstLast.Contains("FAILED") Then
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
                strFirstLast = IsEligibleOfficialBasketball(CLng(Me.txtOSSAAID2.Text))
            Catch
                strFirstLast = "FAILED (9)"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblMessage.Text = gInvalidMessage
                Me.lblOfficialName2.Text = gInvalidName
            ElseIf strFirstLast.Contains("FAILED") Then
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
                strFirstLast = IsEligibleOfficialBasketball(CLng(Me.txtOSSAAID3.Text))
            Catch
                strFirstLast = "FAILED (10)"
            End Try
            If strFirstLast Is Nothing Then
                Me.lblMessage.Text = gInvalidMessage
                Me.lblOfficialName3.Text = gInvalidName
            ElseIf strFirstLast.Contains("FAILED") Then
                Me.lblMessage.Text = gInvalidMessage
                Me.lblOfficialName3.Text = gInvalidName
            Else
                Me.lblMessage.Text = ""
                Me.lblOfficialName3.Text = strFirstLast
            End If
        End If
    End Sub


    Protected Sub cmdBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBack.Click
        Response.Redirect("~/Officials/BBMainMenu.aspx")
    End Sub
End Class