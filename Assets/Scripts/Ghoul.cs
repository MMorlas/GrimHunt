using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghoul : EnemyBase
{


	[Header("StatsGHOUL")]

    /*
	public override float maxLife;
	public float currentLife;

    */

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
    public float velocityAttack = 1.5f;

	[Header("Dead")]
    private Collider physicCollider;

    private  PlayerController player;
    public bool canAttack;
    private NavMeshAgent agent;

    private Animator anim;


    public enum State { Stationary, Chase, Attack, Stunned, Dead};
	public State state;


	SpawnTemporalUpgrade spawn;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentLife = maxLife;
		player = GetComponent<PlayerController>();
		physicCollider = GetComponent<Collider>();
        anim = GetComponent<Animator>();
        canAttack = true;

		spawn = GameObject.FindGameObjectWithTag("RandomSpawn").GetComponent<SpawnTemporalUpgrade>();


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

		if (currentLife <= 0)
        {
            SetDead();
        }
    }



    void SetChase()
    {
        anim.SetTrigger("EndAttack");
        rangeDetection = findRange;
        agent.stoppingDistance = 1.0f;
        agent.speed = chaseSpeed;
        agent.isStopped = false;

        //anim.SetBool("isMoving", true);

        state = State.Chase;



    }

	void SetAttack()
    {
        agent.isStopped = true;
        //anim.SetBool("isMoving", false);
        anim.SetTrigger("Attack");
        state = State.Attack;

    }

	void SetDead()
    {

        physicCollider.enabled = false;

		spawn.Spawn();

		//STOP ANIMATION WALK
		//ANIMATION DIE
        Destroy(gameObject);

        state = State.Dead;
    }




	


	void UpdateChase()
    {

        TrackingTarget();
        agent.SetDestination(targetTransform.position);

        if(canAttack)
        {

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                SetAttack();
            }
        }

        else
        {
            velocityAttack -= Time.deltaTime;

            if(velocityAttack <= 0)
            {
                canAttack = true;
            }

            //contador -> cuando contador sea 0 can attack a true y reseteo el contador
        }

		

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
    
    public void Attack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, rangeAttack);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].tag == "Player")
            {
                hits[i].GetComponent<PlayerController>().damagePlayer(attackDamage);
                canAttack = false;
            }
        }

        SetChase();


    }
    


    private void OnDrawGizmos()
    {
        if (targetDetected) Gizmos.color = Color.red;
        else Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangeDetection);
    }

}
