Module Variables
    'Mga di pwedeng characters na i entry
    Public DisallowedCharacters As String = "!#$%'~`{}^¨|°¬+[]^¨\/;=?<>*&()-+=" & """"
    'Variables para sa connections
    Public LocalhostConnectionAvailable As Boolean
    Public CloudConnectionAvailable As Boolean
    Public LocalConnectionString As String
    Public ValidLocalConnection As Boolean
    Public ValidCloudConnection As Boolean
    'cloud connection string
    Public CloudConnectionString As String
    'Reference para sa hr na gumagamit'
    Public HRUsername As String
    'List of string para sa subform sa groups'
    Public CompanyArray As New List(Of String)()
    Public BranchArray As New List(Of String)()
    Public DepartmentArray As New List(Of String)()
    Public TeamArray As New List(Of String)()
    'Checker sa insert query
    Public CheckCompanyNameExist As Boolean = False
    Public CheckCompanyCodeExist As Boolean = False

    Public CheckBranchNameExist As Boolean = False
    Public CheckDepartmentExist As Boolean = False
    Public CheckTeamnameExist As Boolean = False
    'Update groups variables
    Public UPDATECOMPANYDETAILS As Boolean = False
    Public UPDATEBRANCHDETAILS As Boolean = False
    Public UPDATEDEPARTMENTDETAILS As Boolean = False
    Public UPDATETEAMNAMEDETAILS As Boolean = False
    'GetEmpCode
    Public PIEMPLOYEECODE As Integer = 0
    'Form Employee Arrays
    Public EmployeeBasicInfoArray() As String
    Public EmployeeEmploymentDetailsArray() As String
    Public FileArray As String()

    '
    Public CloseSpecificForm As Boolean = True
End Module
