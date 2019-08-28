using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLerpTest : MonoBehaviour
{

    private float horizontalSpeed;
    private float verticalSpeed;
    private float amplitude;
    private float additiony;
    private Vector3 ShipPosition;

    // Use this for initialization
    void Start()
    {
        horizontalSpeed = 0.1f;
        verticalSpeed = 2;
        amplitude = 2;
        additiony = transform.position.y;
        ShipPosition = transform.position;
    }

    // Update is called once per frames
    void Update()
    {
        Patrol();
    }
    public void Patrol()
    {
        if (transform.position.x > 10)
        {
            horizontalSpeed = -horizontalSpeed;
        }
        if (transform.position.x < -10)
        {
            horizontalSpeed = -horizontalSpeed;
        }
        ShipPosition.x += horizontalSpeed;
        ShipPosition.y = additiony + Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = ShipPosition;
    }
}
