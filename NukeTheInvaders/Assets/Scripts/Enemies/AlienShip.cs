using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AlienShip : MonoBehaviour
{
    protected float _health { get; set; }

    public abstract void ReduceHealth();
    public abstract void kill();
    public abstract void OnDestroy();
    public abstract void StartMoving(Vector3 shipDirection);
}
