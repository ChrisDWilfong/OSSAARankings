Partial Class RankingsStatsWinter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strSQL As String
        Dim ds As DataSet
        Dim x As Integer
        Dim intWeek As Integer
        Dim strWeek As String

        Dim intBasketballBoysTotal As New Hashtable
        Dim intBasketballGirlsTotal As New Hashtable
        Dim intSwimmingBoysTotal As New Hashtable
        Dim intSwimmingGirlsTotal As New Hashtable
        Dim intWrestlingTotal As New Hashtable
        Dim intWrestlingDualTotal As New Hashtable

        Dim strStylePre As String = "<span style='font-family:verdana; font-size:9pt;'>"
        Dim strStyleSuf As String = "</span>"

        strSQL = "SELECT * FROM viewCoachesRanksDistinctPerWeekWinterSUM"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            For x = 0 To ds.Tables(0).Rows.Count - 1
                With ds.Tables(0).Rows(x)

                    Try
                        strWeek = .Item("WeekNo")
                        intWeek = CInt(strWeek.Replace("Week ", ""))
                    Catch ex As Exception
                        intWeek = 15
                    End Try

                    Select Case .Item("sportID")
                        ' BOYS BASKETBALL...
                        Case "BasketballBoys6A"
                            BasketballBoys6A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intBasketballBoysTotal(intWeek) = intBasketballBoysTotal(intWeek) + .Item("RankCount")
                        Case "BasketballBoys5A"
                            BasketballBoys5A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intBasketballBoysTotal(intWeek) = intBasketballBoysTotal(intWeek) + .Item("RankCount")
                        Case "BasketballBoys4A"
                            BasketballBoys4A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intBasketballBoysTotal(intWeek) = intBasketballBoysTotal(intWeek) + .Item("RankCount")
                        Case "BasketballBoys3A"
                            BasketballBoys3A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intBasketballBoysTotal(intWeek) = intBasketballBoysTotal(intWeek) + .Item("RankCount")
                        Case "BasketballBoys2A"
                            BasketballBoys2A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intBasketballBoysTotal(intWeek) = intBasketballBoysTotal(intWeek) + .Item("RankCount")
                        Case "BasketballBoysA"
                            BasketballBoysA.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intBasketballBoysTotal(intWeek) = intBasketballBoysTotal(intWeek) + .Item("RankCount")
                        Case "BasketballBoysB"
                            BasketballBoysB.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intBasketballBoysTotal(intWeek) = intBasketballBoysTotal(intWeek) + .Item("RankCount")

                            ' GIRLS BASKETBALL...
                        Case "BasketballGirls6A"
                            BasketballGirls6A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intBasketballGirlsTotal(intWeek) = intBasketballGirlsTotal(intWeek) + .Item("RankCount")
                        Case "BasketballGirls5A"
                            BasketballGirls5A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intBasketballGirlsTotal(intWeek) = intBasketballGirlsTotal(intWeek) + .Item("RankCount")
                        Case "BasketballGirls4A"
                            BasketballGirls4A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intBasketballGirlsTotal(intWeek) = intBasketballGirlsTotal(intWeek) + .Item("RankCount")
                        Case "BasketballGirls3A"
                            BasketballGirls3A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intBasketballGirlsTotal(intWeek) = intBasketballGirlsTotal(intWeek) + .Item("RankCount")
                        Case "BasketballGirls2A"
                            BasketballGirls2A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intBasketballGirlsTotal(intWeek) = intBasketballGirlsTotal(intWeek) + .Item("RankCount")
                        Case "BasketballGirlsA"
                            BasketballGirlsA.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intBasketballGirlsTotal(intWeek) = intBasketballGirlsTotal(intWeek) + .Item("RankCount")
                        Case "BasketballGirlsB"
                            BasketballGirlsB.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intBasketballGirlsTotal(intWeek) = intBasketballGirlsTotal(intWeek) + .Item("RankCount")

                            ' BOYS SWIMMING...
                        Case "SwimmingBoys6A"
                            SwimmingBoys6A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intSwimmingBoysTotal(intWeek) = intSwimmingBoysTotal(intWeek) + .Item("RankCount")
                        Case "SwimmingBoys5A"
                            SwimmingBoys5A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intSwimmingBoysTotal(intWeek) = intSwimmingBoysTotal(intWeek) + .Item("RankCount")

                            ' GIRLS SWIMMING...
                        Case "SwimmingGirls6A"
                            SwimmingGirls6A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intSwimmingGirlsTotal(intWeek) = intSwimmingGirlsTotal(intWeek) + .Item("RankCount")
                        Case "SwimmingGirls5A"
                            SwimmingGirls5A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intSwimmingGirlsTotal(intWeek) = intSwimmingGirlsTotal(intWeek) + .Item("RankCount")

                            ' WRESTLING...
                        Case "Wrestling6A"
                            Wrestling6A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intWrestlingTotal(intWeek) = intWrestlingTotal(intWeek) + .Item("RankCount")
                        Case "Wrestling5A"
                            Wrestling5A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intWrestlingTotal(intWeek) = intWrestlingTotal(intWeek) + .Item("RankCount")
                        Case "Wrestling4A"
                            Wrestling4A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intWrestlingTotal(intWeek) = intWrestlingTotal(intWeek) + .Item("RankCount")
                        Case "Wrestling3A"
                            Wrestling3A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intWrestlingTotal(intWeek) = intWrestlingTotal(intWeek) + .Item("RankCount")

                            ' WRESTLING DUAL...
                        Case "WrestlingDual6A"
                            WrestlingDual6A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intWrestlingDualTotal(intWeek) = intWrestlingTotal(intWeek) + .Item("RankCount")
                        Case "WrestlingDual5A"
                            WrestlingDual5A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intWrestlingDualTotal(intWeek) = intWrestlingTotal(intWeek) + .Item("RankCount")
                        Case "WrestlingDual4A"
                            WrestlingDual4A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intWrestlingDualTotal(intWeek) = intWrestlingTotal(intWeek) + .Item("RankCount")
                        Case "WrestlingDual3A"
                            WrestlingDual3A.Cells(intWeek).Text = strStylePre & .Item("RankCount") & strStylePre
                            intWrestlingDualTotal(intWeek) = intWrestlingTotal(intWeek) + .Item("RankCount")
                        Case Else
                    End Select
                End With
            Next
        End If

        ' Put the totals...
        For x = 1 To 14
            BasketballBoysTotal.Cells(x).Text = strStylePre & intBasketballBoysTotal(x) & strStyleSuf
            BasketballGirlsTotal.Cells(x).Text = strStylePre & intBasketballGirlsTotal(x) & strStyleSuf
            SwimmingBoysTotal.Cells(x).Text = strStylePre & intSwimmingBoysTotal(x) & strStyleSuf
            SwimmingGirlsTotal.Cells(x).Text = strStylePre & intSwimmingGirlsTotal(x) & strStyleSuf
            WrestlingTotal.Cells(x).Text = strStylePre & intWrestlingTotal(x) & strStyleSuf
            WrestlingDualTotal.Cells(x).Text = strStylePre & intWrestlingDualTotal(x) & strStyleSuf
            If x = 1 Then
                ' Swimming Only...
                GrandTotal.Cells(x).Text = strStylePre & (intSwimmingBoysTotal(x) + intSwimmingGirlsTotal(x)) & strStyleSuf
            ElseIf x = 2 Then
                GrandTotal.Cells(x).Text = strStylePre & (intBasketballBoysTotal(x - 1) + intBasketballGirlsTotal(x - 1) + intSwimmingBoysTotal(x) + intSwimmingGirlsTotal(x)) & strStyleSuf
            Else
                GrandTotal.Cells(x).Text = strStylePre & (intBasketballBoysTotal(x - 1) + intBasketballGirlsTotal(x - 1) + intSwimmingBoysTotal(x) + intSwimmingGirlsTotal(x) + intWrestlingTotal(x - 2) + intWrestlingDualTotal(x - 2)) & strStyleSuf
            End If

        Next


        lblDateTime.Text = Now

    End Sub

End Class