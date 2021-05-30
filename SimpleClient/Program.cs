using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SimpleClient
{
    public class Client
    {
        private int port = 30001;
        private TcpClient client = null;
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Client!");
            Client myClient = new Client();

            while(true) {
                Console.WriteLine("Enter a message:");
                // Create a string variable and get user input from the keyboard and store it in the variable
                string message = Console.ReadLine();
                myClient.send("127.0.0.1", message);
            }
        }

        public void send(String server, String message) {
            try {
                client = new TcpClient(server, port);
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                NetworkStream stream = client.GetStream();
                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);
                // Close everything.
                stream.Close();
                client.Close();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
