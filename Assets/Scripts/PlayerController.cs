using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private float timeCounter;

    [Header("Stats")]
    public float life = 3;
    public float money = 0;


    private CharacterController controller;
    public float gravityMagnitude = 1.0f; 
    private Vector2 movementAxis; 
    private bool jump = false; 
    private Vector3 moveDirection;

    [Header("Properties")]
    public float forceToGround = Physics.gravity.y;
    public float jumpSpeed = 5;
    public float moveSpeed = 5;
    public float originalSpeed = 5;
    public float movesprint = 8;




    private PlayerUI ui;

    private void Start()
    {

        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    private void Update()
    {
        GravitySimulation();
        MovementSimulation();
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetButtonDown("Sprint"))
        {
            moveSpeed = movesprint;
        }

        else if (Input.GetButtonUp("Sprint"))
        {
            moveSpeed = originalSpeed;
        }

    }

    
    private void GravitySimulation()
    {
        
        if (controller.isGrounded && !jump) 
        {
           
            moveDirection.y = forceToGround; 
        }
        else 
        {
            moveDirection += Physics.gravity * gravityMagnitude * Time.deltaTime; 

            jump = false;
        }
        
    }

    private void MovementSimulation()
    {
        Vector3 localDirection = transform.forward * movementAxis.y + transform.right * movementAxis.x;

        moveDirection.x = localDirection.x * moveSpeed;
        moveDirection.z = localDirection.z * moveSpeed; 


    }

    public void StartJump() 
    {
        if (controller.isGrounded) 
        {
            moveDirection.y = jumpSpeed;
            jump = true; 
        }
    }

    
    public void SetAxis(Vector2 inputAxis) 
    {
        movementAxis = inputAxis;
    }

    public void GetCoins(int coins)
    {

        money += coins;

    }
}
