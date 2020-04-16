Partial Class MemberInfoAD
    Inherits System.Web.UI.Page

    ' Notes: 
    '   11/1/2010: Added VotingStreetAddress
    '

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Session("usertype") = "OSSAA" Or Session("usertype") = "OSSAAADMIN" Then
                Me.cmdClearAndSave.Visible = True
            Else
                Me.cmdClearAndSave.Visible = False
            End If

            Dim intConfirmed As Integer
            intConfirmed = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, CommandType.Text, "SELECT intConfirmedAD FROM tblSchool WHERE Id = " & Session("key"))
            If intConfirmed = 0 Then
                Me.cmdSaveChanges.Text = "Confirm Your Information"
            Else
                Me.cmdSaveChanges.Text = "Save Changes"
            End If
        End If

        If Session("user") = "" Then
            Response.Redirect("MemberLogin.aspx")
        End If

        Me.lblStep.Text = "Athletic Director Info - " & Session("school")
        Me.lblTitle.Text = "Please enter your school's Athletic Director information.<br>If this is the first time you are entering the AD info, a password will be assigned automatically."

        If Session("usertype") = "AD" Then
            Me.cmdChangeUsername.Visible = True
            Me.lblPasswordInfo1.Visible = False
            Me.lblPasswordInfo2.Visible = False
        Else
            Me.cmdChangeUsername.Visible = False
            Me.lblPasswordInfo1.Visible = True
            Me.lblPasswordInfo2.Visible = True
        End If

        ' Load the data...
        If Not IsPostBack Then
            Dim strSQL As String
            strSQL = "SELECT AdminADMrMs, AdminADFirst, AdminADLast, AdminADMailingAddress, AdminADStreetAddress, AdminADPhoneSchool, AdminADPhoneSchoolExt, AdminADPhoneCell, AdminADPhoneFax, AdminADEmail, MailingCity, MailingState, MailingZip, Password3, intSchoolID "
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
                If Not .Item("AdminADMrMs") Is System.DBNull.Value Then
                    cboMrMsSup.SelectedValue = .Item("AdminADMrMs")
                End If
                If Not .Item("AdminADFirst") Is System.DBNull.Value Then
                    txtFirstNameSup.Text = .Item("AdminADFirst")
                End If
                If Not .Item("AdminADLast") Is System.DBNull.Value Then
                    txtLastNameSup.Text = .Item("AdminADLast")
                End If
                If Not .Item("AdminADMailingAddress") Is System.DBNull.Value Then
                    txtMailingAddressSup.Text = .Item("AdminADMailingAddress")
                End If
                If Not .Item("AdminADPhoneSchool") Is System.DBNull.Value Then
                    txtSchoolPhoneSup.Text = .Item("AdminADPhoneSchool")
                End If
                If Not .Item("AdminADPhoneSchoolExt") Is System.DBNull.Value Then
                    txtSchoolPhoneSupExt.Text = .Item("AdminADPhoneSchoolExt")
                End If
                If Not .Item("AdminADPhoneCell") Is System.DBNull.Value Then
                    txtCellSup.Text = .Item("AdminADPhoneCell")
                End If
                If Not .Item("AdminADPhoneFax") Is System.DBNull.Value Then
                    txtSchoolFaxSup.Text = .Item("AdminADPhoneFax")
                End If
                If Not .Item("AdminADEmail") Is System.DBNull.Value Then
                    txtSchoolEmailSup.Text = .Item("AdminADEmail")
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
                If Not .Item("AdminADStreetAddress") Is System.DBNull.Value Then
                    txtPhysicalAddress.Text = .Item("AdminADStreetAddress")
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
                ' Show the password if not an AD...
                If Session("usertype") <> "AD" Then
                    If Not .Item("Password3") Is System.DBNull.Value Then
                        Me.lblPasswordInfo2.Text = .Item("Password3")
                    Else
                        Session("password") = clsMembership.AssignPassword(Session("school"), Session("usertype"), Session("key"))
                        Me.lblPasswordInfo2.Text = Session("password")
                    End If
                End If

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
            strSQLInsert.Append("(AdminADMrMs, AdminADFirst, AdminADLast, AdminADMailingAddress, ")
            strSQLInsert.Append("AdminADStreetAddress, AdminADPhoneSchool, ")
            strSQLInsert.Append("AdminADPhoneSchoolExt, AdminADPhoneCell, AdminADPhoneFax, AdminADEmail, ")
            strSQLInsert.Append("Username3, MailingCity, MailingState, MailingZip, dtmStampAdmin, ")
            strSQLInsert.Append("intSync4, dtmSync, intSchoolID, strChangedBy, strUserType")

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
            strSQL.Append("UPDATE tblSchool SET AdminADMrMs = '" & strMrMs & "' ")
            strSQL.Append(", intConfirmedAD = 1 ")
            strSQL.Append(", AdminADFirst = '" & Replace(Me.txtFirstNameSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminADLast = '" & Replace(Me.txtLastNameSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminADMailingAddress = '" & Replace(Me.txtMailingAddressSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminADStreetAddress = '" & Replace(Me.txtPhysicalAddress.Text, "'", "") & "' ")

            strSQL.Append(", AdminADPhoneSchool = '" & Replace(Me.txtSchoolPhoneSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminADPhoneSchoolExt = '" & Replace(Me.txtSchoolPhoneSupExt.Text, "'", "") & "' ")

            strSQL.Append(", AdminADPhoneCell = '" & Replace(Me.txtCellSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminADPhoneFax = '" & Replace(Me.txtSchoolFaxSup.Text, "'", "") & "' ")
            strSQL.Append(", AdminADEmail = '" & Replace(Me.txtSchoolEmailSup.Text, "'", "") & "' ")
            strSQL.Append(", Username3 = '" & Replace(Me.txtSchoolEmailSup.Text, "'", "") & "' ")
            strSQL.Append(", MailingCity = '" & Replace(Me.txtMailingCitySup.Text, "'", "") & "' ")
            strSQL.Append(", MailingState = '" & Replace(Me.txtMailingStateSup.Text, "'", "") & "' ")
            strSQL.Append(", MailingZip = '" & Replace(Me.txtMailingZipSup.Text, "'", "") & "'")

            ' Show the password if not an AD...
            If Session("usertype") <> "AD" Then
                If Me.lblPasswordInfo2.Visible Then
                    If Me.lblPasswordInfo2.Text <> "" Then
                        strSQL.Append(", Password3 = '" & Me.lblPasswordInfo2.Text & "'")
                    End If
                End If
            End If

            strSQL.Append(", dtmStampAD = '" & Now & "'")

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

    Private Sub MemberInfoAD_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
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

    Protected Sub cmdChangeUsername_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChangeUsername.Click
        Response.Redirect("MemberChangePassword.aspx")
    End Sub
End Class