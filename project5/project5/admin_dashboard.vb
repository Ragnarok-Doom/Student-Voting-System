Public Class admin_dashboard
    Public p As Panel = Panel3

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_head.Click

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lbl_time.Text = Date.Now.ToString("hh:mm:ss tt")
        lbl_date.Text = Date.Now.ToString("dddd, yyyy-MM-dd")
    End Sub

    Private Sub dashboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()

        Dim screen As Screen = screen.PrimaryScreen
        Dim screeWidth As Integer = screen.Bounds.Width
        Dim screeHeight As Integer = screen.Bounds.Height
        Me.Size = New Size(1600, 900)

    End Sub

    Private Sub timer_lbl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_time.Click

    End Sub

    Private Sub btn_vot_frm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_vot_frm.Click
        With frm_voter
            .TopLevel = False
            Panel3.Controls.Add(frm_voter)
            .BringToFront()
            .Show()
        End With





    End Sub

    Private Sub btn_logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_logout.Click
        Me.Hide()
        admin_login.Show()
    End Sub

    Private Sub btn_mng_cand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mng_cand.Click
        With frm_candidate
            .TopLevel = False
            Panel3.Controls.Add(frm_candidate)
            .BringToFront()
            .Show()

        End With
    End Sub

    Private Sub btn_mng_stud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mng_stud.Click
        With manage_student
            .TopLevel = False
            Panel3.Controls.Add(manage_student)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub btn_res_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_res.Click
        With frm_result
            .TopLevel = True
            'Panel3.Controls.Add(frm_result)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        Me.Hide()
        admin_setting.Show()
    End Sub
End Class
