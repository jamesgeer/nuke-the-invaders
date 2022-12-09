using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    // item image/sprite
    [SerializeField] private Image itemSprite;
    
    // number of items in stack
    [SerializeField] private TextMeshProUGUI itemCount;
    
    // inventory slot in which the item has been assigned to
    [SerializeField] private InventorySlot assignedInventorySlot;
    
    // parent class, the wrapper containing the slot(s)
    private InventoryUI InventoryUI { get; set; }
    
    // getter for assigned inventory slot
    public InventorySlot AssignedInventorySlot => assignedInventorySlot;

    /**
     * initialise variables
     */
    private void Awake()
    {
        // slot is initially empty
        ClearSlot();

        // assign reference to ui wrapper component (e.g. player hotbar)
        InventoryUI = transform.parent.GetComponent<InventoryUI>();
    }

    /**
     * assign an item to the slot
     */
    public void InitialiseSlot(InventorySlot slot)
    {
        assignedInventorySlot = slot;
        UpdateUISlot(slot);
    }

    /**
     * updates slot appearance
     */
    public void UpdateUISlot(InventorySlot slot)
    {
        // make sure slot has an item
        if (slot.Item != null)
        {
            // display item sprite and changes slot color in the ui
            itemSprite.sprite = slot.Item.icon;
            itemSprite.color = Color.white;
            
            // displays the item count in the ui
            itemCount.text = slot.StackSize.ToString();
        }
        else
        {
            ClearSlot();
        }
    }

    /**
     * initial state of our empty slot
     */
    public void ClearSlot()
    {
        assignedInventorySlot?.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = "";
    }

}
