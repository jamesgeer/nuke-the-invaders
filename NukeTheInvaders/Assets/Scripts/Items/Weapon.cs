using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    // which object this weapon will be firing
    [SerializeField] private GameObject ammoObject;
    
    // which ammo this weapon can use
    [SerializeField] private InventoryItem ammoType;
    
    // amount of ammo
    [SerializeField] private int ammoQuantity = 0;
    
    // rocket launch sound
    [SerializeField] public AudioClip shootSound;

    private void Start()
    {
        ammoObject = GetComponent<GameObject>();
    }

    public void LoadAmmo(int amount)
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    
    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // play shooting sound
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
            
            // instantiate the projectile as game object (also make it point forward)
            GameObject projectile = Instantiate(ammoObject, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
            
            // ask physics engine to ignore collison between power cell and our FPSController
            Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), projectile.GetComponent<Collider>(), true);
        }
        //if left control (fire1) pressed, and we still have at least 1 cell
        // if (Input.GetButtonDown("Fire1") && ammoQuantity > 0)
        // {
        //     // decrement ammo count
        //     ammoQuantity--; 
        //
        //     // play shooting sound
        //     AudioSource.PlayClipAtPoint(shootSound, transform.position);
        //     
        //     // instantiate the rocket as game object (also make it point forward)
        //     GameObject rocket = Instantiate(rocketObj, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
        //     
        //     // ask physics engine to ignore collison between power cell and our FPSController
        //     Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), rocket.GetComponent<Collider>(), true);
        // }
    }
}
