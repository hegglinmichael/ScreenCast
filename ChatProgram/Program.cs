// dotnet new console
// dotnet run

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatProgram
{
    public class Server {

        TcpListener server = null;

        private IPAddress localAddr = null;
        private String username = "Anonymous Andy";
        private int port = 30001;

        public static void Main(String[] args) {

            Console.WriteLine("Starting Server");  
            Server myServer = new Server();
            myServer.recieve();

        }

        /*
        * This method is mean to recieve data
        * on the specified port.
        */
        public void recieve() {

            try {
                Console.WriteLine("Chat server is listening on port: 30001");

                // creating the tcp listener obj
                Console.WriteLine("\tCreating a new server obj");
                localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);

                // starting the server
                Console.WriteLine("\tStarting the Server");
                server.Start();

                // creating buffer for reading data
                Byte[] buffer = new Byte[256];
                // the data that is recieved
                String data = null;
                
                // listening loop
                while(true) {
                    Console.WriteLine("Waiting for a connection");
                    // blocking call
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine(username + " Connected!");

                    // putting this here to zero the data again
                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while((i = stream.Read(buffer, 0, buffer.Length)) != 0) {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(buffer, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        // Process the data sent by the client.
                        // data = data.ToUpper();
                        // byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                        // Send back a response.
                        // stream.Write(msg, 0, msg.Length);
                        // Console.WriteLine("Sent: {0}", data);
                    }

                    // Shutdown and end connection
                    client.Close();
                }

            } catch (Exception e) {
                Console.WriteLine("The server has failed");
                Console.WriteLine(e.Message);
            } finally {
                server.Stop();
            }
        }
    }
}
