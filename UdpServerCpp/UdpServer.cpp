#include "pch.h"
#include "UdpServer.h"


using namespace std;

#pragma comment(lib,"ws2_32.lib") // Winsock Library

#pragma warning(disable:4996) 

queue<string> q;

mutex g_num_mutex;

// create a socket
SOCKET server_socket;

// initialise winsock
WSADATA wsa;

#define BUFLEN 1024 * 4

char* CreateListener(int port) {

	system("title UDP Server");

	sockaddr_in server, client;

	cout << "Initialising Winsock...\n";

	if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0)
	{
		printf("Failed. Error Code: %d", WSAGetLastError());

		exit(0);
	}

	cout << "Initialised.\n";

	if ((server_socket = socket(AF_INET, SOCK_DGRAM, 0)) == INVALID_SOCKET)
		return  (char*)"Could not create socket: " + WSAGetLastError();


	cout << "Socket created on port: " << port << ".\n";

	//  IPv4 socket address
	server.sin_family = AF_INET;

	// allowing it to receive UDP packets sent to any IP address
	server.sin_addr.s_addr = INADDR_ANY;

	server.sin_port = htons(port);

	// bind
	if (bind(server_socket, (sockaddr*)&server, sizeof(server)) == SOCKET_ERROR)
		return  (char*)"Could not create socket: " + WSAGetLastError();

	cout << "Bind done.\n";

	while (1)
	{
		char message[BUFLEN] = {};

		int message_len;

		int slen = sizeof(sockaddr_in);

		if (message_len = recvfrom(server_socket, message, BUFLEN, 0, (sockaddr*)&client, &slen) == SOCKET_ERROR)
			return  (char*)"recvfrom() failed with error code: " + WSAGetLastError();

		g_num_mutex.lock();

		q.push(message);

		g_num_mutex.unlock();
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

	g_num_mutex.lock();

	string message;

	if (q.size() == 0)
	{
		strcpy(msg, message.c_str());
	}
	else 
	{
		message = q.front();

		strcpy(msg, message.c_str());

		q.pop();
	}

	g_num_mutex.unlock();
}
