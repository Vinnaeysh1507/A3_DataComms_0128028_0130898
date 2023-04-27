using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SerializeField] private TMP_Text displayNameText = null;
    [SerializeField] private Transform playerTransform;
    //[SerializeField] private Renderer displayColorRenderer = null;

    [SyncVar(hook = nameof(HandleDisplayNameUpdate))]
    [SerializeField] private string displayName = "Missing Name";
    private Transform displaySpawnPoint = null;

    //[SyncVar(hook = nameof(HandleDisplayColourUpdate))]
    //[SerializeField] private Color displayColor = Color.black;

    //-------------------server------------------------
    
    [Server]
    public void setDisplayName(string newDisplayName)
    {
        displayName = newDisplayName;
    }

    [ClientRpc]
    public void RpcSetSpawnPoint(Vector3 newSpawnPoint)
    {
        playerTransform.position = newSpawnPoint;
    }


    //[Server]
    //public void setDisplayColor(Color newDisplayColor)
    //{
    //    displayColor = newDisplayColor;
    //}

    [Command]
    private void CmdSetDisplayName(string newDisplayName)
    {
        if (newDisplayName.Length < 2 || newDisplayName.Length > 20)
        {
            return;
        }
        RpcDisplayNewName(newDisplayName);
        setDisplayName(newDisplayName);
    }

    //------------------------------------------------

    //------------------------client------------------
    
    //private void HandleDisplayColourUpdate(Color oldColor, Color newColor)
    //{
    //    displayColorRenderer.material.SetColor("_BaseColor", newColor);
    //}

    private void HandleDisplayNameUpdate(string oldName, string newName)
    {
        displayNameText.text = newName;
    }

    [ContextMenu("Set THis Name")]
    private void SetThisName()
    {
        CmdSetDisplayName("M");
    }

    [ClientRpc]
    private void RpcDisplayNewName(string newDisplayName)
    {
        Debug.Log(newDisplayName);
    }

    //------------------------------------------------
}
