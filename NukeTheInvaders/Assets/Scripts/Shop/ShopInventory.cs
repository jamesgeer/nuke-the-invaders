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

    public bool SellItem(ShopInventoryItem shopItem, int amount)
    {
        // // check inventory contains this item and if so grab slots with it
        // if (ContainsItem(item, out List<InventorySlot> slotsWithItem))
        // {
        //     // copy amount in the case that we need to pull from different stacks
        //     int amountToTake = amount;
        //     
        //     // loop over slots that contain the item
        //     foreach (var slot in slotsWithItem)
        //     {
        //         // if amount to take is greater than the stack size then see if there is enough
        //         // to take from another stack
        //         if (amountToTake > slot.StackSize)
        //         {
        //             // reduce amount to take by the items taken from this slot
        //             amountToTake -= slot.StackSize;
        //             
        //             // all items taken from slot so set to empty state
        //             slot.ClearSlot();
        //             onSlotChange?.Invoke(slot);
        //         } 
        //         else if (amountToTake == slot.StackSize)
        //         {
        //             slot.ClearSlot();
        //             onSlotChange?.Invoke(slot);
        //             return true;
        //         }
        //         else
        //         {
        //             slot.DecreaseQuantity(amountToTake);
        //             onSlotChange?.Invoke(slot);
        //             return true;
        //         }
        //     }
        // }

        // this item is not in the inventory
        return false;
    }
}
