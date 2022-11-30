using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripodHealth : MonoBehaviour
{
    private float _health = 3;
    public GameObject smoke, flare;

    public void ReduceHealth()
    {
        _health--;
        if (_health <= 0){
            smoke.SetActive(true);
            flare.SetActive(true);
        }
    }
}
