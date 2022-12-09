using UnityEngine;

// adds "Inventory" to the Unity "Create" menu with an option to create a new item
[CreateAssetMenu(fileName = "Shop Item", menuName = "Shop/Item")]
public class ShopInventoryItem : ScriptableObject
{
    // item data
    public InventoryItem item;
    
    // how much of this item the shop keeper starts with
    public int amount;
    
    // how much it will cost the player to purchase this item
    public int price;
}
