<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSubDept
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
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ComboBoxBranchName = New System.Windows.Forms.ComboBox()
        Me.ComboBoxCompanyName = New System.Windows.Forms.ComboBox()
        Me.TextBoxDeptDesc = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextBoxDeptName = New System.Windows.Forms.TextBox()
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
        Me.Button2.Location = New System.Drawing.Point(98, 168)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 71
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(17, 168)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 70
        Me.Button1.Text = "Submit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(14, 17)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 13)
        Me.Label15.TabIndex = 58
        Me.Label15.Text = "Company Name:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 97)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(103, 13)
        Me.Label14.TabIndex = 59
        Me.Label14.Text = "Department Name:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 131)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 13)
        Me.Label13.TabIndex = 60
        Me.Label13.Text = "Description:"
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
        Me.ComboBoxBranchName.TabIndex = 67
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
        Me.ComboBoxCompanyName.TabIndex = 66
        '
        'TextBoxDeptDesc
        '
        Me.TextBoxDeptDesc.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TextBoxDeptDesc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxDeptDesc.Location = New System.Drawing.Point(17, 147)
        Me.TextBoxDeptDesc.Name = "TextBoxDeptDesc"
        Me.TextBoxDeptDesc.Size = New System.Drawing.Size(299, 15)
        Me.TextBoxDeptDesc.TabIndex = 65
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(14, 57)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(77, 13)
        Me.Label22.TabIndex = 63
        Me.Label22.Text = "Branch Name:"
        '
        'TextBoxDeptName
        '
        Me.TextBoxDeptName.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TextBoxDeptName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxDeptName.Location = New System.Drawing.Point(17, 113)
        Me.TextBoxDeptName.Name = "TextBoxDeptName"
        Me.TextBoxDeptName.Size = New System.Drawing.Size(299, 15)
        Me.TextBoxDeptName.TabIndex = 64
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 208)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(335, 22)
        Me.StatusStrip1.TabIndex = 72
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
        'frmSubDept
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(335, 230)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.ComboBoxBranchName)
        Me.Controls.Add(Me.ComboBoxCompanyName)
        Me.Controls.Add(Me.TextBoxDeptDesc)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.TextBoxDeptName)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSubDept"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSubDept"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents ComboBoxBranchName As ComboBox
    Friend WithEvents ComboBoxCompanyName As ComboBox
    Friend WithEvents TextBoxDeptDesc As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TextBoxDeptName As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
End Class
