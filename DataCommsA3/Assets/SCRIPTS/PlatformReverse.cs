using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlatformReverse : NetworkBehaviour
{
    [SerializeField] private float pushBackForce = 0.0f;
    [SerializeField] private Transform playerTransform;
    private bool canPush = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasAuthority)
        {
            return; 
        }

        
        if(!canPush)
        {
            canPush = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (canPush)
        {
            canPush = false;
        }
    }

    private void Update()
    {
        if(canPush)
        {
            pushBackPlayer();
        }
    }

    private void pushBackPlayer()
    {
        playerTransform.Translate(new Vector3(0, 0, -pushBackForce*0.01f));
    }

}
