Imports MySql.Data.MySqlClient
Module Connection
    Dim ConnStr As String
    Dim ConnStr2 As String
    Public LocServer As String
    Public LocUser As String
    Public LocPass As String
    Public LocDatabase As String
    Public LocPort As String
    Public Function LoadLocalConnection() As MySqlConnection
        Dim ConnectionLocal As MySqlConnection = New MySqlConnection
        Try
            ConnectionLocal.ConnectionString = LoadConn(My.Settings.LocalConnectionPath)
            ConnectionLocal.Open()
            If ConnectionLocal.State = ConnectionState.Open Then
                LocalhostConnectionAvailable = True
            End If
        Catch ex As Exception
            LocalhostConnectionAvailable = False

        End Try
        Return ConnectionLocal
    End Function
    Public Function LocalhostConn() As MySqlConnection
        Dim localconnection As MySqlConnection = New MySqlConnection
        Try
            If LocalhostConnectionAvailable Then
                localconnection.ConnectionString = LocalConnectionString
                localconnection.Open()

                If localconnection.State = ConnectionState.Open Then
                    ValidLocalConnection = True
                End If
            Else
                ValidLocalConnection = False
            End If

        Catch ex As Exception
            ValidLocalConnection = False
        End Try
        Return localconnection
    End Function

    Private Function LoadConn(Path As String)
        Try
            If My.Settings.LocalConnectionPath <> "" Then
                If System.IO.File.Exists(Path) Then
                    'The File exists 
                    Dim CreateConnString As String = ""
                    Dim filename As String = String.Empty
                    Dim TextLine As String = ""
                    Dim objReader As New System.IO.StreamReader(Path)
                    Dim lineCount As Integer
                    Do While objReader.Peek() <> -1
                        TextLine = objReader.ReadLine()
                        If lineCount = 0 Then
                            ConnStr = ConvertB64ToString(RemoveCharacter(TextLine, "server="))
                            ConnStr2 = "server=" & ConnStr
                            LocServer = ConnStr
                        End If
                        If lineCount = 1 Then
                            ConnStr = ConvertB64ToString(RemoveCharacter(TextLine, "user id="))
                            ConnStr2 += ";user id=" & ConnStr
                            LocUser = ConnStr
                        End If
                        If lineCount = 2 Then
                            ConnStr = ConvertB64ToString(RemoveCharacter(TextLine, "password="))
                            ConnStr2 += ";password=" & ConnStr
                            LocPass = ConnStr
                        End If
                        If lineCount = 3 Then
                            ConnStr = ConvertB64ToString(RemoveCharacter(TextLine, "database="))
                            ConnStr2 += ";database=" & ConnStr
                            LocDatabase = ConnStr
                        End If
                        If lineCount = 4 Then
                            ConnStr = ConvertB64ToString(RemoveCharacter(TextLine, "port="))
                            ConnStr2 += ";port=" & ConnStr
                            LocPort = ConnStr
                        End If
                        If lineCount = 5 Then
                            ConnStr2 += ";" & TextLine
                        End If
                        lineCount = lineCount + 1
                    Loop
                    LocalConnectionString = ConnStr2
                    objReader.Close()
                End If
            Else
                Dim path2 = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\HRBuddy\user.config"
                If System.IO.File.Exists(path2) Then
                    'The File exists 
                    Dim CreateConnString As String = ""
                    Dim filename As String = String.Empty
                    Dim TextLine As String = ""
                    Dim objReader As New System.IO.StreamReader(path2)
                    Dim lineCount As Integer
                    Do While objReader.Peek() <> -1
                        TextLine = objReader.ReadLine()
                        If lineCount = 0 Then
                            ConnStr = ConvertB64ToString(RemoveCharacter(TextLine, "server="))
                            ConnStr2 = "server=" & ConnStr
                        End If
                        If lineCount = 1 Then
                            ConnStr = ConvertB64ToString(RemoveCharacter(TextLine, "user id="))
                            ConnStr2 += ";user id=" & ConnStr
                        End If
                        If lineCount = 2 Then
                            ConnStr = ConvertB64ToString(RemoveCharacter(TextLine, "password="))
                            ConnStr2 += ";password=" & ConnStr
                        End If
                        If lineCount = 3 Then
                            ConnStr = ConvertB64ToString(RemoveCharacter(TextLine, "database="))
                            ConnStr2 += ";database=" & ConnStr
                        End If
                        If lineCount = 4 Then
                            ConnStr = ConvertB64ToString(RemoveCharacter(TextLine, "port="))
                            ConnStr2 += ";port=" & ConnStr
                        End If
                        If lineCount = 5 Then
                            ConnStr2 += ";" & TextLine
                        End If
                        lineCount = lineCount + 1
                    Loop
                    LocalConnectionString = ConnStr2
                    objReader.Close()
                    My.Settings.LocalConnectionPath = path2
                    My.Settings.LocalConnectionString = ConnStr2
                    My.Settings.Save()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ConnStr2
    End Function

    Public Function ServerCloudCon()
        Dim servercloudconn As MySqlConnection = New MySqlConnection
        Try
            Dim sql = "SELECT `C_Server`, `C_Username`, `C_Password`, `C_Database`, `C_Port` FROM tbl_settings WHERE settings_id = 1"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, LocalhostConn)
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable
            da.Fill(dt)
            CloudConnectionString = "server=" & ConvertB64ToString(dt(0)(0)) &
            ";userid= " & ConvertB64ToString(dt(0)(1)) &
            ";password=" & ConvertB64ToString(dt(0)(2)) &
            ";port=" & ConvertB64ToString(dt(0)(4)) &
            ";database=" & ConvertB64ToString(dt(0)(3))
            servercloudconn.ConnectionString = CloudConnectionString
            servercloudconn.Open()
            If servercloudconn.State = ConnectionState.Open Then
                ValidCloudConnection = True
            End If
        Catch ex As Exception
            ValidCloudConnection = False
        End Try
        Return servercloudconn
    End Function

End Module
