Imports System.Threading
Imports MySql.Data.MySqlClient

Public Class frmSubDept
    Private Sub frmSubDept_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Home.newMDIchildGroups.Enabled = True
        Home.Enabled = True
    End Sub
    Dim CompanyID As String
    Dim BranchID As String

    Public UpDeptCompanyName As String
    Public UpDeptBranchName As String
    Public UpDeptName As String
    Public UpDeptDesc As String
    Public UpDeptID

    Private Sub frmSubDept_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            For Each str As String In CompanyArray
                ComboBoxCompanyName.Items.Add(str)
            Next
            For Each str As String In BranchArray
                ComboBoxBranchName.Items.Add(str)
            Next

            If UPDATEDEPARTMENTDETAILS Then
                TextBoxDeptName.Text = UpDeptName
                TextBoxDeptDesc.Text = UpDeptDesc
                ComboBoxCompanyName.SelectedIndex = ComboBoxCompanyName.FindStringExact(UpDeptCompanyName)
                ComboBoxBranchName.SelectedIndex = ComboBoxBranchName.FindStringExact(UpDeptBranchName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCompanyName.SelectedIndexChanged
        Try
            Dim result() As DataRow = Home.newMDIchildGroups.CompanyDatatable.Select("companyname ='" & ComboBoxCompanyName.Text & "'")
            ' Loop and display.
            For Each row As DataRow In result
                CompanyID = row(0)
                'Console.WriteLine("{0}, {1}", row(0), row(1))
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxBranchName.SelectedIndexChanged
        Try
            Dim result() As DataRow = Home.newMDIchildGroups.BranchDatatable.Select("branch_name ='" & ComboBoxBranchName.Text & "'")
            ' Loop and display.
            For Each row As DataRow In result
                BranchID = row(0)
                'Console.WriteLine("{0}, {1}", row(0), row(1))
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BlankFields(Me) Then
            MsgBox("Fill up all fields")
        Else
            If ComboBoxCompanyName.SelectedIndex = -1 Then
                MsgBox("Select company name first")
            ElseIf ComboBoxBranchName.SelectedIndex = -1 Then
                MsgBox("Select branch name first")
            Else
                If ValidCloudConnection Then
                    BackgroundWorker1.WorkerReportsProgress = True
                    BackgroundWorker1.WorkerSupportsCancellation = True
                    BackgroundWorker1.RunWorkerAsync()
                    Enabled = False
                Else
                    MsgBox("Cloud server connection must be valid first")
                End If
            End If

        End If
    End Sub
    Dim ThreadChecker As Thread
    Dim ThreadCheckerList As List(Of Thread) = New List(Of Thread)
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            For i = 0 To 100
                BackgroundWorker1.ReportProgress(i)
                Thread.Sleep(50)
                If i = 0 Then
                    ToolStripStatusLabel1.Text = "Checking details. Please wait"
                    ThreadChecker = New Thread(Sub() CheckDepartment(Trim(TextBoxDeptName.Text), UpDeptID, CompanyID))
                    ThreadChecker.Start()
                    ThreadCheckerList.Add(ThreadChecker)
                End If
            Next
            For Each t In ThreadCheckerList
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
        ToolStripProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If CheckDepartmentExist Then
            Enabled = True
            MsgBox("Department already exist")
        Else
            BackgroundWorker2.WorkerReportsProgress = True
            BackgroundWorker2.WorkerSupportsCancellation = True
            BackgroundWorker2.RunWorkerAsync()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
    Private Sub TextBox15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxDeptDesc.KeyPress, TextBoxDeptName.KeyPress
        Try
            If InStr(DisallowedCharacters, e.KeyChar) > 0 Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim threadListDept As List(Of Thread) = New List(Of Thread)
    Dim ThreadDept As Thread
    Dim WorkerCancel As Boolean = False
    Dim returnBool As String
    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            For i = 0 To 100
                BackgroundWorker2.ReportProgress(i)
                Thread.Sleep(20)
                If WorkerCancel Then
                    Exit For
                End If
                If i = 0 Then
                    ToolStripStatusLabel1.Text = "Loading. Please wait."
                    If UPDATEDEPARTMENTDETAILS Then
                        ThreadDept = New Thread(Sub() UpdateDepartment())
                        ThreadDept.Start()
                        threadListDept.Add(ThreadDept)
                    Else
                        ThreadDept = New Thread(Sub() InsertDepartment())
                        ThreadDept.Start()
                        threadListDept.Add(ThreadDept)
                    End If
                End If
            Next
            For Each t In threadListDept
                t.Join()
                If (BackgroundWorker2.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub BackgroundWorker2_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        Try
            ToolStripProgressBar1.Value = e.ProgressPercentage
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        Enabled = True
        Home.newMDIchildGroups.ToolStripProgressBar1.Value = 0
        Home.newMDIchildGroups.BackgroundWorkerDept.WorkerReportsProgress = True
        Home.newMDIchildGroups.BackgroundWorkerDept.WorkerSupportsCancellation = True
        Home.newMDIchildGroups.BackgroundWorkerDept.RunWorkerAsync()
        Home.newMDIchildGroups.TabControl1.Enabled = False
    End Sub

    Private Sub InsertDepartment()
        Try
            Dim Fields = "company_id,branch_id,dep_name,description,createdat,updatedat,creator,status"
            Dim Values = "'" & CompanyID & "','" & BranchID &
            "','" & Trim(TextBoxDeptName.Text) & "','" & Trim(TextBoxDeptDesc.Text) & "','" & FullDate24HR() &
            "','" & FullDate24HR() & "','" & HRUsername & "','1'"
            returnBool = InsertSingleQueryCloud("tbldepartment", Fields, Values)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub UpdateDepartment()
        Try
            Dim ConnectionCloud As MySqlConnection = New MySqlConnection
            ConnectionCloud.ConnectionString = CloudConnectionString
            ConnectionCloud.Open()

            Dim sql = "UPDATE tbldepartment SET company_id=@0,branch_id=@1,dep_name=@2,description=@3,updatedat=@5,creator=@6,status=@7 WHERE dep_id = " & UpDeptID
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionCloud)
            cmd.Parameters.Add("@0", MySqlDbType.Text).Value = CompanyID
            cmd.Parameters.Add("@1", MySqlDbType.Text).Value = BranchID
            cmd.Parameters.Add("@2", MySqlDbType.Text).Value = Trim(TextBoxDeptName.Text)
            cmd.Parameters.Add("@3", MySqlDbType.Text).Value = Trim(TextBoxDeptDesc.Text)
            cmd.Parameters.Add("@5", MySqlDbType.Text).Value = FullDate24HR()
            cmd.Parameters.Add("@6", MySqlDbType.Text).Value = HRUsername
            cmd.Parameters.Add("@7", MySqlDbType.Text).Value = "1"
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class