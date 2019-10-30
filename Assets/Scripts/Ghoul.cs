using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghoul : MonoBehaviour
{


	[Header("StatsGHOUL")]

	public float maxLife;
	public float currentLife;

	[Header("Chase")]
    public LayerMask targetMask;
    private bool targetDetected;
    private Transform targetTransform;
    public float rangeDetection = 8;
    public float findRange;
    public float chaseSpeed;

	[Header("Attack")]
    public float rangeAttack = 3;
    public float attackDamage = 0.5f;
    public float velocityAttack = 0.5f;

	[Header("Dead")]
    private Collider physicCollider;

    private  PlayerController player;
    public bool canAttack;
    private NavMeshAgent agent;


    public enum State { Stationary, Chase, Attack, Stunned, Dead};
	public State state;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentLife = maxLife;
		player = GetComponent<PlayerController>();
		physicCollider = GetComponent<Collider>();
		canAttack = false;

		SetChase();		 
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
			case State.Chase:
				UpdateChase();
				break;
			case State.Attack:
				UpdateAttack();
				break;
			case State.Dead:
				UpdateDead();
				break;
			default:
				break;

		}
    }



    void SetChase()
    {

        rangeDetection = findRange;
        agent.stoppingDistance = 2.0f;
        agent.speed = chaseSpeed;

        state = State.Chase;


    }

	void SetAttack()
    {

		//STOP ANIMATION WALK
        //ANIMATION ATTACK
        state = State.Attack;

    }

	void SetDead()
    {

        physicCollider.enabled = false;

		//STOP ANIMATION WALK
		//ANIMATION DIE
        Destroy(gameObject, 1.5f);

        state = State.Dead;
    }



	public void Attack()
    {

        Collider[] hits = Physics.OverlapSphere(transform.position, rangeAttack);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].tag == "Player")
            {
                canAttack = true;
                //hits[i].GetComponent<PlayerController>().Damage(explosionDamage);
            }


        }

        //if (canAttack) anim.SetTrigger("Attack");
        //SetChase();
        canAttack = false;

    }
	


	void UpdateChase()
    {
        TrackingTarget();
        agent.SetDestination(targetTransform.position);
        /*
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            SetAttack();
        }
        
    */

    }

    void UpdateAttack()
    {

    }


    void UpdateDead()
    {

    }

    void TrackingTarget()
    {
        targetDetected = false;
        Collider[] hits = Physics.OverlapSphere(transform.position, rangeDetection, targetMask);
        if (hits.Length > 0)
        {
            targetDetected = true;
            targetTransform = hits[0].transform;
        }
    }

	public void Damage (int value)
    {
        currentLife -= value;
        if (currentLife <= 0)
        {
            SetDead();
        }
        else
        {
			//soundEnemy.DamageEnemy();

        }
    }




    private void OnDrawGizmos()
    {
        if (targetDetected) Gizmos.color = Color.red;
        else Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangeDetection);
    }

}
