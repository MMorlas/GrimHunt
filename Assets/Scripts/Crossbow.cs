using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{

    public float range = Mathf.Infinity;

    public Camera fpsCam;

    public bool canShoot;

    private bool isScoped;
    private bool noScoped;

    public float scopedFOV = 15f;
    public float normalFOV;

    private void Start()
    {
        canShoot = true;
    }

    void Update()
    {
     
        if(Input.GetButtonDown("Fire1"))
        {
            //Shoot();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;

            if(isScoped)
            {
                Scope();
            }

            else if(!isScoped)
            {
                Unscoped();
            }
        }


    }

   /* 
    void Shoot()
    {
        if(canShoot)
        {
            RaycastHit hit;

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
             //   Debug.Log(hit.transform.name);

                /*
                Target target = hit.transform.GetComponent<Target>();

                if(target != null)
                {
                    target.
                }

                
            }
        }

    }
    */
    
    void Scope()
    {
        normalFOV = fpsCam.fieldOfView;
        fpsCam.fieldOfView = scopedFOV;
    }

    void Unscoped()
    {
        fpsCam.fieldOfView = normalFOV; ;
    }
}
