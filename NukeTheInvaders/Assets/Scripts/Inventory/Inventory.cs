using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// system serializable so we can see this class in the inspector
[System.Serializable]
public class Inventory
{
    // our "inventory" a list of slots
    [SerializeField] private List<Slot> slots;

    // get the list of inventory slots
    public List<Slot> Slots => slots;

    // get the number of inventory slots
    public int InventorySize => Slots.Count;

    // event fires when an item is added to the inventory
    public UnityAction<Slot> onSlotChange;

    /**
     * inventory constructor, generates the slots for the inventory
     */
    public Inventory(int size)
    {
        // instantiate a new list for our inventory slots
        slots = new List<Slot>(size);

        // generate an inventory for the passed in size
        for (int i = 0; i < size; i++)
        {
            // initialise our inventory with empty slots
            slots.Add(new Slot());
        }
    }

}
