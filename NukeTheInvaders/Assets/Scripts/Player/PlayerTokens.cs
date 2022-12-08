using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTokens : MonoBehaviour
{
    private int tokensHeld = 0;

    // tokens held getter
    public int TokensHeld => tokensHeld;
    
    /**
     * increase amount of tokens held by player
     */
    public void IncreaseTokens(int amount)
    {
        tokensHeld += amount;
    }

    /**
     * decrease number of tokens held by player
     */
    public void DecreaseTokens(int amount)
    {
        tokensHeld -= amount;
    }

    /**
     * check if player can afford this purchase
     */
    public bool CanAfford(int amountToDecrease)
    {
        return tokensHeld - amountToDecrease < 1;
    }
}
