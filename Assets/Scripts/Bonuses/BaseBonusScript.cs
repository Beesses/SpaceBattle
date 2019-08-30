using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(CircleCollider2D))]
[RequireComponent (typeof(Rigidbody2D))]
public abstract class BaseBonusScript : MonoBehaviour
{
    [SerializeField] private float Special;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerShipScript PSS;
    [SerializeField] public PlayerProjectile PP;
    public Text _text;
    public PlayerProjectile _pp
    {
        get { return PP; }
        set { PP = value; }
    }
    public PlayerShipScript _pss
    {
        get { return PSS; }
        set { PSS = value; }
    }
    public Rigidbody2D _rb
    {
        get { return rb; }
        set { rb = value; }
    }
    public float _special
    {
        get { return Special; }
        set { Special = value; }
    }
    public void Moving()
    {
        _rb.AddForce(new Vector2(0, -1) * 2, ForceMode2D.Impulse);
    }
    public virtual void AddBonus()
    {
        if(gameObject.name == "HealthBonus(Clone)")
        {
            _pss._maxHealth += _special;
            _pss.H++;
        }
        if (gameObject.name == "FireRateBonus(Clone)")
        {
            _pss._fireRate -= _special;
            _pss.F++;
        }
        if(gameObject.name == "DamageBonus(Clone)")
        {
            _pss._damage += _special;
            _pss.D++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            AddBonus();
            Destroy(gameObject);
        }
    }
}
