Imports System.IO
Imports System.Text
Imports System.Threading
Imports MySql.Data.MySqlClient

Public Class ConfigManager
    Dim LoadLocalConnData As Boolean
    Private Sub ConfigManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CheckForIllegalCrossThreadCalls = False
            LoadConn()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub LoadConn()
        Try
            If My.Settings.LocalConnectionPath <> "" Then
                If System.IO.File.Exists(My.Settings.LocalConnectionPath) Then
                    'The File exists 
                    Dim CreateConnString As String = ""
                    Dim filename As String = String.Empty
                    Dim TextLine As String = ""
                    Dim objReader As New System.IO.StreamReader(My.Settings.LocalConnectionPath)
                    Dim lineCount As Integer
                    Do While objReader.Peek() <> -1
                        TextLine = objReader.ReadLine()
                        If lineCount = 0 Then
                            TextBoxLocalServer.Text = ConvertB64ToString(RemoveCharacter(TextLine, "server="))
                        End If
                        If lineCount = 1 Then
                            TextBoxLocalUser.Text = ConvertB64ToString(RemoveCharacter(TextLine, "user id="))
                        End If
                        If lineCount = 2 Then
                            TextBoxLocalPassword.Text = ConvertB64ToString(RemoveCharacter(TextLine, "password="))
                        End If
                        If lineCount = 3 Then
                            TextBoxLocalDB.Text = ConvertB64ToString(RemoveCharacter(TextLine, "database="))
                        End If
                        If lineCount = 4 Then
                            TextBoxLocalPort.Text = ConvertB64ToString(RemoveCharacter(TextLine, "port="))
                        End If
                        lineCount = lineCount + 1
                    Loop
                    objReader.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub ButtonLocalTest_Click(sender As Object, e As EventArgs) Handles ButtonLocalTest.Click
        Try
            BackgroundWorkerTestLocal.WorkerReportsProgress = True
            BackgroundWorkerTestLocal.WorkerSupportsCancellation = True
            BackgroundWorkerTestLocal.RunWorkerAsync()
            TextboxEnableability(GroupBox1, False)
            ButtonEnableability(GroupBox1, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim thread As Thread
    Private Sub BackgroundWorkerTestLocal_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerTestLocal.DoWork
        Try
            For i = 0 To 100
                BackgroundWorkerTestLocal.ReportProgress(i)
                Thread.Sleep(50)
                If i = 10 Then
                    thread = New Thread(Sub() TestConn(True, Trim(TextBoxLocalServer.Text), Trim(TextBoxLocalUser.Text), Trim(TextBoxLocalPassword.Text), Trim(TextBoxLocalDB.Text), Trim(TextBoxLocalPort.Text)))
                    thread.Start()
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub TestConn(ByVal ConType As Boolean, ByVal Server As String, ByVal User As String, ByVal Pass As String, ByVal Db As String, ByVal Port As String)
        Dim Conn As MySqlConnection

        Try
            Conn = New MySqlConnection
            Conn.ConnectionString = "server=" & Server & ";user id=" & User & ";password=" & Pass & ";database=" & Db & ";port=" & Port & ";"
            Conn.Open()

            If Conn.State = ConnectionState.Open Then
                If ConType Then
                    ValidLocalConnection = True
                Else
                    ValidCloudConnection = True
                End If

            Else
                If ConType Then
                    ValidLocalConnection = False
                Else
                    ValidCloudConnection = False
                End If
            End If
        Catch ex As Exception
            If ConType Then
                ValidLocalConnection = False
            Else
                ValidCloudConnection = False
            End If
        End Try

    End Sub

    Private Sub BackgroundWorkerTestLocal_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerTestLocal.RunWorkerCompleted
        MsgBox(ValidLocalConnection)

        TextboxEnableability(GroupBox1, True)
        ButtonEnableability(GroupBox1, True)
        LoadLocalConnData = False
    End Sub
    Private Sub ButtonCloudTest_Click(sender As Object, e As EventArgs) Handles ButtonCloudTest.Click
        Try
            BackgroundWorkerTestCloud.WorkerReportsProgress = True
            BackgroundWorkerTestCloud.WorkerSupportsCancellation = True
            BackgroundWorkerTestCloud.RunWorkerAsync()
            TextboxEnableability(GroupBox2, False)
            ButtonEnableability(GroupBox2, False)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerTestCloud_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerTestCloud.DoWork
        Try
            For i = 0 To 100
                BackgroundWorkerTestCloud.ReportProgress(i)
                Thread.Sleep(50)
                If i = 10 Then
                    thread = New Thread(Sub() TestConn(False, Trim(TextBoxCloudServer.Text), Trim(TextBoxCloudUser.Text), Trim(TextBoxCloudPassword.Text), Trim(TextBoxCloudDB.Text), Trim(TextBoxCloudPort.Text)))
                    thread.Start()
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerTestCloud_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerTestCloud.RunWorkerCompleted
        MsgBox(ValidLocalConnection)
        TextboxEnableability(GroupBox2, True)
        ButtonEnableability(GroupBox2, True)
    End Sub
    Private Sub TextBoxLocalServer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxLocalPort.KeyPress, TextBoxLocalDB.KeyPress, TextBoxLocalPassword.KeyPress, TextBoxLocalUser.KeyPress, TextBoxLocalServer.KeyPress
        Try
            ValidLocalConnection = False
            If InStr(DisallowedCharacters, e.KeyChar) > 0 Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBoxCloudServer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxCloudUser.KeyPress, TextBoxCloudPassword.KeyPress, TextBoxCloudDB.KeyPress, TextBoxCloudPort.KeyPress, TextBoxCloudServer.KeyPress
        Try
            ValidCloudConnection = False
            If InStr(DisallowedCharacters, e.KeyChar) > 0 Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub ButtonLocalSave_Click(sender As Object, e As EventArgs) Handles ButtonLocalSave.Click
        SaveLocalConnection()
    End Sub

    Private Sub SaveLocalConnection()
        Try
            If ValidLocalConnection Then
                Dim FolderName As String = "HRBuddy"
                Dim path = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                CreateFolder(path, FolderName)
            Else
                MsgBox("Connection must be valid")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub CreateFolder(Path As String, FolderName As String, Optional ByVal Attributes As System.IO.FileAttributes = IO.FileAttributes.Normal)
        Try
            My.Computer.FileSystem.CreateDirectory(Path & "\" & FolderName)
            If Not Attributes = IO.FileAttributes.Normal Then
                My.Computer.FileSystem.GetDirectoryInfo(Path & "\" & FolderName).Attributes = Attributes
            End If
            CreateUserConfig(Path, "user.config", FolderName)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub CreateUserConfig(path As String, FileName As String, FolderName As String, Optional ByVal Attributes As System.IO.FileAttributes = IO.FileAttributes.Normal)
        Try
            Dim CompletePath As String = path & "\" & FolderName & "\" & "user.config"
            My.Computer.FileSystem.CreateDirectory(path & "\" & FolderName)
            If Not Attributes = IO.FileAttributes.Normal Then
                My.Computer.FileSystem.GetDirectoryInfo(path & "\" & FolderName).Attributes = Attributes
            End If
            Dim ConnString(5) As String
            ConnString(0) = "server=" & ConvertToBase64(Trim(TextBoxLocalServer.Text))
            ConnString(1) = "user id=" & ConvertToBase64(Trim(TextBoxLocalUser.Text))
            ConnString(2) = "password=" & ConvertToBase64(Trim(TextBoxLocalPassword.Text))
            ConnString(3) = "database=" & ConvertToBase64(Trim(TextBoxLocalDB.Text))
            ConnString(4) = "port=" & ConvertToBase64(Trim(TextBoxLocalPort.Text))
            ConnString(5) = "Allow Zero Datetime=True"
            File.WriteAllLines(CompletePath, ConnString, Encoding.UTF8)
            CreateConn(CompletePath)
            My.Settings.LocalConnectionPath = CompletePath
            My.Settings.Save()
            If LoadLocalConnData = False Then
                MsgBox("Saved")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub CreateConn(path As String)
        Try
            Dim CreateConnString As String = ""
            Dim filename As String = String.Empty
            Dim TextLine As String = ""
            Dim objReader As New System.IO.StreamReader(path)
            Dim lineCount As Integer
            Do While objReader.Peek() <> -1
                TextLine = objReader.ReadLine()
                If lineCount = 0 Then
                    CreateConnString += TextLine & ";"
                End If
                If lineCount = 1 Then
                    CreateConnString += TextLine & ";"
                End If
                If lineCount = 2 Then
                    CreateConnString += TextLine & ";"
                End If
                If lineCount = 3 Then
                    CreateConnString += TextLine & ";"
                End If
                If lineCount = 4 Then
                    CreateConnString += TextLine & ";"
                End If
                If lineCount = 5 Then
                    CreateConnString += TextLine
                End If
                lineCount = lineCount + 1
            Loop
            objReader.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function TestLocalConnection()
        Dim Conn As MySqlConnection = New MySqlConnection
        Try
            Conn.ConnectionString = "server=" & Trim(TextBoxLocalServer.Text) &
            ";user id= " & Trim(TextBoxLocalUser.Text) &
            ";password=" & Trim(TextBoxLocalPassword.Text) &
            ";database=" & Trim(TextBoxLocalDB.Text) &
            ";port=" & Trim(TextBoxLocalPort.Text)
            Conn.Open()
            If Conn.State = ConnectionState.Open Then
                ValidLocalConnection = True
                'LOCALCONNDATA = True
            End If
        Catch ex As Exception
            ValidLocalConnection = False
            'LOCALCONNDATA = False
        End Try
        Return Conn
    End Function
    Private Sub ButtonCloudSave_Click(sender As Object, e As EventArgs) Handles ButtonCloudSave.Click
        Try
            Dim table = "loc_settings"
            Dim where = "settings_id = 1"
            If ValidLocalConnection Then
                If ValidCloudConnection Then
                    Dim fields = "C_Server, C_Username, C_Password, C_Database, C_Port"
                    Dim Sql = "Select " & fields & " FROM " & table & " WHERE " & where
                    Dim cmd As MySqlCommand = New MySqlCommand(Sql, TestLocalConnection())
                    Dim da As MySqlDataAdapter = New MySqlDataAdapter(cmd)
                    Dim dt As DataTable = New DataTable
                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        fields = "C_Server = '" & ConvertToBase64(Trim(TextBoxCloudServer.Text)) & "', C_Username = '" & ConvertToBase64(Trim(TextBoxCloudUser.Text)) & "', C_Password = '" & ConvertToBase64(Trim(TextBoxCloudPassword.Text)) & "', C_Database = '" & ConvertToBase64(Trim(TextBoxCloudDB.Text)) & "', C_Port = '" & ConvertToBase64(Trim(TextBoxCloudPort.Text)) & "'"
                        Sql = "UPDATE " & table & " SET " & fields & " WHERE " & where
                        cmd = New MySqlCommand(Sql, TestLocalConnection())
                        cmd.ExecuteNonQuery()
                        'If CLOUDCONDATA = False Then
                        '    MsgBox("Saved!")
                        'End If
                    Else
                        fields = "(C_Server, C_Username, C_Password, C_Database, C_Port, S_Zreading)"
                        Dim value = "('" & ConvertToBase64(Trim(TextBoxCloudServer.Text)) & "'
                     ,'" & ConvertToBase64(Trim(TextBoxCloudUser.Text)) & "'
                     ,'" & ConvertToBase64(Trim(TextBoxCloudPassword.Text)) & "'
                     ,'" & ConvertToBase64(Trim(TextBoxCloudDB.Text)) & "'
                     ,'" & ConvertToBase64(Trim(TextBoxCloudPort.Text)) & "'
                     ,'" & Format(Now(), "yyyy-MM-dd") & "')"
                        Sql = "INSERT INTO " & table & " " & fields & " VALUES " & value
                        cmd = New MySqlCommand(Sql, TestLocalConnection)
                        cmd.ExecuteNonQuery()
                        'If CLOUDCONDATA = False Then
                        '    MsgBox("Saved!")
                        'End If
                    End If

                    TextboxEnableability(GroupBox2, False)

                Else
                    'FillUp = False
                    'BTNSaveCloudConn = False
                    MsgBox("Connection must be valid")
                End If
            Else
                MsgBox("Local connection must be valid first.")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class