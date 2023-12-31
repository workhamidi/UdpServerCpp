using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpSender;

public class Program
{
    public Socket udp = new Socket(
        AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);


    public static string payload =
        @"
            testtesttesttesttesttesttesttesttesttesttesttesttest
            testtesttesttesttesttesttesttesttesttesttesttesttest
            testtesttesttesttesttesttesttesttesttesttesttesttest
            testtesttesttesttesttesttesttesttesttesttesttesttest
            testtesttesttesttesttesttesttesttesttesttesttesttest
            testtesttesttesttesttesttesttesttesttesttesttesttest
            testtesttesttesttesttesttesttesttesttesttesttesttest
            testtesttesttesttesttesttesttesttesttesttesttesttest
            testtesttesttesttesttesttesttesttesttesttesttesttest
            testtesttesttesttesttesttesttesttesttesttesttesttest
            testtesttesttesttesttesttesttesttesttesttesttesttest
           ";

    public int range = 1_000;

    public void Sender()
    {
        var i = 0;

        var ip = IPAddress.Parse("127.0.0.1");

        var end = new IPEndPoint(ip, 8888);

        for (i = 0; i < range; i++)
        {
            var payloadBytes = Encoding.ASCII.GetBytes(
                payload + Guid.NewGuid().ToString());

            udp.SendTo(payloadBytes, end);
        }

        Console.WriteLine(i);
    }

    public static void Main()
    {
        Thread.Sleep(3000);

        var a = new Program();

        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);

        

        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);

        

        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);

        

        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);

        

        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);

        

        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);
        Task.Run(a.Sender);


        Console.ReadKey();
    }
}