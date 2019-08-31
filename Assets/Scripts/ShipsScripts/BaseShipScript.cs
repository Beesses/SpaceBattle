using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public abstract class BaseShipScript : MonoBehaviour
{
    [SerializeField] private float CurrentHealth;
    [SerializeField] private float MaxHealth;
    [SerializeField] private float FireRate;
    [SerializeField] private bool CanAttack;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private float Score;
    public float _score
    {
        get { return Score; }
        set { Score = value; }
    }
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
    public abstract void Reload();
    public virtual void CheckHealth()
    {
        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
