using UnityEngine;

// adds "Inventory" to the Unity "Create" menu with an option to create a new item
[CreateAssetMenu(fileName = "Inventory Item", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    // public int id;
    public string itemName;
    public Sprite icon;
    public int maxStackSize;
}
