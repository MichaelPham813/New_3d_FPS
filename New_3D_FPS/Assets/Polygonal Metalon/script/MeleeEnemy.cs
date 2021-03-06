
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MeleeEnemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public Object stab;

    public LayerMask whatIsGround, whatIsPlayer;

    public TimeStop timeStop;

    //damgedeal
    public float damagedeal=50f;
    //Patroling
    public Vector3 walkPoint; 	//điểm đến
    bool walkPointSet;		    //bool để hoạt động
    public float walkPointRange;//tầm hoạt động

    //Attacking
    public float timeBetweenAttacks;	//delay attack
    bool alreadyAttacked= false;		        //bool để delay
    public GameObject projectile;	

    //States
    public float sightRange, attackRange; 		        // tầm nhìn và tầm bắn
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
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (timeStop.TimeStopped)
        {
            agent.velocity = Vector3.zero; // stop moving
            anim.speed = 0f;  //stop the animation
        }
        else
        {
            MovControll();
            anim.speed = 1f;
        }
        
    }

    private void MovControll()
    {
        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();   //tuần tra
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();  //rượt
        }


        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();  //tấn công

        }
        anim.SetFloat("speed", agent.speed);
    }
    
    private void LookAtPlayer(){
        // Vector3 dir = player.position - transform.position;
        // dir.y= transform.position.y;
        // Quaternion rotation = Quaternion.LookRotation(dir);
        // transform.rotation = rotation;
        Vector3 targetDirection = (player.position - transform.position).normalized;
        targetDirection.y = Mathf.Clamp(targetDirection.y,-10,10);
        Quaternion rotateDirection = Quaternion.LookRotation(new Vector3(targetDirection.x, targetDirection.y, targetDirection.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateDirection, Time.deltaTime * 20f);
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.speed = 3;
            agent.SetDestination(walkPoint);
        }
            
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 2f)
        {
            agent.speed=0;
            walkPointSet = false;
        }
           
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y+0.5f, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        //agent.isStopped = false;
        LookAtPlayer();
        agent.SetDestination(player.position);
        agent.speed = 8;
    }
    
    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        //agent.SetDestination(transform.position);
        LookAtPlayer();
        if (!alreadyAttacked)
        {
            ///Attack code here
            anim.SetTrigger("Stab Attack");
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }



    public void DestroyEnemy()
    {
        anim.speed=1;
        anim.SetTrigger("Die");
        Destroy(gameObject,2f);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player"){
            other.gameObject.GetComponent<TakeDamage>().TakeDamages(damagedeal);
        }
    }
}
