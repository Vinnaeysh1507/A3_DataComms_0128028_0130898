using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlatformReverse : NetworkBehaviour
{
    [SyncVar(hook = nameof(SetPlayerSpeed))]
    [SerializeField] float pushBackForce = 0.0f;

    public override void OnStartServer()
    {
        base.OnStartServer();
        pushBackForce = 5.0f;
    }

    private void SetPlayerSpeed(float oldSpeed, float newSpeed)
    {
           
    }
}
