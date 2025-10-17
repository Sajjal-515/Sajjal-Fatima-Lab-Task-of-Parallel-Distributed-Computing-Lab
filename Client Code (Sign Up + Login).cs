using System;
using System.Net.Sockets;
using System.Text;

class AuthClient
{
    static void Main()
    {
        Console.WriteLine("=== Auth Client ===");

        while (true)
        {
            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine(); 

            Console.WriteLine("\nSelect Option:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Signup");
            Console.WriteLine("3. Exit");
            Console.Write("Choice: ");
            string choice = Console.ReadLine()?.Trim();

            string action = choice switch
            {
                "1" => "LOGIN",
                "2" => "SIGNUP",
                "3" => "EXIT",
                _ => ""
            };

            if (action == "EXIT")
            {
                Console.WriteLine("Exiting...");
                break;
            }

            if (action == "")
            {
                Console.WriteLine("Invalid choice. Try again.");
                continue;
            }

            Console.Write("Username: ");
            string user = Console.ReadLine()?.Trim();
            Console.Write("Password: ");
            string pass = Console.ReadLine()?.Trim();
            try
            {
                using var c = new TcpClient("127.0.0.1", 5000);
                using var ns = c.GetStream();

                string message = $"{action},{user},{pass}";
                ns.Write(Encoding.UTF8.GetBytes(message));

                byte[] buf = new byte[256];
                int n = ns.Read(buf);
                string response = Encoding.UTF8.GetString(buf, 0, n);

                Console.WriteLine("\nServer Response: " + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }}}}



            


