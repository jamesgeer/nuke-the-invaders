using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
	private InventoryHolder _inventoryHolder;
	private Inventory _inventory;
	
	[SerializeField] private GameObject mainWeapon;
	[SerializeField] private InventoryItem startItem;
	[SerializeField] private int startItemAmount;
	
	private void Start()
	{
        // currentAmmoText.text = noRocket.ToString();
        // maxAmmoText.text = "/ " + maxAmmo.ToString();

        _inventoryHolder = GetComponent<InventoryHolder>();
        _inventory = _inventoryHolder.Inventory;

        // see if a starting item has been assigned to the player
        if (startItem != null && startItemAmount > 0)
        {
	        _inventory.AddToInventory(startItem, startItemAmount);
        }
	}
}
