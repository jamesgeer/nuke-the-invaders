using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    // ammo objects that this weapon will be firing
    [SerializeField] private GameObject regularAmmoObject;
    [SerializeField] private GameObject infiniteAmmoObject;

    // which ammo this weapon can use
    [SerializeField] private InventoryItem ammoType;

    // rocket launch sound
    [SerializeField] public AudioClip shootSound;
    
    private Inventory inventory;
    private InventoryItem infiniteAmmo;

    // listen for trigger events (e.g. clicking the mouse to shoot)
    void Update()
    {
        TriggerEvent();
    }

    private void CheckInventory()
    {
         if (inventory == null)
         {
             // player object
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    
            // player inventory
            inventory = player.Inventory;
    
            // infinite ammo
            if (player.InfiniteAmmo)
            {
                infiniteAmmo = player.InfiniteAmmo;
            }
        }
    }
    
    private void TriggerEvent()
    {
        // left mouse click
        if (Input.GetButtonDown("Fire1"))
        {

           CheckInventory();
            
            // if player has any regular ammo, shoot that
            if (inventory.TakeFromInventory(ammoType, 1))
            {
                FireAmmo(regularAmmoObject);
            }
            // out of regular ammo, see if they have any infinite, replenishing ammo to use
            else
            {
                if (infiniteAmmo && inventory.TakeFromInventory(infiniteAmmo, 1))
                {
                    FireAmmo(infiniteAmmoObject);
                }
            }
        }
    }

    private void FireAmmo(GameObject ammoGameObject)
    {
        // play shooting sound
        AudioSource.PlayClipAtPoint(shootSound, transform.position, 0.4f);
                
        // instantiate the projectile as game object (also make it point forward)
        // GameObject projectile = Instantiate(ammoObject, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
        GameObject created = Instantiate(ammoGameObject, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
                
        // ask physics engine to ignore collison between power cell and our FPSController
        Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), created.GetComponent<Collider>(), true);
    }
}
