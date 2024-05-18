Imports System.Data.SqlClient
Public Class frm_voter_setting



    Private Sub votergrid()

        Dim cmd As SqlCommand = New SqlCommand("select stud_id as 'Stud ID', fname as 'First Name', lname as 'Last Name', email as 'Email', course as 'Course', year as 'Semester', status as 'Status' from voter", conn)
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        da.SelectCommand = cmd
        da.Fill(dt)
        DataGridView1.DataSource = dt

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.Close()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub frm_voter_setting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        votergrid()
        Dim newFont As New Font("Verdana", 9, FontStyle.Regular)
        Dim newFontt As New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = newFont
        DataGridView1.DefaultCellStyle.Font = newFontt





        Dim path As New Drawing2D.GraphicsPath()
        Dim radius As Integer = 15
        path.AddArc(0, 0, radius * 2, radius * 2, 180, 90) ' Top left corner
        path.AddArc(Panel1.Width - (radius * 2), 0, radius * 2, radius * 2, 270, 90) ' Top right corner
        path.AddArc(Panel1.Width - (radius * 2), Panel1.Height - (radius * 2), radius * 2, radius * 2, 0, 90) ' Bottom right corner
        path.AddArc(0, Panel1.Height - (radius * 2), radius * 2, radius * 2, 90, 90) ' Bottom left corner
        path.CloseFigure()
        Panel1.Region = New Region(path)


        Dim fontSize As Single = 12
        DataGridView1.DefaultCellStyle.Font = New Font(DataGridView1.DefaultCellStyle.Font.FontFamily, fontSize)
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, fontSize)
        Dim rowHeight As Integer = 40
        DataGridView1.RowTemplate.Height = rowHeight

    End Sub

    Private Function IsEmptyOrSpaces(ByVal value As String) As Boolean
        Return String.IsNullOrWhiteSpace(value) OrElse value.Trim() = ""
    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        lbl_error.Text = ""
        Dim fname As String = txt_fname.Text
        Dim lname As String = txt_lname.Text
        Dim email As String = txt_email.Text
        Dim id As String = txt_id.Text
        Dim course As String = cmb_course.Text
        Dim year As String = cmb_year.Text


        Dim cmd As New SqlCommand("update voter set fname = '" & fname & "', lname = '" & lname & "', email = '" & email & "', course = '" & course & "', year = '" & year & "' where stud_id = '" & id & "'", conn)
        conn.Open()


        If IsEmptyOrSpaces(txt_id.Text) OrElse IsEmptyOrSpaces(txt_fname.Text) OrElse IsEmptyOrSpaces(txt_lname.Text) OrElse IsEmptyOrSpaces(txt_email.Text) OrElse String.IsNullOrWhiteSpace(cmb_course.Text) OrElse String.IsNullOrWhiteSpace(cmb_year.Text) Then
            MessageBox.Show("Fill Details !", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim n As Integer = cmd.ExecuteNonQuery()
            If n > 0 Then
                MessageBox.Show("Record Updated !", "", MessageBoxButtons.OK)
            Else
                MessageBox.Show("Record not Updated !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            txt_fname.Clear()
            txt_lname.Clear()
            txt_email.Clear()
            txt_id.Text = "202122"
            cmb_course.SelectedIndex = -1
            cmb_year.SelectedIndex = -1
        End If

        conn.Close()
        votergrid()


    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim cmd As SqlCommand = New SqlCommand("select * from voter where stud_id = '" & txt_id.Text & "'", conn)
        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim dt As New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            txt_fname.Text = dt.Rows(0)(0).ToString
            txt_lname.Text = dt.Rows(0)(1).ToString
            txt_email.Text = dt.Rows(0)(2).ToString
            cmb_course.Text = dt.Rows(0)(4).ToString
            cmb_year.Text = dt.Rows(0)(5).ToString
            lbl_error.Text = ""
        Else
            txt_fname.Clear()
            txt_lname.Clear()
            txt_email.Clear()
            cmb_course.SelectedIndex = -1
            cmb_year.SelectedIndex = -1
            lbl_error.Text = "Record Not Found !"
        End If

    End Sub

    Private Sub DataGridView1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            txt_fname.Text = dr.Cells(1).Value.ToString()
            txt_lname.Text = dr.Cells(2).Value.ToString()
            txt_email.Text = dr.Cells(3).Value.ToString()
            txt_id.Text = dr.Cells(0).Value.ToString()
            cmb_course.Text = dr.Cells(4).Value.ToString()
            cmb_year.Text = dr.Cells(5).Value.ToString()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        lbl_error.Text = ""
        Dim id As String = txt_id.Text


        Dim cmd As New SqlCommand("delete voter where stud_id = '" & id & "'", conn)
        conn.Open()


        
            Dim n As Integer = cmd.ExecuteNonQuery()
            If n > 0 Then
                MessageBox.Show("Record Deleted !", "", MessageBoxButtons.OK)
            Else
                MessageBox.Show("Record not Deleted !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            txt_fname.Clear()
            txt_lname.Clear()
            txt_email.Clear()
            txt_id.Text = "202122"
            cmb_course.SelectedIndex = -1
            cmb_year.SelectedIndex = -1


        conn.Close()
        votergrid()

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        lbl_error.Text = ""
    End Sub

    Private Sub txt_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_id.TextChanged
        Dim defaultValue As String = "202122"

        If Not txt_id.Text.StartsWith(defaultValue) Then
            txt_id.Text = defaultValue
        End If
    End Sub

    Public Sub clear()
        txt_id.Clear()
        txt_fname.Clear()
        txt_lname.Clear()
        txt_email.Clear()
        cmb_course.SelectedIndex = -1
        cmb_year.SelectedIndex = -1
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        clear()
        lbl_error.Text = ""
    End Sub

    Private Sub frm_voter_setting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        lbl_error.Text = ""
    End Sub

    Private Sub DataGridView1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.MouseHover
        lbl_error.Text = ""
    End Sub

    Private Sub cmb_course_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_course.SelectedIndexChanged

    End Sub
End Class