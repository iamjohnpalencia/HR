Public Class frmAbout
    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        StartPosition = FormStartPosition.CenterScreen
        Me.Panel1.Location = New Point(Convert.ToInt32(Me.ClientSize.Width / 2 - Me.Panel1.Width / 2),
                               Convert.ToInt32(Me.ClientSize.Height / 2 - Me.Panel1.Height / 2))
    End Sub
End Class