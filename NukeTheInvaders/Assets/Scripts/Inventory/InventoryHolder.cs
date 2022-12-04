using UnityEngine;
using UnityEngine.Events;

// system serializable so we can see this class in the inspector
[System.Serializable]
// the holder of our inventory, for example the player, a vendor, a chest, etc.
public class InventoryHolder : MonoBehaviour
{
    [SerializeField] private int inventorySize;
    [SerializeField] protected Inventory inventory;

    // inventory getter
    public Inventory Inventory => inventory;

    /**
     * using awake for setting up the reference between objects, acts kind of like a constructor
     */
    private void Awake()
    {
        inventory = new Inventory(inventorySize);
    }
} 