using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {

        var client = new TcpClient("127.0.0.1", 5000);
        var ns = client.GetStream();
        byte[] questionBuffer = new byte[1024];
        int qBytes = ns.Read(questionBuffer, 0, questionBuffer.Length);
        Console.WriteLine("Server says: " + Encoding.UTF8.GetString(questionBuffer, 0, qBytes));
        string choice = Console.ReadLine();
        ns.Write(Encoding.UTF8.GetBytes(choice));
        Console.Write("Enter the temperature value: ");
        string value = Console.ReadLine();
        ns.Write(Encoding.UTF8.GetBytes(value));
        byte[] resultBuffer = new byte[1024];
        int rBytes = ns.Read(resultBuffer, 0, resultBuffer.Length);
        Console.WriteLine("\nResult: " + Encoding.UTF8.GetString(resultBuffer, 0, rBytes));
        ns.Close();


        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}