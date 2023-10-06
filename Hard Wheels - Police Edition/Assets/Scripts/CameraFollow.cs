using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject target;

    private Vector3 offset;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        if (target)
        {
            offset = transform.position - target.transform.position;
        }
    }

    private void LateUpdate()
    {
        if (target)
            transform.position = target.transform.position + offset;
    }

}