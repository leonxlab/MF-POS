Imports System.Data.SQLite
Imports System.Diagnostics

Public Class UpdateStokForm
    Private dataTable As DataTable

    Private Sub UpdateStokForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.BringToFront()
    End Sub

    Private Sub UpdateStokForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeSearchBox()
        LoadDataObat() ' Tanpa parameter akan menampilkan semua data

        'Me.TopMost = True  ' Pastikan selalu di depan

        ' Tambahkan event handler lainnya...
        AddHandler txtHargaJual.TextChanged, AddressOf HitungKeuntungan
        AddHandler txtHargaModal.TextChanged, AddressOf HitungKeuntungan
    End Sub

    Private Sub InitializeSearchBox()
        Dim panelSearch As New Panel()
        panelSearch.Dock = DockStyle.Top
        panelSearch.Height = 40

        txtSearch = New TextBox()
        txtSearch.Location = New Point(100, 7)
        txtSearch.Width = 200
        AddHandler txtSearch.TextChanged, AddressOf SearchBarcode

        panelSearch.Controls.Add(txtSearch)

        Me.Controls.Add(panelSearch)
        Me.Controls.SetChildIndex(panelSearch, 0)

        ' Tambahkan button di InitializeSearchBox
        Dim btnClearSearch As New Button()
        btnClearSearch.Text = "X"
        btnClearSearch.Location = New Point(310, 7)
        btnClearSearch.Width = 25
        AddHandler btnClearSearch.Click, Sub()
                                             txtSearch.Text = ""
                                             LoadDataObat()
                                         End Sub
        panelSearch.Controls.Add(btnClearSearch)


    End Sub

    Private Sub SearchBarcode(sender As Object, e As EventArgs)
        Dim searchText As String = txtSearch.Text.Trim()
        LoadDataObat(searchText)
    End Sub

    Private Sub LoadDataObat(Optional searchText As String = Nothing)
        Using connection As New SQLiteConnection("Data Source=apotek.db;Version=3;")
            connection.Open()

            Dim query As String = "SELECT No, Barcode, NamaObat, Satuan, HargaJual, HargaModal, " &
                            "Keuntungan, NoBatch, KategoriObat, JumlahStok FROM Obat"

            ' Add filter if search text exists
            If Not String.IsNullOrEmpty(searchText) Then
                query &= " WHERE Barcode LIKE @SearchText"
            End If

            Using command As New SQLiteCommand(query, connection)
                If Not String.IsNullOrEmpty(searchText) Then
                    command.Parameters.AddWithValue("@SearchText", "%" & searchText & "%")
                End If

                Using adapter As New SQLiteDataAdapter(command)
                    dataTable = New DataTable()
                    adapter.Fill(dataTable)
                    DataGridView1.DataSource = dataTable
                End Using
            End Using
        End Using

        ' Ensure Action column exists
        If DataGridView1.Columns("Aksi") Is Nothing Then
            Dim aksiColumn As New DataGridViewButtonColumn()
            aksiColumn.HeaderText = "Aksi"
            aksiColumn.Name = "Aksi"
            aksiColumn.Text = "Edit"
            aksiColumn.UseColumnTextForButtonValue = True
            DataGridView1.Columns.Add(aksiColumn)
        End If

        ' Adjust column widths
        DataGridView1.Columns("No").Width = 50
        DataGridView1.Columns("Barcode").Width = 110
        DataGridView1.Columns("NamaObat").Width = 160
        DataGridView1.Columns("Satuan").Width = 50
        DataGridView1.Columns("HargaJual").Width = 100
        DataGridView1.Columns("HargaModal").Width = 100
        DataGridView1.Columns("Keuntungan").Width = 100
        DataGridView1.Columns("NoBatch").Width = 100
        DataGridView1.Columns("KategoriObat").Width = 100
        DataGridView1.Columns("JumlahStok").Width = 100
        DataGridView1.Columns("Aksi").Width = 100
    End Sub

    Private Sub btnTambahObat_Click(sender As Object, e As EventArgs) Handles btnTambahObat.Click
        ' Implementasi tambah obat
        Dim tambahObatForm As New TambahObatForm()
        tambahObatForm.ShowDialog()
        tambahObatForm.Show(Me) ' Me sebagai owner
        tambahObatForm.BringToFront()
        Me.SendToBack()
        Dim mainForm As New MainForm()
        mainForm.SendToBack()

        LoadDataObat()
    End Sub

    Private Sub btnUpdateObat_Click(sender As Object, e As EventArgs) Handles btnUpdateObat.Click
        ' Implementasi update obat
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim no As Integer = Convert.ToInt32(selectedRow.Cells("No").Value)
            UpdateObat(no)
            LoadDataObat()
        Else
            MessageBox.Show("Silakan pilih baris yang ingin diupdate.")
        End If
    End Sub

    Private Sub btnHapusObat_Click(sender As Object, e As EventArgs) Handles btnHapusObat.Click
        ' Implementasi hapus obat
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim no As Integer = Convert.ToInt32(selectedRow.Cells("No").Value)
            HapusObat(no)
            LoadDataObat()
        Else
            MessageBox.Show("Silakan pilih baris yang ingin dihapus.")
        End If
    End Sub

    Private Sub UpdateObat(no As Integer)
        Try
            ' Implementasi update obat di database
            ' Declare variables as nullable types first
            Dim hargaJual As Decimal? = Nothing
            Dim hargaModal As Decimal? = Nothing
            Dim jumlahStok As Integer? = Nothing
            Dim keuntungan As Decimal? = Nothing


            Dim barcode As String = txtBarcode.Text.Trim()
            Dim namaObat As String = txtNamaObat.Text.Trim()
            Dim satuan As String = txtSatuan.Text.Trim()

            Dim noBatch As String = txtNoBatch.Text.Trim()
            Dim kategoriObat As String = txtKategoriObat.Text.Trim()

            ' Parse harga jual with validation
            Dim tempHargaJual As Decimal
            If Not String.IsNullOrEmpty(txtHargaJual.Text) AndAlso Decimal.TryParse(txtHargaJual.Text, tempHargaJual) Then
                hargaJual = tempHargaJual
            Else
                hargaJual = Nothing
            End If

            ' Parse harga modal with validation
            Dim tempHargaModal As Decimal
            If Not String.IsNullOrEmpty(txtHargaModal.Text) AndAlso Decimal.TryParse(txtHargaModal.Text, tempHargaModal) Then
                hargaModal = tempHargaModal
            Else
                hargaModal = Nothing
            End If

            ' Parse jumlah stok with validation
            Dim tempJumlahStok As Integer
            If Not String.IsNullOrEmpty(txtJumlahStok.Text) AndAlso Integer.TryParse(txtJumlahStok.Text, tempJumlahStok) Then
                jumlahStok = tempJumlahStok
            Else
                jumlahStok = Nothing
            End If

            ' Calculate keuntungan only if both hargaJual and hargaModal have values
            If hargaJual.HasValue AndAlso hargaModal.HasValue Then
                keuntungan = hargaJual.Value - hargaModal.Value
            Else
                keuntungan = Nothing
            End If


            ' Parse jumlah stok dengan validasi
            If Not String.IsNullOrEmpty(txtJumlahStok.Text) AndAlso Integer.TryParse(txtJumlahStok.Text, jumlahStok) Then
                ' Do nothing, jumlahStok already has a value
            Else
                jumlahStok = Nothing
            End If

            Using connection As New SQLiteConnection("Data Source=apotek.db;Version=3;")
                connection.Open()
                Dim query As String = "UPDATE Obat SET "
                Dim parameters As New List(Of SQLiteParameter)()

                If Not String.IsNullOrEmpty(barcode) Then
                    query &= "Barcode=@Barcode, "
                    parameters.Add(New SQLiteParameter("@Barcode", barcode))
                End If

                If Not String.IsNullOrEmpty(namaObat) Then
                    query &= "NamaObat=@NamaObat, "
                    parameters.Add(New SQLiteParameter("@NamaObat", namaObat))
                End If

                If Not String.IsNullOrEmpty(satuan) Then
                    query &= "Satuan=@Satuan, "
                    parameters.Add(New SQLiteParameter("@Satuan", satuan))
                End If

                If hargaJual.HasValue Then
                    query &= "HargaJual=@HargaJual, "
                    parameters.Add(New SQLiteParameter("@HargaJual", hargaJual.Value))
                End If

                If hargaModal.HasValue Then
                    query &= "HargaModal=@HargaModal, "
                    parameters.Add(New SQLiteParameter("@HargaModal", hargaModal.Value))
                End If

                If keuntungan.HasValue Then
                    query &= "Keuntungan=@Keuntungan, "
                    parameters.Add(New SQLiteParameter("@Keuntungan", keuntungan.Value))
                End If

                If Not String.IsNullOrEmpty(noBatch) Then
                    query &= "NoBatch=@NoBatch, "
                    parameters.Add(New SQLiteParameter("@NoBatch", noBatch))
                End If

                If Not String.IsNullOrEmpty(kategoriObat) Then
                    query &= "KategoriObat=@KategoriObat, "
                    parameters.Add(New SQLiteParameter("@KategoriObat", kategoriObat))
                End If

                If jumlahStok.HasValue Then
                    query &= "JumlahStok=@JumlahStok, "
                    parameters.Add(New SQLiteParameter("@JumlahStok", jumlahStok.Value))
                End If

                ' Remove trailing comma and space
                If query.EndsWith(", ") Then
                    query = query.Substring(0, query.Length - 2)
                End If

                query &= " WHERE No=@No"
                parameters.Add(New SQLiteParameter("@No", no))

                Using command As New SQLiteCommand(query, connection)
                    command.Parameters.AddRange(parameters.ToArray())
                    command.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Obat berhasil diupdate.")
        Catch ex As FormatException
            MessageBox.Show("Format angka tidak valid. Harap masukkan angka yang benar.")
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message)
        End Try
    End Sub

    Private Sub HapusObat(no As Integer)
        ' Implementasi hapus obat dari database
        Using connection As New SQLiteConnection("Data Source=apotek.db;Version=3;")
            connection.Open()
            Dim query As String = "DELETE FROM Obat WHERE No=@No"
            Using command As New SQLiteCommand(query, connection)
                command.Parameters.AddWithValue("@No", no)
                command.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Obat berhasil dihapus.")
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.RowIndex >= 0 Then
            ' Isi TextBox1 (barcode) ketika baris diklik
            Dim selectedRow = DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = selectedRow.Cells("Barcode").Value.ToString()

            ' Fokus ke TextBox2 untuk memudahkan input
            TextBox2.Focus()
        End If

        If e.ColumnIndex = DataGridView1.Columns("Aksi").Index AndAlso e.RowIndex >= 0 Then
            ' Implementasi edit obat
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtBarcode.Text = selectedRow.Cells("Barcode").Value.ToString()
            txtNamaObat.Text = selectedRow.Cells("NamaObat").Value.ToString()
            txtSatuan.Text = selectedRow.Cells("Satuan").Value.ToString()
            txtHargaJual.Text = selectedRow.Cells("HargaJual").Value.ToString()
            txtHargaModal.Text = selectedRow.Cells("HargaModal").Value.ToString()
            txtKeuntungan.Text = selectedRow.Cells("Keuntungan").Value.ToString()
            txtNoBatch.Text = selectedRow.Cells("NoBatch").Value.ToString()
            txtKategoriObat.Text = selectedRow.Cells("KategoriObat").Value.ToString()
            txtJumlahStok.Text = selectedRow.Cells("JumlahStok").Value.ToString()
        End If
    End Sub

    Private Sub HitungKeuntungan(sender As Object, e As EventArgs)
        ' Initialize default values
        Dim hargaJual As Decimal = 0
        Dim hargaModal As Decimal = 0

        ' Parse harga jual dengan validasi
        If Not String.IsNullOrEmpty(txtHargaJual.Text) Then
            Decimal.TryParse(txtHargaJual.Text, hargaJual)
        End If

        ' Parse harga modal dengan validasi
        If Not String.IsNullOrEmpty(txtHargaModal.Text) Then
            Decimal.TryParse(txtHargaModal.Text, hargaModal)
        End If

        ' Calculate and display profit
        Dim keuntungan As Decimal = hargaJual - hargaModal
        txtKeuntungan.Text = keuntungan.ToString()
    End Sub

    Private Sub txtHargaJual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHargaJual.KeyPress
        ' Allow numbers, decimal point, and backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If

        ' Only allow one decimal point
        If e.KeyChar = "." AndAlso DirectCast(sender, TextBox).Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtHargaModal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHargaModal.KeyPress
        ' Same validation as above
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If

        If e.KeyChar = "." AndAlso DirectCast(sender, TextBox).Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtJumlahStok_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJumlahStok.KeyPress
        ' Allow only digits and backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validasi input
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MessageBox.Show("Barcode tidak boleh kosong!")
            Return
        End If

        If String.IsNullOrEmpty(TextBox2.Text) OrElse Not Integer.TryParse(TextBox2.Text, Nothing) Then
            MessageBox.Show("Jumlah stok harus berupa angka!")
            Return
        End If

        Dim barcode As String = TextBox1.Text.Trim()
        Dim jumlahTambah As Integer = Integer.Parse(TextBox2.Text)

        ' Update stok di database
        Try
            Using connection As New SQLiteConnection("Data Source=apotek.db;Version=3;")
                connection.Open()

                ' 1. Cek apakah obat ada
                Dim cekQuery As String = "SELECT JumlahStok FROM Obat WHERE Barcode = @Barcode"
                Dim currentStok As Integer = 0

                Using command As New SQLiteCommand(cekQuery, connection)
                    command.Parameters.AddWithValue("@Barcode", barcode)
                    Dim result = command.ExecuteScalar()

                    If result Is Nothing Then
                        MessageBox.Show("Obat dengan barcode tersebut tidak ditemukan!")
                        Return
                    End If

                    currentStok = Convert.ToInt32(result)
                End Using

                ' 2. Update stok
                Dim updateQuery As String = "UPDATE Obat SET JumlahStok = JumlahStok + @JumlahTambah WHERE Barcode = @Barcode"

                Using command As New SQLiteCommand(updateQuery, connection)
                    command.Parameters.AddWithValue("@JumlahTambah", jumlahTambah)
                    command.Parameters.AddWithValue("@Barcode", barcode)

                    Dim rowsAffected = command.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show($"Stok berhasil ditambahkan!{Environment.NewLine}Stok lama: {currentStok}{Environment.NewLine}Stok baru: {currentStok + jumlahTambah}")
                        LoadDataObat() ' Refresh datagrid
                        TextBox1.Text = ""
                        TextBox2.Text = ""
                    Else
                        MessageBox.Show("Gagal menambah stok!")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        ' Hanya memperbolehkan angka dan backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class