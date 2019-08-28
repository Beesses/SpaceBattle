using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseForEnemyMoving : MonoBehaviour
{
    [SerializeField] private float HorizontalSpeed;
    [SerializeField] private float VerticalSpeed;
    [SerializeField] private float Amplitude;
    public float _horizontalSpeed
    {
        get { return HorizontalSpeed; }
        set { HorizontalSpeed = value; }
    }
    public float _verticalSpeed
    {
        get { return VerticalSpeed; }
        set { VerticalSpeed = value ; }
    }
    public float _amplitude
    {
        get { return Amplitude; }
        set { Amplitude = value; }
    }
    public abstract void Patrol();
}
