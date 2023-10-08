using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyFollowPlayer : MonoBehaviour
{

    private Rigidbody myBody;

    [SerializeField] private GameObject target;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private float speed;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 targetDirection = transform.position - target.transform.position;
            targetDirection.Normalize();

            float rotation = Vector3.Cross(targetDirection, transform.forward).y;

            // Προσθέτουμε την περιστροφή στον εχθρό
            myBody.angularVelocity = rotationSpeed * rotation * new Vector3(0, 1, 0);
        }
    }

    private void FixedUpdate()
    {
        // Ο εχθρός κινείται μπροστά
        myBody.velocity = transform.forward * speed;
    }

    /*public Transform player; // Ο παίκτης προς ακολούθηση
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (player == null)
        {
            // Βρείτε τον παίκτη με βάση το tag "Player"
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // Ορίστε τον παίκτη ως τον στόχο του NavMeshAgent
            agent.SetDestination(player.position);
        }
    }*/
}
