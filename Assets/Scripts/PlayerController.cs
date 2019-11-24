using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour
{
    private float timeCounter;

    [Header("Stats")]
    public float life = 3f;
    public float maxlife = 3f;
    public float money = 0f;
    public float damage = 1f;
    public float attackSpeed = 1f;

    private CharacterController controller;
    public Shoot crossbow;
    public float gravityMagnitude = 1.0f; 
    private Vector2 movementAxis; 
    private bool jump = false; 
    private Vector3 moveDirection;

    [Header("Properties")]
    public float forceToGround = Physics.gravity.y;
    public float jumpSpeed = 8f;
    public float originalJumpSpeed = 8f;
    public float moveSpeed = 5f;
    public float movesprint = 8f;
    public float saveSprintSpeed;

    public bool isDead;

    public float temporalUpgradeCounter;

    public bool canJump;


    private PlayerUI ui;


    [Header("TemporalUpgrades")]
    public bool upjump;
    public bool nojump;
    public bool slowed;
    public bool canSprint;
    public bool canShoot;
    public bool doubleHurt;
    public bool damageDown;

    public float halfDamage;
    public float halfSpeed;
    public float saveDamage;
    public float saveSpeed;
    public float stateJumpUp = 14;





    private void Start()
    {
        isDead = false;
        controller = GetComponent<CharacterController>();
        crossbow = GameObject.FindGameObjectWithTag("Crossbow").GetComponent<Shoot>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        canJump = true;
        canSprint = true;
        canShoot = true;

        upjump = false;
        nojump = false;
        slowed = false;
        doubleHurt = false;


    }

    private void Update()
    {
        GravitySimulation();
        MovementSimulation();
        controller.Move(moveDirection * Time.deltaTime);
        if(canSprint)
        {
            if (Input.GetButtonDown("Sprint"))
            {
                saveSprintSpeed = moveSpeed;
                moveSpeed *= 1.5f;
            }

            else if (Input.GetButtonUp("Sprint"))
            {
                moveSpeed = saveSprintSpeed;
            }

            if (Input.GetButton("Fire1")) crossbow.Bang();
            {

            }
        }



        //TEMPORALUPGRADES;////////////////////////////////////////////////////////////////////////////////

        if(nojump)
        {
            canJump = false;
            if (temporalUpgradeCounter <= 0f)
            {
                canJump = true;
                temporalUpgradeCounter = 5f;
                nojump = false;
            }

            else
            {   
                temporalUpgradeCounter -= Time.deltaTime;
            }
        }

        if (upjump)
        {
            jumpSpeed = stateJumpUp;
            if (temporalUpgradeCounter <= 0f)
            {
                jumpSpeed = originalJumpSpeed;
                temporalUpgradeCounter = 5f;
                upjump = false;
            }

            else
            {
                temporalUpgradeCounter -= Time.deltaTime;
            }
        }

        if(slowed)
        {   
            canSprint = false;
            if (temporalUpgradeCounter <= 0f)
            {
                moveSpeed = saveSpeed;
                temporalUpgradeCounter = 5f;
                slowed = false;
                canSprint = true;
            }

            else
            {
                temporalUpgradeCounter -= Time.deltaTime;
            }

        }

        if(!canShoot)
        {
            if (temporalUpgradeCounter <= 0f)
            {
                temporalUpgradeCounter = 5f;
                canShoot = true;
            }

            else
            {
                temporalUpgradeCounter -= Time.deltaTime;
            }
        }

        if(damageDown)
        {


            if (temporalUpgradeCounter <= 0f)
            {
                damage = saveDamage;
                temporalUpgradeCounter = 5f;
                damageDown = false;
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
        if (doubleHurt)
        {
            life -= attackDamage * 2;
            if (temporalUpgradeCounter <= 0f)
            {
                temporalUpgradeCounter = 5f;
                doubleHurt = false;
            }

            else
            {
                temporalUpgradeCounter -= Time.deltaTime;
            }
        }

        else
        {
            life -= attackDamage;
        }
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

}
