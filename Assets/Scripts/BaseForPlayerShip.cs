using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseForPlayerShip : BaseShipScript
{
    [SerializeField] public bool Attacking;
    private Vector3 direction;
    [SerializeField] public float Forward;
    [SerializeField] public List<Transform> PlacesOfPrejectiles;
    private float NextFireRate = 0;
    public override void Reload(float FR)
    {
        if (Time.time > NextFireRate)
        {
            NextFireRate = FR + Time.time;
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
}
