using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUp : MonoBehaviour
{
    public string impactTag = "Player";
    public float damageUp;


    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == impactTag)
        {
            collision.GetComponent<PlayerController>().GetDamageUp(damageUp);
            gameObject.SetActive(false);
        }

    }
}
