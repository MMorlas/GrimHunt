using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDetecter : MonoBehaviour
{
    public LayerMask targetMask;
    public float range = 3.0f;
    private Camera mainCamera;
    public bool detect;
    private ShowE show;
    private ShowPanel showUI;


    private void Start()
    {
        mainCamera = Camera.main;
        detect = false;

        show = GameObject.FindGameObjectWithTag("ShopE").GetComponent<ShowE>();
        showUI = GameObject.FindGameObjectWithTag("ShopPanel").GetComponent<ShowPanel>();
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

            if (botonRange.transform.tag == "Seller")
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
