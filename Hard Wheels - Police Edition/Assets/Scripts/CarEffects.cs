using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEffects : MonoBehaviour
{
    public TrailRenderer[] tireMarks;
    private bool isBreaking;
    private bool isTurning;

    private Rigidbody myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isBreaking = Input.GetKey(KeyCode.Space);
        isTurning = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

        if ((myBody.velocity.magnitude > 12 && isBreaking) || (myBody.velocity.magnitude > 13 && isTurning))
        {
            StartMarks();
        }
        else
        {
            StopMarks();
        }
    }

    private void StartMarks()
    {
        foreach (TrailRenderer trail in tireMarks)
        {
            trail.emitting = true;
        }
    }

    private void StopMarks()
    {
        foreach (TrailRenderer trail in tireMarks)
        {
            trail.emitting = false;
        }
    }
}
