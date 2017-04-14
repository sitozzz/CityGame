using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Net.Sockets;
public class ClientScriptV2 : MonoBehaviour
{


    internal Boolean socketReady = false;

    TcpClient mySocket;
    NetworkStream theStream;
    StreamWriter theWriter;
    StreamReader theReader;
    String Host = "198.57.44.231";
    Int32 Port = 1337;
    string channel = "testingSona";



    public void setupSocket()
    {
        try
        {
            mySocket = new TcpClient(Host, Port);
            theStream = mySocket.GetStream();
            theWriter = new StreamWriter(theStream);
            theReader = new StreamReader(theStream);
            socketReady = true;
        }
        catch (Exception e)
        {
            Debug.Log("Socket error: " + e);
        }
    }
    public void writeSocket(string theLine)
    {
        if (!socketReady)
            return;
        String foo = theLine + "\r\n";
        theWriter.Write(foo);
        theWriter.Flush();

    }
    public String readSocket()
    {
        if (!socketReady)
            return "";
        try
        {
            return theReader.ReadLine();
        }
        catch (Exception e)
        {
            return "";
        }
    }
        

    
    public void closeSocket()
    {
        if (!socketReady)
            return;
        theWriter.Close();
        theReader.Close();
        mySocket.Close();
        socketReady = false;
    }
}