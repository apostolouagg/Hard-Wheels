using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMover : MonoBehaviour
{
    [SerializeField] private Paths paths;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanceThreshold = 0.1f;

    [Range(0f, 15f)]
    [SerializeField] private float rotateSpeed = 4f;

    private Transform currentPath;

    // Explosion
    [SerializeField] private GameObject explosion;

    //the rotation target for the current frame
    private Quaternion rotationGoal;
    //the direction to the next waypoint that the agent needs to rotate towards
    private Vector3 directionToWaypoint;

    // Start is called before the first frame update
    public void Start()
    {
        currentPath = paths.GetRandomWaypoint(); // Χρησιμοποίησε τη συνάρτηση GetRandomWaypoint για την αρχική θέση.
        transform.position = currentPath.position;
        currentPath = paths.GetNextWaypoint(currentPath);
        transform.LookAt(currentPath);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPath.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentPath.position) < distanceThreshold)
        {
            currentPath = paths.GetNextWaypoint(currentPath);
            //transform.LookAt(currentPath);
        }

        RotateTowardsWaypoint();
    }

    //will slowly rotate the agent towards the current waypoint it is moving towards
    private void RotateTowardsWaypoint()
    {
        directionToWaypoint = (currentPath.position - transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.tag != "Enemy")
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            Destroy(gameObject);
        }
    }
}
