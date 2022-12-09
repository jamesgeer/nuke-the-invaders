using System;
using UnityEngine;
using TMPro;

public class PlayerToken : MonoBehaviour
{
    // object that displays the player's currently held tokens in the UI
    [SerializeField] private TextMeshProUGUI tokensHeldUI;
    
    // initialise to 0
    private int tokensHeld;
    
    // tokens held getter
    public int TokensHeld => tokensHeld;

    private void Start()
    {
        tokensHeldUI.text = "0";
    }
    
    /**
     * increase amount of tokens held by player
     */
    public void IncreaseTokens(int amount)
    {
        tokensHeld += amount;
        UpdateUI();
    }

    /**
     * decrease number of tokens held by player
     */
    public void DecreaseTokens(int amount)
    {
        tokensHeld -= amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        tokensHeldUI.text = tokensHeld.ToString();
    }

    /**
     * check if player can afford this purchase
     */
    public bool CanAfford(int itemCost)
    {
        return tokensHeld - itemCost > 0;
    }
}
