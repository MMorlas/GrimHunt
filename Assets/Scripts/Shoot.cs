using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public Camera cam;
	public GameObject arrowPrefab;
	public Transform arrowSpawn;
	public float shootForce = 20f;

    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }



    void Update()
    {
        if(player.canShoot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject go = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
                Rigidbody rb = go.GetComponent<Rigidbody>();
                rb.velocity = cam.transform.forward * shootForce;
            }
        }

    }
}
