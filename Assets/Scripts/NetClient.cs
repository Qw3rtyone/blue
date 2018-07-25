using UnityEngine;
using UnityEngine.Networking;

public class NetClient : NetworkBehaviour
{
    NetworkClient myClient;

    public void OnConnected(NetworkConnection conn)//, NetworkReader reader)
    {
        Debug.Log("Connected to server" + conn.address);
    }

    public void OnDisconnected(NetworkConnection conn)//, NetworkReader reader)
    {
        Debug.Log("Disconnected from server");
    }

    public void OnError()//NetworkConnection conn, NetworkReader reader)
    {
        //SystemErrorMessage errorMsg = reader.SmartRead<SystemErrorMessage>();
        Debug.Log("Error connecting with code ");// + errorMsg.errorCode);
    }

    public void Start()
    {

    }
    public void Join()
    { 
        myClient = new NetworkClient();

        //myClient.RegisterHandler(MsgType.SYSTEM_CONNECT, OnConnected);
        //myClient.RegisterHandler(MsgType.SYSTEM_DISCONNECT, OnDisconnected);
        //myClient.RegisterHandler(MsgType.SYSTEM_ERROR, OnError);

        myClient.Connect("127.0.0.1", 7777);
        Debug.Log("Connected?");
    }
}