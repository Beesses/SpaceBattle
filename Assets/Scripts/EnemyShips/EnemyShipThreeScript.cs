using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipThreeScript : BaseForEnemyShips
{
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _projectile = Resources.Load("EnemyProjectileThree") as GameObject;
        FindAllGunPlaces();
        _currentHealth = 5;
        _maxHealth = 5;
        _fireRate = 6;
    }
    void Update()
    {
        LookAtTarget();
        Attack();
        Reload(_fireRate);
    }
    public override void Attack()
    {
        if (_canAttack)
        {
            _canAttack = false;
            foreach (var e in PlacesOfPrejectiles)
            {
                Instantiate(_projectile, e.position, Quaternion.identity);
            }

        }
    }
}
