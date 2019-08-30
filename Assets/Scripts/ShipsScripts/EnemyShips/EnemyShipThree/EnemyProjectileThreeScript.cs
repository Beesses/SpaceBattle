using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileThreeScript : BaseProjectile
{
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _timeToDestroy = 7;
        _damage = 5;
        _speed = 0.2f;
        RotateToPlayer();
        AddSomeForce();
        Destroyy();
    }
}
