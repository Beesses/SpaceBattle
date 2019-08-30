using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : BaseProjectile
{
    private PlayerShipScript PSS;
    void Awake()
    {
        PSS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShipScript>();
        _rb = GetComponent<Rigidbody2D>();
        _damage = PSS._damage;
        _speed = 15;
        _timeToDestroy = 3;
        Destroyy();
        _rb.AddForce(new Vector2(0,1) * _speed, ForceMode2D.Impulse);
    }
    private void SetDamage(IDamageble obj)
    {
        if (obj != null)
        {
            obj.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
    public new void OnTriggerEnter2D(Collider2D collision)
    {
        SetDamage(collision.GetComponent<IDamageble>());
    }
}
