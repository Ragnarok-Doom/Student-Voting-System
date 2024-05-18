Public Class mesgBox

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        student_dashboard.Enabled = True
        Me.Close()

    End Sub

    Private Sub mesgBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        student_dashboard.Enabled = False
        Button1.Enabled = CheckBox1.Checked

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Button1.Enabled = CheckBox1.Checked
    End Sub

    Private Sub mesgBox_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub
End Class