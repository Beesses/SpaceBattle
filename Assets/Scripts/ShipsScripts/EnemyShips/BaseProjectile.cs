using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class BaseProjectile : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float Speed;
    [SerializeField] private float Damage;
    [SerializeField] private float TimeToDestroy;
    private float Lock;
    public Rigidbody2D _rb
    {
        get { return rb; }
        set { rb = value; }
    }
    public Transform _target
    {
        get { return Target; }
        set { Target = value; }
    }
    public float _speed
    {
        get { return Speed; }
        set { Speed = value; }
    }
    public float _damage
    {
        get { return Damage; }
        set { Damage = value; }
    }
    public float _timeToDestroy
    {
        get { return TimeToDestroy; }
        set { TimeToDestroy = value; }
    }
    public virtual void Destroyy()
    {
        Destroy(gameObject, _timeToDestroy);
    }
    public virtual void RotateToPlayer()
    {
        if(_target != null)
        {
            Lock = Mathf.Atan2(transform.position.y - _target.transform.position.y,
                                transform.position.x - _target.transform.position.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, Lock + 90);
        }
    }
    public virtual void AddSomeForce()
    {
        if(_target != null)
        {
            _rb.AddForce(new Vector2
                (_target.transform.position.x -
                transform.position.x, _target.transform.position.y -
                transform.position.y) * _speed, ForceMode2D.Impulse);
        }
    }
    private void SetDamage(ISetDamage obj)
    {
        if (obj != null)
        {
            obj.ApplyDamage(_damage);
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        SetDamage(collision.GetComponent<ISetDamage>());
    }
}
