using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTokens : MonoBehaviour
{
    private int tokensHeld = 0;

    public int TokensHeld => tokensHeld;
    
    public void IncreaseTokens(int amount)
    {
        tokensHeld += amount;
    }

    public void DecreaseTokens(int amount)
    {
        tokensHeld -= amount;
    }
}
