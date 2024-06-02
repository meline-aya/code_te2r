using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyAI : MonoBehaviour
{
    public Animator animator;
    int attackHash;
    int followHash;




    public float speed;
    public float chaseDistance;
    public float safeDistance;

    public float walkPointRange;
    public Vector3 walkPoint;
    bool walkPointSet;
    public LayerMask whatIsGround;

    private Transform player;

    void Start()
    {
        animator = GetComponent<Animator>();

        attackHash = Animator.StringToHash("attack");
        followHash = Animator.StringToHash("follow");



        walkPointSet = false;
        player = GameObject.FindGameObjectWithTag("Joueur").transform;
    }

    void Update()
    {

        bool attack = animator.GetBool(attackHash);
        bool follow = animator.GetBool(followHash);




        if (Vector3.Distance(transform.position, player.position) < safeDistance)
        {
            animator.SetBool("attack", true);
        }

        else if (Vector3.Distance(transform.position, player.position) < chaseDistance)
        {
            transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            animator.SetBool("follow", true);
        }


        else
        {
            Patrolling();

            animator.SetBool("attack", false);
            animator.SetBool("follow", false);
        }

    }


    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            transform.position = Vector3.MoveTowards(transform.position, walkPoint, speed * Time.deltaTime);


        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached 
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

}
