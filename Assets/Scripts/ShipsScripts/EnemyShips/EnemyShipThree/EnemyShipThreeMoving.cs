using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipThreeMoving : BaseForEnemyMoving
{
    [SerializeField] private float additiony;
    private Vector3 ShipPosition;
    void Start()
    {
        _horizontalSpeed = Random.Range(0.01f, 0.03f);
        _verticalSpeed = Random.Range(0.2f, 0.4f);
        _amplitude = Random.Range(0.2f, 0.8f);
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
