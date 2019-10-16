using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public float damage = 1f;

    public float range = Mathf.Infinity;

    public Camera fpsCam;

    public bool canShoot;

    private void Start()
    {
        canShoot = true;
    }

    void Update()
    {
     
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }


    }


    void Shoot()
    {
        if(canShoot)
        {
            RaycastHit hit;

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                /*
                Target target = hit.transform.GetComponent<Target>();

                if(target != null)
                {
                    target.
                }

                */
            }
        }

    }
}
