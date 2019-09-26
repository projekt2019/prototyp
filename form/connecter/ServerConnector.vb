Imports System.Net.Sockets
Imports System.Net
Imports System.Text.Encoding

Public Class ServerConnector
    Private serverSocket As TcpListener
    ' Liste aller verbundener Clients
    Private ReadOnly _sockets As New List(Of TcpClient)

    ' Getter für Client Array
    Public ReadOnly Property Sockets() As TcpClient()
        Get
            Return _sockets.ToArray()
        End Get
    End Property

    ' recieve Event
    Private recieveHandler As Action(Of String, TcpClient)

    Public WriteOnly Property OnRecieve() As Action(Of String, TcpClient)
        Set(value As Action(Of String, TcpClient))
            recieveHandler = value
        End Set
    End Property

    ' connect Event
    Private connectionHandler As Action(Of TcpClient)

    Public WriteOnly Property OnConnection() As Action(Of TcpClient)
        Set(value As Action(Of TcpClient))
            connectionHandler = value
        End Set
    End Property

    ' disconnect Event
    Private closingHandler As Action(Of TcpClient)

    Public WriteOnly Property OnClose() As Action(Of TcpClient)
        Set(value As Action(Of TcpClient))
            closingHandler = value
        End Set
    End Property

    Private Ip As String = "0.0.0.0"
    Private Port As Integer = 8080

    ' Konstruktoren
    Public Sub New()

    End Sub
    Public Sub New(_port As Integer)
        Port = _port
    End Sub
    Public Sub New(_Ip As String, _Port As Integer)
        Ip = _Ip
        Port = _Port
    End Sub

    ' Verbinden(mit IP und Port)
    Public Sub connect()

        ' Neuer Listener
        serverSocket = New TcpListener(IPAddress.Parse(Ip), Port)
        ' Startet Server
        serverSocket.Start()
        Console.WriteLine("Server läuft auf " & Ip & ":" & Port)
        While True
            ' sucht nach neuem client
            Dim clientSocket As TcpClient = serverSocket.AcceptTcpClient()
            ' fügt client zu der Liste hinzu
            If connectionHandler IsNot Nothing Then
                connectionHandler(clientSocket)
            End If

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
            Dim result As String
            Try
                ' Gibt Event aus

                result = Await recieve(client)

            Catch ex As Exception
                closeConnection(client)
            Finally
                result = result.Trim()
                If recieveHandler IsNot Nothing Then
                    recieveHandler(result, client)
                End If
            End Try

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
        Dim inStream(sender.ReceiveBufferSize) As Byte
        ' Nachrichten einlesen
        Await serverStream.ReadAsync(inStream, 0, sender.ReceiveBufferSize)
        Console.WriteLine(sender.ReceiveBufferSize)
        ' In String umwandeln
        Return ASCII.GetString(inStream)
    End Function

    ' beendet eine Verbindung
    Public Sub closeConnection(client As TcpClient)
        If closingHandler IsNot Nothing Then
            closingHandler(client)
        End If
        _sockets.Remove(client)
        client.Close()
        client.Dispose()
    End Sub

    ' beendet alle Verbindungen
    Public Sub closeConnections()
        For Each client In Sockets
            closeConnection(client)
        Next
    End Sub

    ' beendet alle Verbindungen und stoppt Server
    Public Sub disconnect()
        closeConnections()
        serverSocket.Stop()
    End Sub

End Class
