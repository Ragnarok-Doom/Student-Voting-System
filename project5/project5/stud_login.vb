Imports System.Data.SqlClient
Imports System.IO

Public Class stud_login

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit ? ", "Exit", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        admin_login.Show()
    End Sub

    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_id.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
            lbl_error.Text = "Only Numbers allowed!!!"
        ElseIf e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            lbl_error.Text = "Spaces not allowed!!!"
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = False
            lbl_error.Text = ""
        End If
        
    End Sub

    Private Sub lbl_error_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txt_id.Text = String.Empty Or txt_pass.Text = String.Empty Then
            lbl_id_error.Text = "Please Fill Student Details !"
            lbl_id_error.ForeColor = Color.Orange
        Else
            Try

                conn.Open()
                cmd = New SqlCommand("select * from studlogin where stud_id=@stud_id", conn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@stud_id", txt_id.Text)
                da = New SqlDataAdapter
                dt = New DataTable
                da.SelectCommand = cmd
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim cmdd = New SqlCommand("select * from studlogin where stud_id=@stud_id and password=@password", conn)
                    cmdd.Parameters.Clear()
                    cmdd.Parameters.AddWithValue("@stud_id", txt_id.Text)
                    cmdd.Parameters.AddWithValue("@password", txt_pass.Text)
                    Dim count As Integer = Convert.ToInt32(cmdd.ExecuteScalar())
                    If count > 0 Then
                        cmd = New SqlCommand("select * from voter where stud_id=@stud_id and status=@status", conn)
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("@stud_id", txt_id.Text)
                        cmd.Parameters.AddWithValue("@status", "UN-VOTED")
                        da = New SqlDataAdapter
                        dt = New DataTable
                        da.SelectCommand = cmd
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then

                            Dim reader As SqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then

                                Dim firstName As String = reader("fname").ToString()
                                Dim lastName As String = reader("lname").ToString()
                                Dim result As DialogResult = MessageBox.Show("Login successful! Welcome, " & firstName & "" & lastName & "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                student_dashboard.Label1.Text = firstName & " " & lastName
                                If result = DialogResult.OK Then

                                    stud_change_pass.Show()
                                    Me.Hide()

                                End If
                            End If

                        Else
                            lbl_id_error.Text = "Already Voted !"
                            lbl_id_error.ForeColor = Color.Orange
                        End If
                    Else
                        lbl_id_error.Text = "Wrong Password !"
                        lbl_id_error.ForeColor = Color.Orange
                    End If
                Else
                    lbl_id_error.Text = "Student Not Found !"
                    lbl_id_error.ForeColor = Color.Red
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            conn.Close()

        End If
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub txt_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_id.TextChanged
        
    End Sub




End Class