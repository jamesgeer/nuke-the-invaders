using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * our inventory ui/window/hotbar for the frontend
 * marries the slot data from the frontend with the backend
 */
public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    private Dictionary<InventorySlotUI, InventorySlot> slotsDictionary;

    [SerializeField] private InventoryHolder inventoryHolder;
    [SerializeField] private InventorySlotUI[] slots;

    public void Start()
    {
        // if the inventory holder has been assigned in the inspector
        if (inventoryHolder != null)
        {
            inventory = inventoryHolder.Inventory;
            inventory.onSlotChange += UpdateSlot;
        }
        
        AssignSlot(inventory);
    }

    private void AssignSlot(Inventory inventory)
    {
        slotsDictionary = new Dictionary<InventorySlotUI, InventorySlot>();

        for (int i = 0; i < inventory.InventorySize; i++)
        {
            slotsDictionary.Add(slots[i], inventory.Slots[i]);
            slots[i].InitialiseSlot(inventory.Slots[i]);
        }
    }

    private void UpdateSlot(InventorySlot slotToUpdate)
    {
        foreach (var slot in slotsDictionary)
        {
            // slot value is the "backend" inventory slot
            if (slot.Value == slotToUpdate)
            {
                // slot key is the "frontend" inventory slot
                slot.Key.UpdateUISlot(slotToUpdate);
            }
        }
    }

    public void SlotClicked(InventorySlotUI clickedSlot)
    {
        Debug.Log("Slot clicked");
    }
}
