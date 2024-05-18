Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics
Imports System.Text
Imports System.Drawing

Public Class manage_student
    'Private searchColumn As Integer = -1
    Dim unvotedSearchByAll As Boolean = True ' Indicates whether to search all columns by default for unvoted DataGridView
    Dim unvotedSearchColumn As Integer = -1
    Dim imagePath As String = "D:\new_project_SEM5"
    Dim htmlPath As String = "D:\new_project_SEM5\html"
    Dim pdfPath As String = "D:\new_project_SEM5\pdf"
    Dim heading As String = ""

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    '-----------------------------------------------------------------------------------------------------
    '------------------------------------------ VOTER GRIDVIEW -------------------------------------------
    '-----------------------------------------------------------------------------------------------------
    Sub Load_studentData()
        DataGridView1.Rows.Clear()
        Try
            conn.Open()
            cmd = New SqlCommand("select * from voter", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, dr.Item("stud_id"), dr.Item("fname") + dr.Item("lname"), dr.Item("email"), dr.Item("course"), dr.Item("year"), dr.Item("status"))
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
    '-----------------------------------------------------------------------------------------------------
    '------------------------------------------ CANDIDATE GRIDVIEW ---------------------------------------
    '-----------------------------------------------------------------------------------------------------
    Sub Load_studentData2()
        DataGridView2.Rows.Clear()
        Try
            conn.Open()
            cmd = New SqlCommand("select * from candidate", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView2.Rows.Add(DataGridView2.Rows.Count + 1, dr.Item("stud_id"), dr.Item("fname") + dr.Item("lname"), dr.Item("course"), dr.Item("state"), dr.Item("position"))
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    '-----------------------------------------------------------------------------------------------------
    '------------------------------------------ VOTED GRIDVIEW ---------------------------------------
    '-----------------------------------------------------------------------------------------------------
    Sub Load_studentData3()
        DataGridView3.Rows.Clear()
        Try
            conn.Open()
            cmd = New SqlCommand("select * from voter where status = 'VOTED'", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView3.Rows.Add(DataGridView3.Rows.Count + 1, dr.Item("fname") + dr.Item("lname"), dr.Item("course"), dr.Item("year"))
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
        'Dim dataTable As New DataTable()

        'Try

        '    conn.Open()

        '    ' SQL query to join the "voter" and "voting" tables and select the desired columns
        '    Dim query As String = "SELECT v.name, v.date AS 'vote time', c.course, c.year " &
        '                          "FROM voting AS c " &
        '                          "LEFT JOIN voter AS v ON c.fname + ' ' + c.lname = v.name"

        '    Using adapter As New SqlDataAdapter(query, conn)
        '        adapter.Fill(dataTable)
        '    End Using
        '    conn.Close()
        'Catch ex As Exception
        '    MessageBox.Show("An error occurred while loading data: " & ex.Message)
        'End Try

        '' Bind the DataGridView to the DataTable
        'DataGridView3.DataSource = dataTable
    End Sub
    '-----------------------------------------------------------------------------------------------------
    '------------------------------------------ UNVOTED GRIDVIEW ---------------------------------------
    '-----------------------------------------------------------------------------------------------------
    Sub Load_studentData4()
        DataGridView4.Rows.Clear()
        Try
            conn.Open()
            cmd = New SqlCommand("select * from voter where status = 'UN-VOTED'", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView4.Rows.Add(DataGridView4.Rows.Count + 1, dr.Item("fname") + dr.Item("lname"), dr.Item("course"), dr.Item("year"))
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    '-----------------------------------------------------------------------------------------------------
    '------------------------------------------ POSITION & VOTE GRIDVIEW ---------------------------------------
    '-----------------------------------------------------------------------------------------------------
    'Sub Load_studentData5()
    '    DataGridView5.Rows.Clear()
    '    Try
    '        conn.Open()
    '        cmd = New SqlCommand("select * from candidate where position = @position", conn)
    '        cmd.Parameters.AddWithValue("@position", cmb_pos_nv.Text)
    '        dr = cmd.ExecuteReader
    '        While dr.Read
    '            DataGridView5.Rows.Add(DataGridView5.Rows.Count + 1, dr.Item("stud_id"), dr.Item("fname") + dr.Item("lname"), dr.Item("course"), dr.Item("course"))
    '        End While

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    conn.Close()
    'End Sub


    Private Sub manage_student_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Load_studentData()
        Load_studentData2()
        Load_studentData3()
        Load_studentData4()
        lbl_vsearch.Hide()
        lbl_csearch.Hide()
        lblvotsearch.Hide()
        lbl_unvot.Hide()
        lblcaninfoerror.Hide()
        lbl_posvot_error.Hide()
        pnlInfo.Hide()

        ComboBox1.Enabled = False

        CircularPictureBox1.Image = Image.FromFile(imagePath + "\stud_name.png")


        ' Create a GraphicsPath with rounded corners
        Dim path As New Drawing2D.GraphicsPath()
        Dim radius As Integer = 15 ' Adjust this value to control the roundness of corners
        path.AddArc(0, 0, radius * 2, radius * 2, 180, 90) ' Top left corner
        path.AddArc(Panel7.Width - (radius * 2), 0, radius * 2, radius * 2, 270, 90) ' Top right corner
        path.AddArc(Panel7.Width - (radius * 2), Panel7.Height - (radius * 2), radius * 2, radius * 2, 0, 90) ' Bottom right corner
        path.AddArc(0, Panel7.Height - (radius * 2), radius * 2, radius * 2, 90, 90) ' Bottom left corner
        path.CloseFigure()

        ' Apply the GraphicsPath to panel1's Region
        Panel7.Region = New Region(path)



        Dim fontSize As Single = 12
        Dim rowHeight As Integer = 50
        DataGridView1.DefaultCellStyle.Font = New Font(DataGridView1.DefaultCellStyle.Font.FontFamily, fontSize)
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, fontSize)
        DataGridView1.RowTemplate.Height = rowHeight

        DataGridView2.DefaultCellStyle.Font = New Font(DataGridView2.DefaultCellStyle.Font.FontFamily, fontSize)
        DataGridView2.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView2.ColumnHeadersDefaultCellStyle.Font.FontFamily, fontSize)

        DataGridView3.DefaultCellStyle.Font = New Font(DataGridView3.DefaultCellStyle.Font.FontFamily, fontSize)
        DataGridView3.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView3.ColumnHeadersDefaultCellStyle.Font.FontFamily, fontSize)

        DataGridView4.DefaultCellStyle.Font = New Font(DataGridView4.DefaultCellStyle.Font.FontFamily, fontSize)
        DataGridView4.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView4.ColumnHeadersDefaultCellStyle.Font.FontFamily, fontSize)

        DataGridView5.DefaultCellStyle.Font = New Font(DataGridView5.DefaultCellStyle.Font.FontFamily, fontSize)
        DataGridView5.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView5.ColumnHeadersDefaultCellStyle.Font.FontFamily, fontSize)





    End Sub


    '-----------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------
    '---------------------------------------------- VOTER LIST SEARCH -------------------------------------------
    '-----------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------
    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vsearch.TextChanged
        DataGridView1.Rows.Clear()
        Try
            conn.Open()
            cmd = New SqlCommand("select * from voter where stud_id like '%" & txt_vsearch.Text & "%' or email like '%" & txt_vsearch.Text & "%' or fname like '%" & txt_vsearch.Text & "%' or lname like '%" & txt_vsearch.Text & "%' or course like '%" & txt_vsearch.Text & "%' or status like '%" & txt_vsearch.Text & "%' or year like '%" & txt_vsearch.Text & "%'", conn)
            'lbl_vsearch.Hide()
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                lbl_vsearch.Hide()
                While dr.Read
                    DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, dr.Item("stud_id"), dr.Item("fname") + dr.Item("lname"), dr.Item("email"), dr.Item("course"), dr.Item("year"), dr.Item("status"))
                End While
            Else
                lbl_vsearch.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
        'Load_studentData()
    End Sub
    '-----------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------
    '---------------------------------------------- VOTER LIST SEARCH END ---------------------------------------
    '-----------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------

    Private Sub Label2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.Close()
    End Sub

    Private Sub txt_search_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vsearch.Enter
        If txt_vsearch.Text = "Search" Then
            txt_vsearch.Text = ""
            lbl_vsearch.Hide()
        End If
        txt_vsearch.ForeColor = Color.Black
    End Sub

    Private Sub txt_search_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_vsearch.Leave
        If txt_vsearch.Text = "" Then
            txt_vsearch.Text = "Search"
            Load_studentData()
            lbl_vsearch.Hide()
        End If
        txt_vsearch.ForeColor = Color.DarkGray
    End Sub


    '-----------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------
    '------------------------------------------ CANDIDATE SEARCH LIST -------------------------------------------
    '-----------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------
    Private Sub txt_csearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_csearch.TextChanged
        DataGridView2.Rows.Clear()
        Try
            conn.Open()
            cmd = New SqlCommand("select * from candidate where stud_id like '%" & txt_csearch.Text & "%' or fname like '%" & txt_csearch.Text & "%' or lname like '%" & txt_csearch.Text & "%' or course like '%" & txt_csearch.Text & "%' or state like '%" & txt_csearch.Text & "%' or position like '%" & txt_csearch.Text & "%'", conn)
            '     lbl_csearch.Hide()
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                lbl_csearch.Hide()
                While dr.Read
                    DataGridView2.Rows.Add(DataGridView2.Rows.Count + 1, dr.Item("stud_id"), dr.Item("fname") + dr.Item("lname"), dr.Item("course"), dr.Item("state"), dr.Item("position"))
                End While
            Else
                lbl_csearch.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
        ' Load_studentData2()
    End Sub
    '-----------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------
    '-------------------------------------------- CANDIDATE SEARCH LIST END -------------------------------------
    '-----------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------



    Private Sub txt_csearch_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_csearch.Enter
        If txt_csearch.Text = "Search" Then
            txt_csearch.Text = ""
            lbl_csearch.Hide()
        End If
        txt_csearch.ForeColor = Color.Black

    End Sub

    Private Sub txt_csearch_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_csearch.Leave
        If txt_csearch.Text = "" Then
            txt_csearch.Text = "Search"
            Load_studentData2()
            lbl_csearch.Hide()
        End If
        txt_csearch.ForeColor = Color.DarkGray
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub manage_student_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is TabPage1 Then
            txt_vsearch.Text = "Search"
            lbl_csearch.Hide()
            lbl_vsearch.Hide()
            lblvotsearch.Hide()
            lbl_unvot.Hide()
            lbl_posvot_error.Hide()
            pnlInfo.Visible = False
            ComboBox1.Enabled = False
            lblcaninfoerror.Hide()
            Load_studentData()
        ElseIf TabControl1.SelectedTab Is TabPage2 Then
            txt_csearch.Text = "Search"
            lbl_csearch.Hide()
            lbl_vsearch.Hide()
            lblvotsearch.Hide()
            lbl_unvot.Hide()
            lbl_posvot_error.Hide()
            pnlInfo.Visible = False
            ComboBox1.Enabled = False
            lblcaninfoerror.Hide()
            Load_studentData2()
        ElseIf TabControl1.SelectedTab Is TabPage3 Then
            txt_votsearch.Text = "Search"
            lbl_csearch.Hide()
            lbl_vsearch.Hide()
            lblvotsearch.Hide()
            lbl_unvot.Hide()
            lbl_posvot_error.Hide()
            pnlInfo.Visible = False
            ComboBox1.Enabled = False
            lblcaninfoerror.Hide()
            Load_studentData3()
        ElseIf TabControl1.SelectedTab Is TabPage4 Then
            txt_unvotsearch.Text = "Search"
            lbl_csearch.Hide()
            lbl_vsearch.Hide()
            lblvotsearch.Hide()
            lbl_unvot.Hide()
            lbl_posvot_error.Hide()
            pnlInfo.Visible = False
            ComboBox1.Enabled = False
            lblcaninfoerror.Hide()
            Load_studentData4()
        ElseIf TabControl1.SelectedTab Is TabPage5 Then
            SearchTextBox.Text = "Search by Name or ID"
            ComboBox1.Text = "Student List"
            lbl_csearch.Hide()
            lbl_vsearch.Hide()
            lblvotsearch.Hide()
            lbl_unvot.Hide()
            lbl_posvot_error.Hide()
            ComboBox1.Enabled = False
            pnlInfo.Visible = False
            lblcaninfoerror.Hide()
        ElseIf TabControl1.SelectedTab Is TabPage6 Then
            txt_pos_nv.Text = "Search"
            cmb_pos_nv.Text = "Select Position"
            lbl_csearch.Hide()
            lbl_vsearch.Hide()
            lblvotsearch.Hide()
            lbl_unvot.Hide()
            lbl_posvot_error.Hide()
            ComboBox1.Enabled = False
            pnlInfo.Visible = False
            lblcaninfoerror.Hide()
        Else
            lbl_csearch.Hide()
            lbl_vsearch.Hide()
            lblvotsearch.Hide()
            lbl_unvot.Hide()
            lbl_posvot_error.Hide()
            pnlInfo.Visible = False
            lblcaninfoerror.Hide()
            txt_vsearch.Text = "Search"
            txt_csearch.Text = "Search"
            txt_votsearch.Text = "Search"
            txt_unvotsearch.Text = "Search"
            ComboBox1.Enabled = False
            SearchTextBox.Text = "Search by Name or ID"
            ComboBox1.Text = "Student List"
            cmb_pos_nv.Text = "Select Position"
            txt_pos_nv.Text = "Search"
        End If

    End Sub

    '-----------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------
    '------------------------------------------ VOTED SEARCH LIST  -----------------------------------------------
    '-----------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------
    Private Sub txt_votsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_votsearch.TextChanged
        DataGridView3.Rows.Clear()
        Try
            conn.Open()
            cmd = New SqlCommand("select * from voter where status = 'VOTED' and ( fname like '%" & txt_votsearch.Text & "%' or lname like '%" & txt_votsearch.Text & "%' or course like '%" & txt_votsearch.Text & "%' or year like '%" & txt_votsearch.Text & "%')", conn)
            'lbl_vsearch.Hide()
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                lblvotsearch.Hide()
                While dr.Read
                    DataGridView3.Rows.Add(DataGridView3.Rows.Count + 1, dr.Item("fname") + dr.Item("lname"), dr.Item("course"), dr.Item("year"))
                End While
            Else
                lblvotsearch.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()


        'Try
        '    Dim searchText As String = txt_votsearch.Text
        '    Dim query As String

        '    If searchColumn = -1 Then
        '        ' Search all columns
        '        query = "SELECT * FROM voter WHERE fname LIKE @search OR lname LIKE @search OR course LIKE @search"
        '    Else
        '        ' Search in the selected column
        '        query = "SELECT * FROM voter WHERE "
        '        If searchColumn = 0 Then
        '            query += "name LIKE @search"
        '        End If
        '    End If


        '    conn.Open()
        '    Using cmddd As New SqlCommand(query, conn)
        '        cmddd.Parameters.AddWithValue("@search", "%" & searchText & "%")
        '        Using adapter As New SqlDataAdapter(cmddd)
        '            Dim dataTable As New DataTable
        '            adapter.Fill(dataTable)
        '            DataGridView3.DataSource = dataTable
        '        End Using
        '    End Using
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'conn.Close()




    End Sub
    '-----------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------
    '------------------------------------------ VOTED SEARCH LIST  END -------------------------------------------
    '-----------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------

    Private Sub txt_votsearch_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_votsearch.Enter
        If txt_votsearch.Text = "Search" Then
            txt_votsearch.Text = ""
            lblvotsearch.Hide()
        End If
        txt_votsearch.ForeColor = Color.Black
    End Sub

    Private Sub txt_votsearch_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_votsearch.Leave
        If txt_votsearch.Text = "" Then
            txt_votsearch.Text = "Search"
            Load_studentData3()
            lblvotsearch.Hide()
        End If
        txt_votsearch.ForeColor = Color.DarkGray
    End Sub

    Private Sub txt_votsearch_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_votsearch.DoubleClick
        'If searchColumn = -1 Then
        '    searchColumn = 0 ' Search by name
        '    txt_votsearch.Text = "Search by Name"
        'ElseIf searchColumn = 0 Then
        '    searchColumn = -1 ' Reset to searching all columns
        '    txt_votsearch.Text = "Search All Columns"
        'End If
    End Sub

    Private Sub txt_unvotsearch_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_unvotsearch.Enter
        If txt_unvotsearch.Text = "Search" Then
            txt_unvotsearch.Text = ""
            lbl_unvot.Hide()
        End If
        If txt_unvotsearch.Text = "Search All Columns" Then
            txt_unvotsearch.Text = ""
            lbl_unvot.Hide()
        End If
        If txt_unvotsearch.Text = "Search by Name" Then
            txt_unvotsearch.Text = ""
            lbl_unvot.Hide()
        End If
        txt_unvotsearch.ForeColor = Color.Black
    End Sub

    Private Sub txt_unvotsearch_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_unvotsearch.Leave
        If txt_unvotsearch.Text = "" Then
            txt_unvotsearch.Text = "Search"
            Load_studentData4()
            lbl_unvot.Hide()
        End If

        txt_unvotsearch.ForeColor = Color.DarkGray
    End Sub

    Private Sub txt_unvotsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_unvotsearch.TextChanged
        'DataGridView4.Rows.Clear()
        'Try
        '    conn.Open()
        '    cmd = New SqlCommand("select * from voter where status = 'UN-VOTED' and ( fname like '%" & txt_unvotsearch.Text & "%' or lname like '%" & txt_unvotsearch.Text & "%' or course like '%" & txt_unvotsearch.Text & "%' or year like '%" & txt_unvotsearch.Text & "%')", conn)
        '    'lbl_vsearch.Hide()
        '    dr = cmd.ExecuteReader
        '    If dr.HasRows Then
        '        lbl_unvot.Hide()
        '        While dr.Read
        '            DataGridView4.Rows.Add(DataGridView4.Rows.Count + 1, dr.Item("fname") + dr.Item("lname"), dr.Item("course"), dr.Item("year"))
        '        End While
        '    Else
        '        lbl_unvot.Show()
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        'conn.Close()
        ApplyUnvotedSearch()
    End Sub


    Private Sub txt_unvotsearch_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_unvotsearch.DoubleClick
        unvotedSearchByAll = Not unvotedSearchByAll
        unvotedSearchColumn = If(unvotedSearchByAll, -1, 0)

        If unvotedSearchByAll Then
            txt_unvotsearch.Text = "Search All Columns"
            txt_unvotsearch.ForeColor = Color.DarkGray
        Else
            txt_unvotsearch.Text = "Search by Name"
            txt_unvotsearch.ForeColor = Color.DarkGray
        End If

        ApplyUnvotedSearch()
    End Sub

    Private Sub ApplyUnvotedSearch()
        DataGridView4.Rows.Clear()
        Try
            conn.Open()
            Dim query As String

            If unvotedSearchByAll Then
                query = "SELECT * FROM voter WHERE status = 'UN-VOTED' AND (fname LIKE @search OR lname LIKE @search OR course LIKE @search OR year LIKE @search)"
            Else
                query = "SELECT * FROM voter WHERE status = 'UN-VOTED' AND fname LIKE @search"
            End If

            cmd = New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@search", "%" & txt_unvotsearch.Text & "%")

            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                lbl_unvot.Hide()
                While dr.Read
                    DataGridView4.Rows.Add(DataGridView4.Rows.Count + 1, dr.Item("fname") & dr.Item("lname"), dr.Item("course"), dr.Item("year"))
                End While
            Else
                lbl_unvot.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub TabPage5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage5.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim searchQuery As String = SearchTextBox.Text.Trim()
        'Dim searchQuery As String = SearchTextBox.Text.Substring(10)
        If String.IsNullOrEmpty(searchQuery) Then

            ComboBox1.Enabled = False
            pnlInfo.Visible = False
            ComboBox1.ForeColor = Color.Silver
            Return
        End If

        Try

            conn.Open()

            Dim query As String = "SELECT stud_id, fname, lname FROM candidate WHERE stud_id = @searchQuery OR fname = @searchQuery OR lname = @searchQuery"

            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@searchQuery", searchQuery)

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    ComboBox1.Items.Clear()

                    While reader.Read()
                        ' Populate the ComboBox with the search results

                        Dim studentID As String = reader("stud_id").ToString()
                        Dim fname As String = reader("fname").ToString()
                        Dim lname As String = reader("lname").ToString()
                        ComboBox1.Items.Add(studentID + " - " + fname + " " + lname)
                    End While

                    If ComboBox1.Items.Count = 0 Then
                        lblcaninfoerror.Show()
                        pnlInfo.Visible = False
                        ComboBox1.Text = "Student List"
                        ComboBox1.Enabled = False
                        ComboBox1.ForeColor = Color.Silver
                    Else
                        lblcaninfoerror.Hide()
                        ComboBox1.Enabled = True
                        ComboBox1.ForeColor = Color.Black

                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub SearchTextBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchTextBox.Enter
        If SearchTextBox.Text = "Search by Name or ID" Then
            SearchTextBox.Text = ""
        End If
        SearchTextBox.ForeColor = Color.Black
    End Sub

    Private Sub SearchTextBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchTextBox.Leave
        If SearchTextBox.Text = "" Then
            SearchTextBox.Text = "Search by Name or ID"
        End If
        SearchTextBox.ForeColor = Color.DarkGray
    End Sub

    Private Sub ComboBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
        If ComboBox1.Text = "" Then
            ComboBox1.Text = "Student List"
            lblcaninfoerror.Hide()
        End If
        ComboBox1.ForeColor = Color.DarkGray
    End Sub

    Private Sub ComboBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.Enter
        If ComboBox1.Text = "Student List" Then
            ComboBox1.Text = ""
            lblcaninfoerror.Hide()
        End If
        ComboBox1.ForeColor = Color.Black
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back) Or e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            ComboBox1.ForeColor = Color.Black
        End If
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Retrieve the selected student's name from the ComboBox
        Dim selectedStudentName As String = ComboBox1.SelectedItem.ToString().Substring(0, 8)
        'Dim selectedStudentName As String = ComboBox1.SelectedItem.ToString()

        If Not String.IsNullOrEmpty(selectedStudentName) Then

            conn.Open()
            Dim query As String = "SELECT * FROM candidate WHERE stud_id = @SelectedName"
            Using command As New SqlCommand(query, conn)
                command.Parameters.AddWithValue("@SelectedName", selectedStudentName)
                Using reader As SqlDataReader = command.ExecuteReader()
                    If reader.HasRows AndAlso reader.Read() Then
                        ' Populate the PictureBox, Label controls with the student's information
                        lbl_name.Text = reader("fname").ToString() + " " + reader("lname").ToString()
                        lbl_course.Text = reader("course").ToString()
                        lbl_state.Text = reader("state").ToString()
                        lbl_pos.Text = reader("position").ToString()
                        lbl_id.Text = reader("stud_id").ToString()

                        ' Retrieve and display the image
                        Dim imageData As Byte() = DirectCast(reader("img"), Byte())
                        If imageData IsNot Nothing Then
                            Using ms As New MemoryStream(imageData)
                                CircularPictureBox1.Image = Image.FromStream(ms)
                            End Using
                        Else
                            CircularPictureBox1.Image = Nothing ' Clear the PictureBox if no image is available
                        End If

                        ' Make the panel containing student information visible
                        pnlInfo.Visible = True
                    Else
                        pnlInfo.Visible = False
                    End If
                End Using
            End Using
            conn.Close()
        End If
    End Sub

    Private Sub TabPage6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage6.Click

    End Sub

    Private Sub cmb_pos_nv_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_pos_nv.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Or e.KeyChar = Chr(Keys.Back) Or e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            ComboBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub cmb_pos_nv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_pos_nv.SelectedIndexChanged
        Dim selectedPosition As String = cmb_pos_nv.SelectedItem.ToString()
        Dim query As String = "SELECT stud_id, fname, lname, state, course FROM candidate WHERE position = @SelectedPosition"
        Try

            conn.Open()

            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@SelectedPosition", selectedPosition)
                dr = cmd.ExecuteReader()
                DataGridView5.Rows.Clear()
                While dr.Read
                    DataGridView5.Rows.Add(DataGridView5.Rows.Count + 1, dr.Item("stud_id"), dr.Item("fname") + dr.Item("lname"), dr.Item("state"), dr.Item("course"))
                End While
            End Using

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
        conn.Close()

    End Sub

    Private Sub txt_pos_nv_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pos_nv.Enter
        If txt_pos_nv.Text = "Search" Then
            txt_pos_nv.Text = ""
        End If
        txt_pos_nv.ForeColor = Color.Black
    End Sub

    Private Sub txt_pos_nv_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pos_nv.Leave
        If txt_pos_nv.Text = "" Then
            txt_pos_nv.Text = "Search"
        End If
        txt_pos_nv.ForeColor = Color.Silver
    End Sub

    Private Sub txt_pos_nv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pos_nv.TextChanged


        'DataGridView5.Rows.Clear()
        'Try
        '    conn.Open()
        '    cmd = New SqlCommand("select * from candidate where stud_id like '%" & txt_pos_nv.Text & "%' or fname like '%" & txt_pos_nv.Text & "%' or lname like '%" & txt_pos_nv.Text & "%' or course like '%" & txt_pos_nv.Text & "%' or state like '%" & txt_pos_nv.Text & "%'", conn)
        '    'lbl_vsearch.Hide()
        '    dr = cmd.ExecuteReader
        '    If dr.HasRows Then
        '        lbl_posvot_error.Hide()
        '        While dr.Read
        '            DataGridView5.Rows.Add(DataGridView5.Rows.Count + 1, dr.Item("stud_id"), dr.Item("fname") + dr.Item("lname"), dr.Item("state"), dr.Item("course"))
        '        End While
        '    Else
        '        lbl_posvot_error.Show()
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        'conn.Close()

    End Sub

    
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print.Click
        heading = "VOTER STUDENTS REPORT"
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================

        'Private Sub ExportToHTML()

        ' Specify the HTML file path
        Dim htmlFilePath As String = htmlPath + "\data.html"

        ' Create an HTML table and add data
        Dim htmlContent As New StringBuilder()
        htmlContent.AppendLine("<html><head></head><body style=' font-family: Tahoma;'>")
        htmlContent.AppendLine("<center><u><b><h1 style='font-size: 40px; font-family: Tahoma;'>" & heading & "</h1></b></u></center>")
        htmlContent.AppendLine("<br><br><br><br><center><table border='1' cellspacing='0'  width='80%'>")

        ' Add headers to the HTML table
        htmlContent.AppendLine("<tr>")
        For Each column As DataGridViewColumn In DataGridView1.Columns
            ' Create a table header cell for each column in the DataGridView
            htmlContent.AppendLine("<th height='50px' style='background-color: lightGray;'>" & column.HeaderText & "</th>")
        Next
        htmlContent.AppendLine("</tr>")

        ' Add data rows to the HTML table
        For Each row As DataGridViewRow In DataGridView1.Rows
            htmlContent.AppendLine("<tr>")
            For Each cell As DataGridViewCell In row.Cells
                ' Create a table data cell for each cell in the DataGridView
                htmlContent.AppendLine("<td height='35px'>" & cell.Value.ToString() & "</td>")
            Next
            htmlContent.AppendLine("</tr>")
        Next

        ' Close the HTML table and body
        htmlContent.AppendLine("</table></center>")
        htmlContent.AppendLine("</body></html>")

        ' Write the HTML data to the file
        File.WriteAllText(htmlFilePath, htmlContent.ToString())

        ' Convert the HTML to PDF (using wkhtmltopdf, as described in the next step)
        ' Specify the PDF file path
        Dim pdfFilePathh As String = pdfPath

        Dim pdfFileName As String = InputBox("Enter the PDF file name:", "PDF File Name", "")
        Dim pdfFilePath As String = Path.Combine(pdfFilePathh, pdfFileName + ".pdf")

        ' Create a ProcessStartInfo object to run wkhtmltopdf
        Dim psi As New ProcessStartInfo()

        ' Set the filename to the path of the wkhtmltopdf executable
        psi.FileName = "wkhtmltopdf.exe" ' Replace with the path to your wkhtmltopdf executable

        ' Specify the arguments for the wkhtmltopdf command
        ' The first argument is the input HTML file, and the second argument is the output PDF file
        psi.Arguments = """" & htmlFilePath & """ """ & pdfFilePath & """"

        ' Start the process to convert HTML to PDF
        Dim process As New Process()
        process.StartInfo = psi
        process.Start()
        process.WaitForExit()

        ' Notify the user that the PDF has been generated
        MessageBox.Show("PDF generated Successfully !", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If File.Exists(pdfFilePath) Then
            ' Start the default application for PDF files (e.g., Adobe Reader)
            process.Start(pdfFilePath)
        End If

        ' Provide the user with an option to download the PDF (code for download depends on your application context)
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        heading = "CANDIDANTS STUDENT REPORT"
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================

        'Private Sub ExportToHTML()

        ' Specify the HTML file path
        Dim htmlFilePath As String = htmlPath + "\data.html"

        ' Create an HTML table and add data
        Dim htmlContent As New StringBuilder()
        htmlContent.AppendLine("<html><head></head><body style=' font-family: Tahoma;'>")
        htmlContent.AppendLine("<center><u><b><h1 style='font-size: 40px; font-family: Tahoma;'>" & heading & "</h1></b></u></center>")
        htmlContent.AppendLine("<br><br><br><br><center><table border='1' cellspacing='0'  width='80%'>")

        ' Add headers to the HTML table
        htmlContent.AppendLine("<tr>")
        For Each column As DataGridViewColumn In DataGridView2.Columns
            ' Create a table header cell for each column in the DataGridView
            htmlContent.AppendLine("<th height='50px' style='background-color: lightGray;'>" & column.HeaderText & "</th>")
        Next
        htmlContent.AppendLine("</tr>")

        ' Add data rows to the HTML table
        For Each row As DataGridViewRow In DataGridView2.Rows
            htmlContent.AppendLine("<tr>")
            For Each cell As DataGridViewCell In row.Cells
                ' Create a table data cell for each cell in the DataGridView
                htmlContent.AppendLine("<td height='35px'>" & cell.Value.ToString() & "</td>")
            Next
            htmlContent.AppendLine("</tr>")
        Next

        ' Close the HTML table and body
        htmlContent.AppendLine("</table></center>")
        htmlContent.AppendLine("</body></html>")

        ' Write the HTML data to the file
        File.WriteAllText(htmlFilePath, htmlContent.ToString())

        ' Convert the HTML to PDF (using wkhtmltopdf, as described in the next step)
        ' Specify the PDF file path
        Dim pdfFilePathh As String = pdfPath

        Dim pdfFileName As String = InputBox("Enter the PDF file name:", "PDF File Name", "")
        Dim pdfFilePath As String = Path.Combine(pdfFilePathh, pdfFileName + ".pdf")

        ' Create a ProcessStartInfo object to run wkhtmltopdf
        Dim psi As New ProcessStartInfo()

        ' Set the filename to the path of the wkhtmltopdf executable
        psi.FileName = "wkhtmltopdf.exe" ' Replace with the path to your wkhtmltopdf executable

        ' Specify the arguments for the wkhtmltopdf command
        ' The first argument is the input HTML file, and the second argument is the output PDF file
        psi.Arguments = """" & htmlFilePath & """ """ & pdfFilePath & """"

        ' Start the process to convert HTML to PDF
        Dim process As New Process()
        process.StartInfo = psi
        process.Start()
        process.WaitForExit()

        ' Notify the user that the PDF has been generated
        MessageBox.Show("PDF generated Successfully !", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If File.Exists(pdfFilePath) Then
            ' Start the default application for PDF files (e.g., Adobe Reader)
            process.Start(pdfFilePath)
        End If

    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        heading = "STUDENTS WHO UNVOTED"
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================

        'Private Sub ExportToHTML()

        ' Specify the HTML file path
        Dim htmlFilePath As String = htmlPath + "\data.html"

        ' Create an HTML table and add data
        Dim htmlContent As New StringBuilder()
        htmlContent.AppendLine("<html><head></head><body style=' font-family: Tahoma;'>")
        htmlContent.AppendLine("<center><u><b><h1 style='font-size: 40px; font-family: Tahoma;'>" & heading & "</h1></b></u></center>")
        htmlContent.AppendLine("<br><br><br><br><center><table border='1' cellspacing='0'  width='80%'>")

        ' Add headers to the HTML table
        htmlContent.AppendLine("<tr>")
        For Each column As DataGridViewColumn In DataGridView4.Columns
            ' Create a table header cell for each column in the DataGridView
            htmlContent.AppendLine("<th height='50px' style='background-color: lightGray;'>" & column.HeaderText & "</th>")
        Next
        htmlContent.AppendLine("</tr>")

        ' Add data rows to the HTML table
        For Each row As DataGridViewRow In DataGridView4.Rows
            htmlContent.AppendLine("<tr>")
            For Each cell As DataGridViewCell In row.Cells
                ' Create a table data cell for each cell in the DataGridView
                htmlContent.AppendLine("<td height='35px'>" & cell.Value.ToString() & "</td>")
            Next
            htmlContent.AppendLine("</tr>")
        Next

        ' Close the HTML table and body
        htmlContent.AppendLine("</table></center>")
        htmlContent.AppendLine("</body></html>")

        ' Write the HTML data to the file
        File.WriteAllText(htmlFilePath, htmlContent.ToString())

        ' Convert the HTML to PDF (using wkhtmltopdf, as described in the next step)
        ' Specify the PDF file path
        Dim pdfFilePathh As String = pdfPath

        Dim pdfFileName As String = InputBox("Enter the PDF file name:", "PDF File Name", "")
        Dim pdfFilePath As String = Path.Combine(pdfFilePathh, pdfFileName + ".pdf")

        ' Create a ProcessStartInfo object to run wkhtmltopdf
        Dim psi As New ProcessStartInfo()

        ' Set the filename to the path of the wkhtmltopdf executable
        psi.FileName = "wkhtmltopdf.exe" ' Replace with the path to your wkhtmltopdf executable

        ' Specify the arguments for the wkhtmltopdf command
        ' The first argument is the input HTML file, and the second argument is the output PDF file
        psi.Arguments = """" & htmlFilePath & """ """ & pdfFilePath & """"

        ' Start the process to convert HTML to PDF
        Dim process As New Process()
        process.StartInfo = psi
        process.Start()
        process.WaitForExit()

        ' Notify the user that the PDF has been generated
        MessageBox.Show("PDF generated Successfully !", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If File.Exists(pdfFilePath) Then
            ' Start the default application for PDF files (e.g., Adobe Reader)
            process.Start(pdfFilePath)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        heading = cmb_pos_nv.Text + " CAST STUDENTS"
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================

        'Private Sub ExportToHTML()

        ' Specify the HTML file path
        Dim htmlFilePath As String = htmlPath + "\data.html"

        ' Create an HTML table and add data
        Dim htmlContent As New StringBuilder()
        htmlContent.AppendLine("<html><head></head><body style=' font-family: Tahoma;'>")
        htmlContent.AppendLine("<center><u><b><h1 style='font-size: 40px; font-family: Tahoma;'>" & heading & "</h1></b></u></center>")
        htmlContent.AppendLine("<br><br><br><br><center><table border='1' cellspacing='0'  width='80%'>")

        ' Add headers to the HTML table
        htmlContent.AppendLine("<tr>")
        For Each column As DataGridViewColumn In DataGridView5.Columns
            ' Create a table header cell for each column in the DataGridView
            htmlContent.AppendLine("<th height='50px' style='background-color: lightGray;'>" & column.HeaderText & "</th>")
        Next
        htmlContent.AppendLine("</tr>")

        ' Add data rows to the HTML table
        For Each row As DataGridViewRow In DataGridView5.Rows
            htmlContent.AppendLine("<tr>")
            For Each cell As DataGridViewCell In row.Cells
                ' Create a table data cell for each cell in the DataGridView
                htmlContent.AppendLine("<td height='35px'>" & cell.Value.ToString() & "</td>")
            Next
            htmlContent.AppendLine("</tr>")
        Next

        ' Close the HTML table and body
        htmlContent.AppendLine("</table></center>")
        htmlContent.AppendLine("</body></html>")

        ' Write the HTML data to the file
        File.WriteAllText(htmlFilePath, htmlContent.ToString())

        ' Convert the HTML to PDF (using wkhtmltopdf, as described in the next step)
        ' Specify the PDF file path
        Dim pdfFilePathh As String = pdfPath

        Dim pdfFileName As String = InputBox("Enter the PDF file name:", "PDF File Name", "")
        Dim pdfFilePath As String = Path.Combine(pdfFilePathh, pdfFileName + ".pdf")

        ' Create a ProcessStartInfo object to run wkhtmltopdf
        Dim psi As New ProcessStartInfo()

        ' Set the filename to the path of the wkhtmltopdf executable
        psi.FileName = "wkhtmltopdf.exe" ' Replace with the path to your wkhtmltopdf executable

        ' Specify the arguments for the wkhtmltopdf command
        ' The first argument is the input HTML file, and the second argument is the output PDF file
        psi.Arguments = """" & htmlFilePath & """ """ & pdfFilePath & """"

        ' Start the process to convert HTML to PDF
        Dim process As New Process()
        process.StartInfo = psi
        process.Start()
        process.WaitForExit()

        ' Notify the user that the PDF has been generated
        MessageBox.Show("PDF generated Successfully !", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If File.Exists(pdfFilePath) Then
            ' Start the default application for PDF files (e.g., Adobe Reader)
            process.Start(pdfFilePath)
        End If
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim pdfFilePathh As String = pdfPath

        Dim pdfFileName As String = InputBox("Enter the PDF file name:", "PDF File Name", "")
        Dim pdfFilePath As String = Path.Combine(pdfFilePathh, pdfFileName + ".pdf")

        ' Capture the content of the Panel and PictureBox as HTML
        Dim panelHtmlContent As String = CapturePanelAsHtml(pnlInfo)

        ' Combine the HTML content of Panel and PictureBox
        Dim combinedHtmlContent As String = panelHtmlContent

        ' Convert the HTML to PDF using wkhtmltopdf
        ConvertHTMLToPDF(combinedHtmlContent, pdfFilePath)

        ' Notify the user that the PDF has been generated
        MessageBox.Show("PDF generated successfully")

        ' Open the generated PDF using the default PDF viewer (optional)
        Process.Start(pdfFilePath)
    End Sub

    Private Function CapturePanelAsHtml(ByVal panel As Panel) As String
        ' Create a Bitmap to capture the content of the Panel
        Using bmp As New Bitmap(panel.Width, panel.Height)
            panel.DrawToBitmap(bmp, New Rectangle(0, 0, panel.Width, panel.Height))

            ' Save the captured content as an image (PNG format)
            Dim imageFileName As String = "panel_capture.jpeg"
            bmp.Save(imageFileName, Imaging.ImageFormat.Jpeg)

            ' Convert the image to HTML
            Return "<img src=""" & imageFileName & """ />"
        End Using
    End Function

    Private Function CapturePictureBoxAsHtml(ByVal pictureBox As CircularPictureBox) As String
        ' Capture the PictureBox image as HTML
        Try
            Dim imageFileName As String = "picturebox_capture.jpeg"

            ' Clone the image to ensure it's not locked by the PictureBox
            Dim clonedImage As Image = pictureBox.Image.Clone()

            ' Save the cloned image as JPEG
            clonedImage.Save(imageFileName, Imaging.ImageFormat.Jpeg)

            ' Dispose of the cloned image to release resources
            clonedImage.Dispose()

            ' Convert the image to HTML
            Return "<img src=""" & imageFileName & """ />"
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
            Return String.Empty
        End Try



    End Function

    Private Sub ConvertHtmlToPdf(ByVal htmlContent As String, ByVal pdfFilePath As String)
        ' Execute wkhtmltopdf to convert HTML to PDF
        Dim psi As New ProcessStartInfo()
        psi.FileName = "wkhtmltopdf.exe" ' Path to wkhtmltopdf executable
        psi.Arguments = "--page-size A4 - " & pdfFilePath ' Specify page size and input/output

        psi.UseShellExecute = False
        psi.CreateNoWindow = True
        psi.RedirectStandardInput = True

        Dim process As New Process()
        process.StartInfo = psi
        process.Start()

        ' Write the HTML content to the input stream
        Dim sw As StreamWriter = process.StandardInput
        sw.Write(htmlContent)
        sw.Close()

        ' Wait for the conversion to complete
        process.WaitForExit()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        heading = "STUDENTS WHO VOTED"
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================
        '============================================================================================================================================

        'Private Sub ExportToHTML()

        ' Specify the HTML file path
        Dim htmlFilePath As String = htmlPath + "\data.html"

        ' Create an HTML table and add data
        Dim htmlContent As New StringBuilder()
        htmlContent.AppendLine("<html><head></head><body style=' font-family: Tahoma;'>")
        htmlContent.AppendLine("<center><u><b><h1 style='font-size: 40px; font-family: Tahoma;'>" & heading & "</h1></b></u></center>")
        htmlContent.AppendLine("<br><br><br><br><center><table border='1' cellspacing='0'  width='80%'>")

        ' Add headers to the HTML table
        htmlContent.AppendLine("<tr>")
        For Each column As DataGridViewColumn In DataGridView3.Columns
            ' Create a table header cell for each column in the DataGridView
            htmlContent.AppendLine("<th height='50px' style='background-color: lightGray;'>" & column.HeaderText & "</th>")
        Next
        htmlContent.AppendLine("</tr>")

        ' Add data rows to the HTML table
        For Each row As DataGridViewRow In DataGridView3.Rows
            htmlContent.AppendLine("<tr>")
            For Each cell As DataGridViewCell In row.Cells
                ' Create a table data cell for each cell in the DataGridView
                htmlContent.AppendLine("<td height='35px'>" & cell.Value.ToString() & "</td>")
            Next
            htmlContent.AppendLine("</tr>")
        Next

        ' Close the HTML table and body
        htmlContent.AppendLine("</table></center>")
        htmlContent.AppendLine("</body></html>")

        ' Write the HTML data to the file
        File.WriteAllText(htmlFilePath, htmlContent.ToString())

        ' Convert the HTML to PDF (using wkhtmltopdf, as described in the next step)
        ' Specify the PDF file path
        Dim pdfFilePathh As String = pdfPath

        Dim pdfFileName As String = InputBox("Enter the PDF file name:", "PDF File Name", "")
        Dim pdfFilePath As String = Path.Combine(pdfFilePathh, pdfFileName + ".pdf")

        ' Create a ProcessStartInfo object to run wkhtmltopdf
        Dim psi As New ProcessStartInfo()

        ' Set the filename to the path of the wkhtmltopdf executable
        psi.FileName = "wkhtmltopdf.exe" ' Replace with the path to your wkhtmltopdf executable

        ' Specify the arguments for the wkhtmltopdf command
        ' The first argument is the input HTML file, and the second argument is the output PDF file
        psi.Arguments = """" & htmlFilePath & """ """ & pdfFilePath & """"

        ' Start the process to convert HTML to PDF
        Dim process As New Process()
        process.StartInfo = psi
        process.Start()
        process.WaitForExit()

        ' Notify the user that the PDF has been generated
        MessageBox.Show("PDF generated Successfully !", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If File.Exists(pdfFilePath) Then
            ' Start the default application for PDF files (e.g., Adobe Reader)
            process.Start(pdfFilePath)
        End If
    End Sub

    Private Sub ComboBox1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.MouseHover
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub ComboBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.MouseLeave
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDown
    End Sub
End Class