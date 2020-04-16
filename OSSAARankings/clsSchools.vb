Public Class clsSchools

    Shared Function GetSchoolsDS() As DataSet
        Dim strSQL As String
        Dim ds As DataSet

        strSQL = "SELECT SchoolID, SchoolName FROM tblSchool WHERE OrganizationType = 'SCHOOL' ORDER BY SchoolName"
        ds = SqlHelper.ExecuteDataset(SqlHelper.SQLConnection, CommandType.Text, strSQL)

        Return ds

    End Function

End Class
