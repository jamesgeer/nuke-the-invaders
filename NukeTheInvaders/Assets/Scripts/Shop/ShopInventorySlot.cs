using UnityEngine;

// system serializable so we can see this class in the inspector
[System.Serializable]
public class ShopInventorySlot
{
    [SerializeField] private ShopInventoryItem shopItem;
    [SerializeField] private int quantity;

    // item data getter
    public ShopInventoryItem ShopItem => shopItem;
    
    // stack size getter
    public int StackSize => quantity;

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
    public void AddItemToSlot(ShopInventoryItem item, int amount)
    {
        shopItem = item;
        quantity = amount;
    }

    /**
     * set slot to default empty state
     */
    public void ClearSlot()
    {
        shopItem = null;
        quantity = -1;
    }

    /**
     * increase number of items in stack
     */
    public void IncreaseQuantity(int amount)
    {
        quantity += amount;
    }

    /**
     * decrease number of items in stack
     */
    public void DecreaseQuantity(int amount)
    {
        quantity -= amount;
    }

    /**
     * returns true if the amount to add plus the current quantity is equal to, or greater than the current
     * maximum stack size
     */
    public bool IsStackFull(int amountToAdd)
    {
        return quantity + amountToAdd > shopItem.item.maxStackSize;
    }

    /**
     * returns true if amount to take from stack goes below one
     */
    public bool IsStackEmpty(int amountToDecrease)
    {
        return quantity - amountToDecrease < 1;
    }
}
