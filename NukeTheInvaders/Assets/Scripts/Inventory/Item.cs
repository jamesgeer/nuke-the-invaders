using UnityEngine;

// adds "Inventory" to the Unity "Create" menu with an option to create a new item
[CreateAssetMenu(fileName = "Inventory Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string name;
    public Sprite icon;
    public int maxStackSize;
}
