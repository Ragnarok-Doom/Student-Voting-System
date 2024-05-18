Imports System.Data.SqlClient
Imports System.IO

Public Class stud_change_pass
    'Public Property StudentId As String
    'Public Sub New(ByVal studentId As String)
    '    InitializeComponent()
    '    Me.studentId = studentId
    'End Sub

    Private Sub txt_user_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_id.TextChanged

    End Sub

    Private Sub txt_kpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_kpass.TextChanged

    End Sub

    Private Sub txt_chpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_chpass.TextChanged

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim studentId As String = txt_id.Text
        Dim newPassword As String = txt_chpass.Text
        Dim confirmPassword As String = txt_kpass.Text

        ' Check if the new password and confirm password match
        If newPassword <> confirmPassword Then
            MessageBox.Show("Passwords do not match. Please try again.")
            Return
        End If

        Try
            conn.Open()

            ' Check if the student ID exists in the database
            'Dim queryCheckStudentId As String = "SELECT COUNT(*) FROM studlogin WHERE stud_id = @student_id"
            'Using cmdCheckStudentId As New SqlCommand(queryCheckStudentId, conn)
            '    cmdCheckStudentId.Parameters.AddWithValue("@student_id", studentId)
            '    Dim studentIdCount As Integer = Convert.ToInt32(cmdCheckStudentId.ExecuteScalar())

            '    If studentIdCount = 0 Then
            '        MessageBox.Show("Student ID not found.")
            '        Return
            '    End If
            'End Using

            If studentId = stud_login.txt_id.Text Then
                ' Update the password for the student
                Dim queryUpdatePassword As String = "UPDATE studlogin SET password = @newPassword WHERE stud_id = @student_id"
                Using cmdUpdatePassword As New SqlCommand(queryUpdatePassword, conn)
                    cmdUpdatePassword.Parameters.AddWithValue("@newPassword", newPassword)
                    cmdUpdatePassword.Parameters.AddWithValue("@student_id", studentId)
                    Dim affectedRows As Integer = cmdUpdatePassword.ExecuteNonQuery()

                    If affectedRows > 0 Then
                        MessageBox.Show("Password updated successfully.")
                        Me.Hide()
                        student_dashboard.Show()
                    Else
                        MessageBox.Show("Failed to update password.")
                    End If
                End Using
            Else
                MsgBox("Your Student ID is Wrong !", MsgBoxStyle.Exclamation)
            End If

            

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub stud_change_pass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Me.Hide()
        stud_login.Show()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub
End Class