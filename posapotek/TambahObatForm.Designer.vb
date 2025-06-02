<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TambahObatForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.txtNamaObat = New System.Windows.Forms.TextBox()
        Me.txtSatuan = New System.Windows.Forms.TextBox()
        Me.txtHargaJual = New System.Windows.Forms.TextBox()
        Me.txtHargaModal = New System.Windows.Forms.TextBox()
        Me.txtKeuntungan = New System.Windows.Forms.TextBox()
        Me.txtNoBatch = New System.Windows.Forms.TextBox()
        Me.txtKategoriObat = New System.Windows.Forms.TextBox()
        Me.txtJumlahStok = New System.Windows.Forms.TextBox()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBarcode
        '
        Me.txtBarcode.Location = New System.Drawing.Point(150, 50)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(200, 20)
        Me.txtBarcode.TabIndex = 0
        '
        'txtNamaObat
        '
        Me.txtNamaObat.Location = New System.Drawing.Point(150, 80)
        Me.txtNamaObat.Name = "txtNamaObat"
        Me.txtNamaObat.Size = New System.Drawing.Size(200, 20)
        Me.txtNamaObat.TabIndex = 1
        '
        'txtSatuan
        '
        Me.txtSatuan.Location = New System.Drawing.Point(150, 110)
        Me.txtSatuan.Name = "txtSatuan"
        Me.txtSatuan.Size = New System.Drawing.Size(200, 20)
        Me.txtSatuan.TabIndex = 2
        '
        'txtHargaJual
        '
        Me.txtHargaJual.Location = New System.Drawing.Point(150, 140)
        Me.txtHargaJual.Name = "txtHargaJual"
        Me.txtHargaJual.Size = New System.Drawing.Size(200, 20)
        Me.txtHargaJual.TabIndex = 3
        '
        'txtHargaModal
        '
        Me.txtHargaModal.Location = New System.Drawing.Point(150, 170)
        Me.txtHargaModal.Name = "txtHargaModal"
        Me.txtHargaModal.Size = New System.Drawing.Size(200, 20)
        Me.txtHargaModal.TabIndex = 4
        '
        'txtKeuntungan
        '
        Me.txtKeuntungan.Location = New System.Drawing.Point(150, 200)
        Me.txtKeuntungan.Name = "txtKeuntungan"
        Me.txtKeuntungan.ReadOnly = True
        Me.txtKeuntungan.Size = New System.Drawing.Size(200, 20)
        Me.txtKeuntungan.TabIndex = 5
        '
        'txtNoBatch
        '
        Me.txtNoBatch.Location = New System.Drawing.Point(150, 230)
        Me.txtNoBatch.Name = "txtNoBatch"
        Me.txtNoBatch.Size = New System.Drawing.Size(200, 20)
        Me.txtNoBatch.TabIndex = 6
        Me.txtNoBatch.Text = "NULL"
        '
        'txtKategoriObat
        '
        Me.txtKategoriObat.Location = New System.Drawing.Point(150, 260)
        Me.txtKategoriObat.Name = "txtKategoriObat"
        Me.txtKategoriObat.Size = New System.Drawing.Size(200, 20)
        Me.txtKategoriObat.TabIndex = 7
        '
        'txtJumlahStok
        '
        Me.txtJumlahStok.Location = New System.Drawing.Point(150, 290)
        Me.txtJumlahStok.Name = "txtJumlahStok"
        Me.txtJumlahStok.Size = New System.Drawing.Size(200, 20)
        Me.txtJumlahStok.TabIndex = 8
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(150, 340)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(100, 30)
        Me.btnSimpan.TabIndex = 9
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Barcode:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Nama Obat:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Satuan:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Harga Jual:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Harga Modal:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Keuntungan:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 230)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "No Batch:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(30, 260)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Kategori Obat:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(30, 290)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Jumlah Stok:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.GhostWhite
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnSimpan)
        Me.GroupBox1.Controls.Add(Me.txtJumlahStok)
        Me.GroupBox1.Controls.Add(Me.txtKategoriObat)
        Me.GroupBox1.Controls.Add(Me.txtNoBatch)
        Me.GroupBox1.Controls.Add(Me.txtKeuntungan)
        Me.GroupBox1.Controls.Add(Me.txtHargaModal)
        Me.GroupBox1.Controls.Add(Me.txtHargaJual)
        Me.GroupBox1.Controls.Add(Me.txtSatuan)
        Me.GroupBox1.Controls.Add(Me.txtNamaObat)
        Me.GroupBox1.Controls.Add(Me.txtBarcode)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 400)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tambah Obat"
        '
        'TambahObatForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(424, 424)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TambahObatForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tambah Obat"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents txtNamaObat As TextBox
    Friend WithEvents txtSatuan As TextBox
    Friend WithEvents txtHargaJual As TextBox
    Friend WithEvents txtHargaModal As TextBox
    Friend WithEvents txtKeuntungan As TextBox
    Friend WithEvents txtNoBatch As TextBox
    Friend WithEvents txtKategoriObat As TextBox
    Friend WithEvents txtJumlahStok As TextBox
    Friend WithEvents btnSimpan As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox1 As GroupBox
End Class