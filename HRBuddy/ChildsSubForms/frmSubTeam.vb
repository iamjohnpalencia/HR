Imports System.Threading

Public Class frmSubTeam
    Private Sub frmSubTeam_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Home.newMDIchildGroups.Enabled = True
        Home.Enabled = True
    End Sub


    Dim CompanyID As String
    Dim BranchID As String
    Dim DeptID As String

    Public UpTeamCompanyName As String
    Public UpTeamBranchName As String
    Public UpTeamDeptname As String
    Public UpTeamName As String
    Public UpTeamDesc As String
    Public UpTeamID
    Private Sub frmSubTeam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            For Each str As String In CompanyArray
                ComboBoxCompanyName.Items.Add(str)
            Next
            For Each str As String In BranchArray
                ComboBoxBranchName.Items.Add(str)
            Next
            For Each str As String In DepartmentArray
                ComboBoxDeptName.Items.Add(str)
            Next

            If UPDATETEAMNAMEDETAILS Then

                TextBoxTeamName.Text = UpTeamName
                TextBoxTeamDesc.Text = UpTeamDesc

                ComboBoxCompanyName.SelectedIndex = ComboBoxCompanyName.FindStringExact(UpTeamCompanyName)
                ComboBoxBranchName.SelectedIndex = ComboBoxBranchName.FindStringExact(UpTeamBranchName)
                ComboBoxDeptName.SelectedIndex = ComboBoxDeptName.FindStringExact(UpTeamDeptname)

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCompanyName.SelectedIndexChanged
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

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxBranchName.SelectedIndexChanged
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

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDeptName.SelectedIndexChanged
        Try
            Dim result() As DataRow = Home.newMDIchildGroups.DeptDatatable.Select("dep_name ='" & ComboBoxDeptName.Text & "'")
            ' Loop and display.
            For Each row As DataRow In result
                DeptID = row(0)
                'Console.WriteLine("{0}, {1}", row(0), row(1))
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TextBox21_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxTeamDesc.KeyPress, TextBoxTeamName.KeyPress
        Try
            If InStr(DisallowedCharacters, e.KeyChar) > 0 Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If BlankFields(Me) Then
                MsgBox("Fill up all fields")
            Else
                If ComboBoxCompanyName.SelectedIndex = -1 Then
                    MsgBox("Select company first")
                ElseIf ComboBoxBranchName.SelectedIndex = -1 Then
                    MsgBox("Select branch first")
                ElseIf ComboBoxDeptName.SelectedIndex = -1 Then
                    MsgBox("Select department first")
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
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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
                    ThreadChecker = New Thread(Sub() CheckTeamName(Trim(TextBoxTeamName.Text), UpTeamID, CompanyID))
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
        If CheckTeamnameExist Then
            MsgBox("Team already exist")
            Enabled = True
        Else
            BackgroundWorker2.WorkerReportsProgress = True
            BackgroundWorker2.WorkerSupportsCancellation = True
            BackgroundWorker2.RunWorkerAsync()
        End If
    End Sub
    Dim threadListTeam As List(Of Thread) = New List(Of Thread)
    Dim ThreadTeam As Thread
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
                    ThreadTeam = New Thread(Sub() InsertTeam())
                    ThreadTeam.Start()
                    threadListTeam.Add(ThreadTeam)
                End If
            Next
            For Each t In threadListTeam
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
        Home.newMDIchildGroups.BackgroundWorkerTeam.WorkerReportsProgress = True
        Home.newMDIchildGroups.BackgroundWorkerTeam.WorkerSupportsCancellation = True
        Home.newMDIchildGroups.BackgroundWorkerTeam.RunWorkerAsync()
        Home.newMDIchildGroups.TabControl1.Enabled = False
    End Sub
    Private Sub InsertTeam()
        Try
            Dim Fields = "companyid,branch_id,dep_id,teamname,description,createdat,updatedat,creator,status"
            Dim Values = "'" & CompanyID & "','" & BranchID & "','" & DeptID & "','" & Trim(TextBoxTeamName.Text) & "','" & Trim(TextBoxTeamDesc.Text) & "','" & FullDate24HR() &
            "','" & FullDate24HR() & "','" & HRUsername & "','1'"
            returnBool = InsertSingleQueryCloud("tblteam", Fields, Values)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class