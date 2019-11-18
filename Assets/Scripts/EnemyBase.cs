using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float maxLife;
    public float currentLife;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Damage(float hit)
    {
        currentLife -= hit;
        Debug.Log("ATACA");

        if (currentLife <= 0)
        {
            currentLife = 0;
            Defeat();
        }
    }

    public void Defeat()
    {
        Destroy(gameObject);
    }

}
