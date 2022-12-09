using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private ShopInventory shopInventory;

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
}
