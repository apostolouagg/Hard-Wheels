using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
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

    public GameObject gameOverPanel;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
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
            YouLost();
        }
    }

    public void YouLost()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
}