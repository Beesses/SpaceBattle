using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class BaseProjectile : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float Damage;
    [SerializeField] private float TimeToDestroy;
    private float Lock;
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
    public virtual void Destroyy(float TimeDestroy)
    {
        Destroy(gameObject, TimeDestroy);
    }
    public virtual void RotateToPlayer(Transform target)
    {
        if(target != null)
        {
            Lock = Mathf.Atan2(transform.position.y - target.transform.position.y,
                                transform.position.x - target.transform.position.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, Lock + 90);
        }
    }
    public virtual void AddSomeForce(float SomeSpeed, Transform target, Rigidbody2D Somerb)
    {
        Somerb.AddForce(new Vector2
            (target.transform.position.x - 
            transform.position.x, target.transform.position.y - 
            transform.position.y) * SomeSpeed, ForceMode2D.Impulse);
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
