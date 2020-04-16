Public Class MemberParticipation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("user") = "" Then
            Response.Redirect("MemberLogin.aspx")
        End If

        If Not IsPostBack Then
            Dim strInfo As String
            strInfo = "The National Federation of State High School Associations, requires participation data on an annual basis to track the changes nationwide.  We are requesting that each individual school enter their participation numbers, to the best of their calculations, so we may provide the most accurate data possible for our State.<br><br>"
            strInfo = strInfo & "INSTRUCTIONS :<br>"
            strInfo = strInfo & "'Boy' participants and 'Girl' participants should be calculated based upon the maximum number of individuals, in grades 9-12,  who participated in the school related activity for any length of time during the school year.<br><br>"
            strInfo = strInfo & "<strong>Data should be submitted by each school no later than May 24, 2020.</strong><br><br>"
            strInfo = strInfo & "If you do not complete the survey, you may hit the SAVE CHANGES button and come back to complete the survey at a later time.  Once you have completed the survey, you must hit the SUBMIT TO OSSAA button to send the data to the OSSAA."
            lblInfo.Text = strInfo
            LoadData()
        End If

        Me.lblMessageSubmit.Text = SubmissionStatus()

    End Sub

    Public Sub LoadData()
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = "SELECT * FROM tblSchool WHERE schoolID = " & Session("idSchool")
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            With ds.Tables(0).Rows(0)
                Me.TextBox1.Text = .Item("intPart_BAB")
                Me.TextBox2.Text = .Item("intPart_BAG")
                Me.TextBox3.Text = .Item("intPart_SCB")
                Me.TextBox4.Text = .Item("intPart_SCG")
                Me.TextBox5.Text = .Item("intPart_NABN")
                Me.TextBox6.Text = .Item("intPart_BKB")
                Me.TextBox7.Text = .Item("intPart_BKG")
                Me.TextBox9.Text = .Item("intPart_FP")
                Me.TextBox10.Text = .Item("intPart_NAOR")
                Me.TextBox11.Text = .Item("intPart_CHB")
                Me.TextBox12.Text = .Item("intPart_CHG")
                Me.TextBox14.Text = .Item("intPart_SP")
                Me.TextBox15.Text = .Item("intPart_NAVO")
                Me.TextBox16.Text = .Item("intPart_CCB")
                Me.TextBox17.Text = .Item("intPart_CCG")
                Me.TextBox18.Text = .Item("intPart_SWB")
                Me.TextBox19.Text = .Item("intPart_SWG")
                Me.TextBox20.Text = .Item("intPart_NAOA")
                Me.TextBox21.Text = .Item("intPart_FBB")
                Me.TextBox22.Text = .Item("intPart_FBG")
                Me.TextBox23.Text = .Item("intPart_TNB")
                Me.TextBox24.Text = .Item("intPart_TNG")
                Me.TextBox25.Text = .Item("intPart_NASD")
                Me.TextBox26.Text = .Item("intPart_FBB8")
                Me.TextBox27.Text = .Item("intPart_FBG8")
                Me.TextBox28.Text = .Item("intPart_TKB")
                Me.TextBox29.Text = .Item("intPart_TKG")
                Me.TextBox30.Text = .Item("intPart_GOB")
                Me.TextBox31.Text = .Item("intPart_GOG")
                Me.TextBox33.Text = .Item("intPart_VB")
                Me.TextBox34.Text = .Item("intPart_WRB")
                Me.TextBox35.Text = .Item("intPart_WRG")
                Me.TextBox36.Text = .Item("intPart_NAACA")
            End With
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As System.EventArgs) Handles cmdSave.Click
        Dim strReturn As String = "OK"
        strReturn = SaveChanges("SAVE")
        If strReturn = "OK" Then
            Me.lblMessage.Text = "Changes Saved"
        Else
            Me.lblMessage.Text = strReturn
        End If
    End Sub

    Public Sub LogAction(strAction As String, strSQLIn As String, strResult As String)
        Dim strSQL As String = ""

        strSQL = "INSERT INTO ossaauser.tblParticipationNumbersLog (strUserName, strSchool, strAction, strSQL, strResult) VALUES ("
        strSQL = strSQL & "'" & Session("user") & "', "
        strSQL = strSQL & "'" & Session("school") & "', "
        strSQL = strSQL & "'" & strAction & "', "
        strSQL = strSQL & "'" & strSQLIn & "', "
        strSQL = strSQL & "'" & strResult & "')"

        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)


    End Sub

    Public Function CheckField(strIn As String) As Integer
        Dim intReturn As Integer

        Try
            intReturn = CInt(strIn)
            If intReturn > 550 Then intReturn = 550
        Catch ex As Exception
            intReturn = 0
        End Try

        Return intReturn

    End Function

    Public Function SaveChanges(strAction As String) As String
        Dim strSQL As String
        Dim strReturn As String = "OK"

        ' Too Many Boy Cheerleaders...
        If CheckField(Me.TextBox11.Text) >= 5 Then
            strReturn = "TOO MANY BOY CHEERLEADERS."
            Return strReturn
        ElseIf CheckField(Me.TextBox22.Text) >= 8 Or CheckField(Me.TextBox22.Text) > CheckField(Me.TextBox21.Text) Then
            strReturn = "TOO MANY GIRL FOOTBALL PLAYERS."
            Return strReturn
        ElseIf CheckField(Me.TextBox27.Text) >= 8 Or CheckField(Me.TextBox27.Text) > CheckField(Me.TextBox26.Text) Then
            strReturn = "TOO MANY GIRL FOOTBALL PLAYERS."
            Return strReturn
        ElseIf CheckField(Me.TextBox35.Text) >= 8 Or CheckField(Me.TextBox35.Text) > CheckField(Me.TextBox34.Text) Then
            strReturn = "TOO MANY GIRL WRESTLERS."
            Return strReturn
        End If

        strSQL = "UPDATE tblSchool SET "
        strSQL = strSQL & "intPart_BAB = " & CheckField(Me.TextBox1.Text) & ", "
        strSQL = strSQL & "intPart_BAG = " & CheckField(Me.TextBox2.Text) & ", "
        strSQL = strSQL & "intPart_SCB = " & CheckField(Me.TextBox3.Text) & ", "
        strSQL = strSQL & "intPart_SCG = " & CheckField(Me.TextBox4.Text) & ", "
        strSQL = strSQL & "intPart_NABN = " & CheckField(Me.TextBox5.Text) & ", "
        strSQL = strSQL & "intPart_BKB = " & CheckField(Me.TextBox6.Text) & ", "
        strSQL = strSQL & "intPart_BKG = " & CheckField(Me.TextBox7.Text) & ", "
        strSQL = strSQL & "intPart_FP = " & CheckField(Me.TextBox9.Text) & ", "
        strSQL = strSQL & "intPart_NAOR = " & CheckField(Me.TextBox10.Text) & ", "
        strSQL = strSQL & "intPart_CHB = " & CheckField(Me.TextBox11.Text) & ", "
        strSQL = strSQL & "intPart_CHG = " & CheckField(Me.TextBox12.Text) & ", "
        strSQL = strSQL & "intPart_SP = " & CheckField(Me.TextBox14.Text) & ", "
        strSQL = strSQL & "intPart_NAVO = " & CheckField(Me.TextBox15.Text) & ", "
        strSQL = strSQL & "intPart_CCB = " & CheckField(Me.TextBox16.Text) & ", "
        strSQL = strSQL & "intPart_CCG = " & CheckField(Me.TextBox17.Text) & ", "
        strSQL = strSQL & "intPart_SWB = " & CheckField(Me.TextBox18.Text) & ", "
        strSQL = strSQL & "intPart_SWG = " & CheckField(Me.TextBox19.Text) & ", "
        strSQL = strSQL & "intPart_NAOA = " & CheckField(Me.TextBox20.Text) & ", "
        strSQL = strSQL & "intPart_FBB = " & CheckField(Me.TextBox21.Text) & ", "
        strSQL = strSQL & "intPart_FBG = " & CheckField(Me.TextBox22.Text) & ", "
        strSQL = strSQL & "intPart_TNB = " & CheckField(Me.TextBox23.Text) & ", "
        strSQL = strSQL & "intPart_TNG = " & CheckField(Me.TextBox24.Text) & ", "
        strSQL = strSQL & "intPart_NASD = " & CheckField(Me.TextBox25.Text) & ", "
        strSQL = strSQL & "intPart_FBB8 = " & CheckField(Me.TextBox26.Text) & ", "
        strSQL = strSQL & "intPart_FBG8 = " & CheckField(Me.TextBox27.Text) & ", "
        strSQL = strSQL & "intPart_TKB = " & CheckField(Me.TextBox28.Text) & ", "
        strSQL = strSQL & "intPart_TKG = " & CheckField(Me.TextBox29.Text) & ", "
        strSQL = strSQL & "intPart_GOB = " & CheckField(Me.TextBox30.Text) & ", "
        strSQL = strSQL & "intPart_GOG = " & CheckField(Me.TextBox31.Text) & ", "
        strSQL = strSQL & "intPart_VB = " & CheckField(Me.TextBox33.Text) & ", "
        strSQL = strSQL & "intPart_WRB = " & CheckField(Me.TextBox34.Text) & ", "
        strSQL = strSQL & "intPart_NAACA = " & CheckField(Me.TextBox36.Text) & ", "
        strSQL = strSQL & "intPart_WRG = " & CheckField(Me.TextBox35.Text)
        strSQL = strSQL & " WHERE schoolID = " & Session("idSchool")

        Try
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            LogAction(strAction, strSQL, "SUCCESS")
        Catch
            LogAction(strAction, strSQL, "FAILED (4)")
        End Try

        Return strReturn

    End Function

    Private Sub MemberParticipation_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
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

    Private Sub cmdSubmit_Click(sender As Object, e As System.EventArgs) Handles cmdSubmit.Click
        SaveChanges("SUBMIT")
        Dim strSQL As String = "UPDATE tblSchool SET dtmSubmittedDate = '" & Now & "', strSubmittedBy = '" & Session("user") & "' WHERE schoolID = " & Session("idSchool")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
        Me.lblMessage.Text = "Changes have been submitted to the OSSAA."
        Me.lblMessageSubmit.Text = "SUBMITTED on " & Format(Now, "Short Date") & " by " & Session("user")
    End Sub

    Public Function SubmissionStatus() As String
        Dim strResult As String = ""
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = "SELECT dtmSubmittedDate, strSubmittedBy FROM tblSchool WHERE schoolID = " & Session("idSchool")
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
            strResult = "Participation Numbers info NOT FOUND."
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            If ds.Tables(0).Rows(0).Item("dtmSubmittedDate") Is System.DBNull.Value Then
                strResult = "Have NOT been submitted."
            Else
                strResult = "SUBMITTED on " & Format(ds.Tables(0).Rows(0).Item("dtmSubmittedDate"), "Short Date") & " by " & ds.Tables(0).Rows(0).Item("strSubmittedBy")
            End If
        End If

        Return strResult
    End Function
End Class