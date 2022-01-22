Imports System.ComponentModel
Imports System.Net
Imports System.Text.RegularExpressions

Public Class Principale

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CLB_Risultati.DoubleBuffering(True)

            Pb_Album.DoubleBuffering(True)
            Pb_Canzone.DoubleBuffering(True)
            Pb_Download.DoubleBuffering(True)

            Lbl_Album.DoubleBuffering(True)
            Lbl_Canzone.DoubleBuffering(True)
            Lbl_Download.DoubleBuffering(True)

            Lbl_Album.Text = String.Empty
            Lbl_Canzone.Text = String.Empty
            Lbl_Download.Text = String.Empty
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
            For I As Integer = 0 To CLB_Risultati.Items.Count - 1
                CLB_Risultati.SetItemChecked(I, Chk_Seleziona.Checked)
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

            If CLB_Risultati.CheckedItems.Count = 0 Then
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
        CLB_Risultati.InvocaMetodoSicuro(Sub() CLB_Risultati.Enabled = Not SpengiIcosi)
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
                               Dim Corpo As String = Regex.Matches(HTMLRicerca, "EchoTopic([\s\S]*?)<\/div>")(0).Value

                               'CLB_Risultati.InvocaMetodoSicuro(Sub() CLB_Risultati.Items.Clear())
                               Dim RisList As New Dictionary(Of String, String)

                               For Each Ris As Match In Regex.Matches(Corpo, "<a href=""(?<LINK>[\s\S]*?)"">(?<NOME>[\s\S]*?)<\/a>")
                                   Dim RawLink As String = Ris.Groups("LINK").Value.Trim
                                   Dim RawNome As String = Ris.Groups("NOME").Value.Trim

                                   RisList.Add(RawLink, RawNome)
                               Next

                               Lbl_Risultati.InvocaMetodoSicuro(Sub() Lbl_Risultati.Text = "Risultati ricerca (" & RisList.Count & ")")

                               CLB_Risultati.InvocaMetodoSicuro(Sub() CLB_Risultati.DataSource = RisList.ToList)
                               CLB_Risultati.InvocaMetodoSicuro(Sub() CLB_Risultati.DisplayMember = "Value")
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

                               Pb_Album.InvocaMetodoSicuro(Sub() Pb_Album.Maximum = CLB_Risultati.CheckedItems.Count)

                               For S As Integer = 0 To CLB_Risultati.CheckedItems.Count - 1

                                   Dim CreaUnaVariabileLocaleMah As Integer = S
                                   Dim SelItem As KeyValuePair(Of String, String) = CLB_Risultati.CheckedItems(S)

                                   Lbl_Album.InvocaMetodoSicuro(Sub() Lbl_Album.Text =
                                                                    String.Format("[{0} / {1}] {2}", CreaUnaVariabileLocaleMah + 1, CLB_Risultati.CheckedItems.Count, SelItem.Value))

                                   Dim HTMLPagina As String = OttieniHTML(SitoBase & SelItem.Key)

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

    Private Function OttieniHTML(Query As String) As String
        Try
            Dim UriSito As Uri = Nothing
            Dim TheHTML As String = String.Empty
            Uri.TryCreate(Query, UriKind.RelativeOrAbsolute, UriSito)

            Using WC As New WebClientWithTimeout
                WC.Headers.Add(Net.HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36")
                WC.Encoding = System.Text.Encoding.UTF8
                WC.CachePolicy = New System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore)
                WC.Timeout = 30000
                WC.KeepAlive = True
                TheHTML = WC.DownloadStringTaskAsync(UriSito).Result
            End Using

            Return TheHTML
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


#Region " Downloader "

    Dim TCS As TaskCompletionSource(Of Boolean)

    Private Sub Cliente_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Try
            Pb_Download.InvocaMetodoSicuro(Sub() Pb_Download.Value = e.ProgressPercentage)
            Lbl_Download.InvocaMetodoSicuro(Sub() Lbl_Download.Text = String.Format("Download in corso ... {0} / {1}", e.BytesReceived.ToSize(2), e.TotalBytesToReceive.ToSize(2)))
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
