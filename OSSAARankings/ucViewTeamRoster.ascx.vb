Imports System.Data

Partial Class ucViewTeamRoster
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ''If Not IsPostBack Then
        ''    Dim objTeamInfo As New clsTeam(Session("gTeamID"))
        ''    InitializeGrid(objTeamInfo.getSport, Session("gTeamID"))
        ''End If

        ''If Session("sel") = "sros" Then
        ''    hlPrint.NavigateUrl = "PrintRoster.aspx?sel=ts&t=" & Session("gTeamID")
        ''Else
        ''    hlPrint.Visible = False
        ''End If

        ' Print Version???
        Try
            If Session("printOnly") = 1 Then
                hlPrint.Visible = False
            Else
                hlPrint.NavigateUrl = "PrintRoster.aspx?sel=ts&t=" & Session("gTeamID")
                hlPrint.Visible = True
            End If
        Catch
            hlPrint.Visible = True
        End Try
        Session("printOnly") = 0
        Dim objTeam As New clsTeam(Session("gTeamID"))
        Session("gSport") = objTeam.getSport
        ShowPicture()
        ShowColumns()

    End Sub

    Public Sub ShowPicture()
        If Session("gTeamPicture") = "" Then
            imgTeamPicture.Visible = False
        Else
            imgTeamPicture.Visible = True
            imgTeamPicture.ImageUrl = clsTeams.GetTeamPixLocation & Session("gTeamPicture")
        End If
    End Sub

    Public Sub ShowColumns()

        Me.GridView1.Columns(2).Visible = True
        Me.GridView1.Columns(3).Visible = True
        Me.GridView1.Columns(4).Visible = True

        ' Only show appropriate columns...
        Select Case Session("gSport")
            Case "Baseball", "SPSoftball", "FPSoftball", "BaseballFall", "Soccer"
                Me.GridView1.Columns(2).Visible = False    ' Height...
            Case "Basketball", "Football", "Volleyball"
                ' Do nothing, show all...
            Case Else
                Me.GridView1.Columns(2).Visible = False    ' Height...
                Me.GridView1.Columns(3).Visible = False    ' Position...
                Me.GridView1.Columns(4).Visible = False    ' Jersey...
        End Select

    End Sub


End Class
