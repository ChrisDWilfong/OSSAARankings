Public Class NameSearch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("code") = "8401116" Then
            Session("code") = Request.QueryString("code")
        Else
            Session("code") = "Invalid"
        End If
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As System.EventArgs) Handles cmdSearch.Click
        Dim strResult As String = ""
        Dim strWhere As String = ""
        Dim strSQL As String
        Dim ds As DataSet
        Dim x As Integer = 0

        If Session("code") <> "8401116" Then
            strResult = "You do not have permission to be here."
        ElseIf txtFirstName.Text = "" And txtLastName.Text = "" Then
            strResult = "You must type in a First Name OR Last Name."
        Else

            ' Check Coaches in OSSAARankings.com...
            If txtFirstName.Text = "" Then
                strWhere = "LastName Like '%" & txtLastName.Text & "%' AND intYear = " & clsFunctions.GetCurrentYear
            ElseIf txtLastName.Text = "" Then
                strWhere = "FirstName Like '%" & txtFirstName.Text & "%' AND intYear = " & clsFunctions.GetCurrentYear
            Else
                strWhere = "LastName Like '%" & Me.txtLastName.Text & "%' OR FirstName Like '%" & Me.txtFirstName.Text & "%' AND intYear = " & clsFunctions.GetCurrentYear
            End If
            strSQL = "SELECT DISTINCT LastName, FirstName, SchoolName, SportGenderKey, emailMain, phoneMain FROM allCoachesDetail WHERE " & strWhere & " ORDER BY LastName, FirstName"

            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                strResult = strResult & "<tr style='background-color: black; color:white;'><td colspan=6>&nbsp;COACHES</td></tr>"
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    If x Mod 2 = 0 Then
                        strResult = strResult & "<tr style='background-color: lightblue;'>"
                    Else
                        strResult = strResult & "<tr style='background-color: white;'>"
                    End If
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("LastName") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("FirstName") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("SchoolName") & "</td>"
                    strResult = strResult & "<td>COACH " & ds.Tables(0).Rows(x).Item("SportGenderKey") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("emailMain") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("phoneMain") & "</td>"
                    strResult = strResult & "</tr>"
                Next
            End If

            ' Check Superintendents...
            If txtFirstName.Text = "" Then
                strWhere = "AdminSuperLast Like '%" & txtLastName.Text & "%'"
            ElseIf txtLastName.Text = "" Then
                strWhere = "AdminSuperFirst Like '%" & txtFirstName.Text & "%'"
            Else
                strWhere = "AdminSuperLast Like '%" & Me.txtLastName.Text & "%' OR AdminSuperFirst Like '%" & Me.txtFirstName.Text & "%'"
            End If

            strSQL = "SELECT * FROM tblSchool WHERE " & strWhere & " ORDER BY AdminSuperLast, AdminSuperFirst"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                strResult = strResult & "<tr style='background-color: black; color:white;'><td colspan=6>&nbsp;SUPERINTENDENTS</td></tr>"
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    If x Mod 2 = 0 Then
                        strResult = strResult & "<tr style='background-color: lightblue;'>"
                    Else
                        strResult = strResult & "<tr style='background-color: white;'>"
                    End If
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("AdminSuperLast") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("AdminSuperFirst") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("SchoolName") & "</td>"
                    strResult = strResult & "<td>SUPERINTENDENT</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("AdminSuperEmail") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("AdminSuperPhoneCell") & "</td>"
                    strResult = strResult & "</tr>"
                Next
            End If

            ' Check Principal...
            If txtFirstName.Text = "" Then
                strWhere = "AdminPrincipalLast Like '%" & txtLastName.Text & "%'"
            ElseIf txtLastName.Text = "" Then
                strWhere = "AdminPrincipalFirst Like '%" & txtFirstName.Text & "%'"
            Else
                strWhere = "AdminPrincipalLast Like '%" & Me.txtLastName.Text & "%' OR AdminPrincipalFirst Like '%" & Me.txtFirstName.Text & "%'"
            End If
            strSQL = "SELECT * FROM tblSchool WHERE " & strWhere & " ORDER BY AdminPrincipalLast, AdminPrincipalFirst"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                strResult = strResult & "<tr style='background-color: black; color:white;'><td colspan=6>&nbsp;PRINCIPALS</td></tr>"
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    If x Mod 2 = 0 Then
                        strResult = strResult & "<tr style='background-color: lightblue;'>"
                    Else
                        strResult = strResult & "<tr style='background-color: white;'>"
                    End If
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("AdminPrincipalLast") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("AdminPrincipalFirst") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("SchoolName") & "</td>"
                    strResult = strResult & "<td>PRINCIPAL</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("AdminPrincipalEmail") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("AdminPrincipalPhoneCell") & "</td>"
                    strResult = strResult & "</tr>"
                Next
            End If

            ' Check A/D...
            If txtFirstName.Text = "" Then
                strWhere = "AdminADLast Like '%" & txtLastName.Text & "%'"
            ElseIf txtLastName.Text = "" Then
                strWhere = "AdminADFirst Like '%" & txtFirstName.Text & "%'"
            Else
                strWhere = "AdminADLast Like '%" & Me.txtLastName.Text & "%' OR AdminADFirst Like '%" & Me.txtFirstName.Text & "%'"
            End If
            strSQL = "SELECT * FROM tblSchool WHERE " & strWhere & " ORDER BY AdminADLast, AdminADFirst"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                strResult = strResult & "<tr style='background-color: black; color:white;'><td colspan=6>&nbsp;ATHLETIC DIRECTOR</td></tr>"
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    If x Mod 2 = 0 Then
                        strResult = strResult & "<tr style='background-color: lightblue;'>"
                    Else
                        strResult = strResult & "<tr style='background-color: white;'>"
                    End If
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("AdminADLast") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("AdminADFirst") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("SchoolName") & "</td>"
                    strResult = strResult & "<td>ATHLETIC DIRECTOR</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("AdminADEmail") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("AdminADPhoneCell") & "</td>"
                    strResult = strResult & "</tr>"
                Next
            End If

            ' Check Officials...
            If txtFirstName.Text = "" Then
                strWhere = "strLastName Like '%" & txtLastName.Text & "%'"
            ElseIf txtLastName.Text = "" Then
                strWhere = "strFirstName Like '%" & txtFirstName.Text & "%'"
            Else
                strWhere = "strLastName Like '%" & Me.txtLastName.Text & "%' OR strFirstName Like '%" & Me.txtFirstName.Text & "%'"
            End If
            strSQL = "SELECT * FROM prodOfficials WHERE " & strWhere & " ORDER BY strLastName, strFirstName"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                strResult = strResult & "<tr style='background-color: black; color:white;'><td colspan=6>&nbsp;OFFICIALS</td></tr>"
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    If x Mod 2 = 0 Then
                        strResult = strResult & "<tr style='background-color: lightblue;'>"
                    Else
                        strResult = strResult & "<tr style='background-color: white;'>"
                    End If
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("strLastName") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("strFirstName") & "</td>"
                    strResult = strResult & "<td>NONE</td>"
                    strResult = strResult & "<td>OFFICIAL</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("strEmail") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("strPhone1") & "</td>"
                    strResult = strResult & "</tr>"
                Next
            End If

            ' Check OSSAASpeech...
            If txtFirstName.Text = "" Then
                strWhere = "strLastName Like '%" & txtLastName.Text & "%' AND intYear = " & clsFunctions.GetCurrentYear
            ElseIf txtLastName.Text = "" Then
                strWhere = "strFirstName Like '%" & txtFirstName.Text & "%' AND intYear = " & clsFunctions.GetCurrentYear
            Else
                strWhere = "strLastName Like '%" & Me.txtLastName.Text & "%' OR strFirstName Like '%" & Me.txtFirstName.Text & "%' AND intYear = " & clsFunctions.GetCurrentYear
            End If
            strSQL = "SELECT * FROM viewSchoolsCoaches WHERE " & strWhere & " ORDER BY strLastName, strFirstName"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAASpeech, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                strResult = strResult & "<tr style='background-color: black; color:white;'><td colspan=6>&nbsp;SPEECH COACHES</td></tr>"
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    If x Mod 2 = 0 Then
                        strResult = strResult & "<tr style='background-color: lightblue;'>"
                    Else
                        strResult = strResult & "<tr style='background-color: white;'>"
                    End If
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("strLastName") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("strFirstName") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("strSchoolName") & "</td>"
                    strResult = strResult & "<td>SPEECH COACH</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("strEmail") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("strPhoneCell") & "</td>"
                    strResult = strResult & "</tr>"
                Next
            End If

            ' Check Playoff Passes...
            If txtFirstName.Text = "" Then
                strWhere = "LastName Like '%" & txtLastName.Text & "%'"
            ElseIf txtLastName.Text = "" Then
                strWhere = "FirstName Like '%" & txtFirstName.Text & "%'"
            Else
                strWhere = "LastName Like '%" & Me.txtLastName.Text & "%' OR FirstName Like '%" & Me.txtFirstName.Text & "%'"
            End If
            strSQL = "SELECT * FROM viewPassHeaderDetails WHERE " & strWhere & " ORDER BY LastName, FirstName"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                strResult = strResult & "<tr style='background-color: black; color:white;'><td colspan=6>&nbsp;PLAYOFF PASS ADMINISTRATOR</td></tr>"
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    If x Mod 2 = 0 Then
                        strResult = strResult & "<tr style='background-color: lightblue;'>"
                    Else
                        strResult = strResult & "<tr style='background-color: white;'>"
                    End If
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("LastName") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("FirstName") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("strSchool") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("Position") & "</td>"
                    strResult = strResult & "<td>&nbsp;</td>"
                    strResult = strResult & "<td>&nbsp;</td>"
                    strResult = strResult & "</tr>"
                Next
            End If

            ' Check Playoff Passes Spouse...
            If txtFirstName.Text = "" Then
                strWhere = "SpouseLastName Like '%" & txtLastName.Text & "%'"
            ElseIf txtLastName.Text = "" Then
                strWhere = "SpouseFirstName Like '%" & txtFirstName.Text & "%'"
            Else
                strWhere = "SpouseLastName Like '%" & Me.txtLastName.Text & "%' OR SpouseFirstName Like '%" & Me.txtFirstName.Text & "%'"
            End If
            strSQL = "SELECT * FROM viewPassHeaderDetails WHERE " & strWhere & " ORDER BY LastName, FirstName"
            ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)
            If ds Is Nothing Then
            ElseIf ds.Tables.Count = 0 Then
            ElseIf ds.Tables(0).Rows.Count = 0 Then
            Else
                strResult = strResult & "<tr style='background-color: black; color:white;'><td colspan=6>&nbsp;PLAYOFF PASS SPOUSE</td></tr>"
                For x = 0 To ds.Tables(0).Rows.Count - 1
                    If x Mod 2 = 0 Then
                        strResult = strResult & "<tr style='background-color: lightblue;'>"
                    Else
                        strResult = strResult & "<tr style='background-color: white;'>"
                    End If
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("SpouseLastName") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("SpouseFirstName") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("strSchool") & "</td>"
                    strResult = strResult & "<td>" & ds.Tables(0).Rows(x).Item("Position") & "</td>"
                    strResult = strResult & "<td>of " & ds.Tables(0).Rows(x).Item("LastName") & ", " & ds.Tables(0).Rows(x).Item("FirstName") & "</td>"
                    strResult = strResult & "<td>&nbsp;</td>"
                    strResult = strResult & "</tr>"
                Next
            End If

        End If

        If strResult = "" Then
            strResult = "NO RESULTS"
        Else
            strResult = "<table width='960px'><tr style='background-color:gray;'><td>&nbsp;Last</td><td>&nbsp;First</td><td>&nbsp;School</td><td>&nbsp;Sport</td><td>&nbsp;Email</td><td>&nbsp;Phone</td><tr>" & strResult & "</table>"
        End If

        lblResults.Text = strResult

    End Sub
End Class