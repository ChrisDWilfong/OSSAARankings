Public Class unpw
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmdGo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdGo.Click
        ' Load the Data...
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = "SELECT * FROM tblSchool WHERE Id = " & Me.cboSchool.SelectedValue

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            With ds.Tables(0).Rows(0)
                If cboPosition.SelectedValue = "Superintendent" Then
                    Me.txtFirstName.Text = .Item("AdminSuperFirst").ToString
                    Me.txtLastName.Text = .Item("AdminSuperLast").ToString
                    Me.txtEmail.Text = .Item("AdminSuperEmail").ToString
                    Me.txtPassword.Text = .Item("Password1").ToString
                    Me.txtPhone.Text = .Item("AdminSuperPhoneSchool").ToString
                    Me.txtCell.Text = .Item("AdminSuperPhoneCell").ToString
                    Me.dtmStamp.Text = .Item("dtmStampAdmin").ToString
                    Session("key") = .Item("Id")
                ElseIf cboPosition.SelectedValue = "High School Principal" Then
                    Me.txtFirstName.Text = .Item("AdminPrincipalFirst").ToString
                    Me.txtLastName.Text = .Item("AdminPrincipalLast").ToString
                    Me.txtEmail.Text = .Item("AdminPrincipalEmail").ToString
                    Me.txtPassword.Text = .Item("Password2").ToString
                    Me.txtPhone.Text = .Item("AdminPrincipalPhoneSchool").ToString
                    Me.txtCell.Text = .Item("AdminPrincipalPhoneCell").ToString
                    Me.dtmStamp.Text = .Item("dtmStampPrincipal").ToString
                    Session("key") = .Item("Id")
                ElseIf cboPosition.SelectedValue = "Athletic Director" Then
                    Me.txtFirstName.Text = .Item("AdminADFirst").ToString
                    Me.txtLastName.Text = .Item("AdminADLast").ToString
                    Me.txtEmail.Text = .Item("AdminADEmail").ToString
                    Me.txtPassword.Text = .Item("Password3").ToString
                    Me.txtPhone.Text = .Item("AdminADPhoneSchool").ToString
                    Me.txtCell.Text = .Item("AdminADPhoneCell").ToString
                    Me.dtmStamp.Text = .Item("dtmStampAD").ToString
                    Session("key") = .Item("Id")
                Else
                    Me.txtFirstName.Text = ""
                    Me.txtLastName.Text = ""
                    Me.txtEmail.Text = ""
                    Me.txtPassword.Text = ""
                    Me.txtPhone.Text = ""
                    Me.txtCell.Text = ""
                    Me.dtmStamp.Text = ""
                    Session("key") = 0
                End If
            End With

            ' Get the AD Info from OSSAARankings.com... 7/25/2019 added...
            If Me.cboPosition.SelectedValue = "Athletic Director" Then
                Dim strRankings As String = ""
                strSQL = "SELECT * FROM tblSchool WHERE Id = " & Me.cboSchool.SelectedValue
                ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, System.Data.CommandType.Text, strSQL)
                strRankings = "<br>OSSAARankings.com<br>"
                With ds.Tables(0).Rows(0)
                    strRankings += "NAME : " & .Item("AdminADFirst").ToString & " " & .Item("AdminADLast").ToString & "<br>"
                    strRankings += "EMAIL : " & .Item("AdminADEmail").ToString & "<br>"
                    strRankings += "PASSWORD : " & .Item("Password3").ToString & "<br>"
                    strRankings += "PHONE (SCHOOL) : " & .Item("AdminADPhoneSchool").ToString & "<br>"
                    strRankings += "PHONE (CELL) : " & .Item("AdminADPhoneCell").ToString
                End With
                lblOSSAARankings.Text = strRankings
            Else
                lblOSSAARankings.Text = ""
            End If

        End If
        Me.lblMessage.Text = ""
    End Sub

    Protected Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click
        Me.txtFirstName.Text = ""
        Me.txtLastName.Text = ""
        Me.txtEmail.Text = ""
        Me.txtPassword.Text = ""
        Me.txtPhone.Text = ""
        Me.txtCell.Text = ""
        Me.dtmStamp.Text = ""
        Session("key") = 0
        Session("multi") = 0
        Me.cboPosition.SelectedIndex = 0
        Me.lblMessage.Text = "Data cleared"
    End Sub

    Protected Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave.Click
        Dim strSQL As String

        Select Case Me.cboPosition.SelectedValue
            Case "Superintendent"
                strSQL = "UPDATE tblSchool SET AdminSuperFirst = '" & Replace(Me.txtFirstName.Text, "'", "") & "', AdminSuperLast = '" & Replace(Me.txtLastName.Text, "'", "") & "', "
                If Me.txtPhone.Text = "" And Me.txtCell.Text = "" Then
                ElseIf Me.txtPhone.Text = "" Then
                    strSQL = strSQL & "AdminSuperPhoneCell = '" & Me.txtCell.Text & "', "
                ElseIf Me.txtCell.Text = "" Then
                    strSQL = strSQL & "AdminSuperPhoneSchool = '" & Me.txtPhone.Text & "', "
                    strSQL = strSQL & "AdminSuperPhoneCell = Null, "
                Else
                    strSQL = strSQL & "AdminSuperPhoneSchool = '" & Me.txtPhone.Text & "', AdminSuperPhoneCell = '" & Me.txtCell.Text & "', "
                End If
                strSQL = strSQL & "AdminSuperEmail = '" & Me.txtEmail.Text & "', Password1 = '" & Me.txtPassword.Text & "' WHERE "
                strSQL = strSQL & "Id = " & Session("key")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, System.Data.CommandType.Text, strSQL)
                Me.lblMessage.Text = "Data saved."
            Case "High School Principal"
                strSQL = "UPDATE tblSchool SET AdminPrincipalFirst = '" & Replace(Me.txtFirstName.Text, "'", "") & "', AdminPrincipalLast = '" & Replace(Me.txtLastName.Text, "'", "") & "', "
                If Me.txtPhone.Text = "" And Me.txtCell.Text = "" Then
                ElseIf Me.txtPhone.Text = "" Then
                    strSQL = strSQL & "AdminPrincipalPhoneCell = '" & Me.txtCell.Text & "', "
                ElseIf Me.txtCell.Text = "" Then
                    strSQL = strSQL & "AdminPrincipalPhoneSchool = '" & Me.txtPhone.Text & "', "
                    strSQL = strSQL & "AdminPrincipalPhoneCell = Null, "
                Else
                    strSQL = strSQL & "AdminPrincipalPhoneSchool = '" & Me.txtPhone.Text & "', AdminPrincipalPhoneCell = '" & Me.txtCell.Text & "', "
                End If
                strSQL = strSQL & "AdminPrincipalEmail = '" & Me.txtEmail.Text & "', Password2 = '" & Me.txtPassword.Text & "' WHERE "
                strSQL = strSQL & "Id = " & Session("key")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, System.Data.CommandType.Text, strSQL)
                Me.lblMessage.Text = "Data saved."
            Case "Athletic Director"
                strSQL = "UPDATE tblSchool SET AdminADFirst = '" & Replace(Me.txtFirstName.Text, "'", "") & "', AdminADLast = '" & Replace(Me.txtLastName.Text, "'", "") & "', "
                If Me.txtPhone.Text = "" And Me.txtCell.Text = "" Then
                ElseIf Me.txtPhone.Text = "" Then
                    strSQL = strSQL & "AdminADPhoneCell = '" & Me.txtCell.Text & "', "
                ElseIf Me.txtCell.Text = "" Then
                    strSQL = strSQL & "AdminADPhoneSchool = '" & Me.txtPhone.Text & "', "
                    strSQL = strSQL & "AdminADPhoneCell = Null, "
                Else
                    strSQL = strSQL & "AdminADPhoneSchool = '" & Me.txtPhone.Text & "', AdminADPhoneCell = '" & Me.txtCell.Text & "', "
                End If
                strSQL = strSQL & "AdminADEmail = '" & Me.txtEmail.Text & "', Password3 = '" & Me.txtPassword.Text & "' WHERE "
                strSQL = strSQL & "Id = " & Session("key")
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
                SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, System.Data.CommandType.Text, strSQL)
                Me.lblMessage.Text = "Data saved."
            Case Else
                Me.lblMessage.Text = "Data NOT saved."
        End Select
    End Sub

    Protected Sub cmdSendEmail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSendEmail.Click
        Dim strValidate As String

        strValidate = clsEmail.GetForgotLoginEmailContent(SqlHelper.StripString(txtEmail.Text), cboSchool.SelectedItem.Value.ToString, 99999, Me.cboPosition.SelectedItem.Value.ToString, SqlHelper.StripString(Me.txtFirstName.Text), cboSchool.SelectedItem.Text, False)
        If strValidate.Contains("FAILED") Then
        Else
            clsEmail.SendEmailNew(txtEmail.Text, "", "Login Information Request from OSSAA.com : " & txtEmail.Text, strValidate, False, "OSSAA Response Email")
            'clsEmail.SendEmail(Me, strValidate, txtEmail.Text, "cwilfong@ossaa.com", "Login Information Request from OSSAA.com", False)
        End If
        clsEmail.SendEmailNew("cwilfong@ossaa.com", "", "Login Information Request from OSSAA.com : " & txtEmail.Text, strValidate, False, "OSSAA Response Email")
        'clsEmail.SendEmail(Me, strValidate, "cwilfong@ossaa.com", "cwilfong@ossaa.com", "Login Information Request from OSSAA.com : " & txtEmail.Text, False)
        lblMessage.Text = "Your password sent."

    End Sub

    Shared Sub SmtpClient_OnCompleted(ByVal sender As Object, ByVal e As ComponentModel.AsyncCompletedEventArgs)

    End Sub

    'Protected Sub cmdTestEmail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTestEmail.Click
    '    Dim strValidate As String

    '    'strValidate = clsEmail.GetForgotLoginEmailContent(SqlHelper.StripString(txtEmail.Text), cboSchool.SelectedItem.Value.ToString, Me.cboPosition.SelectedItem.Value.ToString, SqlHelper.StripString(Me.txtFirstName.Text))
    '    strValidate = "Test Content 3"
    '    clsEmail.SendEmail(Me, strValidate.ToString, "mwilfong@earthlink.net", "postmaster@ossaa.net", "Test Send")
    '    lblMessage.Text = "Your password sent."

    'End Sub
End Class