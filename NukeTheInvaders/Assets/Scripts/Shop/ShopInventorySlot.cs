using UnityEngine;

// system serializable so we can see this class in the inspector
[System.Serializable]
public class ShopInventorySlot
{
    [SerializeField] private ShopInventoryItem shopItem;

    // item data getter
    public ShopInventoryItem ShopItem => shopItem;

    /**
     * slot will initially be empty
     */
    public ShopInventorySlot()
    {
        ClearSlot();
    }

    /**
     * place item into slot
     */
    public void AddItemToSlot(ShopInventoryItem item)
    {
        shopItem = item;
    }

    /**
     * set slot to default empty state
     */
    public void ClearSlot()
    {
        shopItem = null;
    }
    
}
