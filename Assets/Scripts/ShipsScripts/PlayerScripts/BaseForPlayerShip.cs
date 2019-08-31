using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class BaseForPlayerShip : BaseShipScript, ISetDamage
{
    [SerializeField] public bool Attacking;
    [SerializeField] private float Damage;
    private Vector3 direction;
    [SerializeField] public float Forward;
    [SerializeField] public List<Transform> PlacesOfPrejectiles;
    private float NextFireRate = 0;
    public float _damage
    {
        get { return Damage; }
        set { Damage = value; }
    }
    public override void Reload()
    {
        if (Time.time > NextFireRate)
        {
            NextFireRate = _fireRate + Time.time;
            _canAttack = true;
        }
    }
    public virtual void FindAllGunPlaces()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "PlaceOfProjectile")
                PlacesOfPrejectiles.Add(child);
        }
    }
    public virtual void Controllers()
    {
        Attacking = Input.GetButton("Attack");
        Forward = Input.GetAxis("Horizontal");
    }
    public virtual void Move(float speed)
    {
        direction = transform.right * Forward;
        transform.position = Vector3.Lerp(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
    public override void Attack()
    {
        if (_canAttack)
        {
            Debug.Log("Attack");
            _canAttack = false;
            foreach (var e in PlacesOfPrejectiles)
            {
                Instantiate(_projectile, e.position, Quaternion.identity);
            }
        }
    }
    public void ApplyDamage(float Damage)
    {
        _currentHealth -= Damage;
    }
    public override void CheckHealth()
    {
        if(_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
