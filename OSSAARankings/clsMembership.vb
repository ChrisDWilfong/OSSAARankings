Public Class clsMembership

    Shared Function GetCopyright() As String
        Return "Copyright © 2019 OSSAA. All rights reserved."
    End Function

    Shared Function FindSchoolId(intKey As Integer) As Integer
        Dim strSQL As String
        Dim idSchool As Integer

        strSQL = "SELECT schoolID FROM tblSchool WHERE Id = " & intKey
        Try
            idSchool = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)
        Catch
            idSchool = 0
        End Try
        Return idSchool

    End Function

    Shared Function GetVotingDelegateInfo(intSchoolID As Integer) As String
        Dim strSQL As String = "SELECT VotingFirst, VotingLast, VotingPosition, VotingOther, Quadrant, Division FROM tblSchool WHERE tblSchool.schoolID = " & intSchoolID
        ' Changed 1/23/2019...
        'Dim strSQL As String = "SELECT prodSchools.strSchoolName AS SchoolName, CASE WHEN prodSchools.strQuadrant Is Null THEN 'NONE' ELSE prodSchools.strQuadrant END AS strQuadrant, prodSchools.intDivision AS Division, tblSchool.VotingFirst, tblSchool.VotingPosition, tblSchool.VotingOther, tblSchool.VotingLast, [VotingFirst] + ' ' + [VotingLast] AS VotingDelegate, prodSchools.strSchoolAbb FROM prodSchools LEFT JOIN tblSchool ON prodSchools.schoolID = tblSchool.schoolID WHERE tblSchool.schoolID = " & intSchoolID
        Dim ds As DataSet
        Dim intDivision As Integer = 0
        Dim strQuadrant As String = "NONE"
        Dim strReturn As String = ""

        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnectionOSSAA, CommandType.Text, strSQL)

        If ds Is Nothing Then
        ElseIf ds.Tables.Count = 0 Then
        ElseIf ds.Tables(0).Rows.Count = 0 Then
        Else
            Try
                strSQL = "SELECT intDivision FROM prodSchools WHERE schoolID = " & intSchoolID
                intDivision = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
            Catch

            End Try
            Try
                strSQL = "SELECT strQuadrant FROM prodSchools WHERE schoolID = " & intSchoolID
                strQuadrant = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAAServer, CommandType.Text, strSQL)
            Catch

            End Try

            With ds.Tables(0).Rows(0)
                If .Item("VotingPosition") Is System.DBNull.Value Then
                    strReturn = .Item("VotingFirst") & " " & .Item("VotingLast") & " (" & .Item("VotingOther") & ") : DIVISION " & intDivision & " - QUADRANT " & strQuadrant
                ElseIf .Item("VotingPosition") = "" Then
                    strReturn = .Item("VotingFirst") & " " & .Item("VotingLast") & " (" & .Item("VotingOther") & ") : DIVISION " & intDivision & " - QUADRANT " & strQuadrant
                Else
                    strReturn = .Item("VotingFirst") & " " & .Item("VotingLast") & " (" & .Item("VotingPosition") & ") : DIVISION " & intDivision & " - QUADRANT " & strQuadrant
                End If
            End With
        End If

        Return strReturn

    End Function

    Public Shared Function GetSchoolNameFromKey(ByVal intKey As Integer) As String
        Dim strSchool As String = ""
        Dim strSQL As String

        strSQL = "SELECT Schoolname FROM tblSchool WHERE Id = " & intKey
        strSchool = SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL)

        Return strSchool

    End Function

    Shared Function IsLoginADuplicate(ByVal strUsernameIn As String, ByVal strPasswordIn As String, ByVal intKey As Integer, ByVal strType As String, ysnConfirmed As Boolean) As Boolean
        Dim boolDuplicate As Boolean = False
        Dim strSQL As String
        Dim strSQLKey As String = ""
        Dim intKeyFind As Integer = 0

        If intKey > 0 Then
            strSQLKey = " And Not (Id = " & intKey & ")"
        End If

        ' Duplicate somewhere else???
        If intKey > 0 Then
            strSQL = "SELECT Id FROM tblSchool WHERE AdminSuperEmail = '" & strUsernameIn & "' AND (Password1 = '" & strPasswordIn & "' OR Password2 = '" & strPasswordIn & "' OR Password3 = '" & strPasswordIn & "')"
            strSQL = strSQL & strSQLKey
        Else
            strSQL = "SELECT Id FROM tblSchool WHERE AdminSuperEmail = '" & strUsernameIn & "' AND (Password1 = '" & strPasswordIn & "' OR Password2 = '" & strPasswordIn & "' OR Password3 = '" & strPasswordIn & "')"
        End If
        If SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL) > 0 Then
            boolDuplicate = True
        Else
            If intKey > 0 Then
                strSQL = "SELECT Id FROM tblSchool WHERE AdminPrincipalEmail = '" & strUsernameIn & "' AND (Password1 = '" & strPasswordIn & "' OR Password2 = '" & strPasswordIn & "' OR Password3 = '" & strPasswordIn & "')"
                strSQL = strSQL & strSQLKey
            Else
                strSQL = "SELECT Id FROM tblSchool WHERE AdminPrincipalEmail = '" & strUsernameIn & "' AND (Password1 = '" & strPasswordIn & "' OR Password2 = '" & strPasswordIn & "' OR Password3 = '" & strPasswordIn & "')"
            End If
            If SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL) > 0 Then
                boolDuplicate = True
            Else
                If intKey > 0 Then
                    strSQL = "SELECT Id FROM tblSchool WHERE AdminADEmail = '" & strUsernameIn & "' AND (Password1 = '" & strPasswordIn & "' OR Password2 = '" & strPasswordIn & "' OR Password3 = '" & strPasswordIn & "')"
                    strSQL = strSQL & strSQLKey
                Else
                    strSQL = "SELECT Id FROM tblSchool WHERE AdminADEmail = '" & strUsernameIn & "' AND (Password1 = '" & strPasswordIn & "' OR Password2 = '" & strPasswordIn & "' OR Password3 = '" & strPasswordIn & "')"
                End If
                If SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL) > 0 Then
                    boolDuplicate = True
                End If
            End If
        End If

        ' If found, make sure it is not in this record...
        If ysnConfirmed = False Then

        Else
            If boolDuplicate = False Then
                Select Case strType
                    Case "SUPER", "Superintendent"
                        strSQL = "SELECT Id FROM tblSchool WHERE (AdminPrincipalEmail = '" & strUsernameIn & "' And Password2 = '" & strPasswordIn & "') OR (AdminADEmail = '" & strUsernameIn & "' And Password3='" & strPasswordIn & "')"
                    Case "PRINCIPAL", "High School Principal"
                        strSQL = "SELECT Id FROM tblSchool WHERE (AdminSuperEmail = '" & strUsernameIn & "' And Password1 = '" & strPasswordIn & "') OR (AdminADEmail = '" & strUsernameIn & "' And Password3='" & strPasswordIn & "')"
                    Case "AD", "Athletic Director"
                        strSQL = "SELECT Id FROM tblSchool WHERE (AdminSuperEmail = '" & strUsernameIn & "' And Password1 = '" & strPasswordIn & "') OR (AdminPrincipalEmail = '" & strUsernameIn & "' And Password2='" & strPasswordIn & "')"
                End Select
                If SqlHelper.ExecuteScalar(SqlHelper.SQLConnectionOSSAA, System.Data.CommandType.Text, strSQL) > 0 Then
                    boolDuplicate = True
                End If
            End If
        End If

        Return boolDuplicate

    End Function

    Shared Function InvoiceTotalString(ByVal intKey As Long) As String
        Dim strReturn As String
        strReturn = "&nbsp;&nbsp;&nbsp;Submission Form Total = $" & InvoiceTotal(intKey)
        Return strReturn
    End Function

    Shared Function InvoiceTotal(ByVal intKey As Long) As Integer
        Dim strSQL As String
        Dim intTotal As Integer = 0
        strSQL = "SELECT SUM(intCost) AS InvoiceTotal FROM tblPassDetails WHERE PassHeaderId = " & intKey & " AND (SpousePaidStatus = 'UNPAID' OR PaidStatus = 'UNPAID')"
        Try
            intTotal = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, System.Data.CommandType.Text, strSQL)
        Catch
            intTotal = 0
        End Try
        Return intTotal
    End Function

    Shared Function InvoiceBalanceString(ByVal intKey As Long) As String
        Dim strReturn As String
        strReturn = "Balance = $" & InvoiceTotal(intKey)
        Return strReturn
    End Function

    Shared Function GetInvoiceNumber() As String
        Dim intInvoice As Integer = 1
        Dim strInvoice As String

        ' Get Last ID...
        intInvoice = SqlHelper.ExecuteScalar(SqlHelper.SQLConnection, System.Data.CommandType.Text, "SELECT TOP 1 Id FROM tblPassHeader ORDER BY Id DESC")

        If intInvoice = 0 Then intInvoice = 1

        strInvoice = "CP-" & Format(intInvoice, "000#") & "-10"

        Return strInvoice
    End Function

    Shared Function GetInvoiceNumberFromKey(ByVal intKey As Integer) As String
        Dim strInvoice As String

        strInvoice = "CP-" & Format(intKey, "000#") & "-10"

        Return strInvoice
    End Function

    Shared Sub AutomaticallyAddDetail(ByVal strCategory As String, ByVal intKey As Long, ByVal ysnAutomaticallyAdd As Boolean, ByVal strPosition As String, ByVal strType As String, ByVal intGridNumber As Integer)
        ' Some details have to be automatically added:
        ' Example : Superintendent add Type = 'SUPER' and Position = 'Superintendent'
        '           
        Dim strSQL As String
        Dim intReturn As Integer

        Select Case strCategory
            Case "Coach"
                ' Check and Add Coach Record...
                If ysnAutomaticallyAdd Then
                    strSQL = "INSERT INTO tblCoaches (SchoolID, intYear, Position) VALUES ("
                    strSQL = strSQL & intKey & ", "
                    strSQL = strSQL & "12, "
                    ' Set the Default Position...
                    If strPosition = "" Then
                        strSQL = strSQL & "'Select...')"
                    Else
                        strSQL = strSQL & "'" & strPosition & "')"
                    End If
                    intReturn = SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, Data.CommandType.Text, strSQL)
                Else
                    ' Check first...
                End If
            Case "Superintendent"
                ' Check and Add Superintendent record...
                If ysnAutomaticallyAdd Then
                    strSQL = "INSERT INTO tblPassDetails (PassHeaderId, strCategory, Type, Status, PaidStatus, Position) VALUES ("
                    strSQL = strSQL & intKey & ", "
                    strSQL = strSQL & "'" & strCategory & "', "
                    strSQL = strSQL & "'SUPER', "
                    strSQL = strSQL & "'Requested', "
                    strSQL = strSQL & "'Free', "
                    ' Set the Default Position...
                    If strPosition = "" Then
                        strSQL = strSQL & "'Superintendent')"
                    Else
                        strSQL = strSQL & "'" & strPosition & "')"
                    End If
                    intReturn = SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, Data.CommandType.Text, strSQL)
                Else
                    ' Check first...
                End If
            Case "5A/6A Athletic Director"
                ' Check and Add  record...
                If ysnAutomaticallyAdd Then

                    strSQL = "INSERT INTO tblPassDetails (PassHeaderId, strCategory, Type, Status, PaidStatus, Position) VALUES ("
                    strSQL = strSQL & intKey & ", "
                    strSQL = strSQL & "'" & strCategory & "', "
                    strSQL = strSQL & "'COACH', "
                    strSQL = strSQL & "'Requested', "
                    strSQL = strSQL & "'Free', "
                    ' Set the Default Position...
                    If strPosition = "" Then
                        strSQL = strSQL & "'Select...')"
                    Else
                        strSQL = strSQL & "'" & strPosition & "')"
                    End If
                    intReturn = SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, Data.CommandType.Text, strSQL)
                Else
                    ' Check first...
                End If
            Case "5A/6A Junior High Principal"
                If ysnAutomaticallyAdd Then
                    ' Automatically add for Principal...
                    strSQL = "INSERT INTO tblPassDetails (PassHeaderId, strCategory, Type, Status, PaidStatus, Position) VALUES ("
                    strSQL = strSQL & intKey & ", "
                    strSQL = strSQL & "'" & strCategory & "', "
                    If strType = "" Then
                        strSQL = strSQL & "'COACH', "
                    Else
                        strSQL = strSQL & "'" & strType & "', "
                    End If
                    strSQL = strSQL & "'Requested', "
                    strSQL = strSQL & "'Free', "
                    ' Set the Default Position...
                    If strPosition = "" Then
                        strSQL = strSQL & "'Select...')"
                    Else
                        strSQL = strSQL & "'" & strPosition & "')"
                    End If
                    intReturn = SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, Data.CommandType.Text, strSQL)
                Else
                    ' Check first...
                End If

            Case "6A High School Principal", "5A High School Principal"
                ' Check and Add  record...
                If ysnAutomaticallyAdd Then

                    strSQL = "INSERT INTO tblPassDetails (PassHeaderId, strCategory, Type, Status, PaidStatus, Position) VALUES ("
                    strSQL = strSQL & intKey & ", "
                    strSQL = strSQL & "'" & strCategory & "', "
                    strSQL = strSQL & "'ADMIN', "
                    strSQL = strSQL & "'Requested', "
                    strSQL = strSQL & "'Free', "
                    ' Set the Default Position...
                    If strPosition = "" Then
                        strSQL = strSQL & "'Select...')"
                    Else
                        strSQL = strSQL & "'" & strPosition & "')"
                    End If
                    intReturn = SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, Data.CommandType.Text, strSQL)
                Else
                    ' Check first...
                End If

            Case "4A High School Principal", "3A High School Principal", "2A High School Principal", "A High School Principal", "B High School Principal"
                If ysnAutomaticallyAdd Then

                    If intGridNumber = 0 Or intGridNumber = 1 Then
                        strSQL = "INSERT INTO tblPassDetails (PassHeaderId, strCategory, Type, Status, PaidStatus, Position) VALUES ("
                        strSQL = strSQL & intKey & ", "
                        strSQL = strSQL & "'" & strCategory & "', "
                        If strType = "" Then
                            strSQL = strSQL & "'ADMIN', "
                        Else
                            strSQL = strSQL & "'" & strType & "', "
                        End If
                        strSQL = strSQL & "'Requested', "
                        strSQL = strSQL & "'Free', "
                        ' Set the Default Position...
                        If strPosition = "" Then
                            strSQL = strSQL & "'Select...')"
                        Else
                            strSQL = strSQL & "'" & strPosition & "')"
                        End If
                        intReturn = SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, Data.CommandType.Text, strSQL)
                    End If

                    If intGridNumber = 0 Or intGridNumber = 2 Then
                        strSQL = "INSERT INTO tblPassDetails (PassHeaderId, strCategory, Type, Status, PaidStatus, Position) VALUES ("
                        strSQL = strSQL & intKey & ", "
                        strSQL = strSQL & "'" & strCategory & "', "
                        If strType = "" Then
                            strSQL = strSQL & "'COACH', "
                        Else
                            strSQL = strSQL & "'" & strType & "', "
                        End If
                        strSQL = strSQL & "'Requested', "
                        strSQL = strSQL & "'Free', "
                        ' Set the Default Position...
                        If strPosition = "" Then
                            strSQL = strSQL & "'Select...')"
                        Else
                            strSQL = strSQL & "'" & strPosition & "')"
                        End If
                        intReturn = SqlHelper.ExecuteNonQuery(SqlHelper.SQLConnectionOSSAA, Data.CommandType.Text, strSQL)
                    End If
                Else
                    ' Check first...
                End If
            Case Else

        End Select

    End Sub

    Shared Function DeleteTheRow(ByVal strCategory As String, ByVal strPosition As String) As Boolean
        Dim ysnCancel As Boolean = False

        Select Case strCategory
            Case "Superintendent"
                If strPosition = "Superintendent" Then
                    ysnCancel = True
                End If
            Case "5A/6A Athletic Director"
                If strPosition = "Athletic Director" Then
                    ysnCancel = True
                End If
            Case "5A/6A Junior High Principal"
                If strPosition = "Principal - Junior High" Or strPosition = "Principal -  Junior High" Then
                    ysnCancel = True
                End If
            Case "6A High School Principal"
                If strPosition = "Principal - High School" Then
                    ysnCancel = True
                End If
            Case "5A High School Principal"
                If strPosition = "Principal - High School" Then
                    ysnCancel = True
                End If
            Case "4A High School Principal"
                If strPosition = "Principal - High School" Then
                    ysnCancel = True
                End If
            Case "3A High School Principal"
                If strPosition = "Principal - High School" Then
                    ysnCancel = True
                End If
            Case "2A High School Principal"
                If strPosition = "Principal - High School" Then
                    ysnCancel = True
                End If
            Case "A High School Principal"
                If strPosition = "Principal - High School" Then
                    ysnCancel = True
                End If
            Case "B High School Principal"
                If strPosition = "Principal - High School" Then
                    ysnCancel = True
                End If
            Case Else

        End Select

        Return ysnCancel

    End Function


    Public Shared Function AssignPassword(ByVal strSchoolIn As String, ByVal strType As String, ByVal intKey As String) As String
        Dim strPassword As String
        Dim strSchool As String
        Dim strPrefix As String

        strSchool = strSchoolIn.Replace(" ", "")

        If strType = "SUPER" Then
            strPrefix = "S"
        ElseIf strType = "PRINCIPAL" Then
            strPrefix = "P"
        ElseIf strType = "AD" Then
            strPrefix = "A"
        Else
            strPrefix = "N"
        End If

        strPassword = strPrefix & intKey & Left(strSchool, 3)

        Return strPassword

    End Function

End Class
