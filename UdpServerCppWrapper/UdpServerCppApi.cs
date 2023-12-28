using System.Runtime.InteropServices;
using System.Text;

namespace UdpServerCppWrapper;

public class UdpServerCppApi
{
    private const string DllFilePath
        = @"C:\Users\mm\Desktop\UdpServer\x64\Debug\UdpServerCpp.dll";

    [DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
    private extern static void CreateListener(int port);


    [DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
    private extern static void CloseSocket();


    //[DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
    //private extern static IntPtr GetReceivedMessage();


    [DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
    private extern static void GetReceivedMessage(StringBuilder sMsg);




    [DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
    private extern static int GetQueueSize();

    public void CreteNewListener(int port) => CreateListener(port);

    public void CloseListener() => CloseSocket();

    public int GetSize() => GetQueueSize();


    public string GetMessage()
    {
        if (GetQueueSize() > 0)
            //return Marshal.PtrToStringAnsi(GetReceivedMessage())!;
        {
            StringBuilder msg = new StringBuilder(1024);
            GetReceivedMessage(msg);
            return msg.ToString();
        }

        return String.Empty;
    }
}