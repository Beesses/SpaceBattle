using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipOneScript : BaseForEnemyShips
{
    public Transform GunPlace;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _projectile = Resources.Load("EnemyProjectileOne") as GameObject;
        _currentHealth = 1;
        _maxHealth = 1;
        _speed = 5;
        //_damage = 1;
        _fireRate = 1;
    }

    // Update is called once per frame
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
            Debug.Log("Attaaaack");
            _canAttack = false;
            Instantiate(_projectile, GunPlace.position, Quaternion.identity);
        }
    }
}
