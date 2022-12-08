using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    // ammo objects that this weapon will be firing
    [SerializeField] private GameObject RegularAmmoObject;
    [SerializeField] private GameObject InfiniteAmmoObject;

    // which ammo this weapon can use
    [SerializeField] private InventoryItem ammoType;

    // rocket launch sound
    [SerializeField] public AudioClip shootSound;

    private GameObject _playerGameObject;
    private Player _player;
    private Inventory _inventory;
    private InventoryItem _infiniteAmmo;

    private void Start()
    {
        // player object
        _playerGameObject = GameObject.FindGameObjectWithTag("Player");
        
        // player class from player object
        _player = _playerGameObject.GetComponent<Player>();
        
        // player inventory
        _inventory = _player.Inventory;
        
        // infinite ammo
        if (_player.InfiniteAmmo)
        {
            _infiniteAmmo = _player.InfiniteAmmo;
        }
    }
    
    // listen for trigger events (e.g. clicking the mouse to shoot)
    void Update()
    {
        TriggerEvent();
    }
    
    private void TriggerEvent()
    {
        // left mouse click
        if (Input.GetButtonDown("Fire1"))
        {
            // if player has any regular ammo, shoot that
            if (_inventory.TakeFromInventory(ammoType, 1))
            {
                FireAmmo(RegularAmmoObject);
            }
            // out of regular ammo, see if they have any infinite, replenishing ammo to use
            else
            {
                if (_infiniteAmmo && _inventory.TakeFromInventory(_infiniteAmmo, 1))
                {
                    FireAmmo(InfiniteAmmoObject);
                }
            }
        }
    }

    private void FireAmmo(GameObject ammoGameObject)
    {
        // play shooting sound
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
                
        // instantiate the projectile as game object (also make it point forward)
        // GameObject projectile = Instantiate(ammoObject, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
        GameObject created = Instantiate(ammoGameObject, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
                
        // ask physics engine to ignore collison between power cell and our FPSController
        Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), created.GetComponent<Collider>(), true);
    }
}
