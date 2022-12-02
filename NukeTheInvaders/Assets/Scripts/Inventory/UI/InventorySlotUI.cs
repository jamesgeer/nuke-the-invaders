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

    // ui slot button
    private Button button;
    
    // parent class, the wrapper containing the slot(s)
    private InventoryUI InventoryUI { get; set; }
    
    // getter for assigned inventory slot
    public InventorySlot AssignedInventorySlot => assignedInventorySlot;

    private void Awake()
    {
        ClearSlot();

        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);

        InventoryUI = transform.parent.GetComponent<InventoryUI>();
    }

    public void InitialiseSlot(InventorySlot slot)
    {
        assignedInventorySlot = slot;
        UpdateUISlot(slot);
    }

    public void UpdateUISlot(InventorySlot slot)
    {
        if (slot.Item != null)
        {
            itemSprite.sprite = slot.Item.icon;
            itemSprite.color = Color.white;
            
            itemCount.text = slot.StackSize.ToString();
        }
        else
        {
            ClearSlot();
        }
    }

    public void RefreshUISlot()
    {
        if (assignedInventorySlot != null)
        {
            UpdateUISlot(assignedInventorySlot);
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

    public void OnUISlotClick()
    {
        InventoryUI?.SlotClicked(this);
    }
}
