using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BallDespawning : NetworkBehaviour
{
    private void Start()
    {
        StartCoroutine(DespawnBall(20.0f));
    }

    private IEnumerator DespawnBall(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
