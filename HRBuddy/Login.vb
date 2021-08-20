Public Class Login
    Private Sub LinkLabelRegister_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelRegister.LinkClicked
        Registration.Show()
        Close()
    End Sub

    Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click
        Try
            If BlankFields(Me) Then
                MsgBox("Fill up all fields")
            Else
                Dim UserExist As Boolean = False
                UserExist = UserLogin(TextBox1.Text, TextBox2.Text)
                If UserExist Then
                    HRUsername = Trim(TextBox1.Text)
                    MsgBox("Welcome")
                    Home.Show()
                    Close()
                Else
                    MsgBox("Wrong Credentials")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
