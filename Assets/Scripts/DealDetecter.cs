using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDetecter : MonoBehaviour
{
    public LayerMask targetMask;
    public float range = 3.0f;
    private Camera mainCamera;
    public bool detect;
    private DeathObject price;
    private ShowE show;
    private ShowPanel showUI;


    private void Start()
    {
        mainCamera = Camera.main;
        detect = false;

        price = GameObject.FindGameObjectWithTag("DealItem").GetComponent<DeathObject>();
        show = GameObject.FindGameObjectWithTag("PressE").GetComponent<ShowE>();
        showUI = GameObject.FindGameObjectWithTag("DealPanel").GetComponent<ShowPanel>();
    }

    private void FixedUpdate()
    {
        ObjectDetecter();
    }

    public void ObjectDetecter()
    {

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit botonRange = new RaycastHit();
        if (Physics.Raycast(ray, out botonRange, range, targetMask))
        {

            if (botonRange.transform.tag == "DealItem")
            {
                detect = true;
                show.Show();


                if (Input.GetKeyDown(KeyCode.E))
                {
                    showUI.Show();


                }
            }



        }

        
    

        else
        {
            detect = false;
            show.Hide();
            showUI.Hide();
        }

    }





}