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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principale))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Cerca = New System.Windows.Forms.TextBox()
        Me.Btn_Cerca = New System.Windows.Forms.Button()
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
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Lsv_Risultati = New System.Windows.Forms.ListView()
        Me.TimerVelocità = New System.Windows.Forms.Timer(Me.components)
        Me.Chk_IncludeAll = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(206, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Keyword(s) to search for"
        '
        'Txt_Cerca
        '
        Me.Txt_Cerca.Location = New System.Drawing.Point(13, 27)
        Me.Txt_Cerca.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Txt_Cerca.Name = "Txt_Cerca"
        Me.Txt_Cerca.Size = New System.Drawing.Size(427, 28)
        Me.Txt_Cerca.TabIndex = 0
        '
        'Btn_Cerca
        '
        Me.Btn_Cerca.Location = New System.Drawing.Point(447, 26)
        Me.Btn_Cerca.Name = "Btn_Cerca"
        Me.Btn_Cerca.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Cerca.TabIndex = 1
        Me.Btn_Cerca.Text = "S&earch"
        Me.Btn_Cerca.UseVisualStyleBackColor = True
        '
        'Lbl_Risultati
        '
        Me.Lbl_Risultati.Location = New System.Drawing.Point(315, 73)
        Me.Lbl_Risultati.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Risultati.Name = "Lbl_Risultati"
        Me.Lbl_Risultati.Size = New System.Drawing.Size(205, 15)
        Me.Lbl_Risultati.TabIndex = 0
        Me.Lbl_Risultati.Text = "Results"
        Me.Lbl_Risultati.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Chk_Seleziona
        '
        Me.Chk_Seleziona.AutoSize = True
        Me.Chk_Seleziona.Location = New System.Drawing.Point(15, 69)
        Me.Chk_Seleziona.Name = "Chk_Seleziona"
        Me.Chk_Seleziona.Size = New System.Drawing.Size(182, 26)
        Me.Chk_Seleziona.TabIndex = 2
        Me.Chk_Seleziona.Text = "Check/uncheck all"
        Me.Chk_Seleziona.UseVisualStyleBackColor = True
        '
        'Txt_SalvaIn
        '
        Me.Txt_SalvaIn.Location = New System.Drawing.Point(13, 404)
        Me.Txt_SalvaIn.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Txt_SalvaIn.Name = "Txt_SalvaIn"
        Me.Txt_SalvaIn.Size = New System.Drawing.Size(403, 28)
        Me.Txt_SalvaIn.TabIndex = 4
        '
        'Btn_SalvaIn
        '
        Me.Btn_SalvaIn.Location = New System.Drawing.Point(423, 403)
        Me.Btn_SalvaIn.Name = "Btn_SalvaIn"
        Me.Btn_SalvaIn.Size = New System.Drawing.Size(99, 23)
        Me.Btn_SalvaIn.TabIndex = 5
        Me.Btn_SalvaIn.Text = "&Save to..."
        Me.Btn_SalvaIn.UseVisualStyleBackColor = True
        '
        'Pb_Download
        '
        Me.Pb_Download.Location = New System.Drawing.Point(50, 513)
        Me.Pb_Download.Name = "Pb_Download"
        Me.Pb_Download.Size = New System.Drawing.Size(472, 10)
        Me.Pb_Download.TabIndex = 5
        '
        'Pb_Canzone
        '
        Me.Pb_Canzone.Location = New System.Drawing.Point(50, 546)
        Me.Pb_Canzone.Name = "Pb_Canzone"
        Me.Pb_Canzone.Size = New System.Drawing.Size(472, 15)
        Me.Pb_Canzone.TabIndex = 5
        '
        'Lbl_Download
        '
        Me.Lbl_Download.AutoSize = True
        Me.Lbl_Download.Location = New System.Drawing.Point(51, 495)
        Me.Lbl_Download.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Download.Name = "Lbl_Download"
        Me.Lbl_Download.Size = New System.Drawing.Size(52, 22)
        Me.Lbl_Download.TabIndex = 0
        Me.Lbl_Download.Text = "Song"
        '
        'Lbl_Canzone
        '
        Me.Lbl_Canzone.AutoSize = True
        Me.Lbl_Canzone.Location = New System.Drawing.Point(51, 528)
        Me.Lbl_Canzone.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Canzone.Name = "Lbl_Canzone"
        Me.Lbl_Canzone.Size = New System.Drawing.Size(60, 22)
        Me.Lbl_Canzone.TabIndex = 0
        Me.Lbl_Canzone.Text = "Album"
        '
        'Btn_Scarica
        '
        Me.Btn_Scarica.Enabled = False
        Me.Btn_Scarica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Scarica.Location = New System.Drawing.Point(12, 431)
        Me.Btn_Scarica.Name = "Btn_Scarica"
        Me.Btn_Scarica.Size = New System.Drawing.Size(510, 23)
        Me.Btn_Scarica.TabIndex = 6
        Me.Btn_Scarica.Text = "&Download!"
        Me.Btn_Scarica.UseVisualStyleBackColor = True
        '
        'Lbl_Album
        '
        Me.Lbl_Album.AutoSize = True
        Me.Lbl_Album.Location = New System.Drawing.Point(51, 567)
        Me.Lbl_Album.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Album.Name = "Lbl_Album"
        Me.Lbl_Album.Size = New System.Drawing.Size(51, 22)
        Me.Lbl_Album.TabIndex = 0
        Me.Lbl_Album.Text = "Total"
        '
        'Pb_Album
        '
        Me.Pb_Album.Location = New System.Drawing.Point(50, 584)
        Me.Pb_Album.Name = "Pb_Album"
        Me.Pb_Album.Size = New System.Drawing.Size(472, 15)
        Me.Pb_Album.TabIndex = 5
        '
        'Lnk_Info
        '
        Me.Lnk_Info.AutoSize = True
        Me.Lnk_Info.Location = New System.Drawing.Point(485, 4)
        Me.Lnk_Info.Name = "Lnk_Info"
        Me.Lnk_Info.Size = New System.Drawing.Size(66, 22)
        Me.Lnk_Info.TabIndex = 7
        Me.Lnk_Info.TabStop = True
        Me.Lnk_Info.Text = "(?) Info"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.VideoGamesMusic_Downloader.My.Resources.Resources.downloader_arrow_icon
        Me.PictureBox3.Location = New System.Drawing.Point(12, 491)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox3.TabIndex = 8
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.VideoGamesMusic_Downloader.My.Resources.Resources.musique_icon
        Me.PictureBox2.Location = New System.Drawing.Point(12, 529)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 567)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'Lsv_Risultati
        '
        Me.Lsv_Risultati.CheckBoxes = True
        Me.Lsv_Risultati.HideSelection = False
        Me.Lsv_Risultati.Location = New System.Drawing.Point(12, 91)
        Me.Lsv_Risultati.Name = "Lsv_Risultati"
        Me.Lsv_Risultati.Size = New System.Drawing.Size(510, 292)
        Me.Lsv_Risultati.TabIndex = 3
        Me.Lsv_Risultati.UseCompatibleStateImageBehavior = False
        '
        'TimerVelocità
        '
        Me.TimerVelocità.Enabled = True
        Me.TimerVelocità.Interval = 1000
        '
        'Chk_IncludeAll
        '
        Me.Chk_IncludeAll.Location = New System.Drawing.Point(12, 457)
        Me.Chk_IncludeAll.Name = "Chk_IncludeAll"
        Me.Chk_IncludeAll.Size = New System.Drawing.Size(510, 20)
        Me.Chk_IncludeAll.TabIndex = 9
        Me.Chk_IncludeAll.Text = "Download all available formats"
        Me.Chk_IncludeAll.UseVisualStyleBackColor = True
        '
        'Principale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 611)
        Me.Controls.Add(Me.Chk_IncludeAll)
        Me.Controls.Add(Me.Lsv_Risultati)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Lnk_Info)
        Me.Controls.Add(Me.Btn_Scarica)
        Me.Controls.Add(Me.Pb_Album)
        Me.Controls.Add(Me.Pb_Canzone)
        Me.Controls.Add(Me.Pb_Download)
        Me.Controls.Add(Me.Chk_Seleziona)
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
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_Cerca As TextBox
    Friend WithEvents Btn_Cerca As Button
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
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Lsv_Risultati As ListView
    Friend WithEvents TimerVelocità As Timer
    Friend WithEvents Chk_IncludeAll As CheckBox
End Class
