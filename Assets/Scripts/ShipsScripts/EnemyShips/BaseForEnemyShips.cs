using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseForEnemyShips : BaseShipScript, IDamageble
{
    [SerializeField] public List<Transform> PlacesOfPrejectiles;
    [SerializeField] private ScoreScript SV;
    [SerializeField] private Transform Target;
    [SerializeField] public List<GameObject> Bonuses;
    private float Look;
    private float NextFireRate = 0;
    private float FrRt = 0;
    public void FindBonuses()
    {
        Bonuses.Add(Resources.Load("HealthBonus") as GameObject);
        Bonuses.Add(Resources.Load("DamageBonus") as GameObject);
        Bonuses.Add(Resources.Load("FireRateBonus") as GameObject);
    }
    public Transform _target
    {
        get { return Target; }
        set { Target = value; }
    }
    public ScoreScript _sv
    {
        get { return SV; }
        set { SV = value; }
    }
    public virtual void LookAtTarget()
    {
        if(_target != null)
        {
            Look = Mathf.Atan2(transform.position.y - _target.transform.position.y,
                                transform.position.x - _target.transform.position.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, Look + 90);
        }
    }
    public override void Reload()
    {
        if (Time.time > NextFireRate)
        {
            FrRt = Random.Range(_fireRate, _fireRate + 3);
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
        if (_canAttack && _target != null)
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
    public override void CheckHealth()
    {
        if (_currentHealth <= 0)
        {
            if(85 <= Random.Range(0, 100))
            {
                FindBonuses();
                Instantiate(Bonuses[Random.Range(0, 3)], transform.position, Quaternion.identity);
            }
            SV.ScoreValue += _score;
            Destroy(gameObject);
        }
    }
}
