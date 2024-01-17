using System.Runtime.InteropServices;
using System.Text;

namespace UdpServerCppWrapper;

public class UdpServerCppApi
{
    private const string DllFilePath
        = @"D:\projects\.net\UdpServer\x64\Debug\UdpServerCpp.dll";

    [DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr CreateListener(int port);


    [DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
    private static extern void CloseSocket();
    

    [DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
    private static extern void GetReceivedMessage(StringBuilder sMsg);
    

    [DllImport(DllFilePath, CallingConvention = CallingConvention.Cdecl)]
    private static extern int GetQueueSize();

    public string CreteNewListener(int port) =>
        Marshal.PtrToStringAnsi(CreateListener(port))!;

    public void CloseListener() => CloseSocket();

    public int GetSize() => GetQueueSize();
    
    public string GetMessage()
    {
        if (GetQueueSize() == 0) return String.Empty;

        var msg = new StringBuilder(1024);

        GetReceivedMessage(msg);

        var tempStr = msg.ToString();

        if (string.IsNullOrEmpty(tempStr)) return String.Empty;

        return tempStr;
    }
}