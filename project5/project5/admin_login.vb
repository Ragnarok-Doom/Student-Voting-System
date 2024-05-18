Imports System.Data.SqlClient
Imports System.IO

Public Class admin_login

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit ? ", "Exit", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        stud_login.Show()

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_user.KeyPress

        If Char.IsLetterOrDigit(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = False
            lbl_error.Text = ""
        End If
        If e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            lbl_error.Text = "Spaces not allow!!"
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pass.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = False
            lbl_error.Text = ""
        End If
        If e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            lbl_error.Text = "Spaces not allow!!"
        End If
    End Sub

    Private Sub admin_login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_login.Click
        conn.Open()
        Dim cmd As SqlCommand = New SqlCommand("select * from admin where username=@username and password=@password", conn)
        cmd.Parameters.AddWithValue("username", txt_user.Text.Trim)
        cmd.Parameters.AddWithValue("password", txt_pass.Text.Trim)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        txt_pass.Clear()
        txt_user.Clear()

        If reader.Read Then
            admin_dashboard.Show()
            MessageBox.Show("Welcome , Admin !", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
        Else
            MessageBox.Show("Username or Password Incorrect !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        conn.Close()
    End Sub
End Class