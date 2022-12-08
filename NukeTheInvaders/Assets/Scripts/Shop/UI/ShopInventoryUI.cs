using System.Collections.Generic;
using UnityEngine;

/**
 * our inventory ui/window/hotbar for the frontend
 * marries the slot data from the frontend with the backend
 */
public class ShopInventoryUI : MonoBehaviour
{
    // the holder of our inventory (player/npc/object/etc)
    [SerializeField] private ShopInventoryHolder shopInventoryHolder;
    
    // array containing assigned inventory ui slots (from the editor)
    [SerializeField] private ShopInventorySlotUI[] slotsUI;
    
    // shop inventory
    private ShopInventory shopInventory;
    
    // player
    private Player player;

    // dictionary with the ui slots as the key and backend slots as the value
    private Dictionary<ShopInventorySlotUI, ShopInventorySlot> slotsDictionary;

    public void Start()
    {
        // check to make sure the inventory holder has been assigned
        if (shopInventoryHolder == null) return;

        // assign the inventory variable to the inventory holder's inventory
        shopInventory = shopInventoryHolder.ShopInventory;
        
        // assign the player inventory variable
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        // append UpdateSlot to onSlotChange event (trigger on inventory change)
        shopInventory.onSlotChange += UpdateSlot;
        
        AssignSlot(shopInventory);
    }

    /**
     * each frontend slot is assigned a backend slot, these are stored a dictionary
     * to keep both in sync
     */
    private void AssignSlot(ShopInventory inventory)
    {
        // create a new dictionary to contain our backend and frontend slots
        slotsDictionary = new Dictionary<ShopInventorySlotUI, ShopInventorySlot>();

        // loop over the slots in the inventory
        for (int i = 0; i < inventory.InventorySize; i++)
        {
            // add empty slots to the dictionary
            slotsDictionary.Add(slotsUI[i], inventory.Slots[i]);
            
            // initialise slots to their default empty values
            slotsUI[i].InitialiseSlot(inventory.Slots[i]);
        }
    }

    /**
     * update slot, keeping the frontend and backend slots in sync
     */
    private void UpdateSlot(ShopInventorySlot slotToUpdate)
    {
        // loop over slots in dictionary
        foreach (var slot in slotsDictionary)
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
     */
    public void SlotClicked(ShopInventorySlotUI clickedUISlot)
    {
        // no action if slot is empty
        if (clickedUISlot.AssignedInventorySlot.ShopItem.item == null) return;

        // shop item clicked
        var shopItem = clickedUISlot.AssignedInventorySlot.ShopItem;

        // player wants to purchase clicked shop item
        shopInventory.SellItem(player, shopItem);
    }
}
