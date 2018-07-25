using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetHost : NetworkBehaviour {

    bool Startup = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Number of players = " + Network.connections.Length);
	}

    public void Host()
    {
        if (Startup)
        {
            
            NetworkServer.Listen(7777);
            Debug.Log("Hosting...");

        }
    }
    
}
