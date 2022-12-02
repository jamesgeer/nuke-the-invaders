using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseItem : MonoBehaviour
{
    public Image ItemSprite;
    public TextMeshProUGUI ItemCount;

    /**
     * on initialisation set to display an empty slot
     */
    private void Awake()
    {
        ItemSprite.color = Color.clear;
        ItemCount.text = "";
    }
}
