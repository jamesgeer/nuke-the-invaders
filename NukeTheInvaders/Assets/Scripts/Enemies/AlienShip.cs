using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AlienShip : MonoBehaviour
{
    protected float _health { get; set; }

    public abstract void ReduceHealth();
    public abstract void OnDestroy();
}
