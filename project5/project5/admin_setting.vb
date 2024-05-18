Imports System.Data.SqlClient
Imports System.IO

Public Class admin_setting

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            conn.Open()
            If txt_chpass.Text = String.Empty Or txt_user.Text = String.Empty Or txt_kpass.Text = String.Empty Then
                MsgBox("Please Fill Details !", MessageBoxIcon.Warning, MessageBoxButtons.OK)
            Else
                If txt_user.Text = "admin" Then
                    If txt_kpass.Text = txt_chpass.Text Then
                        Dim q As String = "update admin set password=@d2 where username=@d1"
                        Dim cmd As SqlCommand = New SqlCommand(q, conn)
                        cmd.Parameters.AddWithValue("@d1", txt_user.Text)
                        cmd.Parameters.AddWithValue("@d2", txt_chpass.Text)
                        cmd.ExecuteNonQuery()
                        MsgBox("Your password is Changed !", MessageBoxButtons.OK, vbInformation)
                        Me.Close()
                        admin_dashboard.Show()
                    Else
                        MsgBox("You write wrong Password !", MessageBoxIcon.Warning, MessageBoxButtons.OK)
                    End If
                Else
                    MsgBox("Username must be wrong !", MessageBoxIcon.Warning, MessageBoxButtons.OK)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Me.Close()
        admin_dashboard.Show()
    End Sub

    Private Sub admin_setting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class