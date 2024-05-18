<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_candidate
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_candidate))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_fname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_course = New System.Windows.Forms.ComboBox()
        Me.cmb_state = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_pos = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txt_lname = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_stud_id = New System.Windows.Forms.TextBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.upload_candi_image = New project.CircularPictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.upload_candi_image, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(1318, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 52)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "X"
        '
        'txt_fname
        '
        Me.txt_fname.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_fname.ForeColor = System.Drawing.Color.Silver
        Me.txt_fname.Location = New System.Drawing.Point(669, 244)
        Me.txt_fname.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_fname.Multiline = True
        Me.txt_fname.Name = "txt_fname"
        Me.txt_fname.Size = New System.Drawing.Size(221, 38)
        Me.txt_fname.TabIndex = 3
        Me.txt_fname.Tag = ""
        Me.txt_fname.Text = "First Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Yu Gothic Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(671, 323)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 21)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Course  : "
        '
        'cmb_course
        '
        Me.cmb_course.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_course.ForeColor = System.Drawing.Color.Silver
        Me.cmb_course.FormattingEnabled = True
        Me.cmb_course.ItemHeight = 25
        Me.cmb_course.Items.AddRange(New Object() {"BBA", "ITM", "BCA", "BCOM"})
        Me.cmb_course.Location = New System.Drawing.Point(809, 323)
        Me.cmb_course.Margin = New System.Windows.Forms.Padding(2)
        Me.cmb_course.Name = "cmb_course"
        Me.cmb_course.Size = New System.Drawing.Size(291, 33)
        Me.cmb_course.TabIndex = 5
        Me.cmb_course.Text = "Select Course"
        '
        'cmb_state
        '
        Me.cmb_state.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_state.ForeColor = System.Drawing.Color.Silver
        Me.cmb_state.FormattingEnabled = True
        Me.cmb_state.ItemHeight = 25
        Me.cmb_state.Items.AddRange(New Object() {"BIHAR", "GOA", "MAHARASHTRA", "KARNATAKA", "ANDHRA PRADESH", "CHHATTISGARH", "HARYANA", "HIMACHAL PRADESH", "GUJARAT", "PUNJAB", "ASSAM", "MANIPUR", "ARUNACHAL PRADESH", "MIZORAM", "KERALA", "WEST BENGAL", "TRIPURA", "JHARKHAND", "MADHYA PRADESH", "TAMIL NADU", "RAJASTHAN", "ODISHA", "NAGALAND", "SIKKIM", "UTTAR PRADESH", "MEGHALAYA", "TELANGANA", "UTTRAKHAND", "DELHI", "JAMMU & KASHMIR"})
        Me.cmb_state.Location = New System.Drawing.Point(806, 407)
        Me.cmb_state.Margin = New System.Windows.Forms.Padding(2)
        Me.cmb_state.Name = "cmb_state"
        Me.cmb_state.Size = New System.Drawing.Size(291, 33)
        Me.cmb_state.TabIndex = 6
        Me.cmb_state.Text = "Select State"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Yu Gothic Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(680, 407)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 21)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "State  : "
        '
        'cmb_pos
        '
        Me.cmb_pos.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_pos.ForeColor = System.Drawing.Color.Silver
        Me.cmb_pos.FormattingEnabled = True
        Me.cmb_pos.ItemHeight = 25
        Me.cmb_pos.Items.AddRange(New Object() {"President", "Vice - President", "Secretary", "General Secretary"})
        Me.cmb_pos.Location = New System.Drawing.Point(806, 491)
        Me.cmb_pos.Margin = New System.Windows.Forms.Padding(2)
        Me.cmb_pos.Name = "cmb_pos"
        Me.cmb_pos.Size = New System.Drawing.Size(291, 33)
        Me.cmb_pos.TabIndex = 7
        Me.cmb_pos.Text = "Select Position"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Yu Gothic Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(680, 491)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 21)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Position  : "
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Olive
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Consolas", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(683, 583)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(414, 70)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Register"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txt_lname
        '
        Me.txt_lname.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_lname.ForeColor = System.Drawing.Color.Silver
        Me.txt_lname.Location = New System.Drawing.Point(904, 244)
        Me.txt_lname.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_lname.Multiline = True
        Me.txt_lname.Name = "txt_lname"
        Me.txt_lname.Size = New System.Drawing.Size(221, 38)
        Me.txt_lname.TabIndex = 4
        Me.txt_lname.Tag = ""
        Me.txt_lname.Text = "Last Name"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Britannic Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(254, 644)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(283, 32)
        Me.Label7.TabIndex = 14
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.project.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(9, 10)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(135, 128)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic Medium", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(680, 170)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 21)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Student ID  : "
        '
        'txt_stud_id
        '
        Me.txt_stud_id.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_stud_id.ForeColor = System.Drawing.Color.Black
        Me.txt_stud_id.Location = New System.Drawing.Point(809, 163)
        Me.txt_stud_id.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_stud_id.Multiline = True
        Me.txt_stud_id.Name = "txt_stud_id"
        Me.txt_stud_id.Size = New System.Drawing.Size(291, 38)
        Me.txt_stud_id.TabIndex = 2
        Me.txt_stud_id.Tag = ""
        Me.txt_stud_id.Text = "202122"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = Global.project.My.Resources.Resources.setting1
        Me.PictureBox3.Location = New System.Drawing.Point(1293, 709)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(75, 77)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 33
        Me.PictureBox3.TabStop = False
        '
        'upload_candi_image
        '
        Me.upload_candi_image.BackColor = System.Drawing.Color.LightGray
        Me.upload_candi_image.Cursor = System.Windows.Forms.Cursors.Hand
        Me.upload_candi_image.Image = Global.project.My.Resources.Resources.upload_photo1
        Me.upload_candi_image.Location = New System.Drawing.Point(229, 214)
        Me.upload_candi_image.Margin = New System.Windows.Forms.Padding(2)
        Me.upload_candi_image.Name = "upload_candi_image"
        Me.upload_candi_image.Size = New System.Drawing.Size(331, 352)
        Me.upload_candi_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.upload_candi_image.TabIndex = 13
        Me.upload_candi_image.TabStop = False
        '
        'frm_candidate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1379, 797)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.txt_stud_id)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.upload_candi_image)
        Me.Controls.Add(Me.txt_lname)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmb_pos)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmb_state)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmb_course)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_fname)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frm_candidate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.upload_candi_image, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_fname As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_course As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_state As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmb_pos As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt_lname As System.Windows.Forms.TextBox
    Friend WithEvents upload_candi_image As project.CircularPictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_stud_id As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
