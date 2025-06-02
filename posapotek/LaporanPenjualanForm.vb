Imports System.Data.SQLite
Imports System.IO
Imports iTextSharp.text
Imports System.Text
Imports iTextSharp.text.pdf

Public Class LaporanPenjualanForm
    Private dataTable As DataTable
    ' Gunakan satu variabel username yang konsisten
    Private _username As String
    Public Property Username() As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
        End Set
    End Property

    Private stopwatch As Stopwatch

    Public Property ParentMainForm As MainForm = Nothing

    Public Sub SetTimer(elapsedTime As TimeSpan)
        If Stopwatch Is Nothing Then
            Stopwatch = New Stopwatch()
        End If

        Stopwatch.Start()
        ' Setel ulang timer ke nilai yang diterima
        Stopwatch = Stopwatch.StartNew()
        Stopwatch.Start()
        ' Kompensasi waktu yang sudah berlalu
        For i = 1 To elapsedTime.TotalMilliseconds
            Stopwatch.Elapsed.Add(TimeSpan.FromTicks(1))
        Next
    End Sub


    Private Sub CenterControl(ctrl As Control)
        ctrl.Left = (Me.ClientSize.Width - ctrl.Width) \ 2
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



    Private Sub LaporanPenjualanForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set fullscreen
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.None
        CenterControl(GroupBox1)

        Me.TopMost = True  ' Pastikan selalu di depan
        Me.StartPosition = FormStartPosition.CenterParent

        ' Atur tanggal akhir ke hari ini
        dtpTanggalAkhir.Value = DateTime.Now

        ' Load data transaksi ke DataGridView
        LoadDataTransaksi()

        ' Load data stok obat ke RichTextBox
        LoadDataStokPeringatan()

        ' Tambahkan event handler untuk perubahan tanggal, sorting, dan pencarian
        AddHandler dtpTanggalAwal.ValueChanged, AddressOf LoadDataTransaksi
        AddHandler dtpTanggalAkhir.ValueChanged, AddressOf LoadDataTransaksi
        AddHandler cmbSort.SelectedIndexChanged, AddressOf SortDataTransaksi
        AddHandler btnCariBarcode.Click, AddressOf CariBarcode
        AddHandler btnRefresh.Click, AddressOf LoadDataTransaksi
        AddHandler btnUnduhPDF.Click, AddressOf btnUnduhPDF_Click
        AddHandler btnFilterStok.Click, AddressOf btnFilterStok_Click
        AddHandler btnUnduhStokPeringatan.Click, AddressOf btnUnduhStokPeringatan_Click
    End Sub

    Private Sub LoadDataTransaksi()
        ' Implementasi load data dari database
        Using connection As New SQLiteConnection("Data Source=apotek.db;Version=3;")
            connection.Open()
            Dim query As String = "SELECT ROWID AS No, NamaObat, Jumlah, Harga, (Jumlah * Harga) AS Total, Username, Tanggal " &
                    "FROM Transaksi WHERE Date(Tanggal) BETWEEN @TanggalAwal AND @TanggalAkhir"

            ' Periksa apakah kolom Tanggal ada di tabel Transaksi
            If Not KolomAdaDiTabel(connection, "Transaksi", "Tanggal") Then
                MessageBox.Show("Kolom Tanggal tidak ada di tabel Transaksi. Silakan tambahkan kolom tersebut ke database.")
                Return
            End If

            Using command As New SQLiteCommand(query, connection)
                command.Parameters.AddWithValue("@TanggalAwal", dtpTanggalAwal.Value.Date)
                command.Parameters.AddWithValue("@TanggalAkhir", dtpTanggalAkhir.Value.Date.AddDays(1).AddTicks(-1))
                Using adapter As New SQLiteDataAdapter(command)
                    dataTable = New DataTable()
                    adapter.Fill(dataTable)
                    DataGridView1.DataSource = dataTable
                End Using
            End Using
        End Using

        ' Hitung total penjualan
        HitungTotalPenjualan()
    End Sub

    Private Function KolomAdaDiTabel(connection As SQLiteConnection, tabel As String, kolom As String) As Boolean
        Dim query As String = $"PRAGMA table_info({tabel})"
        Using command As New SQLiteCommand(query, connection)
            Using reader As SQLiteDataReader = command.ExecuteReader()
                While reader.Read()
                    If reader("name").ToString() = kolom Then
                        Return True
                    End If
                End While
            End Using
        End Using
        Return False
    End Function

    Private Sub HitungTotalPenjualan()
        Dim totalPenjualan As Decimal = 0
        For Each row As DataRow In dataTable.Rows
            totalPenjualan += Convert.ToDecimal(row("Total"))
        Next
        lblTotalPenjualan.Text = "Total Penjualan: Rp. " & totalPenjualan.ToString("N0")
    End Sub

    Private Sub SortDataTransaksi(sender As Object, e As EventArgs) Handles cmbSort.SelectedIndexChanged
        If dataTable IsNot Nothing AndAlso dataTable.Rows.Count > 0 Then
            Select Case cmbSort.SelectedItem.ToString()
                Case "Alfabet Nama Obat"
                    dataTable.DefaultView.Sort = "NamaObat ASC"
                Case "Tanggal Waktu"
                    dataTable.DefaultView.Sort = "Tanggal ASC"
                Case Else
                    dataTable.DefaultView.Sort = ""
            End Select
            DataGridView1.DataSource = dataTable
        End If
    End Sub

    Private Sub CariBarcode(sender As Object, e As EventArgs) Handles btnCariBarcode.Click
        If dataTable IsNot Nothing AndAlso dataTable.Rows.Count > 0 Then
            If String.IsNullOrEmpty(txtBarcodeCari.Text) Then
                dataTable.DefaultView.RowFilter = ""
            Else
                dataTable.DefaultView.RowFilter = $"NamaObat LIKE '%{txtBarcodeCari.Text}%'"
            End If
        End If
    End Sub

    Private Sub btnUnduhPDF_Click(sender As Object, e As EventArgs)
        ' Implementasi unduh PDF
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf"
        saveFileDialog.Title = "Simpan Laporan Penjualan"
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = saveFileDialog.FileName
            ExportToPdf(filePath)
            MessageBox.Show("Laporan berhasil disimpan sebagai PDF.")
        End If
    End Sub

    Private Sub LaporanPenjualanForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.BringToFront()
    End Sub

    Private Sub ExportToPdf(filePath As String)
        ' Implementasi export data ke PDF
        Using document As New Document(PageSize.A4.Rotate(), 50, 50, 25, 25)
            PdfWriter.GetInstance(document, New FileStream(filePath, FileMode.Create))
            document.Open()

            ' Tambahkan nama apotek dan alamat
            Dim namaApotek As New Paragraph("APOTEK MF", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18))
            namaApotek.Alignment = Element.ALIGN_CENTER
            document.Add(namaApotek)

            Dim alamatApotek As New Paragraph("Telagamurni, Kec. Cikarang Bar., Kabupaten Bekasi, Jawa Barat 17530", FontFactory.GetFont(FontFactory.HELVETICA, 12))
            alamatApotek.Alignment = Element.ALIGN_CENTER
            document.Add(alamatApotek)
            document.Add(New Paragraph(" "))

            ' Tambahkan judul
            Dim title As New Paragraph("LAPORAN PENJUALAN", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24))
            title.Alignment = Element.ALIGN_CENTER
            document.Add(title)
            document.Add(New Paragraph(" "))

            ' Tambahkan rentang tanggal
            Dim tanggalRange As New Paragraph($"Rentang Tanggal: {dtpTanggalAwal.Value.ToShortDateString()} - {dtpTanggalAkhir.Value.ToShortDateString()}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))
            tanggalRange.Alignment = Element.ALIGN_CENTER
            document.Add(tanggalRange)
            document.Add(New Paragraph(" "))

            ' Tambahkan tabel
            Dim table As New PdfPTable(DataGridView1.Columns.Count)
            table.WidthPercentage = 100

            ' Tambahkan header tabel
            For Each column As DataGridViewColumn In DataGridView1.Columns
                Dim cell As New PdfPCell(New Phrase(column.HeaderText))
                cell.BackgroundColor = BaseColor.LIGHT_GRAY
                cell.HorizontalAlignment = Element.ALIGN_CENTER
                table.AddCell(cell)
            Next

            ' Tambahkan data tabel
            For Each row As DataRow In dataTable.Rows
                For Each col As DataColumn In dataTable.Columns
                    table.AddCell(row(col).ToString())
                Next
            Next

            document.Add(table)
            document.Add(New Paragraph(" "))

            ' Tambahkan total penjualan
            Dim totalParagraph As New Paragraph(lblTotalPenjualan.Text, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))
            totalParagraph.Alignment = Element.ALIGN_RIGHT
            document.Add(totalParagraph)

            document.Close()
        End Using
    End Sub

    Private Sub LoadStokPeringatan(threshold As Integer)
        Try
            Using conn As New SQLiteConnection("Data Source=apotek.db;Version=3;")
                conn.Open()
                Dim query As String = "SELECT NamaObat, JumlahStok, Satuan FROM Obat WHERE JumlahStok < @Threshold ORDER BY JumlahStok ASC"

                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Threshold", threshold)

                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        Dim sb As New System.Text.StringBuilder()

                        If reader.HasRows Then
                            ' Deklarasi counter di sini (hanya sekali dalam scope ini)
                            Dim itemNumber As Integer = 1 ' Mengganti nama variabel untuk menghindari conflict

                            While reader.Read()
                                Dim stok = Convert.ToInt32(reader("JumlahStok"))
                                Dim stokText = If(stok = 0, "HABIS", $"{stok} {reader("Satuan").ToString()}")

                                sb.AppendLine($"{itemNumber}. {reader("NamaObat").ToString()}")
                                sb.AppendLine($"   Stok: {stokText}")
                                sb.AppendLine()


                                ' Increment counter
                                itemNumber += 1
                            End While
                        Else
                            If threshold = 0 Then
                                sb.AppendLine($"Tidak ada obat dengan stok habis")
                            Else
                                sb.AppendLine($"Tidak ada obat dengan stok di bawah {threshold}")
                            End If
                        End If

                        rtbStokPeringatan.Text = sb.ToString()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error memuat data stok: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            rtbStokPeringatan.Text = "Terjadi kesalahan saat memuat data stok..."
        End Try
    End Sub

    Private Sub LoadDataStokPeringatan()
        LoadStokPeringatan(1) ' Default threshold 5
    End Sub

    Private Sub btnFilterStok_Click(sender As Object, e As EventArgs) Handles btnFilterStok.Click
        Dim threshold As Integer
        If Integer.TryParse(txtFilterStok.Text, threshold) Then
            LoadStokPeringatan(threshold)
        Else
            MessageBox.Show("Masukkan angka yang valid")
            LoadStokPeringatan(1) ' Kembali ke default
        End If
    End Sub

    Private Sub btnUnduhStokPeringatan_Click(sender As Object, e As EventArgs) Handles btnUnduhStokPeringatan.Click
        ' Implementasi unduh PDF stok peringatan
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf"
        saveFileDialog.FileName = $"Laporan_Stok_Peringatan_{DateTime.Now:yyyyMMdd}.pdf"
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = saveFileDialog.FileName
            ExportStokPeringatanToPdf(filePath)
        End If
    End Sub

    Private Sub ExportStokPeringatanToPdf(filePath As String)
        ' Implementasi export data stok peringatan ke PDF
        Using document As New Document(PageSize.A4, 50, 50, 25, 25)
            PdfWriter.GetInstance(document, New FileStream(filePath, FileMode.Create))
            document.Open()

            ' Tambahkan nama apotek dan alamat
            Dim namaApotek As New Paragraph("APOTEK MF", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18))
            namaApotek.Alignment = Element.ALIGN_CENTER
            document.Add(namaApotek)

            Dim alamatApotek As New Paragraph("Telagamurni, Kec. Cikarang Bar., Kabupaten Bekasi, Jawa Barat 17530", FontFactory.GetFont(FontFactory.HELVETICA, 12))
            alamatApotek.Alignment = Element.ALIGN_CENTER
            document.Add(alamatApotek)
            document.Add(New Paragraph(" "))

            ' Judul
            Dim title As New Paragraph("LAPORAN STOK RENDAH", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24))
            title.Alignment = Element.ALIGN_CENTER
            document.Add(title)
            document.Add(New Paragraph(" "))

            ' Ambil threshold dari TextBox
            Dim threshold As Integer = 5
            Integer.TryParse(txtFilterStok.Text, threshold)

            Dim lines = rtbStokPeringatan.Text.Split({vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
            Dim items As New List(Of (String, String, Integer))()

            For i As Integer = 0 To lines.Length - 1 Step 3
                If i + 2 >= lines.Length Then Exit For

                ' Parsing nama obat (hilangkan nomor)
                Dim namaLine = lines(i)
                Dim namaObat = If(namaLine.Contains("."), namaLine.Substring(namaLine.IndexOf(".") + 1).Trim(), namaLine)

                ' Parsing stok
                Dim stokLine = lines(i + 1)
                Dim stokStr = stokLine.Replace("Stok:", "").Trim().Split(" ")(0)
                Dim stok As Integer
                Integer.TryParse(stokStr, stok)

                ' Parsing satuan (jika ada)
                Dim satuan = If(stokLine.Contains(" "), stokLine.Substring(stokLine.LastIndexOf(" ")).Trim(), "")

                items.Add((namaObat, satuan, stok))
            Next

            ' Buat tabel
            Dim table As New PdfPTable(3) ' Nama Obat, Satuan, Jumlah Stok
            table.WidthPercentage = 100
            table.SetWidths(New Single() {60, 20, 20})

            ' Header tabel
            Dim headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11)
            table.AddCell(New Phrase("NAMA OBAT", headerFont))
            table.AddCell(New Phrase("SATUAN", headerFont))
            table.AddCell(New Phrase("STOK", headerFont))

            ' Ambil data langsung dari database
            Using conn As New SQLiteConnection("Data Source=apotek.db;Version=3;")
                conn.Open()
                Dim query = "SELECT NamaObat, Satuan, JumlahStok FROM Obat WHERE JumlahStok <= @Threshold ORDER BY JumlahStok ASC"

                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Threshold", threshold)

                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            ' Nama Obat
                            table.AddCell(New Phrase(reader("NamaObat").ToString()))

                            ' Satuan
                            Dim satuanCell = New PdfPCell(New Phrase(reader("Satuan").ToString()))
                            satuanCell.HorizontalAlignment = Element.ALIGN_CENTER
                            table.AddCell(satuanCell)

                            ' Stok dengan warna
                            Dim stok = Convert.ToInt32(reader("JumlahStok"))
                            Dim stokText = If(stok = 0, "HABIS", stok.ToString())
                            Dim stokPhrase = New Phrase(stokText)
                            Dim stokCell = New PdfPCell(stokPhrase)
                            stokCell.HorizontalAlignment = Element.ALIGN_CENTER

                            If stok = 0 Then
                                stokCell.BackgroundColor = New BaseColor(255, 150, 150) ' Merah lebih gelap untuk HABIS
                                stokPhrase.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.RED)
                            ElseIf stok <= 3 Then
                            stokCell.BackgroundColor = New BaseColor(255, 200, 200) ' Merah muda
                                stokPhrase.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.RED)
                            ElseIf stok <= 5 Then
                                stokCell.BackgroundColor = New BaseColor(255, 235, 200) ' Oranye muda
                                stokPhrase.Font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.ORANGE)
                            End If

                            table.AddCell(stokCell)
                        End While
                    End Using
                End Using
            End Using

            document.Add(table)
            document.Close()
        End Using
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class