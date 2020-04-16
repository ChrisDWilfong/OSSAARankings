Public Class ucAssigners
    Inherits System.Web.UI.UserControl
    Dim ds1 As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Added 8/9/2017...

        If Session("madgCoachName") = "" Then
            Response.Redirect("adLogin.aspx")
        End If

        If Me.Visible = False Then
            LoadData()
        End If
        'End If

    End Sub

    Public Sub LoadData()
        ' Load the current selected coaches...
        Dim strSQL As String
        Dim ds As DataSet
        Dim x As Integer
        Dim strSportID As String = ""

        If Session("madgSchoolID") = 0 Then Exit Sub

        strSQL = "SELECT * FROM tblSchool WHERE schoolID = " & Session("madgSchoolID")
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            With ds.Tables(0).Rows(0)
                If Not .Item("strAssignerBaseball") Is System.DBNull.Value Then
                    strBaseball.Text = .Item("strAssignerBaseball")
                Else
                    strBaseball.Text = ""
                End If
                If Not .Item("strAssignerBasketball") Is System.DBNull.Value Then
                    strBasketball.Text = .Item("strAssignerBasketball")
                Else
                    strBasketball.Text = ""
                End If
                If Not .Item("strAssignerFootball") Is System.DBNull.Value Then
                    strFootball.Text = .Item("strAssignerFootball")
                Else
                    strFootball.Text = ""
                End If
                If Not .Item("strAssignerSoccer") Is System.DBNull.Value Then
                    strSoccer.Text = .Item("strAssignerSoccer")
                Else
                    strSoccer.Text = ""
                End If
                If Not .Item("strAssignerSoftball") Is System.DBNull.Value Then
                    strSoftball.Text = .Item("strAssignerSoftball")
                Else
                    strSoftball.Text = ""
                End If
                If Not .Item("strAssignerVolleyball") Is System.DBNull.Value Then
                    strVolleyball.Text = .Item("strAssignerVolleyball")
                Else
                    strVolleyball.Text = ""
                End If
                If Not .Item("strAssignerWrestling") Is System.DBNull.Value Then
                    strWrestling.Text = .Item("strAssignerWrestling")
                Else
                    strWrestling.Text = ""
                End If
            End With
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As System.EventArgs) Handles cmdSave.Click
        Dim strSQL As String

        strSQL = ""

        If strSQL = "" Then
            strSQL = "strAssignerBaseball = '" & clsFunctions.StringValidateSQL(strBaseball.Text) & "'"
        Else
            strSQL = strSQL & ", strAssignerBaseball = '" & clsFunctions.StringValidateSQL(strBaseball.Text) & "'"
        End If

        If strSQL = "" Then
            strSQL = "strAssignerBasketball = '" & clsFunctions.StringValidateSQL(strBasketball.Text) & "'"
        Else
            strSQL = strSQL & ", strAssignerBasketball = '" & clsFunctions.StringValidateSQL(strBasketball.Text) & "'"
        End If

        If strSQL = "" Then
            strSQL = "strAssignerFootball = '" & clsFunctions.StringValidateSQL(strFootball.Text) & "'"
        Else
            strSQL = strSQL & ", strAssignerFootball = '" & clsFunctions.StringValidateSQL(strFootball.Text) & "'"
        End If

        If strSQL = "" Then
            strSQL = "strAssignerSoccer = '" & clsFunctions.StringValidateSQL(strSoccer.Text) & "'"
        Else
            strSQL = strSQL & ", strAssignerSoccer = '" & clsFunctions.StringValidateSQL(strSoccer.Text) & "'"
        End If

        If strSQL = "" Then
            strSQL = "strAssignerSoftball = '" & clsFunctions.StringValidateSQL(strSoftball.Text) & "'"
        Else
            strSQL = strSQL & ", strAssignerSoftball = '" & clsFunctions.StringValidateSQL(strSoftball.Text) & "'"
        End If

        If strSQL = "" Then
            strSQL = "strAssignerVolleyball = '" & clsFunctions.StringValidateSQL(strVolleyball.Text) & "'"
        Else
            strSQL = strSQL & ", strAssignerVolleyball = '" & clsFunctions.StringValidateSQL(strVolleyball.Text) & "'"
        End If

        If strSQL = "" Then
            strSQL = "strAssignerWrestling = '" & clsFunctions.StringValidateSQL(strWrestling.Text) & "'"
        Else
            strSQL = strSQL & ", strAssignerWrestling = '" & clsFunctions.StringValidateSQL(strWrestling.Text) & "'"
        End If

        If strSQL = "" Then
            ' Do nothing...
        Else
            strSQL = "UPDATE tblSchool SET " & strSQL & " WHERE schoolID = " & Session("madgSchoolID")
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
            SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnection, System.Data.CommandType.Text, strSQL)
        End If

        Me.lblMessage.Text = "Your changes have been saved."

    End Sub

End Class