Imports System.Threading
Imports MySql.Data.MySqlClient

Public Class UserLogs
    Dim threadListAction As List(Of Thread) = New List(Of Thread)
    Dim threadListLogs As List(Of Thread) = New List(Of Thread)
    Dim ThreadAction As Thread
    Dim ThreadLogs As Thread
    Dim UserActionDatatable As DataTable = New DataTable
    Dim UserLogsDatatable As DataTable = New DataTable

    Dim WorkerCancel As Boolean = False
    Private Sub UserLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            WindowState = FormWindowState.Maximized
            StartPosition = FormStartPosition.CenterScreen
            CheckForIllegalCrossThreadCalls = False

            If ValidCloudConnection Then
                If TabControl1.SelectedIndex = 0 Then
                    ToolStripProgressBar1.Value = 0
                    BackgroundWorker1.WorkerReportsProgress = True
                    BackgroundWorker1.WorkerSupportsCancellation = True
                    BackgroundWorker1.RunWorkerAsync()
                    ToolStrip1.Enabled = False
                    TabControl1.Enabled = False
                Else
                    ToolStripProgressBar1.Value = 0
                    BackgroundWorker2.WorkerReportsProgress = True
                    BackgroundWorker2.WorkerSupportsCancellation = True
                    BackgroundWorker2.RunWorkerAsync()
                    ToolStrip1.Enabled = False
                    TabControl1.Enabled = False
                End If

            Else
                ToolStripStatusLabel1.Text = "Cloud connection failed. Setup cloud database connection first."
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If ValidCloudConnection Then
            If TabControl1.SelectedIndex = 0 Then
                ToolStripProgressBar1.Value = 0
                BackgroundWorker1.WorkerReportsProgress = True
                BackgroundWorker1.WorkerSupportsCancellation = True
                BackgroundWorker1.RunWorkerAsync()
                ToolStrip1.Enabled = False
                TabControl1.Enabled = False
            Else
                ToolStripProgressBar1.Value = 0
                BackgroundWorker2.WorkerReportsProgress = True
                BackgroundWorker2.WorkerSupportsCancellation = True
                BackgroundWorker2.RunWorkerAsync()
                ToolStrip1.Enabled = False
                TabControl1.Enabled = False

            End If

        Else
            ToolStripStatusLabel1.Text = "Cloud connection failed. Setup cloud database connection first."
        End If
    End Sub
    Private Sub GetLogs()
        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim sql = "SELECT * FROM tbluserlogs WHERE logtype NOT IN ('IN','OUT') LIMIT 50"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionServer)
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            da.Fill(UserActionDatatable)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            For i = 0 To 100
                BackgroundWorker1.ReportProgress(i)
                Thread.Sleep(20)
                If WorkerCancel Then
                    Exit For
                End If
                If i = 0 Then
                    ToolStripStatusLabel1.Text = "Loading. Please wait."
                    ThreadAction = New Thread(Sub() GetLogs())
                    ThreadAction.Start()
                    threadListAction.Add(ThreadAction)
                End If
            Next
            For Each t In threadListAction
                t.Join()
                If (BackgroundWorker1.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Try
            If WorkerCancel = False Then
                ToolStripProgressBar1.Value = e.ProgressPercentage
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            TabControl1.Enabled = True
            ToolStripStatusLabel1.Text = "Complete"
            DataGridView1.Rows.Clear()
            For Each row As DataRow In UserActionDatatable.Rows
                If WorkerCancel Then
                    Exit For
                End If
                DataGridView1.Rows.Add(row("logid"), row("localid"), row("localregdate"), row("companyname"), row("devicename"), row("usercode"), row("address"), row("logtype"), row("logdesc"), row("longitude"), row("latitude"), row("image"), row("createdat"), row("status"))
            Next
            If WorkerCancel Then
                Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SyncToolStripMenuItem_Click(sender As Object, e As EventArgs)
        BackgroundWorker2.WorkerReportsProgress = True
        BackgroundWorker2.WorkerSupportsCancellation = True
        BackgroundWorker2.RunWorkerAsync()
    End Sub
    Private Sub FetchUserLogs()
        Try

            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim sql = "SELECT `logid`, `localid`, `localregdate`, `companyname`, `devicename`, `usercode`, `address`, `logtype`, `logdesc`, `longitude`, `latitude`, `createdat`, `status` FROM tbluserlogs WHERE logtype IN ('IN','OUT') LIMIT 50"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionServer)
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            da.Fill(UserLogsDatatable)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        For i = 0 To 100
            BackgroundWorker2.ReportProgress(i)
            Thread.Sleep(20)
            If i = 0 Then
                ToolStripStatusLabel1.Text = "Loading. Please wait."
                ThreadLogs = New Thread(AddressOf FetchUserLogs)
                ThreadLogs.Start()
                threadListLogs.Add(ThreadLogs)
            End If
        Next
        For Each t In threadListLogs
            t.Join()
            If (BackgroundWorker2.CancellationPending) Then
                ' Indicate that the task was canceled.

                e.Cancel = True
                Exit For
            End If
        Next
    End Sub
    Private Sub BackgroundWorker2_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        Try
            If WorkerCancel = False Then
                ToolStripProgressBar1.Value = e.ProgressPercentage
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        Try
            TabControl1.Enabled = True
            ToolStripStatusLabel1.Text = "Complete"
            DataGridView2.Rows.Clear()
            For Each row As DataRow In UserLogsDatatable.Rows
                If WorkerCancel Then
                    Exit For
                End If
                DataGridView2.Rows.Add(row("logid"), row("localid"), row("localregdate"), row("companyname"), row("devicename"), row("usercode"), row("address"), row("logtype"), row("logdesc"), row("longitude"), row("latitude"), row("createdat"), row("status"))
            Next

            If WorkerCancel Then
                Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Try
            Dim logid = DataGridView2.SelectedRows(0).Cells(0).Value
            Dim ImageString = SelectImage(logid)
            PictureBox1.Image = Base64ToImage(ImageString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function SelectImage(logid) As String
        Dim Image As String = ""
        Try
            Dim ServerCon As MySqlConnection = ServerCloudCon()
            Dim sql = "SELECT image FROM tbluserlogs WHERE logid = " & logid
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ServerCon)

            Using reader As MySqlDataReader = cmd.ExecuteReader
                If reader.HasRows Then
                    While reader.Read()
                        Image = reader("image")
                    End While
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return Image
    End Function

    Private Sub UserLogs_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If BackgroundWorker1.IsBusy Or BackgroundWorker2.IsBusy Then
                Dim msg = MessageBox.Show("Are you sure do you want to cancel sync ?", "Cancel Sync", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If msg = DialogResult.Yes Then
                    If BackgroundWorker1.IsBusy Then
                        BackgroundWorker1.CancelAsync()
                    End If
                    If BackgroundWorker2.IsBusy Then
                        BackgroundWorker2.CancelAsync()
                    End If
                    WorkerCancel = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class