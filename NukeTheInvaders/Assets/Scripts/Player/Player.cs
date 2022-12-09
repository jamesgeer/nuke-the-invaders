using UnityEngine;

public class Player : MonoBehaviour
{
	private InventoryHolder inventoryHolder;
	private Inventory inventory;
	private PlayerToken playerToken;
	
	[SerializeField] private InventoryItem infiniteAmmo;
	[SerializeField] private InventoryItem startItem;
	[SerializeField] private int startItemAmount;

	// player inventory getter
	public Inventory Inventory => inventory;

	// infinite ammo getter
	public InventoryItem InfiniteAmmo => infiniteAmmo;
	
	// player token getter
	public PlayerToken PlayerToken => playerToken;

	private void Start()
	{
		// get the inventory assigned to the player
		inventoryHolder = GetComponent<InventoryHolder>();
		inventory = inventoryHolder.Inventory;
		playerToken = GetComponent<PlayerToken>();

		if (infiniteAmmo)
		{
			inventory.AddToInventory(infiniteAmmo, 30);
		}
		// see if a starting item has been assigned to the player
		if (startItem != null && startItemAmount > 0)
		{
			inventory.AddToInventory(startItem, startItemAmount);
		}
		
		// refill ammo run every 10secs
		InvokeRepeating(nameof(incrementInfiniteAmmo), 10f, 10f);
	}

	/**
	 *  refill infinite ammo (by default 1)
	 */
	public void refillInfiniteAmmo(int amount)
	{
		_inventory.AddToInventory(infiniteAmmo, amount);
    }
    
	private void incrementInfiniteAmmo()
    {
		_inventory.AddToInventory(infiniteAmmo, 1);
    }

}
