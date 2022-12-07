using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Dictionary<InventoryItem, int>> _shopItems;

    private void Start()
    {
    }
}
