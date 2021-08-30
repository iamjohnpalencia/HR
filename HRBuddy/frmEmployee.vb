Imports System.Drawing.Imaging
Imports System.Threading
Imports MySql.Data.MySqlClient

Public Class frmEmployee
    Dim UpdateEmpDetails As Boolean = False
    Private Sub frmEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        StartPosition = FormStartPosition.CenterScreen

        CheckForIllegalCrossThreadCalls = False
        ToolStripButton1.Enabled = False
        ToolStripButton3.Enabled = False
        ToolStripButton4.Enabled = False
        If ValidCloudConnection Then
            ToolStripProgressBar1.Value = 0
            BackgroundWorkerpersonalinfo.WorkerReportsProgress = True
            BackgroundWorkerpersonalinfo.WorkerSupportsCancellation = True
            BackgroundWorkerpersonalinfo.RunWorkerAsync()
        End If
    End Sub


    Dim EmployeeLoaded As Boolean = False
    Dim PersonalInfoDatatable As DataTable
    Private Sub LoadEmployee()
        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim sql = "SELECT * FROM tblemployeepersonal LIMIT 50"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionServer)
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            PersonalInfoDatatable = New DataTable
            da.Fill(PersonalInfoDatatable)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim PersonalWorkExperience As DataTable
    Private Sub LoadPersonalExperience(empcode)
        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim sql = "SELECT * FROM tblworkexperience WHERE empcode = '" & empcode & "'"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionServer)
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            PersonalWorkExperience = New DataTable
            da.Fill(PersonalWorkExperience)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim PersonalEducationalBG As DataTable
    Private Sub LoadEducationalbg(empcode)
        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim sql = "SELECT * FROM tbleducationalbg WHERE empcode = '" & empcode & "'"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionServer)
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            PersonalEducationalBG = New DataTable
            da.Fill(PersonalEducationalBG)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim PersonalRelationshipInfo As DataTable
    Private Sub LoadRelationShipInfo(empcode)
        Try

            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim sql = "SELECT * FROM tblrelationshipinfo WHERE empcode = '" & empcode & "'"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionServer)
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            PersonalRelationshipInfo = New DataTable
            da.Fill(PersonalRelationshipInfo)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim PersonalGovMandatories As DataTable
    Private Sub LoadGovMandatories(empcode)

        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim sql = "SELECT * FROM tblgovmandatories WHERE empcode = '" & empcode & "'"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionServer)
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            PersonalGovMandatories = New DataTable
            da.Fill(PersonalGovMandatories)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim PersonalEmploymentDetails As DataTable
    Private Sub LoadEmploymentDetails(empcode)

        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim sql = "SELECT * FROM tblemploymentdetails WHERE empcode = '" & empcode & "'"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionServer)
            Dim da As MySqlDataAdapter = New MySqlDataAdapter(cmd)
            PersonalEmploymentDetails = New DataTable
            da.Fill(PersonalEmploymentDetails)
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
            ToolStripButton1.Enabled = True
            ToolStripButton3.Enabled = True
            ToolStripButton4.Enabled = True
            EmployeeLoaded = True
            TabControl1.Enabled = True
            ToolStripStatusLabel1.Text = "Complete"
            DataGridView1.Rows.Clear()
            With PersonalInfoDatatable
                For Each row As DataRow In .Rows
                    If WorkerCancel Then
                        Exit For
                    End If
                    DataGridView1.Rows.Add(row("empcode"), row("first") & " " & row("mid") & " " & row("last"))
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
                Else
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub LoadDgvInfo()
        Try
            With DataGridViewPIPersonalInfo
                .Columns.Clear()
                .Columns.Add("Column1", " ")
                .Columns.Add("Column2", " ")
                .Columns(0).Width = 155
                '.Columns("Column1").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                .Columns("Column2").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Rows.Add("First Name :", "Jay")
                .Rows.Add("Middle Name :", "Jay")
                .Rows.Add("Last Name :", "Jay")
                .Rows.Add("Suffix :", "Jay")
                .Rows.Add("Birth Date :", Format(Now, "yyyy-MM-dd").ToString)
                .Rows.Add("Age :", Format(Now, "yyyy-MM-dd").ToString)
                .Rows.Add("Contact # :", "Jay")
                .Rows.Add("Gender :", "Jay")
                .Rows.Add("Marital Status :", "Jay")

                .Rows.Add("Home address 1 :", "Jay")
                .Rows.Add("Home address 2 :", "Jay")
                .Rows.Add("Designation :", "Jay")
                .Rows.Add("Salary Package :", "Jay")
                .Rows.Add("Date Hired :", "Jay")
                .Rows.Add("Appraisal :", "Jay")
                .Rows.Add("Status :", "Jay")
                .Rows.Add("Mothers Name :", "Jay")
                .Rows.Add("Mothers Occupation :", "Jay")
                .Rows.Add("Fathers Name :", "Jay")
                .Rows.Add("Fathers Occupation :", "Jay")
                .Rows.Add("Spouse Name :", "Jay")
                .Rows.Add("Spouse Occupation :", "Jay")
                .Rows.Add("Emergency Contact :", "Jay")
                .Rows.Add("Emergency Contact Number :", "Jay")

            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try



            If Me.DataGridView1.SelectedRows.Count = 0 Then
                MsgBox("No user to load", MsgBoxStyle.Information, "Sorry")
            Else
                ToolStripButton1.Enabled = False
                ToolStripButton3.Enabled = False
                ToolStripButton4.Enabled = False
                DataGridView1.Enabled = False
                TextBoxClear(Me)
                PictureBoxPIImage.Image = Nothing
                DataGridViewPIPersonalInfo.Rows.Clear()
                DataGridViewPIWorkExperience.Rows.Clear()
                DataGridViewPIEducationalBG.Rows.Clear()
                DataGridViewPIRelationshipInfo.Rows.Clear()
                DataGridViewPIGovMandatories.Rows.Clear()
                DataGridViewPIEmploymentDetails.Rows.Clear()
                BackgroundWorkerLoadEmployeeDetails.WorkerReportsProgress = True
                BackgroundWorkerLoadEmployeeDetails.WorkerSupportsCancellation = True
                BackgroundWorkerLoadEmployeeDetails.RunWorkerAsync()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Home.Enabled = False
        frmEmployees.UpdateEmployeeDetails = False
        frmEmployees.Show()
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            If Not String.IsNullOrEmpty(TextBoxFullName.Text) Then
                If Not BackgroundWorkerLoadEmployeeDetails.IsBusy Then
                    Home.Enabled = False
                    With PersonalInfoDatatable
                        Dim result() As DataRow = .Select("empcode = '" & DataGridView1.SelectedRows(0).Cells(0).Value & "'")
                        For Each row As DataRow In result
                            EmployeeBasicInfoArray = {row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9), row(10), row(11), row(12), row(13), row(14), row(15), row(16), row(17), row(18), row(22)}
                        Next
                    End With
                    With PersonalEmploymentDetails
                        Dim result() As DataRow = .Select("empcode = '" & DataGridView1.SelectedRows(0).Cells(0).Value & "'")
                        For Each row As DataRow In result
                            EmployeeEmploymentDetailsArray = {row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(12)}

                            'ComboBoxCompany.SelectedIndex = ComboBoxCompany.FindStringExact(EmployeeEmploymentDetailsArray(0))
                            'ComboBoxBranch.SelectedIndex = ComboBoxBranch.FindStringExact(EmployeeEmploymentDetailsArray(1))
                            'ComboBoxDepartment.SelectedIndex = ComboBoxDepartment.FindStringExact(EmployeeEmploymentDetailsArray(2))
                            'ComboBoxTeam.SelectedIndex = ComboBoxTeam.FindStringExact(EmployeeEmploymentDetailsArray(3))
                            'TextBoxPosition.Text = EmployeeEmploymentDetailsArray(4)
                            'TextBoxSalary.Text = EmployeeEmploymentDetailsArray(5)
                            'DateTimePickerDateHired.Value = EmployeeEmploymentDetailsArray(6)
                            'ComboBoxStatus.SelectedIndex = ComboBoxStatus.FindStringExact(EmployeeEmploymentDetailsArray(7))
                        Next
                    End With

                    frmEmployees.FillDetailsWorkExperienceDT = New DataTable
                    With frmEmployees.FillDetailsWorkExperienceDT
                        .Columns.Add("id")
                        .Columns.Add("companyname")
                        .Columns.Add("position")
                        For i As Integer = 0 To PersonalWorkExperience.Rows.Count - 1 Step +1
                            Dim WorkExp As DataRow = .NewRow
                            WorkExp("id") = PersonalWorkExperience(i)(0)
                            WorkExp("companyname") = PersonalWorkExperience(i)(3)
                            WorkExp("position") = PersonalWorkExperience(i)(4)
                            .Rows.Add(WorkExp)
                        Next
                    End With

                    frmEmployees.FillDetailsEducationBG = New DataTable
                    With frmEmployees.FillDetailsEducationBG
                        .Columns.Add("id")
                        .Columns.Add("schoolname")
                        .Columns.Add("level")
                        .Columns.Add("degree")
                        .Columns.Add("year")
                        For i As Integer = 0 To PersonalEducationalBG.Rows.Count - 1 Step +1
                            Dim EducBG As DataRow = .NewRow
                            EducBG("id") = PersonalEducationalBG(i)(0)
                            EducBG("schoolname") = PersonalEducationalBG(i)(3)
                            EducBG("level") = PersonalEducationalBG(i)(4)
                            EducBG("degree") = PersonalEducationalBG(i)(5)
                            EducBG("year") = PersonalEducationalBG(i)(6)
                            .Rows.Add(EducBG)
                        Next
                    End With

                    frmEmployees.FillDetailsRelationshipInfo = New DataTable
                    With frmEmployees.FillDetailsRelationshipInfo
                        .Columns.Add("id")
                        .Columns.Add("name")
                        .Columns.Add("relationship")
                        .Columns.Add("contact")
                        .Columns.Add("emergency")
                        For i As Integer = 0 To PersonalRelationshipInfo.Rows.Count - 1 Step +1
                            Dim Relationship As DataRow = .NewRow
                            Relationship("id") = PersonalRelationshipInfo(i)(0)
                            Relationship("name") = PersonalRelationshipInfo(i)(3)
                            Relationship("relationship") = PersonalRelationshipInfo(i)(4)
                            Relationship("contact") = PersonalRelationshipInfo(i)(5)
                            Relationship("emergency") = PersonalRelationshipInfo(i)(6)
                            .Rows.Add(Relationship)
                        Next
                    End With

                    frmEmployees.FillDetailsGovMandatories = New DataTable
                    With frmEmployees.FillDetailsGovMandatories
                        .Columns.Add("id")
                        .Columns.Add("agency")
                        .Columns.Add("subscribernumber")
                        For i As Integer = 0 To PersonalGovMandatories.Rows.Count - 1 Step +1
                            Dim GovMandatory As DataRow = .NewRow
                            GovMandatory("id") = PersonalGovMandatories(i)(0)
                            GovMandatory("agency") = PersonalGovMandatories(i)(3)
                            GovMandatory("subscribernumber") = PersonalGovMandatories(i)(4)
                            .Rows.Add(GovMandatory)
                        Next
                    End With

                    frmEmployees.UpdateEmployeeID = DataGridView1.SelectedRows(0).Cells(0).Value
                    frmEmployees.UpdateEmployeeDetails = True
                    frmEmployees.Show()
                Else
                    MsgBox("Loading employee details. Please wait")
                End If
            Else
                MsgBox("Select employee first")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Hide" Then
            Panel5.Height = 25
            Button1.Text = "Expand"
        Else
            Panel5.Height = 250
            Button1.Text = "Hide"
        End If
    End Sub
    Dim ThreadLoadDetails As Thread
    Dim threadlistloaddetails As List(Of Thread) = New List(Of Thread)
    Private Sub BackgroundWorkerLoadEmployeeDetails_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerLoadEmployeeDetails.DoWork
        Try
            Dim empid = DataGridView1.SelectedRows(0).Cells(0).Value
            For i = 0 To 100
                BackgroundWorkerLoadEmployeeDetails.ReportProgress(i)
                Thread.Sleep(20)
                If WorkerCancel Then
                    Exit For
                End If
                If i = 0 Then
                    ToolStripStatusLabel1.Text = "Loading. Please wait."
                    ThreadLoadDetails = New Thread(Sub() LoadPersonalExperience(empid))
                    ThreadLoadDetails.Start()
                    threadlistloaddetails.Add(ThreadLoadDetails)
                End If
                If i = 20 Then
                    ThreadLoadDetails = New Thread(Sub() LoadEducationalbg(empid))
                    ThreadLoadDetails.Start()
                    threadlistloaddetails.Add(ThreadLoadDetails)
                End If
                If i = 40 Then

                    ThreadLoadDetails = New Thread(Sub() LoadRelationShipInfo(empid))
                    ThreadLoadDetails.Start()
                    threadlistloaddetails.Add(ThreadLoadDetails)
                End If
                If i = 60 Then

                    ThreadLoadDetails = New Thread(Sub() LoadGovMandatories(empid))
                    ThreadLoadDetails.Start()
                    threadlistloaddetails.Add(ThreadLoadDetails)
                End If
                If i = 80 Then
                    ThreadLoadDetails = New Thread(Sub() LoadEmploymentDetails(empid))
                    ThreadLoadDetails.Start()
                    threadlistloaddetails.Add(ThreadLoadDetails)
                End If

            Next
            For Each t In threadlistloaddetails
                t.Join()
                If (BackgroundWorkerLoadEmployeeDetails.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BackgroundWorkerLoadEmployeeDetails_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorkerLoadEmployeeDetails.ProgressChanged
        Try
            If WorkerCancel = False Then
                ToolStripProgressBar1.Value = e.ProgressPercentage
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BackgroundWorkerLoadEmployeeDetails_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerLoadEmployeeDetails.RunWorkerCompleted
        Try
            With PersonalInfoDatatable
                Dim result() As DataRow = .Select("empcode = '" & DataGridView1.SelectedRows(0).Cells(0).Value & "'")
                For Each row As DataRow In result
                    With DataGridViewPIPersonalInfo
                        PictureBoxPIImage.Image = Base64ToImage(row(22))
                        TextBoxEmpCode.Text = row(1)
                        TextBoxFullName.Text = row(2) & " " & row(3) & " " & row(4)
                        Dim iDate As String = row(6)
                        Dim oDate As DateTime = Convert.ToDateTime(iDate)
                        .Columns.Clear()
                        .Columns.Add("Column1", " ")
                        .Columns.Add("Column2", " ")
                        .Columns(0).Width = 155
                        .Columns("Column2").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        .Rows.Add("First Name :", row(2))
                        .Rows.Add("Middle Name :", row(3))
                        .Rows.Add("Last Name :", row(4))
                        .Rows.Add("Suffix :", row(5))
                        .Rows.Add("Birth Date :", oDate.Day & "/" & oDate.Month & "/" & oDate.Year)
                        .Rows.Add("Age :", row(7))
                        .Rows.Add("Contact # :", row(8))
                        .Rows.Add("Gender :", row(9))
                        .Rows.Add("Marital Status :", row(10))
                        .Rows.Add("Home address 1 :", row(11))
                        .Rows.Add("Home address 2 :", row(12))
                        .Rows.Add("Mothers Name :", row(13))
                        .Rows.Add("Fathers Name :", row(14))
                        .Rows.Add("Spouse Name :", row(15))
                        .Rows.Add("Mothers Occupation :", row(16))
                        .Rows.Add("Fathers Occupation :", row(17))
                        .Rows.Add("Spouse Occupation :", row(18))
                    End With
                Next
            End With
            With PersonalWorkExperience
                For Each row As DataRow In .Rows
                    DataGridViewPIWorkExperience.Rows.Add(row("companyname"), row("position"))
                Next
            End With
            With PersonalEducationalBG
                For Each row As DataRow In .Rows
                    DataGridViewPIEducationalBG.Rows.Add(row("schoolname"), row("level"), row("degree"), row("year"))
                Next
            End With

            With PersonalRelationshipInfo
                For Each row As DataRow In .Rows
                    DataGridViewPIRelationshipInfo.Rows.Add(row("name"), row("relationship"), row("contact"), row("emergency"))
                Next
            End With
            With PersonalGovMandatories
                For Each row As DataRow In .Rows
                    DataGridViewPIGovMandatories.Rows.Add(row("agency"), row("subscribernumber"))
                Next
            End With
            With PersonalEmploymentDetails
                For Each row As DataRow In .Rows
                    DataGridViewPIEmploymentDetails.Rows.Add(row("company"), row("branch"), row("department"), row("team"))
                Next
                Dim result() As DataRow = .Select("empcode = '" & DataGridView1.SelectedRows(0).Cells(0).Value & "'")
                For Each row As DataRow In result
                    TextBoxPosition.Text = row(6)
                    TextBoxSalary.Text = row(7)
                    TextBoxDateHired.Text = row(8)
                    TextBoxCompany.Text = row(2)
                    TextBoxDepartment.Text = row(4)
                    TextBoxEmploymentStatus.Text = row(12)
                Next
            End With
            DataGridView1.Enabled = True
            ToolStripButton1.Enabled = True
            ToolStripButton3.Enabled = True
            ToolStripButton4.Enabled = True
            DataGridView1.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Hide" Then
            Panel7.Height = 25
            Button2.Text = "Expand"
        Else
            Panel7.Height = 200
            Button2.Text = "Hide"
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "Hide" Then
            Panel9.Height = 25
            Button3.Text = "Expand"
        Else
            Panel9.Height = 200
            Button3.Text = "Hide"
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.Text = "Hide" Then
            Panel11.Height = 25
            Button4.Text = "Expand"
        Else
            Panel11.Height = 200
            Button4.Text = "Hide"
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Button5.Text = "Hide" Then
            Panel13.Height = 25
            Button5.Text = "Expand"
        Else
            Panel13.Height = 200
            Button5.Text = "Hide"
        End If
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Button6.Text = "Hide" Then
            Panel15.Height = 25
            Button6.Text = "Expand"
        Else
            Panel15.Height = 200
            Button6.Text = "Hide"
        End If
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If String.IsNullOrEmpty(TextBoxFullName.Text) Then
            MsgBox("Select user to delete", MsgBoxStyle.Information, "Delete")
        Else
            Dim msg = MessageBox.Show("Are you sure you want to delete this?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If msg = DialogResult.Yes Then
                TextBoxClear(Me)
                PictureBoxPIImage.Image = Nothing
                DataGridViewPIPersonalInfo.Rows.Clear()
                DataGridViewPIWorkExperience.Rows.Clear()
                DataGridViewPIEducationalBG.Rows.Clear()
                DataGridViewPIRelationshipInfo.Rows.Clear()
                DataGridViewPIGovMandatories.Rows.Clear()
                DataGridViewPIEmploymentDetails.Rows.Clear()
                DataGridView1.Enabled = False
                BackgroundWorkerDelete.WorkerReportsProgress = True
                BackgroundWorkerDelete.WorkerSupportsCancellation = True
                BackgroundWorkerDelete.RunWorkerAsync()
            End If
        End If
        Try
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim ThreadDeleteEmployeeBasic As Thread
    Dim threadlistdeleteemployeeBasic As List(Of Thread) = New List(Of Thread)

    Dim ThreadDeleteEmployeeWorkExp As Thread
    Dim threadlistdeleteemployeeWorkExp As List(Of Thread) = New List(Of Thread)

    Dim ThreadDeleteEmployeeEduc As Thread
    Dim threadlistdeleteemployeeEduc As List(Of Thread) = New List(Of Thread)

    Dim ThreadDeleteEmployeeRelationship As Thread
    Dim threadlistdeleteemployeeRelationship As List(Of Thread) = New List(Of Thread)

    Dim ThreadDeleteEmployeeGovMan As Thread
    Dim threadlistdeleteemployeeGovMan As List(Of Thread) = New List(Of Thread)

    Dim ThreadDeleteEmployeeEmpDetails As Thread
    Dim threadlistdeleteemployeeEmpDetails As List(Of Thread) = New List(Of Thread)
    Private Sub BackgroundWorkerDelete_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerDelete.DoWork
        Try
            Dim empcode = DataGridView1.SelectedRows(0).Cells(0).Value
            For i = 0 To 100
                BackgroundWorkerDelete.ReportProgress(i)
                Thread.Sleep(20)
                If WorkerCancel Then
                    Exit For
                End If
                If i = 0 Then
                    ToolStripStatusLabel1.Text = "Processing. Please wait."
                    ThreadDeleteEmployeeBasic = New Thread(Sub() DeleteCloud("tblemployeepersonal", "empcode = '" & DataGridView1.SelectedRows(0).Cells(0).Value & "'"))
                    ThreadDeleteEmployeeBasic.Start()
                    threadlistdeleteemployeeBasic.Add(ThreadDeleteEmployeeBasic)
                End If
                For Each t In threadlistdeleteemployeeBasic
                    t.Join()
                    If (BackgroundWorkerDelete.CancellationPending) Then
                        e.Cancel = True
                        Exit For
                    End If
                Next
                If i = 15 Then
                    ThreadDeleteEmployeeWorkExp = New Thread(Sub() DeleteCloud("tblworkexperience", "empcode = '" & DataGridView1.SelectedRows(0).Cells(0).Value & "'"))
                    ThreadDeleteEmployeeWorkExp.Start()
                    threadlistdeleteemployeeWorkExp.Add(ThreadDeleteEmployeeWorkExp)
                End If
                For Each t In threadlistdeleteemployeeWorkExp
                    t.Join()
                    If (BackgroundWorkerDelete.CancellationPending) Then
                        e.Cancel = True
                        Exit For
                    End If
                Next
                If i = 30 Then
                    ThreadDeleteEmployeeEduc = New Thread(Sub() DeleteCloud("tbleducationalbg", "empcode = '" & DataGridView1.SelectedRows(0).Cells(0).Value & "'"))
                    ThreadDeleteEmployeeEduc.Start()
                    threadlistdeleteemployeeEduc.Add(ThreadDeleteEmployeeEduc)
                End If
                For Each t In threadlistdeleteemployeeEduc
                    t.Join()
                    If (BackgroundWorkerDelete.CancellationPending) Then
                        e.Cancel = True
                        Exit For
                    End If
                Next
                If i = 45 Then
                    ThreadDeleteEmployeeRelationship = New Thread(Sub() DeleteCloud("tblrelationshipinfo", "empcode = '" & DataGridView1.SelectedRows(0).Cells(0).Value & "'"))
                    ThreadDeleteEmployeeRelationship.Start()
                    threadlistdeleteemployeeRelationship.Add(ThreadDeleteEmployeeRelationship)
                End If
                For Each t In threadlistdeleteemployeeRelationship
                    t.Join()
                    If (BackgroundWorkerDelete.CancellationPending) Then
                        e.Cancel = True
                        Exit For
                    End If
                Next
                If i = 60 Then
                    ThreadDeleteEmployeeGovMan = New Thread(Sub() DeleteCloud("tblgovmandatories", "empcode = '" & DataGridView1.SelectedRows(0).Cells(0).Value & "'"))
                    ThreadDeleteEmployeeGovMan.Start()
                    threadlistdeleteemployeeGovMan.Add(ThreadDeleteEmployeeGovMan)
                End If
                For Each t In threadlistdeleteemployeeGovMan
                    t.Join()
                    If (BackgroundWorkerDelete.CancellationPending) Then
                        e.Cancel = True
                        Exit For
                    End If
                Next
                If i = 75 Then
                    ThreadDeleteEmployeeEmpDetails = New Thread(Sub() DeleteCloud("tblemploymentdetails", "empcode = '" & DataGridView1.SelectedRows(0).Cells(0).Value & "'"))
                    ThreadDeleteEmployeeEmpDetails.Start()
                    threadlistdeleteemployeeEmpDetails.Add(ThreadDeleteEmployeeEmpDetails)
                End If
                For Each t In threadlistdeleteemployeeEmpDetails
                    t.Join()
                    If (BackgroundWorkerDelete.CancellationPending) Then
                        e.Cancel = True
                        Exit For
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BackgroundWorkerDelete_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorkerDelete.ProgressChanged
        Try
            If WorkerCancel = False Then
                ToolStripProgressBar1.Value = e.ProgressPercentage
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BackgroundWorkerDelete_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerDelete.RunWorkerCompleted
        Try
            DataGridView1.Enabled = True
            ToolStripButton1.Enabled = False
            ToolStripButton3.Enabled = False
            ToolStripButton4.Enabled = False
            If ValidCloudConnection Then
                ToolStripProgressBar1.Value = 0
                BackgroundWorkerpersonalinfo.WorkerReportsProgress = True
                BackgroundWorkerpersonalinfo.WorkerSupportsCancellation = True
                BackgroundWorkerpersonalinfo.RunWorkerAsync()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class