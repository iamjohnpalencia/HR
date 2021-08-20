<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigManager
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ButtonLocalSave = New System.Windows.Forms.Button()
        Me.ButtonLocalEdit = New System.Windows.Forms.Button()
        Me.ButtonLocalTest = New System.Windows.Forms.Button()
        Me.ButtonLocalImport = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxLocalPort = New System.Windows.Forms.TextBox()
        Me.TextBoxLocalDB = New System.Windows.Forms.TextBox()
        Me.TextBoxLocalPassword = New System.Windows.Forms.TextBox()
        Me.TextBoxLocalUser = New System.Windows.Forms.TextBox()
        Me.TextBoxLocalServer = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ButtonCloudImport = New System.Windows.Forms.Button()
        Me.ButtonCloudTest = New System.Windows.Forms.Button()
        Me.ButtonCloudEdit = New System.Windows.Forms.Button()
        Me.ButtonCloudSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBoxCloudPort = New System.Windows.Forms.TextBox()
        Me.TextBoxCloudDB = New System.Windows.Forms.TextBox()
        Me.TextBoxCloudPassword = New System.Windows.Forms.TextBox()
        Me.TextBoxCloudUser = New System.Windows.Forms.TextBox()
        Me.TextBoxCloudServer = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BackgroundWorkerTestLocal = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorkerTestCloud = New System.ComponentModel.BackgroundWorker()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TabControl1.Location = New System.Drawing.Point(12, 75)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(987, 451)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 30)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(979, 417)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "DATABASE SETTINGS"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 31)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(973, 383)
        Me.TableLayoutPanel2.TabIndex = 21
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(480, 377)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ButtonLocalSave)
        Me.GroupBox1.Controls.Add(Me.ButtonLocalEdit)
        Me.GroupBox1.Controls.Add(Me.ButtonLocalTest)
        Me.GroupBox1.Controls.Add(Me.ButtonLocalImport)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextBoxLocalPort)
        Me.GroupBox1.Controls.Add(Me.TextBoxLocalDB)
        Me.GroupBox1.Controls.Add(Me.TextBoxLocalPassword)
        Me.GroupBox1.Controls.Add(Me.TextBoxLocalUser)
        Me.GroupBox1.Controls.Add(Me.TextBoxLocalServer)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(474, 182)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "System connection (System Administrator Only) For Local"
        '
        'ButtonLocalSave
        '
        Me.ButtonLocalSave.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonLocalSave.Location = New System.Drawing.Point(327, 129)
        Me.ButtonLocalSave.Name = "ButtonLocalSave"
        Me.ButtonLocalSave.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLocalSave.TabIndex = 269
        Me.ButtonLocalSave.Text = "Save"
        Me.ButtonLocalSave.UseVisualStyleBackColor = True
        '
        'ButtonLocalEdit
        '
        Me.ButtonLocalEdit.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonLocalEdit.Location = New System.Drawing.Point(246, 129)
        Me.ButtonLocalEdit.Name = "ButtonLocalEdit"
        Me.ButtonLocalEdit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLocalEdit.TabIndex = 268
        Me.ButtonLocalEdit.Text = "Edit"
        Me.ButtonLocalEdit.UseVisualStyleBackColor = True
        '
        'ButtonLocalTest
        '
        Me.ButtonLocalTest.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonLocalTest.Location = New System.Drawing.Point(165, 129)
        Me.ButtonLocalTest.Name = "ButtonLocalTest"
        Me.ButtonLocalTest.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLocalTest.TabIndex = 267
        Me.ButtonLocalTest.Text = "Test"
        Me.ButtonLocalTest.UseVisualStyleBackColor = True
        '
        'ButtonLocalImport
        '
        Me.ButtonLocalImport.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonLocalImport.Location = New System.Drawing.Point(84, 129)
        Me.ButtonLocalImport.Name = "ButtonLocalImport"
        Me.ButtonLocalImport.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLocalImport.TabIndex = 266
        Me.ButtonLocalImport.Text = "Import"
        Me.ButtonLocalImport.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(281, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 15)
        Me.Label7.TabIndex = 265
        Me.Label7.Text = "Port"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(29, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 15)
        Me.Label6.TabIndex = 264
        Me.Label6.Text = "Schema"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 15)
        Me.Label5.TabIndex = 263
        Me.Label5.Text = "Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 15)
        Me.Label4.TabIndex = 262
        Me.Label4.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 261
        Me.Label2.Text = "Server"
        '
        'TextBoxLocalPort
        '
        Me.TextBoxLocalPort.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxLocalPort.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxLocalPort.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxLocalPort.Location = New System.Drawing.Point(317, 46)
        Me.TextBoxLocalPort.Name = "TextBoxLocalPort"
        Me.TextBoxLocalPort.Size = New System.Drawing.Size(100, 15)
        Me.TextBoxLocalPort.TabIndex = 4
        '
        'TextBoxLocalDB
        '
        Me.TextBoxLocalDB.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxLocalDB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxLocalDB.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxLocalDB.Location = New System.Drawing.Point(84, 108)
        Me.TextBoxLocalDB.Name = "TextBoxLocalDB"
        Me.TextBoxLocalDB.Size = New System.Drawing.Size(333, 15)
        Me.TextBoxLocalDB.TabIndex = 3
        Me.TextBoxLocalDB.UseSystemPasswordChar = True
        '
        'TextBoxLocalPassword
        '
        Me.TextBoxLocalPassword.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxLocalPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxLocalPassword.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxLocalPassword.Location = New System.Drawing.Point(84, 87)
        Me.TextBoxLocalPassword.Name = "TextBoxLocalPassword"
        Me.TextBoxLocalPassword.Size = New System.Drawing.Size(191, 15)
        Me.TextBoxLocalPassword.TabIndex = 2
        Me.TextBoxLocalPassword.UseSystemPasswordChar = True
        '
        'TextBoxLocalUser
        '
        Me.TextBoxLocalUser.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxLocalUser.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxLocalUser.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxLocalUser.Location = New System.Drawing.Point(84, 66)
        Me.TextBoxLocalUser.Name = "TextBoxLocalUser"
        Me.TextBoxLocalUser.Size = New System.Drawing.Size(333, 15)
        Me.TextBoxLocalUser.TabIndex = 1
        Me.TextBoxLocalUser.UseSystemPasswordChar = True
        '
        'TextBoxLocalServer
        '
        Me.TextBoxLocalServer.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxLocalServer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxLocalServer.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxLocalServer.Location = New System.Drawing.Point(84, 45)
        Me.TextBoxLocalServer.Name = "TextBoxLocalServer"
        Me.TextBoxLocalServer.Size = New System.Drawing.Size(191, 15)
        Me.TextBoxLocalServer.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonCloudImport)
        Me.GroupBox2.Controls.Add(Me.ButtonCloudTest)
        Me.GroupBox2.Controls.Add(Me.ButtonCloudEdit)
        Me.GroupBox2.Controls.Add(Me.ButtonCloudSave)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.TextBoxCloudPort)
        Me.GroupBox2.Controls.Add(Me.TextBoxCloudDB)
        Me.GroupBox2.Controls.Add(Me.TextBoxCloudPassword)
        Me.GroupBox2.Controls.Add(Me.TextBoxCloudUser)
        Me.GroupBox2.Controls.Add(Me.TextBoxCloudServer)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 191)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(474, 183)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "System connection (System Administrator Only) For Cloud"
        '
        'ButtonCloudImport
        '
        Me.ButtonCloudImport.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonCloudImport.Location = New System.Drawing.Point(84, 130)
        Me.ButtonCloudImport.Name = "ButtonCloudImport"
        Me.ButtonCloudImport.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCloudImport.TabIndex = 279
        Me.ButtonCloudImport.Text = "Import"
        Me.ButtonCloudImport.UseVisualStyleBackColor = True
        '
        'ButtonCloudTest
        '
        Me.ButtonCloudTest.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonCloudTest.Location = New System.Drawing.Point(165, 130)
        Me.ButtonCloudTest.Name = "ButtonCloudTest"
        Me.ButtonCloudTest.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCloudTest.TabIndex = 278
        Me.ButtonCloudTest.Text = "Test"
        Me.ButtonCloudTest.UseVisualStyleBackColor = True
        '
        'ButtonCloudEdit
        '
        Me.ButtonCloudEdit.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonCloudEdit.Location = New System.Drawing.Point(246, 130)
        Me.ButtonCloudEdit.Name = "ButtonCloudEdit"
        Me.ButtonCloudEdit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCloudEdit.TabIndex = 277
        Me.ButtonCloudEdit.Text = "Edit"
        Me.ButtonCloudEdit.UseVisualStyleBackColor = True
        '
        'ButtonCloudSave
        '
        Me.ButtonCloudSave.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonCloudSave.Location = New System.Drawing.Point(327, 130)
        Me.ButtonCloudSave.Name = "ButtonCloudSave"
        Me.ButtonCloudSave.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCloudSave.TabIndex = 276
        Me.ButtonCloudSave.Text = "Save"
        Me.ButtonCloudSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(281, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 15)
        Me.Label1.TabIndex = 275
        Me.Label1.Text = "Port"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(29, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 15)
        Me.Label8.TabIndex = 274
        Me.Label8.Text = "Schema"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 15)
        Me.Label9.TabIndex = 273
        Me.Label9.Text = "Password"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 15)
        Me.Label10.TabIndex = 272
        Me.Label10.Text = "Username"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(37, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 15)
        Me.Label11.TabIndex = 271
        Me.Label11.Text = "Server"
        '
        'TextBoxCloudPort
        '
        Me.TextBoxCloudPort.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxCloudPort.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCloudPort.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCloudPort.Location = New System.Drawing.Point(317, 47)
        Me.TextBoxCloudPort.Name = "TextBoxCloudPort"
        Me.TextBoxCloudPort.Size = New System.Drawing.Size(100, 15)
        Me.TextBoxCloudPort.TabIndex = 270
        '
        'TextBoxCloudDB
        '
        Me.TextBoxCloudDB.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxCloudDB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCloudDB.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCloudDB.Location = New System.Drawing.Point(84, 109)
        Me.TextBoxCloudDB.Name = "TextBoxCloudDB"
        Me.TextBoxCloudDB.Size = New System.Drawing.Size(333, 15)
        Me.TextBoxCloudDB.TabIndex = 269
        Me.TextBoxCloudDB.UseSystemPasswordChar = True
        '
        'TextBoxCloudPassword
        '
        Me.TextBoxCloudPassword.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxCloudPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCloudPassword.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCloudPassword.Location = New System.Drawing.Point(84, 88)
        Me.TextBoxCloudPassword.Name = "TextBoxCloudPassword"
        Me.TextBoxCloudPassword.Size = New System.Drawing.Size(191, 15)
        Me.TextBoxCloudPassword.TabIndex = 268
        Me.TextBoxCloudPassword.UseSystemPasswordChar = True
        '
        'TextBoxCloudUser
        '
        Me.TextBoxCloudUser.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxCloudUser.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCloudUser.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCloudUser.Location = New System.Drawing.Point(84, 67)
        Me.TextBoxCloudUser.Name = "TextBoxCloudUser"
        Me.TextBoxCloudUser.Size = New System.Drawing.Size(333, 15)
        Me.TextBoxCloudUser.TabIndex = 267
        Me.TextBoxCloudUser.UseSystemPasswordChar = True
        '
        'TextBoxCloudServer
        '
        Me.TextBoxCloudServer.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxCloudServer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCloudServer.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCloudServer.Location = New System.Drawing.Point(84, 46)
        Me.TextBoxCloudServer.Name = "TextBoxCloudServer"
        Me.TextBoxCloudServer.Size = New System.Drawing.Size(191, 15)
        Me.TextBoxCloudServer.TabIndex = 266
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(973, 28)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(5, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(256, 26)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "DATABASE CONFIGURATION"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 536)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1011, 22)
        Me.StatusStrip1.TabIndex = 20
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(263, 17)
        Me.ToolStripStatusLabel1.Text = "Copyright 2020 All Rights Reserved - DEVGEEKPH"
        '
        'BackgroundWorkerTestLocal
        '
        '
        'BackgroundWorkerTestCloud
        '
        '
        'ConfigManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1011, 558)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "ConfigManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HR Buddy"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxLocalPort As TextBox
    Friend WithEvents TextBoxLocalDB As TextBox
    Friend WithEvents TextBoxLocalPassword As TextBox
    Friend WithEvents TextBoxLocalUser As TextBox
    Friend WithEvents TextBoxLocalServer As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBoxCloudPort As TextBox
    Friend WithEvents TextBoxCloudDB As TextBox
    Friend WithEvents TextBoxCloudPassword As TextBox
    Friend WithEvents TextBoxCloudUser As TextBox
    Friend WithEvents TextBoxCloudServer As TextBox
    Friend WithEvents ButtonLocalSave As Button
    Friend WithEvents ButtonLocalEdit As Button
    Friend WithEvents ButtonLocalTest As Button
    Friend WithEvents ButtonLocalImport As Button
    Friend WithEvents ButtonCloudImport As Button
    Friend WithEvents ButtonCloudTest As Button
    Friend WithEvents ButtonCloudEdit As Button
    Friend WithEvents ButtonCloudSave As Button
    Friend WithEvents BackgroundWorkerTestLocal As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorkerTestCloud As System.ComponentModel.BackgroundWorker
End Class
