using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class NetworkManagerScript : NetworkManager
{
    [SerializeField] public int minPlayer = 2;
    [SerializeField] public int MaxPlayer;
    [SerializeField] public string TitleSceenName;
    [SerializeField] private LobbyPlayer lobbyPlayerPrefab;
    [SerializeField] private GamePlayer gamePlayerPrefab;

    public List <LobbyPlayer> LobbyPlayers { get; } = new List<LobbyPlayer>();
    public List<GamePlayer> GamePlayers { get; } = new List<GamePlayer>();

    public void OnServerConnect(NetworkConnection conn)
    {
        Debug.Log("Connecting to server...");
        if (numPlayers >= MaxPlayer)
        {
            Debug.Log("Too many players.Disconnecting user");
            conn.Disconnect();
            return;
        }
        if (SceneManager.GetActiveScene().name != TitleSceenName)
        {
            conn.Disconnect();
            return;
        }
        Debug.Log("Server Connected");
    }

    public void OnServerAddPlayer(NetworkConnection conn)
    {
        if (SceneManager.GetActiveScene().name == TitleSceenName)
        {
            if (LobbyPlayers.Count == 0)
            { 
                bool isGameLeader  = true;

                LobbyPlayer lobbyPlayerInstance = Instantiate(lobbyPlayerPrefab);

                lobbyPlayerInstance.IsGameLeader = isGameLeader;

                lobbyPlayerInstance.ConnectionId = conn.connectionId;

                NetworkServer.AddPlayerForConnection((NetworkConnectionToClient)conn,lobbyPlayerInstance.gameObject);

            }
        }
    }
}
