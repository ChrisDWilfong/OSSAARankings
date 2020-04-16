Public Class MemberInfoJH2
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

        Me.lblStep.Text = "Junior High #2 Principal's Info - " & Session("school")
        Me.lblTitle.Text = "Please enter your school's Junior High #2 Principal's information..."

        ' Load the data...
        If Not IsPostBack Then
            Dim strSQL As String
            strSQL = "SELECT AdminJH2MrMs, AdminJH2First, AdminJH2Last, AdminJH2MailingAddress, AdminJH2PhoneSchool, AdminJH2PhoneSchoolExt, AdminJH2PhoneCell, AdminJH2PhoneFax, AdminJH2Email, MailingCity, MailingState, MailingZip, AdminJH2SchoolName, "
            strSQL = strSQL & "AdminJH2Type, AdminJH2GradeFrom, AdminJH2GradeTo, intSchoolID "
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
                If Not .Item("AdminJH2SchoolName") Is System.DBNull.Value Then
                    txtSchoolName.Text = .Item("AdminJH2SchoolName")
                End If
                If Not .Item("AdminJH2MrMs") Is System.DBNull.Value Then
                    cboMrMsSup.SelectedValue = .Item("AdminJH2MrMs")
                End If
                If Not .Item("AdminJH2First") Is System.DBNull.Value Then
                    txtFirstNameSup.Text = .Item("AdminJH2First")
                End If
                If Not .Item("AdminJH2Last") Is System.DBNull.Value Then
                    txtLastNameSup.Text = .Item("AdminJH2Last")
                End If
                If Not .Item("AdminJH2MailingAddress") Is System.DBNull.Value Then
                    txtMailingAddressSup.Text = .Item("AdminJH2MailingAddress")
                End If
                If Not .Item("AdminJH2PhoneSchool") Is System.DBNull.Value Then
                    txtSchoolPhoneSup.Text = .Item("AdminJH2PhoneSchool")
                End If
                If Not .Item("AdminJH2PhoneSchoolExt") Is System.DBNull.Value Then
                    txtSchoolPhoneSupExt.Text = .Item("AdminJH2PhoneSchoolExt")
                End If
                If Not .Item("AdminJH2PhoneCell") Is System.DBNull.Value Then
                    txtCellSup.Text = .Item("AdminJH2PhoneCell")
                End If
                If Not .Item("AdminJH2PhoneFax") Is System.DBNull.Value Then
                    txtSchoolFaxSup.Text = .Item("AdminJH2PhoneFax")
                End If
                If Not .Item("AdminJH2Email") Is System.DBNull.Value Then
                    txtSchoolEmailSup.Text = .Item("AdminJH2Email")
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
                If Not .Item("AdminJH2Type") Is System.DBNull.Value Then
                    cboSchoolType.SelectedValue = .Item("AdminJH2Type")
                End If
                If Not .Item("AdminJH2GradeFrom") Is System.DBNull.Value Then
                    cboGradeFrom.SelectedValue = .Item("AdminJH2GradeFrom")
                End If
                If Not .Item("AdminJH2GradeTo") Is System.DBNull.Value Then
                    cboGradeTo.SelectedValue = .Item("AdminJH2GradeTo")
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
        strSQLInsert.Append("(AdminJH2MrMs, AdminJH2SchoolName, AdminJH2First, AdminJH2Last, AdminJH2MailingAddress, ")
        strSQLInsert.Append("AdminJH2PhoneSchool, ")
        strSQLInsert.Append("AdminJH2PhoneSchoolExt, AdminJH2PhoneCell, AdminJH2PhoneFax, AdminJH2Email, ")
        strSQLInsert.Append("MailingCity, MailingState, MailingZip, dtmStampJH2, ")
        strSQLInsert.Append("AdminJH2Type, AdminJH2GradeFrom, AdminJH2GradeTo, ")
        strSQLInsert.Append("intSync7, dtmSync, intSchoolID, strChangedBy, strUserType")

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
        strSQL.Append("UPDATE tblSchool SET AdminJH2MrMs = '" & strMrMs & "' ")
        strSQL.Append(", AdminJH2SchoolName = '" & Replace(Me.txtSchoolName.Text, "'", "") & "'")
        strSQL.Append(", AdminJH2First = '" & Replace(Me.txtFirstNameSup.Text, "'", "") & "' ")
        strSQL.Append(", AdminJH2Last = '" & Replace(Me.txtLastNameSup.Text, "'", "") & "' ")
        strSQL.Append(", AdminJH2MailingAddress = '" & Replace(Me.txtMailingAddressSup.Text, "'", "") & "' ")
        strSQL.Append(", AdminJH2PhoneSchool = '" & Replace(Me.txtSchoolPhoneSup.Text, "'", "") & "' ")
        strSQL.Append(", AdminJH2PhoneSchoolExt = '" & Replace(Me.txtSchoolPhoneSupExt.Text, "'", "") & "' ")

        strSQL.Append(", AdminJH2PhoneCell = '" & Replace(Me.txtCellSup.Text, "'", "") & "' ")
        strSQL.Append(", AdminJH2PhoneFax = '" & Replace(Me.txtSchoolFaxSup.Text, "'", "") & "' ")
        strSQL.Append(", AdminJH2Email = '" & Replace(Me.txtSchoolEmailSup.Text, "'", "") & "' ")
        strSQL.Append(", MailingCity = '" & Replace(Me.txtMailingCitySup.Text, "'", "") & "' ")
        strSQL.Append(", MailingState = '" & Replace(Me.txtMailingStateSup.Text, "'", "") & "' ")
        strSQL.Append(", MailingZip = '" & Replace(Me.txtMailingZipSup.Text, "'", "") & "'")

        strSQL.Append(", AdminJH2Type = '" & Me.cboSchoolType.SelectedValue.ToString & "'")
        strSQL.Append(", AdminJH2GradeFrom = '" & Me.cboGradeFrom.SelectedValue.ToString & "'")
        strSQL.Append(", AdminJH2GradeTo = '" & Me.cboGradeTo.SelectedValue.ToString & "'")

        strSQL.Append(", dtmStampJH2 = '" & Now & "'")

        strSQL.Append(" WHERE Id = " & Session("key"))

        ' Save the data...
        Try
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL.ToString)
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQLInsert.ToString)
            Me.lblMessage.Text = "Changes saved."
        Catch
            'Me.lblMessage.Text = "Change failed."
            Me.lblMessage.Text = strSQLInsert.ToString
        End Try

    End Sub

    Private Sub MemberInfoJH2_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
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