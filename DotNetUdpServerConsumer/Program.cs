using System.Reflection;
using UdpServerCppWrapper;


namespace DotNetUdpServerConsumer;

public class Program
{
    public static List<string> myList = new List<string>();

    public static void Main()
    {
        try
        {
            var u = new UdpServerCppApi();
            
            Task.Run(() => Console.WriteLine($"- {u.CreteNewListener(8888)} -"));

            Thread.Sleep(5000);

            while (true && u.GetSize() > 0)
            {
                myList.Add(u.GetMessage());
            }

            var duplicates = myList
                .GroupBy(x => x)
                .ToList();

            Console.WriteLine(myList.Count);

            u.CloseListener();

            Console.WriteLine("ok");

            //var v = new UdpServerCppApi();

            //Task.Run(() => Console.WriteLine($"- {v.CreteNewListener(8888)} -"));

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }


    }
}