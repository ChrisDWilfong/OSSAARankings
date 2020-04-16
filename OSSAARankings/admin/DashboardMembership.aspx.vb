Imports Telerik.Web.UI

Public Class DashboardMembership
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("whereSite") = "OSSAAMembers"
            Session("whereType") = "NONE"
            Session("whereYear") = clsFunctions.GetCurrentYear
        End If
    End Sub

    Private Sub RadMenu1_ItemClick(sender As Object, e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenu1.ItemClick
        Session("whereSite") = "OSSAAMembers"
        Session("whereType") = e.Item.Value
        Session("RadMenu2") = ""
        hlPreview.Visible = False
        SqlDataSource1.DataBind()
    End Sub


    Private Sub RadMenu2_ItemClick(sender As Object, e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenu2.ItemClick
        Session("whereSite") = "OSSAA.COM"
        Session("whereType") = e.Item.Value
        Session("RadMenu2") = e.Item.Value
        hlPreview.Visible = True

        ' Show PREVIEW hyperlink...
        Select Case e.Item.Value
            Case "HomeColumn1"
                hlPreview.NavigateUrl = "~/ossaa/OSSAAHome.aspx"
            Case "HomeColumn2"
                hlPreview.NavigateUrl = "~/ossaa/OSSAAHome.aspx"
            Case "HomeColumn3"
                hlPreview.NavigateUrl = "~/ossaa/OSSAAHome.aspx"
            Case "Classifications"
                hlPreview.NavigateUrl = "~/ossaa/OSSAAHome.aspx"
            Case "Basketball"
                hlPreview.NavigateUrl = "~/ossaa/SportsBasketballDb.aspx"
            Case "Baseball"
                hlPreview.NavigateUrl = "~/ossaa/SportsBaseballDb.aspx"
            Case "Cheer"
                hlPreview.NavigateUrl = "~/ossaa/SportsCheerDb.aspx"
            Case "CrossCountry"
                hlPreview.NavigateUrl = "~/ossaa/SportsCrossCountryDb.aspx"
            Case "FastPitch"
                hlPreview.NavigateUrl = "~/ossaa/SportsFastPitchDb.aspx"
            Case "Football"
                hlPreview.NavigateUrl = "~/ossaa/SportsFootballDb.aspx"
            Case "Golf"
                hlPreview.NavigateUrl = "~/ossaa/SportsGolfDb.aspx"
            Case "SlowPitch"
                hlPreview.NavigateUrl = "~/ossaa/SportsSlowPitchDb.aspx"
            Case "Soccer"
                hlPreview.NavigateUrl = "~/ossaa/SportsSoccerDb.aspx"
            Case "Swimming"
                hlPreview.NavigateUrl = "~/ossaa/SportsSwimmingDb.aspx"
            Case "Track"
                hlPreview.NavigateUrl = "~/ossaa/SportsTrackDb.aspx"
            Case "Tennis"
                hlPreview.NavigateUrl = "~/ossaa/SportsTennisDb.aspx"
            Case "Volleyball"
                hlPreview.NavigateUrl = "~/ossaa/SportsVolleyballDb.aspx"
            Case "Wrestling"
                hlPreview.NavigateUrl = "~/ossaa/SportsWrestlingDb.aspx"
            Case Else
        End Select

        SqlDataSource1.DataBind()
    End Sub

    Private Sub RadGrid1_UpdateCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.UpdateCommand
        ' Update the record...
        Dim strSQL As String
        Dim ds As DataSet
        Dim id As Long = 0
        Dim editedItem As GridEditableItem = CType(e.Item, GridEditableItem)

        Dim MyUserControl As UserControl = CType(e.Item.FindControl(GridEditFormItem.EditFormUserControlID), UserControl)
        Try
            id = editedItem.OwnerTableView.DataKeyValues(editedItem.ItemIndex)("id")
        Catch
            id = 0
        End Try

        Dim newValues As Hashtable = New Hashtable

        If id = 0 Then      ' INSERT NEW RECORD...
            Dim strSQLFields As String = ""
            Dim strSQLValues As String = ""

            strSQL = "SELECT TOP 1 * FROM tblDashboardLinks"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            newValues = GetValues(MyUserControl)

            ' Build INSERT SQL Statement...
            strSQL = ""
            Dim entry As DictionaryEntry
            With ds.Tables(0).Rows(0)
                For Each entry In newValues
                    If entry.Key.ToString = "id" Then
                        ' Skip the key...
                    Else
                        If entry.Key = "intSort" And entry.Value = "" Then
                            entry.Value = "1"
                        End If
                        .Item(CType(entry.Key, String)) = entry.Value
                        Try
                            If strSQLFields = "" Then
                                strSQLFields = entry.Key.ToString
                                strSQLValues = "'" & entry.Value.ToString & "'"
                            Else
                                strSQLFields += ", " & entry.Key.ToString
                                strSQLValues += ", '" & entry.Value.ToString & "'"
                            End If
                        Catch
                        End Try
                    End If
                Next
                ' Add a couple more...
                strSQLFields += ", strSite"
                strSQLValues += ", '" & Session("whereSite") & "'"
                strSQLFields += ", strType"
                strSQLValues += ", '" & Session("whereType") & "'"
                'strSQLFields += ", strLink"
                'strSQLValues += ", '" & Session("ReturnURL") & "'"
            End With

            strSQL = "INSERT INTO tblDashboardLinks (" & strSQLFields & ") VALUES (" & strSQLValues & ")"
            'lblMessage.Text = strSQL
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        Else
            strSQL = "SELECT * FROM tblDashboardLinks WHERE id = " & id
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

            newValues = GetValues(MyUserControl)

            ' Build UPDATE SQL Statement...
            strSQL = ""
            'Try
            Dim entry As DictionaryEntry
            With ds.Tables(0).Rows(0)
                For Each entry In newValues
                    If entry.Key.ToString = "id" Then
                        ' Skip...
                    Else
                        .Item(CType(entry.Key, String)) = entry.Value.ToString
                        If strSQL = "" Then
                            strSQL = strSQL & entry.Key.ToString & " = '" & entry.Value.ToString & "'"
                        Else
                            strSQL = strSQL & ", " & entry.Key.ToString & " = '" & entry.Value.ToString & "'"
                        End If
                    End If
                Next

                ' Add a couple more...
                strSQL = strSQL & ", strSite = '" & Session("whereSite") & "'"
                'strSQL = strSQL & ", strType = '" & Me.RadMenu1.SelectedValue & "'"
                strSQL = strSQL & ", strType = '" & Session("whereType") & "'"

            End With

            strSQL = "UPDATE tblDashboardLinks SET " & strSQL & " WHERE id = " & id
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        End If

    End Sub

    Public Function GetValues(MyUserControl As UserControl) As Hashtable
        On Error Resume Next
        Dim newValues As New Hashtable

        newValues("id") = CType(MyUserControl.FindControl("id"), TextBox).Text
        newValues("strDescription") = Replace(CType(MyUserControl.FindControl("strDescription"), TextBox).Text, "'", "")
        newValues("strLink") = CType(MyUserControl.FindControl("strLink"), TextBox).Text
        newValues("intSort") = CType(MyUserControl.FindControl("intSort"), TextBox).Text
        newValues("intYear") = CType(MyUserControl.FindControl("intYear"), TextBox).Text
        newValues("strLineType") = CType(MyUserControl.FindControl("strLineType"), DropDownList).SelectedValue

        Return newValues

    End Function

End Class