using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class WinningCondition : NetworkBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform finishPoint;
    private float distToPoint;

    private void Update()
    {
        //distToPoint = Vector3.Distance(finishPoint.position, player.position);
        //distToPoint = (finishPoint.position - player.position).sqrMagnitude;
        if (distToPoint <= 5.0f)
        {
            
            Debug.Log("game won!");
        }
    }
}
