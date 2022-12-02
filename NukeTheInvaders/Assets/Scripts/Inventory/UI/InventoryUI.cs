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
    // the holder of our inventory (player/npc/object/etc)
    [SerializeField] private InventoryHolder inventoryHolder;
    
    // array containing assigned inventory ui slots (from the editor)
    [SerializeField] private InventorySlotUI[] slotsUI;
    
    // our inventory
    private Inventory inventory;
    
    // dictionary with the ui slots as the key and backend slots as the value
    private Dictionary<InventorySlotUI, InventorySlot> slotsDictionary;

    public void Start()
    {
        // check to make sure the inventory holder has been assigned
        if (inventoryHolder != null)
        {
            // assign the inventory variable to the inventory holder's inventory
            inventory = inventoryHolder.Inventory;
            
            // 
            inventory.onSlotChange += UpdateSlot;
            
            AssignSlot(inventory);
        }
    }

    private void AssignSlot(Inventory inventory)
    {
        slotsDictionary = new Dictionary<InventorySlotUI, InventorySlot>();

        for (int i = 0; i < inventory.InventorySize; i++)
        {
            slotsDictionary.Add(slotsUI[i], inventory.Slots[i]);
            slotsUI[i].InitialiseSlot(inventory.Slots[i]);
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
