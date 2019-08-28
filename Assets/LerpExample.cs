using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpExample : MonoBehaviour
{
    Vector3 startPos;

    public float amplitude = 2f;
    public float period = 2f;
    public float distance = 0.1f;
    public float verticalSpeed = 2f;
    protected void Start()
    {
        startPos = transform.position;
    }

    protected void Update()
    {
        float theta = Time.timeSinceLevelLoad / period;
        distance = amplitude * Mathf.Sin(theta);
        transform.position = startPos + new Vector3(5,
            (Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude)/distance) * distance;
    }
}

