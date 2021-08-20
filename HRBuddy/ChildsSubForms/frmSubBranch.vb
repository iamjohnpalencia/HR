Imports System.Threading
Imports MySql.Data.MySqlClient

Public Class frmSubBranch
    Private Sub frmSubBranch_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Home.newMDIchildGroups.Enabled = True
        Home.Enabled = True
    End Sub
    Dim CompanyID As String
    Public UpBranchName As String
    Public UpBranchCompanyName As String
    Public UpBranchAddress As String
    Public UpBranchDesc As String
    Public UpBranchID

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BlankFields(Me) Then
            MsgBox("Fill up all fields")
        Else
            If ComboBox1.SelectedIndex = -1 Then
                MsgBox("Select company name first")
            Else
                If ValidCloudConnection Then
                    BackgroundWorker2.WorkerReportsProgress = True
                    BackgroundWorker2.WorkerSupportsCancellation = True
                    BackgroundWorker2.RunWorkerAsync()
                    Enabled = False
                Else
                    MsgBox("Cloud server connection must be valid first")
                End If
            End If

        End If
    End Sub

    Private Sub frmSubBranch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            For Each str As String In CompanyArray
                ComboBox1.Items.Add(str)
            Next

            If UPDATEBRANCHDETAILS Then
                TextBoxBranchName.Text = UpBranchName
                TextBoxBranchAddress.Text = UpBranchAddress
                TextBoxBranchDesc.Text = UpBranchDesc
                ComboBox1.SelectedIndex = ComboBox1.FindStringExact(UpBranchCompanyName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim threadListBranch As List(Of Thread) = New List(Of Thread)
    Dim ThreadBranch As Thread
    Dim WorkerCancel As Boolean = False
    Dim returnBool As String
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
                    If UPDATEBRANCHDETAILS Then
                        ThreadBranch = New Thread(Sub() UpdateBranch())
                        ThreadBranch.Start()
                        threadListBranch.Add(ThreadBranch)
                    Else
                        ThreadBranch = New Thread(Sub() InsertBranch())
                        ThreadBranch.Start()
                        threadListBranch.Add(ThreadBranch)
                    End If

                End If
            Next
            For Each t In threadListBranch
                t.Join()
                If (BackgroundWorker1.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Try
            ToolStripProgressBar1.Value = e.ProgressPercentage
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            Enabled = True
            Home.newMDIchildGroups.ToolStripProgressBar1.Value = 0
            Home.newMDIchildGroups.BackgroundWorkerBranch.WorkerReportsProgress = True
            Home.newMDIchildGroups.BackgroundWorkerBranch.WorkerSupportsCancellation = True
            Home.newMDIchildGroups.BackgroundWorkerBranch.RunWorkerAsync()
            Home.newMDIchildGroups.TabControl1.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub InsertBranch()
        Try
            Dim Fields = "company_id,branch_name,address,description,createdat,updatedat,creator,status"
            Dim Values = "'" & CompanyID & "','" & Trim(TextBoxBranchName.Text) &
            "','" & Trim(TextBoxBranchAddress.Text) & "','" & Trim(TextBoxBranchDesc.Text) & "','" & FullDate24HR() &
            "','" & FullDate24HR() & "','" & HRUsername & "','1'"
            returnBool = InsertSingleQueryCloud("tblbranch", Fields, Values)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub UpdateBranch()
        Try
            Dim ConnectionCloud As MySqlConnection = New MySqlConnection
            ConnectionCloud.ConnectionString = CloudConnectionString
            ConnectionCloud.Open()

            Dim sql = "UPDATE tblbranch SET company_id=@0,branch_name=@1,address=@2,description=@3,updatedat=@5,creator=@6,status=@7 WHERE branch_id = " & UpBranchID
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionCloud)
            cmd.Parameters.Add("@0", MySqlDbType.Text).Value = CompanyID
            cmd.Parameters.Add("@1", MySqlDbType.Text).Value = Trim(TextBoxBranchName.Text)
            cmd.Parameters.Add("@2", MySqlDbType.Text).Value = Trim(TextBoxBranchAddress.Text)
            cmd.Parameters.Add("@3", MySqlDbType.Text).Value = Trim(TextBoxBranchAddress.Text)
            cmd.Parameters.Add("@5", MySqlDbType.Text).Value = FullDate24HR()
            cmd.Parameters.Add("@6", MySqlDbType.Text).Value = HRUsername
            cmd.Parameters.Add("@7", MySqlDbType.Text).Value = "1"
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxBranchDesc.KeyPress, TextBoxBranchAddress.KeyPress, TextBoxBranchName.KeyPress
        Try
            If InStr(DisallowedCharacters, e.KeyChar) > 0 Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try

            Dim result() As DataRow = Home.newMDIchildGroups.CompanyDatatable.Select("companyname ='" & ComboBox1.Text & "'")

            ' Loop and display.
            For Each row As DataRow In result
                CompanyID = row(0)
                'Console.WriteLine("{0}, {1}", row(0), row(1))
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim ThreadChecker As Thread
    Dim ThreadCheckerList As List(Of Thread) = New List(Of Thread)
    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            For i = 0 To 100
                BackgroundWorker2.ReportProgress(i)
                Thread.Sleep(50)
                If i = 0 Then
                    ToolStripStatusLabel1.Text = "Checking details. Please wait"
                    ThreadChecker = New Thread(Sub() CheckBranchName(Trim(TextBoxBranchName.Text), UpBranchID, CompanyID))
                    ThreadChecker.Start()
                    ThreadCheckerList.Add(ThreadChecker)
                End If
            Next
            For Each t In ThreadCheckerList
                t.Join()
                If (BackgroundWorker2.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorker2_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        ToolStripProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        If CheckBranchNameExist Then
            Enabled = True
            MsgBox("Branch name already exist")
        Else
            BackgroundWorker1.WorkerReportsProgress = True
            BackgroundWorker1.WorkerSupportsCancellation = True
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
End Class