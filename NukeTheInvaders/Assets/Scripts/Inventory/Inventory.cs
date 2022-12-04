using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// system serializable so we can see this class in the inspector
[System.Serializable]
public class Inventory
{
    // our "inventory" a list of slots
    [SerializeField] private List<InventorySlot> slots;

    // get the list of inventory slots
    public List<InventorySlot> Slots => slots;

    // get the number of inventory slots
    public int InventorySize => Slots.Count;

    // event fires when an item is added to the inventory
    public UnityAction<InventorySlot> onSlotChange;

    /**
     * inventory constructor, generates the slots for the inventory
     */
    public Inventory(int size)
    {
        // instantiate a new list for our inventory slots
        slots = new List<InventorySlot>(size);

        // generate an inventory for the passed in size
        for (int i = 0; i < size; i++)
        {
            // initialise our inventory with empty slots
            slots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(InventoryItem item, int amount)
    {
        // check if the inventory already contains this item and if so,
        // see if there is space left in the stack
        if (ContainsItem(item, out List<InventorySlot> slotsWithItem))
        {
            // loop over our slots that contain the item
            foreach (var slot in slotsWithItem)
            {
                // if the amount we want to add does not make the stack full, then increase item quantity
                if (!slot.IsStackFull(amount))
                {
                    slot.IncreaseQuantity(amount); 
                    onSlotChange?.Invoke(slot);
                    return true;
                }
            }
        }
        
        // check if the inventory has a free slot and if so place item in the first
        // available one
        if (HasFreeSlot(out InventorySlot freeSlot))
        {
            freeSlot.AddItemToSlot(item, amount);
            onSlotChange?.Invoke(freeSlot);
            return true;
        }

        return false;
    }

    public bool TakeFromInventory(InventoryItem item, int amountToTake)
    {
        // check inventory contains this item and if so grab slots with it
        if (ContainsItem(item, out List<InventorySlot> slotsWithItem))
        {
            // loop over slots that contain the item
            foreach (var slot in slotsWithItem)
            {
                // if amount to take is greater than the stack size then see if there is enough
                // to take from another stack
                if (amountToTake > slot.StackSize)
                {
                    // reduce amount to take by the items taken from this slot
                    amountToTake -= slot.StackSize;
                    
                    // all items taken from slot so set to empty state
                    slot.ClearSlot();
                } 
                else if (amountToTake == slot.StackSize)
                {
                    slot.ClearSlot();
                    return true;
                }
                else
                {
                    slot.DecreaseQuantity(amountToTake);
                    return true;
                }
                
                // slot item changed so update ui
                onSlotChange?.Invoke(slot);
            }
        }

        // this item is not in the inventory
        return false;
    }

    /**
     * check if the inventory contains the item and if it does, returns a list of slots
     * that have the item, otherwise, returns false
     */
    public bool ContainsItem(InventoryItem item, out List<InventorySlot> slotsWithItem)
    {
        // new list to contain all slots that have the item
        List<InventorySlot> itemSlots = new List<InventorySlot>();
        
        // loop over our inventory sots
        foreach (var slot in slots)
        {
            // if the slot contains the item
            if (slot.Item == item)
            {
                // add the slot to our "itemSlots" list
                itemSlots.Add(slot);
            }
        }

        // check if the list has any slots, if it does the the item is in our inventory
        if (itemSlots.Count > 0)
        {
            // send to the list to our "out" value
            slotsWithItem = itemSlots;
            return true;
        }

        // the item is not in our inventory
        slotsWithItem = null;
        return false;
    }

    public bool HasFreeSlot(out InventorySlot freeSlot)
    {
        // loop over our inventory sots
        foreach (var slot in slots)
        {
            if (slot.Item == null)
            {
                freeSlot = slot;
                return true;
            }
        }

        freeSlot = null;
        return false;
    }
}
