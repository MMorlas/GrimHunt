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
<<<<<<< HEAD
    public float gravityMagnitude = 1.0f;
    private Vector2 movementAxis;
    private bool jump = false;
=======
    public float gravityMagnitude = 1.0f; 
    private Vector2 movementAxis; 
    private bool jump = false; 
>>>>>>> ecee1fa5512a68db35515b1972090caab75f090b
    private Vector3 moveDirection;

    [Header("Properties")]
    public float forceToGround = Physics.gravity.y;
    public float jumpSpeed = 8f;
    public float originalJumpSpeed = 8f;
    public float moveSpeed = 5f;
    public float movesprint = 8f;
    public float saveSprintSpeed;
<<<<<<< HEAD
    public bool canJump;
=======
>>>>>>> ecee1fa5512a68db35515b1972090caab75f090b

    public bool isDead;

    [Header("CounterTemporal")]
    public float temporalUpgradeCounter;
    public float temporalUpJump;
    public float temporalNoJump;
    public float temporalSlowed;
    public float temporalNoShoot;
    public float temporalDoubleHurt;
    public float temporalDamageDown;
    public float temporalMachineGun;
    public float temporalDoubleVelocity;




    private PlayerUI ui;


    [Header("TemporalUpgrades")]
    public bool upjump;
    public bool nojump;
    public bool slowed;
    public bool canSprint;
    public bool canShoot;
    public bool doubleHurt;
<<<<<<< HEAD
    public bool getDoubleHurt;
=======
>>>>>>> ecee1fa5512a68db35515b1972090caab75f090b
    public bool damageDown;
    public bool canBeHurt;
    public bool machineGun;
    public bool doubleVelocity;

<<<<<<< HEAD

=======
>>>>>>> ecee1fa5512a68db35515b1972090caab75f090b
    public float halfDamage;
    public float halfSpeed;
    public float saveDamage;
    public float saveSpeed;
    public float saveAttackSpeed;
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
        canBeHurt = true;

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
<<<<<<< HEAD
        if (canSprint)
=======
        if(canSprint)
>>>>>>> ecee1fa5512a68db35515b1972090caab75f090b
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
<<<<<<< HEAD

=======
            {

            }
>>>>>>> ecee1fa5512a68db35515b1972090caab75f090b
        }



        //TEMPORALUPGRADES;////////////////////////////////////////////////////////////////////////////////



        //BAD;////////////////////////////////////////////////////////////////////////////////




<<<<<<< HEAD
        if (nojump)
        {
            canJump = false;
            if (temporalNoJump <= 0f)
            {
                canJump = true;
                temporalNoJump = 5f;
                nojump = false;
            }

            else
            {
                temporalNoJump -= Time.deltaTime;
            }
        }


        if (slowed)
        {
            canSprint = false;
            if (temporalSlowed <= 0f)
            {
                moveSpeed = saveSpeed;
                temporalSlowed = 5f;
                slowed = false;
                canSprint = true;
=======
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
>>>>>>> ecee1fa5512a68db35515b1972090caab75f090b
            }

            else
            {
<<<<<<< HEAD
                temporalSlowed -= Time.deltaTime;
            }

        }

        if (!canShoot)
        {
            if (temporalNoShoot <= 0f)
            {
                temporalNoShoot = 5f;
                canShoot = true;
=======
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
>>>>>>> ecee1fa5512a68db35515b1972090caab75f090b
            }

            else
            {
<<<<<<< HEAD
                temporalNoShoot -= Time.deltaTime;
            }
        }

        if (damageDown)
        {


            if (temporalDamageDown <= 0f)
            {
                damage = saveDamage;
                temporalDamageDown = 5f;
                damageDown = false;
            }

            else
            {
                temporalDamageDown -= Time.deltaTime;
            }
        }


        if (doubleHurt)
        {
            getDoubleHurt = true;

            if (temporalDoubleHurt <= 0f)
            {
                temporalDoubleHurt = 5f;
                doubleHurt = false;
                getDoubleHurt = false;
            }

            else
            {
                temporalDoubleHurt -= Time.deltaTime;
            }
        }



        //GOOD////////////////////////////////////////////////////////////////////////////////

        if (upjump)
        {
            jumpSpeed = stateJumpUp;
            if (temporalUpJump <= 0f)
            {
                jumpSpeed = originalJumpSpeed;
                temporalUpJump = 5f;
=======
                temporalUpgradeCounter -= Time.deltaTime;
            }
        }


        //GOOD////////////////////////////////////////////////////////////////////////////////

        if (upjump)
        {
            jumpSpeed = stateJumpUp;
            if (temporalUpgradeCounter <= 0f)
            {
                jumpSpeed = originalJumpSpeed;
                temporalUpgradeCounter = 5f;
>>>>>>> ecee1fa5512a68db35515b1972090caab75f090b
                upjump = false;
            }

            else
            {
                temporalUpJump -= Time.deltaTime;
            }
        }


        if (machineGun)
        {


<<<<<<< HEAD
            if (temporalMachineGun <= 0f)
            {
                attackSpeed = saveAttackSpeed;
                temporalMachineGun = 5f;
=======
            if (temporalUpgradeCounter <= 0f)
            {
                attackSpeed = saveAttackSpeed;
                temporalUpgradeCounter = 5f;
>>>>>>> ecee1fa5512a68db35515b1972090caab75f090b
                machineGun = false;
            }

            else
            {
<<<<<<< HEAD
                temporalMachineGun -= Time.deltaTime;
=======
                temporalUpgradeCounter -= Time.deltaTime;
>>>>>>> ecee1fa5512a68db35515b1972090caab75f090b
            }
        }


        if (doubleVelocity)
        {

<<<<<<< HEAD
            if (temporalDoubleVelocity <= 0f)
            {
                moveSpeed = saveSpeed;
                temporalDoubleVelocity = 5f;
                doubleVelocity = false;

=======
            if (temporalUpgradeCounter <= 0f)
            {
                moveSpeed = saveSpeed;
                temporalUpgradeCounter = 5f;
                doubleVelocity = false;
 
>>>>>>> ecee1fa5512a68db35515b1972090caab75f090b
            }

            else
            {
                temporalDoubleVelocity -= Time.deltaTime;
            }

        }




        /////////////////////////////////////////////////////////////////////
        if (life <= 0)
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
        if (canJump)
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

<<<<<<< HEAD
        if (getDoubleHurt)
        {
            life -= attackDamage * 2;
        }

        else
        {

            life -= attackDamage;

        }
=======
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
>>>>>>> ecee1fa5512a68db35515b1972090caab75f090b


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

<<<<<<< HEAD

=======
>>>>>>> ecee1fa5512a68db35515b1972090caab75f090b
}
