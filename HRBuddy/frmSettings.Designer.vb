<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.BackgroundWorkerTestCloud = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorkerTestLocal = New System.ComponentModel.BackgroundWorker()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 25)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(938, 437)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(930, 411)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Database Settings"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(924, 405)
        Me.TableLayoutPanel1.TabIndex = 0
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
        Me.GroupBox1.Size = New System.Drawing.Size(456, 196)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "System connection (System Administrator Only) For Local"
        '
        'ButtonLocalSave
        '
        Me.ButtonLocalSave.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonLocalSave.Location = New System.Drawing.Point(327, 136)
        Me.ButtonLocalSave.Name = "ButtonLocalSave"
        Me.ButtonLocalSave.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLocalSave.TabIndex = 283
        Me.ButtonLocalSave.Text = "Save"
        Me.ButtonLocalSave.UseVisualStyleBackColor = True
        '
        'ButtonLocalEdit
        '
        Me.ButtonLocalEdit.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonLocalEdit.Location = New System.Drawing.Point(246, 136)
        Me.ButtonLocalEdit.Name = "ButtonLocalEdit"
        Me.ButtonLocalEdit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLocalEdit.TabIndex = 282
        Me.ButtonLocalEdit.Text = "Edit"
        Me.ButtonLocalEdit.UseVisualStyleBackColor = True
        '
        'ButtonLocalTest
        '
        Me.ButtonLocalTest.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonLocalTest.Location = New System.Drawing.Point(165, 136)
        Me.ButtonLocalTest.Name = "ButtonLocalTest"
        Me.ButtonLocalTest.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLocalTest.TabIndex = 281
        Me.ButtonLocalTest.Text = "Test"
        Me.ButtonLocalTest.UseVisualStyleBackColor = True
        '
        'ButtonLocalImport
        '
        Me.ButtonLocalImport.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonLocalImport.Location = New System.Drawing.Point(84, 136)
        Me.ButtonLocalImport.Name = "ButtonLocalImport"
        Me.ButtonLocalImport.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLocalImport.TabIndex = 280
        Me.ButtonLocalImport.Text = "Import"
        Me.ButtonLocalImport.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(281, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 15)
        Me.Label7.TabIndex = 279
        Me.Label7.Text = "Port"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(29, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 15)
        Me.Label6.TabIndex = 278
        Me.Label6.Text = "Schema"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 15)
        Me.Label5.TabIndex = 277
        Me.Label5.Text = "Password"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 15)
        Me.Label4.TabIndex = 276
        Me.Label4.Text = "Username"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 275
        Me.Label2.Text = "Server"
        '
        'TextBoxLocalPort
        '
        Me.TextBoxLocalPort.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxLocalPort.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxLocalPort.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxLocalPort.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxLocalPort.Location = New System.Drawing.Point(317, 53)
        Me.TextBoxLocalPort.Name = "TextBoxLocalPort"
        Me.TextBoxLocalPort.Size = New System.Drawing.Size(94, 15)
        Me.TextBoxLocalPort.TabIndex = 274
        '
        'TextBoxLocalDB
        '
        Me.TextBoxLocalDB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxLocalDB.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxLocalDB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxLocalDB.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxLocalDB.Location = New System.Drawing.Point(84, 115)
        Me.TextBoxLocalDB.Name = "TextBoxLocalDB"
        Me.TextBoxLocalDB.Size = New System.Drawing.Size(327, 15)
        Me.TextBoxLocalDB.TabIndex = 273
        Me.TextBoxLocalDB.UseSystemPasswordChar = True
        '
        'TextBoxLocalPassword
        '
        Me.TextBoxLocalPassword.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxLocalPassword.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxLocalPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxLocalPassword.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxLocalPassword.Location = New System.Drawing.Point(84, 94)
        Me.TextBoxLocalPassword.Name = "TextBoxLocalPassword"
        Me.TextBoxLocalPassword.Size = New System.Drawing.Size(185, 15)
        Me.TextBoxLocalPassword.TabIndex = 272
        Me.TextBoxLocalPassword.UseSystemPasswordChar = True
        '
        'TextBoxLocalUser
        '
        Me.TextBoxLocalUser.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxLocalUser.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxLocalUser.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxLocalUser.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxLocalUser.Location = New System.Drawing.Point(84, 73)
        Me.TextBoxLocalUser.Name = "TextBoxLocalUser"
        Me.TextBoxLocalUser.Size = New System.Drawing.Size(327, 15)
        Me.TextBoxLocalUser.TabIndex = 271
        Me.TextBoxLocalUser.UseSystemPasswordChar = True
        '
        'TextBoxLocalServer
        '
        Me.TextBoxLocalServer.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxLocalServer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxLocalServer.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxLocalServer.Location = New System.Drawing.Point(84, 52)
        Me.TextBoxLocalServer.Name = "TextBoxLocalServer"
        Me.TextBoxLocalServer.Size = New System.Drawing.Size(189, 15)
        Me.TextBoxLocalServer.TabIndex = 270
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
        Me.GroupBox2.Location = New System.Drawing.Point(3, 205)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(456, 197)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "System connection (System Administrator Only) For Cloud"
        '
        'ButtonCloudImport
        '
        Me.ButtonCloudImport.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonCloudImport.Location = New System.Drawing.Point(84, 137)
        Me.ButtonCloudImport.Name = "ButtonCloudImport"
        Me.ButtonCloudImport.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCloudImport.TabIndex = 293
        Me.ButtonCloudImport.Text = "Import"
        Me.ButtonCloudImport.UseVisualStyleBackColor = True
        '
        'ButtonCloudTest
        '
        Me.ButtonCloudTest.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonCloudTest.Location = New System.Drawing.Point(165, 137)
        Me.ButtonCloudTest.Name = "ButtonCloudTest"
        Me.ButtonCloudTest.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCloudTest.TabIndex = 292
        Me.ButtonCloudTest.Text = "Test"
        Me.ButtonCloudTest.UseVisualStyleBackColor = True
        '
        'ButtonCloudEdit
        '
        Me.ButtonCloudEdit.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonCloudEdit.Location = New System.Drawing.Point(246, 137)
        Me.ButtonCloudEdit.Name = "ButtonCloudEdit"
        Me.ButtonCloudEdit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCloudEdit.TabIndex = 291
        Me.ButtonCloudEdit.Text = "Edit"
        Me.ButtonCloudEdit.UseVisualStyleBackColor = True
        '
        'ButtonCloudSave
        '
        Me.ButtonCloudSave.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonCloudSave.Location = New System.Drawing.Point(327, 137)
        Me.ButtonCloudSave.Name = "ButtonCloudSave"
        Me.ButtonCloudSave.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCloudSave.TabIndex = 290
        Me.ButtonCloudSave.Text = "Save"
        Me.ButtonCloudSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(281, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 15)
        Me.Label1.TabIndex = 289
        Me.Label1.Text = "Port"
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(29, 114)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 15)
        Me.Label8.TabIndex = 288
        Me.Label8.Text = "Schema"
        '
        'Label9
        '
        Me.Label9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 15)
        Me.Label9.TabIndex = 287
        Me.Label9.Text = "Password"
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 15)
        Me.Label10.TabIndex = 286
        Me.Label10.Text = "Username"
        '
        'Label11
        '
        Me.Label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(37, 53)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 15)
        Me.Label11.TabIndex = 285
        Me.Label11.Text = "Server"
        '
        'TextBoxCloudPort
        '
        Me.TextBoxCloudPort.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCloudPort.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxCloudPort.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCloudPort.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCloudPort.Location = New System.Drawing.Point(317, 54)
        Me.TextBoxCloudPort.Name = "TextBoxCloudPort"
        Me.TextBoxCloudPort.Size = New System.Drawing.Size(94, 15)
        Me.TextBoxCloudPort.TabIndex = 284
        '
        'TextBoxCloudDB
        '
        Me.TextBoxCloudDB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCloudDB.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxCloudDB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCloudDB.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCloudDB.Location = New System.Drawing.Point(84, 116)
        Me.TextBoxCloudDB.Name = "TextBoxCloudDB"
        Me.TextBoxCloudDB.Size = New System.Drawing.Size(327, 15)
        Me.TextBoxCloudDB.TabIndex = 283
        Me.TextBoxCloudDB.UseSystemPasswordChar = True
        '
        'TextBoxCloudPassword
        '
        Me.TextBoxCloudPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCloudPassword.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxCloudPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCloudPassword.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCloudPassword.Location = New System.Drawing.Point(84, 95)
        Me.TextBoxCloudPassword.Name = "TextBoxCloudPassword"
        Me.TextBoxCloudPassword.Size = New System.Drawing.Size(185, 15)
        Me.TextBoxCloudPassword.TabIndex = 282
        Me.TextBoxCloudPassword.UseSystemPasswordChar = True
        '
        'TextBoxCloudUser
        '
        Me.TextBoxCloudUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCloudUser.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxCloudUser.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCloudUser.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCloudUser.Location = New System.Drawing.Point(84, 74)
        Me.TextBoxCloudUser.Name = "TextBoxCloudUser"
        Me.TextBoxCloudUser.Size = New System.Drawing.Size(327, 15)
        Me.TextBoxCloudUser.TabIndex = 281
        Me.TextBoxCloudUser.UseSystemPasswordChar = True
        '
        'TextBoxCloudServer
        '
        Me.TextBoxCloudServer.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxCloudServer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCloudServer.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCloudServer.Location = New System.Drawing.Point(84, 53)
        Me.TextBoxCloudServer.Name = "TextBoxCloudServer"
        Me.TextBoxCloudServer.Size = New System.Drawing.Size(189, 15)
        Me.TextBoxCloudServer.TabIndex = 280
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripSeparator3, Me.ToolStripSeparator2, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(938, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI Light", 9.75!)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(69, 22)
        Me.ToolStripLabel1.Text = "EMPLOYEE"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(40, 22)
        Me.ToolStripButton2.Text = "Close"
        '
        'BackgroundWorkerTestCloud
        '
        '
        'BackgroundWorkerTestLocal
        '
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(938, 462)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmSettings"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ButtonLocalSave As Button
    Friend WithEvents ButtonLocalEdit As Button
    Friend WithEvents ButtonLocalTest As Button
    Friend WithEvents ButtonLocalImport As Button
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
    Friend WithEvents ButtonCloudImport As Button
    Friend WithEvents ButtonCloudTest As Button
    Friend WithEvents ButtonCloudEdit As Button
    Friend WithEvents ButtonCloudSave As Button
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
    Friend WithEvents BackgroundWorkerTestCloud As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorkerTestLocal As System.ComponentModel.BackgroundWorker
End Class
