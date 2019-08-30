using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipThreeScript : BaseForEnemyShips
{
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _projectile = Resources.Load("EnemyProjectileThree") as GameObject;
        _sv = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
        FindAllGunPlaces();
        _currentHealth = 5;
        _maxHealth = 5;
        _fireRate = 6;
        _score = 10;
    }
    void Update()
    {
        LookAtTarget();
        Attack();
        Reload();
        CheckHealth();
    }
}
