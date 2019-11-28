using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	Rigidbody myBody;
	private float lifeTimer = 5f;
	private float timer;
	private bool hitSomething = false;
    private EnemyBase enemy;

    Collider boxCollider;

    PlayerController player;

    public float hitDamage;


    public string impactTag = "Enemy";
    public string criticTag = "Critic";

    Quaternion beforeCollision;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<Collider>();
        myBody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(myBody.velocity);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        enemy = GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<EnemyBase>();

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
            beforeCollision = Quaternion.LookRotation(myBody.velocity);
            transform.rotation = beforeCollision;
		}

    }

	private void OnCollisionEnter(Collision collision)
	{
        if(collision.collider.tag != "Arrow" && collision.collider.tag != "Player")
        {
            hitSomething = true;
            Stick();


            ContactPoint contact = collision.contacts[0];
            transform.position = contact.point;
            //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            //transform.rotation = rot;
            transform.rotation = beforeCollision;
        }



    }

	private void Stick()
	{
		//myBody.constraints = RigidbodyConstraints.FreezeAll;
        //boxCollider.enabled = false;
        myBody.isKinematic = true;
	}


<<<<<<< HEAD
     
=======
>>>>>>> ecee1fa5512a68db35515b1972090caab75f090b

    public void OnTriggerEnter(Collider collision)
    {

        if (collision.tag == criticTag)
        {
            Debug.Log("CRITAS");
            player.damage *=2;
        }

        if (collision.tag == impactTag)
        {
            Stick();
            collision.GetComponent<EnemyBase>().Damage(hitDamage);


            /*
            if (enemy.crit)
            {
                collision.GetComponent<EnemyBase>().Damage(hitDamage * 2);
                enemy.crit = false;
            }
            */

            /*
            else
            {
                collision.GetComponent<EnemyBase>().Damage(hitDamage);
            }
            */

        }
    }



}


