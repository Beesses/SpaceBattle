using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseForEnemyShips : BaseShipScript, IDamageble
{
    [SerializeField] public List<Transform> PlacesOfPrejectiles;
    [SerializeField] public ScoreScript SV;
    private float Look;
    public Transform target;
    private float NextFireRate = 0;
    private float FrRt = 0;
    public void findSV()
    {
        SV = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
    }
    public virtual void LookAtTarget()
    {
        if(target != null)
        {
            Look = Mathf.Atan2(transform.position.y - target.transform.position.y,
                                transform.position.x - target.transform.position.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, Look + 90);
        }
    }
    public override void Reload(float FR)
    {
        if (Time.time > NextFireRate)
        {
            FrRt = Random.Range(FR, FR+3);
            NextFireRate = FrRt + Time.time;
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
    public override void Attack()
    {
        if (_canAttack && target != null)
        {
            _canAttack = false;
            foreach (var e in PlacesOfPrejectiles)
            {
                Instantiate(_projectile, e.position, Quaternion.identity);
            }

        }
    }
    public void TakeDamage(float Damage)
    {
        _currentHealth -= Damage;
    }
    public override void CheckHealth(float _currentHealth, float score)
    {
        if (_currentHealth <= 0)
        {
            SV.ScoreValue += score;
            Destroy(gameObject);
        }
    }
}
