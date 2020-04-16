Public Class MemberInfoPrin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Session("usertype") = "OSSAA" Or Session("usertype") = "OSSAAADMIN" Then
                Me.cmdClearAndSave.Visible = True
            Else
                If Session("usertype") <> "PRINCIPAL" And Session("usertype") <> "SUPER" Then
                    Response.Redirect("MemberLogin.aspx")
                Else
                    Me.cmdClearAndSave.Visible = False
                End If
            End If

            Dim intConfirmed As Integer
            intConfirmed = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT intConfirmedPrincipal FROM tblSchool WHERE Id = " & Session("key"))
            If intConfirmed = 0 Then
                Me.cmdSaveChanges.Text = "Confirm Your Information"
            Else
                Me.cmdSaveChanges.Text = "Save Changes"
            End If

        End If

        If Session("user") = "" Then
            Response.Redirect("MemberLogin.aspx")
        End If

        Me.lblStep.Text = "High School Principal's Info - " & Session("school")
        Me.lblTitle.Text = "Please enter your school's High School Principal's information..."

        ' Load the data...
        If Not IsPostBack Then
            Dim strSQL As String
            strSQL = "SELECT AdminPrincipalMrMs, AdminPrincipalFirst, AdminPrincipalLast, AdminPrincipalMailingAddress, AdminPrincipalStreetAddress, AdminPrincipalPhoneSchool, AdminPrincipalPhoneSchoolExt, AdminPrincipalPhoneCell, AdminPrincipalPhoneFax, AdminPrincipalEmail, MailingCity, MailingState, MailingZip, intSchoolID "
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
                If Not .Item("AdminPrincipalMrMs") Is System.DBNull.Value Then
                    cboMrMsSup.SelectedValue = .Item("AdminPrincipalMrMs")
                End If
                If Not .Item("AdminPrincipalFirst") Is System.DBNull.Value Then
                    txtFirstNameSup.Text = .Item("AdminPrincipalFirst")
                End If
                If Not .Item("AdminPrincipalLast") Is System.DBNull.Value Then
                    txtLastNameSup.Text = .Item("AdminPrincipalLast")
                End If
                If Not .Item("AdminPrincipalMailingAddress") Is System.DBNull.Value Then
                    txtMailingAddressSup.Text = .Item("AdminPrincipalMailingAddress")
                End If
                If Not .Item("AdminPrincipalPhoneSchool") Is System.DBNull.Value Then
                    txtSchoolPhoneSup.Text = .Item("AdminPrincipalPhoneSchool")
                End If
                If Not .Item("AdminPrincipalPhoneSchoolExt") Is System.DBNull.Value Then
                    txtSchoolPhoneSupExt.Text = .Item("AdminPrincipalPhoneSchoolExt")
                End If
                If Not .Item("AdminPrincipalPhoneCell") Is System.DBNull.Value Then
                    txtCellSup.Text = .Item("AdminPrincipalPhoneCell")
                End If
                If Not .Item("AdminPrincipalPhoneFax") Is System.DBNull.Value Then
                    txtSchoolFaxSup.Text = .Item("AdminPrincipalPhoneFax")
                End If
                If Not .Item("AdminPrincipalEmail") Is System.DBNull.Value Then
                    txtSchoolEmailSup.Text = .Item("AdminPrincipalEmail")
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
                If Not .Item("AdminPrincipalStreetAddress") Is System.DBNull.Value Then
                    txtPhysicalAddress.Text = .Item("AdminPrincipalStreetAddress")
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
            strSQLInsert.Append("(AdminPrincipalMrMs, AdminPrincipalFirst, AdminPrincipalLast, AdminPrincipalMailingAddress, ")
            strSQLInsert.Append("AdminPrincipalStreetAddress, AdminPrincipalPhoneSchool, ")
            strSQLInsert.Append("AdminPrincipalPhoneSchoolExt, AdminPrincipalPhoneCell, AdminPrincipalPhoneFax, AdminPrincipalEmail, ")
            strSQLInsert.Append("Username2, MailingCity, MailingState, MailingZip, dtmStampPrincipal, ")
            strSQLInsert.Append("intSync3, dtmSync, intSchoolID, strChangedBy, strUserType")

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
            strSQL.Append("UPDATE tblSchool SET AdminPrincipalMrMs = '" & strMrMs & "' ")
            strSQL.Append(", intConfirmedPrincipal = 1 ")
            strSQL.Append(", AdminPrincipalFirst = '" & Replace(Me.txtFirstNameSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminPrincipalLast = '" & Replace(Me.txtLastNameSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminPrincipalMailingAddress = '" & Replace(Me.txtMailingAddressSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminPrincipalStreetAddress = '" & Replace(Me.txtPhysicalAddress.Text, "'", "") & "' ")

            strSQL.Append(", AdminPrincipalPhoneSchool = '" & Replace(Me.txtSchoolPhoneSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminPrincipalPhoneSchoolExt = '" & Replace(Me.txtSchoolPhoneSupExt.Text, "'", "") & "' ")

            strSQL.Append(", AdminPrincipalPhoneCell = '" & Replace(Me.txtCellSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminPrincipalPhoneFax = '" & Replace(Me.txtSchoolFaxSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminPrincipalEmail = '" & Replace(Me.txtSchoolEmailSup.Text, "'", "") & "' ")
            strSQL.Append(", Username2 = '" & Replace(Me.txtSchoolEmailSup.Text, "'", "") & "' ")
            strSQL.Append(", dtmStampPrincipal = '" & Now & "'")
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
            Catch objException As Exception
                Me.lblMessage.Text = "Change failed."
            End Try
        End If

    End Sub

    Private Sub MemberInfoPrin_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
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
End Class