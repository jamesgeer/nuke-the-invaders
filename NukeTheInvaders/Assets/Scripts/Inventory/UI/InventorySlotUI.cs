using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private InventorySlot assignedInventorySlot;

    private Button button;

    // getter for assigned inventory slot
    public InventorySlot AssignedInventorySlot => assignedInventorySlot;

    private void Awake()
    {
        ClearSlot();

        button.GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);
    }

    public void Init(InventorySlot slot)
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

    public void ClearSlot()
    {
        assignedInventorySlot?.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = "";
    }

    public void OnUISlotClick()
    {
        
    }
}
