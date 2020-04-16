Partial Class ucSportsListRankings
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim intYear As Integer = clsFunctions.GetCurrentYear

            Try
                If sender("gYear") Is Nothing Then
                    intYear = clsFunctions.GetCurrentYear
                Else
                    intYear = Session("gYear")
                End If
            Catch
                intYear = clsFunctions.GetCurrentYear
            End Try

            Dim ds As DataSet
            Dim x As Integer
            Dim strSQL As String

            strSQL = "SELECT DISTINCT GenderSport1, GenderSport, Sport, Gender, SportGenderKey FROM tblSports WHERE intRankings > 0 ORDER BY GenderSport1"

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    Dim objGroupBar As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
                    objGroupBar.Value = ds.Tables(0).Rows(x).Item("GenderSport")
                    objGroupBar.Text = ds.Tables(0).Rows(x).Item("GenderSport1")
                    objGroupBar.NavigateUrl = "?sel=rankings&spGK=" & ds.Tables(0).Rows(x).Item("SportGenderKey") & "&sp=" & ds.Tables(0).Rows(x).Item("Sport") & "&g=" & ds.Tables(0).Rows(x).Item("Gender") & "&y=" & intYear
                    ExplorerBarSportsListRankings.Groups.Add(objGroupBar)
                Next x
            End If

            If System.Configuration.ConfigurationManager.AppSettings("showWrestlingAccumulativeRankings") = 0 Then
                '    ' Do nothing....
            Else
                ' Wrestling Accumulative Total Rankings...
                Dim objGroupBarA As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
                objGroupBarA.Value = "Wrestling"
                objGroupBarA.Text = "Wrestling (Final 5 Weeks)"
                objGroupBarA.NavigateUrl = "?sel=rankings&spGK=Wrestling&sp=Wrestling&g=5&y=" & intYear
                ExplorerBarSportsListRankings.Groups.Add(objGroupBarA)

                ' Wrestling Accumulative Total Rankings...
                Dim objGroupBarAd As New Infragistics.Web.UI.NavigationControls.ExplorerBarGroup
                objGroupBarAd.Value = "WrestlingDual"
                objGroupBarAd.Text = "Wrestling (Dual-Final 5 Weeks)"
                If Session("memgSplitWeek") = 1 Then
                    objGroupBarAd.NavigateUrl = "?sel=rankings&spGK=WrestlingDual&sp=WrestlingDual&g=5d&y=" & intYear
                Else
                    ' NOTE Change back when final Dual Rankings...1/16/2016...
                    objGroupBarAd.NavigateUrl = "?sel=rankings&spGK=WrestlingDual&sp=WrestlingDual&g=5d&y=" & intYear
                    'objGroupBarAd.NavigateUrl = "?sel=rankings&spGK=WrestlingDual&sp=WrestlingDual&g=5d8&y=" & intYear
                End If
                ExplorerBarSportsListRankings.Groups.Add(objGroupBarAd)
            End If

        End If
    End Sub

End Class