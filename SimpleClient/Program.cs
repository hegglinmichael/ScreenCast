using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;

namespace SimpleClient
{
    public class Client
    {
        // this is the port the server is listening on
        private int port = 30001;
        // This is the tcp client obj
        private TcpClient client = null;
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Client!");
            Client myClient = new Client();

            while(true) {
                Console.WriteLine("Enter a message:");
                // Create a string variable and get user input from the keyboard and store it in the variable
                string message = Console.ReadLine();
                // get the byte array of the screen capture
                Byte[] singleImage = myClient.captureScreen();
                // sending byte array to tcp client
                myClient.send("127.0.0.1", singleImage);
            }
        }

        /*
         * This method captures an image from the screen
         * and translates it into a byte array.  This byte array
         * will be sent to the server to display
         */
        public Byte[] captureScreen() {
            PrintScreen ps = new PrintScreen();

            try {
                ps.captureScreen();
            } catch (Exception e) {

            }

            Console.WriteLine("Failed to take image!\nSending nothing");
            return new Byte[0];
        }

        /*
         * This method sends data from the client to the
         * server. Sends the data in a byte array.
         */
        public void send(String server, Byte[] image) {
            try {
                client = new TcpClient(server, port);
                // Translate the passed message into ASCII and store it as a Byte array.
                // Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                NetworkStream stream = client.GetStream();
                // Send the message to the connected TcpServer.
                stream.Write(image, 0, image.Length);

                Console.WriteLine("Sent Screenshot!");
                // Close everything.
                stream.Close();
                client.Close();
            } catch (Exception e) {
                Console.WriteLine("Failed to send message");
                Console.WriteLine(e.Message);
            }
        }
    }
}



