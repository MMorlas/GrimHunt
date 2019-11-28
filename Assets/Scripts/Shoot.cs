using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera cam;
    public GameObject arrowPrefab;
    public Transform arrowSpawn;
    public float shootForce = 20f;

    [Header("Propierties")]
    public int maxAmmo;
    public int currentAmmo;
    public float fireRate;
    public float reloadTime;

    [Header("State")]
    public bool reloading;
    public bool isShooting;

    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        currentAmmo = maxAmmo;
        reloading = false;
        isShooting = false;

    }

    [Header("Propierties")]
    public int maxAmmo;
    public int currentAmmo;
    public float fireRate;
    public float reloadTime;

    [Header("State")]
    public bool reloading;
    public bool isShooting;

    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        currentAmmo = maxAmmo;
        reloading = false;
        isShooting = false;

    }



    void Update()
    {

        fireRate = player.attackSpeed;

    }

    public void Bang()
    {
        if (player.canShoot)
        {
            if (isShooting || reloading) return;
            if (currentAmmo <= 0)
            {


                //   soundWeapon.Play(1);
                Reload();
                //anim.SetTrigger("Reload");

                return;
            }
            isShooting = true;
            currentAmmo--;

            if (Input.GetMouseButtonDown(0))
            {

                Debug.Log("DISPARA");
                GameObject go = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
                Rigidbody rb = go.GetComponent<Rigidbody>();
                rb.velocity = cam.transform.forward * shootForce;
                // currentAmmo--;

            }

            StartCoroutine(Shooting());
        }

    }


    public void Reload()
    {

        //soundWeapon.Play(1);
        if (isShooting || reloading) return;
        reloading = true;
        StartCoroutine(Reloading());
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(fireRate);
        isShooting = false;
    }

    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
        currentAmmo = maxAmmo;
<<<<<<< HEAD
        // ui.UpdateAmmoUI(currentAmmo);
=======
       // ui.UpdateAmmoUI(currentAmmo);
>>>>>>> ecee1fa5512a68db35515b1972090caab75f090b
    }
}
