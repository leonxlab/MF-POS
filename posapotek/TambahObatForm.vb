Imports System.Data.SQLite

Public Class TambahObatForm

    Private Sub TambahObatForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.BringToFront()
    End Sub
    Private Sub TambahObatForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tambahkan event handler untuk perubahan harga jual dan harga modal
        AddHandler txtHargaJual.TextChanged, AddressOf HitungKeuntungan
        AddHandler txtHargaModal.TextChanged, AddressOf HitungKeuntungan
    End Sub

    Private Sub HitungKeuntungan(sender As Object, e As EventArgs)
        ' Initialize default values
        Dim hargaJual As Decimal = 0
        Dim hargaModal As Decimal = 0

        ' Parse harga jual with validation
        If Not String.IsNullOrEmpty(txtHargaJual.Text) Then
            Decimal.TryParse(txtHargaJual.Text, hargaJual)
        End If

        ' Parse harga modal with validation
        If Not String.IsNullOrEmpty(txtHargaModal.Text) Then
            Decimal.TryParse(txtHargaModal.Text, hargaModal)
        End If

        ' Calculate and display profit
        Dim keuntungan As Decimal = hargaJual - hargaModal
        txtKeuntungan.Text = keuntungan.ToString()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        ' Validasi semua field wajib diisi
        If String.IsNullOrWhiteSpace(txtBarcode.Text) OrElse
       String.IsNullOrWhiteSpace(txtNamaObat.Text) OrElse
       String.IsNullOrWhiteSpace(txtSatuan.Text) OrElse
       String.IsNullOrWhiteSpace(txtHargaJual.Text) OrElse
       String.IsNullOrWhiteSpace(txtHargaModal.Text) OrElse
       String.IsNullOrWhiteSpace(txtKategoriObat.Text) OrElse
       String.IsNullOrWhiteSpace(txtJumlahStok.Text) Then

            MessageBox.Show("Semua input harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Implementasi simpan obat baru ke database
        Dim barcode As String = txtBarcode.Text.Trim()
        Dim namaObat As String = txtNamaObat.Text.Trim()
        Dim satuan As String = txtSatuan.Text.Trim()
        Dim hargaJual As Decimal = Convert.ToDecimal(txtHargaJual.Text.Trim())
        Dim hargaModal As Decimal = Convert.ToDecimal(txtHargaModal.Text.Trim())
        Dim keuntungan As Decimal = Convert.ToDecimal(txtKeuntungan.Text.Trim())
        Dim noBatch As String = txtNoBatch.Text.Trim()
        Dim kategoriObat As String = txtKategoriObat.Text.Trim()
        Dim jumlahStok As Integer = Convert.ToInt32(txtJumlahStok.Text.Trim())

        Using connection As New SQLiteConnection("Data Source=apotek.db;Version=3;")
            connection.Open()
            Dim query As String = "INSERT INTO Obat (Barcode, NamaObat, Satuan, HargaJual, HargaModal, Keuntungan, NoBatch, KategoriObat, JumlahStok) VALUES (@Barcode, @NamaObat, @Satuan, @HargaJual, @HargaModal, @Keuntungan, @NoBatch, @KategoriObat, @JumlahStok)"
            Using command As New SQLiteCommand(query, connection)
                command.Parameters.AddWithValue("@Barcode", barcode)
                command.Parameters.AddWithValue("@NamaObat", namaObat)
                command.Parameters.AddWithValue("@Satuan", satuan)
                command.Parameters.AddWithValue("@HargaJual", hargaJual)
                command.Parameters.AddWithValue("@HargaModal", hargaModal)
                command.Parameters.AddWithValue("@Keuntungan", keuntungan)
                command.Parameters.AddWithValue("@NoBatch", noBatch)
                command.Parameters.AddWithValue("@KategoriObat", kategoriObat)
                command.Parameters.AddWithValue("@JumlahStok", jumlahStok)
                command.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Obat berhasil ditambahkan.")
        Me.Close()
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

End Class