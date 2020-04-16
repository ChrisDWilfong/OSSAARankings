Public Class MemberInfoSchool
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

            Me.lblStep.Text = "School Info - " & Session("school")
            Me.lblTitle.Text = "Please enter your school information..."
            Me.txtMailingState.Text = "OK"
            Me.txtSchoolState.Text = "OK"

            ' Load the data...
            If Not IsPostBack Then
                Dim strSQL As String
                strSQL = "SELECT SchoolName, SchoolMascot, MailingAddress, MailingCity, MailingState, MailingZip, StreetAddress, StreetCity, StreetState, StreetZip, Email, Website, intSchoolID "
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
                    If Not .Item("SchoolName") Is System.DBNull.Value Then
                        Me.txtSchoolName.Text = .Item("SchoolName")
                    End If
                    If Not .Item("SchoolMascot") Is System.DBNull.Value Then
                        Me.txtSchoolMascot.Text = .Item("SchoolMascot")
                    End If
                    If Not .Item("MailingAddress") Is System.DBNull.Value Then
                        Me.txtMailingAddress.Text = .Item("MailingAddress")
                    End If
                    If Not .Item("MailingCity") Is System.DBNull.Value Then
                        Me.txtMailingCity.Text = .Item("MailingCity")
                    End If
                    If Not .Item("MailingState") Is System.DBNull.Value Then
                        Me.txtMailingState.Text = .Item("MailingState")
                    End If
                    If Not .Item("MailingZip") Is System.DBNull.Value Then
                        Me.txtMailingZip.Text = .Item("MailingZip")
                    End If
                    If Not .Item("StreetAddress") Is System.DBNull.Value Then
                        Me.txtSchoolAddress.Text = .Item("StreetAddress")
                    End If
                    If Not .Item("StreetCity") Is System.DBNull.Value Then
                        Me.txtSchoolCity.Text = .Item("StreetCity")
                    End If
                    If Not .Item("StreetState") Is System.DBNull.Value Then
                        Me.txtSchoolState.Text = .Item("StreetState")
                    End If
                    If Not .Item("StreetZip") Is System.DBNull.Value Then
                        Me.txtSchoolZip.Text = .Item("StreetZip")
                    End If
                    If Not .Item("Email") Is System.DBNull.Value Then
                        Me.txtSchoolEmail.Text = .Item("Email")
                    End If
                    If Not .Item("Website") Is System.DBNull.Value Then
                        Me.txtSchoolWebSite.Text = .Item("Website")
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

        ' APPEND query...
        strSQLInsert.Append("INSERT INTO tblSchoolSync ")
        strSQLInsert.Append("(SchoolName, SchoolMascot, MailingAddress, MailingCity, MailingState, MailingZip, ")
        strSQLInsert.Append("Email, Website, StreetAddress, StreetCity, StreetState, StreetZip, intSync1, dtmSync, intSchoolID, strChangedBy, strUserType")
        strSQLInsert.Append(") VALUES (")
        strSQLInsert.Append("'" & Replace(txtSchoolName.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolMascot.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtMailingAddress.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtMailingCity.Text, "'", "") & "', ")
        strSQLInsert.Append("'OK', ")
        strSQLInsert.Append("'" & Replace(Me.txtMailingZip.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolEmail.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolWebSite.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolAddress.Text, "'", "") & "', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolCity.Text, "'", "") & "', ")
        strSQLInsert.Append("'OK', ")
        strSQLInsert.Append("'" & Replace(Me.txtSchoolZip.Text, "'", "") & "', ")
        strSQLInsert.Append("1, ")
        strSQLInsert.Append("'" & Now & "', ")
        strSQLInsert.Append("" & Session("intSchoolID") & ", ")
        strSQLInsert.Append("'" & Session("user") & "', ")
        strSQLInsert.Append("'" & Session("usertype") & "'")
        strSQLInsert.Append(")")

        ' UPDATE query...
        ' 12/9/2011 DO NOT ALLOW CHANGING OF SCHOOL NAME...
        'strSQL.Append("UPDATE tblSchool SET SchoolName = '" & Replace(txtSchoolName.Text, "'", "") & "' ")
        'strSQL.Append(", SchoolMascot = '" & Replace(Me.txtSchoolMascot.Text, "'", "") & "' ")
        strSQL.Append("UPDATE tblSchool SET SchoolMascot = '" & Replace(Me.txtSchoolMascot.Text, "'", "") & "' ")
        strSQL.Append(", MailingAddress = '" & Replace(Me.txtMailingAddress.Text, "'", "") & "' ")
        strSQL.Append(", MailingCity = '" & Replace(Me.txtMailingCity.Text, "'", "") & "' ")
        strSQL.Append(", MailingState = 'OK' ")
        strSQL.Append(", MailingZip = '" & Replace(Me.txtMailingZip.Text, "'", "") & "' ")

        strSQL.Append(", Email = '" & Replace(Me.txtSchoolEmail.Text, "'", "") & "' ")
        strSQL.Append(", Website = '" & Replace(Me.txtSchoolWebSite.Text, "'", "") & "' ")

        strSQL.Append(", StreetAddress = '" & Replace(Me.txtSchoolAddress.Text, "'", "") & "' ")
        strSQL.Append(", StreetCity = '" & Replace(Me.txtSchoolCity.Text, "'", "") & "' ")
        strSQL.Append(", StreetState = 'OK' ")
        strSQL.Append(", StreetZip = '" & Replace(Me.txtSchoolZip.Text, "'", "") & "'")
        strSQL.Append(", dtmStampSchoolInfo = '" & Now & "'")

        strSQL.Append(" WHERE Id = " & Session("key"))

        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL.ToString)
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQLInsert.ToString)

        Me.lblMessage.Text = "Changes saved."

    End Sub

    Private Sub MemberInfoSchool_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
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