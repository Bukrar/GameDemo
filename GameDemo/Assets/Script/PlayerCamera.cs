using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Vector3 distance;
    public Transform target;
    public float smooting = 5;

    void Start()
    {
        distance = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        Vector3 cameraPosition = target.position + distance;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, Time.deltaTime * smooting);
    }
}
