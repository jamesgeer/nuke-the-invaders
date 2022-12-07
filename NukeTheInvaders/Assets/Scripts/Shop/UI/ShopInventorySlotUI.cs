using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopInventorySlotUI : MonoBehaviour
{
    // item image/sprite
    [SerializeField] private Image itemSprite;
    
    // number of items in stack
    //[SerializeField] private TextMeshProUGUI itemCount;
    
    // item price
    [SerializeField] private TextMeshProUGUI itemPrice;
    
    // inventory slot in which the item has been assigned to
    [SerializeField] private ShopInventorySlot assignedInventorySlot;

    // ui slot button
    private Button button;
    
    // parent class, the wrapper containing the slot(s)
    private ShopInventoryUI ShopInventoryUI { get; set; }
    
    // getter for assigned inventory slot
    public ShopInventorySlot AssignedInventorySlot => assignedInventorySlot;

    /**
     * initialise variables
     */
    private void Awake()
    {
        // slot is initially empty
        ClearSlot();

        // get slot button and assign the click event listener
        button = GetComponent<Button>();
        button?.onClick.AddListener(OnUISlotClick);

        // assign reference to ui wrapper component (e.g. player hotbar)
        ShopInventoryUI = transform.parent.GetComponent<ShopInventoryUI>();
    }

    /**
     * assign an item to the slot
     */
    public void InitialiseSlot(ShopInventorySlot slot)
    {
        assignedInventorySlot = slot;
        UpdateUISlot(slot);
    }

    /**
     * updates slot appearance
     */
    public void UpdateUISlot(ShopInventorySlot slot)
    {
        // make sure slot has an item
        if (slot.ShopItem.item != null)
        {
            // display item sprite and changes slot color in the ui
            itemSprite.sprite = slot.ShopItem.item.icon;
            itemSprite.color = Color.white;
            
            // display item price in ui
            itemPrice.text = slot.ShopItem.price.ToString();
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
        itemPrice.text = "";
    }

    /**
     * click event for when a slot is clicked
     */
    public void OnUISlotClick()
    {
        ShopInventoryUI?.SlotClicked(this);
    }
}
