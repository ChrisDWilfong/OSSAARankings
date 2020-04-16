Public Class ucRosterList
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("memgTeamID") Is Nothing Then
        Else
            Dim strSQL As String
            Dim ds As DataSet

            strSQL = "SELECT [Jersey], [LastName] AS Last, [FirstName] AS First, '<a href=?sel=RosterEdit&r=' + CAST([rosterID] AS varchar) + ' target=_self>' + CAST(LastName + ', ' + FirstName AS varchar) + '</a>' AS DisplayName, [Pos], [Height], [Weight], [Grade], [Jersey], [rosterID], [ysnStarter] AS Starter, CAST(intJersey AS INT) AS JerseySort, CAST(Grade AS INT) AS GradeSort, ysnPitcher FROM [tblRosters] WHERE ([teamID] = " & Session("memgTeamID") & ") AND ysnActive <> 0"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            GridView1.DataSource = ds
            GridView1.DataBind()

            ShowColumns()

        End If

    End Sub

    Public Sub ShowColumns()
        Me.GridView1.Columns(2).Visible = True
        Me.GridView1.Columns(3).Visible = True
        Me.GridView1.Columns(4).Visible = True

        ' Only show appropriate columns...
        Select Case Session("memgSport")
            Case "Baseball", "SPSoftball", "FPSoftball", "BaseballFall", "Soccer"
                Me.GridView1.Columns(2).Visible = False    ' Height...
            Case "Basketball", "Football", "Volleyball"
                ' Do nothing, show all...
            Case Else
                Me.GridView1.Columns(2).Visible = False    ' Height...
                Me.GridView1.Columns(3).Visible = False    ' Position...
                Me.GridView1.Columns(4).Visible = False    ' Jersey...
        End Select

        If Session("memgSport") = "Baseball" Or Session("memgSport") = "BaseballFall" Then
        Else
            Me.GridView1.Columns(5).Visible = False
        End If

    End Sub

End Class