Imports System.Data.SqlClient
Imports System.IO
Public Class frm_candidate_setting

    Dim imagePath As String = "D:\new_project_SEM5"

    Private Sub votergrid()

        Dim cmd As SqlCommand = New SqlCommand("select stud_id as 'STUD ID', fname as 'FIRST NAME', lname as 'LAST NAME', state as STATE, course as COURSE, position as POSITION, img as IMAGE from candidate", conn)
        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        Dim dt As New DataTable
        da.Fill(dt)
        DataGridView1.DataSource = dt

    End Sub

    Public Sub clear()
        txt_fname.Clear()
        txt_lname.Clear()
        txt_id.Text = "202122"
        cmb_course.SelectedIndex = -1
        cmb_pos.SelectedIndex = -1
        cmb_state.SelectedIndex = -1
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.Close()

    End Sub

    Private Sub frm_candidate_setting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        votergrid()
        Dim newFont As New Font("Verdana", 9, FontStyle.Regular)
        Dim newFontt As New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = newFont
        DataGridView1.DefaultCellStyle.Font = newFontt
        upload_candi_img.Image = Image.FromFile(imagePath + "\stud_name.png")


        ' Create a GraphicsPath with rounded corners
        Dim path As New Drawing2D.GraphicsPath()
        Dim radius As Integer = 15 ' Adjust this value to control the roundness of corners
        path.AddArc(0, 0, radius * 2, radius * 2, 180, 90) ' Top left corner
        path.AddArc(Panel1.Width - (radius * 2), 0, radius * 2, radius * 2, 270, 90) ' Top right corner
        path.AddArc(Panel1.Width - (radius * 2), Panel1.Height - (radius * 2), radius * 2, radius * 2, 0, 90) ' Bottom right corner
        path.AddArc(0, Panel1.Height - (radius * 2), radius * 2, radius * 2, 90, 90) ' Bottom left corner
        path.CloseFigure()

        ' Apply the GraphicsPath to panel1's Region
        Panel1.Region = New Region(path)

        Dim fontSize As Single = 12
        DataGridView1.DefaultCellStyle.Font = New Font(DataGridView1.DefaultCellStyle.Font.FontFamily, fontSize)
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, fontSize)
        Dim rowHeight As Integer = 28
        DataGridView1.RowTemplate.Height = rowHeight

    End Sub
    Private Function IsEmptyOrSpaces(ByVal value As String) As Boolean
        Return String.IsNullOrWhiteSpace(value) OrElse value.Trim() = ""
    End Function
    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click

        conn.Open()
        Dim q As String = "update candidate set img=@d1, fname=@d2, lname=@d3, course=@d5, state=@d6, position=@d7 where stud_id=@d4"
        Dim cmd As SqlCommand = New SqlCommand(q, conn)
        cmd.Parameters.AddWithValue("@d2", txt_fname.Text)
        cmd.Parameters.AddWithValue("@d3", txt_lname.Text)
        cmd.Parameters.AddWithValue("@d4", txt_id.Text)
        cmd.Parameters.AddWithValue("@d5", cmb_course.Text)
        cmd.Parameters.AddWithValue("@d6", cmb_state.Text)
        cmd.Parameters.AddWithValue("@d7", cmb_pos.Text)


        'code for image
        Dim ms As New MemoryStream()
        Dim img As New Bitmap(upload_candi_img.Image)
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim data As Byte() = ms.GetBuffer()
        Dim p As New SqlParameter("@d1", SqlDbType.Image)
        p.Value = data
        cmd.Parameters.Add(p)

        If IsEmptyOrSpaces(txt_id.Text) OrElse IsEmptyOrSpaces(txt_fname.Text) OrElse IsEmptyOrSpaces(txt_lname.Text) OrElse IsEmptyOrSpaces(cmb_course.Text) OrElse String.IsNullOrWhiteSpace(cmb_pos.Text) OrElse String.IsNullOrWhiteSpace(cmb_state.Text) Then
            MessageBox.Show("Fill Details !", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim n As Integer = cmd.ExecuteNonQuery()
            If n > 0 Then
                MessageBox.Show("Record Updated !", "", MessageBoxButtons.OK)
            Else
                MessageBox.Show("Record not Updated !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            clear()
            upload_candi_img.Image = Image.FromFile(imagePath + "\stud_name.png")
        End If

        conn.Close()
        votergrid()

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txt_id.Text = "202122" Then
            lbl_error.Text = "Please Write Student id !"
        Else
            Dim cmd As SqlCommand = New SqlCommand("select * from candidate where stud_id = '" & txt_id.Text & "'", conn)
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            Dim dt As New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then

                'upload_candi_img.Image = dt.Rows
                txt_fname.Text = dt.Rows(0)(1).ToString
                txt_lname.Text = dt.Rows(0)(2).ToString
                cmb_state.Text = dt.Rows(0)(5).ToString
                cmb_course.Text = dt.Rows(0)(4).ToString
                cmb_pos.Text = dt.Rows(0)(6).ToString
                Dim data As Byte() = DirectCast(dt.Rows(0)(0), Byte())
                Dim ms As New MemoryStream(data)
                upload_candi_img.Image = Image.FromStream(ms)

                lbl_error.Text = ""
            Else
                clear()
                upload_candi_img.Image = Image.FromFile(imagePath + "\stud_name.png")
                lbl_error.Text = "Record Not Found !"
            End If
        End If
       
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            With OpenFileDialog1
                .Filter = "Image Files| *.png;*.jpeg;*.jpg"
                .FilterIndex = 1
                OpenFileDialog1.FileName = ""
                Dim pop As OpenFileDialog = New OpenFileDialog
                If pop.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                    upload_candi_img.Image = Image.FromFile(pop.FileName)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            txt_fname.Text = dr.Cells(1).Value.ToString()
            txt_lname.Text = dr.Cells(2).Value.ToString()
            txt_id.Text = dr.Cells(0).Value.ToString()
            cmb_course.Text = dr.Cells(4).Value.ToString()
            cmb_state.Text = dr.Cells(3).Value.ToString()
            cmb_pos.Text = dr.Cells(5).Value.ToString()
            'code for image
            Dim data As Byte() = DirectCast(dr.Cells(6).Value, Byte())
            Dim ms As New MemoryStream(data)
            upload_candi_img.Image = Image.FromStream(ms)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        Dim id As String = txt_id.Text

        Dim cmd As New SqlCommand("delete candidate where stud_id = '" & id & "'", conn)
        conn.Open()


        If txt_fname.Text = "" Or txt_lname.Text = "" Or txt_id.Text = "202122" Or cmb_course.Text = "" Or cmb_pos.Text = "" Or cmb_state.Text = "" Then
            MessageBox.Show("Select Student !", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim n As Integer = cmd.ExecuteNonQuery()
            If n > 0 Then
                MessageBox.Show("Record Deleted !", "", MessageBoxButtons.OK)
            Else
                MessageBox.Show("Record not Deleted !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            clear()
            upload_candi_img.Image = Image.FromFile(imagePath + "\stud_name.png")

        End If

        conn.Close()
        votergrid()
    End Sub

    Private Sub txt_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_id.TextChanged
        Dim defaultValue As String = "202122"

        If Not txt_id.Text.StartsWith(defaultValue) Then
            txt_id.Text = defaultValue
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        clear()
        upload_candi_img.Image = Image.FromFile(imagePath + "\stud_name.png")
    End Sub

    Private Sub DataGridView1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.MouseHover
        lbl_error.Text = ""
    End Sub

    Private Sub Panel1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.MouseHover
        lbl_error.Text = ""
    End Sub
End Class