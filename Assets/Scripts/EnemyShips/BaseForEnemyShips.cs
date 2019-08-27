using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseForEnemyShips : BaseShipScript
{
    private float Look;
    public Transform target;
    private float NextFireRate = 0;
    private float FrRt = 0;
    public virtual void LookAtTarget()
    {
        Look = Mathf.Atan2(transform.position.y - target.transform.position.y,
                            transform.position.x - target.transform.position.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, Look + 90);
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
}
