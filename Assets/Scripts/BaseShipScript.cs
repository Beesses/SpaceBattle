using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public abstract class BaseShipScript : MonoBehaviour
{
    [SerializeField] private float CurrentHealth;
    [SerializeField] private float MaxHealth;
    [SerializeField] private float FireRate;
    [SerializeField] private bool CanAttack;
    [SerializeField] private GameObject Projectile;
    public GameObject _projectile
    {
        get { return Projectile; }
        set { Projectile = value; }
    }
    public bool _canAttack
    {
        get { return CanAttack; }
        set { CanAttack = value; }
    }
    public float _fireRate
    {
        get { return FireRate; }
        set { FireRate = value; }
    }
    public float _maxHealth
    {
        get { return MaxHealth; }
        set { MaxHealth = value; }
    }
    public float _currentHealth
    {
        get { return CurrentHealth; }
        set { CurrentHealth = value; }
    }
    public abstract void Attack();
    public abstract void Reload(float FR);
}
