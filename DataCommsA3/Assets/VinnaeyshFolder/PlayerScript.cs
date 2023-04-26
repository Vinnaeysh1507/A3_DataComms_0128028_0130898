using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEditor.Experimental.GraphView;

public class PlayerScript : NetworkBehaviour
{
    [SerializeField] private Vector3 movement = new Vector3();

    private float InputX;
    private float InputY;
    [SerializeField] private float speed;

    [Client]
    private void Update()
    {
        if (!hasAuthority)
        { return; }

        InputX = Input.GetAxisRaw("Horizontal");
        InputY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(InputX, 0, InputY);

        movement = Vector3.ClampMagnitude(movement, 1);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
