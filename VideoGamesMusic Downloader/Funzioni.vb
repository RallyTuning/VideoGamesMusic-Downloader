Imports System.IO
Imports System.Linq.Expressions
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions

Module Funzioni

    Friend ReadOnly SitoBase As String = "https://downloads.khinsider.com"

#Region " Thread "

    Private Delegate Sub InvokeThreadSafeMethodDelegate(ByVal Cnt As Control, ByVal Mtd As Expression(Of Action))
    Private Delegate Function InvokeThreadSafeFunctionDelegate(Of T)(ByVal Cnt As Control, ByVal Fnc As Expression(Of Func(Of T))) As T

    <Extension()>
    Public Sub InvocaMetodoSicuro(ByVal Cnt As Control, ByVal Mtd As Expression(Of Action))
        If (Cnt.InvokeRequired) Then
            Dim del = New InvokeThreadSafeMethodDelegate(AddressOf InvocaMetodoSicuro)
            Cnt.Invoke(del, Cnt, Mtd)
        Else
            Mtd.Compile().DynamicInvoke()
        End If
    End Sub

    <Extension()>
    Public Function InvocaFunzioneSicuro(Of T)(ByVal Cnt As Control, ByVal Fnc As Expression(Of Func(Of T))) As T
        If (Cnt.InvokeRequired) Then
            Dim del = New InvokeThreadSafeFunctionDelegate(Of T)(AddressOf InvocaFunzioneSicuro)
            Return DirectCast(Cnt.Invoke(del, Cnt, Fnc), T)
        Else
            Return DirectCast(Fnc.Compile().DynamicInvoke(), T)
        End If
    End Function

