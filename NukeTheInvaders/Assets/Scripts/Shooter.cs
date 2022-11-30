using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject powercell; //link to the powerCell prefab
    public int noCell = 1; //number of powerCell owned
    public AudioClip throwSound; //throw sound
    public float throwSpeed= 20;//throw speed

    // Update is called once per frame
    void Update()
    {
        //if left control (fire1) pressed, and we still have at least 1 cell
        if (Input.GetButtonDown("Fire1") && noCell > 0)
        {
            noCell--; //reduce the cell
            
            //play throw sound
            AudioSource.PlayClipAtPoint(throwSound, transform.position);
            
            //instantaite the power cel as game object
            GameObject cell = Instantiate(powercell, transform.position, transform.rotation) as GameObject;
            //ask physics engine to ignore collison between power cell and our FPSController
            
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(),
                cell.GetComponent<Collider>(), true);
            
            //give the powerCell a velocity so that it moves forward
            cell.GetComponent<Rigidbody>().velocity = transform.forward * throwSpeed;
        }
    }

    public void IncrementCellsHeld()
    {
        noCell++;
    }
}
