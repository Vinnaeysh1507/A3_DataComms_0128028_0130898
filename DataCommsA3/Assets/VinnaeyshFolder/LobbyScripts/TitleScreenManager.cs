using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    public static TitleScreenManager Instance;
    [SerializeField] private NetworkManagerScript netManager;


    [Header("UI Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject PlayerNamePanel;
    [SerializeField] private GameObject HostOrJoinPanel;
    [SerializeField] private GameObject EnterIpAddressPanel;

    [Header("PlayerName UI")]
    [SerializeField] private TMP_InputField playerNameInputField;

    [Header("IpName UI")]
    [SerializeField] private TMP_InputField IpAddressField;

    private const string PlayerPrefsNameKey = "PlayerName";

    private void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if(Instance == null)
            Instance = this;
    }

    public void StartGame()
    { 
        mainMenuPanel.SetActive(false);
        PlayerNamePanel.SetActive(true);
        GetSavedPlayerName();
    }

    private void GetSavedPlayerName()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsNameKey))
        { 
            playerNameInputField.text = PlayerPrefs.GetString(PlayerPrefsNameKey);
        }
    }

    public void SavePlayerName()
    {
        string playerName = null;

        if (!string.IsNullOrEmpty(playerNameInputField.text))
        { 
            playerName = playerNameInputField.text;
            PlayerPrefs.SetString(PlayerPrefsNameKey, playerName);
            PlayerNamePanel.SetActive(false);
            HostOrJoinPanel.SetActive(true);
        }
    }

    public void HostGame()
    {
        Debug.Log("Currently Hosting a game");
        netManager.StartHost();
        HostOrJoinPanel.SetActive(false);
    }

    public void JoinGame()
    {
        HostOrJoinPanel.SetActive(false);
        EnterIpAddressPanel.SetActive(true);
    }

    public void ConnectToGame()
    {
        if (!string.IsNullOrEmpty(IpAddressField.text))
        {
            Debug.Log("Client will connect to: " + IpAddressField.text);
            netManager.networkAddress = IpAddressField.text;
            netManager.StartClient();
        }
        EnterIpAddressPanel.SetActive(false);
    }
}
