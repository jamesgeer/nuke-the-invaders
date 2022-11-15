using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triPodHealth : MonoBehaviour
{
    private float health = 3;
    public GameObject smoke, flare;

    public void reduceHealth()
    {
        health--;
        if (health <= 0){
            smoke.SetActive(true);
            flare.SetActive(true);
        }
    }
}
