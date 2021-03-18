
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class RangedEnemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //damgedeal
    public float damagedeal = 5f;
    //Patroling
    public Vector3 walkPoint; 	//điểm đến
    bool walkPointSet;		    //bool để hoạt động
    public float walkPointRange = 30;//tầm hoạt động

    //Attacking
    public float timeBetweenAttacks = 1;	//delay attack
    bool alreadyAttacked = false;		        //bool để delay
    public GameObject projectile;

    //States
    public float sightRange = 30, attackRange = 10f; 		        // tầm nhìn và tầm bắn
    public bool playerInSightRange, playerInAttackRange;//bool hoạt động
    //public bool patroling, chasing, attacking;
    public Animator anim;
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.speed = 1f;
    }
    private void Update()
    {

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        MovControll();
        
    }

    private void MovControll()
    {
        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling(); 
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }


        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();  //tấn công
                             //attacking = true;

        }
        anim.SetFloat("speed", agent.speed);
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.speed = 3;
            agent.SetDestination(walkPoint);
            //anim.SetBool("Walk Forward", true);

        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 2f)
        {
            walkPointSet = false;
        }

    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void LookAtPlayer(){
        Vector3 targetDirection = (player.position - transform.position).normalized;
        targetDirection.y = Mathf.Clamp(targetDirection.y,-10,10);
        Quaternion rotateDirection = Quaternion.LookRotation(new Vector3(targetDirection.x, targetDirection.y, targetDirection.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateDirection, Time.deltaTime * 20f);
    }
    private void ChasePlayer()
    {
        LookAtPlayer();
        agent.SetDestination(player.position);
        agent.speed = 8;
        //anim.SetBool("Run Forward", true);
    }

    private void AttackPlayer()
    {
        
        LookAtPlayer();

        if (!alreadyAttacked)
        {
            ///Attack code here
            agent.SetDestination(transform.position);
            agent.speed = 0;
            anim.SetTrigger("Cast Spell");
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
        
    }
    

    private void DestroyEnemy()
    {
        agent.SetDestination(transform.position);
        anim.SetTrigger("Die");
        Destroy(gameObject, 5f);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
