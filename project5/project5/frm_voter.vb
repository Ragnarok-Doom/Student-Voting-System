Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.IO




Public Class frm_voter

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.Close()

    End Sub

    Sub clear()

        txt_fname.Text = "First Name"
        txt_lname.Text = "Last Name"
        txt_email.Text = "ex. xyz@gmail.com"
        txt_stud_id.Text = "202122"
        cmb_course.Text = "Select Course"
        cmb_year.Text = "Select Sem"
        Dim textboxes As TextBox() = {txt_email, txt_fname, txt_lname}
        Dim comboboxes As ComboBox() = {cmb_course, cmb_year}

        For Each textBox As TextBox In textboxes
            textBox.ForeColor = Color.Silver
        Next
        For Each comboBox As ComboBox In comboboxes
            comboBox.ForeColor = Color.Silver
        Next

    End Sub


    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_fname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_fname.TextChanged

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub cmb_course_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_course.SelectedIndexChanged

    End Sub

    Private Sub txt_stud_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_stud_id.TextChanged
        Dim defaultValue As String = "202122"

        If Not txt_stud_id.Text.StartsWith(defaultValue) Then
            txt_stud_id.Text = defaultValue
        End If
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub txt_lname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_lname.TextChanged

    End Sub

    Private Sub frm_voter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txt_fname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_fname.Enter
        If txt_fname.Text = "First Name" Then
            txt_fname.Text = ""
            txt_fname.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txt_fname_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_fname.Leave
        If txt_fname.Text = "" Then
            txt_fname.Text = "First Name"
            txt_fname.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub txt_lname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_lname.Enter
        If txt_lname.Text = "Last Name" Then
            txt_lname.Text = ""
            txt_lname.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txt_lname_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_lname.Leave
        If txt_lname.Text = "" Then
            txt_lname.Text = "Last Name"
            txt_lname.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub cmb_course_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_course.Enter
        If cmb_course.Text = "Select Course" Then
            cmb_course.Text = ""
            cmb_course.ForeColor = Color.Black
        End If
    End Sub

    Private Sub cmb_course_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_course.Leave
        If cmb_course.Text = "" Then
            cmb_course.Text = "Select Course"
            cmb_course.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub cmb_course_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_course.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back) Or e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("You Can not Change it!")
        End If
    End Sub

    'Private Sub txt_stud_id_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_stud_id.Enter
    '   If txt_stud_id.Text = "ex. 202122" Then
    '      txt_stud_id.Text = ""
    '     txt_stud_id.ForeColor = Color.Black
    'End If
    'End Sub

    'Private Sub txt_stud_id_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_stud_id.Leave
    '   If txt_stud_id.Text = "" Then
    '      txt_stud_id.Text = "ex. 202122"
    '     txt_stud_id.ForeColor = Color.Silver
    ' End If
    'End Sub

    Private Sub cmb_year_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_year.Enter
        If cmb_year.Text = "Select Sem" Then
            cmb_year.Text = ""
            cmb_year.ForeColor = Color.Black
        End If
    End Sub

    Private Sub cmb_year_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_year.Leave
        If cmb_year.Text = "" Then
            cmb_year.Text = "Select Sem"
            cmb_year.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub cmb_year_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_year.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back) Or e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("You Can not Change it!")
        End If
    End Sub

    Private Sub TextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_email.Enter
        If txt_email.Text = "ex. xyz@gmail.com" Then
            txt_email.Text = ""
            txt_email.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txt_email_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_email.Leave
        If txt_email.Text = "" Then
            txt_email.Text = "ex. xyz@gmail.com"
            txt_email.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub btn_register_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_register.Click

        Try
            ' ----------First Name ----------
            If txt_fname.Text = "First Name" Or String.IsNullOrEmpty(txt_fname.Text.Trim) Then
                ErrorProvider1.SetError(txt_fname, "First Name Required")
                txt_fname.Focus()
                Return
            Else
                ErrorProvider1.SetError(txt_fname, String.Empty)
            End If
            '---------- Last Name --------------
            If txt_lname.Text = "Last Name" Or String.IsNullOrEmpty(txt_lname.Text.Trim) Then
                ErrorProvider1.SetError(txt_lname, "Last Name Required")
                txt_lname.Focus()
                Return
            Else
                ErrorProvider1.SetError(txt_lname, String.Empty)
            End If
            '----------- Email ------------------
            If txt_email.Text = "ex. xyz@gmail.com" Or String.IsNullOrEmpty(txt_email.Text.Trim) Then
                ErrorProvider1.SetError(txt_email, "Email Required")
                txt_email.Focus()
                Return
            Else
                ErrorProvider1.SetError(txt_email, String.Empty)
            End If
            '----------- Stud ID ------------------
            If txt_stud_id.Text = "ex. 202122" Or String.IsNullOrEmpty(txt_stud_id.Text.Trim) Then
                ErrorProvider1.SetError(txt_stud_id, "Student ID Required")
                txt_stud_id.Focus()
                Return
            Else
                ErrorProvider1.SetError(txt_stud_id, String.Empty)
            End If
            '----------- Course ------------------
            If cmb_course.Text = "Select Course" Or String.IsNullOrEmpty(cmb_course.Text.Trim) Then
                ErrorProvider1.SetError(cmb_course, "Course Required")
                cmb_course.Focus()
                Return
            Else
                ErrorProvider1.SetError(cmb_course, String.Empty)
            End If
            '----------- Year ------------------
            If cmb_year.Text = "Select Sem" Or String.IsNullOrEmpty(cmb_year.Text.Trim) Then
                ErrorProvider1.SetError(cmb_year, "Year Required")
                cmb_year.Focus()
                Return
            Else
                ErrorProvider1.SetError(cmb_year, String.Empty)
            End If

            '--------------emial validation------------------
            '^[^@\s]+@[^@\s]+\.[^@\s]+$  ^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\[a-zA-Z{2,}$
            Dim regex As Regex = New Regex("^[^@\s]+@[^@\s]+\.[^@\s]+$")
            Dim isvalid As Boolean = regex.IsMatch(txt_email.Text.Trim)
            If Not isvalid Then
                lbl_email_error.Text = "Email not Valid"
                Return
            Else
                lbl_email_error.Text = ""

            End If
        Catch ex As Exception
            MsgBox("Errors are there !", vbExclamation)
        End Try






        '----------------------------- INSERT QUERY ----------------------------------
        Dim studentID As String = txt_stud_id.Text
        Dim fname As String = txt_fname.Text + " "
        Dim lname As String = txt_lname.Text
        Dim email As String = txt_email.Text
        Dim id As String = txt_stud_id.Text
        Dim course As String = cmb_course.Text
        Dim year As String = cmb_year.Text



        Try
            If Not StudentExists(studentID) Then
                If Not txt_stud_id.Text = "202122" Then
                    conn.Open()
                    Dim cmd As New SqlCommand("Insert into voter values('" & fname & "','" & lname & "','" & email & "','" & id & "','" & course & "','" & year & "', 'UN-VOTED')", conn)
                    Dim cmdd As New SqlCommand("Insert into studlogin values('" & id & "','" & fname + lname & "', '1234')", conn)

                    cmdd.ExecuteNonQuery()
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    If i > 0 Then
                        MessageBox.Show("Record Inserted !", "", MessageBoxButtons.OK)
                    Else
                        MessageBox.Show("Record not Inserted !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    clear()
                Else
                    MessageBox.Show("202122 is not a valid Student Id !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Student ID already exists in the database.")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        conn.Close()

        manage_student.Load_studentData()

    End Sub
    Private Function StudentExists(ByVal studentID As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM voter WHERE stud_id = @StudentID"
        Dim command As New SqlCommand(query, conn)
        command.Parameters.AddWithValue("@StudentID", studentID)

        conn.Open()
        Dim count As Integer = CInt(command.ExecuteScalar())
        conn.Close()

        Return count > 0
    End Function

    Private Sub txt_fname_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_fname.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("Only Alphabets Allowed!!!")
        End If
    End Sub

    Private Sub txt_lname_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_lname.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("Only Alphabets Allowed!!!")
        End If
    End Sub

    Private Sub txt_stud_id_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_stud_id.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
            MessageBox.Show("Only Numbers Allowed")
        ElseIf e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("Spaces not Allowed")
        End If
    End Sub

    Private Sub txt_email_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_email.KeyPress

    End Sub

    Private Sub txt_email_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_email.TextChanged

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        With frm_voter_setting
            .TopLevel = False
            admin_dashboard.Panel3.Controls.Add(frm_voter_setting)
            .BringToFront()
            .Show()
        End With
    End Sub

End Class