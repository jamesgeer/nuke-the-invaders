using UnityEngine;

// system serializable so we can see this class in the inspector
[System.Serializable]
public class InventorySlot
{
    [SerializeField] private InventoryItem item;
    [SerializeField] private int quantity;

    // item data getter
    public InventoryItem Item => item;
    
    // stack size getter
    public int StackSize => quantity;

    /**
     * slot will initially be empty
     */
    public InventorySlot()
    {
        ClearSlot();
    }

    /**
     * place item into slot
     */
    public void AddItemToSlot(InventoryItem inventoryItem, int amount)
    {
        item = inventoryItem;
        quantity = amount;
    }

    /**
     * set slot to default empty state
     */
    public void ClearSlot()
    {
        item = null;
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
     * returns true if the stack is full, false otherwise
     */
    public bool IsStackFull(int amountToAdd)
    {
        return quantity + amountToAdd == item.maxStackSize;
    }
}
