Imports System.Data.SQLite
Imports System.Diagnostics
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports System.IO

Public Class KasirForm
    ' Gunakan satu variabel username yang konsisten
    Private _username As String
    Public Property Username() As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
            UpdateUserDisplay()
        End Set
    End Property

    Public Property ParentMainForm As MainForm = Nothing
    Private stopwatch As Stopwatch
    Private dataTableBeli As DataTable

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


    Private Sub KasirForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Aktifkan key preview untuk shortcut keyboard
        Me.KeyPreview = True

        ' 1. Inisialisasi komponen dasar
        InitializeBasicComponents()

        ' 2. Buat kolom DataGridView
        InitializeDataGridViewColumns()

        ' 3. Konfigurasi lanjutan
        ConfigureAdvancedGridView()

        ' 4. Load data
        LoadDataBeli()

        RefreshDataGridView()

        ' Inisialisasi timer
        stopwatch = New Stopwatch()
        stopwatch.Start()
        timerStopwatch.Interval = 1000
        timerStopwatch.Start()

        ' Update display username
        UpdateUserDisplay()

        ' Set fullscreen
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.None
        CenterControl(GroupBox1)
        CenterControl(GroupBox2)
    End Sub
    Private Sub CenterControl(ctrl As Control)
        ctrl.Left = (Me.ClientSize.Width - ctrl.Width) \ 2
    End Sub

    Private Sub UpdateUserDisplay()
        If lblUser IsNot Nothing AndAlso Not lblUser.IsDisposed Then
            lblUser.Text = $"User: {Username}"
        End If
    End Sub

    Private Sub LoadDataBeli()
        '1. Inisialisasi DataTable
        dataTableBeli = New DataTable()
        With dataTableBeli.Columns
            .Add("Barcode", GetType(String))
            .Add("NamaObat", GetType(String))
            .Add("Jumlah", GetType(Integer))
            .Add("Harga", GetType(Decimal))
            .Add("Stok", GetType(Integer))
        End With

        '2. Set DataSource DULU baru atur kolom (seperti kode lama)
        DataGridView1.DataSource = dataTableBeli
        DataGridView1.AutoGenerateColumns = False 'Nonaktifkan setelah set DataSource

        '3. Buat kolom manual
        DataGridView1.Columns.Clear()

        ' Kolom Barcode
        Dim colBarcode As New DataGridViewTextBoxColumn()
        With colBarcode
            .Name = "colBarcode"
            .HeaderText = "Barcode"
            .DataPropertyName = "Barcode"
            .ValueType = GetType(String)
            .DefaultCellStyle = New DataGridViewCellStyle With {
            .Alignment = DataGridViewContentAlignment.MiddleRight
            }
        End With
        DataGridView1.Columns.Add(colBarcode)

        ' Kolom Nama
        Dim colNama As New DataGridViewTextBoxColumn()
        With colNama
            .Name = "colNama"
            .HeaderText = "Nama Obat"
            .DataPropertyName = "NamaObat"
            .ValueType = GetType(String)
            .DefaultCellStyle = New DataGridViewCellStyle With {
            .Alignment = DataGridViewContentAlignment.MiddleRight
            }
        End With
        DataGridView1.Columns.Add(colNama)

        Dim colHarga As New DataGridViewTextBoxColumn()
        With colHarga
            .Name = "colHarga"
            .HeaderText = "Harga"
            .DataPropertyName = "Harga"
            .ValueType = GetType(Decimal)
            .DefaultCellStyle = New DataGridViewCellStyle With {
            .Alignment = DataGridViewContentAlignment.MiddleRight
            }
        End With
        DataGridView1.Columns.Add(colHarga)

        ' Setup DataGridView
        DataGridView1.SuspendLayout()
        Try
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = dataTableBeli

            ' Pastikan mapping kolom benar
            For Each col As DataGridViewColumn In DataGridView1.Columns
                Debug.WriteLine($"Kolom {col.Name} -> {col.DataPropertyName}")
            Next
        Finally
            DataGridView1.ResumeLayout()
        End Try
    End Sub

    Private Function GetDefaultValue(type As Type) As Object
        If type Is GetType(Integer) Then Return 0
        If type Is GetType(Decimal) Then Return 0D
        If type Is GetType(String) Then Return String.Empty
        If type Is GetType(DateTime) Then Return DateTime.MinValue
        Return Nothing
    End Function

    Private Sub InitializeDataGridViewColumns()
        ' Pastikan DataGridView1 sudah diinisialisasi
        If DataGridView1 Is Nothing Then
            MessageBox.Show("DataGridView belum diinisialisasi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Suspend layout untuk performa
        DataGridView1.SuspendLayout()

        Try
            DataGridView1.Columns.Clear()

            ' Kolom Barcode
            Dim colBarcode As New DataGridViewTextBoxColumn()
            With colBarcode
                .Name = "colBarcode"
                .HeaderText = "Barcode"
                .DataPropertyName = "Barcode"
                .ValueType = GetType(String)
            End With

            ' Kolom Nama
            Dim colNama As New DataGridViewTextBoxColumn()
            With colNama
                .Name = "colNama"
                .HeaderText = "Nama Obat"
                .DataPropertyName = "NamaObat"
                .ValueType = GetType(String)
            End With

            ' Kolom Jumlah (Integer)
            Dim colJumlah As New DataGridViewTextBoxColumn()
            With colJumlah
                .Name = "colJumlah"
                .HeaderText = "Jumlah"
                .DataPropertyName = "Jumlah" ' Pastikan sesuai dengan nama kolom di DataTable
                .ValueType = GetType(Integer)
                .DefaultCellStyle = New DataGridViewCellStyle With {
            .Alignment = DataGridViewContentAlignment.MiddleRight,
            .Format = "N0",
            .BackColor = Color.LightYellow
        }
            End With

            ' Kolom Harga (Decimal)
            Dim colHarga As New DataGridViewTextBoxColumn()
            With colHarga
                .Name = "colHarga"
                .HeaderText = "Harga"
                .DataPropertyName = "Harga" ' Pastikan sesuai dengan nama kolom di DataTable
                .ValueType = GetType(Decimal)
                .DefaultCellStyle = New DataGridViewCellStyle With {
            .Alignment = DataGridViewContentAlignment.MiddleRight,
            .Format = "N0",
            .ForeColor = Color.DarkGreen,
            .BackColor = Color.LightCyan
        }
            End With

            ' Kolom Stok (Integer)
            Dim colStok As New DataGridViewTextBoxColumn()
            With colStok
                .Name = "colStok"
                .HeaderText = "Stok"
                .DataPropertyName = "Stok" ' Pastikan sesuai dengan nama kolom di DataTable
                .ValueType = GetType(Integer)
                .ReadOnly = True
                .DefaultCellStyle = New DataGridViewCellStyle With {
            .Alignment = DataGridViewContentAlignment.MiddleRight,
            .Format = "N0",
            .ForeColor = Color.DarkBlue,
            .BackColor = Color.Lavender
        }
            End With

            ' Tambahkan semua kolom
            DataGridView1.Columns.AddRange({colBarcode, colNama})
            DataGridView1.Columns.AddRange({colJumlah, colHarga, colStok})


            ' Atur auto size
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Setel properti tambahan
            DataGridView1.AutoGenerateColumns = False
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.AllowUserToDeleteRows = False
            DataGridView1.RowHeadersVisible = False

            ' Pastikan kolom Jumlah dan Stok memiliki ValueType yang benar
            DataGridView1.Columns("colJumlah").ValueType = GetType(Integer)
            DataGridView1.Columns("colStok").ValueType = GetType(Integer)

            ' Set ReadOnly untuk kolom Stok
            DataGridView1.Columns("colStok").ReadOnly = True

        Catch ex As Exception
            MessageBox.Show($"Error inisialisasi kolom: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Resume layout
            DataGridView1.ResumeLayout(False)
        End Try
    End Sub



    Private Sub ConfigureDataGridViewColumns()
        ' Atur ulang properti kolom yang perlu di-update
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Update format kolom jika diperlukan
        DataGridView1.Columns("colHarga").DefaultCellStyle.Format = "N0"
        DataGridView1.Columns("colJumlah").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns("colStok").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub


    Private Sub txtBarcode_TextChanged(sender As Object, e As EventArgs) Handles txtBarcode.TextChanged
        ' Jika barcode reader mengirimkan input, tambahkan obat ke DataTableBeli
        If txtBarcode.Text.Length > 0 Then
            ' Simpan barcode saat ini
            Dim barcode As String = txtBarcode.Text.Trim()

            ' Tambahkan obat
            TambahObat(barcode)
            ' Di akhir method TambahObat, tambahkan:
            'Debug.WriteLine($"Data yang ditambahkan - Barcode: {barcode}, Jumlah: {dataTableBeli.Rows(dataTableBeli.Rows.Count - 1)("Jumlah")}, Stok: {dataTableBeli.Rows(dataTableBeli.Rows.Count - 1)("Stok")}")

            ' Bersihkan TextBox setelah input
            txtBarcode.Clear()
        End If
    End Sub

    Private Sub InitializeBasicComponents()
        ' Pastikan DataGridView dan GroupBox sudah diinisialisasi
        If DataGridView1 Is Nothing Then
            DataGridView1 = New DataGridView()
            GroupBox1.Controls.Add(DataGridView1)
        End If

        ' Konfigurasi dasar GroupBox
        GroupBox1.Dock = DockStyle.Fill
    End Sub

    Private Sub TambahObat(barcode As String)
        Try
            Debug.WriteLine($"Memproses barcode: {barcode}")

            Using connection As New SQLiteConnection("Data Source=apotek.db;Version=3;")
                connection.Open()
                Dim query As String = "SELECT NamaObat, HargaJual AS Harga, JumlahStok AS Stok FROM Obat WHERE Barcode=@Barcode"

                Using command As New SQLiteCommand(query, connection)
                    command.Parameters.AddWithValue("@Barcode", barcode)

                    Using reader As SQLiteDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            ' Ambil nilai dengan konversi eksplisit
                            Dim namaObat As String = reader("NamaObat").ToString()
                            Dim harga As Decimal = Convert.ToDecimal(reader("Harga"))
                            Dim stok As Integer = Convert.ToInt32(reader("Stok"))

                            Debug.WriteLine($"Data dari DB - Harga: {harga}, Stok: {stok}")

                            ' Cari apakah obat sudah ada di DataTable
                            Dim existingRows = dataTableBeli.Select($"Barcode = '{barcode}'")


                            ' Tambahkan baris baru dengan nilai default
                            Dim newRow = dataTableBeli.NewRow()
                                newRow("Barcode") = barcode
                                newRow("NamaObat") = namaObat
                                newRow("Jumlah") = 1 ' Default 1, bukan dari harga
                                newRow("Harga") = harga ' Simpan di kolom harga
                                newRow("Stok") = stok ' Simpan di kolom stok

                                dataTableBeli.Rows.Add(newRow)
                                RefreshDataGridView()

                                Debug.WriteLine($"Baris baru - Jumlah: 1, Harga: {harga}, Stok: {stok}")


                            ' Refresh tampilan
                            ' Refresh DataGridView setelah perubahan data
                            'RefreshDataGridView()
                            ForceGridViewRefresh()
                            HitungTotalHarga()
                            'Else
                            'MessageBox.Show("Obat tidak ditemukan", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.WriteLine($"Error TambahObat: {ex.ToString()}")
        End Try
    End Sub
    Private Sub ForceGridViewRefresh()
        ' Validasi sebelum refresh
        If DataGridView1 Is Nothing OrElse dataTableBeli Is Nothing Then Return

        DataGridView1.SuspendLayout()
        Try
            ' Handle kasus tabel kosong
            If dataTableBeli.Rows.Count = 0 Then
                DataGridView1.DataSource = Nothing
                lblTotalHarga.Text = "Rp. 0"
                Return
            End If

            ' Simpan posisi scroll dan seleksi
            Dim firstVisibleRow = If(DataGridView1.FirstDisplayedScrollingRowIndex >= 0,
                               DataGridView1.FirstDisplayedScrollingRowIndex, 0)
            Dim selectedRow = If(DataGridView1.CurrentRow IsNot Nothing,
                           DataGridView1.CurrentRow.Index, -1)

            ' Lakukan refresh dengan data baru
            Dim tempTable = dataTableBeli.Copy()
            DataGridView1.DataSource = Nothing
            Application.DoEvents()
            DataGridView1.DataSource = tempTable

            ' Kembalikan posisi scroll dan seleksi
            If firstVisibleRow < DataGridView1.Rows.Count Then
                DataGridView1.FirstDisplayedScrollingRowIndex = firstVisibleRow
            End If
            If selectedRow >= 0 AndAlso selectedRow < DataGridView1.Rows.Count Then
                DataGridView1.Rows(selectedRow).Selected = True
            End If

        Catch ex As Exception
            Debug.WriteLine($"Error ForceGridViewRefresh: {ex.Message}")
        Finally
            DataGridView1.ResumeLayout()
        End Try
    End Sub


    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        ' Validasi dasar sebelum memproses error
        If DataGridView1 Is Nothing OrElse dataTableBeli Is Nothing Then
            e.ThrowException = False
            e.Cancel = True
            Return
        End If

        ' Tangani khusus error index out of range
        If TypeOf e.Exception Is IndexOutOfRangeException Then
            Debug.WriteLine($"Error IndexOutOfRange di kolom {e.ColumnIndex}, baris {e.RowIndex}")
            e.ThrowException = False
            e.Cancel = True
            Return
        End If

        ' Tangani error lainnya
        Select Case DataGridView1.Columns(e.ColumnIndex).Name
            Case "colJumlah", "colStok"
                ' Set nilai default untuk kolom numeric
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0
                e.ThrowException = False
                e.Cancel = True
            Case Else
                ' Biarkan error lainnya ditampilkan
                Debug.WriteLine($"DataError: {e.Exception.Message}")
        End Select
    End Sub

    Private Function IsValidRowIndex(rowIndex As Integer) As Boolean
        Return DataGridView1 IsNot Nothing AndAlso
           rowIndex >= 0 AndAlso
           rowIndex < DataGridView1.Rows.Count AndAlso
           Not DataGridView1.Rows(rowIndex).IsNewRow
    End Function

    Private Function GetSafeCellValue(rowIndex As Integer, columnName As String) As Object
        If Not IsValidRowIndex(rowIndex) OrElse Not DataGridView1.Columns.Contains(columnName) Then
            Return Nothing
        End If

        Try
            Return DataGridView1.Rows(rowIndex).Cells(columnName).Value
        Catch
            Return Nothing
        End Try
    End Function

    Private Sub ForceDataGridViewRefresh()
        If DataGridView1 Is Nothing OrElse dataTableBeli Is Nothing Then Return

        'Simpan posisi scroll
        Dim vertScroll As Integer = DataGridView1.FirstDisplayedScrollingRowIndex
        Dim horzScroll As Integer = DataGridView1.FirstDisplayedScrollingColumnIndex

        'Refresh binding
        Dim tempDataSource As DataTable = dataTableBeli
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = tempDataSource

        'Kembalikan posisi scroll
        If vertScroll >= 0 Then DataGridView1.FirstDisplayedScrollingRowIndex = vertScroll
        If horzScroll >= 0 Then DataGridView1.FirstDisplayedScrollingColumnIndex = horzScroll

        'Refresh tampilan
        DataGridView1.Refresh()

        ' Ganti dengan ini untuk lebih aman
        DataGridView1.SuspendLayout()
        Try
            Dim tempDS = dataTableBeli.Copy()
            DataGridView1.DataSource = Nothing
            Application.DoEvents()
            DataGridView1.DataSource = tempDS
        Finally
            DataGridView1.ResumeLayout()
        End Try
    End Sub

    Private Sub RefreshDataGridView()
        ' Simpan posisi scroll dan seleksi
        Dim scrollPos = DataGridView1.FirstDisplayedScrollingRowIndex
        Dim selectedRow = If(DataGridView1.CurrentRow IsNot Nothing, DataGridView1.CurrentRow.Index, -1)

        ' Lakukan refresh
        Dim tempDataSource As DataTable = dataTableBeli.Copy()
        DataGridView1.DataSource = Nothing
        Application.DoEvents() ' Memastikan UI update
        DataGridView1.DataSource = tempDataSource

        ' Kembalikan posisi scroll dan seleksi
        If scrollPos >= 0 AndAlso scrollPos < DataGridView1.Rows.Count Then
            DataGridView1.FirstDisplayedScrollingRowIndex = scrollPos
        End If
        If selectedRow >= 0 AndAlso selectedRow < DataGridView1.Rows.Count Then
            DataGridView1.Rows(selectedRow).Selected = True
        End If
    End Sub

    Private Function FindRowByBarcode(barcode As String) As DataRow
        For Each row As DataRow In dataTableBeli.Rows
            If row("Barcode").ToString() = barcode Then
                Return row
            End If
        Next
        Return Nothing
    End Function

    Private Sub HitungTotalHarga()
        Dim totalHarga As Decimal = 0
        For Each row As DataRow In dataTableBeli.Rows
            Dim harga As Decimal = If(IsDBNull(row("Harga")), 0D, Convert.ToDecimal(row("Harga")))
            Dim jumlah As Integer = If(IsDBNull(row("Jumlah")), 0, Convert.ToInt32(row("Jumlah")))
            totalHarga += harga * jumlah
        Next
        lblTotalHarga.Text = "Rp. " & totalHarga.ToString("N0")
    End Sub

    Private Sub KasirForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                SelesaikanTransaksi()
            Case Keys.Back
                HapusItemTerakhir()
        End Select
    End Sub

    Private Sub SelesaikanTransaksi()
        If String.IsNullOrEmpty(Username) Then
            MessageBox.Show("Username tidak tersedia.")
            Return
        End If

        ' Validasi apakah ada item yang dibeli
        If dataTableBeli.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada item yang dibeli!")
            Return
        End If

        Using connection As New SQLiteConnection("Data Source=apotek.db;Version=3;")
            Try
                connection.Open()

                ' Mulai transaction untuk atomic operation
                Dim transaction As SQLiteTransaction = connection.BeginTransaction()

                Try
                    ' 1. Simpan transaksi dan update stok
                    For Each row As DataRow In dataTableBeli.Rows
                        Dim barcode As String = row("Barcode").ToString()
                        Dim namaObat As String = row("NamaObat").ToString()
                        Dim jumlah As Integer = If(IsDBNull(row("Jumlah")), 0, Convert.ToInt32(row("Jumlah")))
                        Dim harga As Decimal = If(IsDBNull(row("Harga")), 0D, Convert.ToDecimal(row("Harga")))

                        ' Simpan ke tabel Transaksi
                        Dim queryTransaksi As String = "INSERT INTO Transaksi (NamaObat, Jumlah, Harga, Username, Tanggal) VALUES (@NamaObat, @Jumlah, @Harga, @Username, datetime('now'))"
                        Using cmdTransaksi As New SQLiteCommand(queryTransaksi, connection, transaction)
                            cmdTransaksi.Parameters.AddWithValue("@NamaObat", namaObat)
                            cmdTransaksi.Parameters.AddWithValue("@Jumlah", jumlah)
                            cmdTransaksi.Parameters.AddWithValue("@Harga", harga)
                            cmdTransaksi.Parameters.AddWithValue("@Username", Username)
                            cmdTransaksi.ExecuteNonQuery()
                        End Using

                        ' Update stok obat
                        Dim queryUpdate As String = "UPDATE Obat SET JumlahStok = JumlahStok - @Jumlah WHERE Barcode = @Barcode"
                        Using cmdUpdate As New SQLiteCommand(queryUpdate, connection, transaction)
                            cmdUpdate.Parameters.AddWithValue("@Jumlah", jumlah)
                            cmdUpdate.Parameters.AddWithValue("@Barcode", barcode)
                            cmdUpdate.ExecuteNonQuery()
                        End Using

                        ' Log aktivitas per item
                        LogActivity(connection, transaction, $"Menjual {namaObat} ({jumlah} x Rp {harga:N0})")
                    Next

                    ' Log summary transaksi
                    Dim totalHarga As Decimal = dataTableBeli.AsEnumerable().Sum(Function(r) Convert.ToDecimal(r("Harga")) * Convert.ToInt32(r("Jumlah")))
                    LogActivity(connection, transaction, $"Transaksi selesai - Total: Rp {totalHarga:N0}")

                    ' Setelah transaksi berhasil
                    transaction.Commit()
                    'MessageBox.Show("Transaksi berhasil disimpan!")

                    ' RESET DATA SETELAH TRANSAKSI
                    ResetTransaksi()
                    HitungTotalHarga()

                Catch ex As Exception
                    transaction.Rollback()
                    MessageBox.Show($"Error saat proses transaksi: {ex.Message}")
                    LogError($"Error transaksi: {ex.Message}")
                End Try

            Catch ex As Exception
                MessageBox.Show($"Error koneksi database: {ex.Message}")
                LogError($"Error koneksi: {ex.Message}")
            End Try
        End Using
    End Sub

    Private Sub ResetTransaksi()
        ' Suspend layout untuk performa
        DataGridView1.SuspendLayout()

        Try
            ' Clear DataTable
            If dataTableBeli IsNot Nothing Then
                dataTableBeli.Rows.Clear()
            Else
                ' Re-inisialisasi jika null
                LoadDataBeli()
            End If

            ' Refresh DataGridView
            DataGridView1.DataSource = Nothing
            DataGridView1.DataSource = dataTableBeli

            ' Reset total harga
            lblTotalHarga.Text = "Rp. 0"

            ' Fokus kembali ke textbox barcode
            txtBarcode.Clear()
            txtBarcode.Focus()

            ' Force refresh UI
            DataGridView1.Refresh()
            Application.DoEvents()

        Catch ex As Exception
            MessageBox.Show($"Error reset transaksi: {ex.Message}")
        Finally
            DataGridView1.ResumeLayout()
        End Try
    End Sub

    ' Method untuk log aktivitas dalam transaction yang sama
    Private Sub LogActivity(connection As SQLiteConnection, transaction As SQLiteTransaction, activity As String)
        Try
            Dim query As String = "INSERT INTO LogActivity (Username, Activity, Timestamp) VALUES (@Username, @Activity, datetime('now'))"
            Using command As New SQLiteCommand(query, connection, transaction)
                command.Parameters.AddWithValue("@Username", Username)
                command.Parameters.AddWithValue("@Activity", activity)
                command.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Gagal mencatat log: {ex.Message}")
        End Try
    End Sub

    ' Method untuk log error (terpisah dari transaction)
    Private Sub LogError(message As String)
        Try
            Using connection As New SQLiteConnection("Data Source=apotek.db;Version=3;")
                connection.Open()
                Dim query As String = "INSERT INTO ErrorLog (Username, ErrorMessage, Timestamp) VALUES (@Username, @Message, datetime('now'))"
                Using command As New SQLiteCommand(query, connection)
                    command.Parameters.AddWithValue("@Username", Username)
                    command.Parameters.AddWithValue("@Message", message)
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Gagal mencatat error: {ex.Message}")
        End Try
    End Sub

    Private Sub LogActivity(username As String, activity As String)
        Try
            Using connection As New SQLiteConnection("Data Source=apotek.db;Version=3;")
                connection.Open()

                ' Tambahkan detail tambahan ke aktivitas
                Dim fullActivity As String = $"Transaksi: {activity}"

                Dim query As String = "INSERT INTO LogActivity (Username, Activity, Timestamp) 
                                 VALUES (@Username, @Activity, datetime('now', 'localtime'))"

                Using command As New SQLiteCommand(query, connection)
                    command.Parameters.AddWithValue("@Username", username)
                    command.Parameters.AddWithValue("@Activity", fullActivity)
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Jangan ganggu alur transaksi utama jika log gagal
            Debug.WriteLine($"Gagal mencatat log: {ex.Message}")
        End Try
    End Sub

    Private Function GetStokTersedia(connection As SQLiteConnection, barcode As String) As Integer
        Dim query As String = "SELECT JumlahStok FROM Obat WHERE Barcode = @Barcode"
        Using command As New SQLiteCommand(query, connection)
            command.Parameters.AddWithValue("@Barcode", barcode)
            Dim result = command.ExecuteScalar()
            Return If(result IsNot Nothing AndAlso Not IsDBNull(result), Convert.ToInt32(result), 0)
        End Using
    End Function

    Private Sub HapusItemTerakhir()
        Try
            ' Validasi 1: Cek DataTable
            If dataTableBeli Is Nothing OrElse dataTableBeli.Rows.Count = 0 Then
                MessageBox.Show("Keranjang belanja kosong", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Validasi 2: Dapatkan baris terakhir dengan aman
            Dim lastIndex = dataTableBeli.Rows.Count - 1
            If lastIndex < 0 Then Return

            Dim lastRow = dataTableBeli.Rows(lastIndex)
            Dim productName = lastRow("NamaObat").ToString()
            Dim currentQty = Convert.ToInt32(lastRow("Jumlah"))

            dataTableBeli.Rows.Remove(lastRow)

            ' Refresh tampilan
            RefreshDataGridView()
            ForceGridViewRefresh()
            HitungTotalHarga()

        Catch ex As Exception
            MessageBox.Show($"Gagal menghapus item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_Paint(sender As Object, e As PaintEventArgs) Handles DataGridView1.Paint
        ' Jika tidak ada data, tampilkan pesan
        If DataGridView1.Rows.Count = 0 Then
            Using f As New Font("Arial", 12, FontStyle.Italic)
                e.Graphics.DrawString("Tidak ada data", f, Brushes.Gray,
                                New PointF(10, DataGridView1.Height / 2))
            End Using
        End If
    End Sub

    Private Sub timerStopwatch_Tick(sender As Object, e As EventArgs) Handles timerStopwatch.Tick
        ' Update label aktif dengan waktu stopwatch
        lblAktif.Text = AppTimer.GetElapsedTime()
    End Sub

    ' Metode untuk mengatur username yang login
    Public Sub SetUsername(user As String)
        Me.username = user
        If lblUser IsNot Nothing Then
            lblUser.Text = $"User: {user}"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Kembali ke MainForm dengan membawa username
        If ParentMainForm IsNot Nothing Then
            ' Pastikan MainForm menerima username terbaru
            ParentMainForm.Username = Me.Username
            ParentMainForm.Show()
        Else
            ' Fallback jika MainForm tidak tersedia
            Dim mainForm As New MainForm()
            mainForm.Username = Me.Username
            mainForm.Show()
        End If
        Me.Close()
    End Sub

    ' Method untuk menerima timer dari MainForm
    Public Sub SetTimer(elapsedTime As TimeSpan)
        If stopwatch Is Nothing Then
            stopwatch = New Stopwatch()
        End If

        stopwatch.Start()
        ' Setel ulang timer ke nilai yang diterima
        stopwatch = Stopwatch.StartNew()
        stopwatch.Start()
        ' Kompensasi waktu yang sudah berlalu
        For i = 1 To elapsedTime.TotalMilliseconds
            stopwatch.Elapsed.Add(TimeSpan.FromTicks(1))
        Next
    End Sub

    Private Sub ConfigureAdvancedGridView()
        ' Pastikan DataGridView1 sudah diinisialisasi
        If DataGridView1 Is Nothing Then
            MessageBox.Show("DataGridView belum diinisialisasi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Suspend layout untuk performa
        DataGridView1.SuspendLayout()

        Try
            ' ===== KONFIGURASI DASAR =====
            DataGridView1.Dock = DockStyle.Fill
            DataGridView1.BorderStyle = BorderStyle.Fixed3D
            DataGridView1.EnableHeadersVisualStyles = False

            ' ===== PENGATURAN FONT =====
            DataGridView1.DefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Bold)

            ' ===== WARNA DAN TAMPILAN =====
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            DataGridView1.ColumnHeadersHeight = 40
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender

            ' ===== KONFIGURASI KOLOM =====
            ' Pastikan kolom sudah ada sebelum diakses
            If DataGridView1.Columns.Count = 0 Then
                InitializeDataGridViewColumns()
            End If

            ' Atur auto size hanya jika kolom ada
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            If DataGridView1.Columns.Contains("colBarcode") Then
                DataGridView1.Columns("colBarcode").FillWeight = 15
            End If
            If DataGridView1.Columns.Contains("colNama") Then
                DataGridView1.Columns("colNama").FillWeight = 35
            End If
            If DataGridView1.Columns.Contains("colJumlah") Then
                DataGridView1.Columns("colJumlah").FillWeight = 35
            End If
            If DataGridView1.Columns.Contains("ColHarga") Then
                DataGridView1.Columns("colHarga").FillWeight = 35
            End If
            If DataGridView1.Columns.Contains("colStok") Then
                DataGridView1.Columns("colStok").FillWeight = 35
            End If
            ' ... [lanjutkan untuk kolom lainnya] ...



        Catch ex As Exception
            MessageBox.Show($"Error mengkonfigurasi DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Resume layout
            DataGridView1.ResumeLayout(False)
        End Try
    End Sub


    Private Sub EnhanceUserExperience()
        ' Aktifkan double buffering untuk smooth scrolling
        GetType(DataGridView).InvokeMember("DoubleBuffered",
        Reflection.BindingFlags.NonPublic Or
        Reflection.BindingFlags.Instance Or
        Reflection.BindingFlags.SetProperty,
        Nothing, DataGridView1, New Object() {True})

        ' Optimasi performa untuk banyak data
        DataGridView1.AutoSize = False
        DataGridView1.RowHeadersVisible = False ' Sembunyikan row header jika tidak perlu

        ' Hover effect
        DataGridView1.DefaultCellStyle.BackColor = Color.White
        DataGridView1.DefaultCellStyle.ForeColor = Color.Black
    End Sub
    Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim colName As String = DataGridView1.Columns(e.ColumnIndex).Name

        ' Validasi untuk kolom numeric
        If colName = "colHarga" OrElse colName = "colJumlah" OrElse colName = "colStok" Then
            If Not Integer.TryParse(e.FormattedValue.ToString(), Nothing) Then
                DataGridView1.Rows(e.RowIndex).ErrorText = "Harap masukkan angka yang valid"
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        ' Clear error text setelah edit selesai
        DataGridView1.Rows(e.RowIndex).ErrorText = String.Empty
    End Sub

    Private Sub LogDataTableChanges()
        Debug.WriteLine("=== Isi DataTable ===")
        For Each row As DataRow In dataTableBeli.Rows
            Debug.WriteLine($"Barcode: {row("Barcode")}, " &
                       $"Jumlah: {row("Jumlah")}({row("Jumlah").GetType().Name}), " &
                       $"Harga: {row("Harga")}({row("Harga").GetType().Name}), " &
                       $"Stok: {row("Stok")}({row("Stok").GetType().Name})")
        Next
        Debug.WriteLine("=====================")
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim colName = DataGridView1.Columns(e.ColumnIndex).Name
            Dim cellValue = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            Debug.WriteLine($"Perubahan nilai - Kolom: {colName}, Nilai: {cellValue}, Tipe: {If(cellValue IsNot Nothing, cellValue.GetType().Name, "NULL")}")

            ' Validasi khusus untuk kolom jumlah
            If colName = "colJumlah" Then
                If cellValue IsNot Nothing AndAlso Not IsNumeric(cellValue) Then
                    DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 1
                    MessageBox.Show("Jumlah harus angka", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        ' Bersihkan error setelah binding selesai
        For Each row As DataGridViewRow In DataGridView1.Rows
            row.ErrorText = String.Empty
        Next
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        ' Handle khusus kolom Jumlah dan Stok
        If DataGridView1.Columns(e.ColumnIndex).Name = "colJumlah" OrElse
       DataGridView1.Columns(e.ColumnIndex).Name = "colStok" Then

            ' Jika nilai null, set ke default
            If e.Value Is Nothing OrElse IsDBNull(e.Value) Then
                e.Value = 0
                e.FormattingApplied = True
                Return
            End If

            ' Coba konversi ke Integer
            Dim intValue As Integer
            If Integer.TryParse(e.Value.ToString(), intValue) Then
                e.Value = intValue
            Else
                e.Value = 0
            End If
            e.FormattingApplied = True
        End If
    End Sub


    Private Sub DataGridView1_CellToolTipTextNeeded(sender As Object, e As DataGridViewCellToolTipTextNeededEventArgs) Handles DataGridView1.CellToolTipTextNeeded
        ' Pastikan row index valid dan DataGridView memiliki data
        If e.RowIndex >= 0 AndAlso e.RowIndex < DataGridView1.Rows.Count AndAlso
       DataGridView1.Columns.Contains("colNama") AndAlso
       e.ColumnIndex = DataGridView1.Columns("colNama").Index Then

            Dim cellValue As Object = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If cellValue IsNot Nothing AndAlso Not IsDBNull(cellValue) Then
                e.ToolTipText = cellValue.ToString()
            Else
                e.ToolTipText = "Nama obat tidak tersedia"
            End If
        End If
    End Sub


    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click

    End Sub

    Private Sub lblUser_Click(sender As Object, e As EventArgs) Handles lblUser.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub
End Class
