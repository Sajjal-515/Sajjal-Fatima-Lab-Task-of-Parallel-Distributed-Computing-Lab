using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


class Server
{
    static void Main()
    {
        var listener = new TcpListener(IPAddress.Any, 5000);
        listener.Start();
        Console.WriteLine("Server is running... waiting for strings.");

        while (true)
        {
            using (var client = listener.AcceptTcpClient())
            using (var ns = client.GetStream())
            {
                byte[] data = new byte[4096];
                int bytesRead = ns.Read(data, 0, data.Length);
                string receivedText = Encoding.UTF8.GetString(data, 0, bytesRead);
                Console.WriteLine($"Received: {receivedText}");
                int wordCount = receivedText.Split(new char[] { ' ', '\t', '\n', '\r' },
                                 StringSplitOptions.RemoveEmptyEntries).Length;

                string response = $"The string contains {wordCount} words.";
                byte[] responseData = Encoding.UTF8.GetBytes(response);
                ns.Write(responseData, 0, responseData.Length);
                Console.WriteLine($"Sent word count: {wordCount}");
            }
        }
    }
}

