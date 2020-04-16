Public Class adHome
    Inherits System.Web.UI.Page

    Private Sub adHome_Error(sender As Object, e As System.EventArgs) Handles Me.Error
        On Error Resume Next
        Dim objErr As Exception = Server.GetLastError.GetBaseException
        Dim strSQL As String

        strSQL = "INSERT INTO dbo.Errors (errDescription, URL, RequestMethod, HostAddress, UserAgent, AllHTTP) VALUES ('" & objErr.Message.Replace("'", "") & "', '" & Request.Url.ToString & "', '" & Request.ServerVariables("REQUEST_METHOD") & "', '" & Request.ServerVariables("REMOTE_ADDR") & "', '" & Session("madgUserName") & "', '" & objErr.StackTrace.ToString & "')"
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)

    End Sub

    Private Sub SetHyperlink()
        On Error Resume Next
        hlPrefs.Visible = True
        If Session("memgRole") = "OSSAAADMIN" Then
            hlPrefs.NavigateUrl = "http://www.ossaarankings.com/officials/LoginBBPref.aspx?l=ossaaad&id=" & Session("madgEmailMain") & "&sid=" & ((Session("madgSchoolID") + 1234))
        Else
            hlPrefs.NavigateUrl = "http://www.ossaarankings.com/officials/LoginBBPref.aspx?l=ossaaad&id=" & Session("madgUsername") & "&sid=" & ((Session("madgSchoolID") + 1234))
        End If
        'hlPrefs.Text = "Preferential Officials List and Bracket Entry Site"
        hlPrefs.Text = "Officials Assignments (click here)"
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.ClientTarget = "Uplevel"       ' Added 11/20/2013 to resolve IE 11 compatibility problem...

        If Session("madgSchool") = "" Then
            Response.Redirect("adLogin.aspx")
        End If

        lblCoach.Text = Session("madgCoachName")
        lblSchool.Text = clsFunctions.ParseSchool(Session("madgSchool")) & " (" & Session("madgTitle") & ")"

        If ConfigurationManager.AppSettings("showBBPrefsLink") = 1 Then
            SetHyperlink()
        ElseIf ConfigurationManager.AppSettings("ShowPlayoffOfficialsList") = 1 Then
            hlPrefs.Text = "Round 5 Football Playoff Officials"
            hlPrefs.NavigateUrl = "http://www.ossaa.net/docs/2019-20/Round5_Football_Officials_Schools.pdf"
            hlPrefs.Visible = True
        End If

        ' TODO : Load the Sports for this coach...
        If Not IsPostBack Then
            Session("madsel") = Request.QueryString("sel")
            LoadAction(Request.QueryString("sel"))
        End If

        ' Handle Multi...
        If Not IsPostBack Then
            If Session("madgOrganizationType") = "MULTI" Then
                rowSchools.Visible = True
                cboSchools.DataSource = Session("maddsSchoolsMULTI")
                cboSchools.DataBind()
                Dim objItem As New System.Web.UI.WebControls.ListItem
                objItem.Value = 0
                objItem.Text = "Select School..."
                cboSchools.Items.Insert(0, objItem)
                cboSchools.SelectedValue = Session("madcboSchools")
            ElseIf Session("madgOrganizationType") = "OSSAAADMIN" Then
                rowSchools.Visible = True
                cboSchools.DataSource = Session("maddsSchoolsADMIN")
                cboSchools.DataBind()
                Dim objItem As New System.Web.UI.WebControls.ListItem
                objItem.Value = 0
                objItem.Text = "Select School..."
                cboSchools.Items.Insert(0, objItem)
                cboSchools.SelectedValue = Session("madcboSchools")
            End If
        End If

    End Sub

    Protected Sub cboAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAction.SelectedIndexChanged
        LoadAction(cboAction.SelectedValue)
    End Sub

    Public Sub LoadAction(strAction As String)
        Dim objControl1 As UserControl

        ' Hide first...
        ucCoaches1.Visible = False
        ucPersonalInfoAD1.Visible = False
        ucCoachesSports1.Visible = False
        ucEntryFormsList.Visible = False
        ucAssigners1.Visible = False

        ' Now turn on the correct one...
        Select Case strAction
            Case "HeadCoaches"
                Me.ucCoaches1.Visible = True
                Me.cboAction.SelectedValue = "HeadCoaches"
                Session("madsel") = "CoachesList"
            Case "CoachesList", "CoachAdd", "CoachEdit"
                Me.ucCoaches1.Visible = True
                Session("madsel") = strAction
                Me.cboAction.SelectedValue = "HeadCoaches"
            Case "CoachesSports"
                Me.ucCoachesSports1.Visible = True
                Me.cboAction.SelectedValue = "CoachesSports"
                Session("madsel") = "Assigners"
            Case "Assigners"               ' Added 8/9/2017...
                Me.ucAssigners1.Visible = True
                Session("madsel") = "EntryForms"
            Case "EntryForms"               ' Added 7/19/2017...
                Me.ucEntryFormsList.Visible = True
                Session("madsel") = "SportsList"
            Case "SportsList"
                Me.ucCoachesSports1.Visible = True
                Me.cboAction.SelectedValue = "CoachesSports"
            Case "PersonalInfo"
                Me.ucPersonalInfoAD1.Visible = True
                cboAction.SelectedValue = "PersonalInfo"
            Case "ContactUs"
                cboAction.SelectedValue = "ContactUs"
                PlaceHolder.Visible = True
                objControl1 = CType(LoadControl("ucContactUs.ascx"), UserControl)
                PlaceHolder.Controls.Add(objControl1)
            Case "Logout"
                Session("madgSchool") = ""
                Session("madgMemberID") = 0
                Session("madgSchoolID") = 0
                Session("madgTeamID") = 0
                Session("entryFormSchoolName") = ""
                Session("entryFormSchoolID") = 0
                Session("entryFormMemberID") = 0
                Response.Redirect("adLogin.aspx")
            Case Else
        End Select

    End Sub

    Private Sub cboSchools_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboSchools.SelectedIndexChanged
        ' FOR MULTI...
        ' Load School Info...
        Dim objSchoolInfo As New clsSchool("", cboSchools.SelectedValue)

        Session("madgSchoolID") = cboSchools.SelectedValue
        Session("madgSchool") = objSchoolInfo.getSchool
        Session("madcboSchools") = cboSchools.SelectedValue

        ' Load the AD Info...
        Dim objMember As New clsMember(Session("madgSchoolID"), True)
        Session("madgMemberID") = objMember.gMemberID
        Session("madgSchool") = objMember.gSchool
        Session("madgSchoolID") = objMember.gSchoolID

        Session("entryFormSchoolName") = objMember.gSchool          ' 7/19/2017..
        'Session("entryFormSchoolNameSelected") = objMember.gSchool
        Session("entryFormSchoolID") = objMember.gSchoolID
        Session("entryFormMemberID") = objMember.gMemberID

        Session("madgCoachName") = objMember.gFirstName & " " & objMember.gLastName
        Session("madgTitle") = "Athletic Director"
        Session("madgFirstName") = objMember.gFirstName
        Session("madgLastName") = objMember.gLastName
        Session("madgEmailMain") = objMember.gEmailMain
        Session("madgPhoneMain") = objMember.gPhoneMain
        Session("madgPhoneAlt") = objMember.gPhoneAlt
        Session("madgPassword") = objMember.gPassword

        cboAction.SelectedIndex = 0

        ' HIDE OBJECTS :  all of the existing objects...
        ucCoaches1.Visible = False
        ucCoachesSports1.Visible = False
        ucPersonalInfoAD1.Visible = False
        ucEntryFormsList.Visible = False
        ucAssigners1.Visible = False

    End Sub
End Class