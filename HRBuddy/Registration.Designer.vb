<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Registration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Registration))
        Me.TextBoxUsername = New System.Windows.Forms.TextBox()
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxConfirmPassword = New System.Windows.Forms.TextBox()
        Me.ButtonExit = New System.Windows.Forms.Button()
        Me.ButtonRegister = New System.Windows.Forms.Button()
        Me.LinkLabelLogin = New System.Windows.Forms.LinkLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBoxUsername
        '
        Me.TextBoxUsername.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxUsername.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.TextBoxUsername.Location = New System.Drawing.Point(12, 145)
        Me.TextBoxUsername.Name = "TextBoxUsername"
        Me.TextBoxUsername.Size = New System.Drawing.Size(264, 16)
        Me.TextBoxUsername.TabIndex = 9
        Me.TextBoxUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxPassword.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.TextBoxPassword.Location = New System.Drawing.Point(12, 182)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.Size = New System.Drawing.Size(264, 16)
        Me.TextBoxPassword.TabIndex = 10
        Me.TextBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxPassword.UseSystemPasswordChar = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(12, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Username:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(12, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Password:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(12, 201)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 15)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Confirm Password:"
        '
        'TextBoxConfirmPassword
        '
        Me.TextBoxConfirmPassword.BackColor = System.Drawing.SystemColors.Control
        Me.TextBoxConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxConfirmPassword.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.TextBoxConfirmPassword.Location = New System.Drawing.Point(12, 219)
        Me.TextBoxConfirmPassword.Name = "TextBoxConfirmPassword"
        Me.TextBoxConfirmPassword.Size = New System.Drawing.Size(264, 16)
        Me.TextBoxConfirmPassword.TabIndex = 14
        Me.TextBoxConfirmPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxConfirmPassword.UseSystemPasswordChar = True
        '
        'ButtonExit
        '
        Me.ButtonExit.FlatAppearance.BorderSize = 0
        Me.ButtonExit.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonExit.Location = New System.Drawing.Point(130, 256)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(112, 29)
        Me.ButtonExit.TabIndex = 16
        Me.ButtonExit.Text = "Exit"
        Me.ButtonExit.UseVisualStyleBackColor = True
        '
        'ButtonRegister
        '
        Me.ButtonRegister.FlatAppearance.BorderSize = 0
        Me.ButtonRegister.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.ButtonRegister.Location = New System.Drawing.Point(12, 256)
        Me.ButtonRegister.Name = "ButtonRegister"
        Me.ButtonRegister.Size = New System.Drawing.Size(112, 29)
        Me.ButtonRegister.TabIndex = 15
        Me.ButtonRegister.Text = "Register"
        Me.ButtonRegister.UseVisualStyleBackColor = True
        '
        'LinkLabelLogin
        '
        Me.LinkLabelLogin.AutoSize = True
        Me.LinkLabelLogin.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.LinkLabelLogin.LinkColor = System.Drawing.Color.Black
        Me.LinkLabelLogin.Location = New System.Drawing.Point(9, 238)
        Me.LinkLabelLogin.Name = "LinkLabelLogin"
        Me.LinkLabelLogin.Size = New System.Drawing.Size(148, 15)
        Me.LinkLabelLogin.TabIndex = 17
        Me.LinkLabelLogin.TabStop = True
        Me.LinkLabelLogin.Text = "Already have an account?"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 297)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(288, 22)
        Me.StatusStrip1.TabIndex = 18
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(271, 17)
        Me.ToolStripStatusLabel1.Text = "Copyright 2020 All Rights Reserved - DEVGEEKPH"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(61, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(183, 116)
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'Registration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(288, 319)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.LinkLabelLogin)
        Me.Controls.Add(Me.ButtonExit)
        Me.Controls.Add(Me.ButtonRegister)
        Me.Controls.Add(Me.TextBoxConfirmPassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBoxPassword)
        Me.Controls.Add(Me.TextBoxUsername)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Registration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HR Buddy"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxUsername As TextBox
    Friend WithEvents TextBoxPassword As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxConfirmPassword As TextBox
    Friend WithEvents ButtonExit As Button
    Friend WithEvents ButtonRegister As Button
    Friend WithEvents LinkLabelLogin As LinkLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents PictureBox1 As PictureBox
End Class
