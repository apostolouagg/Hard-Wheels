using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System;

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


    /*---------------------------------------------------------------------------------------------------------------*/

    /*
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;

    // Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;
    [SerializeField] private float driftFactor; // Παράγοντας ντριφτ
    [SerializeField] private float maxAngularVelocity; // Μέγιστη γωνιακή ταχύτητα

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider, backRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform, backRightWheelTransform;

    // Explosion
    [SerializeField] private GameObject explosion;

    private Rigidbody myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }


    private void GetInput()
    {
        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = Input.GetAxis("Vertical");

        // Breaking Input
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        if (isBreaking && Mathf.Abs(horizontalInput) > 0)
        {
            float angularVelocity = myBody.angularVelocity.magnitude;

            // Έλεγχος αν η γωνιακή ταχύτητα υπερβαίνει το μέγιστο όριο
            if (angularVelocity > maxAngularVelocity)
            {
                // Περικόψτε τη γωνιακή ταχύτητα για να είναι μικρότερη από το μέγιστο όριο
                myBody.angularVelocity = myBody.angularVelocity.normalized * maxAngularVelocity;
            }

            // Εφαρμόστε τον παράγοντα ντριφτ στην γωνιακή ταχύτητα
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
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
        UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
            Destroy(gameObject);
        }
    }
    */
}
