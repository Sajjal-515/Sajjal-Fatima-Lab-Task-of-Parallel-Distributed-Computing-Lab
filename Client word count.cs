using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {

        var client = new TcpClient("127.0.0.1", 5000);
        var ns = client.GetStream();
        Console.WriteLine("Enter a sentence to count words:");
        string input = Console.ReadLine();
        byte[] dataToSend = Encoding.UTF8.GetBytes(input);
        ns.Write(dataToSend, 0, dataToSend.Length);
        byte[] buffer = new byte[4096];
        int bytesRead = ns.Read(buffer, 0, buffer.Length);
        string result = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Console.WriteLine("\nServer Response: " + result);
        ns.Close();


        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}