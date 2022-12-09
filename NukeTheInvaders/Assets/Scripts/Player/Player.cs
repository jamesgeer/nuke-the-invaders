using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private InventoryHolder _inventoryHolder;
	private Inventory _inventory;
	
	[SerializeField] private InventoryItem infiniteAmmo;
	[SerializeField] private InventoryItem startItem;
	[SerializeField] private int startItemAmount;

	// player inventory getter
	public Inventory Inventory => _inventory;

	public InventoryItem InfiniteAmmo => infiniteAmmo;
	
	/**
	 * must be awake as otherwise when classes like the gun
	 * tries to access the inventory variables it will be null
	 */
	private void Awake()
	{
		_inventoryHolder = GetComponent<InventoryHolder>();
        _inventory = _inventoryHolder.Inventory;

        if (infiniteAmmo)
        {
	        _inventory.AddToInventory(infiniteAmmo, 30);
        }

        // see if a starting item has been assigned to the player
        if (startItem != null && startItemAmount > 0)
        {
	        _inventory.AddToInventory(startItem, startItemAmount);
        }
	}

	private void Start()
	{
		InvokeRepeating(nameof(incrementInfiniteAmmo), 10f, 10f);
	}

	/**
	 *  refill infinite ammo (by default 1)
	 */
	public void refillInfiniteAmmo(int amount)
	{
		_inventory.AddToInventory(infiniteAmmo,amount);
	}

	private void incrementInfiniteAmmo()
	{
		_inventory.AddToInventory(infiniteAmmo, 1);
	}

}
