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
    private Quaternion rotationGoal;
    private Vector3 directionToWaypoint;

    [SerializeField] private float motorForce, breakForce, maxSteerAngle;
    [SerializeField] private float driftFactor; // Παράγοντας ντριφτ
    [SerializeField] private float maxAngularVelocity; // Μέγιστη γωνιακή ταχύτητα

    //private float motorForce, breakForce, maxSteerAngle, driftFactor, maxAngularVelocity;
    public WheelCollider frontLeftWheelCollider, frontRightWheelCollider, backLeftWheelCollider, backRightWheelCollider;

    private Transform frontLeftWheelTransform, frontRightWheelTransform, backLeftWheelTransform, backRightWheelTransform;

    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;

    private Rigidbody myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>(); // Προσθήκη για το RigidBody
    }

    void Start()
    {
        //set initial position
        currentPath = paths.GetNextWaypoint(currentPath);
        transform.position = currentPath.position;

        //set the next path target
        currentPath = paths.GetNextWaypoint(currentPath);
        transform.LookAt(currentPath);
    }

    void Update()
    {
        //find next waypoint
        transform.position = Vector3.MoveTowards(transform.position, currentPath.position, motorForce * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentPath.position) < distanceThreshold)
        {
            currentPath = paths.GetNextWaypoint(currentPath);
        }

        //RotateTowardsWaypoint();

        GetCoordinations(); // Προσθήκη για να λάβετε το input
        HandleMotor();
        ApplyBreaking();
        HandleSteering();
    }

    private void GetCoordinations()
    {
        Vector3 position = transform.position;
        horizontalInput = position.x;
        verticalInput = position.y;
        isBreaking = false; // Θέστε την τιμή του isBreaking στο false
    }

    private void RotateTowardsWaypoint()
    {
        directionToWaypoint = (currentPath.position - transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
        currentSteerAngle = transform.rotation;
    }

    /*private void HandleMotor()
    {
        if (isBreaking && Mathf.Abs(horizontalInput) > 0)
        {
            float angularVelocity = myBody.angularVelocity.magnitude;

            if (angularVelocity > maxAngularVelocity)
            {
                myBody.angularVelocity = myBody.angularVelocity.normalized * maxAngularVelocity;
            }

            if (verticalInput != 0f)
            {
                myBody.angularVelocity *= driftFactor;
            }
        }
        else
        {
            frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
            frontRightWheelCollider.motorTorque = verticalInput * motorForce;
            currentbreakForce = isBreaking ? breakForce : 0f;
            ApplyBreaking();
        }
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        backLeftWheelCollider.brakeTorque = currentbreakForce;
        backRightWheelCollider.brakeTorque = currentbreakForce;
    }*/

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    /*private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }*/

}


/*using System.Collections;
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

    //the rotation target for the current frame
    private Quaternion rotationGoal;
    //the direction to the next waypoint that the agent needs to rotate towards
    private Vector3 directionToWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        //set initial position
        currentPath = paths.GetNextWaypoint(currentPath);
        transform.position = currentPath.position;

        //set the next path target
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
}*/
