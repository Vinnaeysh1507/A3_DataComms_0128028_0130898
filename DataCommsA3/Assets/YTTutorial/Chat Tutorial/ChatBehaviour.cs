using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using System;
using Mirror.Examples.Chat;

public class ChatBehaviour : NetworkBehaviour
{
    [SerializeField] private GameObject chatUI = null;
    [SerializeField] private TMP_Text chatText = null;
    [SerializeField] private TMP_InputField inputField = null;

    //Each behaviour has their own chat behaviour they own
    private static event Action<string> onMessage;

    public override void OnStartAuthority()
    {
        chatUI.SetActive(true);

        onMessage += HandleNewMessage;
    }


    //Calling it on client not server
    [ClientCallback]
    private void OnDestroy()
    {
        if (!hasAuthority)
        {
            return;
        }

        onMessage -= HandleNewMessage;
    }

    private void HandleNewMessage(string message)
    { 
        chatText.text = message;
    }

    public void Send(string message)
    {
        if (!Input.GetKeyDown(KeyCode.Return))
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(message))
        {
            return;
        }

        CmdSendMessage(message);

        inputField.text = string.Empty;
    }

    [Command]
    private void CmdSendMessage(string message)
    { 
        RpcHandleMessage($"[{connectionToClient.connectionId}]: {message}");
    }

    [ClientRpc]
    private void RpcHandleMessage(string message) 
    {
        onMessage?.Invoke($"\n{message}");
    }
}
