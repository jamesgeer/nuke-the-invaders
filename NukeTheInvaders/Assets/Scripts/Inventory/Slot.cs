using UnityEngine;

// system serializable so we can see this class in the inspector
[System.Serializable]
public class Slot
{
    [SerializeField] private Item item;
    [SerializeField] private int stackSize;

    // item data getter
    public Item Item => item;
    
    // stack size getter
    public int StackSize => stackSize;

    /**
     * slot will initially be empty
     */
    public Slot()
    {
        ClearSlot();
    }

    /**
     * place item into slot
     */
    public void AddItemToSlot(Item item, int quantity)
    {
        this.item = item;
        stackSize = quantity;
    }

    /**
     * set slot to default empty state
     */
    public void ClearSlot()
    {
        item = null;
        stackSize = -1;
    }

    /**
     * add mount to stack
     */
    public void AddToStack(int quantity)
    {
        stackSize += quantity;
    }

    /**
     * remove amount from stack
     */
    public void RemoveFromStack(int quantity)
    {
        stackSize -= quantity;
    }

    /**
     * returns true if the stack is full, false otherwise
     */
    public bool IsStackFull(int amountToAdd)
    {
        return stackSize + amountToAdd == item.maxStackSize;
    }
}
