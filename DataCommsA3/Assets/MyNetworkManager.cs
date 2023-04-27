using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    [SerializeField] private Transform[] spawnPoint = new Transform[8];

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

        if (numPlayers == 1)
        {
            player.setSpawnPoint(spawnPoint[0]);
        }
        else if (numPlayers == 2)
        {
            player.setSpawnPoint(spawnPoint[1]);
        }
        else if (numPlayers == 3)
        {
            player.setSpawnPoint(spawnPoint[2]);
        }
        else if (numPlayers == 4)
        {
            player.setSpawnPoint(spawnPoint[3]);
        }
        else if (numPlayers == 5)
        {
            player.setSpawnPoint(spawnPoint[4]);
        }
        else if (numPlayers == 6)
        {
            player.setSpawnPoint(spawnPoint[5]);
        }
        else if (numPlayers == 7)
        {
            player.setSpawnPoint(spawnPoint[6]);
        }
        else if (numPlayers == 8)
        {
            player.setSpawnPoint(spawnPoint[7]);
        }

        //else
        //{
        //    player.setDisplayColor(displayColor);
        //}
    }
}
