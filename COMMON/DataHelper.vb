Imports System.Globalization

Public Class DataHelper


    Public Shared Function getSQLServerConnectionObject(ByVal connectionString As String) As SqlClient.SqlConnection
        Dim sqlConnection As New SqlClient.SqlConnection
        'If Not IsNothing(sqlConnection) AndAlso sqlConnection.State = ConnectionState.Open Then sqlConnection.Close()

        Try
            sqlConnection.ConnectionString = connectionString
            sqlConnection.Open()

            'Throw New Exception("Test Exception Error 88")

            Return sqlConnection
        Catch ex As Exception

            ' WriteLogFile("Call Function getSQLServerConnectionObject - " + ex.Message)

            Throw ex

        Finally
            sqlConnection.Close()
        End Try


    End Function

    Public Shared Function getOLEDBConnectionObject(ByVal connectionString As String) As OleDb.OleDbConnection
        Dim OLEDBConnection As New OleDb.OleDbConnection

        ' If Not IsNothing(OLEDBConnection) AndAlso OLEDBConnection.State = ConnectionState.Open Then OLEDBConnection.Close()

        Try
            OLEDBConnection.ConnectionString = connectionString
            OLEDBConnection.Open()

            Return OLEDBConnection

        Catch ex As Exception
            Throw ex
        Finally

            OLEDBConnection.Close()
        End Try

    End Function

    Public Shared Function WriteLogFile(ByVal Message As String, Optional ByVal LogFileName As String = "")

        Try
            Dim _AppSettingsReader As New System.Configuration.AppSettingsReader()

            Dim new_log_fiilename As String


            If LogFileName.Trim() <> "" Then
                new_log_fiilename = LogFileName.Trim()
            Else
                new_log_fiilename = _AppSettingsReader.GetValue("Path_Log_FileName", GetType(String)).ToString()
            End If


            Dim FileExt() As String = Split(new_log_fiilename, ".")

            Dim CurrentDate = DateTime.Now

            new_log_fiilename = FileExt(0) + CurrentDate.ToString("yyyy-MM-dd", New CultureInfo("en-US")) + "." + FileExt(1)


            Dim TargetPath_Log_FileName As String = AppDomain.CurrentDomain.BaseDirectory + _AppSettingsReader.GetValue("Path_Log_Folder", GetType(String)).ToString + new_log_fiilename

            Dim sCurrentDateTime = CurrentDate.ToString("yyyy-MM-dd HH:mm:ss", New CultureInfo("en-US"))


            Using writer As System.IO.StreamWriter = New System.IO.StreamWriter(TargetPath_Log_FileName, True)

                writer.WriteLine(sCurrentDateTime + " - " + Message)

            End Using

        Catch ex As Exception

            Throw ex

        Finally

        End Try

    End Function

End Class
