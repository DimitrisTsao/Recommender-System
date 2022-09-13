Imports System.IO
Imports System.Reflection.Emit
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class Form1

    Dim usrFolder As String
    Dim sourceFile As String
    Dim destinationFile As String
    Dim usrFileName As String


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""

        usrFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
        Label1.Text = usrFolder
    End Sub
    Sub CopyUserFile(srce As String, dstn As String)

        My.Computer.FileSystem.CopyFile(srce, dstn, overwrite:=True)
        Timer1.Enabled = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        '  Dim strFileName As String

        fd.Title = "Επιλογή αρχείου"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.csv)|*.csv"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            sourceFile = fd.FileName
            Label2.Text = sourceFile
            GenerateDestinationPath()
            CopyUserFile(sourceFile, destinationFile)

        End If

    End Sub

    Sub GenerateDestinationPath()
        usrFileName = Path.GetFileName(sourceFile)
        destinationFile = usrFolder + "\" + usrFileName
        Label3.Text = destinationFile
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Process.Start("explorer.exe", String.Format("/n, /e, {0}", usrFolder))
        Catch ex As Exception
            MsgBox("Αδυναμία ανοιγματος φακέλου. Σφάλμα " & Err.GetHashCode)
        End Try


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If File.Exists(destinationFile) Then
            Label3.ForeColor = Color.Green
        Else
            Label3.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        'Process.Start("http://localhost:8888/notebooks/CP%202nd%20Unsupervised%20Recommender%20System-Copy1.ipynb")
        Process.Start("C:\Program Files (x86)\Internet Explorer\iexplore.exe", "http://localhost:8805/lab")


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class