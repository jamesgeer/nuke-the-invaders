using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// system serializable so we can see this class in the inspector
[System.Serializable]
public class ShopInventory
{
    // our "inventory" a list of slots
    [SerializeField] private List<ShopInventorySlot> slots;

    // get the list of inventory slots
    public List<ShopInventorySlot> Slots => slots;
    
    // get the number of inventory slots
    public int InventorySize => Slots.Count;

    // event fires when an item is added to the inventory
    public UnityAction<ShopInventorySlot> onSlotChange;
    
    /**
     * inventory constructor, generates the slots for the inventory
     */
    public ShopInventory(int size)
    {
        // instantiate a new list for our inventory slots
        slots = new List<ShopInventorySlot>(size);

        // generate an inventory for the passed in size
        for (int i = 0; i < size; i++)
        {
            // initialise our inventory with empty slots
            slots.Add(new ShopInventorySlot());
        }
    }

    public bool SellItem(Player player, ShopInventoryItem shopItem)
    {
        // check if the player can afford this item
        if (!player.PlayerToken.CanAfford(shopItem.price)) return false;
        
        // check if the player has space for this item
        if (!player.Inventory.HasSpaceForItem(shopItem.item, shopItem.price)) return false;
        
        // player has enough tokens, and has space for item so complete transaction
        player.PlayerToken.DecreaseTokens(shopItem.price);
        player.Inventory.AddToInventory(shopItem.item, shopItem.price);

        // item successfully sold
        return true;
    }
    
    private bool HasFreeSlot(out ShopInventorySlot freeSlot)
    {
        // loop over our inventory sots
        foreach (var slot in slots)
        {
            if (slot.ShopItem == null)
            {
                freeSlot = slot;
                return true;
            }
        }

        freeSlot = null;
        return false;
    }
    
    public bool AddToInventory(ShopInventoryItem item)
    {
        // add item to first free slot
        if (HasFreeSlot(out ShopInventorySlot freeSlot))
        {
            freeSlot.AddItemToSlot(item);
            onSlotChange?.Invoke(freeSlot);
            return true;
        }

        return false;
    }
}
