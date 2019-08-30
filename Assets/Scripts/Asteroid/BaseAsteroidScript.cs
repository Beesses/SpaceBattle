using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAsteroidScript : MonoBehaviour, IDamageble
{
    [SerializeField] private float CurrentHealth;
    [SerializeField] private float MaxHealth;
    [SerializeField] private float Score;
    [SerializeField] public ScoreScript SV;
    [SerializeField] private float Damage;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float Scale;
    [SerializeField] private bool isAlive;
    public bool _isAlive
    {
        get { return isAlive; }
        set { isAlive = value; }
    }
    public float _scale
    {
        get { return Scale; }
        set { Scale = value; }
    }
    public Rigidbody2D _rb
    {
        get { return rb; }
        set { rb = value; }
    }
    public Animator _anim
    {
        get { return anim; }
        set { anim = value; }
    }
    public float _damage
    {
        get { return Damage; }
        set { Damage = value; }
    }
    public float _score
    {
        get { return Score; }
        set { Score = value; }
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

    public virtual void AsteroidMove()
    {
        _rb.AddForce(new Vector2(0, Random.Range(-0.5f, -3)) * 2, ForceMode2D.Impulse);
    }
    public void findSV()
    {
        SV = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
    }
    public virtual void CheckHealth()
    {
        if (_currentHealth <= 0)
        {
            if (_isAlive)
            {
                SV.ScoreValue += _score;
                _isAlive = false;
            }
        }
    }
    public virtual void RandomScale()
    {
        _scale = Random.Range(0.2f, 1);
        if (_scale > 0.7f)
        {
            _score = 2;
            _maxHealth = 2;
            _currentHealth = 2;
            _damage = 20;
        }
        transform.localScale = new Vector3(_scale, _scale, _scale);
    }
    public virtual void Illiminated()
    {
        _anim.SetBool("Destroy", true);
        Destroy(gameObject, 1.8f);
    }
    public void TakeDamage(float Damage)
    {
        _currentHealth -= Damage;
    }
    private void SetDamage(ISetDamage obj)
    {
        if (obj != null)
        {
            obj.ApplyDamage(_damage);
            Illiminated();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        SetDamage(collision.GetComponent<ISetDamage>());
    }
}
