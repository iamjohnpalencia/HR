<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSubTeam
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ComboBoxDeptName = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.ComboBoxCompanyName = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ComboBoxBranchName = New System.Windows.Forms.ComboBox()
        Me.TextBoxTeamName = New System.Windows.Forms.TextBox()
        Me.TextBoxTeamDesc = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(98, 208)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 93
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(17, 208)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 92
        Me.Button1.Text = "Submit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(14, 17)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(90, 13)
        Me.Label20.TabIndex = 78
        Me.Label20.Text = "Company Name:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(14, 171)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 13)
        Me.Label19.TabIndex = 91
        Me.Label19.Text = "Description:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(14, 137)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 13)
        Me.Label18.TabIndex = 79
        Me.Label18.Text = "Team Name:"
        '
        'ComboBoxDeptName
        '
        Me.ComboBoxDeptName.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ComboBoxDeptName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDeptName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBoxDeptName.FormattingEnabled = True
        Me.ComboBoxDeptName.Location = New System.Drawing.Point(17, 113)
        Me.ComboBoxDeptName.Name = "ComboBoxDeptName"
        Me.ComboBoxDeptName.Size = New System.Drawing.Size(299, 21)
        Me.ComboBoxDeptName.TabIndex = 88
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(14, 97)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(103, 13)
        Me.Label24.TabIndex = 82
        Me.Label24.Text = "Department Name:"
        '
        'ComboBoxCompanyName
        '
        Me.ComboBoxCompanyName.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ComboBoxCompanyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxCompanyName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBoxCompanyName.FormattingEnabled = True
        Me.ComboBoxCompanyName.Location = New System.Drawing.Point(17, 33)
        Me.ComboBoxCompanyName.Name = "ComboBoxCompanyName"
        Me.ComboBoxCompanyName.Size = New System.Drawing.Size(299, 21)
        Me.ComboBoxCompanyName.TabIndex = 87
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(14, 57)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(77, 13)
        Me.Label23.TabIndex = 83
        Me.Label23.Text = "Branch Name:"
        '
        'ComboBoxBranchName
        '
        Me.ComboBoxBranchName.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ComboBoxBranchName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxBranchName.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBoxBranchName.FormattingEnabled = True
        Me.ComboBoxBranchName.Location = New System.Drawing.Point(17, 73)
        Me.ComboBoxBranchName.Name = "ComboBoxBranchName"
        Me.ComboBoxBranchName.Size = New System.Drawing.Size(299, 21)
        Me.ComboBoxBranchName.TabIndex = 86
        '
        'TextBoxTeamName
        '
        Me.TextBoxTeamName.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TextBoxTeamName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxTeamName.Location = New System.Drawing.Point(17, 153)
        Me.TextBoxTeamName.Name = "TextBoxTeamName"
        Me.TextBoxTeamName.Size = New System.Drawing.Size(299, 15)
        Me.TextBoxTeamName.TabIndex = 84
        '
        'TextBoxTeamDesc
        '
        Me.TextBoxTeamDesc.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TextBoxTeamDesc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxTeamDesc.Location = New System.Drawing.Point(17, 187)
        Me.TextBoxTeamDesc.Name = "TextBoxTeamDesc"
        Me.TextBoxTeamDesc.Size = New System.Drawing.Size(299, 15)
        Me.TextBoxTeamDesc.TabIndex = 85
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 247)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(335, 22)
        Me.StatusStrip1.TabIndex = 94
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel1.Text = "Status"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'BackgroundWorker1
        '
        '
        'BackgroundWorker2
        '
        '
        'frmSubTeam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(335, 269)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.ComboBoxDeptName)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.ComboBoxCompanyName)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.ComboBoxBranchName)
        Me.Controls.Add(Me.TextBoxTeamName)
        Me.Controls.Add(Me.TextBoxTeamDesc)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSubTeam"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSubTeam"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents ComboBoxDeptName As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents ComboBoxCompanyName As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents ComboBoxBranchName As ComboBox
    Friend WithEvents TextBoxTeamName As TextBox
    Friend WithEvents TextBoxTeamDesc As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
End Class
