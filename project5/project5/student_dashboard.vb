Imports System.Data.SqlClient
Imports System.IO

Public Class student_dashboard
    Private WithEvents pic_candi As New CircularPictureBox
    Private WithEvents pan As New Panel
    Private WithEvents namelbl As Label
    Dim connectionString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=D:\new_project_SEM5\project5\project5\studvotDatabasemdf.mdf;Integrated Security=True;User Instance=True"

    Private Sub student_dashboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim form1 As New mesgBox()
        form1.TopMost = True
        form1.Owner = Me
        form1.Show()

        Load_PresidentList()
        Load_VicePresidentList()
        Load_Secretory()
        Load_GS()
    End Sub

    Sub Load_controls()
        Dim len As Long = dr.GetBytes(0, 0, Nothing, 0, 0)
        Dim array(CInt(len)) As Byte
        dr.GetBytes(0, 0, array, 0, CInt(len))

        pan = New Panel
        pan.Width = 150
        pan.Height = 160
        pan.BackColor = Color.White
        pan.Tag = dr.Item("fname").ToString

        pic_candi = New CircularPictureBox
        pic_candi.Height = 140
        pic_candi.BackgroundImageLayout = ImageLayout.Stretch
        pic_candi.Dock = DockStyle.Bottom
        pic_candi.Cursor = Cursors.Hand
        pic_candi.Tag = dr.Item("fname").ToString

        namelbl = New Label
        namelbl.ForeColor = Color.Black
        namelbl.BackColor = Color.White
        namelbl.TextAlign = ContentAlignment.MiddleCenter
        namelbl.Font = New Font("segoe UI", 8, FontStyle.Bold)
        namelbl.Dock = DockStyle.Top
        namelbl.Tag = dr.Item("fname").ToString

        namelbl.Text = dr.Item("fname").ToString

        Dim ms As New System.IO.MemoryStream(array)
        Dim bitmap As New System.Drawing.Bitmap(ms)
        pic_candi.BackgroundImage = bitmap

        AddHandler pic_candi.Click, AddressOf Selectimg_Click
        AddHandler namelbl.Click, AddressOf Selectimg_Click
    End Sub

    Public Sub Selectimg_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                cmd = New SqlCommand("select * from candidate where fname like '%" & sender.tag.ToString & "%'", conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    Dim exist As Boolean
                    For Each itm As DataGridViewRow In DataGridView1.Rows
                        If itm.Cells(3).Value IsNot Nothing Then
                            If itm.Cells(3).Value.ToString = dr.Item("position") Then
                                exist = True
                                Exit For
                            End If
                        End If
                    Next
                    If exist = False Then
                        DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, dr.Item("fname") + "  " + dr.Item("lname"), dr.Item("course"), dr.Item("position"))
                    Else
                        MsgBox("Already Selected !", vbExclamation)
                    End If
                End While
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Load_PresidentList()
        FlowLayoutPanel1.Controls.Clear()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                cmd = New SqlCommand("select * from candidate where position='President'", conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    Load_controls()
                    pan.Controls.Add(pic_candi)
                    pan.Controls.Add(namelbl)
                    FlowLayoutPanel1.Controls.Add(pan)
                End While
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Load_VicePresidentList()
        FlowLayoutPanel2.Controls.Clear()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                cmd = New SqlCommand("select * from candidate where position='Vice - President'", conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    Load_controls()
                    pan.Controls.Add(pic_candi)
                    pan.Controls.Add(namelbl)
                    FlowLayoutPanel2.Controls.Add(pan)
                End While
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Load_Secretory()
        FlowLayoutPanel3.Controls.Clear()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                cmd = New SqlCommand("select * from candidate where position='Secretary'", conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    Load_controls()
                    pan.Controls.Add(pic_candi)
                    pan.Controls.Add(namelbl)
                    FlowLayoutPanel3.Controls.Add(pan)
                End While
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Load_GS()
        FlowLayoutPanel4.Controls.Clear()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                cmd = New SqlCommand("select * from candidate where position='General Secretary'", conn)
                dr = cmd.ExecuteReader
                While dr.Read
                    Load_controls()
                    pan.Controls.Add(pic_candi)
                    pan.Controls.Add(namelbl)
                    FlowLayoutPanel4.Controls.Add(pan)
                End While
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                If DataGridView1.Rows.Count = 4 Then
                    For j As Integer = 0 To DataGridView1.Rows.Count - 1 Step +1
                        cmd = New SqlCommand("insert into voting(stud_id, date, name, course, position) values(@stud_id, @date, @name, @course, @position)", conn)
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("@stud_id", stud_login.txt_id.Text)
                        cmd.Parameters.AddWithValue("@date", Date.Now.ToString("yyyy-MM-dd hh:mm:ss tt"))
                        cmd.Parameters.AddWithValue("@name", DataGridView1.Rows(j).Cells(1).Value)
                        cmd.Parameters.AddWithValue("@course", DataGridView1.Rows(j).Cells(2).Value)
                        cmd.Parameters.AddWithValue("@position", DataGridView1.Rows(j).Cells(3).Value)
                        i = cmd.ExecuteNonQuery
                    Next

                    If i > 0 Then
                        MsgBox("Thanks for Voting !", vbInformation, "VOTE")
                        stud_login.Show()
                        Me.Hide()
                    Else
                        MsgBox("Warning : Vote Failure !", vbExclamation, "VOTE")
                        Return
                    End If
                Else
                    MsgBox("Warning : Compulsory to Choose 1 Student from each Position !", vbExclamation, "VOTE")
                    Return
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        updateStudentVoteList()
        DataGridView1.Rows.Clear()
        stud_login.txt_id.Clear()
        stud_login.txt_pass.Clear()
        stud_login.lbl_error.Text = ""
        stud_login.lbl_id_error.Text = ""
        Me.Close()
    End Sub

    Sub updateStudentVoteList()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                cmd = New SqlCommand("update voter set status=@status where stud_id = @stud_id", conn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@status", "VOTED")
                cmd.Parameters.AddWithValue("@stud_id", stud_login.txt_id.Text)
                i = cmd.ExecuteNonQuery
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
