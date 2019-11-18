using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    private PlayerController playerController;
    private CameraController cameraController;



    public float mouseSensitivity;

    void Start()
    {

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        cameraController = playerController.GetComponent<CameraController>();

    }

    void Update()
    {
        PlayerInput();


    }

    void PlayerInput() 
    {
        
        if (Input.GetButtonDown("Jump")) 
        {
            
            playerController.StartJump(); 
        }

        
        
        Vector2 axis = Vector2.zero; 
        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");
        
        playerController.SetAxis(axis);
        

        axis.x = Input.GetAxis("Mouse X") * mouseSensitivity;
        axis.y = Input.GetAxis("Mouse Y") * mouseSensitivity;
        cameraController.SetAxis(axis);


    }






}
