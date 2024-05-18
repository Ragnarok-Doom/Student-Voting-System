Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Diagnostics
Imports System.Text
Imports System.Drawing

Public Class frm_result
    Dim htmlPath As String = "D:\new_project_SEM5\html"
    Dim pdfPath As String = "D:\new_project_SEM5\pdf"
    Dim heading As String = ""
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.Close()
        
    End Sub
    Private Sub Load_result()
        Try
            conn.Open()
            cmd = New SqlCommand("SELECT name AS NAME, position AS POSITION, COUNT(*) AS VOTE FROM voting GROUP BY name, position HAVING COUNT(*) >= 1 ORDER BY VOTE DESC, POSITION", conn)
            dt = New DataTable
            da = New SqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(dt)
            DataGridView1.DataSource = dt

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()



        If DataGridView1.Rows.Count > 1 Then
            Try
                Dim presidentName As String = ""
                Dim vicepresidentName As String = ""
                Dim secretary As String = ""
                Dim gsName As String = ""

                Dim presidentCount As Integer = 0
                Dim gsCount As Integer = 0
                Dim vicePresidentCount As Integer = 0
                Dim secretarycount As Integer = 0

                For i As Integer = 0 To 7
                    Dim position As String = DataGridView1.Rows(i).Cells("POSITION").Value.ToString()
                    Dim name As String = DataGridView1.Rows(i).Cells("NAME").Value.ToString()
                    Dim vote As String = DataGridView1.Rows(i).Cells("VOTE").Value.ToString()

                    If position = "President" AndAlso presidentCount = 0 Then
                        presidentName = name
                        presidentCount += 1
                        txtp.Text = vote
                        DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LawnGreen
                    End If
                    If position = "Vice - President" AndAlso vicePresidentCount = 0 Then
                        vicepresidentName = name
                        vicePresidentCount += 1
                        txtvp.Text = vote
                        DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    End If
                    If position = "Secretary" AndAlso secretarycount = 0 Then
                        secretary = name
                        secretarycount += 1
                        txts.Text = vote
                        DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue
                    End If
                    If position = "General Secretary" AndAlso gsCount = 0 Then
                        gsName = name
                        gsCount += 1
                        txtg.Text = vote
                        DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
                    End If

                    If presidentCount > 0 And gsCount > 0 And vicePresidentCount > 0 And secretarycount > 0 Then
                        Exit For
                    End If

                Next

                

                ' Display the names in the textboxes
                txt_president.Text = presidentName
                txt_vpresident.Text = vicepresidentName
                txt_secretary.Text = secretary
                txt_gs.Text = gsName
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("No  Record  Available")
        End If



    End Sub

    Private Sub frm_result_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_result()
        DataGridView1.CurrentCell = Nothing
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
            ' Create a new font with the desired style
            Dim newFont As New Font("NewsGoth Lt BT", 12) ' Change the font family, size, and style as needed
            e.CellStyle.Font = newFont
        End If
    End Sub

    Private Sub btn_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print.Click
        ' Specify the HTML file path
        Dim htmlFilePath As String = htmlPath + "\report.html"

        ' Create an HTML table and add data
        Dim htmlContent As New StringBuilder()
        htmlContent.AppendLine("<html><head></head><body style=' font-family: Tahoma;'>")
        htmlContent.AppendLine("<center><u><b><h1 style='font-size: 40px; font-family: Tahoma;'>FINAL REPORT</h1></b></u></center>")
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
                htmlContent.AppendLine("<td height='35px' align='center'>" & cell.Value.ToString() & "</td>")
            Next
            htmlContent.AppendLine("</tr>")
        Next

        ' Close the HTML table and body
        htmlContent.AppendLine("</table></center><br><br>")
        htmlContent.AppendLine("<b><h3> Winners are - </h3></b>")
        htmlContent.AppendLine("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font style='font-size: 20px; color: blue;'> President :  " & txt_president.Text & "</font><br><br>")
        htmlContent.AppendLine("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font style='font-size: 20px; color: red;'> Vice - President :  " & txt_vpresident.Text & "</font><br><br>")
        htmlContent.AppendLine("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font style='font-size: 20px; color: green;'> Secretary :  " & txt_secretary.Text & "</font><br><br>")
        htmlContent.AppendLine("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font style='font-size: 20px; color: darkYellow;'> General - Secretary :  " & txt_gs.Text & "</font><br><br><br><br>")
        htmlContent.AppendLine("<h3 align='right'>Signature ,</h3>")
        htmlContent.AppendLine("</body></html>")

        ' Write the HTML data to the file
        File.WriteAllText(htmlFilePath, htmlContent.ToString())

        ' Convert the HTML to PDF (using wkhtmltopdf, as described in the next step)
        ConvertHTMLToPDF(htmlFilePath)
    End Sub

    Private Sub ConvertHTMLToPDF(ByVal htmlFilePath As String)
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
End Class



'SELECT name AS Name, MAX(CASE WHEN position = 'President' THEN 'President' END) AS Position, SUM(CASE WHEN position = 'President' THEN 1 ELSE 0 END) AS PresidentVotes, SUM(CASE WHEN position = 'Vice - President' THEN 1 ELSE 0 END) AS VicePresidentVotes, SUM(CASE WHEN position = 'Secretary' THEN 1 ELSE 0 END) AS SecretaryVotes, SUM(CASE WHEN position = 'GS' THEN 1 ELSE 0 END) AS GSVotes FROM voting GROUP BY name
'SELECT name AS NAME, position AS POSITION, COUNT(*) AS VOTE FROM voting GROUP BY name, position HAVING COUNT(*) >= 1 ORDER BY position
'SELECT name AS StudentName, SUM(CASE WHEN position = 'President' THEN 1 ELSE 0 END) AS PresidentCount, SUM(CASE WHEN position = 'Vice-President' THEN 1 ELSE 0 END) AS VicePresidentCount, SUM(CASE WHEN position = 'Secretary' THEN 1 ELSE 0 END) AS SecretaryCount, SUM(CASE WHEN position = 'GS' THEN 1 ELSE 0 END) AS GSCount FROM voting GROUP BY name, position