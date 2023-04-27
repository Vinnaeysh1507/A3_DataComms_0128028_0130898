using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    [SerializeField] private Transform[] spawnPoint = new Transform[8];
    [SerializeField] public int MaxPlayer;
    [SerializeField] private string ExceedLimitScene;

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
            player.RpcSetSpawnPoint(spawnPoint[0].position);
        }
        else if (numPlayers == 2)
        {
            player.RpcSetSpawnPoint(spawnPoint[1].position);
        }
        else if (numPlayers == 3)
        {
            player.RpcSetSpawnPoint(spawnPoint[2].position);
        }
        else if (numPlayers == 4)
        {
            player.RpcSetSpawnPoint(spawnPoint[3].position);
        }
        else if (numPlayers == 5)
        {
            player.RpcSetSpawnPoint(spawnPoint[4].position);
        }
        else if (numPlayers == 6)
        {
            player.RpcSetSpawnPoint(spawnPoint[5].position);
        }
        else if (numPlayers == 7)
        {
            player.RpcSetSpawnPoint(spawnPoint[6].position);
        }
        else if (numPlayers == 8)
        {
            player.RpcSetSpawnPoint(spawnPoint[7].position);
        }
        else if (numPlayers  >8 )
        {
            SceneManager.LoadScene(ExceedLimitScene);
        }

        //else
        //{
        //    player.setDisplayColor(displayColor);
        //}
    }
}
