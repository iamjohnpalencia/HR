Imports MySql.Data.MySqlClient
Public Class Registration
    Private Sub LinkLabelLogin_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelLogin.LinkClicked
        Login.Show()
        Close()
    End Sub
    Private Sub ButtonRegister_Click(sender As Object, e As EventArgs) Handles ButtonRegister.Click
        Try
            If BlankFields(Me) Then
                MsgBox("Fill up all fields")
            Else
                Dim Password As String = TextBoxPassword.Text
                Dim ConPassword As String = TextBoxConfirmPassword.Text
                If Password <> ConPassword Then
                    MsgBox("Password did not match")
                Else
                    Dim QueryResult As Boolean
                    If CheckUserName(TextBoxUsername.Text) = False Then
                        QueryResult = InsertSingleQuery("tbl_hr", "hr_username,hr_password", "'" & TextBoxUsername.Text & "','" & TextBoxPassword.Text & "'")
                        MsgBox(QueryResult)
                        MsgBox("Registered!")
                    Else
                        MsgBox("User already exist")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub TextBoxUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxUsername.KeyPress, TextBoxPassword.KeyPress, TextBoxConfirmPassword.KeyPress
        Try
            If InStr(DisallowedCharacters, e.KeyChar) > 0 Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class