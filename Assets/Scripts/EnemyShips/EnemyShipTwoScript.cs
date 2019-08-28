using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipTwoScript : BaseForEnemyShips
{
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _projectile = Resources.Load("EnemyProjectileTwo") as GameObject;
        FindAllGunPlaces();
        _currentHealth = 3;
        _maxHealth = 3;
        _fireRate = 3;
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
