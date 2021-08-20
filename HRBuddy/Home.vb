Imports System.Windows.Forms

Public Class Home
    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub formclose(ByVal closeform As Form)
        Try
            For Each P As Control In Controls
                For Each ctrl As Control In P.Controls
                    If TypeOf ctrl Is Form Then
                        If ctrl.Name <> closeform.Name Then
                            CType(ctrl, Form).FindForm.Close()
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub




    Public newMDIchildAbout As frmAbout
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            newMDIchildAbout = New frmAbout
            If Application.OpenForms().OfType(Of frmAbout).Any Then
            Else
                formclose(closeform:=frmEmployee)
                newMDIchildAbout.MdiParent = Me
                newMDIchildAbout.ShowIcon = False
                newMDIchildAbout.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Public newMDIchildEmployee As frmEmployee
    Private Sub EmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeToolStripMenuItem.Click
        Try
            newMDIchildEmployee = New frmEmployee
            If Application.OpenForms().OfType(Of frmEmployee).Any Then
            Else
                formclose(closeform:=frmEmployee)
                newMDIchildEmployee.MdiParent = Me
                newMDIchildEmployee.ShowIcon = False
                newMDIchildEmployee.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public newMDIchildDashBoard As frmDashboard
    Private Sub DashboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DashboardToolStripMenuItem.Click
        Try
            newMDIchildDashBoard = New frmDashboard
            If Application.OpenForms().OfType(Of frmDashboard).Any Then
            Else
                formclose(closeform:=frmDashboard)
                newMDIchildDashBoard.MdiParent = Me
                newMDIchildDashBoard.ShowIcon = False
                newMDIchildDashBoard.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public newMDIchildGroups As frmGroups
    Private Sub GroupsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GroupsToolStripMenuItem1.Click
        Try
            newMDIchildGroups = New frmGroups
            If Application.OpenForms().OfType(Of frmGroups).Any Then
            Else
                formclose(closeform:=frmGroups)
                newMDIchildGroups.MdiParent = Me
                newMDIchildGroups.ShowIcon = False
                newMDIchildGroups.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public newMDIchildLogs As UserLogs
    Private Sub GeneralLogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneralLogsToolStripMenuItem.Click
        Try
            newMDIchildLogs = New UserLogs
            If Application.OpenForms().OfType(Of UserLogs).Any Then
            Else
                formclose(closeform:=UserLogs)
                newMDIchildLogs.MdiParent = Me
                newMDIchildLogs.ShowIcon = False
                newMDIchildLogs.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public newMDIchildSettings As frmSettings
    Private Sub SettingsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem1.Click
        Try
            newMDIchildSettings = New frmSettings
            If Application.OpenForms().OfType(Of frmSettings).Any Then
            Else
                formclose(closeform:=frmSettings)
                newMDIchildSettings.MdiParent = Me
                newMDIchildSettings.ShowIcon = False
                newMDIchildSettings.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public newMDIchildUsers As frmUsers
    Private Sub UsersToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UsersToolStripMenuItem1.Click
        Try
            newMDIchildUsers = New frmUsers
            If Application.OpenForms().OfType(Of frmUsers).Any Then
            Else
                formclose(closeform:=frmUsers)
                newMDIchildUsers.MdiParent = Me
                newMDIchildUsers.ShowIcon = False
                newMDIchildUsers.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
