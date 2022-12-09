using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopInventoryObject;
    [SerializeField] private List<ShopInventoryItem> shopItems;

    private ShopInventory shopInventory;
    private Weapon weapon;
    
    /**
	 * must be awake as otherwise when classes like the gun
	 * tries to access the inventory variables it will be null
	 */
    private void Start()
    {
        // get the inventory assigned to the player
        ShopInventoryHolder shopInventoryHolder = GetComponent<ShopInventoryHolder>();
        shopInventory = shopInventoryHolder.ShopInventory;
        
        // get the player weapon
        weapon = GameObject.FindWithTag("MainCamera").GetComponent<Weapon>();

        if (shopItems.Count > 0)
        {
            foreach (var shopItem in shopItems)
            {
                shopInventory.AddToInventory(shopItem);
            }
        }
    }

    /**
     * display shop inventory when player is in proximity of the shop
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            // show shop inventory
            shopInventoryObject.SetActive(true);
            
            // prevent weapon from firing while using the shop inventory
            weapon.enabled = false;

            other.gameObject.GetComponent<FirstPersonAIO>().enableCameraMovement = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    
    /**
     * hide shop inventory when player leaves the shop zone
     */
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            // hide shop inventory
            shopInventoryObject.SetActive(false);
            
            // enable weapon once player has left the shop
            weapon.enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            other.gameObject.GetComponent<FirstPersonAIO>().enableCameraMovement = true;
        }
    }
}
