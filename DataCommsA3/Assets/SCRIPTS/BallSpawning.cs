using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BallSpawning : NetworkBehaviour
{
    //counters
    private int ballSpawnCounter;
    [SerializeField] private float ballSpawnTimer = 3.0f;
    private float tempTimer;
    [SerializeField] private GameObject[] balls = new GameObject[3];

    private void Start()
    {
        tempTimer = ballSpawnTimer;
    }

    private void Update()
    {
        if(ballSpawnTimer<=0.0f)
        {
            spawnBall();
            ballSpawnTimer = tempTimer;
        }
        else
        {
            ballSpawnTimer -= Time.deltaTime;
        }
    }

    private void generateBallCounter()
    {
        ballSpawnCounter = Random.Range(0, 3);
    }

    private void spawnBall()
    {
        generateBallCounter();

        switch (ballSpawnCounter)
        {
            case 0:
                Instantiate(balls[0], balls[0].transform.position, Quaternion.identity);
                break;

            case 1:
                Instantiate(balls[1], balls[1].transform.position, Quaternion.identity);
                break;

            case 2:
                Instantiate(balls[2], balls[2].transform.position, Quaternion.identity);
                break;

            default:
                break;
        }
            
    } 
}
