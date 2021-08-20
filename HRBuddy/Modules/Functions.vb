﻿Imports System.IO

Module Functions
    Public Function ConvertB64ToString(str As String)
        Dim b As Byte() = Convert.FromBase64String(str)
        Dim byt2 = System.Text.Encoding.UTF8.GetString(b)
        Return byt2
    End Function
    Public Function RemoveCharacter(ByVal stringToCleanUp, ByVal characterToRemove)
        ' replace the target with nothing
        ' Replace() returns a new String and does not modify the current one
        Return stringToCleanUp.Replace(characterToRemove, "")
    End Function

    Public Function BlankFields(ByVal root As Control) As Boolean
        Dim ReturnThisThing As Boolean
        Try
            For Each tb As TextBox In root.Controls.OfType(Of TextBox)()
                If tb.Text = String.Empty Then
                    ReturnThisThing = True
                    Exit For
                Else
                    ReturnThisThing = False
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ReturnThisThing
    End Function
    Public Sub ButtonEnableability(ByVal root As Control, ENB As Boolean)
        For Each ctrl As Control In root.Controls
            ButtonEnableability(ctrl, ENB)
            If TypeOf ctrl Is Button Then
                CType(ctrl, Button).Enabled = ENB
            End If
        Next ctrl
    End Sub
    Public Sub CheckBoxEnabled(ByVal root As Control, ENB As Boolean)
        For Each ctrl As Control In root.Controls
            CheckBoxEnabled(ctrl, ENB)
            If TypeOf ctrl Is CheckBox Then
                CType(ctrl, CheckBox).Checked = ENB
            End If
        Next ctrl
    End Sub
    Public Sub TextboxEnableability(ByVal root As Control, ENB As Boolean)
        Try
            For Each ctrl As Control In root.Controls
                TextboxEnableability(ctrl, ENB)
                If TypeOf ctrl Is TextBox Then
                    CType(ctrl, TextBox).Enabled = ENB
                End If
            Next ctrl
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Function ConvertToBase64(str As String)
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(str)
        Dim byt2 = Convert.ToBase64String(byt)
        Return byt2
    End Function
    Public Function ImageToBase64(ByVal image As Image, ByVal format As System.Drawing.Imaging.ImageFormat) As String
        Using ms As New MemoryStream()
            ' Convert Image to byte[]
            image.Save(ms, format)
            Dim imageBytes As Byte() = ms.ToArray() ' Convert byte[] to Base64 String
            Dim base64String As String = Convert.ToBase64String(imageBytes)
            Return base64String
        End Using
    End Function

    Public Function Base64ToImage(ByVal base64String As String) As Image
        ' Convert Base64 String to byte[]
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)
        Dim ms As New MemoryStream(imageBytes, 0, imageBytes.Length)

        ' Convert byte[] to Image
        ms.Write(imageBytes, 0, imageBytes.Length)
        Dim ConvertedBase64Image As Image = Image.FromStream(ms, True)
        Return ConvertedBase64Image
    End Function

    Public Function FullDate24HR()
        Dim DateNow As String = ""
        Try
            DateNow = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return DateNow
    End Function
End Module
