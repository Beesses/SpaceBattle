using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipTwoMoving : BaseForEnemyMoving
{
    [SerializeField] private float additiony;
    private Vector3 ShipPosition;
    void Start()
    {
        _horizontalSpeed = Random.Range(0.03f, 0.07f);
        _verticalSpeed = Random.Range(0.4f, 1);
        _amplitude = Random.Range(0.4f, 1);
        additiony = transform.position.y;
        ShipPosition = transform.position;
    }
    void Update()
    {
        if (Time.timeScale == 1)
        {
            Patrol();
        }
    }
    public override void Patrol()
    {
        if (transform.position.x > 10)
        {
            _horizontalSpeed = -_horizontalSpeed;
        }
        if (transform.position.x < -10)
        {
            _horizontalSpeed = -_horizontalSpeed;
        }
        ShipPosition.x += _horizontalSpeed;
        ShipPosition.y = additiony + Mathf.Sin(Time.realtimeSinceStartup * _verticalSpeed) * _amplitude;
        transform.position = ShipPosition;
    }
}
