Imports MySql.Data.MySqlClient
Module InsertQueries
    Public Function InsertSingleQuery(ByVal Table As String, ByVal Fields As String, ByVal Values As String) As Boolean
        Dim ReturnThis As Boolean
        Try
            If ValidLocalConnection Then
                Dim ConnectionLocal As MySqlConnection = LocalhostConn()
                Dim sql = "INSERT INTO " & Table & "(" & Fields & ") VALUES (" & Values & ")"
                Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionLocal)
                Dim result = cmd.ExecuteNonQuery()
                If result > 0 Then
                    ReturnThis = True
                Else
                    ReturnThis = False
                End If
            Else
                ReturnThis = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ReturnThis = False
        End Try
        Return ReturnThis
    End Function

    Public Function InsertSingleQueryCloud(ByVal Table As String, ByVal Fields As String, ByVal Values As String) As String
        Dim sql = ""
        Try

            Dim ConnectionLocal As MySqlConnection = ServerCloudCon()
            sql = "INSERT INTO " & Table & "(" & Fields & ") VALUES (" & Values & ")"

            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionLocal)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return sql
    End Function

End Module
