using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileTwoScript : BaseProjectile
{
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _timeToDestroy = 5;
        _damage = 1;
        _speed = 0.5f;
        RotateToPlayer();
        AddSomeForce();
        Destroyy();
    }
}
