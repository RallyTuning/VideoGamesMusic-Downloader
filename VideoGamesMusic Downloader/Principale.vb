Imports System.ComponentModel
Imports System.Net
Imports System.Text.RegularExpressions

Public Class Principale

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Lsv_Risultati.DoubleBuffering(True)

            Pb_Album.DoubleBuffering(True)
            Pb_Canzone.DoubleBuffering(True)
            Pb_Download.DoubleBuffering(True)

            Lbl_Album.DoubleBuffering(True)
            Lbl_Canzone.DoubleBuffering(True)
            Lbl_Download.DoubleBuffering(True)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub Btn_Cerca_Click(sender As Object, e As EventArgs) Handles Btn_Cerca.Click
        Try
            Await AvviaRicerca()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_SalvaIn_Click(sender As Object, e As EventArgs) Handles Btn_SalvaIn.Click
        Try
            Using FBD = New FolderBrowserDialog
                FBD.Description = "Seleziona dove salvare le soundtrack"
                FBD.ShowNewFolderButton = True

                If FBD.ShowDialog(Me) = DialogResult.OK Then
                    Txt_SalvaIn.Text = FBD.SelectedPath
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Chk_Seleziona_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Seleziona.CheckedChanged
        Try
            For Each Itm As ListViewItem In Lsv_Risultati.Items
                Itm.Checked = Chk_Seleziona.Checked
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Txt_Cerca_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Cerca.KeyDown, Txt_SalvaIn.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Btn_Cerca.PerformClick()
        End If
    End Sub

    Private Sub Txt_SalvaIn_TextChanged(sender As Object, e As EventArgs) Handles Txt_SalvaIn.TextChanged
        Btn_Scarica.Enabled = Not String.IsNullOrWhiteSpace(Txt_SalvaIn.Text)
    End Sub

    Private Async Sub Btn_Scarica_Click(sender As Object, e As EventArgs) Handles Btn_Scarica.Click
        Try
            If Not IsValidPath(Txt_SalvaIn.Text.Trim) Then
                MessageBox.Show("Directory di salvataggio non valida!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If Lsv_Risultati.CheckedItems.Count = 0 Then
                MessageBox.Show("Seleziona qualcosa da scaricare!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Await AvviaEstrazione()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Lnk_Info_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_Info.LinkClicked
        MessageBox.Show("Made with ♥ by Gianluigi Capozzoli" & Environment.NewLine &
                        "www.disactive.com - www.capozzoli.me" & Environment.NewLine & Environment.NewLine &
                        "Suondtrack scaricate da https://downloads.khinsider.com" & Environment.NewLine &
                        "Ringraziate loro per l'hosting e me per l'automatizzazione :P",
                        "About that shit...", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Private Sub Spengi(SpengiIcosi As Boolean)
        Txt_Cerca.InvocaMetodoSicuro(Sub() Txt_Cerca.Enabled = Not SpengiIcosi)
        Txt_SalvaIn.InvocaMetodoSicuro(Sub() Txt_SalvaIn.Enabled = Not SpengiIcosi)
        Btn_Cerca.InvocaMetodoSicuro(Sub() Btn_Cerca.Enabled = Not SpengiIcosi)
        Btn_Scarica.InvocaMetodoSicuro(Sub() Btn_Scarica.Enabled = Not SpengiIcosi)
        Btn_SalvaIn.InvocaMetodoSicuro(Sub() Btn_SalvaIn.Enabled = Not SpengiIcosi)
        Lsv_Risultati.InvocaMetodoSicuro(Sub() Lsv_Risultati.Enabled = Not SpengiIcosi)
        Chk_Seleziona.InvocaMetodoSicuro(Sub() Chk_Seleziona.Enabled = Not SpengiIcosi)

        Pb_Album.InvocaMetodoSicuro(Sub() Pb_Album.Value = 0)
        Pb_Canzone.InvocaMetodoSicuro(Sub() Pb_Canzone.Value = 0)
        Pb_Download.InvocaMetodoSicuro(Sub() Pb_Download.Value = 0)
    End Sub

    Async Function AvviaRicerca() As Task
        Await Task.Run(Sub()
                           Try
                               Spengi(True)

                               Dim HTMLRicerca As String = OttieniHTML(SitoBase & "/search?search=" & Txt_Cerca.Text.Trim)

                               If String.IsNullOrWhiteSpace(HTMLRicerca) Then
                                   MessageBox.Show("Impossibile ottenere le informazioni", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                   Exit Sub
                               End If

                               'EchoTopic
                               Dim Corpo As String = Regex.Match(HTMLRicerca, "table.*?albumList([\s\S]*?)<\/table>").Value
                               Dim RowLst As MatchCollection = Regex.Matches(Corpo, "<tr>([\s\S]*?)<\/tr>")

                               Dim AlbumLst As New List(Of Album)

                               'For Each Ris As Match In Regex.Matches(Corpo, "<td.*?albumIcon.*?img src.*?""(?<IMMAGINE>[\s\S]*?)"">|<a href=""(?<LINK>[\s\S]*?)"">(?<NOME>[\s\S]*?)<\/a>")
                               For M As Integer = 1 To RowLst.Count - 1
                                   Dim RawImg As String = Regex.Match(RowLst(M).Value, "<td.*?albumIcon.*?img src.*?""([\s\S]*?)""").Groups(1).Value.Trim
                                   Dim RawLink As String = Regex.Match(RowLst(M).Value, "<td.*?albumIcon.*?a href.*?""([\s\S]*?)""").Groups(1).Value.Trim
                                   Dim RawNome As String = Regex.Matches(RowLst(M).Value, "a href.*?"">([\s\S]*?)<\/a>")(1).Groups(1).Value.Trim

                                   Dim AlbumImg As Image = OttieniImmagine(RawImg)

                                   AlbumLst.Add(New Album(AlbumImg, RawNome, RawLink))
                               Next

                               Lbl_Risultati.InvocaMetodoSicuro(Sub() Lbl_Risultati.Text = "Risultati ricerca (" & AlbumLst.Count & ")")

                               Lsv_Risultati.InvocaMetodoSicuro(Sub() Lsv_Risultati.BeginUpdate())
                               Lsv_Risultati.InvocaMetodoSicuro(Sub() Lsv_Risultati.Items.Clear())

                               Dim ImgLstBoh As New ImageList With {.ColorDepth = ColorDepth.Depth32Bit, .ImageSize = New Drawing.Size(60, 60)}
                               Lsv_Risultati.InvocaMetodoSicuro(Sub() Lsv_Risultati.LargeImageList = ImgLstBoh)

                               For Each Alb As Album In AlbumLst
                                   Lsv_Risultati.InvocaMetodoSicuro(Sub() ImgLstBoh.Images.Add(Alb.Immagine))

                                   Dim Itm As New ListViewItem(Alb.Nome)
                                   Itm.SubItems.Add(Alb.Link)
                                   Itm.ImageIndex = ImgLstBoh.Images.Count - 1

                                   Lsv_Risultati.InvocaMetodoSicuro(Sub() Lsv_Risultati.Items.Add(Itm))
                               Next

                               Lsv_Risultati.InvocaMetodoSicuro(Sub() Lsv_Risultati.EndUpdate())
                           Catch ex As Exception
                               MessageBox.Show(ex.ToString, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
                           Finally
                               Spengi(False)
                           End Try
                       End Sub)
    End Function

    Async Function AvviaEstrazione() As Task
        Await Task.Run(Sub()
                           Try
                               Spengi(True)

                               Dim SalvaIn As String = Txt_SalvaIn.Text.Trim
                               If Not IO.Directory.Exists(SalvaIn) Then IO.Directory.CreateDirectory(SalvaIn)

                               Pb_Album.InvocaMetodoSicuro(Sub() Pb_Album.Maximum = Lsv_Risultati.CheckedItems.Count)

                               For S As Integer = 0 To Lsv_Risultati.InvocaFunzioneSicuro(Function() Lsv_Risultati.CheckedItems.Count - 1)

                                   Dim CreaUnaVariabileLocaleMah As Integer = S
                                   'Dim SelItem As KeyValuePair(Of String, String) = Nothing ' CLB_Risultati.CheckedItems(S)
                                   Dim SelItem As ListViewItem = Lsv_Risultati.InvocaFunzioneSicuro(Function() Lsv_Risultati.CheckedItems(CreaUnaVariabileLocaleMah))

                                   Lbl_Album.InvocaMetodoSicuro(Sub() Lbl_Album.Text =
                                                                    String.Format("[{0} / {1}] {2}", CreaUnaVariabileLocaleMah + 1, Lsv_Risultati.CheckedItems.Count, SelItem.Text))

                                   Dim HTMLPagina As String = OttieniHTML(SitoBase & SelItem.SubItems(1).Text)

                                   If String.IsNullOrWhiteSpace(HTMLPagina) Then
                                       MessageBox.Show("Impossibile ottenere le informazioni", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                       Exit Sub
                                   End If

                                   Dim Tabella As String = Regex.Matches(HTMLPagina, "table.*?songlist.*?>([\s\S]*?)<\/table>")(0).Value

                                   Dim SongMatches As MatchCollection = Regex.Matches(Tabella, "row""><a href=""(?<LINK>[\s\S]*?)"">(?<NOME>[\s\S]*?)<\/a>")

                                   Pb_Canzone.InvocaMetodoSicuro(Sub() Pb_Canzone.Maximum = SongMatches.Count)

                                   For M As Integer = 0 To SongMatches.Count - 1

                                       Dim CreaUnaVariabileLocaleMahIlRitorno As Integer = M
                                       Dim Ris As Match = SongMatches(M)

                                       Lbl_Canzone.InvocaMetodoSicuro(Sub() Lbl_Canzone.Text =
                                                                          String.Format("[{0} / {1}] {2}", CreaUnaVariabileLocaleMahIlRitorno + 1, SongMatches.Count, Ris.Groups(2).Value))

                                       Dim HTMLSong As String = OttieniHTML(SitoBase & Ris.Groups(1).Value)

                                       If String.IsNullOrWhiteSpace(HTMLSong) Then
                                           MessageBox.Show("Impossibile ottenere le informazioni", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                           Exit Sub
                                       End If

                                       Dim AlbumName As String
                                       Try
                                           AlbumName = Regex.Matches(HTMLSong, "Album name.*?>([\s\S]*?)<")(0).Groups(1).Value
                                       Catch
                                           AlbumName = "Album sconosciuto"
                                       End Try

                                       Dim SongName As String
                                       Try
                                           SongName = Regex.Matches(HTMLSong, "Song name.*?>([\s\S]*?)<")(0).Groups(1).Value
                                       Catch ex As Exception
                                           SongName = "Titolo sconosciuto"
                                       End Try

                                       Dim SongLink As String = Regex.Matches(HTMLSong, "<audio.*?src=""([\s\S]*?)"".*?audio>")(0).Groups(1).Value

                                       'Estensione
                                       Dim sTemp As String = SongLink.Split("."c).Last
                                       If Not SongName.EndsWith(sTemp) Then
                                           SongName &= "." & sTemp
                                       End If

                                       If Not IO.Directory.Exists(SalvaIn & "\" & AlbumName) Then IO.Directory.CreateDirectory(SalvaIn & "\" & AlbumName)

                                       AvviaDownload(SongLink, SalvaIn & "\" & AlbumName & "\" & SongName).Wait()

                                       Pb_Canzone.InvocaMetodoSicuro(Sub() Pb_Canzone.Value = CreaUnaVariabileLocaleMahIlRitorno + 1)
                                   Next

                                   Pb_Album.InvocaMetodoSicuro(Sub() Pb_Album.Value = CreaUnaVariabileLocaleMah + 1)
                               Next

                               MessageBox.Show("Tutto scaricato!", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information)

                               'Qua perchè nel finally li cancella anche se da' errore, e non va bene... devi vedere dove si è fermato
                               Lbl_Download.InvocaMetodoSicuro(Sub() Lbl_Album.Text = String.Empty)
                               Lbl_Canzone.InvocaMetodoSicuro(Sub() Lbl_Canzone.Text = String.Empty)
                               Lbl_Download.InvocaMetodoSicuro(Sub() Lbl_Download.Text = String.Empty)
                           Catch ex As Exception
                               MessageBox.Show(ex.ToString, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
                           Finally
                               Spengi(False)
                           End Try
                       End Sub)
    End Function

#Region " Downloader "

    Dim TCS As TaskCompletionSource(Of Boolean)

    Private Sub Cliente_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Try
            Pb_Download.InvocaMetodoSicuro(Sub() Pb_Download.Value = e.ProgressPercentage)
            Lbl_Download.InvocaMetodoSicuro(Sub() Lbl_Download.Text = String.Format("Download in corso... {0} / {1}", e.BytesReceived.ToSize(2), e.TotalBytesToReceive.ToSize(2)))
        Catch
        End Try
    End Sub

    Private Sub Cliente_DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        TCS.SetResult(True)
        Pb_Download.InvocaMetodoSicuro(Sub() Pb_Download.Value = 0)
        Lbl_Download.InvocaMetodoSicuro(Sub() Lbl_Download.Text = "Caricamento...")
    End Sub

    Private Async Function AvviaDownload(TheLink As String, TheName As String) As Task
        Try
            Using Cliente As New WebClient
                AddHandler Cliente.DownloadProgressChanged, AddressOf Cliente_DownloadProgressChanged
                AddHandler Cliente.DownloadFileCompleted, AddressOf Cliente_DownloadFileCompleted

                TCS = New TaskCompletionSource(Of Boolean)

                Cliente.DownloadFileAsync(New Uri(TheLink), TheName)
                Await TCS.Task
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TCS = Nothing
        End Try
    End Function


#End Region

End Class
