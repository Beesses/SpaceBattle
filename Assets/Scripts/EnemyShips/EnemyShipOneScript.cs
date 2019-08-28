using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipOneScript : BaseForEnemyShips
{
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _projectile = Resources.Load("EnemyProjectileOne") as GameObject;
        FindAllGunPlaces();
        _currentHealth = 1;
        _maxHealth = 1;
        _fireRate = 1;
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
            foreach(var e in PlacesOfPrejectiles)
            {
                Instantiate(_projectile, e.position, Quaternion.identity);
            }
            
        }
    }
}
