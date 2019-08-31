using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipOneMoving : BaseForEnemyMoving
{
    [SerializeField]private float additiony;
    private Vector3 ShipPosition;

    // Use this for initialization
    void Start()
    {
        _horizontalSpeed = Random.Range(0.05f, 0.1f);
        _verticalSpeed = Random.Range(0.5f, 2);
        _amplitude = Random.Range(0.5f, 1.5f);
        additiony = transform.position.y;
        ShipPosition = transform.position;
    }

    // Update is called once per frames
    void Update()
    {
        if(Time.timeScale == 1)
        {
            Patrol();
        }
    }
    public override void Patrol()
    {
        if (transform.position.x > 11)
        {
            _horizontalSpeed = -_horizontalSpeed;
        }
        if (transform.position.x < -11)
        {
            _horizontalSpeed = -_horizontalSpeed;
        }
        ShipPosition.x += _horizontalSpeed;
        ShipPosition.y = additiony + Mathf.Sin(Time.realtimeSinceStartup * _verticalSpeed) * _amplitude;
        transform.position = ShipPosition;
    }
}
