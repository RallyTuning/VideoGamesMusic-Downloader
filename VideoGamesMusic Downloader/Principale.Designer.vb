<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principale
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Cerca = New System.Windows.Forms.TextBox()
        Me.Btn_Cerca = New System.Windows.Forms.Button()
        Me.CLB_Risultati = New System.Windows.Forms.CheckedListBox()
        Me.Lbl_Risultati = New System.Windows.Forms.Label()
        Me.Chk_Seleziona = New System.Windows.Forms.CheckBox()
        Me.Txt_SalvaIn = New System.Windows.Forms.TextBox()
        Me.Btn_SalvaIn = New System.Windows.Forms.Button()
        Me.Pb_Download = New System.Windows.Forms.ProgressBar()
        Me.Pb_Canzone = New System.Windows.Forms.ProgressBar()
        Me.Lbl_Download = New System.Windows.Forms.Label()
        Me.Lbl_Canzone = New System.Windows.Forms.Label()
        Me.Btn_Scarica = New System.Windows.Forms.Button()
        Me.Lbl_Album = New System.Windows.Forms.Label()
        Me.Pb_Album = New System.Windows.Forms.ProgressBar()
        Me.Lnk_Info = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Parola/e chiave da cercare"
        '
        'Txt_Cerca
        '
        Me.Txt_Cerca.Location = New System.Drawing.Point(13, 27)
        Me.Txt_Cerca.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Txt_Cerca.Name = "Txt_Cerca"
        Me.Txt_Cerca.Size = New System.Drawing.Size(427, 21)
        Me.Txt_Cerca.TabIndex = 1
        '
        'Btn_Cerca
        '
        Me.Btn_Cerca.Location = New System.Drawing.Point(447, 26)
        Me.Btn_Cerca.Name = "Btn_Cerca"
        Me.Btn_Cerca.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Cerca.TabIndex = 2
        Me.Btn_Cerca.Text = "&Cerca"
        Me.Btn_Cerca.UseVisualStyleBackColor = True
        '
        'CLB_Risultati
        '
        Me.CLB_Risultati.FormattingEnabled = True
        Me.CLB_Risultati.Location = New System.Drawing.Point(12, 91)
        Me.CLB_Risultati.Name = "CLB_Risultati"
        Me.CLB_Risultati.Size = New System.Drawing.Size(510, 292)
        Me.CLB_Risultati.TabIndex = 3
        '
        'Lbl_Risultati
        '
        Me.Lbl_Risultati.Location = New System.Drawing.Point(315, 73)
        Me.Lbl_Risultati.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Risultati.Name = "Lbl_Risultati"
        Me.Lbl_Risultati.Size = New System.Drawing.Size(205, 15)
        Me.Lbl_Risultati.TabIndex = 0
        Me.Lbl_Risultati.Text = "Risultati ricerca"
        Me.Lbl_Risultati.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Chk_Seleziona
        '
        Me.Chk_Seleziona.AutoSize = True
        Me.Chk_Seleziona.Location = New System.Drawing.Point(15, 69)
        Me.Chk_Seleziona.Name = "Chk_Seleziona"
        Me.Chk_Seleziona.Size = New System.Drawing.Size(173, 19)
        Me.Chk_Seleziona.TabIndex = 4
        Me.Chk_Seleziona.Text = "Seleziona/deseleziona tutti"
        Me.Chk_Seleziona.UseVisualStyleBackColor = True
        '
        'Txt_SalvaIn
        '
        Me.Txt_SalvaIn.Location = New System.Drawing.Point(13, 404)
        Me.Txt_SalvaIn.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Txt_SalvaIn.Name = "Txt_SalvaIn"
        Me.Txt_SalvaIn.Size = New System.Drawing.Size(427, 21)
        Me.Txt_SalvaIn.TabIndex = 1
        '
        'Btn_SalvaIn
        '
        Me.Btn_SalvaIn.Location = New System.Drawing.Point(447, 403)
        Me.Btn_SalvaIn.Name = "Btn_SalvaIn"
        Me.Btn_SalvaIn.Size = New System.Drawing.Size(75, 23)
        Me.Btn_SalvaIn.TabIndex = 2
        Me.Btn_SalvaIn.Text = "&Salva in..."
        Me.Btn_SalvaIn.UseVisualStyleBackColor = True
        '
        'Pb_Download
        '
        Me.Pb_Download.Location = New System.Drawing.Point(12, 504)
        Me.Pb_Download.Name = "Pb_Download"
        Me.Pb_Download.Size = New System.Drawing.Size(510, 23)
        Me.Pb_Download.TabIndex = 5
        '
        'Pb_Canzone
        '
        Me.Pb_Canzone.Location = New System.Drawing.Point(12, 548)
        Me.Pb_Canzone.Name = "Pb_Canzone"
        Me.Pb_Canzone.Size = New System.Drawing.Size(510, 15)
        Me.Pb_Canzone.TabIndex = 5
        '
        'Lbl_Download
        '
        Me.Lbl_Download.AutoSize = True
        Me.Lbl_Download.Location = New System.Drawing.Point(13, 486)
        Me.Lbl_Download.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Download.Name = "Lbl_Download"
        Me.Lbl_Download.Size = New System.Drawing.Size(147, 15)
        Me.Lbl_Download.TabIndex = 0
        Me.Lbl_Download.Text = "Download in corso ... 0 / 0"
        '
        'Lbl_Canzone
        '
        Me.Lbl_Canzone.AutoSize = True
        Me.Lbl_Canzone.Location = New System.Drawing.Point(13, 530)
        Me.Lbl_Canzone.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Canzone.Name = "Lbl_Canzone"
        Me.Lbl_Canzone.Size = New System.Drawing.Size(123, 15)
        Me.Lbl_Canzone.TabIndex = 0
        Me.Lbl_Canzone.Text = "[0 / 0] Nome canzone"
        '
        'Btn_Scarica
        '
        Me.Btn_Scarica.Enabled = False
        Me.Btn_Scarica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Scarica.Location = New System.Drawing.Point(12, 447)
        Me.Btn_Scarica.Name = "Btn_Scarica"
        Me.Btn_Scarica.Size = New System.Drawing.Size(510, 23)
        Me.Btn_Scarica.TabIndex = 6
        Me.Btn_Scarica.Text = "Scarica &Tutto!"
        Me.Btn_Scarica.UseVisualStyleBackColor = True
        '
        'Lbl_Album
        '
        Me.Lbl_Album.AutoSize = True
        Me.Lbl_Album.Location = New System.Drawing.Point(13, 566)
        Me.Lbl_Album.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Album.Name = "Lbl_Album"
        Me.Lbl_Album.Size = New System.Drawing.Size(111, 15)
        Me.Lbl_Album.TabIndex = 0
        Me.Lbl_Album.Text = "[0 / 0] Nome album"
        '
        'Pb_Album
        '
        Me.Pb_Album.Location = New System.Drawing.Point(12, 584)
        Me.Pb_Album.Name = "Pb_Album"
        Me.Pb_Album.Size = New System.Drawing.Size(510, 15)
        Me.Pb_Album.TabIndex = 5
        '
        'Lnk_Info
        '
        Me.Lnk_Info.AutoSize = True
        Me.Lnk_Info.Location = New System.Drawing.Point(485, 4)
        Me.Lnk_Info.Name = "Lnk_Info"
        Me.Lnk_Info.Size = New System.Drawing.Size(45, 15)
        Me.Lnk_Info.TabIndex = 7
        Me.Lnk_Info.TabStop = True
        Me.Lnk_Info.Text = "(?) Info"
        '
        'Principale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 611)
        Me.Controls.Add(Me.Lnk_Info)
        Me.Controls.Add(Me.Btn_Scarica)
        Me.Controls.Add(Me.Pb_Album)
        Me.Controls.Add(Me.Pb_Canzone)
        Me.Controls.Add(Me.Pb_Download)
        Me.Controls.Add(Me.Chk_Seleziona)
        Me.Controls.Add(Me.CLB_Risultati)
        Me.Controls.Add(Me.Btn_SalvaIn)
        Me.Controls.Add(Me.Btn_Cerca)
        Me.Controls.Add(Me.Txt_SalvaIn)
        Me.Controls.Add(Me.Txt_Cerca)
        Me.Controls.Add(Me.Lbl_Risultati)
        Me.Controls.Add(Me.Lbl_Album)
        Me.Controls.Add(Me.Lbl_Canzone)
        Me.Controls.Add(Me.Lbl_Download)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "Principale"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VideoGameMusic Downloader"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_Cerca As TextBox
    Friend WithEvents Btn_Cerca As Button
    Friend WithEvents CLB_Risultati As CheckedListBox
    Friend WithEvents Lbl_Risultati As Label
    Friend WithEvents Chk_Seleziona As CheckBox
    Friend WithEvents Txt_SalvaIn As TextBox
    Friend WithEvents Btn_SalvaIn As Button
    Friend WithEvents Pb_Download As ProgressBar
    Friend WithEvents Pb_Canzone As ProgressBar
    Friend WithEvents Lbl_Download As Label
    Friend WithEvents Lbl_Canzone As Label
    Friend WithEvents Btn_Scarica As Button
    Friend WithEvents Lbl_Album As Label
    Friend WithEvents Pb_Album As ProgressBar
    Friend WithEvents Lnk_Info As LinkLabel
End Class
