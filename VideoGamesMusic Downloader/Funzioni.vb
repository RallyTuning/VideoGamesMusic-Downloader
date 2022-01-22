Imports System.IO
Imports System.Linq.Expressions
Imports System.Net
Imports System.Runtime.CompilerServices

Module Funzioni

    Friend ReadOnly SitoBase As String = "https://downloads.khinsider.com"

#Region " Thread "

    Private Delegate Sub InvokeThreadSafeMethodDelegate(ByVal control As Control, ByVal method As Expression(Of Action))
    Private Delegate Function InvokeThreadSafeFunctionDelegate(Of T)(ByVal control As Control, ByVal [function] As Expression(Of Func(Of T))) As T

    <Extension()>
    Public Sub InvocaMetodoSicuro(ByVal control As Control, ByVal method As Expression(Of Action))
        If (control.InvokeRequired) Then
            Dim del = New InvokeThreadSafeMethodDelegate(AddressOf InvocaMetodoSicuro)
            control.Invoke(del, control, method)
        Else
            method.Compile().DynamicInvoke()
        End If
    End Sub

    <Extension()>
    Public Function InvocaFunzioneSicuro(Of T)(ByVal control As Control, ByVal [function] As Expression(Of Func(Of T))) As T
        If (control.InvokeRequired) Then
            Dim del = New InvokeThreadSafeFunctionDelegate(Of T)(AddressOf InvocaFunzioneSicuro)
            Return DirectCast(control.Invoke(del, control, [function]), T)
        Else
            Return DirectCast([function].Compile().DynamicInvoke(), T)
        End If
    End Function

#End Region

    ''' <summary>
    ''' Abilita il Double Buffer sui controlli che non lo prevedono.
    ''' </summary>
    ''' <param name="Controllo">Controllo sul quale abilitare il Double Buffer.</param>
    ''' <param name="Abilita">True abilita, False disabilita.</param>
    <Extension()>
    Sub DoubleBuffering(ByVal Controllo As System.Windows.Forms.Control, ByVal Abilita As Boolean)
        Dim DoubleBufferPropertyInfo = Controllo.[GetType]().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        DoubleBufferPropertyInfo.SetValue(Controllo, Abilita, Nothing)
    End Sub

    <Extension()>
    Friend Function ToSize(ByVal Valore As Long, ByVal Optional Decimali As Integer = 0) As String
        Try
            Dim SizeSuffixes As String() = {"b", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"}

            Dim Mag As Integer = CInt(Math.Floor(Math.Log(Valore, 1024)))
            Dim AdjustedSize = Math.Round(Valore / Math.Pow(1024, Mag), Decimali)
            Return String.Format("{0} {1}", AdjustedSize, SizeSuffixes(Mag))
        Catch ex As Exception
            Return "0 bytes"
        End Try
    End Function

    Friend Class WebClientWithTimeout
        Inherits WebClient

        Friend Property Timeout As Integer = 60000
        Friend Property KeepAlive As Boolean = True

        'for sync requests
        Protected Overrides Function GetWebRequest(ByVal TheURI As Uri) As WebRequest
            Dim W = MyBase.GetWebRequest(TheURI)
            W.Timeout = Me.Timeout

            If TypeOf W Is HttpWebRequest Then
                CType(W, HttpWebRequest).KeepAlive = Me.KeepAlive
            End If

            Return W
        End Function

        'the above does not work for async requests, lets override the method
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

    Friend Function IsValidPath(ByVal ThePath As String, ByVal Optional allowRelativePaths As Boolean = False) As Boolean
        Dim isValid As Boolean

        Try
            Dim fullPath As String = Path.GetFullPath(ThePath)

            If allowRelativePaths Then
                isValid = Path.IsPathRooted(ThePath)
            Else
                Dim root As String = Path.GetPathRoot(ThePath)
                isValid = String.IsNullOrEmpty(root.Trim(New Char() {"\"c, "/"c})) = False
            End If

        Catch ex As Exception
            isValid = False
        End Try

        Return isValid
    End Function

    Friend Class Songz

        Friend Property Nome As String = String.Empty
        Friend Property Link As String = String.Empty

        Sub New(Nome As String, Link As String)
            Me.Nome = Nome
            Me.Link = Link
        End Sub
    End Class
End Module
