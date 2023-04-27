using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System.Linq;

public class LobbyPlayer : NetworkBehaviour
{
    [SyncVar] public string PlayerName;
    [SyncVar] public int ConnectionId;

    [Header("UI")]
    [SerializeField] private GameObject PlayerLobbyUI;
    [SerializeField] private GameObject Player1ReadyPanel;
    [SerializeField] private GameObject Player2ReadyPanel;
    [SerializeField] private GameObject startGameButton;
    [SerializeField] private Button ReadyButton;

    [Header("Game info")]
    public bool IsGameLeader = false;

    private const string PlayerPrefsNameKey = "PlayerName";

    private NetworkManagerScript game;


    private NetworkManagerScript Game
    {
        get
        {
            if (game != null)
            {
                return game;
            }
            return game = NetworkManagerScript.singleton as NetworkManagerScript;
        }
    }

    public override void OnStartAuthority()
    {
        CmdSetPlayerName(PlayerPrefs.GetString(PlayerPrefsNameKey));
        if (!PlayerLobbyUI.activeInHierarchy)
        { 
            PlayerLobbyUI.SetActive(true);
        }

    }

    [Command]
    private void CmdSetPlayerName(string playerName)
    {
        PlayerName = playerName;
    }

    public override void OnStartClient()
    {
        Game.LobbyPlayers.Add(this);
    }

    public override void OnStopClient() 
    {
        Game.LobbyPlayers.Remove(this);
    }
}
