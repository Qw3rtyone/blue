using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class NetManager : MonoBehaviour {

    public bool isAtStartup = true;
    public NetworkIdentity prefab;
    NetworkClient myClient;

    public void Host()
    {
        if (isAtStartup)
        {
            SetupServer();
            SetupLocalClient();
        }
    }
    public void Join()
    {
        if(isAtStartup)
        {
            SetupClient();
        }
    }

    void SetupServer()
    {
        NetworkServer.Listen(4444);
        isAtStartup = false;
        NetworkServer.RegisterHandler(MsgType.AddPlayer, AddPlayerServer);

    }
    public void AddPlayerServer(NetworkMessage Netmsg)
    {
        var n = Netmsg.ReadMessage<AddPlayerMessage>();
        GameObject go = Instantiate(Resources.Load("Prefabs/NetPlayer")) as GameObject;
        NetworkServer.AddPlayerForConnection(Netmsg.conn, go, n.playerControllerId);

    }
    void SetupClient()
    {
        ClientScene.RegisterPrefab(Resources.Load("Prefabs/NetPlayer") as GameObject);
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.Connect("localhost", 4444);
        isAtStartup = false;
    }

    void SetupLocalClient()
    {
        myClient = ClientScene.ConnectLocalServer();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        isAtStartup = false;
    }

    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected");
        ClientScene.Ready(netMsg.conn);
        ClientScene.AddPlayer(1);
    }

    void Update()
    {
        Debug.Log("Number of players = " + Network.connections.Length);
    }
}
