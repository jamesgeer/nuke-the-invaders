using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInventoryDisplay : InventoryDisplay
{
    [SerializeField] private InventoryHolder inventoryHolder;
    [SerializeField] private InventorySlotUI[] slots;
    
    protected override void Start()
    {
        base.Start();

        // if the inventory holder has been assigned in the inspector
        if (inventoryHolder != null)
        {
            inventory = inventoryHolder.Inventory;
            inventory.onSlotChange += UpdateSlot;
        }
        
        AssignSlot(inventory);
    }

    public override void AssignSlot(Inventory inventory)
    {
        slotsDictionary = new Dictionary<InventorySlotUI, InventorySlot>();

        for (int i = 0; i < inventory.InventorySize; i++)
        {
            slotsDictionary.Add(slots[i], inventory.Slots[i]);
            slots[i].InitialiseSlot(inventory.Slots[i]);
        }
    }
}
