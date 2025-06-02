Imports System.Data.SQLite
Imports System.Runtime.InteropServices


Public Class LoginForm

    ' Deklarasi konstanta untuk Windows API
    Private Const GWL_STYLE As Integer = -16
    Private Const WS_SYSMENU As Integer = &H80000
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTCAPTION As Integer = 2
    Private Const SC_CLOSE As Integer = &HF060
    Private Const MF_GRAYED As Integer = &H1
    Private Const MF_BYCOMMAND As Integer = &H0

    ' Deklarasi fungsi Windows API
    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Shared Function GetSystemMenu(ByVal hWnd As IntPtr, ByVal bRevert As Boolean) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Shared Function EnableMenuItem(ByVal hMenu As IntPtr, ByVal uIDEnableItem As Integer, ByVal uEnable As Integer) As Boolean
    End Function

    Private Sub YourForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Atur properti dasar form
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = True

        ' Dapatkan handle form
        Dim hWnd As IntPtr = Me.Handle

        ' 1. Nonaktifkan tombol Close melalui System Menu
        Dim hMenu As IntPtr = GetSystemMenu(hWnd, False)
        EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND Or MF_GRAYED)

        ' 2. Blokir pergerakan form
        Me.DoubleBuffered = True
    End Sub

    ' Blokir drag form melalui title bar
    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_NCLBUTTONDOWN AndAlso m.WParam.ToInt32() = HTCAPTION Then
            Return ' Blokir drag form
        End If
        MyBase.WndProc(m)
    End Sub

    ' Blokir penutupan form melalui Alt+F4 atau cara lain
    Private Sub YourForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtPassword.Clear()  ' Menghapus teks pada TextBox 
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtPassword.Clear()

        ' Membuat form fullscreen
        Me.WindowState = FormWindowState.Maximized
        'Me.FormBorderStyle = FormBorderStyle.None

        ' Pusatkan komponen di tengah form
        CenterControl(GroupBox1)
    End Sub

    Private Sub CenterControl(ctrl As Control)
        ctrl.Left = (Me.ClientSize.Width - ctrl.Width) \ 2
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        Select Case True
            Case username = "" And password = ""
                lblError.Text = "Username dan password harus diisi."
                Return
            Case username = ""
                lblError.Text = "Username harus diisi."
                Return
            Case password = ""
                lblError.Text = "Password harus diisi."
                Return
        End Select



        If AuthenticateUser(username, password) Then
            ' Create new instance of MainForm (don't use My.Forms)
            Dim mainForm As New MainForm()

            ' Set the username
            mainForm.Username = username
            mainForm.UpdateUserDisplay()

            ' Show main form and hide login
            mainForm.Show()
            Me.Hide()

            ' Log the activity
            mainForm.LogActivity("Login")
        Else
            lblError.Text = "Username atau password salah."
            lblError.Visible = True
        End If

    End Sub

    Private Function AuthenticateUser(username As String, password As String) As Boolean
        ' Implementasi autentikasi dengan SQLite
        Using connection As New SQLiteConnection("Data Source=apotek.db;Version=3;")
            connection.Open()
            Dim query As String = "SELECT COUNT(*) FROM Users WHERE Username=@Username AND Password=@Password"
            Using command As New SQLiteCommand(query, connection)
                command.Parameters.AddWithValue("@Username", username)
                command.Parameters.AddWithValue("@Password", password)
                Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())
                Return result > 0
            End Using
        End Using
    End Function

    Private Sub LogActivity(username As String, activity As String)
        ' Simpan aktivitas ke database
        Using connection As New SQLiteConnection("Data Source=apotek.db;Version=3;")
            connection.Open()
            Dim query As String = "INSERT INTO LogActivity (Username, Activity, Timestamp) VALUES (@Username, @Activity, DATETIME('now'))"
            Using command As New SQLiteCommand(query, connection)
                command.Parameters.AddWithValue("@Username", username)
                command.Parameters.AddWithValue("@Activity", activity)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter
        Process.Start("shutdown", "/s /f /t 0")
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Process.Start("shutdown", "/s /f /t 0")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Process.Start("shutdown", "/s /f /t 0")
    End Sub
End Class
