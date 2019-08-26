using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScript : MonoBehaviour
{
    Rigidbody2D RB;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        RB.AddForce(new Vector2(0, -1) * 1, ForceMode2D.Impulse);
    }
    void Update()
    {
        if(gameObject.transform.position.y < -9.81)
        {
            transform.position = new Vector2(transform.position.x, 9.99f);
        }
    }
}
