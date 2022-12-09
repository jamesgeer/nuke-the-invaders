using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    private ShopInventory shopInventory;
    
    [SerializeField] private GameObject shopInventoryObject;
    [SerializeField] private List<ShopInventoryItem> shopItems;

    /**
	 * must be awake as otherwise when classes like the gun
	 * tries to access the inventory variables it will be null
	 */
    private void Start()
    {
        // get the inventory assigned to the player
        ShopInventoryHolder shopInventoryHolder = GetComponent<ShopInventoryHolder>();
        shopInventory = shopInventoryHolder.ShopInventory;

        if (shopItems.Count > 0)
        {
            foreach (var shopItem in shopItems)
            {
                Debug.Log(shopItem.item.itemName);
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
            shopInventoryObject.SetActive(true);
        }
    }
    
    /**
     * hide shop inventory when player leaves the shop zone
     */
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            shopInventoryObject.SetActive(false);
        }
    }
}
