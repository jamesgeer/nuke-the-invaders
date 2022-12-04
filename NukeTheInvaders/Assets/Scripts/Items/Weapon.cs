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

    // rocket launch sound
    [SerializeField] public AudioClip shootSound;

    private GameObject _playerGameObject;
    private Player _player;
    private Inventory _inventory;

    private void Start()
    {
        // player object
        _playerGameObject = GameObject.FindGameObjectWithTag("Player");
        
        // player class from player object
        _player = _playerGameObject.GetComponent<Player>();
        
        // player inventory
        _inventory = _player.Inventory;
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
            if (_inventory.TakeFromInventory(ammoType, 1))
            {
                // play shooting sound
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
                
                // instantiate the projectile as game object (also make it point forward)
                // GameObject projectile = Instantiate(ammoObject, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
                Instantiate(ammoObject, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
                
                // ask physics engine to ignore collison between power cell and our FPSController
                //Physics.IgnoreCollision(transform.root.GetComponent<Collider>(), projectile.GetComponent<Collider>(), true);
            }
        }
    }
}
