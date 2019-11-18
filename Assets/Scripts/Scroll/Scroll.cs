using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [Header("SelectionScroll")]

    public bool damage;
    public bool life;
    public bool speed;
    public bool attackSpeed;


    public string impactTag = "Player";
    public float damageUp;
    public float lifeUp;
    public float speedUp;
    public float attackSpeedUp;

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
            if(damage)

            {
                collision.GetComponent<PlayerController>().GetDamageUp(damageUp);
                //gameObject.SetActive(false);
                Destroy(gameObject);
            }

            if(life)
            {
                collision.GetComponent<PlayerController>().GetLifeUp(lifeUp);
                //gameObject.SetActive(false);
                Destroy(gameObject);
            }

            if (speed)
            {
                collision.GetComponent<PlayerController>().GetSpeedUp(speedUp);
                //gameObject.SetActive(false);
                Destroy(gameObject);
            }

            if (attackSpeed)
            {
                collision.GetComponent<PlayerController>().GetAttackSpeedUp(attackSpeedUp);
                //gameObject.SetActive(false);
                Destroy(gameObject);
            }
            

            

        }

    }



}
