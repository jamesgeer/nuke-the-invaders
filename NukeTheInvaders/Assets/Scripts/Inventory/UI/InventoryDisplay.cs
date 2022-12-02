using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * class for marrying the data between the backend and frontend
 */
public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private MouseItem mouseItem;
    
    protected Inventory inventory;
    protected Dictionary<InventorySlotUI, InventorySlot> slotsDictionary;

    public Inventory Inventory => inventory;
    public Dictionary<InventorySlotUI, InventorySlot> SlotsDictionary => slotsDictionary;

    protected virtual void Start()
    {
        throw new NotImplementedException();
    }

    public abstract void AssignSlot(Inventory inventory);

    protected virtual void UpdateSlot(InventorySlot slotToUpdate)
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
