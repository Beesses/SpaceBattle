using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
//[RequireComponent(typeof())]
public abstract class BaseShipScript : MonoBehaviour
{
    [SerializeField] public float CurrentHealth;
    [SerializeField] private float MaxHealth;
    [SerializeField] private float Damage;
    [SerializeField] private float Speed;
    public abstract void Attack();
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
