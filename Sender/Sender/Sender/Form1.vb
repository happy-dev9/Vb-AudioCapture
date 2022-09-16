Option Strict On

Imports NAudio.Wave
Imports System.Net
Imports System.Net.Sockets
Imports System.Single
Imports System.IO
Imports NAudio.CoreAudioApi.MMDevice
Imports System

Public Class Form1

    Dim TimeIt1 As New Stopwatch ' For testing
    Dim TimeIt2 As New Stopwatch ' For testing

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Sender"
        Me.Location = New Point(CInt((Screen.PrimaryScreen.WorkingArea.Width / 2) - (Me.Width / 2)), CInt((Screen.PrimaryScreen.WorkingArea.Height / 2) - (Me.Height / 2)))

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As EventArgs) Handles Me.FormClosing
        Try

        Catch ex As Exception
        End Try
        Try
            VoxViaUDPTxClient.Close()
            Application.Exit()
        Catch ex As Exception
        End Try
    End Sub

    Dim WaveData(38400) As Byte           ' Altered by input device selected in ListBox.
    Dim NumberofChannels As Integer = 2       ' Retrieved from input device selected in ListBox.
    Dim SamplingRate As Integer = 48000        ' Recommend always use this amount. Keep byte amount to send per second at 32000 bytes.


    ' VoxViaUDPTx - Start VoxViaUDPRx Listener first ___________________________________________________________________________

    Dim VoxViaUDPIPAddress As IPAddress
    Dim VoxViaUDPLogicalPortNumber As Integer = 4012
    Dim VoxViaUDPRemoteIpEndPoint As IPEndPoint
    Dim VoxViaUDPTxClient As UdpClient

    Dim BytesSent As Integer = 0

    Private Sub Stop_Transmitting_Click(sender As Object, e As EventArgs) Handles Stop_Transmitting.Click

        audioBtn.Enabled = True
        Stop_Transmitting.Enabled = False
        RecordCapture.StopRecording()

    End Sub

    Dim RecordCapture As New WasapiLoopbackCapture()
    Dim filestream As FileStream

    Private Sub audioBtn_Click(sender As Object, e As EventArgs) Handles audioBtn.Click

        audioBtn.Enabled = False

        VoxViaUDPTxClient = New UdpClient()
        VoxViaUDPTxClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, True)
        VoxViaUDPIPAddress = IPAddress.Parse(TextBox1.Text)
        VoxViaUDPTxClient.Connect(VoxViaUDPIPAddress, VoxViaUDPLogicalPortNumber)

        AddHandler RecordCapture.DataAvailable, AddressOf sourceStream_DataRecord
        RecordCapture.StartRecording()

    End Sub

    Private Sub sourceStream_DataRecord(sender As Object, e As NAudio.Wave.WaveInEventArgs)

        Dim byteRecordCountTemp As Integer = e.BytesRecorded
        Dim newArray16Bit(byteRecordCountTemp \ 2) As Byte
        Dim two As Short
        Dim value As Single

        TimeIt1.Restart()
        Dim j As Integer = 0

        For i = 0 To byteRecordCountTemp - 1 Step 4
            value = (BitConverter.ToSingle(e.Buffer, i))
            two = CType(value * Short.MaxValue, Short)
            newArray16Bit(j) = CType(two And &HFF, Byte)
            newArray16Bit(j + 1) = CType((two >> 8) And &HFF, Byte)
            j = j + 2
        Next

        Buffer.BlockCopy(newArray16Bit, 0, WaveData, 0, newArray16Bit.Length)
        ReDim Preserve WaveData(newArray16Bit.Length)

        TimeIt1.Stop()

        BytesSent = VoxViaUDPTxClient.Send(WaveData, WaveData.Count)
        ReDim Preserve WaveData(38400)

    End Sub

End Class