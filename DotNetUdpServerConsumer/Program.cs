using UdpServerCppWrapper;


namespace DotNetUdpServerConsumer;

public class Program
{
    public static List<string> myList = new List<string>();

    public static void Main()
    {
        var u = new UdpServerCppApi();

        Task.Run(() =>
        {
            u.CreteNewListener(8888);
        });

        Thread.Sleep(5000);

        while (true && u.GetSize() > 0)
        {
           myList.Add(u.GetMessage());
        }

        var duplicates = myList
            .GroupBy(x => x)
            .ToList();


        Console.WriteLine();

    }
}