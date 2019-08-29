using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : BaseForEnemyShips
{
    Animator anim;
    private Rigidbody2D rb;
    bool isAlive = true;
    private float _scale;
    private float _damage = 10;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _currentHealth = 1;
        _score = 1;
        _maxHealth = 1;
        RandomScale();
        AsteroidMove();
        findSV();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth(_currentHealth, _score);
    }
    public override void CheckHealth(float _currentHealth, float score)
    {
        if (_currentHealth <= 0)
        {
            if (isAlive)
            {
                SV.ScoreValue += score;
                isAlive = false;
            }
            Illiminated();
        }
    }
    private void AsteroidMove()
    {
        rb.AddForce(new Vector2(0, Random.Range(-0.5f, -3)) * 2, ForceMode2D.Impulse);
    }
    private void RandomScale()
    {
        _scale = Random.Range(0.2f, 1);
        if(_scale > 0.7f)
        {
            _score = 2;
            _maxHealth = 2;
            _currentHealth = 2;
            _damage = 20;
        }
        transform.localScale = new Vector3(_scale, _scale, _scale);
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
    private void Illiminated()
    {
        anim.SetBool("Destroy", true);
        Destroy(gameObject, 1.8f);
    }
}
