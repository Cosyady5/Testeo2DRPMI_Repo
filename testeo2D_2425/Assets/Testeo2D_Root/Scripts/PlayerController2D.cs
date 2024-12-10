using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Librería para que funcione el New Input System

public class PlayerController2D : MonoBehaviour
{

    
    //Referencias generales
    [SerializeField] Rigidbody2D playerRb; //Ref al rigidbody del player 
    [SerializeField] PlayerInput playerInput; //Ref al gestor del input del jugador

    [Header("Movement Parameters")]

    private Vector2 moveInput; //Almacén del input del player
    public float speed;

    [Header ("Jump Parameters")]
    public float jumpForce;

    [SerializeField] bool isGrounded;


    void Start()
    {
        //Autoreferenciarcomponentes: nombre de variable = GetComponent
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
       playerRb.velocity = new Vector2(moveInput.x * speed, playerRb.velocity.y);
    }

   

    #region Input Events
    //Para crea un evento:
    //Se define PUBLIC sin tipo de dato (VOID) y con una referencia al input (Callback.Context)

    public void HandleMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void HandleJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        
    }

    #endregion



}
