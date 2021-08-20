Imports System.Globalization
Imports System.Threading
Imports MySql.Data.MySqlClient

Public Class frmSubCompany
    Private Sub frmSubGroups_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Home.newMDIchildGroups.Enabled = True
        Home.Enabled = True
    End Sub
    Public UpCompanyID
    Public UpCompanyName As String
    Public UpCompanyCode As String
    Public UpCompanyAddress As String
    Public UpCompanyDesc As String
    Public UpCompRegDate As String
    Public UpCompExpDate As String

    Private Sub frmSubGroups_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CheckForIllegalCrossThreadCalls = False
            If UPDATECOMPANYDETAILS Then
                If UpCompRegDate <> "" Then
                    Dim regDate As String = UpCompRegDate
                    Dim regDateFormat As DateTime = Convert.ToDateTime(regDate)
                    DateTimePickerCompReg.Value = regDateFormat.Month & "/" & regDateFormat.Day & "/" & regDateFormat.Year & " " & regDateFormat.Hour & ":" & regDateFormat.Minute & ":" & regDateFormat.Second
                End If
                If UpCompExpDate <> "" Then
                    Dim expDate As String = UpCompExpDate
                    Dim expDateFormat As DateTime = Convert.ToDateTime(expDate)
                    DateTimePickerCompExp.Value = expDateFormat.Month & "/" & expDateFormat.Day & "/" & expDateFormat.Year & " " & expDateFormat.Hour & ":" & expDateFormat.Minute & ":" & expDateFormat.Second

                End If
                TextBoxCompName.Text = UpCompanyName
                TextBoxCompCode.Text = UpCompanyCode
                TextBoxCompAddress.Text = UpCompanyAddress
                TextBoxCompDesc.Text = UpCompanyDesc
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BlankFields(Me) Then
            MsgBox("Fill up all fields")
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
                    ThreadChecker = New Thread(Sub() CheckCompanyName(Trim(TextBoxCompName.Text), UpCompanyID))
                    ThreadChecker.Start()
                    ThreadCheckerList.Add(ThreadChecker)
                End If
                If i = 50 Then
                    ThreadChecker = New Thread(Sub() CheckCompanyCode(Trim(TextBoxCompCode.Text), UpCompanyID))
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
        If CheckCompanyNameExist And CheckCompanyCodeExist Then
            MsgBox("Company name/code already exist")
            Enabled = True
        ElseIf CheckCompanyNameExist And CheckCompanyCodeExist = False Then
            MsgBox("Company name/code already exist")
            Enabled = True
        ElseIf CheckCompanyNameExist = False And CheckCompanyCodeExist Then
            MsgBox("Company name/code already exist")
            Enabled = True
        Else
            BackgroundWorker1.WorkerReportsProgress = True
            BackgroundWorker1.WorkerSupportsCancellation = True
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Dim threadListCompany As List(Of Thread) = New List(Of Thread)
    Dim ThreadCompany As Thread
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
                    If UPDATECOMPANYDETAILS Then
                        ThreadCompany = New Thread(Sub() UpdateCompany())
                        ThreadCompany.Start()
                        threadListCompany.Add(ThreadCompany)
                    Else
                        ThreadCompany = New Thread(Sub() InsertCompany())
                        ThreadCompany.Start()
                        threadListCompany.Add(ThreadCompany)
                    End If
                End If
            Next
            For Each t In threadListCompany
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
        ToolStripProgressBar1.Value = e.ProgressPercentage
    End Sub
    Private Sub InsertCompany()
        Try
            Dim Fields = "companyname,companycode,address,description,created_at,updated_at,registration_date,expiry_date,creator,status"
            Dim Values = "'" & Trim(TextBoxCompName.Text) & "','" & Trim(TextBoxCompCode.Text) &
            "','" & Trim(TextBoxCompAddress.Text) & "','" & Trim(TextBoxCompDesc.Text) & "','" & FullDate24HR() &
            "','" & FullDate24HR() & "','" & DateTimePickerCompReg.Value & "','" & DateTimePickerCompExp.Value &
            "','" & HRUsername & "','1'"
            returnBool = InsertSingleQueryCloud("tblcompany", Fields, Values)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub UpdateCompany()
        Try
            Dim ConnectionCloud As MySqlConnection = New MySqlConnection
            ConnectionCloud.ConnectionString = CloudConnectionString
            ConnectionCloud.Open()

            Dim sql = "UPDATE tblcompany SET companyname=@0,companycode=@1,address=@2,description=@3,updated_at=@5,registration_date=@6,expiry_date=@7,creator=@8,status=@9 WHERE companyid = " & UpCompanyID
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionCloud)
            cmd.Parameters.Add("@0", MySqlDbType.Text).Value = Trim(TextBoxCompName.Text)
            cmd.Parameters.Add("@1", MySqlDbType.Text).Value = Trim(TextBoxCompCode.Text)
            cmd.Parameters.Add("@2", MySqlDbType.Text).Value = Trim(TextBoxCompAddress.Text)
            cmd.Parameters.Add("@3", MySqlDbType.Text).Value = Trim(TextBoxCompDesc.Text)

            cmd.Parameters.Add("@5", MySqlDbType.Text).Value = FullDate24HR()
            cmd.Parameters.Add("@6", MySqlDbType.Text).Value = DateTimePickerCompReg.Value
            cmd.Parameters.Add("@7", MySqlDbType.Text).Value = DateTimePickerCompExp.Value
            cmd.Parameters.Add("@8", MySqlDbType.Text).Value = HRUsername
            cmd.Parameters.Add("@9", MySqlDbType.Text).Value = "1"
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            Enabled = True
            Home.newMDIchildGroups.ToolStripProgressBar1.Value = 0
            Home.newMDIchildGroups.BackgroundWorkerCompany.WorkerReportsProgress = True
            Home.newMDIchildGroups.BackgroundWorkerCompany.WorkerSupportsCancellation = True
            Home.newMDIchildGroups.BackgroundWorkerCompany.RunWorkerAsync()
            Home.newMDIchildGroups.TabControl1.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TextBoxCompName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxCompName.KeyPress, TextBoxCompDesc.KeyPress, TextBoxCompCode.KeyPress, TextBoxCompAddress.KeyPress
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


End Class