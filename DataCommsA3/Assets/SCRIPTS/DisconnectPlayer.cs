using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class DisconnectPlayer : NetworkBehaviour
{
    private float timer =0.0f;
    [SerializeField] private string overTimeScene;

    private void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.A))
        {
            timer = 0.0f;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            timer = 0.0f;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            timer = 0.0f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            timer = 0.0f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer = 0.0f;
        }

        if(timer >= 60.0f)
        {
            SceneManager.LoadScene(overTimeScene);
        }
    }
}
