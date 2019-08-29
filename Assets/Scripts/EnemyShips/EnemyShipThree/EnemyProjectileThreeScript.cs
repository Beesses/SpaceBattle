using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileThreeScript : BaseProjectile
{
    public Transform target;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _timeToDestroy = 7;
        _damage = 5;
        _speed = 0.2f;
        RotateToPlayer(target);
        AddSomeForce(_speed, target, rb);
        Destroyy(_timeToDestroy);
    }
}
