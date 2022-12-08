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
	
	/**
	 * must be awake as otherwise when classes like the gun
	 * tries to access the inventory variables it will be null
	 */
	private void Awake()
	{
		// get the inventory assigned to the player
		inventoryHolder = GetComponent<InventoryHolder>();
		inventory = inventoryHolder.Inventory;
		playerToken = GetComponent<PlayerToken>();

        if (infiniteAmmo)
        {
	        inventory.AddToInventory(infiniteAmmo, 10);
        }

        // see if a starting item has been assigned to the player
        if (startItem != null && startItemAmount > 0)
        {
	        inventory.AddToInventory(startItem, startItemAmount);
        }
	}

	private void Start()
	{
		// refill ammo run every 10secs
		InvokeRepeating(nameof(RefillInfiniteAmmo), 10f, 10f);
	}

	/**
	 * slowly refill infinite ammo
	 */
	private void RefillInfiniteAmmo()
	{
		inventory.AddToInventory(infiniteAmmo, 1);
	}
}
