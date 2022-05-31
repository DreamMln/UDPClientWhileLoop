using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPClientWhileLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UDP Client/Sender!");
            //DETTE ER EN CLIENT MED ET WHILE LOOP, FOR AT KUNNE SENDE FLERE MESSAGES

            //initialisere UdpClient
            using (UdpClient socket = new UdpClient())
            {
                //message 
                string message = null;
                IPEndPoint endPoint = null;

                while (true)
                {
                    //readline - is input - until the user presses Enter or a newline character is found. 
                    message = Console.ReadLine();
                    //Encoding is the process of transforming a set of Unicode characters
                    byte[] dataSendsToServer = Encoding.UTF8.GetBytes(message);
                    socket.Send(dataSendsToServer, dataSendsToServer.Length, "127.0.0.1", 5005);
                    //åbner, lytter tilbage på svar
                    //linjerne nedenfor er ECHO - message bliver sendt fra client til server
                    //server sender svaret tilbage til client, derfor echo!
                    byte[] recieveDataFromServer = socket.Receive(ref endPoint);
                    string recievedMessage = Encoding.UTF8.GetString(recieveDataFromServer);
                    Console.WriteLine("Server sent this message back: " + recievedMessage);
                }
            }
        }
    }
}
