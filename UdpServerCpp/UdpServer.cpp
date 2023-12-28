#include "pch.h"
#include "UdpServer.h"

using namespace std;

#pragma comment(lib,"ws2_32.lib") // Winsock Library

#pragma warning(disable:4996) 

queue<string> q;

// create a socket
SOCKET server_socket;

#define BUFLEN 1024 * 4

void CreateListener(int port) {

    system("title UDP Server");

    sockaddr_in server, client;

    // initialise winsock
    WSADATA wsa;

    printf("Initialising Winsock...");

    if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0)
    {
        printf("Failed. Error Code: %d", WSAGetLastError());

        exit(0);
    }

    printf("Initialised.\n");


    if ((server_socket = socket(AF_INET, SOCK_DGRAM, 0)) == INVALID_SOCKET)
    {
        printf("Could not create socket: %d", WSAGetLastError());
    }

    cout << "Socket created on port: " << port << ".\n";

    //  IPv4 socket address
    server.sin_family = AF_INET;

    // allowing it to receive UDP packets sent to any IP address
    server.sin_addr.s_addr = INADDR_ANY;

    server.sin_port = htons(port);

    // bind
    if (bind(server_socket, (sockaddr*)&server, sizeof(server)) == SOCKET_ERROR)
    {
        printf("Bind failed with error code: %d", WSAGetLastError());

        exit(EXIT_FAILURE);
    }

    puts("Bind done.");

    while (1)
    {
        char message[BUFLEN] = {};

        int message_len;

        int slen = sizeof(sockaddr_in);

        if (message_len = recvfrom(server_socket, message, BUFLEN, 0, (sockaddr*)&client, &slen) == SOCKET_ERROR)
        {
            printf("recvfrom() failed with error code: %d", WSAGetLastError());

            exit(0);
        }

        q.push(message);
    }

    WSACleanup();
}

void CloseSocket() {

    closesocket(server_socket);

    WSACleanup();
}

int GetQueueSize() {
    return q.size();
}

void GetReceivedMessage(LPSTR msg) {

    string message = q.front();

    strcpy(msg, message.c_str());

    q.pop();

}








