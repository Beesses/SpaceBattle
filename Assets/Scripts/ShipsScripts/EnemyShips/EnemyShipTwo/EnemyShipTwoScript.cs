using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipTwoScript : BaseForEnemyShips
{
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _projectile = Resources.Load("EnemyProjectileTwo") as GameObject;
        _sv = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
        FindAllGunPlaces();
        _currentHealth = 3;
        _maxHealth = 3;
        _fireRate = 3;
        _score = 5;
    }
    void Update()
    {
        LookAtTarget();
        Attack();
        Reload();
        CheckHealth();
    }
}
