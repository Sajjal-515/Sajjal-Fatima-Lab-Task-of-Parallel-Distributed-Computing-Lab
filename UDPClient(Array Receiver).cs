using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
class UDPArraySender
{
static void Main()
{
int[] numbers = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100
};
var client = new UdpClient();
var serverEP = new
IPEndPoint(IPAddress.Parse("127.0.0.1"), 9005);
Console.WriteLine("Sending integer array via UDP...");
for (int i = 0; i < numbers.Length; i++)
{
byte[] packet = new byte[8]; // 4 bytes seq + 4 bytes

value

BitConverter.GetBytes(i).CopyTo(packet, 0);
BitConverter.GetBytes(numbers[i]).CopyTo(packet,

4);

client.Send(packet, packet.Length, serverEP);
Console.WriteLine($"Sent index {i}, value

{numbers[i]}");
}
client.Send(Encoding.UTF8.GetBytes("END"), 3,
serverEP);
Console.WriteLine("Array sent successfully!");
} }