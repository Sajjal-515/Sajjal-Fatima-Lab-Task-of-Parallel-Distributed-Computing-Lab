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
        Console.WriteLine("Temperature Converter Server is active...");

        while (true)
        {
            using (var client = listener.AcceptTcpClient())
            using (var ns = client.GetStream())
            {
                string question = "Is your temperature in (C)elsius or (F)ahrenheit? Type C or F:";
                ns.Write(Encoding.UTF8.GetBytes(question));
                byte[] typeBuffer = new byte[10];
                int typeBytes = ns.Read(typeBuffer, 0, typeBuffer.Length);
                string choice = Encoding.UTF8.GetString(typeBuffer, 0, typeBytes).ToUpper().Trim();
                byte[] valBuffer = new byte[1024];
                int valBytes = ns.Read(valBuffer, 0, valBuffer.Length);
                string valInput = Encoding.UTF8.GetString(valBuffer, 0, valBytes);
                if (double.TryParse(valInput, out double temp))
                {
                    string result;
                    if (choice == "C")
                    {
                        double f = (temp * 9 / 5) + 32;
                        result = $"{temp}°C is equal to {f:F2}°F";
                    }
                    else if (choice == "F")
                    {
                        double c = (temp - 32) * 5 / 9;
                        result = $"{temp}°F is equal to {c:F2}°C";
                    }
                    else
                    {
                        result = "Error: Invalid selection. Use 'C' or 'F'.";
                    }
                    ns.Write(Encoding.UTF8.GetBytes(result));
                }
                else
                {
                    ns.Write(Encoding.UTF8.GetBytes("Error: Invalid numeric value."));
                }
            }
        }
    }
}