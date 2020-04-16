Partial Class sbSwimmingRegionals
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim intButtonHeight As Integer = 0
        Dim intButtonFontSize As Integer = 0
        'If Request.UserAgent.Contains("android") Or Request.UserAgent.Contains("iphone") Or Request.UserAgent.Contains("blackberry") Or Request.UserAgent.Contains("mobile") Or Request.UserAgent.Contains("palm") Then

        If Request.UserAgent.ToUpper.Contains("IPHONE") Then
            Header1.Style("font-size") = "1.6em"
            Header2.Style("font-size") = "1.6em"
            Page.Form.Style.Item("margin-top") = "-50px"
            intButtonHeight = 60
            intButtonFontSize = 12
            ButtonsChange(intButtonHeight, intButtonFontSize)

        ElseIf Request.UserAgent.ToUpper.Contains("ANDROID") Then
            Header1.Style("font-size") = "3.0em"
            Header2.Style("font-size") = "3.0em"
        ElseIf Request.UserAgent.ToUpper.Contains("WINDOWS PHONE") Then
            Header1.Style("font-size") = "0.75em"
            Header2.Style("font-size") = "0.75em"
        ElseIf Request.UserAgent.ToUpper.Contains("IPAD") Then
            Header1.Style("font-size") = "2.5em"
            Header2.Style("font-size") = "2.5em"
            intButtonHeight = 60
            intButtonFontSize = 16
            ButtonsChange(intButtonHeight, intButtonFontSize)
        Else
            If Request.QueryString("src") = "IFRAME" Then
                Page.Form.Style.Item("background") = "White"
                Page.Form.Style.Item("margin-top") = "-80px"
                form1.Style.Add("background", "White")
                Header1.Style("font-size") = "2.25em"
                Header2.Style("font-size") = "2.25em"
                'Header1.Text = "2016 OSSAA REGIONAL"
                'Header2.Text = "SWIMMING RESULTS"
                Header1.ForeColor = System.Drawing.Color.Maroon
                Header2.ForeColor = System.Drawing.Color.Maroon
                intButtonHeight = 55
                intButtonFontSize = 16
                ButtonsChange(intButtonHeight, intButtonFontSize)
            Else
                intButtonHeight = 50
                intButtonFontSize = 12
                ButtonsChange(intButtonHeight, intButtonFontSize)
            End If
        End If

        LoadStuff()

        'lblMessage.Text = Request.UserAgent.ToString

    End Sub

    Public Sub ButtonsChange(intButtonHeight As Integer, intButtonFontSize As Integer)
        Button1.Height = Web.UI.WebControls.Unit.Pixel(intButtonHeight)
        Button2.Height = Web.UI.WebControls.Unit.Pixel(intButtonHeight)
        Button3.Height = Web.UI.WebControls.Unit.Pixel(intButtonHeight)
        Button4.Height = Web.UI.WebControls.Unit.Pixel(intButtonHeight)
        Button5.Height = Web.UI.WebControls.Unit.Pixel(intButtonHeight)
        Button6.Height = Web.UI.WebControls.Unit.Pixel(intButtonHeight)
        Button7.Height = Web.UI.WebControls.Unit.Pixel(intButtonHeight)
        Button8.Height = Web.UI.WebControls.Unit.Pixel(intButtonHeight)
        Button1.Font.Size() = Web.UI.WebControls.FontUnit.Point(intButtonFontSize)
        Button2.Font.Size() = Web.UI.WebControls.FontUnit.Point(intButtonFontSize)
        Button3.Font.Size() = Web.UI.WebControls.FontUnit.Point(intButtonFontSize)
        Button4.Font.Size() = Web.UI.WebControls.FontUnit.Point(intButtonFontSize)
        Button5.Font.Size() = Web.UI.WebControls.FontUnit.Point(intButtonFontSize)
        Button6.Font.Size() = Web.UI.WebControls.FontUnit.Point(intButtonFontSize)
        Button7.Font.Size() = Web.UI.WebControls.FontUnit.Point(intButtonFontSize)
        Button8.Font.Size() = Web.UI.WebControls.FontUnit.Point(intButtonFontSize)
    End Sub

    Public Sub LoadStuff()
        Dim strSQL As String
        Dim ds As DataSet
        Dim x As Integer

        Dim strDescription As String = ""
        Dim strType As String = ""
        Dim strButton As String = ""
        Dim strLink As String = ""
        Dim intActive As Integer = 0
        Dim intScore As Integer = 0

        strSQL = "SELECT * FROM tblPlayoffDetail WHERE intYear = " & clsFunctions.GetCurrentYear & " AND intActive = 1 AND strType Like 'Swimming%' ORDER BY intSort"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAAScoreboard, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else

            For x = 0 To ds.Tables(0).Rows.Count - 1
                ' Initialize buttons...
                strDescription = ds.Tables(0).Rows(x).Item("strPeriod")
                'strDescription = strDescription.Replace("@", vbCrLf & "@")
                intActive = ds.Tables(0).Rows(x).Item("intActive")
                strButton = ds.Tables(0).Rows(x).Item("strTeam1")
                strLink = ds.Tables(0).Rows(x).Item("txtLink")
                intScore = ds.Tables(0).Rows(x).Item("intScore1")

                If x = 0 Then
                    Session("Button1_Click") = ""
                    Session("Button2_Click") = ""
                    Session("Button3_Click") = ""
                    Session("Button4_Click") = ""
                    Session("Button5_Click") = ""
                    Session("Button6_Click") = ""
                    Session("Button7_Click") = ""
                    Session("Button8_Click") = ""
                End If

                ' Load Button Text...

                Select Case strButton
                    Case "Button1"
                        If intActive = 1 Then
                            Button1.Text = strDescription
                            If intScore = 1 Then
                                Session("Button1_Click") = strLink
                                Button1.ForeColor = System.Drawing.Color.Yellow
                            Else
                                Button1.Enabled = False
                            End If
                        Else
                            Button1.Visible = False
                        End If
                    Case "Button2"
                        If intActive = 1 Then
                            Button2.Text = strDescription
                            If intScore = 1 Then
                                Session("Button2_Click") = strLink
                                Button2.ForeColor = System.Drawing.Color.Yellow
                            Else
                                Button2.Enabled = False
                            End If
                        Else
                            Button2.Visible = False
                        End If
                    Case "Button3"
                        If intActive = 1 Then
                            Button3.Text = strDescription
                            If intScore = 1 Then
                                Session("Button3_Click") = strLink
                                Button3.ForeColor = System.Drawing.Color.Yellow
                            Else
                                Button3.Enabled = False
                            End If
                        Else
                            Button3.Visible = False
                        End If
                    Case "Button4"
                        If intActive = 1 Then
                            Button4.Text = strDescription
                            If intScore = 1 Then
                                Session("Button4_Click") = strLink
                                Button4.ForeColor = System.Drawing.Color.Yellow
                            Else
                                Button4.Enabled = False
                            End If
                        Else
                            Button4.Visible = False
                        End If
                    Case "Button5"
                        If intActive = 1 Then
                            Button5.Text = strDescription
                            If intScore = 1 Then
                                Session("Button5_Click") = strLink
                                Button5.ForeColor = System.Drawing.Color.Yellow
                            Else
                                Button5.Enabled = False
                            End If
                        Else
                            Button5.Visible = False
                        End If
                    Case "Button6"
                        If intActive = 1 Then
                            Button6.Text = strDescription
                            If intScore = 1 Then
                                Session("Button6_Click") = strLink
                                Button6.ForeColor = System.Drawing.Color.Yellow
                            Else
                                Button6.Enabled = False
                            End If
                        Else
                            Button6.Visible = False
                        End If
                    Case "Button7"
                        If intActive = 1 Then
                            Button7.Text = strDescription
                            If intScore = 1 Then
                                Session("Button7_Click") = strLink
                                Button7.ForeColor = System.Drawing.Color.Yellow
                            Else
                                Button7.Enabled = False
                            End If
                        Else
                            Button7.Visible = False
                        End If
                    Case "Button8"
                        If intActive = 1 Then
                            Button8.Text = strDescription
                            If intScore = 1 Then
                                Session("Button8_Click") = strLink
                                Button8.ForeColor = System.Drawing.Color.Yellow
                            Else
                                Button8.Enabled = False
                            End If
                        Else
                            Button8.Visible = False
                        End If
                End Select
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Response.Redirect(Session("Button1_Click"))
    End Sub

    Private Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        Response.Redirect(Session("Button2_Click"))
    End Sub

    Private Sub Button3_Click(sender As Object, e As System.EventArgs) Handles Button3.Click
        Response.Redirect(Session("Button3_Click"))
    End Sub

    Private Sub Button4_Click(sender As Object, e As System.EventArgs) Handles Button4.Click
        Response.Redirect(Session("Button4_Click"))
    End Sub

    Private Sub Button5_Click(sender As Object, e As System.EventArgs) Handles Button5.Click
        Response.Redirect(Session("Button5_Click"))
    End Sub

    Private Sub Button6_Click(sender As Object, e As System.EventArgs) Handles Button6.Click
        Response.Redirect(Session("Button6_Click"))
    End Sub

    Private Sub Button7_Click(sender As Object, e As System.EventArgs) Handles Button7.Click
        Response.Redirect(Session("Button7_Click"))
    End Sub

    Private Sub Button8_Click(sender As Object, e As System.EventArgs) Handles Button8.Click
        Response.Redirect(Session("Button8_Click"))
    End Sub
End Class