using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
class UDPArrayReceiver
{
static void Main()
{
var server = new UdpClient(9005);
IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
int[] receivedArr = new int[20];
int count = 0;
Console.WriteLine("Waiting for array data...");
while (true)
{
byte[] packet = server.Receive(ref ep);
if (packet.Length == 3 &&

Encoding.UTF8.GetString(packet) == "END") break;
int index = BitConverter.ToInt32(packet, 0);
int value = BitConverter.ToInt32(packet, 4);
receivedArr[index] = value;
count++;
Console.WriteLine($"Received index {index}, value
{value}");
}
Console.WriteLine($"\nTotal elements received: {count}");
Console.WriteLine("Reconstructed array:");
for (int i = 0; i < count; i++)
Console.Write(receivedArr[i] + " ");
} }