Imports System.Threading
Imports MySql.Data.MySqlClient
Public Class frmGroups

    Public CompanyDatatable As DataTable
    Public BranchDatatable As DataTable
    Public DeptDatatable As DataTable
    Public TeamDatatable As DataTable

    Dim CompanyLoaded As Boolean
    Dim BranchLoaded As Boolean
    Dim DeptLoaded As Boolean
    Dim TeamLoaded As Boolean

    Private Sub frmGroups_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CloseSpecificForm = False
            WindowState = FormWindowState.Maximized
            StartPosition = FormStartPosition.CenterScreen
            CheckForIllegalCrossThreadCalls = False

            If ValidCloudConnection Then
                ToolStripProgressBar1.Value = 0
                BackgroundWorkerCompany.WorkerReportsProgress = True
                BackgroundWorkerCompany.WorkerSupportsCancellation = True
                BackgroundWorkerCompany.RunWorkerAsync()

                BackgroundWorkerBranch.WorkerReportsProgress = True
                BackgroundWorkerBranch.WorkerSupportsCancellation = True
                BackgroundWorkerBranch.RunWorkerAsync()

                BackgroundWorkerDept.WorkerReportsProgress = True
                BackgroundWorkerDept.WorkerSupportsCancellation = True
                BackgroundWorkerDept.RunWorkerAsync()

                BackgroundWorkerTeam.WorkerReportsProgress = True
                BackgroundWorkerTeam.WorkerSupportsCancellation = True
                BackgroundWorkerTeam.RunWorkerAsync()

                TabControl1.Enabled = False
            Else
                ToolStripStatusLabel1.Text = "Cloud connection failed. Setup cloud database connection first."
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            If ValidCloudConnection Then
                If TabControl1.SelectedIndex = 0 Then
                    If CompanyLoaded = False Then
                        ToolStripProgressBar1.Value = 0
                        BackgroundWorkerCompany.WorkerReportsProgress = True
                        BackgroundWorkerCompany.WorkerSupportsCancellation = True
                        BackgroundWorkerCompany.RunWorkerAsync()
                        TabControl1.Enabled = False
                    End If
                ElseIf TabControl1.SelectedIndex = 1 Then
                    If BranchLoaded = False Then
                        ToolStripProgressBar1.Value = 0
                        BackgroundWorkerBranch.WorkerReportsProgress = True
                        BackgroundWorkerBranch.WorkerSupportsCancellation = True
                        BackgroundWorkerBranch.RunWorkerAsync()
                        TabControl1.Enabled = False
                    End If
                ElseIf TabControl1.SelectedIndex = 2 Then
                    If DeptLoaded = False Then
                        ToolStripProgressBar1.Value = 0
                        BackgroundWorkerDept.WorkerReportsProgress = True
                        BackgroundWorkerDept.WorkerSupportsCancellation = True
                        BackgroundWorkerDept.RunWorkerAsync()
                        TabControl1.Enabled = False
                    End If
                ElseIf TabControl1.SelectedIndex = 3 Then
                    If TeamLoaded = False Then
                        ToolStripProgressBar1.Value = 0
                        BackgroundWorkerTeam.WorkerReportsProgress = True
                        BackgroundWorkerTeam.WorkerSupportsCancellation = True
                        BackgroundWorkerTeam.RunWorkerAsync()
                        TabControl1.Enabled = False
                    End If
                End If
            Else
                ToolStripStatusLabel1.Text = "Cloud connection failed. Setup cloud database connection first."
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        UPDATECOMPANYDETAILS = False
        Enabled = False
        Home.Enabled = False
        frmSubCompany.Show()
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If DataGridViewCompany.SelectedRows.Count > 0 Then
            UPDATECOMPANYDETAILS = True
            frmSubCompany.UpCompanyID = DataGridViewCompany.SelectedRows(0).Cells(0).Value
            frmSubCompany.UpCompanyName = DataGridViewCompany.SelectedRows(0).Cells(1).Value
            frmSubCompany.UpCompanyCode = DataGridViewCompany.SelectedRows(0).Cells(2).Value
            frmSubCompany.UpCompanyAddress = DataGridViewCompany.SelectedRows(0).Cells(3).Value
            frmSubCompany.UpCompanyDesc = DataGridViewCompany.SelectedRows(0).Cells(4).Value
            frmSubCompany.UpCompRegDate = DataGridViewCompany.SelectedRows(0).Cells(7).Value
            frmSubCompany.UpCompExpDate = DataGridViewCompany.SelectedRows(0).Cells(8).Value
            Enabled = False
            Home.Enabled = False
            frmSubCompany.Show()
        Else
            MsgBox("Select company first")
        End If
    End Sub
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Try
            Dim bool As Boolean = False
            Dim msg = MessageBox.Show("Are you sure you want to delete this item?", "Delete Company", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If msg = DialogResult.Yes Then
                bool = CheckIDS(0, DataGridViewCompany.SelectedRows(0).Cells(0).Value)
                If bool Then
                    MsgBox("Selected item is inused")
                Else
                    DeleteCloud("tblcompany", "companyid = " & DataGridViewCompany.SelectedRows(0).Cells(0).Value)
                    ToolStripButton14.PerformClick()
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        UPDATEBRANCHDETAILS = False
        Enabled = False
        Home.Enabled = False
        frmSubBranch.Show()
    End Sub
    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        If DataGridViewBranch.SelectedRows.Count > 0 Then
            UPDATEBRANCHDETAILS = True
            Dim result() As DataRow = Home.newMDIchildGroups.CompanyDatatable.Select("companyid = " & DataGridViewBranch.SelectedRows(0).Cells(1).Value)
            For Each row As DataRow In result
                frmSubBranch.UpBranchCompanyName = row(1)
            Next
            frmSubBranch.UpBranchID = DataGridViewBranch.SelectedRows(0).Cells(0).Value
            frmSubBranch.UpBranchName = DataGridViewBranch.SelectedRows(0).Cells(2).Value
            frmSubBranch.UpBranchAddress = DataGridViewBranch.SelectedRows(0).Cells(3).Value
            frmSubBranch.UpBranchDesc = DataGridViewBranch.SelectedRows(0).Cells(4).Value
            Enabled = False
            Home.Enabled = False
            frmSubBranch.Show()
        Else
            MsgBox("Select branch first")
        End If
    End Sub
    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Try
            Dim bool As Boolean = False
            Dim msg = MessageBox.Show("Are you sure you want to delete this item?", "Delete Company", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If msg = DialogResult.Yes Then
                bool = CheckIDS(1, DataGridViewBranch.SelectedRows(0).Cells(0).Value)
                If bool Then
                    MsgBox("Selected item is inused")
                Else
                    DeleteCloud("tblbranch", "branch_id = " & DataGridViewBranch.SelectedRows(0).Cells(0).Value)
                    ToolStripButton15.PerformClick()
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        UPDATEDEPARTMENTDETAILS = False
        Enabled = False
        Home.Enabled = False
        frmSubDept.Show()
    End Sub
    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        If DataGridViewDepartment.SelectedRows.Count > 0 Then
            UPDATEDEPARTMENTDETAILS = True

            Dim result() As DataRow = Home.newMDIchildGroups.CompanyDatatable.Select("companyid = " & DataGridViewDepartment.SelectedRows(0).Cells(1).Value)
            For Each row As DataRow In result
                frmSubDept.UpDeptCompanyName = row(1)
            Next

            Dim result1() As DataRow = Home.newMDIchildGroups.BranchDatatable.Select("branch_id = " & DataGridViewDepartment.SelectedRows(0).Cells(0).Value)
            For Each row1 As DataRow In result1
                frmSubDept.UpDeptBranchName = row1(2)
            Next

            'DataGridViewDepartment.Rows.Add(row("dep_id"), row("company_id"), row("branch_id"), row("dep_name"), row("description"), row("createdat"), row("updatedat"), row("creator"), row("status"))

            frmSubDept.UpDeptName = DataGridViewDepartment.SelectedRows(0).Cells(3).Value
            frmSubDept.UpDeptDesc = DataGridViewDepartment.SelectedRows(0).Cells(4).Value
            frmSubDept.UpDeptID = DataGridViewDepartment.SelectedRows(0).Cells(0).Value

            Enabled = False
            Home.Enabled = False
            frmSubDept.Show()
        Else
            MsgBox("Select branch first")
        End If
    End Sub
    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        Try
            Dim bool As Boolean = False
            Dim msg = MessageBox.Show("Are you sure you want to delete this item?", "Delete Company", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If msg = DialogResult.Yes Then
                bool = CheckIDS(2, DataGridViewDepartment.SelectedRows(0).Cells(0).Value)
                If bool Then
                    MsgBox("Selected item is inused")
                Else
                    DeleteCloud("tbldepartment", "dep_id = " & DataGridViewDepartment.SelectedRows(0).Cells(0).Value)
                    ToolStripButton16.PerformClick()
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        UPDATETEAMNAMEDETAILS = False
        Enabled = False
        Home.Enabled = False
        frmSubTeam.Show()
    End Sub
    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        If DataGridViewTeam.SelectedRows.Count > 0 Then
            UPDATETEAMNAMEDETAILS = True

            Dim result() As DataRow = Home.newMDIchildGroups.CompanyDatatable.Select("companyid = " & DataGridViewTeam.SelectedRows(0).Cells(1).Value)
            For Each row As DataRow In result
                frmSubTeam.UpTeamCompanyName = row(1)
            Next

            Dim result1() As DataRow = Home.newMDIchildGroups.BranchDatatable.Select("branch_id = " & DataGridViewTeam.SelectedRows(0).Cells(2).Value)
            For Each row1 As DataRow In result1
                frmSubTeam.UpTeamBranchName = row1(2)
            Next

            Dim result2() As DataRow = Home.newMDIchildGroups.DeptDatatable.Select("dep_id = " & DataGridViewTeam.SelectedRows(0).Cells(3).Value)
            For Each row2 As DataRow In result2
                frmSubTeam.UpTeamDeptname = row2(3)
            Next

            frmSubTeam.UpTeamName = DataGridViewTeam.SelectedRows(0).Cells(4).Value
            frmSubTeam.UpTeamDesc = DataGridViewTeam.SelectedRows(0).Cells(5).Value
            frmSubTeam.UpTeamID = DataGridViewTeam.SelectedRows(0).Cells(1).Value

            Enabled = False
            Home.Enabled = False
            frmSubTeam.Show()
        Else
            MsgBox("Select team first")
        End If

    End Sub
    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        Try
            Dim bool As Boolean = False
            Dim msg = MessageBox.Show("Are you sure you want to delete this item?", "Delete Company", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If msg = DialogResult.Yes Then
                bool = CheckIDS(3, DataGridViewTeam.SelectedRows(0).Cells(0).Value)
                If bool Then
                    MsgBox("Selected item is inused")
                Else
                    DeleteCloud("tblteam", "teamid = " & DataGridViewTeam.SelectedRows(0).Cells(0).Value)
                    ToolStripButton16.PerformClick()
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim WorkerCancel As Boolean = False
    Dim threadListCompany As List(Of Thread) = New List(Of Thread)
    Dim ThreadCompany As Thread
    Private Sub BackgroundWorkerCompany_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerCompany.DoWork
        Try
            For i = 0 To 100
                BackgroundWorkerCompany.ReportProgress(i)
                Thread.Sleep(20)
                If WorkerCancel Then
                    Exit For
                End If
                If i = 0 Then
                    ToolStripStatusLabel1.Text = "Loading. Please wait."
                    ThreadCompany = New Thread(Sub() CompanyDatatable = GetCompany(0))
                    ThreadCompany.Start()
                    threadListCompany.Add(ThreadCompany)
                End If
            Next
            For Each t In threadListCompany
                t.Join()
                If (BackgroundWorkerCompany.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim threadListBranch As List(Of Thread) = New List(Of Thread)
    Dim ThreadBranch As Thread
    Private Sub BackgroundWorkerBranch_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerBranch.DoWork
        Try
            For i = 0 To 100
                BackgroundWorkerBranch.ReportProgress(i)
                Thread.Sleep(20)
                If WorkerCancel Then
                    Exit For
                End If
                If i = 0 Then
                    ToolStripStatusLabel1.Text = "Loading. Please wait."
                    ThreadBranch = New Thread(Sub() BranchDatatable = GetBranch(0))
                    ThreadBranch.Start()
                    threadListBranch.Add(ThreadBranch)
                End If
            Next
            For Each t In threadListBranch
                t.Join()
                If (BackgroundWorkerBranch.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim threadListDept As List(Of Thread) = New List(Of Thread)
    Dim ThreadDept As Thread
    Private Sub BackgroundWorkerDept_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerDept.DoWork
        Try
            For i = 0 To 100
                BackgroundWorkerDept.ReportProgress(i)
                Thread.Sleep(20)
                If WorkerCancel Then
                    Exit For
                End If
                If i = 0 Then
                    ToolStripStatusLabel1.Text = "Loading. Please wait."
                    ThreadDept = New Thread(Sub() DeptDatatable = GetDept(0))
                    ThreadDept.Start()
                    threadListDept.Add(ThreadDept)
                End If
            Next
            For Each t In threadListDept
                t.Join()
                If (BackgroundWorkerDept.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim threadListTeam As List(Of Thread) = New List(Of Thread)
    Dim ThreadTeam As Thread
    Private Sub BackgroundWorkerTeam_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerTeam.DoWork
        Try
            For i = 0 To 100
                BackgroundWorkerTeam.ReportProgress(i)
                Thread.Sleep(20)
                If WorkerCancel Then
                    Exit For
                End If
                If i = 0 Then
                    ToolStripStatusLabel1.Text = "Loading. Please wait."
                    ThreadTeam = New Thread(Sub() TeamDatatable = GetTeam(0))
                    ThreadTeam.Start()
                    threadListTeam.Add(ThreadTeam)
                End If
            Next
            For Each t In threadListTeam
                t.Join()
                If (BackgroundWorkerTeam.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BackgroundWorkerCompany_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorkerCompany.ProgressChanged
        Try
            If WorkerCancel = False Then
                ToolStripProgressBar1.Value = e.ProgressPercentage
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BackgroundWorkerBranch_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorkerBranch.ProgressChanged
        Try
            If WorkerCancel = False Then
                ToolStripProgressBar1.Value = e.ProgressPercentage
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerDept_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorkerDept.ProgressChanged
        Try
            If WorkerCancel = False Then
                ToolStripProgressBar1.Value = e.ProgressPercentage
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerTeam_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorkerTeam.ProgressChanged
        Try
            If WorkerCancel = False Then
                ToolStripProgressBar1.Value = e.ProgressPercentage
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BackgroundWorkerCompany_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerCompany.RunWorkerCompleted
        Try
            CompanyArray.Clear()
            CompanyLoaded = True
            TabControl1.Enabled = True
            ToolStripStatusLabel1.Text = "Complete"
            DataGridViewCompany.Rows.Clear()
            With CompanyDatatable

                For Each row As DataRow In .Rows
                    If WorkerCancel Then
                        Exit For
                    End If
                    DataGridViewCompany.Rows.Add(row("companyid"), row("companyname"), row("companycode"), row("address"), row("description"), row("created_at"), row("updated_at"), row("registration_date"), row("expiry_date"), row("status"))
                    CompanyArray.Add(row("companyname"))
                Next

            End With

            If WorkerCancel Then
                Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BackgroundWorkerBranch_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerBranch.RunWorkerCompleted
        Try
            BranchArray.Clear()
            BranchLoaded = True
            TabControl1.Enabled = True
            ToolStripStatusLabel1.Text = "Complete"
            DataGridViewBranch.Rows.Clear()
            For Each row As DataRow In BranchDatatable.Rows
                If WorkerCancel Then
                    Exit For
                End If
                DataGridViewBranch.Rows.Add(row("branch_id"), row("company_id"), row("branch_name"), row("address"), row("description"), row("createdat"), row("updatedat"), row("creator"), row("status"))
                BranchArray.Add(row("branch_name"))
            Next
            For Each str As String In BranchArray
                Console.WriteLine(str)
            Next
            If WorkerCancel Then
                Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BackgroundWorkerDept_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerDept.RunWorkerCompleted
        Try
            DepartmentArray.Clear()
            DeptLoaded = True
            TabControl1.Enabled = True
            ToolStripStatusLabel1.Text = "Complete"
            DataGridViewDepartment.Rows.Clear()
            For Each row As DataRow In DeptDatatable.Rows
                If WorkerCancel Then
                    Exit For
                End If
                DataGridViewDepartment.Rows.Add(row("dep_id"), row("company_id"), row("branch_id"), row("dep_name"), row("description"), row("createdat"), row("updatedat"), row("creator"), row("status"))
                DepartmentArray.Add(row("dep_name"))
            Next
            If WorkerCancel Then
                Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerTeam_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerTeam.RunWorkerCompleted
        Try
            TeamArray.Clear()
            TeamLoaded = True
            TabControl1.Enabled = True
            ToolStripStatusLabel1.Text = "Complete"
            DataGridViewTeam.Rows.Clear()
            For Each row As DataRow In TeamDatatable.Rows
                If WorkerCancel Then
                    Exit For
                End If
                DataGridViewTeam.Rows.Add(row("teamid"), row("companyid"), row("branch_id"), row("dep_id"), row("teamname"), row("description"), row("createdat"), row("updatedat"), row("creator"), row("status"))
                TeamArray.Add(row("teamname"))
            Next
            If WorkerCancel Then
                Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub



    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Try
            If ValidCloudConnection Then
                ToolStripProgressBar1.Value = 0
                BackgroundWorkerCompany.WorkerReportsProgress = True
                BackgroundWorkerCompany.WorkerSupportsCancellation = True
                BackgroundWorkerCompany.RunWorkerAsync()
                TabControl1.Enabled = False
            Else
                ToolStripStatusLabel1.Text = "Cloud connection failed. Setup cloud database connection first."
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs) Handles ToolStripButton15.Click
        Try
            If ValidCloudConnection Then
                ToolStripProgressBar1.Value = 0
                BackgroundWorkerBranch.WorkerReportsProgress = True
                BackgroundWorkerBranch.WorkerSupportsCancellation = True
                BackgroundWorkerBranch.RunWorkerAsync()
                TabControl1.Enabled = False
            Else
                ToolStripStatusLabel1.Text = "Cloud connection failed. Setup cloud database connection first."
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        Try
            If ValidCloudConnection Then
                ToolStripProgressBar1.Value = 0
                BackgroundWorkerDept.WorkerReportsProgress = True
                BackgroundWorkerDept.WorkerSupportsCancellation = True
                BackgroundWorkerDept.RunWorkerAsync()
                TabControl1.Enabled = False
            Else
                ToolStripStatusLabel1.Text = "Cloud connection failed. Setup cloud database connection first."
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click
        Try
            If ValidCloudConnection Then
                ToolStripProgressBar1.Value = 0
                BackgroundWorkerTeam.WorkerReportsProgress = True
                BackgroundWorkerTeam.WorkerSupportsCancellation = True
                BackgroundWorkerTeam.RunWorkerAsync()
                TabControl1.Enabled = False
            Else
                ToolStripStatusLabel1.Text = "Cloud connection failed. Setup cloud database connection first."
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmGroups_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If BackgroundWorkerCompany.IsBusy Or BackgroundWorkerBranch.IsBusy Or BackgroundWorkerDept.IsBusy Or BackgroundWorkerTeam.IsBusy Then
                If MessageBox.Show("Are you sure do you want to cancel sync ?", "Cancel Sync", MessageBoxButtons.YesNo) = DialogResult.No Then
                    e.Cancel = True
                Else
                    If BackgroundWorkerCompany.IsBusy Then
                        BackgroundWorkerCompany.CancelAsync()
                    End If
                    If BackgroundWorkerBranch.IsBusy Then
                        BackgroundWorkerBranch.CancelAsync()
                    End If
                    If BackgroundWorkerDept.IsBusy Then
                        BackgroundWorkerDept.CancelAsync()
                    End If
                    If BackgroundWorkerTeam.IsBusy Then
                        BackgroundWorkerTeam.CancelAsync()
                    End If
                    WorkerCancel = True
                    CloseSpecificForm = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class