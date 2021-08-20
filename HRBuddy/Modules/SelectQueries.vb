﻿Imports MySql.Data.MySqlClient
Module SelectQueries
    Public Function CheckUserName(Username) As Boolean
        Dim ReturnUsername As Boolean = False
        Try
            Dim ConnectionLocal As MySqlConnection = LocalhostConn()
            Dim sql = "SELECT hr_username FROM tbl_hr WHERE hr_username = '" & Username & "'"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionLocal)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    ReturnUsername = True
                Else
                    ReturnUsername = False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ReturnUsername
    End Function

    Public Function CheckCompanyName(CompanyName, companyID) As Boolean
        Try
            Dim ConnectionCloud As MySqlConnection = ServerCloudCon()
            Dim sql As String = ""
            If UPDATECOMPANYDETAILS Then
                sql = "SELECT companyname FROM tblcompany WHERE companyname = '" & CompanyName & "' AND companyid <> " & companyID
            Else
                sql = "SELECT companyname FROM tblcompany WHERE companyname = '" & CompanyName & "'"
            End If
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionCloud)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    CheckCompanyNameExist = True
                Else
                    CheckCompanyNameExist = False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return CheckCompanyNameExist
    End Function
    Public Function CheckCompanyCode(CompanyCode, companyID) As Boolean
        Try
            Dim ConnectionCloud As MySqlConnection = ServerCloudCon()
            Dim sql As String = ""
            If UPDATECOMPANYDETAILS Then
                sql = "SELECT companycode FROM tblcompany WHERE companycode = '" & CompanyCode & "' AND companyid <> " & companyID
            Else
                sql = "SELECT companycode FROM tblcompany WHERE companycode = '" & CompanyCode & "'"
            End If
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionCloud)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    CheckCompanyCodeExist = True
                Else
                    CheckCompanyCodeExist = False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return CheckCompanyCodeExist
    End Function

    Public Function CheckBranchName(branchname, branchid, companyid) As Boolean
        Try
            Dim ConnectionCloud As MySqlConnection = ServerCloudCon()
            Dim sql As String = ""
            If UPDATEBRANCHDETAILS Then
                sql = "SELECT branch_name FROM tblbranch WHERE branch_name = '" & branchname & "' AND branch_id <> " & branchid & " AND company_id = " & companyid
            Else
                sql = "SELECT branch_name FROM tblbranch WHERE branch_name = '" & branchname & "' AND company_id = " & companyid
            End If
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionCloud)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    CheckBranchNameExist = True
                Else
                    CheckBranchNameExist = False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return CheckBranchNameExist
    End Function
    Public Function CheckDepartment(deptname, deptid, companyid) As Boolean
        Try
            Dim ConnectionCloud As MySqlConnection = ServerCloudCon()
            Dim sql As String = ""
            If UPDATEDEPARTMENTDETAILS Then
                sql = "SELECT dep_name FROM tbldepartment WHERE dep_name = '" & deptname & "' AND dep_id <> " & deptid & " AND company_id = " & companyid
            Else
                sql = "SELECT dep_name FROM tbldepartment WHERE dep_name = '" & deptname & "' AND company_id = " & companyid
            End If
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionCloud)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    CheckDepartmentExist = True
                Else
                    CheckDepartmentExist = False
                End If
            End Using
        Catch ex As Exception
            CheckDepartmentExist = False
            MsgBox(ex.ToString)
        End Try
        Return CheckDepartmentExist
    End Function
    Public Function CheckTeamName(teamname, teamid, companyid) As Boolean
        Try
            Dim ConnectionCloud As MySqlConnection = ServerCloudCon()
            Dim sql As String = ""
            If UPDATETEAMNAMEDETAILS Then
                sql = "SELECT teamname FROM tblteam WHERE teamname = '" & teamname & "' AND teamid <> " & teamid & " AND companyid = " & companyid
            Else
                sql = "SELECT teamname FROM tblteam WHERE teamname = '" & teamname & "' AND companyid = " & companyid
            End If
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionCloud)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    CheckTeamnameExist = True
                Else
                    CheckTeamnameExist = False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return CheckTeamnameExist
    End Function
    Public Function CheckIDS(ByVal refID As Integer, ByVal checkID As Integer) As Boolean
        Dim ReturnThis As Boolean = False
        Try
            Dim ConnectionCloud As MySqlConnection = ServerCloudCon()
            Dim cmd As MySqlCommand
            Dim sql As String = ""
            If refID = 0 Then
                sql = "SELECT company_id FROM tblbranch WHERE company_id = " & checkID
                cmd = New MySqlCommand(sql, ConnectionCloud)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        ReturnThis = True
                    Else
                        ReturnThis = False
                    End If
                End Using
                If ReturnThis = False Then
                    sql = "SELECT company_id FROM tbldepartment WHERE company_id = " & checkID
                    cmd = New MySqlCommand(sql, ConnectionCloud)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            ReturnThis = True
                        Else
                            ReturnThis = False
                        End If
                    End Using
                    If ReturnThis = False Then
                        sql = "SELECT companyid FROM tblteam WHERE companyid = " & checkID
                        cmd = New MySqlCommand(sql, ConnectionCloud)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.HasRows Then
                                ReturnThis = True
                            Else
                                ReturnThis = False
                            End If
                        End Using
                    End If
                End If
            ElseIf refID = 1 Then
                sql = "SELECT branch_id FROM tbldepartment WHERE branch_id = " & checkID
                cmd = New MySqlCommand(sql, ConnectionCloud)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        ReturnThis = True
                    Else
                        ReturnThis = False
                    End If
                End Using
                If ReturnThis = False Then
                    sql = "SELECT branch_id FROM tblteam WHERE branch_id = " & checkID
                    cmd = New MySqlCommand(sql, ConnectionCloud)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            ReturnThis = True
                        Else
                            ReturnThis = False
                        End If
                    End Using
                End If
            ElseIf refID = 2 Then
                sql = "SELECT dep_id FROM tblteam WHERE dep_id = " & checkID
                cmd = New MySqlCommand(sql, ConnectionCloud)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        ReturnThis = True
                    Else
                        ReturnThis = False
                    End If
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ReturnThis
    End Function

    Public Function UserLogin(Username, Password) As Boolean
        Dim ReturnThis As Boolean = False
        Try
            Dim ConnectionLocal As MySqlConnection = LocalhostConn()
            Dim sql = "SELECT * FROM tbl_hr WHERE hr_username = '" & Username & "' AND hr_password = '" & Password & "'"
            Dim cmd As MySqlCommand = New MySqlCommand(sql, ConnectionLocal)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    ReturnThis = True
                Else
                    ReturnThis = False
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ReturnThis
    End Function

    Public Function AsDatatable(table, fields, datagridd) As DataTable
        datagridd.rows.clear
        Dim dttable As DataTable = New DataTable
        Dim ConnectionLocal As MySqlConnection = LocalhostConn()

        Dim cmd As MySqlCommand
        Dim da As MySqlDataAdapter
        Try
            Dim sql = "SELECT " & fields & " FROM " & table
            cmd = New MySqlCommand(sql, ConnectionLocal)
            da = New MySqlDataAdapter(cmd)
            da.Fill(dttable)

            cmd.Dispose()
            da.Dispose()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            ConnectionLocal.Close()
        End Try
        Return dttable
    End Function
End Module