#End Region

    ''' <summary>
    ''' Enable the Double Buffer on any control that support it.
    ''' </summary>
    ''' <param name="Controllo">The control</param>
    ''' <param name="Abilita">Enable or disable</param>
    <Extension()>
    Sub DoubleBuffering(ByVal Controllo As System.Windows.Forms.Control, ByVal Abilita As Boolean)
        Dim DoubleBufferPropertyInfo = Controllo.[GetType]().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        DoubleBufferPropertyInfo.SetValue(Controllo, Abilita, Nothing)
    End Sub

    ''' <summary>
    ''' Convert bytes (long) in human readable strings
    ''' </summary>
    ''' <param name="Valore">Bytes to convert</param>
    ''' <param name="Decimali">Number of decimals</param>
    ''' <returns>Human readable strings</returns>
    <Extension()>
    Friend Function ToSize(ByVal Valore As Long, ByVal Optional Decimali As Integer = 0) As String
        Try
            Return CDbl(Valore).ToSize(Decimali)
        Catch ex As Exception
            Return "0 Bytes"
        End Try
    End Function

    ''' <summary>
    ''' Convert bytes (Double) in human readable strings
    ''' </summary>
    ''' <param name="Valore">Bytes to convert</param>
    ''' <param name="Decimali">Number of decimals</param>
    ''' <returns>Human readable strings</returns>
    <Extension()>
    Friend Function ToSize(ByVal Valore As Double, ByVal Optional Decimali As Integer = 0) As String
        Try
            Dim SizeSuffixes() As String = {"Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"}

            Dim Mag As Integer = CInt(Math.Floor(Math.Log(Valore, 1024)))
            Dim AdjustedSize = Math.Round(Valore / Math.Pow(1024, Mag), Decimali, MidpointRounding.AwayFromZero)

            Return String.Format("{0} {1}", AdjustedSize.ToString("N"), SizeSuffixes(Mag))
        Catch ex As Exception
            Return "0 Bytes"
        End Try
    End Function

    ''' <summary>
    ''' Controlla se la cartella già esiste, se no cerca di dargli un nome unico
    ''' </summary>
    ''' <param name="Dir">Cartella da controllare</param>
    ''' <returns>Nome cartella unica</returns>
    Public Function UniquePath(Dir As DirectoryInfo) As String
        Try
            Dim baseName = Dir.Name
            Dim parent = Dir.Parent?.FullName
            Dim u = baseName.LastIndexOf("_"c), n As Integer
            baseName = If(u >= 0 AndAlso Integer.TryParse(baseName.Substring(u + 1), n),
                          baseName.Substring(0, u), baseName)

            Dim cand = Dir.FullName
            While Directory.Exists(cand)
                n += 1
                cand = If(String.IsNullOrEmpty(parent),
                          $"{baseName}_{n}",
                          IO.Path.Combine(parent, $"{baseName}_{n}"))
            End While
            Return cand
        Catch ex As Exception
            Return Dir.FullName
        End Try
    End Function

    ''' <summary>
    ''' Controlla se il file già esiste, se no cerca di dargli un nome unico
    ''' </summary>
    ''' <param name="Fil">File da controllare</param>
    ''' <returns>Nome file unico</returns>
    Public Function UniqueFile(Fil As FileInfo) As String
        Try
            Dim dir = Fil.DirectoryName
            Dim name = IO.Path.GetFileNameWithoutExtension(Fil.Name)
            Dim ext = Fil.Extension
            Dim u = name.LastIndexOf("_"c), n As Integer
            Dim baseName = If(u >= 0 AndAlso Integer.TryParse(name.Substring(u + 1), n),
                              name.Substring(0, u), name)

            Dim cand = Fil.FullName
            While File.Exists(cand)
                n += 1
                cand = IO.Path.Combine(dir, $"{baseName}_{n}{ext}")
            End While
            Return cand
        Catch ex As Exception
            Return Fil.FullName
        End Try
    End Function

    ''' <summary>
    ''' Remove or replace any illegal char from a file name and or path
    ''' </summary>
    ''' <param name="StrInput">Input string</param>
    ''' <param name="Replacement">Char to replace with</param>
    ''' <returns>A legal string</returns>
    <Extension()>
    Friend Function RimuoviIllegal(StrInput As String, Optional Replacement As String = "") As String
        Dim RegexSearch As String = New String(Path.GetInvalidFileNameChars()) & New String(Path.GetInvalidPathChars())
        Dim RRR As New Regex(String.Format("[{0}]", Regex.Escape(RegexSearch)))
        Return RRR.Replace(StrInput, Replacement)
    End Function

    ''' <summary>
    ''' Check if a path is valid
    ''' </summary>
    ''' <param name="ThePath">Path to check</param>
    ''' <param name="AllowRelativePaths">Allow relative paths</param>
    ''' <returns>True if valid, false if not</returns>
    Friend Function IsValidPath(ByVal ThePath As String, ByVal Optional AllowRelativePaths As Boolean = False) As Boolean
        Dim IsValid As Boolean

        Try
            Dim FullPath As String = Path.GetFullPath(ThePath)

            If AllowRelativePaths Then
                IsValid = Path.IsPathRooted(ThePath)
            Else
                Dim Roota As String = Path.GetPathRoot(ThePath)
                IsValid = String.IsNullOrEmpty(Roota.Trim(New Char() {"\"c, "/"c})) = False
            End If
        Catch
            isValid = False
        End Try

        Return isValid
    End Function

    ''' <summary>
    ''' Get the HTML of a webpage
    ''' </summary>
    ''' <param name="Query">URL to get</param>
    ''' <returns>HTML in string</returns>
    Friend Function OttieniHTML(Query As String) As String
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

    ''' <summary>
    ''' Get a image from URL
    ''' </summary>
    ''' <param name="Query">URL to get</param>
    ''' <returns>The image as Image</returns>
    Friend Function OttieniImmagine(Query As String) As Image
        Try
            If String.IsNullOrWhiteSpace(Query) Then Return My.Resources.mixxx_icon

            Dim ImageInBytes() As Byte = Nothing
            Dim UriSito As Uri = Nothing
            Uri.TryCreate(Query, UriKind.RelativeOrAbsolute, UriSito)

            Using WC As New WebClientWithTimeout
                WC.Headers.Add(Net.HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36")
                WC.Encoding = System.Text.Encoding.UTF8
                WC.CachePolicy = New System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore)
                WC.Timeout = 10000
                WC.KeepAlive = True
                ImageInBytes = WC.DownloadDataTaskAsync(UriSito).Result
            End Using

            Dim ImageStream As New IO.MemoryStream(ImageInBytes)

            Return New Drawing.Bitmap(ImageStream)
        Catch ex As Exception
            Return My.Resources.mixxx_icon
        End Try
    End Function

    ''' <summary>
    ''' Split a file name and the extension
    ''' </summary>
    ''' <param name="FileName">Filename to split</param>
    ''' <returns>Return a KeyValuePair(Of String, String) with the name of the file and the extension</returns>
    Friend Function GetFileNameAndExtension(FileName As String) As KeyValuePair(Of String, String)
        Try
            Dim TempFileExt As String = FileName.Split("."c).Last
            Dim TempFileName As String = FileName.Remove(FileName.Length - TempFileExt.Length - 1, TempFileExt.Length + 1)

            Return New KeyValuePair(Of String, String)(TempFileName, TempFileExt)
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' A classic WebClient but with timeout working in Async
    ''' </summary>
    Friend Class WebClientWithTimeout
        Inherits WebClient

        Friend Property Timeout As Integer = 60000
        Friend Property KeepAlive As Boolean = True

        'For sync requests
        Protected Overrides Function GetWebRequest(ByVal TheURI As Uri) As WebRequest
            Dim W = MyBase.GetWebRequest(TheURI)
            W.Timeout = Me.Timeout

            If TypeOf W Is HttpWebRequest Then
                CType(W, HttpWebRequest).KeepAlive = Me.KeepAlive
            End If

            Return W
        End Function

        'The above does not work for async requests, lets override the method
        Friend Overloads Async Function DownloadStringTaskAsync(ByVal Address As Uri) As Task(Of String)
            Return Await RunWithTimeout(MyBase.DownloadStringTaskAsync(Address))
        End Function

        Friend Overloads Async Function UploadStringTaskAsync(ByVal Address As String, ByVal TheData As String) As Task(Of String)
            Return Await RunWithTimeout(MyBase.UploadStringTaskAsync(Address, TheData))
        End Function

        Private Async Function RunWithTimeout(Of T)(ByVal Tasko As Task(Of T)) As Task(Of T)
            If Tasko Is Await Task.WhenAny(Tasko, Task.Delay(Timeout)) Then
                Return Await Tasko
            Else
                Me.CancelAsync()
                Me.Dispose()
                Throw New TimeoutException("Timeout")
            End If
        End Function

    End Class

    ''' <summary>
    ''' Song class
    ''' </summary>
    Friend Class Song
        Friend Property Nome As String = String.Empty
        Friend Property Link As String = String.Empty

        Sub New(Nome As String, Link As String)
            Me.Nome = Nome
            Me.Link = Link
        End Sub
    End Class

End Module
