using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using UnityEngine.UI;

public class ClientScript : LocationService
{
    public Text Console;

    //public Text Console;
    public string SendMessageFromSocket(string message)
    {
        string answer;
        int port = 14880;

        // Буфер для входящих данных
        byte[] bytes = new byte[1024];

        // Соединяемся с удаленным устройством

        // Устанавливаем удаленную точку для сокета
        IPHostEntry ipHost = Dns.GetHostEntry("212.104.70.106");
        IPAddress ipAddr = ipHost.AddressList[0];
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

        Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        // Соединяем сокет с удаленной точкой
        sender.Connect(ipEndPoint);

        Debug.Log("Введите сообщение: ");
        // longtitudeP + " " + lattitudeP;

        Debug.Log("Сокет соединяется с {0} ");
        Debug.Log(sender.RemoteEndPoint.ToString());

        byte[] msg = Encoding.UTF8.GetBytes(message);

        // Отправляем данные через сокет
        int bytesSent = sender.Send(msg);

        // Получаем ответ от сервера
        int bytesRec = sender.Receive(bytes);

        Debug.Log("\nОтвет от сервера: {0}\n\n");
        Debug.Log(Encoding.UTF8.GetString(bytes, 0, bytesRec));

        answer = Encoding.UTF8.GetString(bytes, 0, bytesRec);

        // Используем рекурсию для неоднократного вызова SendMessageFromSocket()
        // if (message.IndexOf("<TheEnd>") == -1)
        //   SendMessageFromSocket();
        //Console.text = answer;
        // Освобождаем сокет
        sender.Shutdown(SocketShutdown.Both);
        sender.Close();

        return answer;

    }
    public string ServerMessage(string s)
    {
        string ServerMessage;
        ServerMessage = SendMessageFromSocket(s);
        return ServerMessage;
    }

    public void SendMsg()
    {
        string Send = ServerMessage("coord "+Instace.longtitudeP + " " +Instace.lattitudeP );
    }

   




}