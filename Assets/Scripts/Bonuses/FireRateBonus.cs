using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateBonus : BaseBonusScript
{
    private void Awake()
    {
        _pss = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShipScript>();
        _rb = GetComponent<Rigidbody2D>();
        _special = 0.01f;
        Moving();
    }
}
