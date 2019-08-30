using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : BaseAsteroidScript
{
    
    void Awake()
    {
        _isAlive = true;
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _damage = 10;
        _currentHealth = 1;
        _score = 1;
        _maxHealth = 1;
        findSV();
        RandomScale();
        AsteroidMove();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        if(!_isAlive)
        {
            Illiminated();
        }
    }
}
