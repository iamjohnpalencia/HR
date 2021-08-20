Imports MySql.Data.MySqlClient
Module Delete
    Public Function DeleteLocal(ByVal Table As String, ByVal Expression As String) As String
        Dim ReturnThis As Boolean = False
        Try
            If ValidLocalConnection Then
                Dim ConnectionLocal As MySqlConnection = LocalhostConn()
                Dim sql = "DELETE FROM " & Table & " WHERE " & Expression
                Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionLocal)
                Dim result = cmd.ExecuteNonQuery()
                If result > 0 Then
                    ReturnThis = True
                Else
                    ReturnThis = False
                End If
            Else
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ReturnThis = False
        End Try
        Return ReturnThis
    End Function

    Public Function DeleteCloud(ByVal Table As String, ByVal Expression As String) As Boolean
        Dim ReturnThis As Boolean = False
        Try
            Dim ConnectionLocal As MySqlConnection = ServerCloudCon()
            Dim sql = "DELETE FROM " & Table & " WHERE " & Expression
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionLocal)
            Dim result = cmd.ExecuteNonQuery()
            If result > 0 Then
                ReturnThis = True
            Else
                ReturnThis = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ReturnThis = False
        End Try
        Return ReturnThis
    End Function
End Module
