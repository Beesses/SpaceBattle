using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipOneScript : BaseForEnemyShips
{
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _projectile = Resources.Load("EnemyProjectileOne") as GameObject;
        findSV();
        FindAllGunPlaces();
        _currentHealth = 1;
        _maxHealth = 1;
        _fireRate = 1;
        _score = 2;
    }
    void Update()
    {
        LookAtTarget();
        Attack();
        Reload(_fireRate);
        CheckHealth(_currentHealth,_score);
    }
}
