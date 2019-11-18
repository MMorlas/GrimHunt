using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour
{
    private float timeCounter;

    [Header("Stats")]
    public float life = 3;
    public float maxlife = 3;
    public float money = 0;
    public float damage = 1;
    public float attackSpeed = 1;

    private CharacterController controller;
    public float gravityMagnitude = 1.0f; 
    private Vector2 movementAxis; 
    private bool jump = false; 
    private Vector3 moveDirection;

    [Header("Properties")]
    public float forceToGround = Physics.gravity.y;
    public float jumpSpeed = 8;
    public float originalJumpSpeed = 8;
    public float moveSpeed = 5;
    public float originalSpeed = 5;
    public float movesprint = 8;

    public bool isDead;

    public float temporalUpgradeCounter;

    public bool canJump;


    private PlayerUI ui;

    private void Start()
    {
        isDead = false;
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        canJump = true;


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
        /////////////////////////////////////////////////////////////////////////////////
        if(jumpSpeed > originalJumpSpeed)
        {
            if(temporalUpgradeCounter <= 0f)
            {
                jumpSpeed = originalJumpSpeed;
                temporalUpgradeCounter = 5f;
            }

            else
            {
                temporalUpgradeCounter -= Time.deltaTime;
            }
        }

        if(canJump == false)
        {
            if (temporalUpgradeCounter <= 0f)
            {
                canJump = true;
                temporalUpgradeCounter = 5f;
            }

            else
            {
                temporalUpgradeCounter -= Time.deltaTime;
            }
        }
        /////////////////////////////////////////////////////////////////////
        if(life <= 0)
        {
            isDead = true;
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
        if(canJump)
        {
            if (controller.isGrounded)
            {
                moveDirection.y = jumpSpeed;
                jump = true;
            }
        }

    }

    
    public void SetAxis(Vector2 inputAxis) 
    {
        movementAxis = inputAxis;
    }

    public void damagePlayer(float attackDamage)
    {
        life -= attackDamage;
    }

    //POWER UPs----------------------------------------------------------
    //-------------------------------------------------------------------
    //-------------------------------------------------------------------
    //-------------------------------------------------------------------

    public void GetCoins(int coins)
    {

        money += coins;

    }

    public void GetDamageUp(float damageUp)
    {

        damage += damageUp;

    }

    public void GetLifeUp(float lifeUp)
    {

        maxlife += lifeUp;

    }

    public void GetSpeedUp(float speedUp)
    {

        moveSpeed += speedUp;

    }


    public void GetAttackSpeedUp(float attackSpeedUp)
    {

        attackSpeed += attackSpeedUp;

    }


    //-------------------------------------------------------------------
    //-------------------------------------------------------------------
    //-------------------------------------------------------------------



    //POWER UPs TEMPORALES----------------------------------------------------------
    //-------------------------------------------------------------------
    //-------------------------------------------------------------------
    //-------------------------------------------------------------------

    


    //-------------------------------------------------------------------
    //-------------------------------------------------------------------
    //-------------------------------------------------------------------

}
