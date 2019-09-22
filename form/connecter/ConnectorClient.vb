Imports System.Net.Sockets
Imports System.Threading
Imports System.Text.Encoding

Public Class ConnectorClient
    Private clientSocket As TcpClient
    Event RecievedMessage(ByVal str As String)

    Public Sub New()
        connect("127.0.0.1", 8080)
    End Sub
    Public Sub New(Port As Integer)
        connect("127.0.0.1", Port)
    End Sub

    Public Sub New(Ip As String, Port As Integer)
        connect(Ip, Port)
    End Sub



    ' Verbinden
    Private Sub connect(Ip As String, Port As Integer)
        ' Erstellt Socket mit IP und Port
        Me.clientSocket = New TcpClient(Ip, Port)
        Console.WriteLine("Client")
        ' Wartet auf Nachrichten(unendlich)
        recieveThread()
    End Sub

    ' Neuen Threat erstellen
    Private Function recieveThread() As Thread
        Dim t = New Thread(AddressOf recieveThreadSub)
        t.Start()
        Return t
    End Function

    Private Async Sub recieveThreadSub()
        While True
            ' Gibt Nachricht als Event weiter
            RaiseEvent RecievedMessage(Await recieve())
        End While
    End Sub

    Public Sub disconnect()
        clientSocket.Close()
    End Sub

    ' Nachrichten senden
    Public Async Sub send(msg As String)

        ' Verbindung
        Dim serverStream As NetworkStream = clientSocket.GetStream()
        ' Nachricht in Bytes umwandeln
        Dim outStream As Byte() = ASCII.GetBytes(msg & "$")

        ' senden
        Await serverStream.WriteAsync(outStream, 0, outStream.Length)
        Await serverStream.FlushAsync()
    End Sub

    ' Nachrichten bekommen
    Private Async Function recieve() As Task(Of String)
        Dim serverStream As NetworkStream = clientSocket.GetStream()
        Dim inStream(clientSocket.ReceiveBufferSize) As Byte
        ' Nachrichten einlesen
        Await serverStream.ReadAsync(inStream, 0, clientSocket.ReceiveBufferSize)
        ' In String umwandeln
        Return ASCII.GetString(inStream)
    End Function

End Class
