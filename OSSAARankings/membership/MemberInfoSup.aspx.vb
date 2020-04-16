Public Class MemberInfoSup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.lblStep.Text = "Superintendent Info - " & Session("school")
        Me.lblTitle.Text = "Please enter your school's Superintendent information..."

        If Not IsPostBack Then
            If Session("usertype") = "OSSAA" Or Session("usertype") = "OSSAAADMIN" Then
                Me.cmdClearAndSave.Visible = True
            Else
                If Session("usertype") <> "SUPER" Then
                    Response.Redirect("MemberLogin.aspx")
                Else
                    Me.cmdClearAndSave.Visible = False
                End If
            End If

            Dim intConfirmed As Integer
            intConfirmed = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT intConfirmedSuper FROM tblSchool WHERE Id = " & Session("key"))
            If intConfirmed = 0 Then
                Me.cmdSaveChanges.Text = "Confirm Your Information"
            Else
                Me.cmdSaveChanges.Text = "Save Changes"
            End If

        End If

        ' Load the data...
        If Not IsPostBack Then
            Dim strSQL As String
            strSQL = "SELECT AdminSuperMrMs, AdminSuperFirst, AdminSuperLast, AdminSuperMailingAddress, AdminSuperStreetAddress, AdminSuperPhoneSchool, AdminSuperPhoneSchoolExt, AdminSuperPhoneCell, AdminSuperPhoneFax, AdminSuperEmail, MailingCity, MailingState, MailingZip, intSchoolID "
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
                If Not .Item("AdminSuperMrMs") Is System.DBNull.Value Then
                    cboMrMsSup.SelectedValue = .Item("AdminSuperMrMs")
                End If
                If Not .Item("AdminSuperFirst") Is System.DBNull.Value Then
                    txtFirstNameSup.Text = .Item("AdminSuperFirst")
                End If
                If Not .Item("AdminSuperLast") Is System.DBNull.Value Then
                    txtLastNameSup.Text = .Item("AdminSuperLast")
                End If
                If Not .Item("AdminSuperMailingAddress") Is System.DBNull.Value Then
                    txtMailingAddressSup.Text = .Item("AdminSuperMailingAddress")
                End If
                If Not .Item("AdminSuperPhoneSchool") Is System.DBNull.Value Then
                    txtSchoolPhoneSup.Text = .Item("AdminSuperPhoneSchool")
                End If
                If Not .Item("AdminSuperPhoneSchoolExt") Is System.DBNull.Value Then
                    txtSchoolPhoneSupExt.Text = .Item("AdminSuperPhoneSchoolExt")
                End If
                If Not .Item("AdminSuperPhoneCell") Is System.DBNull.Value Then
                    txtCellSup.Text = .Item("AdminSuperPhoneCell")
                End If
                If Not .Item("AdminSuperPhoneFax") Is System.DBNull.Value Then
                    txtSchoolFaxSup.Text = .Item("AdminSuperPhoneFax")
                End If
                If Not .Item("AdminSuperEmail") Is System.DBNull.Value Then
                    txtSchoolEmailSup.Text = .Item("AdminSuperEmail")
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

                If Not .Item("AdminSuperStreetAddress") Is System.DBNull.Value Then
                    txtPhysicalAddress.Text = .Item("AdminSuperStreetAddress")
                End If
                If Not .Item("MailingCity") Is System.DBNull.Value Then
                    txtPhysicalCity.Text = .Item("MailingCity")
                End If
                If Not .Item("MailingState") Is System.DBNull.Value Then
                    txtPhysicalState.Text = .Item("MailingState")
                End If
                If Not .Item("MailingZip") Is System.DBNull.Value Then
                    txtPhysicalZip.Text = .Item("MailingZip")
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

        If clsMembership.IsLoginADuplicate(Me.txtSchoolEmailSup.Text, Session("password"), Session("key"), Session("usertype"), Session("confirmed")) Then
            Me.lblMessage.Text = "Save canceled.  This is a duplicate username/password combination."
        Else

            ' APPEND query...
            Dim intID As Integer = 0

            strSQLInsert.Append("INSERT INTO tblSchoolSync ")
            strSQLInsert.Append("(AdminSuperMrMs, AdminSuperFirst, AdminSuperLast, AdminSuperMailingAddress, ")
            strSQLInsert.Append("AdminSuperStreetAddress, AdminSuperPhoneSchool, ")
            strSQLInsert.Append("AdminSuperPhoneSchoolExt, AdminSuperPhoneCell, AdminSuperPhoneFax, AdminSuperEmail, ")
            strSQLInsert.Append("Username1, MailingCity, MailingState, MailingZip, dtmStampAdmin, ")
            strSQLInsert.Append("intSync2, dtmSync, intSchoolID, strChangedBy, strUserType")

            strSQLInsert.Append(") VALUES (")

            strSQLInsert.Append("'" & strMrMs & "', ")
            strSQLInsert.Append("'" & Replace(Me.txtFirstNameSup.Text, "'", "") & "', ")
            strSQLInsert.Append("'" & Replace(Me.txtLastNameSup.Text, "'", "") & "', ")
            strSQLInsert.Append("'" & Replace(Me.txtMailingAddressSup.Text, "'", "") & "', ")
            strSQLInsert.Append("'" & Replace(Me.txtPhysicalAddress.Text, "'", "") & "', ")
            strSQLInsert.Append("'" & Replace(Me.txtSchoolPhoneSup.Text, "'", "") & "', ")
            strSQLInsert.Append("'" & Replace(Me.txtSchoolPhoneSupExt.Text, "'", "") & "', ")
            strSQLInsert.Append("'" & Replace(Me.txtCellSup.Text, "'", "") & "', ")
            strSQLInsert.Append("'" & Replace(Me.txtSchoolFaxSup.Text, "'", "") & "', ")
            strSQLInsert.Append("'" & Replace(Me.txtSchoolEmailSup.Text, "'", "") & "', ")
            strSQLInsert.Append("'" & Replace(Me.txtSchoolEmailSup.Text, "'", "") & "', ")
            strSQLInsert.Append("'" & Replace(Me.txtMailingCitySup.Text, "'", "") & "', ")
            strSQLInsert.Append("'" & Replace(Me.txtMailingStateSup.Text, "'", "") & "', ")
            strSQLInsert.Append("'" & Replace(Me.txtMailingZipSup.Text, "'", "") & "', ")
            strSQLInsert.Append("'" & Now & "', ")
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
            strSQL.Append("UPDATE tblSchool SET AdminSuperMrMs = '" & strMrMs & "' ")
            strSQL.Append(", intConfirmedSuper = 1 ")
            strSQL.Append(", AdminSuperFirst = '" & Replace(Me.txtFirstNameSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminSuperLast = '" & Replace(Me.txtLastNameSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminSuperMailingAddress = '" & Replace(Me.txtMailingAddressSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminSuperStreetAddress = '" & Replace(Me.txtPhysicalAddress.Text, "'", "") & "' ")

            strSQL.Append(", AdminSuperPhoneSchool = '" & Replace(Me.txtSchoolPhoneSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminSuperPhoneSchoolExt = '" & Replace(Me.txtSchoolPhoneSupExt.Text, "'", "") & "' ")

            strSQL.Append(", AdminSuperPhoneCell = '" & Replace(Me.txtCellSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminSuperPhoneFax = '" & Replace(Me.txtSchoolFaxSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminSuperEmail = '" & Replace(Me.txtSchoolEmailSup.Text, "'", "") & "' ")
            strSQL.Append(", Username1 = '" & Replace(Me.txtSchoolEmailSup.Text, "'", "") & "' ")
            strSQL.Append(", MailingCity = '" & Replace(Me.txtMailingCitySup.Text, "'", "") & "' ")
            strSQL.Append(", MailingState = '" & Replace(Me.txtMailingStateSup.Text, "'", "") & "' ")
            strSQL.Append(", MailingZip = '" & Replace(Me.txtMailingZipSup.Text, "'", "") & "'")
            strSQL.Append(", dtmStampAdmin = '" & Now & "'")

            strSQL.Append(" WHERE Id = " & Session("key"))

            Try
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL.ToString)
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQLInsert.ToString)
                Session("user") = Me.txtSchoolEmailSup.Text
                If Session("confirmed") = 0 Then
                    Me.lblMessage.Text = "Your information has been confirmed.  You may now continue using the other tabs."
                    Session("confirmed") = 1
                    Response.Redirect("MemberHome.aspx")
                Else
                    Me.lblMessage.Text = "Changes saved."
                End If
                Session("confirmed") = 1

            Catch
                Me.lblMessage.Text = "Change failed."
            End Try
        End If

    End Sub

    Private Sub MemberInfoSup_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
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

    Protected Sub cmdChangeUsername_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChangeUsername.Click
        Response.Redirect("MemberChangePassword.aspx")
    End Sub

    Protected Sub cmdCancelChanges_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancelChanges.Click
        Response.Redirect("MemberHome.aspx")
    End Sub

    Protected Sub cmdClearAndSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClearAndSave.Click
        Dim strSQL As New StringBuilder
        Dim strSQLInsert As New StringBuilder

        Dim strMrMs As String = Me.cboMrMsSup.SelectedValue
        If strMrMs = "Select..." Then strMrMs = "Mr"

        ' APPEND query...
        Dim intID As Integer = 0

        strSQLInsert.Append("INSERT INTO tblSchoolSync ")
        strSQLInsert.Append("(AdminSuperMrMs, AdminSuperFirst, AdminSuperLast, AdminSuperMailingAddress, ")
        strSQLInsert.Append("AdminSuperStreetAddress, AdminSuperPhoneSchool, ")
        strSQLInsert.Append("AdminSuperPhoneSchoolExt, AdminSuperPhoneCell, AdminSuperPhoneFax, AdminSuperEmail, ")
        strSQLInsert.Append("Username1, MailingCity, MailingState, MailingZip, dtmStampAdmin, ")
        strSQLInsert.Append("intSync2, dtmSync, intSchoolID, strNote, strChangedBy, strUserType")

        strSQLInsert.Append(") VALUES (")

        strSQLInsert.Append("'" & strMrMs & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtFirstNameSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtLastNameSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtMailingAddressSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtPhysicalAddress.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolPhoneSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolPhoneSupExt.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtCellSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolFaxSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolEmailSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolEmailSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtMailingCitySup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtMailingStateSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtMailingZipSup.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Now & "', ")
        strSQLInsert.Append("1, ")

        strSQLInsert.Append("'" & Now & "', ")
        Try
            intID = Session("intSchoolID")
        Catch
            intID = 0
        End Try
        strSQLInsert.Append(intID & ", ")
        strSQLInsert.Append("'CLEARED USER',")
        strSQLInsert.Append("'" & Session("user") & "', ")
        strSQLInsert.Append("'" & Session("usertype") & "'")
        strSQLInsert.Append(")")

        ' UPDATE query...
        strSQL.Append("UPDATE tblSchool SET AdminSuperMrMs = Null ")
        strSQL.Append(", intConfirmedSuper = 0 ")
        strSQL.Append(", AdminSuperFirst = Null ")
        strSQL.Append(", AdminSuperLast = Null ")
        strSQL.Append(", AdminSuperMailingAddress = Null ")
        strSQL.Append(", AdminSuperStreetAddress = Null ")

        strSQL.Append(", AdminSuperPhoneSchool = Null ")
        strSQL.Append(", AdminSuperPhoneSchoolExt = Null ")

        strSQL.Append(", AdminSuperPhoneCell = Null ")
        strSQL.Append(", AdminSuperPhoneFax = Null ")
        strSQL.Append(", AdminSuperEmail = Null ")
        strSQL.Append(", Username1 = Null ")
        strSQL.Append(", MailingCity = Null ")
        strSQL.Append(", MailingState = Null ")
        strSQL.Append(", MailingZip = Null ")
        strSQL.Append(", dtmStampAdmin = '" & Now & "'")

        strSQL.Append(" WHERE Id = " & Session("key"))

        Try
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL.ToString)
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQLInsert.ToString)
            Session("user") = Me.txtSchoolEmailSup.Text

            ' Clear the Fields...
            Me.txtFirstNameSup.Text = ""
            Me.txtLastNameSup.Text = ""
            Me.txtMailingAddressSup.Text = ""
            Me.txtPhysicalAddress.Text = ""
            Me.txtSchoolPhoneSup.Text = ""
            Me.txtSchoolPhoneSupExt.Text = ""
            Me.txtCellSup.Text = ""
            Me.txtSchoolFaxSup.Text = ""
            Me.txtSchoolEmailSup.Text = ""
            Me.txtMailingCitySup.Text = ""
            Me.txtMailingStateSup.Text = ""
            Me.txtMailingZipSup.Text = ""

            Me.lblMessage.Text = "Changes saved."
        Catch
            Me.lblMessage.Text = "Change failed."
        End Try

    End Sub
End Class