<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubCompany
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxCompDesc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxCompAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxCompCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxCompName = New System.Windows.Forms.TextBox()
        Me.DateTimePickerCompReg = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerCompExp = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Company Name:"
        '
        'TextBoxCompDesc
        '
        Me.TextBoxCompDesc.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TextBoxCompDesc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCompDesc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCompDesc.Location = New System.Drawing.Point(17, 135)
        Me.TextBoxCompDesc.Name = "TextBoxCompDesc"
        Me.TextBoxCompDesc.Size = New System.Drawing.Size(299, 15)
        Me.TextBoxCompDesc.TabIndex = 53
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 194)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Expiry Date:"
        '
        'TextBoxCompAddress
        '
        Me.TextBoxCompAddress.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TextBoxCompAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCompAddress.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCompAddress.Location = New System.Drawing.Point(17, 102)
        Me.TextBoxCompAddress.Name = "TextBoxCompAddress"
        Me.TextBoxCompAddress.Size = New System.Drawing.Size(299, 15)
        Me.TextBoxCompAddress.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Company Address:"
        '
        'TextBoxCompCode
        '
        Me.TextBoxCompCode.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TextBoxCompCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCompCode.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCompCode.Location = New System.Drawing.Point(17, 67)
        Me.TextBoxCompCode.Name = "TextBoxCompCode"
        Me.TextBoxCompCode.Size = New System.Drawing.Size(299, 15)
        Me.TextBoxCompCode.TabIndex = 51
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Registration date:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(14, 51)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(88, 13)
        Me.Label25.TabIndex = 50
        Me.Label25.Text = "Company Code:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Description:"
        '
        'TextBoxCompName
        '
        Me.TextBoxCompName.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TextBoxCompName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxCompName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxCompName.Location = New System.Drawing.Point(17, 33)
        Me.TextBoxCompName.Name = "TextBoxCompName"
        Me.TextBoxCompName.Size = New System.Drawing.Size(299, 15)
        Me.TextBoxCompName.TabIndex = 49
        '
        'DateTimePickerCompReg
        '
        Me.DateTimePickerCompReg.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerCompReg.Location = New System.Drawing.Point(17, 168)
        Me.DateTimePickerCompReg.Name = "DateTimePickerCompReg"
        Me.DateTimePickerCompReg.Size = New System.Drawing.Size(299, 22)
        Me.DateTimePickerCompReg.TabIndex = 47
        '
        'DateTimePickerCompExp
        '
        Me.DateTimePickerCompExp.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerCompExp.Location = New System.Drawing.Point(17, 210)
        Me.DateTimePickerCompExp.Name = "DateTimePickerCompExp"
        Me.DateTimePickerCompExp.Size = New System.Drawing.Size(299, 22)
        Me.DateTimePickerCompExp.TabIndex = 48
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(17, 238)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 54
        Me.Button1.Text = "Submit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(98, 238)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 55
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 272)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(335, 22)
        Me.StatusStrip1.TabIndex = 56
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
        'BackgroundWorker2
        '
        '
        'frmSubCompany
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(335, 294)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxCompDesc)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBoxCompAddress)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxCompCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxCompName)
        Me.Controls.Add(Me.DateTimePickerCompReg)
        Me.Controls.Add(Me.DateTimePickerCompExp)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSubCompany"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSubGroups"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxCompDesc As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxCompAddress As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxCompCode As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxCompName As TextBox
    Friend WithEvents DateTimePickerCompReg As DateTimePicker
    Friend WithEvents DateTimePickerCompExp As DateTimePicker
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
End Class
