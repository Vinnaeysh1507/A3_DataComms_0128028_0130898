using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class WinningCondition : NetworkBehaviour
{
    [SerializeField] private BoxCollider winningPoint;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Win condition achieved");
    }


}
