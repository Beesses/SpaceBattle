using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileOneScript : BaseProjectile
{
    public Transform target;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _timeToDestroy = 5;
        _damage = 1;
        _speed = 1;
        RotateToPlayer(target);
        AddSomeForce(_speed, target, rb);
        Destroyy(_timeToDestroy);
    }
}
