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
    private Inventory _inventory;
    
    // dictionary with the ui slots as the key and backend slots as the value
    private Dictionary<InventorySlotUI, InventorySlot> _slotsDictionary;

    public void Start()
    {
        // check to make sure the inventory holder has been assigned
        if (inventoryHolder != null)
        {
            // assign the inventory variable to the inventory holder's inventory
            _inventory = inventoryHolder.Inventory;
            
            // append UpdateSlot to onSlotChange event (trigger on inventory change)
            _inventory.onSlotChange += UpdateSlot;
            
            AssignSlot(_inventory);
        }
    }

    /**
     * each frontend slot is assigned a backend slot, there are stored a dictionary
     * to keep both in sync
     */
    private void AssignSlot(Inventory inventory)
    {
        // create a new dictionary to contain our backend and frontend slots
        _slotsDictionary = new Dictionary<InventorySlotUI, InventorySlot>();

        // loop over the slots in the inventory
        for (int i = 0; i < inventory.InventorySize; i++)
        {
            // add empty slots to the dictionary
            _slotsDictionary.Add(slotsUI[i], inventory.Slots[i]);
            
            // initialise slots to their default empty values
            slotsUI[i].InitialiseSlot(inventory.Slots[i]);
        }
    }

    /**
     * update slot, keeping the frontend and backend slots in sync
     */
    private void UpdateSlot(InventorySlot slotToUpdate)
    {
        // loop over slots in dictionary
        foreach (var slot in _slotsDictionary)
        {
            // find backend slot that matches the frontend value
            if (slot.Value == slotToUpdate)
            {
                // update ui slot to new value
                slot.Key.UpdateUISlot(slotToUpdate);
            }
        }
    }

    /**
     * action performed when an inventory slot is clicked
     * TODO: if slot clicked with item, make that the active item
     */
    public void SlotClicked(InventorySlotUI clickedUISlot)
    {
        if (clickedUISlot.AssignedInventorySlot.Item != null)
        {
            Debug.Log(clickedUISlot.AssignedInventorySlot.Item.itemName);
        }
        else
        {
            Debug.Log("No item");
        }
    }
}
