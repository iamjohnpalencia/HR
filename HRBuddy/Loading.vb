Imports System.Threading

Public Class Loading
    Private Sub Loading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CheckForIllegalCrossThreadCalls = False
            BackgroundWorker1.WorkerReportsProgress = True
            BackgroundWorker1.WorkerSupportsCancellation = True
            BackgroundWorker1.RunWorkerAsync()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim thread As Thread
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            For i = 0 To 100

                BackgroundWorker1.ReportProgress(i)
                Thread.Sleep(50)

                If i = 0 Then
                    LoadLocalConnection()
                    Label3.Text = "Connecting to local database."
                End If

                If i = 20 Then
                    If LocalhostConnectionAvailable Then
                        Label3.Text = "Connected to local database."
                    Else
                        Label3.Text = "Connection failed."
                    End If
                End If

                If i = 40 Then
                    If LocalhostConnectionAvailable Then
                        ServerCloudCon()
                        Label3.Text = "Connecting to cloud database."

                    End If
                End If

                If i = 60 Then
                    If LocalhostConnectionAvailable Then
                        If ValidCloudConnection Then
                            Label3.Text = "Connected to cloud database."
                        Else
                            Label3.Text = "Cloud server connection failed."
                        End If
                    End If
                End If

                If i = 80 Then
                    If LocalhostConnectionAvailable Then
                        Label3.Text = "Loading."
                    Else
                        Label3.Text = "Please set up database connections first."
                    End If
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Try
            Label1.Text = e.ProgressPercentage
            ProgressBar1.Value = e.ProgressPercentage
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If LocalhostConnectionAvailable Then
            Login.Show()
            Close()
        Else
            ConfigManager.Show()
            Close()
        End If
    End Sub
End Class