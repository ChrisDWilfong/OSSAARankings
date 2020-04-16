Imports System.Data
Imports OSSAARankings.SqlHelper

Public Class ucRosterAdd
    Inherits System.Web.UI.UserControl

    Protected Sub cmdSaveChanges_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSaveChanges.Click
        Dim strValidate As String
        Dim strSQL As String = ""
        Dim strSport As String

        strSport = Session("memgSport")
        strValidate = Validate()
        ' Do validation...
        If strValidate = "OK" Then
            Dim intJersey As Integer = 0
            Try
                intJersey = CInt(txtJersey.Text)
            Catch ex As Exception
                intJersey = 0
            End Try
            If Session("memgRosterID") = 0 Then
                strSQL = "INSERT INTO tblRosters (teamID, FirstName, LastName, Pos, Height, Grade, Jersey, intJersey) VALUES ("
                If cbPitcher.Visible Then
                    strSQL = "INSERT INTO tblRosters (teamID, FirstName, LastName, Pos, Height, Grade, ysnPitcher, Jersey, intJersey) VALUES ("
                End If
                strSQL = strSQL & Session("memgTeamID") & ", "
                strSQL = strSQL & "'" & SqlHelper.StripString(txtFirstName.Text) & "', "
                strSQL = strSQL & "'" & SqlHelper.StripString(txtLastName.Text) & "', "
                strSQL = strSQL & "'" & cboPosition.SelectedValue & "', "
                strSQL = strSQL & "'" & cboHeight.SelectedValue & "', "
                strSQL = strSQL & "'" & cboGrade.SelectedValue & "', "
                If cbPitcher.Visible Then
                    If cbPitcher.Checked Then
                        strSQL = strSQL & "1, "
                    Else
                        strSQL = strSQL & "0, "
                    End If
                End If
                strSQL = strSQL & "'" & txtJersey.Text & "', "
                strSQL = strSQL & intJersey & ")"
            Else ' THIS IS AN EDIT...
                strSQL = "UPDATE tblRosters SET "
                strSQL = strSQL & "FirstName = '" & SqlHelper.StripString(txtFirstName.Text) & "', "
                strSQL = strSQL & "LastName = '" & SqlHelper.StripString(txtLastName.Text) & "', "
                strSQL = strSQL & "Pos = '" & cboPosition.SelectedValue & "', "
                strSQL = strSQL & "Height = '" & cboHeight.SelectedValue & "', "
                strSQL = strSQL & "Grade = '" & cboGrade.SelectedValue & "', "
                strSQL = strSQL & "Jersey = '" & txtJersey.Text & "', "
                If cbPitcher.Visible Then
                    If cbPitcher.Checked Then
                        strSQL = strSQL & "ysnPitcher = 1, "
                    Else
                        strSQL = strSQL & "ysnPitcher = 0, "
                    End If
                End If
                strSQL = strSQL & "intJersey = " & intJersey & " "
                strSQL = strSQL & "WHERE rosterID = " & Session("memgRosterID")
            End If
            ExecuteNonQuery(SQLConnection, CommandType.Text, strSQL)
            Session("memadd") = 0
            ' Clear fields and close..
            ClearFields()
            Me.Visible = False
            Response.Redirect("Home.aspx?sel=Roster")
        Else
            Me.lblMessage.Text = strValidate
        End If

    End Sub

    Public Sub HeaderChange(ByVal strHeader As String)
        Me.lblHeader.Text = strHeader
    End Sub

    Private Function Validate() As String
        Dim strReturn As String = "OK"

        If txtFirstName.Text = "" Then
            strReturn = "You must enter a FIRST NAME."
        ElseIf txtLastName.Text = "" Then
            strReturn = "You must enter a LAST NAME."
        ElseIf cboPosition.SelectedValue = "Select..." And cboPosition.Visible = True Then
            strReturn = "You must select a POSITION."
        ElseIf cboHeight.SelectedIndex = 0 And cboHeight.Visible = True Then
            strReturn = "You must select a HEIGHT."
        ElseIf cboGrade.SelectedIndex = 0 Then
            strReturn = "You must select a GRADE."
        ElseIf txtJersey.Text = "" And txtJersey.Visible = True Then
            strReturn = "You must entr a JERSEY #"
        Else
            strReturn = "OK"
        End If

        Return strReturn

    End Function

    Private Sub LoadPositions()

        If Session("memgSport") = "Football" Then
            Me.cboPosition.Items.Clear()
            Me.cboPosition.Items.Add("Select...")
            Me.cboPosition.Items.Add("QB")
            Me.cboPosition.Items.Add("RB")
            Me.cboPosition.Items.Add("C")
            Me.cboPosition.Items.Add("OG")
            Me.cboPosition.Items.Add("OT")
            Me.cboPosition.Items.Add("OL")
            Me.cboPosition.Items.Add("WR")
            Me.cboPosition.Items.Add("DG")
            Me.cboPosition.Items.Add("DT")
            Me.cboPosition.Items.Add("DL")
            Me.cboPosition.Items.Add("S")
            Me.cboPosition.Items.Add("LB")
            Me.cboPosition.Items.Add("P")
            Me.cboPosition.Items.Add("K")
            Me.cboPosition.Items.Add("Off")
            Me.cboPosition.Items.Add("Def")
        ElseIf Session("memgSport") = "Soccer" Then
            Me.cboPosition.Items.Clear()
            Me.cboPosition.Items.Add("Select...")
            Me.cboPosition.Items.Add("Midfielder")
            Me.cboPosition.Items.Add("Forward")
            Me.cboPosition.Items.Add("Wing")
            Me.cboPosition.Items.Add("Striker")
            Me.cboPosition.Items.Add("Defender")
            Me.cboPosition.Items.Add("Goalkeeper")
        ElseIf Session("memgSport") = "Basketball" Then
            Me.cboPosition.Items.Clear()
            Me.cboPosition.Items.Add("Select...")
            Me.cboPosition.Items.Add("Guard")
            Me.cboPosition.Items.Add("Forward")
            Me.cboPosition.Items.Add("Center")
            Me.cboPosition.Items.Add("Post")
        ElseIf Session("memgSport") = "Volleyball" Then
            Me.cboPosition.Items.Clear()
            Me.cboPosition.Items.Add("Select...")
            Me.cboPosition.Items.Add("Defense")
            Me.cboPosition.Items.Add("Middle Blocker")
            Me.cboPosition.Items.Add("Outside Hitter")
            Me.cboPosition.Items.Add("Right Side")
            Me.cboPosition.Items.Add("Setter")
        ElseIf InStr(Session("memgSport"), "Baseball") > 0 Or InStr(Session("memgSport"), "Softball") > 0 Then
            Me.cboPosition.Items.Clear()
            Me.cboPosition.Items.Add("Select...")
            Me.cboPosition.Items.Add("1B")
            Me.cboPosition.Items.Add("2B")
            Me.cboPosition.Items.Add("SS")
            Me.cboPosition.Items.Add("3B")
            Me.cboPosition.Items.Add("C")
            Me.cboPosition.Items.Add("OF")
            Me.cboPosition.Items.Add("P")
            Me.cboPosition.Items.Add("Infield")
            Me.cboPosition.Items.Add("Outfield")
        End If

    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Visible Then
            If Not IsPostBack Then
                LoadPositions()
                ShowFields(Session("memgSport"))
            End If

            If Request.QueryString("sel") = "RosterEdit" Then
                If Not IsPostBack Then
                    If Request.QueryString("sel") = "RosterEdit" Then
                        If Session("memgRosterID") > 0 Then
                            LoadFields(Session("memgRosterID"))
                        End If
                    End If

                End If
            End If
        End If

    End Sub

    Protected Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
        ClearFields()
        Me.Visible = False
        Response.Redirect("Home.aspx?sel=Roster")
    End Sub

    Private Sub ClearFields()
        txtFirstName.Text = ""
        txtLastName.Text = ""
        cboPosition.SelectedIndex = 0
        cboHeight.SelectedIndex = 0
        cboGrade.SelectedIndex = 0
        txtJersey.Text = ""
    End Sub

    Private Sub ShowFields(strSport As String)

        lblPosition.Visible = False
        cboPosition.Visible = False
        lblHeight.Visible = False
        cboHeight.Visible = False
        lblJersey.Visible = False
        txtJersey.Visible = False
        lblWeight.Visible = False
        txtWeight.Visible = False
        cbPitcher.Visible = False

        Select Case strSport
            Case "Baseball", "SPSoftball", "FPSoftball", "BaseballFall", "Soccer"
                lblPosition.Visible = True
                cboPosition.Visible = True
                lblJersey.Visible = True
                txtJersey.Visible = True
                If strSport.Contains("Baseball") Then
                    cbPitcher.Visible = True
                End If
            Case "Basketball"
                lblPosition.Visible = True
                cboPosition.Visible = True
                lblHeight.Visible = True
                cboHeight.Visible = True
                lblJersey.Visible = True
                txtJersey.Visible = True
            Case "Football"
                lblPosition.Visible = True
                cboPosition.Visible = True
                lblHeight.Visible = True
                cboHeight.Visible = True
                lblJersey.Visible = True
                txtJersey.Visible = True
                lblWeight.Visible = True
                txtWeight.Visible = True
            Case "Volleyball"
                lblPosition.Visible = True
                cboPosition.Visible = True
                lblHeight.Visible = True
                cboHeight.Visible = True
                lblJersey.Visible = True
                txtJersey.Visible = True
            Case "Wrestling"
                lblWeight.Visible = True
                txtWeight.Visible = True
            Case Else

        End Select
    End Sub

    Public Sub LoadFields(ByVal rosterID As Long)
        Dim objRoster As New clsRoster(rosterID)
        txtFirstName.Text = objRoster.gFirstName
        txtLastName.Text = objRoster.gLastName
        cboPosition.SelectedValue = objRoster.gPosition
        Try
            cboHeight.SelectedValue = objRoster.gHeight
        Catch
        End Try
        cboGrade.SelectedValue = objRoster.gGrade
        txtJersey.Text = objRoster.gJersey
        If objRoster.gPitcher = True Then
            cbPitcher.Checked = True
        Else
            cbPitcher.Checked = False
        End If
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As System.EventArgs) Handles cmdDelete.Click
        Dim strSQL As String
        strSQL = "UPDATE tblRosters SET ysnActive = 0 WHERE rosterID = " & Session("memgRosterID")
        SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, CommandType.Text, strSQL)
        ClearFields()
        Me.Visible = False
        Response.Redirect("Home.aspx?sel=Roster")
    End Sub
End Class

