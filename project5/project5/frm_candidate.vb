Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO
Public Class frm_candidate

    Dim imagePath As String = "D:\new_project_SEM5"

    Private defaultImage As Image
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.Close()
    End Sub
    Sub clear()
        txt_fname.Text = "First Name"
        txt_lname.Text = "Last Name"
        txt_stud_id.Text = "202122"
        cmb_course.Text = "Select Course"
        cmb_state.Text = "Select State"
        cmb_pos.Text = "Select Position"
        Dim textboxes As TextBox() = {txt_fname, txt_lname}
        Dim comboboxes As ComboBox() = {cmb_course, cmb_pos, cmb_state}
        For Each textBox As TextBox In textboxes
            textBox.ForeColor = Color.Silver
        Next
        For Each comboBox As ComboBox In comboboxes
            comboBox.ForeColor = Color.Silver
        Next
    End Sub


    '------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------
    '----------------------------------------------- PLACE HOLDER -----------------------------------------------
    '------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------


    Private Sub txt_fname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_fname.Enter
        If txt_fname.Text = "First Name" Then
            txt_fname.Text = ""
            txt_fname.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txt_lname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_lname.Enter
        If txt_lname.Text = "Last Name" Then
            txt_lname.Text = ""
            txt_lname.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txt_fname_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_fname.Leave
        If txt_fname.Text = "" Then
            txt_fname.Text = "First Name"
            txt_fname.ForeColor = Color.Silver
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

    Private Sub cmb_state_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_state.Enter
        If cmb_state.Text = "Select State" Then
            cmb_state.Text = ""
            cmb_state.ForeColor = Color.Black
        End If
    End Sub

    Private Sub cmb_state_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_state.Leave
        If cmb_state.Text = "" Then
            cmb_state.Text = "Select State"
            cmb_state.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub cmb_pos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_pos.Enter
        If cmb_pos.Text = "Select Position" Then
            cmb_pos.Text = ""
            cmb_pos.ForeColor = Color.Black
        End If
    End Sub

    Private Sub cmb_pos_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_pos.Leave
        If cmb_pos.Text = "" Then
            cmb_pos.Text = "Select Position"
            cmb_pos.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub frm_candidate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        defaultImage = Image.FromFile(imagePath + "\upload_photo.png")
        upload_candi_image.Image = defaultImage

    End Sub

    Private Sub CircularPictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upload_candi_image.Click

        Try
            With OpenFileDialog1
                .Filter = "Image Files| *.png;*.jpeg;*.jpg"
                .FilterIndex = 1
                OpenFileDialog1.FileName = ""
                Dim pop As OpenFileDialog = New OpenFileDialog
                If pop.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                    upload_candi_image.Image = Image.FromFile(pop.FileName)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub upload_candi_image_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upload_candi_image.MouseHover
        If upload_candi_image.Image Is defaultImage Then
            Label7.Text = "Upload Your Image!"
        Else
            Label7.Text = ""
        End If

    End Sub

    Private Sub upload_candi_image_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles upload_candi_image.MouseLeave
        Label7.Text = " "
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------
    '------------------------------------------- PLACE HOLDER OFF-------------------------------------------------
    '------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    '  Private Sub TextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_stud_id.Enter
    '     If txt_stud_id.Text = "ex. 202122" Then
    '        txt_stud_id.Text = ""
    '       txt_stud_id.ForeColor = Color.Black
    '  End If
    'End Sub

    '  Private Sub txt_stud_id_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_stud_id.Leave
    '     If txt_stud_id.Text = "" Then
    '        txt_stud_id.Text = "ex. 202122"
    '       txt_stud_id.ForeColor = Color.Silver
    '  End If
    'End Sub

    Private Sub txt_stud_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_stud_id.TextChanged
        Dim defaultValue As String = "202122"

        If Not txt_stud_id.Text.StartsWith(defaultValue) Then
            txt_stud_id.Text = defaultValue
        End If
    End Sub

    '------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------
    '------------------------------------------ VALIDATION ------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------
    '------------------------------------------------------------------------------------------------------------


    Private Sub txt_stud_id_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_stud_id.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
            MessageBox.Show("Only Numbers Allowed")
        ElseIf e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("Spaces not Allowed")
        End If
    End Sub

    Private Sub txt_fname_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_fname.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("Only Alphabets Allow!")
        End If
    End Sub

    Private Sub txt_lname_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_lname.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("Only Alphabets Allow!")
        End If
    End Sub

    Private Sub cmb_course_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_course.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back) Or e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("Just Select!!!")
        End If
    End Sub

    Private Sub cmb_state_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_state.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back) Or e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("Just Select!!!")
        End If
    End Sub

    Private Sub cmb_pos_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_pos.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back) Or e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("Just Select!!!")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            '----------- Stud ID ------------------
            If txt_stud_id.Text = "202122" Or String.IsNullOrEmpty(txt_stud_id.Text.Trim) Then
                ErrorProvider1.SetError(txt_stud_id, "Student ID Required")
                txt_stud_id.Focus()
                Return
            Else
                ErrorProvider1.SetError(txt_stud_id, String.Empty)
            End If
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

            '----------- Course ------------------
            If cmb_course.Text = "Select Course" Or String.IsNullOrEmpty(cmb_course.Text.Trim) Then
                ErrorProvider1.SetError(cmb_course, "Course Required")
                cmb_course.Focus()
                Return
            Else
                ErrorProvider1.SetError(cmb_course, String.Empty)
            End If
            '----------- State ------------------
            If cmb_state.Text = "Select State" Or String.IsNullOrEmpty(cmb_state.Text.Trim) Then
                ErrorProvider1.SetError(cmb_state, "State Required")
                cmb_state.Focus()
                Return
            Else
                ErrorProvider1.SetError(cmb_state, String.Empty)
            End If
            '----------- Position ------------------
            If cmb_pos.Text = "Select Position" Or String.IsNullOrEmpty(cmb_pos.Text.Trim) Then
                ErrorProvider1.SetError(cmb_pos, "Position Required")
                cmb_pos.Focus()
                Return
            Else
                ErrorProvider1.SetError(cmb_pos, String.Empty)
            End If

            '--------imge------------
            If Object.ReferenceEquals(upload_candi_image.Image, defaultImage) Then
                MessageBox.Show("Please upload an image before proceeding.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If


        Catch ex As Exception
            MsgBox("Error on validation !")
        End Try



        '------------------------------------------------------------------------------------------------------------
        '------------------------------------------------------------------------------------------------------------
        '---------------------------------------------- VALIDATION OFF ----------------------------------------------
        '------------------------------------------------------------------------------------------------------------
        '------------------------------------------------------------------------------------------------------------



        '----------------------------- INSERT QUERY ----------------------------------

        Dim studentID As String = txt_stud_id.Text

        Try
            If Not StudentExists(studentID) Then
                If Not txt_stud_id.Text = "202122" Then
                    Dim cmd As New SqlCommand("Insert into candidate (img, fname, lname, stud_id, course, state, position) values(@d1, @d2, @d3, @d4, @d5, @d6, @d7)", conn)
                    cmd.Parameters.AddWithValue("@d2", txt_fname.Text + " ")
                    cmd.Parameters.AddWithValue("@d3", txt_lname.Text)
                    cmd.Parameters.AddWithValue("@d4", txt_stud_id.Text)
                    cmd.Parameters.AddWithValue("@d5", cmb_course.Text)
                    cmd.Parameters.AddWithValue("@d6", cmb_state.Text)
                    cmd.Parameters.AddWithValue("@d7", cmb_pos.Text)
                    conn.Open()

                    'code for image
                    Dim ms As New MemoryStream()
                    Dim img As New Bitmap(upload_candi_image.Image)
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Dim data As Byte() = ms.GetBuffer()
                    Dim p As New SqlParameter("@d1", SqlDbType.Image)
                    p.Value = data
                    cmd.Parameters.Add(p)


                    Dim l As Integer = cmd.ExecuteNonQuery()
                    If l > 0 Then
                        MsgBox("Record Inserted !", MessageBoxButtons.OK)

                    Else
                        MsgBox("Record Not Inserted !", MessageBoxButtons.OK)
                    End If

                    upload_candi_image.Image = My.Resources.add_photo_camera_icon_134644
                    clear()

                Else
                    MessageBox.Show("202122 is not a valid !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Student ID already exists .", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()

    End Sub

    Private Function StudentExists(ByVal studentID As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM candidate WHERE stud_id = @StudentID"
        Dim command As New SqlCommand(query, conn)
        command.Parameters.AddWithValue("@StudentID", studentID)

        conn.Open()
        Dim count As Integer = CInt(command.ExecuteScalar())
        conn.Close()

        Return count > 0
    End Function

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click

        With frm_candidate_setting
            .TopLevel = False
            admin_dashboard.Panel3.Controls.Add(frm_candidate_setting)
            .BringToFront()
            .Show()

        End With
    End Sub

    Private Sub txt_lname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_lname.TextChanged

    End Sub
End Class