using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{

    ShowPanel panel;
    DeathObject heart;
    PlayerController player;
    Crossbow playerWeapon;
    CameraController playerCamera;


    private float originalSmooth = 10;
    private float originalPlayerSpeed = 5;
    private float originalPlayerJump = 8;

    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("DealPanel").GetComponent<ShowPanel>();

        heart = GameObject.FindGameObjectWithTag("DealItem").GetComponent<DeathObject>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        playerWeapon = GameObject.FindGameObjectWithTag("Crossbow").GetComponent<Crossbow>();
        playerCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(panel.canbuy)
        {
            playerWeapon.canShoot = false;
            playerCamera.smoothTime = 0;
            player.moveSpeed = 0;
            player.jumpSpeed = 0;

            if (Input.GetKeyDown(KeyCode.F))
            {

                Deal();
                panel.Hide();
                playerWeapon.canShoot = true;
                playerCamera.smoothTime = originalSmooth;
                player.moveSpeed = originalPlayerSpeed;
                player.jumpSpeed = originalPlayerJump;

            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {

                panel.Hide();
                playerWeapon.canShoot = true;
                playerCamera.smoothTime = originalSmooth;
                player.moveSpeed = originalPlayerSpeed;
                player.jumpSpeed = originalPlayerJump;

            }

        }
    }


    public void Deal()
    {
        //Vuelve a preguntar si quieres comprar


        if (heart.heart <= player.life)
        {
            player.life -= heart.heart;
        }


    }
}
