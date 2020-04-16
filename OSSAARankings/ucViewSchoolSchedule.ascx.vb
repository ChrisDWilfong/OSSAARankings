Imports System.Data

Partial Class ucViewSchoolSchedule
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.UserHostAddress.ToString = "72.198.125.78" Then
            clsLog.LogSQL("", Request.UserHostAddress.ToString, "View Schedule School")
            'Response.Redirect("http://www.ossaarankings.com/Default.aspx")        ' Greg Goodrich...
        End If

        Dim objTeamInfo As New clsTeam(Session("gTeamID"))

        InitializeGrid(objTeamInfo.getSport, Session("gTeamID"))
        hlPrint.NavigateUrl = "PrintSchedule.aspx?sel=ts&t=" & Session("gTeamID")

    End Sub

    Public Sub InitializeGrid(ByVal sport As String, ByVal tmID As Integer)
        Dim sql As String
        Dim ds As DataSet

        sql = clsSchedules.GetScheduleTeamSQL(tmID)

        ' Get initial dataset...
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, sql)

        ' Change the dataset...
        ds = clsSchedules.ChangeDatasetSchedule(ds, True, Session("gResults"), Session("gShowRanking"), True)

        ' Bind new dataset ....
        Me.GridView1.DataSource = ds
        Me.GridView1.DataBind()

    End Sub

End Class
