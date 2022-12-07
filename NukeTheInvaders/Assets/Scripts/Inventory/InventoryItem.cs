using UnityEngine;

// adds "Inventory" to the Unity "Create" menu with an option to create a new item
[CreateAssetMenu(fileName = "Inventory Item", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    // name of the item
    public string itemName;
    
    // item sprite
    public Sprite icon;
    
    // maximum allowed stack size for item
    public int maxStackSize;
}
