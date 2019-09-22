Imports System.Net.Sockets
Imports System.Net
Imports System.Text.Encoding

Public Class ConnectorServer
    Private serverSocket As TcpListener
    ' Liste aller verbundener Clients
    Private ReadOnly _sockets As New List(Of TcpClient)

    ' Getter für Client Array
    Public ReadOnly Property Sockets() As TcpClient()
        Get
            Return _sockets.ToArray()
        End Get
    End Property

    ' Event für empfangende Nachricht
    Public Event RecievedMessage(ByVal str As String, ByRef socket As TcpClient)

    ' Konstruktoren
    Public Sub New()
        connect("0.0.0.0", 8080)
    End Sub
    Public Sub New(port As Integer)
        connect("0.0.0.0", port)
    End Sub
    Public Sub New(Ip As String, Port As Integer)
        connect(Ip, Port)
    End Sub

    ' Verbinden(mit IP und Port)
    Public Sub connect(Ip As String, Port As Integer)

        ' Neuer Listener
        serverSocket = New TcpListener(IPAddress.Parse(Ip), Port)
        ' Startet Server
        serverSocket.Start()
        While True
            ' sucht nach neuem client
            Dim clientSocket As TcpClient = serverSocket.AcceptTcpClient()
            ' fügt client zu der Liste hinzu
            RaiseEvent RecievedMessage("Neuer Client!", clientSocket)
            _sockets.Add(clientSocket)
            awaitMessage(clientSocket)
        End While

    End Sub

    Private Sub AcceptClient(ByVal ar As IAsyncResult)
        Dim clientSocket As TcpClient = serverSocket.EndAcceptTcpClient(ar)
        _sockets.Add(clientSocket)
        awaitMessage(clientSocket)
        serverSocket.BeginAcceptTcpClient(New AsyncCallback(AddressOf AcceptClient), serverSocket)
    End Sub

    ' Wartet Asynchron auf Nachricht
    Private Async Sub awaitMessage(client As TcpClient)
        While True
            ' Gibt Event aus
            Dim result As String = Await recieve(client)
            RaiseEvent RecievedMessage(result, client)
        End While
    End Sub

    ' sendet eine Nachricht an einen Client
    Public Async Sub send(reciever As TcpClient, msg As String)
        Dim networkStream As NetworkStream = reciever.GetStream()
        Dim outStream As Byte() = ASCII.GetBytes(msg)

        Await networkStream.WriteAsync(outStream, 0, outStream.Length)
        Await networkStream.FlushAsync()
    End Sub

    ' sendet eine Nachricht an mehrere Clients
    Public Sub send(recievers As TcpClient(), msg As String)
        For Each socket In recievers
            send(socket, msg)
        Next
    End Sub

    ' sendet eine Nachricht an alle Clients
    Public Sub sendAll(msg As String)
        send(Sockets.ToArray(), msg)
    End Sub

    ' empfängt eine Nachricht asynchron
    Private Async Function recieve(sender As TcpClient) As Task(Of String)
        Dim serverStream As NetworkStream = sender.GetStream()
        Console.WriteLine("recieve")
        Dim inStream(sender.ReceiveBufferSize) As Byte
        ' Nachrichten einlesen
        Await serverStream.ReadAsync(inStream, 0, sender.ReceiveBufferSize)
        Console.WriteLine(sender.ReceiveBufferSize)
        ' In String umwandeln
        Return ASCII.GetString(inStream)
    End Function

    ' beendet eine Verbindung
    Public Sub closeConnection(client As TcpClient)
        _sockets.Remove(client)
        client.Close()
    End Sub

    ' beendet alle Verbindungen
    Public Sub closeConnections()
        For Each client In sockets
            closeConnection(client)
        Next
    End Sub

    ' beendet alle Verbindungen und stoppt Server
    Public Sub disconnect()
        closeConnections()
        serverSocket.Stop()
    End Sub

End Class
