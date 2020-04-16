Imports Telerik.Web.UI

Public Class OfficialHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strOfficialsName As String = ""
        Dim intOSSAAID As Long = 0
        Dim strISOK As String = ""

        '''''Session("OSSAAID") = 16211
        '''''Session("Email") = "hosedragonzebra@hotmail.com"
        Session("Year") = clsFunctions.GetCurrentYear - 1
        strISOK = clsOfficials.GetOfficialsInfo(Session("Email"), Session("OSSAAID"), strOfficialsName)

        If strISOK = "OK" Then
            Session("OfficialName") = strOfficialsName
            lblOfficialInfo.Text = "WELCOME : " & UCase(Session("OfficialName")) & " (" & Session("OSSAAID") & ")"
            RadGridBK.DataBind()
            RadGridFB.DataBind()
        Else
            Response.Redirect("Login1718.aspx")
        End If

    End Sub

    Private Sub RadGridBK_ColumnCreated(sender As Object, e As GridColumnCreatedEventArgs) Handles RadGridBK.ColumnCreated
        Select Case e.Column.UniqueName
            Case "Name"
                e.Column.ItemStyle.Font.Bold = True
            Case Else
                If e.Column.UniqueName.Contains("Class") Or e.Column.UniqueName.Contains("Rating") Then
                    e.Column.ItemStyle.Font.Bold = True
                Else
                    e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                End If
                If e.Column.UniqueName = "Year" Or e.Column.UniqueName = "Sport" Then
                    e.Column.Visible = False
                Else
                    e.Column.Visible = True
                End If
        End Select
    End Sub

    Private Sub RadGridFB_ColumnCreated(sender As Object, e As GridColumnCreatedEventArgs) Handles RadGridFB.ColumnCreated
        Select Case e.Column.UniqueName
            Case "Name"
                e.Column.ItemStyle.Font.Bold = True
            Case Else
                If e.Column.UniqueName.Contains("Class") Or e.Column.UniqueName.Contains("Rating") Then
                    e.Column.ItemStyle.Font.Bold = True
                Else
                    e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                End If
                If e.Column.UniqueName = "Year" Or e.Column.UniqueName = "Sport" Then
                    e.Column.Visible = False
                Else
                    e.Column.Visible = True
                End If
        End Select
    End Sub
End Class