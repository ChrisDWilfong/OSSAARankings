Imports System.Data.SqlClient

Partial Class RatingsBK
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Request.QueryString("sub") = 1 Then
                RadAjaxManager1.Alert("You Ratings have been submitted to the OSSAA.  Thank you.")
            End If
        End If

    End Sub

    Private Sub RadDropDownListYouAreA_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.DropDownListEventArgs) Handles RadDropDownListYouAreA.SelectedIndexChanged
        CheckRadDropDownListYouAreA(sender)
    End Sub

    Public Sub CheckRadDropDownListYouAreA(sender As Object)
        Dim strSQL As String = ""
        Dim ds As DataSet
        Dim objItem As New Telerik.Web.UI.DropDownListItem

        Select Case sender.SelectedValue
            Case "FAN"
                ' Load the Types DropDown...
                strSQL = "SELECT * FROM tblOfficialsRatingsBKTypes WHERE strType = 'FAN' ORDER BY intSort"
                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                RadDropDownListYouAreASub.DataSource = ds
                RadDropDownListYouAreASub.DataBind()
                objItem.Value = ""
                objItem.Text = "Select..."
                RadDropDownListYouAreASub.Items.Insert(0, objItem)
                rowYouAreASub.Visible = True
            Case "ADMINISTRATOR"
                ' Load the Types DropDown...
                strSQL = "SELECT * FROM tblOfficialsRatingsBKTypes WHERE strType = 'ADMINISTRATOR' ORDER BY intSort"
                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                RadDropDownListYouAreASub.DataSource = ds
                RadDropDownListYouAreASub.DataBind()
                objItem.Value = ""
                objItem.Text = "Select..."
                RadDropDownListYouAreASub.Items.Insert(0, objItem)
                rowYouAreASub.Visible = True
            Case "OBSERVER", "ASSIGNOR"
                rowYouAreASub.Visible = False
                tblPersonalInfo.Visible = True
                tblGameInfo.Visible = True
                tblOfficialsInfo.Visible = False
                tblOfficialsInfo1.Visible = True
                tblButtons.Visible = True
                rowSchoolOSSAAID.Visible = True
                cellOSSAAID.Visible = True
                cellSchool.Visible = False
            Case "OFFICIAL"
                ' Load the Types DropDown...
                strSQL = "SELECT * FROM tblOfficialsRatingsBKTypes WHERE strType = 'OFFICIAL' ORDER BY intSort"
                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
                RadDropDownListYouAreASub.DataSource = ds
                RadDropDownListYouAreASub.DataBind()
                objItem.Value = ""
                objItem.Text = "Select..."
                RadDropDownListYouAreASub.Items.Insert(0, objItem)
                rowYouAreASub.Visible = True
            Case Else
                rowYouAreASub.Visible = False
                tblPersonalInfo.Visible = False
                rowSchoolOSSAAID.Visible = False
                cellOSSAAID.Visible = False
                cellSchool.Visible = False
        End Select
    End Sub


    Private Sub RadDropDownListYouAreASub_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.DropDownListEventArgs) Handles RadDropDownListYouAreASub.SelectedIndexChanged
        CheckRadDropDownListYouAreASub()
    End Sub

    Public Sub CheckRadDropDownListYouAreASub()

        Select Case RadDropDownListYouAreA.SelectedValue
            Case "FAN"
                tblPersonalInfo.Visible = True
                rowSchoolOSSAAID.Visible = True
                cellOSSAAID.Visible = False
                cellSchool.Visible = True

                tblGameInfo.Visible = True
                tblOfficialsInfo.Visible = True
                tblOfficialsInfo1.Visible = False
                tblButtons.Visible = True

            Case "ADMINISTRATOR"
                tblPersonalInfo.Visible = True
                rowSchoolOSSAAID.Visible = True
                cellOSSAAID.Visible = False
                cellSchool.Visible = True

                tblGameInfo.Visible = True
                tblOfficialsInfo.Visible = True
                tblOfficialsInfo1.Visible = False
                tblButtons.Visible = True

            Case "OBSERVER", "ASSIGNOR", "OFFICIAL"
                tblPersonalInfo.Visible = True
                rowSchoolOSSAAID.Visible = True
                cellOSSAAID.Visible = True
                cellSchool.Visible = False

                tblGameInfo.Visible = True
                tblOfficialsInfo.Visible = False
                tblOfficialsInfo1.Visible = True
                tblButtons.Visible = True

            Case Else
                tblPersonalInfo.Visible = False
                rowSchoolOSSAAID.Visible = False
                cellOSSAAID.Visible = False
                cellSchool.Visible = False
                tblGameInfo.Visible = False
                tblOfficialsInfo.Visible = False
                tblOfficialsInfo1.Visible = False
                tblButtons.Visible = False
        End Select

    End Sub

    'Public Function VerifyPersonalInfo() As String
    '    Dim strResult As String = "OK"

    '    If txtName.Text = "" Or txtEmail.Text = "" Then
    '        strResult = "Name and Email are required."
    '    End If

    '    Return strResult

    'End Function


    'Public Function VerifyGameInfo() As String
    '    Dim strResult As String = "OK"

    '    If RadDatePickerGameDate.SelectedDate Is Nothing Then
    '        strResult = "Game date is required."
    '    ElseIf txtAwayTeam.Text = "" Then
    '        strResult = "Visiting Team is required."
    '    ElseIf txtHomeTeam.Text = "" Then
    '        strResult = "Home Team is required."
    '    Else
    '        strResult = "OK"
    '    End If

    '    Return strResult

    'End Function

    'Private Sub txtName_TextChanged(sender As Object, e As System.EventArgs) Handles txtName.TextChanged
    '    If VerifyPersonalInfo() = "OK" Then
    '        tblGameInfo.Visible = True
    '    Else
    '        lblMessage.Text = "Name and Email are required."
    '    End If
    'End Sub

    'Private Sub txtEmail_TextChanged(sender As Object, e As System.EventArgs) Handles txtEmail.TextChanged
    '    If VerifyPersonalInfo() = "OK" Then
    '        tblGameInfo.Visible = True
    '    Else
    '        lblMessage.Text = "Name and Email are required."
    '    End If
    'End Sub


    'Private Sub RadDatePickerGameDate_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerGameDate.SelectedDateChanged

    '    If txtAwayTeam.Text = "" Then
    '        ' Do nothing, move on...
    '    ElseIf txtHomeTeam.Text = "" Then
    '        ' Do nothing, move on...
    '    Else
    '        Dim strOK As String = VerifyGameInfo()
    '        If strOK = "OK" Then
    '            Select Case RadDropDownListYouAreA.SelectedValue
    '                Case "FAN", "ADMINISTRATOR"
    '                    tblOfficialsInfo.Visible = True
    '                    tblOfficialsInfo1.Visible = False
    '                    tblButtons.Visible = True
    '                Case "OFFICIAL", "OBSERVER", "ASSIGNOR"
    '                    tblOfficialsInfo1.Visible = True
    '                    tblOfficialsInfo.Visible = False
    '                    tblButtons.Visible = True
    '                Case Else
    '                    tblOfficialsInfo1.Visible = False
    '                    tblOfficialsInfo.Visible = False
    '                    tblButtons.Visible = False
    '            End Select
    '        Else
    '            lblMessage.Text = strOK
    '        End If
    '    End If

    'End Sub

    'Private Sub txtHomeTeam_TextChanged(sender As Object, e As System.EventArgs) Handles txtHomeTeam.TextChanged

    '    If txtAwayTeam.Text = "" Then
    '        ' Do nothing, move on...
    '    ElseIf RadDatePickerGameDate.SelectedDate Is Nothing Then
    '        ' Do nothing, move on...
    '    Else
    '        Dim strOK As String = VerifyGameInfo()
    '        If strOK = "OK" Then
    '            Select Case RadDropDownListYouAreA.SelectedValue
    '                Case "FAN", "ADMINISTRATOR"
    '                    tblOfficialsInfo.Visible = True
    '                    tblOfficialsInfo1.Visible = False
    '                    tblButtons.Visible = True
    '                Case "OBSERVER", "ASSIGNOR", "OFFICIAL"
    '                    tblOfficialsInfo1.Visible = True
    '                    tblOfficialsInfo.Visible = False
    '                    tblButtons.Visible = True
    '                Case Else
    '                    tblOfficialsInfo1.Visible = False
    '                    tblOfficialsInfo.Visible = False
    '                    tblButtons.Visible = False
    '            End Select
    '        Else
    '            lblMessage.Text = strOK
    '        End If
    '    End If

    'End Sub

    'Private Sub txtAwayTeam_TextChanged(sender As Object, e As System.EventArgs) Handles txtAwayTeam.TextChanged

    '    If txtHomeTeam.Text = "" Then
    '        ' Do nothing, move on...
    '    ElseIf RadDatePickerGameDate.SelectedDate Is Nothing Then
    '        ' Do nothing, move on...
    '    Else
    '        Dim strOK As String = VerifyGameInfo()
    '        If strOK = "OK" Then
    '            Select Case RadDropDownListYouAreA.SelectedValue
    '                Case "FAN", "ADMINISTRATOR", "OFFICIAL"
    '                    tblOfficialsInfo.Visible = True
    '                    tblOfficialsInfo1.Visible = False
    '                    tblButtons.Visible = True
    '                Case "OBSERVER", "ASSIGNOR", "OFFICIAL"
    '                    tblOfficialsInfo1.Visible = True
    '                    tblOfficialsInfo.Visible = False
    '                    tblButtons.Visible = True
    '                Case Else
    '                    tblOfficialsInfo1.Visible = False
    '                    tblOfficialsInfo.Visible = False
    '                    tblButtons.Visible = True
    '            End Select
    '        Else
    '            lblMessage.Text = strOK
    '        End If
    '    End If

    'End Sub

    Public Function VerifySave() As String
        Dim strReturn As String = "OK"

        If txtName.Text = "" Then
            strReturn = "<strong><span style='font-size:18px;'>You must select your NAME.</span></strong>"
        ElseIf txtEmail.Text = "" Then
            strReturn = "<strong><span style='font-size:18px;'>You must enter your EMAIL.</span></strong>"
        ElseIf txtOSSAAID.Visible And txtOSSAAID.Text = "" Then
            strReturn = "<strong><span style='font-size:18px;'>You must enter your OSSAAID.</span></strong>"
        ElseIf RadDatePickerGameDate.Visible And RadDatePickerGameDate.SelectedDate.ToString = "" Then
            strReturn = "<strong><span style='font-size:18px;'>You must select a GAME DATE.</span></strong>"
        ElseIf txtHomeTeam.Visible And txtHomeTeam.Text = "" Then
            strReturn = "<strong><span style='font-size:18px;'>You must enter a HOME TEAM.</span></strong>"
        ElseIf txtAwayTeam.Visible And txtAwayTeam.Text = "" Then
            strReturn = "<strong><span style='font-size:18px;'>You must enter an AWAY TEAM.</span></strong>"
        ElseIf txtOfficial1.Visible And txtOfficial1.Text = "" Then
            strReturn = "<strong><span style='font-size:18px;'>You must enter an OFFICIALS NAME 1.</span></strong>"
        ElseIf txtOSSAAID1.Visible And txtOSSAAID1.Text = "" Then
            strReturn = "<strong><span style='font-size:18px;'>You must enter an OSSAA ID# for OFFICIAL 1.</span></strong>"
        ElseIf txtOfficial2.Visible And txtOfficial2.Text = "" Then
            strReturn = "<strong><span style='font-size:18px;'>You must enter an OFFICIALS NAME 2.</span></strong>"
        ElseIf txtOSSAAID2.Visible And txtOSSAAID2.Text = "" Then
            strReturn = "<strong><span style='font-size:18px;'>You must enter an OSSAA ID# for OFFICIAL 2.</span></strong>"
        ElseIf txtOfficialsNames.Visible And txtOfficialsNames.Text = "" Then
            strReturn = "<strong><span style='font-size:18px;'>You must enter the OFFICIALS NAME(s).</span></strong>"
        ElseIf txtFeedback.Visible And txtFeedback.Text = "" Then
            strReturn = "<strong><span style='font-size:18px;'>You must enter FEEDBACK.</span></strong>"
        ElseIf RadRatingOfficials.Visible And RadRatingOfficials.Value < 1 Then
            strReturn = "<strong><span style='font-size:18px;'>You must select an OFFICIALS RATING.</span></strong>"
        ElseIf RadRatingOfficial1.Visible And RadRatingOfficial1.Value < 1 Then
            strReturn = "<strong><span style='font-size:18px;'>You must select an OFFICIALS 1 RATING.</span></strong>"
        ElseIf RadRatingOfficial2.Visible And RadRatingOfficial2.Value < 1 Then
            strReturn = "<strong><span style='font-size:18px;'>You must select an OFFICIALS 2 RATING.</span></strong>"
        ElseIf RadRatingOfficial3.Visible And txtOfficial3.Text <> "" And RadRatingOfficial3.Value < 1 Then
            strReturn = "<strong><span style='font-size:18px;'>You must select an OFFICIALS 3 RATING.</span></strong>"
        End If

        Return strReturn
    End Function

    Private Sub RadButtonSave_Click(sender As Object, e As System.EventArgs) Handles RadButtonSave.Click
        Dim strVerify As String = "OK"
        Dim strSQL As String = ""

        strVerify = VerifySave()

        If strVerify = "OK" Then
            ' SAVE THE DATA...
            strSQL = SaveData()

            ' SEND EMAIL...
            Dim strSubject As String = ""
            strSubject = RadDropDownListYouAreA.SelectedText
            If RadDropDownListYouAreASub.Visible Then
                strSubject = strSubject & " - " & RadDropDownListYouAreASub.SelectedText
            End If
            strSubject = strSubject & " - " & txtName.Text

            ' CDW changed 3/5/2019...
            '''''clsEmail.SendEmail(sender, strSQL, "cwilfong@ossaa.com", "postmaster@ossaa.com", strSubject)
            clsEmail.SendEmailNew("cwilfong@ossaa.com", "", strSubject, strSQL, False, "")

            ' REDIRECT...
            Response.Redirect("RatingsBK.aspx?sub=1")

        Else
            lblMessage.Text = strVerify
        End If

    End Sub

    Public Function SaveData() As String
        Dim strFields As String = ""
        Dim strValues As String = ""
        Dim strSQL As String = ""

        strSQL = "INSERT INTO tblOfficialsRatingsBK "

        strFields = "strType, "
        strValues = "'" & RadDropDownListYouAreA.SelectedValue & "', "

        If RadDropDownListYouAreASub.Visible Then
            strFields = strFields & "strTypeSub, "
            strValues = strValues & "'" & RadDropDownListYouAreASub.SelectedValue & "', "
        End If

        strFields = strFields & "strName, "
        strValues = strValues & "'" & StripString(txtName.Text) & "', "

        If txtOSSAAID.Visible = True Then
            strFields = strFields & "intOSSAAID, "
            Try
                strValues = strValues & CLng(Me.txtOSSAAID.Text) & ", "
            Catch
                strValues = strValues & "-1, "
            End Try
        End If

        strFields = strFields & "strEmail, "
        strValues = strValues & "'" & StripString(txtEmail.Text) & "', "

        If txtSchool.Visible = True Then
            strFields = strFields & "strSchool, "
            strValues = strValues & "'" & StripString(txtSchool.Text) & "', "
        End If

        strFields = strFields & "dtmGameDate, "
        strValues = strValues & "'" & RadDatePickerGameDate.SelectedDate & "', "

        strFields = strFields & "strGameHomeTeam, "
        strValues = strValues & "'" & StripString(txtHomeTeam.Text) & "', "

        strFields = strFields & "strGameAwayTeam, "
        strValues = strValues & "'" & StripString(txtAwayTeam.Text) & "', "

        If txtOfficialsNames.Visible Then
            strFields = strFields & "strOfficialsNames, "
            strValues = strValues & "'" & StripString(txtOfficialsNames.Text) & "', "
        End If

        If txtOfficial1.Visible Then
            strFields = strFields & "strOfficialName1, "
            strValues = strValues & "'" & StripString(txtOfficial1.Text) & "', "
        End If

        If txtOfficial2.Visible Then
            strFields = strFields & "strOfficialName2, "
            strValues = strValues & "'" & StripString(txtOfficial2.Text) & "', "
        End If

        If txtOfficial3.Visible Then
            strFields = strFields & "strOfficialName3, "
            strValues = strValues & "'" & StripString(txtOfficial3.Text) & "', "
        End If

        If txtOSSAAID1.Visible = True Then
            strFields = strFields & "intOfficialOSSAAID1, "
            Try
                strValues = strValues & CLng(Me.txtOSSAAID1.Text) & ", "
            Catch
                strValues = strValues & "-1, "
            End Try
        End If

        If txtOSSAAID2.Visible = True Then
            strFields = strFields & "intOfficialOSSAAID2, "
            Try
                strValues = strValues & CLng(Me.txtOSSAAID2.Text) & ", "
            Catch
                strValues = strValues & "-1, "
            End Try
        End If

        If txtOSSAAID3.Visible = True Then
            strFields = strFields & "intOfficialOSSAAID3, "
            Try
                strValues = strValues & CLng(Me.txtOSSAAID3.Text) & ", "
            Catch
                strValues = strValues & "-1, "
            End Try
        End If

        If RadRatingOfficials.Visible Then
            strFields = strFields & "intOfficialsRating, "
            strValues = strValues & RadRatingOfficials.Value & ", "
        End If

        If RadRatingOfficial1.Visible Then
            strFields = strFields & "intOfficialRating1, "
            strValues = strValues & RadRatingOfficial1.Value & ", "
        End If

        If RadRatingOfficial2.Visible Then
            strFields = strFields & "intOfficialRating2, "
            strValues = strValues & RadRatingOfficial2.Value & ", "
        End If

        If RadRatingOfficial3.Visible Then
            strFields = strFields & "intOfficialRating3, "
            strValues = strValues & RadRatingOfficial3.Value & ", "
        End If

        If txtFeedback1.Visible Then
            strFields = strFields & "memNote, "
            strValues = strValues & "'" & SqlHelper.StripString(txtFeedback1.Text) & "', "
        ElseIf txtFeedback.Visible Then
            strFields = strFields & "memNote, "
            strValues = strValues & "'" & SqlHelper.StripString(txtFeedback.Text) & "', "
        End If

        strFields = strFields & "dtmStamp "
        strValues = strValues & "'" & Now & "' "

        strSQL = strSQL & " (" & strFields & ") VALUES (" & strValues & ")"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        Return strSQL

    End Function

    Public Function StripString(strIn As String) As String
        Dim strOut As String = ""

        strOut = strIn.Replace("'", "")
        strOut = strOut.Replace("DELETE FROM", "*delete*")
        strOut = strOut.Replace(".exe", "*exe*")
        strOut = strOut.Replace(".js", "*js*")
        strOut = strOut.Replace("INSERT INTO", "*insert*'")

        Return strOut
    End Function

End Class