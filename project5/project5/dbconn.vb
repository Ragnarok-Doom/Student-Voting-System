Imports System.Data.SqlClient
Imports System.IO

Module dbconn
    Dim result As Boolean
    Public conn As SqlConnection = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=D:\new_project_SEM5\project5\project5\studvotDatabasemdf.mdf;Integrated Security=True;User Instance=True")
    Public cmd As SqlCommand
    Public da As SqlDataAdapter
    Public dt As DataTable
    Public dr As SqlDataReader
    Public i As Integer
End Module
