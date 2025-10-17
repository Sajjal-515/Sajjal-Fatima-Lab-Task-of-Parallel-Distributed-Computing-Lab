using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
class AuthServer
{
    static void Main()
    {
        var users = new Dictionary<string, string>
        {
            { "admin", "1234" },
            { "user", "pass" },
            { "test", "1111" }
        };
        var listener = new TcpListener(IPAddress.Any, 5000);
        listener.Start();
        Console.WriteLine("=== Auth Server Running on Port 5000 ===");
        while (true)
        {
            try
            {
                using var client = listener.AcceptTcpClient();
                using var ns = client.GetStream();

                byte[] buffer = new byte[256];
                int bytesRead = ns.Read(buffer);
                string received = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

                string[] parts = received.Split(',');
                if (parts.Length < 3)
                {
                    ns.Write(Encoding.UTF8.GetBytes("Invalid Request Format"));
                    continue;
                }
                string action = parts[0].ToUpper();
                string username = parts[1];
                string password = parts[2];
                string response;

                switch (action)
                {
                    case "LOGIN":
                        if (users.ContainsKey(username) && users[username] == password)
                            response = "Login Successful";
                        else
                            response = "Invalid Credentials";
                        break;
                    case "SIGNUP":
                        if (users.ContainsKey(username))
                            response = "Username Already Exists";
                        else
                        {
                            users[username] = password;
                            response = "Signup Successful";
                        }
                        break;

                    default:
                        response = "Unknown Command";
                        break;
                }

                ns.Write(Encoding.UTF8.GetBytes(response));
 Console.WriteLine($"{DateTime.Now:HH:mm:ss} | {action}:{username} -> {response}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }}}}


                        



