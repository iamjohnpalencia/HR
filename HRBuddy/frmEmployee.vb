Imports System.Threading
Imports MySql.Data.MySqlClient

Public Class frmEmployee
    Private Sub frmEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        StartPosition = FormStartPosition.CenterScreen

        CheckForIllegalCrossThreadCalls = False

        If ValidCloudConnection Then
            ToolStripProgressBar1.Value = 0
            BackgroundWorkerpersonalinfo.WorkerReportsProgress = True
            BackgroundWorkerpersonalinfo.WorkerSupportsCancellation = True
            BackgroundWorkerpersonalinfo.RunWorkerAsync()
        End If
    End Sub
    Dim EmployeeLoaded As Boolean = False
    Dim PersonalDatatable As DataTable
    Private Sub LoadEmployee()
        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim sql = "SELECT first,mid,last FROM tblemployee LIMIT 50"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionServer)
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            PersonalDatatable = New DataTable
            da.Fill(PersonalDatatable)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim WorkerCancel As Boolean = False
    Dim threadlistpersonalinfo As List(Of Thread) = New List(Of Thread)
    Dim ThreadPersonal As Thread
    Private Sub BackgroundWorkerpersonalinfo_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerpersonalinfo.DoWork
        Try
            For i = 0 To 100
                BackgroundWorkerpersonalinfo.ReportProgress(i)
                Thread.Sleep(20)
                If WorkerCancel Then
                    Exit For
                End If
                If i = 0 Then
                    ToolStripStatusLabel1.Text = "Loading. Please wait."
                    ThreadPersonal = New Thread(Sub() LoadEmployee())
                    ThreadPersonal.Start()
                    threadlistpersonalinfo.Add(ThreadPersonal)
                End If
            Next
            For Each t In threadlistpersonalinfo
                t.Join()
                If (BackgroundWorkerpersonalinfo.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerpersonalinfo_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorkerpersonalinfo.ProgressChanged
        Try
            If WorkerCancel = False Then
                ToolStripProgressBar1.Value = e.ProgressPercentage
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerpersonalinfo_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerpersonalinfo.RunWorkerCompleted
        Try

            EmployeeLoaded = True
            TabControl1.Enabled = True
            ToolStripStatusLabel1.Text = "Complete"
            DataGridView1.Rows.Clear()
            With PersonalDatatable

                For Each row As DataRow In .Rows
                    If WorkerCancel Then
                        Exit For
                    End If
                    DataGridView1.Rows.Add(row("first"), row("mid"), row("last"))
                Next
            End With

            If WorkerCancel Then
                Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmEmployee_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If BackgroundWorkerpersonalinfo.IsBusy Then
                Dim msg = MessageBox.Show("Are you sure do you want to cancel sync ?", "Cancel Sync", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If msg = DialogResult.Yes Then
                    If BackgroundWorkerpersonalinfo.IsBusy Then
                        BackgroundWorkerpersonalinfo.CancelAsync()
                    End If
                    WorkerCancel = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class