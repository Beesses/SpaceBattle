using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBonus : BaseBonusScript
{
    void Awake()
    {
        _pss = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShipScript>();
        _rb = GetComponent<Rigidbody2D>();
        _special = 0.15f;
        Moving();
    }
}
