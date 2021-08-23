Imports System.Drawing.Imaging
Imports System.Threading
Imports MySql.Data.MySqlClient

Public Class frmEmployee
    Dim UpdateEmpDetails As Boolean = False
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
            Dim sql = "SELECT * FROM tblemployee LIMIT 50"
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
                    DataGridView1.Rows.Add(row("empid"), row("first"), row("mid"), row("last"))
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

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        BackgroundWorkerPISave.WorkerReportsProgress = True
        BackgroundWorkerPISave.WorkerSupportsCancellation = True
        BackgroundWorkerPISave.RunWorkerAsync()
    End Sub
    Dim ThreadPersonalSave As Thread
    Dim threadlistpersonalSave As List(Of Thread) = New List(Of Thread)

    Private Sub BackgroundWorkerPISave_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerPISave.DoWork
        Try
            For i = 0 To 50
                BackgroundWorkerPISave.ReportProgress(i)
                Thread.Sleep(20)
                If WorkerCancel Then
                    Exit For
                End If
                If i = 0 Then
                    ToolStripStatusLabel1.Text = "Loading. Please wait."
                    ThreadPersonalSave = New Thread(Sub() EmpCode())
                    ThreadPersonalSave.Start()
                    threadlistpersonalSave.Add(ThreadPersonalSave)
                End If
            Next
            For Each t In threadlistpersonalSave
                t.Join()
                If (BackgroundWorkerPISave.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
            For i = 50 To 100
                BackgroundWorkerPISave.ReportProgress(i)
                Thread.Sleep(20)
                If WorkerCancel Then
                    Exit For
                End If
                If i = 50 Then
                    ToolStripStatusLabel1.Text = "Loading. Please wait."
                    If UpdateEmpDetails Then
                        ThreadPersonalSave = New Thread(Sub() UpdateEmployee())
                        ThreadPersonalSave.Start()
                        threadlistpersonalSave.Add(ThreadPersonalSave)
                    Else
                        ThreadPersonalSave = New Thread(Sub() SaveEmployee())
                        ThreadPersonalSave.Start()
                        threadlistpersonalSave.Add(ThreadPersonalSave)
                    End If

                End If
            Next
            For Each t In threadlistpersonalSave
                t.Join()
                If (BackgroundWorkerPISave.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SaveEmployee()
        Try
            PIEMPLOYEECODE += 1
            Dim EmpCode = PIEMPLOYEECODE.ToString

            Dim Fields = "`empcode`,`first`,`last`,`mid`,`bdate`,`age`,`contact`,`address1`,`address2`,`designation`,`salarypackage`,`datehired`,`appraisal`,
                          `group`,`status`,`sss`,`pagibig`,`tin`,`philhealth`,`mothersname`,`fathersname`,`spousename`,`emergencycontact`,`mothersoccupation`,`fathersoccupation`,
                          `modifier`,`updatedat`,`createdat`,`image`"
            Dim Values = "'" & EmpCode & "','" & Trim(TextBoxPIFirst.Text) &
            "','" & Trim(TextBoxPILastName.Text) & "','" & Trim(TextBoxPIMid.Text) & "','" & DateTimePickerPIBDate.Value &
            "','" & Trim(TextBoxPIAge.Text) & "','" & Trim(TextBoxPIContact.Text) & "','" & Trim(TextBoxPIAddress1.Text) & "','" & Trim(TextBoxPIAddress2.Text) &
            "','" & Trim(TextBoxPIDesignation.Text) & "','" & Trim(TextBoxPISalary.Text) & "','" & DateTimePickerPIDateHired.Value &
            "','" & DateTimePickerPIAppraisal.Value & "','" & ComboBoxPIGroup.Text & "','" & ComboBox1.Text &
            "','" & MaskedTextBoxPISSS.Text & "','" & MaskedTextBoxPIPagIbig.Text & "','" & MaskedTextBoxPITIN.Text &
            "','" & MaskedTextBoxPIPHIL.Text & "','" & TextBoxPIMothersName.Text & "','" & TextBoxPIFathersName.Text &
            "','" & TextBoxPISpouse.Text & "','" & TextBoxPiEmergency.Text & "','" & TextBoxPIMothersOccupation.Text &
            "','" & TextBoxPIFathersOccupation.Text & "','" & HRUsername & "','" & FullDate24HR() &
            "','" & FullDate24HR() & "','" & TextBoxPIImage.Text & "'"
            Dim sql = InsertSingleQueryCloud("tblemployee", Fields, Values)

            Console.WriteLine(sql)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub UpdateEmployee()
        Try
            Dim ConnectionCloud As MySqlConnection = New MySqlConnection
            ConnectionCloud.ConnectionString = CloudConnectionString
            ConnectionCloud.Open()

            Dim sql = "UPDATE `tblemployee` `first` = @1,`last` = @2,`mid` = @3,`bdate` = @4,`age` = @5,`contact` = @6,`address1` = @7,
                      `address2` = @8,`designation` = @9,`salarypackage` = @10,`datehired` = @11,`appraisal` = @12,`group` = @13,`status` = @14,`sss` = @15,
                      `pagibig` = @16,`tin` = @17,`philhealth` = @18,`mothersname` = @19,`fathersname` = @20,`spousename` = @21,`emergencycontact` = @22,`mothersoccupation` = @23,
                      `fathersoccupation` = @24,`modifier` = @25,`updatedat` = @26,`image` = @27 WHERE `empid` = @28;"

            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionCloud)
            cmd.Parameters.Add("@1", MySqlDbType.Text).Value = Trim(TextBoxPIFirst.Text)
            cmd.Parameters.Add("@2", MySqlDbType.Text).Value = Trim(TextBoxPILastName.Text)
            cmd.Parameters.Add("@3", MySqlDbType.Text).Value = Trim(TextBoxPIMid.Text)
            cmd.Parameters.Add("@4", MySqlDbType.Text).Value = DateTimePickerPIBDate.Value
            cmd.Parameters.Add("@5", MySqlDbType.Text).Value = TextBoxPIAge.Text
            cmd.Parameters.Add("@6", MySqlDbType.Text).Value = TextBoxPIContact.Text
            cmd.Parameters.Add("@7", MySqlDbType.Text).Value = TextBoxPIAddress1.Text
            cmd.Parameters.Add("@8", MySqlDbType.Text).Value = TextBoxPIAddress2.Text
            cmd.Parameters.Add("@9", MySqlDbType.Text).Value = TextBoxPIDesignation.Text
            cmd.Parameters.Add("@10", MySqlDbType.Text).Value = TextBoxPISalary.Text
            cmd.Parameters.Add("@11", MySqlDbType.Text).Value = DateTimePickerPIDateHired.Text
            cmd.Parameters.Add("@12", MySqlDbType.Text).Value = DateTimePickerPIAppraisal.Text
            cmd.Parameters.Add("@13", MySqlDbType.Text).Value = ComboBoxPIGroup.Text
            cmd.Parameters.Add("@14", MySqlDbType.Text).Value = ComboBox1.Text
            cmd.Parameters.Add("@15", MySqlDbType.Text).Value = MaskedTextBoxPISSS.Text
            cmd.Parameters.Add("@16", MySqlDbType.Text).Value = MaskedTextBoxPIPagIbig.Text
            cmd.Parameters.Add("@17", MySqlDbType.Text).Value = MaskedTextBoxPITIN.Text
            cmd.Parameters.Add("@18", MySqlDbType.Text).Value = MaskedTextBoxPIPHIL.Text
            cmd.Parameters.Add("@19", MySqlDbType.Text).Value = TextBoxPIMothersName.Text
            cmd.Parameters.Add("@20", MySqlDbType.Text).Value = TextBoxPIFathersName.Text
            cmd.Parameters.Add("@21", MySqlDbType.Text).Value = TextBoxPISpouse.Text
            cmd.Parameters.Add("@22", MySqlDbType.Text).Value = TextBoxPiEmergency.Text
            cmd.Parameters.Add("@23", MySqlDbType.Text).Value = TextBoxPIMothersOccupation.Text
            cmd.Parameters.Add("@24", MySqlDbType.Text).Value = TextBoxPIFathersOccupation.Text
            cmd.Parameters.Add("@25", MySqlDbType.Text).Value = HRUsername
            cmd.Parameters.Add("@26", MySqlDbType.Text).Value = FullDate24HR()
            cmd.Parameters.Add("@27", MySqlDbType.Text).Value = TextBoxPIImage.Text
            cmd.Parameters.Add("@28", MySqlDbType.Text).Value = DataGridView1.Rows(0).Cells(0).Value
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerPISave_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerPISave.RunWorkerCompleted
        BackgroundWorkerpersonalinfo.WorkerReportsProgress = True
        BackgroundWorkerpersonalinfo.WorkerSupportsCancellation = True
        BackgroundWorkerpersonalinfo.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorkerPISave_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorkerPISave.ProgressChanged
        Try
            If WorkerCancel = False Then
                ToolStripProgressBar1.Value = e.ProgressPercentage
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim imagepath As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBoxPIImage.Text = Nothing
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "PNG Images|*.png|JPG Images|*.jpg|JPEG Images|*.jpeg"
        If Me.OpenFileDialog1.ShowDialog = 1 Then
            Me.PictureBoxPIImage.Image = System.Drawing.Image.FromFile(Me.OpenFileDialog1().FileName)
        End If

        If My.Computer.FileSystem.FileExists(imagepath) Then
            Dim ImageToConvert As Bitmap = Bitmap.FromFile(imagepath)
            TextBoxPIImage.Text = ImageToBase64(ImageToConvert, ImageFormat.Png)
        End If
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        imagepath = OpenFileDialog1.FileName
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            If Me.DataGridView1.SelectedRows.Count = 0 Then
                MsgBox("No user to load", MsgBoxStyle.Information, "Sorry")
            Else
                With PersonalDatatable
                    Dim result() As DataRow = .Select("empid = " & DataGridView1.Rows(0).Cells(0).Value)
                    For Each row As DataRow In result
                        TextBoxPIFirst.Text = row(2)
                        TextBoxPILastName.Text = row(3)
                        TextBoxPIMid.Text = row(4)
                        DateTimePickerPIBDate.Value = row(5)
                        TextBoxPIAge.Text = row(6)
                        TextBoxPIContact.Text = row(7)
                        TextBoxPIAddress1.Text = row(8)
                        TextBoxPIAddress2.Text = row(9)
                        TextBoxPIDesignation.Text = row(10)
                        TextBoxPISalary.Text = row(11)
                        DateTimePickerPIDateHired.Value = row(12)
                        DateTimePickerPIAppraisal.Value = row(13)
                        ComboBoxPIGroup.Text = row(14)
                        ComboBox1.Text = row(15)
                        MaskedTextBoxPISSS.Text = row(16)
                        MaskedTextBoxPIPagIbig.Text = row(17)
                        MaskedTextBoxPITIN.Text = row(18)
                        MaskedTextBoxPIPHIL.Text = row(19)
                        TextBoxPIMothersName.Text = row(20)
                        TextBoxPIFathersName.Text = row(21)
                        TextBoxPISpouse.Text = row(22)
                        TextBoxPiEmergency.Text = row(23)
                        TextBoxPIMothersOccupation.Text = row(24)
                        TextBoxPIFathersOccupation.Text = row(25)
                        TextBoxPISpouseOccupation.Text = row(26)
                        TextBoxPIEmergencyContact.Text = row(27)
                        PictureBoxPIImage.Image = Base64ToImage(row(31))
                    Next
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        If ToolStripButton5.Text = "Update" Then
            Button1.Enabled = True
            DataGridView1.Enabled = False
            ToolStripButton1.Enabled = False
            UpdateEmpDetails = True
            TextboxReadOnly(TabPage1, False)
            MaskedTextboxReadOnly(TabPage1, False)
            DateTimePickerEnabled(TabPage1, True)
            ToolStripButton5.Text = "Cancel"
            ToolStripButton5.BackColor = Color.Red
            ToolStripButton5.ForeColor = Color.White
        Else
            DataGridView1.Enabled = True
            Button1.Enabled = False
            ToolStripButton1.Enabled = True
            ToolStripButton5.Text = "Update"
            ToolStripButton5.BackColor = Color.Transparent
            ToolStripButton5.ForeColor = Color.Black
            UpdateEmpDetails = False
            TextboxReadOnly(TabPage1, True)
            MaskedTextboxReadOnly(TabPage1, True)
            DateTimePickerEnabled(TabPage1, False)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        UpdateEmpDetails = False
        If ToolStripButton1.Text = "New" Then
            Button1.Enabled = True
            UpdateEmpDetails = False
            ToolStripButton5.Enabled = False
            DataGridView1.Enabled = False
            TextboxReadOnly(TabPage1, False)
            MaskedTextboxReadOnly(TabPage1, False)
            DateTimePickerEnabled(TabPage1, True)
            TextBoxClear(TabPage1)
            MaskedTextBoxClear(TabPage1)
            DateTimePickerDefault(TabPage1)
            PictureBoxPIImage.Image = Nothing
            ToolStripButton1.Text = "Cancel"
            ToolStripButton1.BackColor = Color.Red
            ToolStripButton1.ForeColor = Color.White
        Else
            DataGridView1.Enabled = True
            Button1.Enabled = False
            ToolStripButton5.Enabled = True
            ToolStripButton1.Text = "New"
            ToolStripButton1.BackColor = Color.Transparent
            ToolStripButton1.ForeColor = Color.Black
            UpdateEmpDetails = True
            TextboxReadOnly(TabPage1, True)
            MaskedTextboxReadOnly(TabPage1, True)
            DateTimePickerEnabled(TabPage1, False)
        End If
    End Sub
End Class