using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerScript : NetworkBehaviour
{
    [SerializeField] private Vector3 movement = new Vector3();
    private Rigidbody rb;

    [Header("Player components")]
    private float InputX;
    private float InputY;
    [SerializeField] private float speed;
    [SerializeField] private float RotSpeed;

    [Header("Jump Components")]
    [SerializeField] private float JumpForce;
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private bool isGrounded;

    [Client]
    private void Start()
    {
       rb = GetComponent<Rigidbody>();
    }


    [Client]
    private void Update()
    {
        if (!hasAuthority)
        { return; }

        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();   
        }
         
       

        
    }

    private void PlayerMovement()
    {
        InputX = Input.GetAxisRaw("Horizontal");
        InputY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(InputX, 0, InputY);

        movement = Vector3.ClampMagnitude(movement, 1);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    private void PlayerJump() 
    {
        rb.velocity = new Vector3(rb.velocity.x ,0, rb.velocity.z);

        rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        isGrounded = true;
    }
}
