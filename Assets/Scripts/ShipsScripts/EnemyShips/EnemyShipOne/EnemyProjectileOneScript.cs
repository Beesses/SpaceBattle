using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileOneScript : BaseProjectile
{
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _timeToDestroy = 5;
        _damage = 1;
        _speed = 1;
        RotateToPlayer();
        AddSomeForce();
        Destroyy();
    }
}
