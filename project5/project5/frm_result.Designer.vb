<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_result
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txt_president = New System.Windows.Forms.TextBox()
        Me.txt_vpresident = New System.Windows.Forms.TextBox()
        Me.txt_secretary = New System.Windows.Forms.TextBox()
        Me.txt_gs = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtp = New System.Windows.Forms.TextBox()
        Me.txtvp = New System.Windows.Forms.TextBox()
        Me.txts = New System.Windows.Forms.TextBox()
        Me.txtg = New System.Windows.Forms.TextBox()
        Me.btn_print = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(1318, 9)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 52)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "X"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Azure
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Historic", 27.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Teal
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 50)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "RESULT"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeight = 60
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.DataGridView1.Location = New System.Drawing.Point(64, 103)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft YaHei", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.RowTemplate.Height = 35
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.ShowCellErrors = False
        Me.DataGridView1.ShowCellToolTips = False
        Me.DataGridView1.ShowEditingIcon = False
        Me.DataGridView1.ShowRowErrors = False
        Me.DataGridView1.Size = New System.Drawing.Size(1165, 294)
        Me.DataGridView1.TabIndex = 55
        '
        'txt_president
        '
        Me.txt_president.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_president.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_president.Location = New System.Drawing.Point(79, 551)
        Me.txt_president.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_president.Multiline = True
        Me.txt_president.Name = "txt_president"
        Me.txt_president.ReadOnly = True
        Me.txt_president.Size = New System.Drawing.Size(223, 34)
        Me.txt_president.TabIndex = 56
        '
        'txt_vpresident
        '
        Me.txt_vpresident.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_vpresident.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_vpresident.Location = New System.Drawing.Point(367, 551)
        Me.txt_vpresident.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_vpresident.Multiline = True
        Me.txt_vpresident.Name = "txt_vpresident"
        Me.txt_vpresident.ReadOnly = True
        Me.txt_vpresident.Size = New System.Drawing.Size(223, 34)
        Me.txt_vpresident.TabIndex = 57
        '
        'txt_secretary
        '
        Me.txt_secretary.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_secretary.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_secretary.Location = New System.Drawing.Point(666, 551)
        Me.txt_secretary.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_secretary.Multiline = True
        Me.txt_secretary.Name = "txt_secretary"
        Me.txt_secretary.ReadOnly = True
        Me.txt_secretary.Size = New System.Drawing.Size(223, 34)
        Me.txt_secretary.TabIndex = 58
        '
        'txt_gs
        '
        Me.txt_gs.BackColor = System.Drawing.Color.GhostWhite
        Me.txt_gs.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_gs.Location = New System.Drawing.Point(974, 551)
        Me.txt_gs.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_gs.Multiline = True
        Me.txt_gs.Name = "txt_gs"
        Me.txt_gs.ReadOnly = True
        Me.txt_gs.Size = New System.Drawing.Size(223, 34)
        Me.txt_gs.TabIndex = 59
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(75, 488)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 23)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "President"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(363, 488)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 23)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Vice - President"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(662, 488)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 23)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "Secretary"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Green
        Me.Label6.Location = New System.Drawing.Point(970, 488)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(181, 23)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "General Secretary"
        '
        'txtp
        '
        Me.txtp.BackColor = System.Drawing.Color.White
        Me.txtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtp.ForeColor = System.Drawing.Color.Red
        Me.txtp.Location = New System.Drawing.Point(271, 488)
        Me.txtp.Margin = New System.Windows.Forms.Padding(2)
        Me.txtp.Name = "txtp"
        Me.txtp.ReadOnly = True
        Me.txtp.Size = New System.Drawing.Size(31, 26)
        Me.txtp.TabIndex = 64
        Me.txtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtvp
        '
        Me.txtvp.BackColor = System.Drawing.Color.White
        Me.txtvp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvp.ForeColor = System.Drawing.Color.Red
        Me.txtvp.Location = New System.Drawing.Point(559, 488)
        Me.txtvp.Margin = New System.Windows.Forms.Padding(2)
        Me.txtvp.Name = "txtvp"
        Me.txtvp.ReadOnly = True
        Me.txtvp.Size = New System.Drawing.Size(31, 26)
        Me.txtvp.TabIndex = 65
        Me.txtvp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txts
        '
        Me.txts.BackColor = System.Drawing.Color.White
        Me.txts.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txts.ForeColor = System.Drawing.Color.Red
        Me.txts.Location = New System.Drawing.Point(858, 488)
        Me.txts.Margin = New System.Windows.Forms.Padding(2)
        Me.txts.Name = "txts"
        Me.txts.ReadOnly = True
        Me.txts.Size = New System.Drawing.Size(31, 26)
        Me.txts.TabIndex = 66
        Me.txts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtg
        '
        Me.txtg.BackColor = System.Drawing.Color.White
        Me.txtg.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtg.ForeColor = System.Drawing.Color.Red
        Me.txtg.Location = New System.Drawing.Point(1166, 488)
        Me.txtg.Margin = New System.Windows.Forms.Padding(2)
        Me.txtg.Name = "txtg"
        Me.txtg.ReadOnly = True
        Me.txtg.Size = New System.Drawing.Size(31, 26)
        Me.txtg.TabIndex = 67
        Me.txtg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_print
        '
        Me.btn_print.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_print.Location = New System.Drawing.Point(1186, 712)
        Me.btn_print.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(182, 74)
        Me.btn_print.TabIndex = 68
        Me.btn_print.Text = "Print Report"
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'frm_result
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MintCream
        Me.ClientSize = New System.Drawing.Size(1379, 797)
        Me.Controls.Add(Me.btn_print)
        Me.Controls.Add(Me.txtg)
        Me.Controls.Add(Me.txts)
        Me.Controls.Add(Me.txtvp)
        Me.Controls.Add(Me.txtp)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_gs)
        Me.Controls.Add(Me.txt_secretary)
        Me.Controls.Add(Me.txt_vpresident)
        Me.Controls.Add(Me.txt_president)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(221, 103)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frm_result"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frm_result"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txt_president As System.Windows.Forms.TextBox
    Friend WithEvents txt_vpresident As System.Windows.Forms.TextBox
    Friend WithEvents txt_secretary As System.Windows.Forms.TextBox
    Friend WithEvents txt_gs As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtp As System.Windows.Forms.TextBox
    Friend WithEvents txtvp As System.Windows.Forms.TextBox
    Friend WithEvents txts As System.Windows.Forms.TextBox
    Friend WithEvents txtg As System.Windows.Forms.TextBox
    Friend WithEvents btn_print As System.Windows.Forms.Button
End Class
