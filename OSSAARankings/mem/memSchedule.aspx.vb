Imports System.Data

Partial Class memSchedule
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '' Turn ON/OFF usercontrols...
        Dim strCmd As String
        'Dim strTournament As String
        Dim sID As Long
        Try
            strCmd = Request.QueryString("cmd")
        Catch
            strCmd = ""
        End Try

        Try
            sID = Request.QueryString("sID")
        Catch
            sID = 0
        End Try


        ' NEW STUFF...
        ' Load Header...
        Dim objControl1 As UserControl
        Dim objControl2 As UserControl
        objControl2 = CType(LoadControl("ucScheduleMember.ascx"), UserControl)
        objControl2.Session.Add("memstyle", Session("memstyle"))
        PlaceHolderSchedule.Controls.Add(objControl2)

        Select Case strCmd
            Case "ag"       ' Add Game...
                objControl1 = CType(LoadControl("ucScheduleAdd.ascx"), UserControl)
                objControl1.Session.Add("memstyle", Session("memstyle"))
                PlaceHolderAction.Controls.Add(objControl1)
            Case "eg"       ' Edit Game...
                objControl1 = CType(LoadControl("ucScheduleAdd.ascx"), UserControl)
                objControl1.Session.Add("memstyle", Session("memstyle"))
                PlaceHolderAction.Controls.Add(objControl1)
            Case Else
        End Select

    End Sub

    Protected Sub cmdRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRefresh.Click
        Response.Redirect("MemberSchedule.aspx")
    End Sub

End Class
