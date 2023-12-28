#include <iostream>
#include <winsock2.h>
#include <algorithm>
#include <windows.h>
#include <thread>
#include <queue>


extern "C" {

    __declspec(dllexport) void CreateListener(int port);

    __declspec(dllexport) void CloseSocket();

    __declspec(dllexport) void GetReceivedMessage(LPSTR msg);

    __declspec(dllexport) int GetQueueSize();

}