Imports System.Drawing.Imaging
Imports System.Threading
Imports MySql.Data.MySqlClient

Public Class frmEmployees
    Dim CompanyID
    Dim BranchID
    Dim DeptID
    Dim TeamID
    Public UpdateEmployeeDetails As Boolean = False
    Public UpdateEmployeeID
    Dim Pagination As Integer = 1
    Dim imagepath As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'TextBoxPIImage.Text = Nothing
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "PNG Images|*.png|JPG Images|*.jpg|JPEG Images|*.jpeg"
        If Me.OpenFileDialog1.ShowDialog = 1 Then
            'Me.PictureBoxPIImage.Image = System.Drawing.Image.FromFile(Me.OpenFileDialog1().FileName)
        End If

        If My.Computer.FileSystem.FileExists(imagepath) Then
            Dim ImageToConvert As Bitmap = Bitmap.FromFile(imagepath)
            'TextBoxPIImage.Text = ImageToBase64(ImageToConvert, ImageFormat.Png)
        End If
    End Sub
    Dim threadlistloademploymentdetails As List(Of Thread) = New List(Of Thread)
    Dim ThreadCompany As Thread
    Dim ThreadBranch As Thread
    Dim ThreadDept As Thread
    Dim ThreadTeam As Thread
    Private Sub frmEmployees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            PNSCButtonEnability(False)
            BackgroundWorker2.WorkerReportsProgress = True
            BackgroundWorker2.WorkerSupportsCancellation = True
            BackgroundWorker2.RunWorkerAsync()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Dim CompanyDatatable As DataTable = New DataTable
    Dim BranchDatatable As DataTable = New DataTable
    Dim DeptDatatable As DataTable = New DataTable
    Dim TeamDatatable As DataTable = New DataTable

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
                    ThreadCompany = New Thread(Sub() CompanyDatatable = GetCompany(1))
                    ThreadCompany.Start()
                    threadlistloademploymentdetails.Add(ThreadCompany)
                End If
                If i = 20 Then
                    ThreadBranch = New Thread(Sub() BranchDatatable = GetBranch(1))
                    ThreadBranch.Start()
                    threadlistloademploymentdetails.Add(ThreadBranch)
                End If
                If i = 60 Then
                    ThreadDept = New Thread(Sub() DeptDatatable = GetDept(1))
                    ThreadDept.Start()
                    threadlistloademploymentdetails.Add(ThreadDept)
                End If
                If i = 80 Then
                    ThreadTeam = New Thread(Sub() TeamDatatable = GetTeam(1))
                    ThreadTeam.Start()
                    threadlistloademploymentdetails.Add(ThreadTeam)
                End If
            Next
            For Each t In threadlistloademploymentdetails
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
            ToolStripStatusLabel1.Text = "Complete"
            ComboBoxCompany.Items.Clear()
            ComboBoxBranch.Items.Clear()
            ComboBoxDepartment.Items.Clear()
            ComboBoxTeam.Items.Clear()

            With CompanyDatatable
                For Each row As DataRow In .Rows
                    If WorkerCancel Then
                        Exit For
                    End If
                    ComboBoxCompany.Items.Add(row("companyname"))
                Next

            End With
            With BranchDatatable
                For Each row As DataRow In .Rows
                    If WorkerCancel Then
                        Exit For
                    End If
                    ComboBoxBranch.Items.Add(row("branch_name"))
                Next

            End With
            With DeptDatatable
                For Each row As DataRow In .Rows
                    If WorkerCancel Then
                        Exit For
                    End If
                    ComboBoxDepartment.Items.Add(row("dep_name"))
                Next

            End With
            With TeamDatatable
                For Each row As DataRow In .Rows
                    If WorkerCancel Then
                        Exit For
                    End If
                    ComboBoxTeam.Items.Add(row("teamname"))
                Next

            End With
            PNSCButtonEnability(True)

            If CompanyDatatable.Rows.Count > 0 Then
                ComboBoxCompany.SelectedIndex = 0
            End If
            If BranchDatatable.Rows.Count > 0 Then
                ComboBoxBranch.SelectedIndex = 0
            End If
            If DeptDatatable.Rows.Count > 0 Then
                ComboBoxDepartment.SelectedIndex = 0
            End If
            If TeamDatatable.Rows.Count > 0 Then
                ComboBoxTeam.SelectedIndex = 0
            End If

            If WorkerCancel Then
                Close()
            End If

            If UpdateEmployeeDetails Then
                BackgroundWorker3.WorkerReportsProgress = True
                BackgroundWorker3.WorkerSupportsCancellation = True
                BackgroundWorker3.RunWorkerAsync()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim threadlistFillDetails As List(Of Thread) = New List(Of Thread)
    Dim ThreadFillDetails As Thread
    Private Sub BackgroundWorker3_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        Try
            For i = 0 To 50
                BackgroundWorker3.ReportProgress(i)
                Thread.Sleep(20)
                If WorkerCancel Then
                    Exit For
                End If
                If UpdateEmployeeDetails Then
                    If i = 0 Then
                        ThreadFillDetails = New Thread(Sub() FillDetails())
                        ThreadFillDetails.Start()
                        threadlistFillDetails.Add(ThreadFillDetails)
                    End If
                End If

            Next
            For Each t In threadlistFillDetails
                t.Join()
                If (BackgroundWorker3.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub BackgroundWorker3_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted

    End Sub
    Public FillDetailsWorkExperienceDT As DataTable
    Public FillDetailsEducationBG As DataTable
    Public FillDetailsRelationshipInfo As DataTable
    Public FillDetailsGovMandatories As DataTable

    Private Sub FillDetails()
        Try
            TextBoxFirstName.Text = EmployeeBasicInfoArray(0)
            TextBoxMiddleName.Text = EmployeeBasicInfoArray(1)
            TextBoxLastName.Text = EmployeeBasicInfoArray(2)
            TextBoxSuffix.Text = EmployeeBasicInfoArray(3)
            DateTimePickerBirthDate.Value = EmployeeBasicInfoArray(4)
            TextBoxAge.Text = EmployeeBasicInfoArray(5)
            TextBoxContact.Text = EmployeeBasicInfoArray(6)
            ComboBoxGender.SelectedIndex = ComboBoxGender.FindStringExact(EmployeeBasicInfoArray(7))
            ComboBoxMaritalStatus.SelectedIndex = ComboBoxMaritalStatus.FindStringExact(EmployeeBasicInfoArray(8))
            TextBoxAddress1.Text = EmployeeBasicInfoArray(9)
            TextBoxAddress2.Text = EmployeeBasicInfoArray(10)


            TextBoxMothersName.Text = EmployeeBasicInfoArray(11)
            TextBoxFathersName.Text = EmployeeBasicInfoArray(12)
            TextBoxSpouseName.Text = EmployeeBasicInfoArray(13)

            TextBoxMothersOcc.Text = EmployeeBasicInfoArray(14)
            TextBoxFathersOcc.Text = EmployeeBasicInfoArray(15)
            TextBoxSpouseOcc.Text = EmployeeBasicInfoArray(16)

            PictureBoxImage.Image = Base64ToImage(EmployeeBasicInfoArray(17))
            TextBoxImage.Text = EmployeeBasicInfoArray(17)

            For Each row As DataRow In FillDetailsWorkExperienceDT.Rows
                DataGridViewWorkExperience.Rows.Add(row("id"), row("companyname"), row("position"))
            Next
            For Each row As DataRow In FillDetailsEducationBG.Rows
                DataGridViewEducationalBackground.Rows.Add(row("id"), row("schoolname"), row("level"), row("degree"), row("year"))
            Next
            For Each row As DataRow In FillDetailsRelationshipInfo.Rows
                DataGridViewRelationshipInfo.Rows.Add(row("id"), row("name"), row("relationship"), row("contact"), row("emergency"))
            Next
            For Each row As DataRow In FillDetailsGovMandatories.Rows
                DataGridViewGovMandatories.Rows.Add(row("id"), row("agency"), row("subscribernumber"))
            Next

            ComboBoxCompany.SelectedIndex = ComboBoxCompany.FindStringExact(EmployeeEmploymentDetailsArray(0))
            ComboBoxBranch.SelectedIndex = ComboBoxBranch.FindStringExact(EmployeeEmploymentDetailsArray(1))
            ComboBoxDepartment.SelectedIndex = ComboBoxDepartment.FindStringExact(EmployeeEmploymentDetailsArray(2))
            ComboBoxTeam.SelectedIndex = ComboBoxTeam.FindStringExact(EmployeeEmploymentDetailsArray(3))
            TextBoxPosition.Text = EmployeeEmploymentDetailsArray(4)
            TextBoxSalary.Text = EmployeeEmploymentDetailsArray(5)
            DateTimePickerDateHired.Value = EmployeeEmploymentDetailsArray(6)
            ComboBoxStatus.SelectedIndex = ComboBoxStatus.FindStringExact(EmployeeEmploymentDetailsArray(7))

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub ButtonBrowse_Click(sender As Object, e As EventArgs) Handles ButtonBrowse.Click
        TextBoxImage.Text = Nothing
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "PNG Images|*.png|JPG Images|*.jpg|JPEG Images|*.jpeg"
        If Me.OpenFileDialog1.ShowDialog = 1 Then
            PictureBoxImage.Image = System.Drawing.Image.FromFile(Me.OpenFileDialog1().FileName)
        End If

        If My.Computer.FileSystem.FileExists(imagepath) Then
            Dim ImageToConvert As Bitmap = Bitmap.FromFile(imagepath)
            TextBoxImage.Text = ImageToBase64(ImageToConvert, ImageFormat.Png)
        End If
    End Sub
    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        imagepath = OpenFileDialog1.FileName
    End Sub
    Private Sub PNSCButtonEnability(ByVal Status As Boolean)
        Try
            ButtonBrowse.Enabled = Status
            ButtonPrevious.Enabled = Status
            ButtonNext.Enabled = Status
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click
        If Pagination = 1 Then
        ElseIf Pagination = 2 Then
            Pagination = 1
            HideGroupBox(GroupBoxBasicInfo)
        ElseIf Pagination = 3 Then
            Pagination = 2
            HideGroupBox(GroupBoxWorkExperience)
        ElseIf Pagination = 4 Then
            Pagination = 3
            HideGroupBox(GroupBoxEducational)
        ElseIf Pagination = 5 Then
            Pagination = 4
            HideGroupBox(GroupBoxRelationshipInfo)
        ElseIf Pagination = 6 Then
            Pagination = 5
            HideGroupBox(GroupBoxGovMandatories)
            ButtonSave.Enabled = False
        ElseIf Pagination = 7 Then
            Pagination = 6
            HideGroupBox(GroupBoxEmploymentDetails)
        End If


    End Sub
    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        If Pagination = 1 Then
            Pagination = 2
            HideGroupBox(GroupBoxWorkExperience)
        ElseIf Pagination = 2 Then
            Pagination = 3
            HideGroupBox(GroupBoxEducational)
        ElseIf Pagination = 3 Then
            Pagination = 4
            HideGroupBox(GroupBoxRelationshipInfo)
        ElseIf Pagination = 4 Then
            Pagination = 5
            HideGroupBox(GroupBoxGovMandatories)
        ElseIf Pagination = 5 Then
            Pagination = 6
            HideGroupBox(GroupBoxEmploymentDetails)
            ButtonSave.Enabled = True
        End If
    End Sub
    Private Sub HideGroupBox(groupBox)
        Try
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is GroupBox Then
                    If ctrl.Name <> groupBox.name Then
                        CType(ctrl, GroupBox).Visible = False
                    Else
                        CType(ctrl, GroupBox).Visible = True
                        groupBox.Left = 12
                        groupBox.Top = 12
                    End If
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub ComboBoxCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCompany.SelectedIndexChanged
        Try
            Dim result() As DataRow = CompanyDatatable.Select("companyname ='" & ComboBoxCompany.Text & "'")
            For Each row As DataRow In result
                CompanyID = row(0)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBoxBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxBranch.SelectedIndexChanged
        Try
            Dim result() As DataRow = BranchDatatable.Select("branch_name ='" & ComboBoxBranch.Text & "'")
            For Each row As DataRow In result
                BranchID = row(0)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBoxDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDepartment.SelectedIndexChanged
        Try
            Dim result() As DataRow = DeptDatatable.Select("dep_name ='" & ComboBoxDepartment.Text & "'")
            For Each row As DataRow In result
                DeptID = row(0)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBoxTeam_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxTeam.SelectedIndexChanged
        Try
            Dim result() As DataRow = TeamDatatable.Select("teamname ='" & ComboBoxTeam.Text & "'")
            For Each row As DataRow In result
                TeamID = row(0)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        Try
            BackgroundWorker1.WorkerReportsProgress = True
            BackgroundWorker1.WorkerSupportsCancellation = True
            BackgroundWorker1.RunWorkerAsync()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim WorkerCancel As Boolean = False

    Dim threadlistGenerateCode As List(Of Thread) = New List(Of Thread)
    Dim ThreadGenerateCode As Thread

    Dim threadlistBasicInfo As List(Of Thread) = New List(Of Thread)
    Dim ThreadBasicInfo As Thread

    Dim threadlistWorkExperience As List(Of Thread) = New List(Of Thread)
    Dim ThreadWorkExperience As Thread

    Dim threadlistEducBG As List(Of Thread) = New List(Of Thread)
    Dim ThreadEducBG As Thread

    Dim threadlistRelationShip As List(Of Thread) = New List(Of Thread)
    Dim ThreadRelationShip As Thread

    Dim threadlistGovMandatories As List(Of Thread) = New List(Of Thread)
    Dim ThreadGovMandatories As Thread

    Dim threadlistEmploymentDetails As List(Of Thread) = New List(Of Thread)
    Dim ThreadEmploymentDetails As Thread


    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            For i = 0 To 100
                BackgroundWorker1.ReportProgress(i)
                Thread.Sleep(20)
                If WorkerCancel Then
                    Exit For
                End If
                If UpdateEmployeeDetails Then
                    If i = 0 Then
                        ToolStripStatusLabel1.Text = "Loading. Please wait."
                        ThreadBasicInfo = New Thread(Sub() UpdateBasicInfo(UpdateEmployeeID))
                        ThreadBasicInfo.Start()
                        threadlistBasicInfo.Add(ThreadBasicInfo)

                        ThreadWorkExperience = New Thread(Sub() UpdateWorkExperience())
                        ThreadWorkExperience.Start()
                        threadlistWorkExperience.Add(ThreadWorkExperience)

                        ThreadEducBG = New Thread(Sub() UpdateEducationalBG())
                        ThreadEducBG.Start()
                        threadlistEducBG.Add(ThreadEducBG)

                        ThreadRelationShip = New Thread(Sub() UpdateRelationshipInfo())
                        ThreadRelationShip.Start()
                        threadlistRelationShip.Add(ThreadRelationShip)

                        ThreadGovMandatories = New Thread(Sub() UpdateGovMandatories())
                        ThreadGovMandatories.Start()
                        threadlistGovMandatories.Add(ThreadGovMandatories)

                        ThreadEmploymentDetails = New Thread(Sub() UpdateEmploymentDetails(UpdateEmployeeID))
                        ThreadEmploymentDetails.Start()
                        threadlistEmploymentDetails.Add(ThreadEmploymentDetails)
                    End If
                Else

                    If i = 0 Then
                        ThreadGenerateCode = New Thread(Sub() GenerateEmpCode(ComboBoxCompany.Text))
                        ThreadGenerateCode.Start()
                        threadlistGenerateCode.Add(ThreadGenerateCode)
                    End If
                    For Each t In threadlistGenerateCode
                        t.Join()
                        If (BackgroundWorker1.CancellationPending) Then
                            ' Indicate that the task was canceled.
                            e.Cancel = True
                            Exit For
                        End If
                    Next
                    If i = 10 Then
                        ToolStripStatusLabel1.Text = "Loading. Please wait."
                        ThreadBasicInfo = New Thread(Sub() SaveBasicInfo())
                        ThreadBasicInfo.Start()
                        threadlistBasicInfo.Add(ThreadBasicInfo)

                        ThreadWorkExperience = New Thread(Sub() SaveWorkExperience())
                        ThreadWorkExperience.Start()
                        threadlistWorkExperience.Add(ThreadWorkExperience)

                        ThreadEducBG = New Thread(Sub() SaveEducationalBG())
                        ThreadEducBG.Start()
                        threadlistEducBG.Add(ThreadEducBG)

                        ThreadRelationShip = New Thread(Sub() SaveRelationshipInfo())
                        ThreadRelationShip.Start()
                        threadlistRelationShip.Add(ThreadRelationShip)

                        ThreadGovMandatories = New Thread(Sub() SaveGovMandatories())
                        ThreadGovMandatories.Start()
                        threadlistGovMandatories.Add(ThreadGovMandatories)

                        ThreadEmploymentDetails = New Thread(Sub() SaveEmploymentDetails())
                        ThreadEmploymentDetails.Start()
                        threadlistEmploymentDetails.Add(ThreadEmploymentDetails)
                    End If
                End If


            Next
            For Each t In threadlistBasicInfo
                t.Join()
                If (BackgroundWorker1.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
            For Each t In threadlistWorkExperience
                t.Join()
                If (BackgroundWorker1.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
            For Each t In threadlistEducBG
                t.Join()
                If (BackgroundWorker1.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
            For Each t In threadlistRelationShip
                t.Join()
                If (BackgroundWorker1.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
            For Each t In threadlistGovMandatories
                t.Join()
                If (BackgroundWorker1.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If
            Next
            For Each t In threadlistEmploymentDetails
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
            Home.newMDIchildEmployee.BackgroundWorkerpersonalinfo.WorkerReportsProgress = True
            Home.newMDIchildEmployee.BackgroundWorkerpersonalinfo.WorkerSupportsCancellation = True
            Home.newMDIchildEmployee.BackgroundWorkerpersonalinfo.RunWorkerAsync()
            'Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim GeneratedEmployeeCode As String = ""
    Private Sub GenerateEmpCode(companyname)
        Try
            Dim prefix As String = ""
            Dim prefixid As String = ""
            Dim prefixFormat As String = "{0:0000}"
            Dim EmployeeGeneratedCode As String = ""
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim sql = "SELECT companycode FROM tblcompany WHERE companyname = '" & companyname & "'"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionServer)
            Using reader As MySqlDataReader = cmd.ExecuteReader
                If reader.HasRows Then
                    While reader.Read
                        prefix = reader("companycode")
                    End While
                End If
            End Using
            cmd.Dispose()

            Dim FetchEmpCode As String = ""
            sql = "SELECT empcode FROM hrbuddy.tblemployeepersonal ORDER BY empid DESC LIMIT 1"
            cmd = New MySqlCommand(sql, ConnectionServer)
            Using reader As MySqlDataReader = cmd.ExecuteReader
                If reader.HasRows Then
                    While reader.Read

                        Dim myChars() As Char = reader("empcode").ToCharArray()
                        For Each ch As Char In myChars
                            If Char.IsDigit(ch) Then
                                FetchEmpCode &= ch
                            End If
                        Next

                        Dim EmpNumber As Integer = Convert.ToInt64(FetchEmpCode)
                        EmpNumber += 1
                        prefixid = String.Format(prefixFormat, EmpNumber)
                    End While
                End If
            End Using

            If FetchEmpCode = "" Then
                EmployeeGeneratedCode = prefix & "-0001"
                GeneratedEmployeeCode = EmployeeGeneratedCode
            Else
                EmployeeGeneratedCode = prefix & "-" & prefixid
                GeneratedEmployeeCode = EmployeeGeneratedCode
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub SaveBasicInfo()
        Try
            Dim Fields = "`empcode`,`first`,`mid`,`last`,`suffix`,`bdate`,`age`,`contact`,`gender`,`maritalstatus`,`address1`,`address2`
            ,`mothersname`,`fathersname`,`spousename`,`mothersoccupation`,`fathersoccupation`,`spouseoccupation`,`modifier`,`updatedat`,`createdat`,`image`,`status`"
            Dim Values = " '" & GeneratedEmployeeCode & "','" & Trim(TextBoxFirstName.Text) & "','" & Trim(TextBoxMiddleName.Text) & "','" & Trim(TextBoxLastName.Text) & "','" & Trim(TextBoxSuffix.Text) &
            "','" & DateTimePickerBirthDate.Value & "','" & Trim(TextBoxAge.Text) & "','" & Trim(TextBoxContact.Text) &
            "','" & ComboBoxGender.Text & "','" & ComboBoxMaritalStatus.Text & "', '" & Trim(TextBoxAddress1.Text) & "', '" & Trim(TextBoxAddress2.Text) & "','" & Trim(TextBoxMothersName.Text) & "', '" & Trim(TextBoxFathersName.Text) & "', '" & Trim(TextBoxSpouseName.Text) & "', '" & Trim(TextBoxMothersOcc.Text) &
            "', '" & Trim(TextBoxFathersOcc.Text) & "', '" & Trim(TextBoxSpouseOcc.Text) & "','" & HRUsername & "', '" & FullDate24HR() & "', '" & FullDate24HR() & "', '" & TextBoxImage.Text & "', 'Active'"
            InsertSingleQueryCloud("tblemployeepersonal", Fields, Values)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub SaveWorkExperience()
        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim cmd As MySqlCommand
            With DataGridViewWorkExperience
                For i As Integer = 0 To .Rows.Count - 1 Step +1
                    If WorkerCancel = True Then
                        Exit For
                    End If
                    cmd = New MySqlCommand("INSERT INTO `tblworkexperience` (`empcode`,`companyname`,`position`,`modifiedby`,`createdat`,`updatedat`,`status`) VALUES (@1,@2,@3,@4,@5,@6,@7)", ConnectionServer)
                    cmd.Parameters.Add("@1", MySqlDbType.Text).Value = GeneratedEmployeeCode
                    cmd.Parameters.Add("@2", MySqlDbType.Text).Value = .Rows(i).Cells(1).Value.ToString()
                    cmd.Parameters.Add("@3", MySqlDbType.Text).Value = .Rows(i).Cells(2).Value.ToString()
                    cmd.Parameters.Add("@4", MySqlDbType.Text).Value = HRUsername
                    cmd.Parameters.Add("@5", MySqlDbType.Text).Value = FullDate24HR()
                    cmd.Parameters.Add("@6", MySqlDbType.Text).Value = FullDate24HR()
                    cmd.Parameters.Add("@7", MySqlDbType.Text).Value = "Active"
                    cmd.ExecuteNonQuery()
                Next
            End With
            ConnectionServer.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub SaveEducationalBG()
        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim cmd As MySqlCommand
            With DataGridViewEducationalBackground
                For i As Integer = 0 To .Rows.Count - 1 Step +1
                    If WorkerCancel = True Then
                        Exit For
                    End If
                    cmd = New MySqlCommand("INSERT INTO `tbleducationalbg` (`empcode`,`schoolname`,`level`,`degree`,`year`,`modifiedby`,`createdat`,`updatedat`,`status`) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9)", ConnectionServer)
                    cmd.Parameters.Add("@1", MySqlDbType.Text).Value = GeneratedEmployeeCode
                    cmd.Parameters.Add("@2", MySqlDbType.Text).Value = .Rows(i).Cells(1).Value.ToString()
                    cmd.Parameters.Add("@3", MySqlDbType.Text).Value = .Rows(i).Cells(2).Value.ToString()
                    cmd.Parameters.Add("@4", MySqlDbType.Text).Value = .Rows(i).Cells(3).Value.ToString()
                    cmd.Parameters.Add("@5", MySqlDbType.Text).Value = .Rows(i).Cells(4).Value.ToString()
                    cmd.Parameters.Add("@6", MySqlDbType.Text).Value = HRUsername
                    cmd.Parameters.Add("@7", MySqlDbType.Text).Value = FullDate24HR()
                    cmd.Parameters.Add("@8", MySqlDbType.Text).Value = FullDate24HR()
                    cmd.Parameters.Add("@9", MySqlDbType.Text).Value = "Active"
                    cmd.ExecuteNonQuery()
                Next
            End With
            ConnectionServer.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub SaveRelationshipInfo()
        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim cmd As MySqlCommand
            With DataGridViewRelationshipInfo
                For i As Integer = 0 To .Rows.Count - 1 Step +1
                    If WorkerCancel = True Then
                        Exit For
                    End If
                    cmd = New MySqlCommand("INSERT INTO `tblrelationshipinfo` (`empcode`,`name`,`relationship`,`contact`,`emergency`,`modifiedby`,`createdat`,`updatedat`,`status`) VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9)", ConnectionServer)
                    cmd.Parameters.Add("@1", MySqlDbType.Text).Value = GeneratedEmployeeCode
                    cmd.Parameters.Add("@2", MySqlDbType.Text).Value = .Rows(i).Cells(1).Value.ToString()
                    cmd.Parameters.Add("@3", MySqlDbType.Text).Value = .Rows(i).Cells(2).Value.ToString()
                    cmd.Parameters.Add("@4", MySqlDbType.Text).Value = .Rows(i).Cells(3).Value.ToString()
                    cmd.Parameters.Add("@5", MySqlDbType.Text).Value = .Rows(i).Cells(4).Value.ToString()
                    cmd.Parameters.Add("@6", MySqlDbType.Text).Value = HRUsername
                    cmd.Parameters.Add("@7", MySqlDbType.Text).Value = FullDate24HR()
                    cmd.Parameters.Add("@8", MySqlDbType.Text).Value = FullDate24HR()
                    cmd.Parameters.Add("@9", MySqlDbType.Text).Value = "Active"
                    cmd.ExecuteNonQuery()
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub SaveGovMandatories()
        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim cmd As MySqlCommand
            With DataGridViewGovMandatories
                For i As Integer = 0 To .Rows.Count - 1 Step +1
                    If WorkerCancel = True Then
                        Exit For
                    End If

                    cmd = New MySqlCommand("INSERT INTO `tblgovmandatories` (`empcode`,`agency`,`subscribernumber`,`modifiedby`,`createdat`,`updatedat`,`status`) VALUES (@1,@2,@3,@4,@5,@6,@7)", ConnectionServer)
                    cmd.Parameters.Add("@1", MySqlDbType.Text).Value = GeneratedEmployeeCode
                    cmd.Parameters.Add("@2", MySqlDbType.Text).Value = .Rows(i).Cells(1).Value.ToString()
                    cmd.Parameters.Add("@3", MySqlDbType.Text).Value = .Rows(i).Cells(2).Value.ToString()
                    cmd.Parameters.Add("@4", MySqlDbType.Text).Value = HRUsername
                    cmd.Parameters.Add("@5", MySqlDbType.Text).Value = FullDate24HR()
                    cmd.Parameters.Add("@6", MySqlDbType.Text).Value = FullDate24HR()
                    cmd.Parameters.Add("@7", MySqlDbType.Text).Value = "Active"
                    cmd.ExecuteNonQuery()

                Next
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub SaveEmploymentDetails()
        Try
            Dim Fields = "`empcode`,`company`,`branch`,`department`,`team`,`position`,`salary`,`datehired`,`modifiedby`,`createdat`,`updatedat`,`status`"
            Dim Values = " '" & GeneratedEmployeeCode & "', '" & CompanyID & "','" & BranchID & "','" & DeptID &
            "','" & TeamID & "','" & Trim(TextBoxPosition.Text) & "','" & Trim(TextBoxSalary.Text) &
            "','" & DateTimePickerDateHired.Text & "','" & HRUsername & "', '" & FullDate24HR() & "', '" & FullDate24HR() &
            "', 'Active'"
            InsertSingleQueryCloud("tblemploymentdetails", Fields, Values)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub UpdateBasicInfo(empcode)
        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim sql = "UPDATE `tblemployeepersonal` SET `first` = @1,`mid` = @2,`last` = @3,`suffix` = @4,`bdate` = @5,`age` = @6,`contact` = @7
            ,`gender` = @8,`maritalstatus` = @9,`address1` = @10,`address2` = @11 ,`mothersname` = @12,`fathersname` = @13,`spousename` = @14,`mothersoccupation` = @15,`fathersoccupation` = @16
            ,`spouseoccupation` = @17,`modifier` = @18, `updatedat` = @19, `image` = @20 WHERE `empcode` = '" & empcode & "'"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionServer)
            cmd.Parameters.Add("@1", MySqlDbType.Text).Value = Trim(TextBoxFirstName.Text)
            cmd.Parameters.Add("@2", MySqlDbType.Text).Value = TextBoxMiddleName.Text
            cmd.Parameters.Add("@3", MySqlDbType.Text).Value = TextBoxLastName.Text
            cmd.Parameters.Add("@4", MySqlDbType.Text).Value = TextBoxSuffix.Text
            cmd.Parameters.Add("@5", MySqlDbType.Text).Value = DateTimePickerBirthDate.Value
            cmd.Parameters.Add("@6", MySqlDbType.Text).Value = TextBoxAge.Text
            cmd.Parameters.Add("@7", MySqlDbType.Text).Value = TextBoxContact.Text
            cmd.Parameters.Add("@8", MySqlDbType.Text).Value = ComboBoxGender.Text
            cmd.Parameters.Add("@9", MySqlDbType.Text).Value = ComboBoxMaritalStatus.Text
            cmd.Parameters.Add("@10", MySqlDbType.Text).Value = TextBoxAddress1.Text
            cmd.Parameters.Add("@11", MySqlDbType.Text).Value = TextBoxAddress2.Text
            cmd.Parameters.Add("@12", MySqlDbType.Text).Value = TextBoxMothersName.Text
            cmd.Parameters.Add("@13", MySqlDbType.Text).Value = TextBoxFathersName.Text
            cmd.Parameters.Add("@14", MySqlDbType.Text).Value = TextBoxSpouseName.Text
            cmd.Parameters.Add("@15", MySqlDbType.Text).Value = TextBoxMothersOcc.Text
            cmd.Parameters.Add("@16", MySqlDbType.Text).Value = TextBoxFathersOcc.Text
            cmd.Parameters.Add("@17", MySqlDbType.Text).Value = TextBoxSpouseOcc.Text
            cmd.Parameters.Add("@18", MySqlDbType.Text).Value = HRUsername
            cmd.Parameters.Add("@19", MySqlDbType.Text).Value = FullDate24HR()
            cmd.Parameters.Add("@20", MySqlDbType.LongText).Value = TextBoxImage.Text
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub UpdateWorkExperience()
        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim cmd As MySqlCommand
            With DataGridViewWorkExperience
                For i As Integer = 0 To .Rows.Count - 1 Step +1
                    cmd = New MySqlCommand("UPDATE `tblworkexperience` SET `companyname` = @1,`position` = @2,`modifiedby` = @3,`updatedat` = @4 WHERE id = @5", ConnectionServer)
                    cmd.Parameters.Add("@1", MySqlDbType.Text).Value = .Rows(i).Cells(1).Value
                    cmd.Parameters.Add("@2", MySqlDbType.Text).Value = .Rows(i).Cells(2).Value
                    cmd.Parameters.Add("@3", MySqlDbType.Text).Value = HRUsername
                    cmd.Parameters.Add("@4", MySqlDbType.Text).Value = FullDate24HR()
                    cmd.Parameters.Add("@5", MySqlDbType.Text).Value = .Rows(i).Cells(0).Value
                    cmd.ExecuteNonQuery()
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub UpdateEducationalBG()
        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim cmd As MySqlCommand
            With DataGridViewEducationalBackground
                For i As Integer = 0 To .Rows.Count - 1 Step +1
                    cmd = New MySqlCommand("UPDATE `tbleducationalbg` SET `schoolname` = @1,`level` = @2,`degree` = @3,`year` = @4,`modifiedby` = @5,`updatedat` = @6 WHERE `id` = @7;", ConnectionServer)
                    cmd.Parameters.Add("@1", MySqlDbType.Text).Value = .Rows(i).Cells(1).Value
                    cmd.Parameters.Add("@2", MySqlDbType.Text).Value = .Rows(i).Cells(2).Value
                    cmd.Parameters.Add("@3", MySqlDbType.Text).Value = .Rows(i).Cells(3).Value
                    cmd.Parameters.Add("@4", MySqlDbType.Text).Value = .Rows(i).Cells(4).Value
                    cmd.Parameters.Add("@5", MySqlDbType.Text).Value = HRUsername
                    cmd.Parameters.Add("@6", MySqlDbType.Text).Value = FullDate24HR()
                    cmd.Parameters.Add("@7", MySqlDbType.Text).Value = .Rows(i).Cells(0).Value
                    cmd.ExecuteNonQuery()
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub UpdateRelationshipInfo()
        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim cmd As MySqlCommand
            With DataGridViewRelationshipInfo
                For i As Integer = 0 To .Rows.Count - 1 Step +1
                    cmd = New MySqlCommand("UPDATE `tblrelationshipinfo` SET `name` = @1,`relationship` = @2,`contact` = @3,`emergency` = @4,`modifiedby` = @5,`updatedat` = @6 WHERE `id` = @7;", ConnectionServer)
                    cmd.Parameters.Add("@1", MySqlDbType.Text).Value = .Rows(i).Cells(1).Value
                    cmd.Parameters.Add("@2", MySqlDbType.Text).Value = .Rows(i).Cells(2).Value
                    cmd.Parameters.Add("@3", MySqlDbType.Text).Value = .Rows(i).Cells(3).Value
                    cmd.Parameters.Add("@4", MySqlDbType.Text).Value = .Rows(i).Cells(4).Value
                    cmd.Parameters.Add("@5", MySqlDbType.Text).Value = HRUsername
                    cmd.Parameters.Add("@6", MySqlDbType.Text).Value = FullDate24HR()
                    cmd.Parameters.Add("@7", MySqlDbType.Text).Value = .Rows(i).Cells(0).Value
                    cmd.ExecuteNonQuery()
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub UpdateGovMandatories()
        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim cmd As MySqlCommand
            With DataGridViewGovMandatories
                For i As Integer = 0 To .Rows.Count - 1 Step +1
                    cmd = New MySqlCommand("UPDATE `tblgovmandatories` SET `agency` = @1,`subscribernumber` = @2,`modifiedby` = @3,`updatedat` = @4 WHERE `id` = @5;", ConnectionServer)
                    cmd.Parameters.Add("@1", MySqlDbType.Text).Value = .Rows(i).Cells(1).Value
                    cmd.Parameters.Add("@2", MySqlDbType.Text).Value = .Rows(i).Cells(2).Value
                    cmd.Parameters.Add("@3", MySqlDbType.Text).Value = HRUsername
                    cmd.Parameters.Add("@4", MySqlDbType.Text).Value = FullDate24HR()
                    cmd.Parameters.Add("@5", MySqlDbType.Text).Value = .Rows(i).Cells(0).Value
                    cmd.ExecuteNonQuery()
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub UpdateEmploymentDetails(empcode)
        Try
            Dim ConnectionServer As MySqlConnection = ServerCloudCon()
            Dim sql = "UPDATE `tblemploymentdetails` SET `company` =@1,`branch` = @2,`department` = @3,`team` = @4,`position` = @5,`salary` = @6,`datehired` = @7,`modifiedby` = @8,`updatedat` = @9,`status` = @10 WHERE `empcode` = @11;"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionServer)

            cmd.Parameters.Add("@1", MySqlDbType.Text).Value = ComboBoxCompany.Text
            cmd.Parameters.Add("@2", MySqlDbType.Text).Value = ComboBoxBranch.Text
            cmd.Parameters.Add("@3", MySqlDbType.Text).Value = ComboBoxDepartment.Text
            cmd.Parameters.Add("@4", MySqlDbType.Text).Value = ComboBoxTeam.Text
            cmd.Parameters.Add("@5", MySqlDbType.Text).Value = TextBoxPosition.Text
            cmd.Parameters.Add("@6", MySqlDbType.Text).Value = TextBoxSalary.Text
            cmd.Parameters.Add("@7", MySqlDbType.Text).Value = DateTimePickerDateHired.Value
            cmd.Parameters.Add("@8", MySqlDbType.Text).Value = HRUsername
            cmd.Parameters.Add("@9", MySqlDbType.Text).Value = FullDate24HR()
            cmd.Parameters.Add("@10", MySqlDbType.Text).Value = ComboBoxStatus.Text
            cmd.Parameters.Add("@11", MySqlDbType.Text).Value = empcode

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Try
            If BackgroundWorker1.IsBusy Or BackgroundWorker2.IsBusy Then
                Dim msg = MessageBox.Show("Are you sure do you want to cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If msg = DialogResult.Yes Then
                    If BackgroundWorker1.IsBusy Then
                        BackgroundWorker1.CancelAsync()
                    End If
                    If BackgroundWorker2.IsBusy Then
                        BackgroundWorker2.CancelAsync()
                    End If
                    WorkerCancel = True
                    Close()
                End If
            Else
                Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub frmEmployees_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Me.UpdateEmployeeDetails = False
            Home.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        DataGridViewWorkExperience.Rows.Add()
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        For Each row As DataGridViewRow In DataGridViewWorkExperience.SelectedRows
            DataGridViewWorkExperience.Rows.Remove(row)
        Next
    End Sub
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        DataGridViewEducationalBackground.Rows.Add()
    End Sub
    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        For Each row As DataGridViewRow In DataGridViewEducationalBackground.SelectedRows
            DataGridViewEducationalBackground.Rows.Remove(row)
        Next
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        DataGridViewRelationshipInfo.Rows.Add()
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        For Each row As DataGridViewRow In DataGridViewRelationshipInfo.SelectedRows
            DataGridViewRelationshipInfo.Rows.Remove(row)
        Next
    End Sub
    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        DataGridViewGovMandatories.Rows.Add()
    End Sub
    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        For Each row As DataGridViewRow In DataGridViewGovMandatories.SelectedRows
            DataGridViewGovMandatories.Rows.Remove(row)
        Next
    End Sub

    Private Sub TextBoxFirstName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSuffix.KeyPress, TextBoxSpouseOcc.KeyPress, TextBoxSpouseName.KeyPress, TextBoxMothersOcc.KeyPress, TextBoxMothersName.KeyPress, TextBoxMiddleName.KeyPress, TextBoxLastName.KeyPress, TextBoxFirstName.KeyPress, TextBoxFathersOcc.KeyPress, TextBoxFathersName.KeyPress, TextBoxContact.KeyPress, TextBoxAge.KeyPress, TextBoxAddress2.KeyPress, TextBoxAddress1.KeyPress, TextBoxPosition.KeyPress, DataGridViewWorkExperience.KeyPress, DataGridViewRelationshipInfo.KeyPress, DataGridViewGovMandatories.KeyPress, DataGridViewEducationalBackground.KeyPress
        Try
            If InStr(DisallowedCharacters, e.KeyChar) > 0 Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TextBoxSalary_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSalary.KeyPress
        Try
            Numeric(sender, e)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class