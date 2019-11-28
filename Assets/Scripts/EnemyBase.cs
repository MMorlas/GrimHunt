using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float maxLife;
    public float currentLife;

    public bool crit;

    public float speed;

	SpawnTemporalUpgrade spawn;


    // Start is called before the first frame update
    void Start()
    {
		spawn = GameObject.FindGameObjectWithTag("RandomSpawn").GetComponent<SpawnTemporalUpgrade>();
        currentLife = maxLife;
        crit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	
    public virtual void Damage(float hit)
    {
        currentLife -= hit;
        Debug.Log("ATACA");
		/*
        if (currentLife <= 0)
        {
            currentLife = 0;

			spawn.isDead = true;
            Defeat();
        }
		*/
    }
	/*
    public void Defeat()
    {
        Destroy(gameObject);
    }
	
	*/
}
