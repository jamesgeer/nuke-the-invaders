using UnityEngine;
using UnityEngine.Events;

// system serializable so we can see this class in the inspector
[System.Serializable]
// the holder of our inventory, for example the player, a vendor, a chest, etc.
public class ShopInventoryHolder : MonoBehaviour
{
    private int inventorySize = 10;
    [SerializeField] protected ShopInventory shopInventory;

    // inventory getter
    public ShopInventory ShopInventory => shopInventory;

    /**
     * using awake for setting up the reference between objects, acts kind of like a constructor
     */
    private void Awake()
    {
        shopInventory = new ShopInventory(inventorySize);
    }
} 