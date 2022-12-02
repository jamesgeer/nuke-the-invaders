using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject rocketObj; //link to the rocket prefab
    public int noRocket = 3; //number of rockets possessed
    public AudioClip shootSound; //rocket launch sound
    public float maxSpeed= 60;//max rocket speed
    public float rocketAcceleration = 1;

    // Update is called once per frame
    void Update()
    {
        //if left control (fire1) pressed, and we still have at least 1 cell
        if (Input.GetButtonDown("Fire1") && noRocket > 0)
        {
            noRocket--; //reduce the number of rockets
            
            //play shooting sound
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
            
            //instantiate the rocket as game object (also make it point forward)
            GameObject rocket = Instantiate(rocketObj, transform.position, transform.rotation * Quaternion.Euler(95f, 0f, 0f)) as GameObject;
            //ask physics engine to ignore collison between power cell and our FPSController
            
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(),
                rocket.GetComponent<Collider>(), true);
            
            //give the powerCell a velocity so that it moves forward
            //rocket.GetComponent<Rigidbody>().velocity = transform.forward * maxSpeed;

            //if (rocketAcceleration < maxSpeed) {
            //    rocketAcceleration++;
            //}
        }
    }

    public void IncrementRocketsHeld()
    {
        noRocket++;
    }
}
