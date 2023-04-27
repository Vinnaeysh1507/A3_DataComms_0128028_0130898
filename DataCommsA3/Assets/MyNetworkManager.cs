using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    public override void OnClientConnect()
    {
        base.OnClientConnect();
        Debug.Log("I connected to the server");
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        MyNetworkPlayer player = conn.identity.GetComponent<MyNetworkPlayer>();

        player.setDisplayName($"Player {numPlayers}");

        Color displayColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        
        if(numPlayers == 1)
        {
            player.setDisplayColor(Color.blue);
        }
        else if(numPlayers == 2)
        {
            player.setDisplayColor(Color.red);
        }
        else
        {
            player.setDisplayColor(displayColor);
        }
    }
}
