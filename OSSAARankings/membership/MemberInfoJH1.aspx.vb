Public Class MemberInfoJH1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Session("usertype") = "OSSAA" Or Session("usertype") = "OSSAAADMIN" Then
                Me.cmdClearAndSave.Visible = True
            Else
                Me.cmdClearAndSave.Visible = False
            End If
        End If

        If Session("user") = "" Then
            Response.Redirect("MemberLogin.aspx")
        End If

        If Session("confirmed") = 0 Then
            If Session("usertype") = "SUPER" Then
                Response.Redirect("MemberInfoSup.aspx")
            ElseIf Session("usertype") = "PRINCIPAL" Then
                Response.Redirect("MemberInfoPrin.aspx")
            ElseIf Session("usertype") = "AD" Then
                Response.Redirect("MemberInfoAD.aspx")
            End If
        End If

        Me.lblStep.Text = "Junior High #1 Principal's Info - " & Session("school")
        Me.lblTitle.Text = "Please enter your school's Junior High #1 Principal's information..."

        ' Load the data...
        If Not IsPostBack Then
            Dim strSQL As String
            strSQL = "SELECT AdminJH1MrMs, AdminJH1First, AdminJH1Last, AdminJH1MailingAddress, AdminJH1PhoneSchool, AdminJH1PhoneSchoolExt, AdminJH1PhoneCell, AdminJH1PhoneFax, AdminJH1Email, MailingCity, MailingState, MailingZip, AdminJH1SchoolName, "
            strSQL = strSQL & "AdminJH1Type, AdminJH1GradeFrom, AdminJH1GradeTo, intSchoolID "
            strSQL = strSQL & "FROM tblSchool WHERE Id = " & Session("key")
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                ' Load it!...
            End If
            With ds.Tables(0).Rows(0)
                If Not .Item("AdminJH1MrMs") Is System.DBNull.Value Then
                    cboMrMsSup.SelectedValue = .Item("AdminJH1MrMs")
                End If
                If Not .Item("AdminJH1SchoolName") Is System.DBNull.Value Then
                    txtSchoolName.Text = .Item("AdminJH1SchoolName")
                End If
                If Not .Item("AdminJH1First") Is System.DBNull.Value Then
                    txtFirstNameSup.Text = .Item("AdminJH1First")
                End If
                If Not .Item("AdminJH1Last") Is System.DBNull.Value Then
                    txtLastNameSup.Text = .Item("AdminJH1Last")
                End If
                If Not .Item("AdminJH1MailingAddress") Is System.DBNull.Value Then
                    txtMailingAddressSup.Text = .Item("AdminJH1MailingAddress")
                End If
                If Not .Item("AdminJH1PhoneSchool") Is System.DBNull.Value Then
                    txtSchoolPhoneSup.Text = .Item("AdminJH1PhoneSchool")
                End If
                If Not .Item("AdminJH1PhoneSchoolExt") Is System.DBNull.Value Then
                    txtSchoolPhoneSupExt.Text = .Item("AdminJH1PhoneSchoolExt")
                End If
                If Not .Item("AdminJH1PhoneCell") Is System.DBNull.Value Then
                    txtCellSup.Text = .Item("AdminJH1PhoneCell")
                End If
                If Not .Item("AdminJH1PhoneFax") Is System.DBNull.Value Then
                    txtSchoolFaxSup.Text = .Item("AdminJH1PhoneFax")
                End If
                If Not .Item("AdminJH1Email") Is System.DBNull.Value Then
                    txtSchoolEmailSup.Text = .Item("AdminJH1Email")
                End If
                If Not .Item("MailingCity") Is System.DBNull.Value Then
                    txtMailingCitySup.Text = .Item("MailingCity")
                End If
                If Not .Item("MailingState") Is System.DBNull.Value Then
                    txtMailingStateSup.Text = .Item("MailingState")
                End If
                If Not .Item("MailingZip") Is System.DBNull.Value Then
                    txtMailingZipSup.Text = .Item("MailingZip")
                End If
                If Not .Item("AdminJH1Type") Is System.DBNull.Value Then
                    cboSchoolType.SelectedValue = .Item("AdminJH1Type")
                End If
                If Not .Item("AdminJH1GradeFrom") Is System.DBNull.Value Then
                    cboGradeFrom.SelectedValue = .Item("AdminJH1GradeFrom")
                End If
                If Not .Item("AdminJH1GradeTo") Is System.DBNull.Value Then
                    cboGradeTo.SelectedValue = .Item("AdminJH1GradeTo")
                End If
                Session("intSchoolID") = .Item("intSchoolID")
            End With
        End If

        If Not IsPostBack Then
            Me.lblCopyright.Text = clsMembership.GetCopyright
        End If

    End Sub

    Protected Sub cmdSaveChanges_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSaveChanges.Click
        Dim strSQL As New StringBuilder
        Dim strSQLInsert As New StringBuilder

        Dim strMrMs As String = Me.cboMrMsSup.SelectedValue
        If strMrMs = "Select..." Then strMrMs = "Mr"

        ' APPEND query...
        Dim intID As Integer = 0

        strSQLInsert.Append("INSERT INTO tblSchoolSync ")
        strSQLInsert.Append("(AdminJH1MrMs, AdminJH1SchoolName, AdminJH1First, AdminJH1Last, AdminJH1MailingAddress, ")
        strSQLInsert.Append("AdminJH1PhoneSchool, ")
        strSQLInsert.Append("AdminJH1PhoneSchoolExt, AdminJH1PhoneCell, AdminJH1PhoneFax, AdminJH1Email, ")
        strSQLInsert.Append("MailingCity, MailingState, MailingZip, dtmStampJH1, ")
        strSQLInsert.Append("AdminJH1Type, AdminJH1GradeFrom, AdminJH1GradeTo, ")
        strSQLInsert.Append("intSync6, dtmSync, intSchoolID, strChangedBy, strUserType")

        strSQLInsert.Append(") VALUES (")

        strSQLInsert.Append("'" & strMrMs & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolName.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtFirstNameSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtLastNameSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtMailingAddressSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolPhoneSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolPhoneSupExt.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtCellSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolFaxSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolEmailSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtMailingCitySup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtMailingStateSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtMailingZipSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Now & "', ")
        strSQLInsert.Append("'" & Me.cboSchoolType.SelectedValue.ToString & "', ")
        strSQLInsert.Append("'" & Me.cboGradeFrom.SelectedValue.ToString & "', ")
        strSQLInsert.Append("'" & Me.cboGradeTo.SelectedValue.ToString & "', ")
        strSQLInsert.Append("1, ")

        strSQLInsert.Append("'" & Now & "', ")
        Try
            intID = Session("intSchoolID")
        Catch
            intID = 0
        End Try
        strSQLInsert.Append(intID & ", ")
        strSQLInsert.Append("'" & Session("user") & "', ")
        strSQLInsert.Append("'" & Session("usertype") & "'")
        strSQLInsert.Append(")")

        ' UPDATE query...
        strSQL.Append("UPDATE tblSchool SET AdminJH1MrMs = '" & strMrMs & "' ")
        strSQL.Append(", AdminJH1SchoolName = '" & Replace(Me.txtSchoolName.Text, "'", "") & "'")
        strSQL.Append(", AdminJH1First = '" & Replace(Me.txtFirstNameSup.Text, "'", "") & "' ")
        strSQL.Append(", AdminJH1Last = '" & Replace(Me.txtLastNameSup.Text, "'", "") & "' ")
        strSQL.Append(", AdminJH1MailingAddress = '" & Replace(Me.txtMailingAddressSup.Text, "'", "") & "' ")
        strSQL.Append(", AdminJH1PhoneSchool = '" & Replace(Me.txtSchoolPhoneSup.Text, "'", "") & "' ")
        strSQL.Append(", AdminJH1PhoneSchoolExt = '" & Replace(Me.txtSchoolPhoneSupExt.Text, "'", "") & "' ")

        strSQL.Append(", AdminJH1PhoneCell = '" & Replace(Me.txtCellSup.Text, "'", "") & "' ")
        strSQL.Append(", AdminJH1PhoneFax = '" & Replace(Me.txtSchoolFaxSup.Text, "'", "") & "' ")
        strSQL.Append(", AdminJH1Email = '" & Replace(Me.txtSchoolEmailSup.Text, "'", "") & "' ")
        strSQL.Append(", MailingCity = '" & Replace(Me.txtMailingCitySup.Text, "'", "") & "' ")
        strSQL.Append(", MailingState = '" & Replace(Me.txtMailingStateSup.Text, "'", "") & "' ")
        strSQL.Append(", MailingZip = '" & Replace(Me.txtMailingZipSup.Text, "'", "") & "'")

        strSQL.Append(", AdminJH1Type = '" & Me.cboSchoolType.SelectedValue.ToString & "'")
        strSQL.Append(", AdminJH1GradeFrom = '" & Me.cboGradeFrom.SelectedValue.ToString & "'")
        strSQL.Append(", AdminJH1GradeTo = '" & Me.cboGradeTo.SelectedValue.ToString & "'")

        strSQL.Append(", dtmStampJH1 = '" & Now & "'")

        strSQL.Append(" WHERE Id = " & Session("key"))

        ' Save the data...
        Try
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL.ToString)
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQLInsert.ToString)
            Me.lblMessage.Text = "Changes saved."
        Catch
            Me.lblMessage.Text = "Change failed."
        End Try

    End Sub

    Private Sub MemberInfoJH1_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Session("usertype") = "SUPER" Then
            Me.MasterPageFile = "SiteMembership.Master"
        ElseIf Session("usertype") = "PRINCIPAL" Then
            Me.MasterPageFile = "SiteP.Master"
        ElseIf Session("usertype") = "AD" Then
            Me.MasterPageFile = "SiteAD.Master"
        ElseIf Session("usertype") = "OSSAA" Or Session("usertype") = "OSSAAADMIN" Then
            Me.MasterPageFile = "SiteOSSAAAdmin.Master"
        Else
            Response.Redirect("MemberLogin.aspx")
        End If
    End Sub

    Protected Sub cmdCancelChanges_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelChanges.Click
        Response.Redirect("MemberHome.aspx")
    End Sub
End Class