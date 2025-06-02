Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports System.Data.SQLite
Imports System.Diagnostics
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports System.Runtime.InteropServices
Imports System.IO  ' Ini memberikan akses ke Path dan File


Public Class MainForm

    ' Di MainForm atau module utama:
    Public Sub Main()
        ' Tambahkan handler untuk unhandled exceptions
        AddHandler Application.ThreadException, AddressOf Application_ThreadException
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New MainForm())
    End Sub

    Private Sub Application_ThreadException(sender As Object, e As Threading.ThreadExceptionEventArgs)
        LogError(e.Exception)
        MessageBox.Show("Terjadi kesalahan tidak terduga. Aplikasi akan terus berjalan." &
                   Environment.NewLine & "Detail: " & e.Exception.Message,
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub CurrentDomain_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs)
        Dim ex As Exception = DirectCast(e.ExceptionObject, Exception)
        LogError(ex)
        MessageBox.Show("Kesalahan kritis terjadi. Aplikasi akan terus berjalan jika memungkinkan." &
                   Environment.NewLine & "Detail: " & ex.Message,
                   "Error Kritis", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    Private Sub LogError(ex As Exception)
        Try
            Dim logPath As String = Path.Combine(Application.StartupPath, "error_log.txt")
            Dim errorMessage As String = $"[{DateTime.Now}] {ex.GetType().Name}: {ex.Message}{Environment.NewLine}" &
                                    $"Stack Trace: {ex.StackTrace}{Environment.NewLine}{Environment.NewLine}"

            File.AppendAllText(logPath, errorMessage)
        Catch logEx As Exception
            ' Jika gagal menulis log, tampilkan di output debug
            Debug.WriteLine("Gagal menulis log error: " & logEx.Message)
        End Try
    End Sub


    ' 1. Deklarasi API dan variabel HANYA SATU KALI
    <DllImport("user32.dll")>
    Private Shared Function GetAsyncKeyState(ByVal vKey As Integer) As Short
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function SetWindowsHookEx(
        ByVal idHook As Integer,
        ByVal lpfn As KeyboardProc,
        ByVal hMod As IntPtr,
        ByVal dwThreadId As Integer
    ) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function UnhookWindowsHookEx(ByVal hhk As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function CallNextHookEx(
        ByVal hhk As IntPtr,
        ByVal nCode As Integer,
        ByVal wParam As IntPtr,
        ByVal lParam As IntPtr
    ) As IntPtr
    End Function

    Private Delegate Function KeyboardProc(
        ByVal nCode As Integer,
        ByVal wParam As IntPtr,
        ByVal lParam As IntPtr
    ) As IntPtr

    ' 2. Deklarasi variabel HANYA SATU KALI
    Private Const WH_KEYBOARD_LL As Integer = 13
    Private Const WM_KEYDOWN As Integer = &H100
    Private Const WM_SYSKEYDOWN As Integer = &H104
    Private Const VK_TAB As Integer = &H9
    Private Const VK_ALT As Integer = &H12
    Private Const VK_F4 As Integer = &H73

    Private hookID As IntPtr = IntPtr.Zero ' Hanya satu deklarasi
    Private keyboardHookDelegate As KeyboardProc

    ' 3. Implementasi KeyboardHook HANYA SATU KALI
    Private Function KeyboardHook(
        ByVal nCode As Integer,
        ByVal wParam As IntPtr,
        ByVal lParam As IntPtr
    ) As IntPtr
        If nCode >= 0 Then
            Dim vkCode As Integer = Marshal.ReadInt32(lParam)

            ' Blokir Alt+Tab
            If (wParam = WM_KEYDOWN OrElse wParam = WM_SYSKEYDOWN) AndAlso
               vkCode = VK_TAB AndAlso (GetAsyncKeyState(VK_ALT) And &H8000) <> 0 Then
                Return CType(1, IntPtr)
            End If

            ' Blokir Alt+F4
            If wParam = WM_SYSKEYDOWN AndAlso vkCode = VK_F4 Then
                Return CType(1, IntPtr)
            End If
        End If

        Return CallNextHookEx(hookID, nCode, wParam, lParam)
    End Function

    ' 4. Inisialisasi hook
    Private Sub InitializeKeyboardHook()
        keyboardHookDelegate = New KeyboardProc(AddressOf KeyboardHook)
        hookID = SetWindowsHookEx(WH_KEYBOARD_LL, keyboardHookDelegate, IntPtr.Zero, 0)
    End Sub

    ' 5. Cleanup hook
    Private Sub CleanupKeyboardHook()
        If hookID <> IntPtr.Zero Then
            UnhookWindowsHookEx(hookID)
            hookID = IntPtr.Zero
        End If
    End Sub

    ' Declare WithEvents variable for the child form
    Private WithEvents currentChildForm As Form = Nothing


    ' Keep child form on top when main form is activated
    Private Sub MainForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If currentChildForm IsNot Nothing AndAlso Not currentChildForm.IsDisposed Then
            currentChildForm.BringToFront()
        End If
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CleanupKeyboardHook()
    End Sub

    ' ==============================================================


    Public Property Username As String
    Private kasirForm As KasirForm = Nothing
    Private stopwatch As Stopwatch

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitializeKeyboardHook()

        ' 2. Simpan delegate sebelum digunakan
        'keyboardHookDelegate = New KeyboardProc(AddressOf KeyboardHook)

        ' 3. Gunakan variabel delegate yang sudah disimpan
        'hookID = SetWindowsHookEx(WH_KEYBOARD_LL, keyboardHookDelegate, IntPtr.Zero, 0)


        ' Pasang keyboard hook
        'hookID = SetWindowsHookEx(WH_KEYBOARD_LL, New KeyboardProc(AddressOf KeyboardHook), IntPtr.Zero, 0)

        ' Set form ke fullscreen
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        Me.TopMost = False

        ' ============================================================

        AppTimer.StartTimer()

        ' Inisialisasi timer
        If AppTimer.GlobalStopwatch Is Nothing Then
            AppTimer.GlobalStopwatch = New Stopwatch()
        End If
        AppTimer.StartTimer()

        timerStopwatch.Interval = 1000
        timerStopwatch.Start()

        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.None
        CenterControl(GroupBox2)
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        ' 7. Pastikan hook dilepas dengan benar
        If hookID <> IntPtr.Zero Then
            UnhookWindowsHookEx(hookID)
            hookID = IntPtr.Zero
        End If
        MyBase.OnFormClosing(e)
    End Sub


    Private Sub CenterControl(ctrl As Control)
        ctrl.Left = (Me.ClientSize.Width - ctrl.Width) \ 2
    End Sub

    Private Sub btnKasir_Click(sender As Object, e As EventArgs) Handles btnKasir.Click
        kasirForm = New KasirForm()
        kasirForm.ParentMainForm = Me
        kasirForm.Username = Me.Username

        Me.Hide()
        kasirForm.Show()
    End Sub

    Public Sub UpdateUserDisplay()
        If lblUser IsNot Nothing AndAlso Not lblUser.IsDisposed Then
            lblUser.Text = $"{Username}"
        End If
    End Sub

    Private Sub btnUpdateStok_Click(sender As Object, e As EventArgs) Handles btnUpdateStok.Click
        Dim updateStokForm As New UpdateStokForm()
        updateStokForm.Show(Me) ' Me sebagai owner
        updateStokForm.BringToFront()
    End Sub

    Private Sub timerStopwatch_Tick(sender As Object, e As EventArgs) Handles timerStopwatch.Tick
        lblAktif.Text = AppTimer.GetElapsedTime()
    End Sub

    Private Sub btnLaporan_Click(sender As Object, e As EventArgs) Handles btnLaporan.Click
        Dim laporanForm As New LaporanPenjualanForm()
        laporanForm.ParentMainForm = Me
        laporanForm.Username = Me.Username
        Me.Hide()
        laporanForm.Show()
    End Sub


    Public Sub LogActivity(activity As String)
        Try
            Using connection As New SQLiteConnection("Data Source=apotek.db;Version=3;")
                connection.Open()
                Dim query As String = "INSERT INTO ActivityLog (Username, Activity, Timestamp) VALUES (@Username, @Activity, datetime('now'))"

                Using command As New SQLiteCommand(query, connection)
                    command.Parameters.AddWithValue("@Username", Username)
                    command.Parameters.AddWithValue("@Activity", activity)
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error logging activity: " & ex.ToString())
        End Try
    End Sub

    ' ===== [6] Cleanup =====
    Private Sub MainForm_FormClosed(
        sender As Object,
        e As FormClosedEventArgs
    ) Handles Me.FormClosed
        UnhookWindowsHookEx(hookID)
    End Sub

    ' ===== [7] Method untuk menutup aplikasi secara paksa =====
    Public Sub ForceClose()
        UnhookWindowsHookEx(hookID)
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' 1. Log aktivitas
        LogActivity("Logout")

        ' 2. Reset timer
        AppTimer.ResetTimer()

        ' 3. Bersihkan resource
        UnhookWindowsHookEx(hookID) ' Pastikan hook dilepas

        ' 4. Tutup child form jika ada
        If currentChildForm IsNot Nothing AndAlso Not currentChildForm.IsDisposed Then
            currentChildForm.Close()
        End If

        ' 5. Buat dan tampilkan login form
        Dim loginForm As New LoginForm()
        loginForm.StartPosition = FormStartPosition.CenterScreen

        ' 6. Tutup main form setelah login form siap
        Me.Hide() ' Sembunyikan dulu untuk transisi halus
        loginForm.Show()

        ' 7. Tutup main form setelah login form ditampilkan
        Me.Close()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class