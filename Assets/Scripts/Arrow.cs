using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	Rigidbody myBody;
	private float lifeTimer = 5f;
	private float timer;
	private bool hitSomething = false;

    Collider boxCollider;

    PlayerController player;

    public float hitDamage;


    public string impactTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<Collider>();
        myBody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(myBody.velocity);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        hitDamage = player.damage;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= lifeTimer)
        {
            Destroy(gameObject);
        }
		if(!hitSomething)
		{
			transform.rotation = Quaternion.LookRotation(myBody.velocity);
		}

    }

	private void OnCollisionEnter(Collision collision)
	{
        if(collision.collider.tag != "Arrow")
        {
            hitSomething = true;
            Stick();

            /* if (collision.collider.tag == "Enemy")
             {
                 Damage();
             }
             */

            ContactPoint contact = collision.contacts[0];
            transform.position = contact.point;
            //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            //transform.rotation = rot;

        }



    }

	private void Stick()
	{
		//myBody.constraints = RigidbodyConstraints.FreezeAll;
        boxCollider.enabled = false;
        myBody.isKinematic = true;
	}

    /* void Damage()
     {

     }
     */



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == impactTag)
        {
            Stick();
            collision.GetComponent<EnemyBase>().Damage(hitDamage);
        }
    }
}


