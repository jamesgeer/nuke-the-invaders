using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCell : MonoBehaviour
{
    public GameObject explode;
    private GameObject _tripod;

    float _removeTime = 3.0f;

    // Use this for initialization
    void Start()
    {
        _tripod = GameObject.Find("tripod"); //find the tripod
        Destroy(gameObject, _removeTime); // destroy the object after 2s
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //instantiate the explosion
            Instantiate(explode, transform.position, transform.rotation);
            
            //reduce the tripod's health
            _tripod.GetComponent<TripodHealth>().ReduceHealth();
            Destroy(gameObject); //destory self
        }

        // object hit is a box
        if (other.gameObject.tag == "Box")
        {
            // explode grenade
            Instantiate(explode, transform.position, transform.rotation);
            // destroy grenade
            Destroy(gameObject);
            
            // grab all objects within explosion radius (our explosion sphere)
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5f);
            // loop over "hit" objects
            foreach (var hitCollider in hitColliders)
            {
                // object hit by explosion was a box
                if (hitCollider.gameObject.CompareTag("Box"))
                {
                    // destroy object hit
                    Destroy(hitCollider.gameObject);
                }
            }
        }
    }

    private void OnDestroy()
    {
        Instantiate(explode, transform.position, transform.rotation);
        Destroy(gameObject, _removeTime);
    }
}