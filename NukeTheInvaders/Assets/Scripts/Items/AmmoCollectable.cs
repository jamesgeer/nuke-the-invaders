using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollectable : MonoBehaviour
{
    private GameObject _player;
    public AudioClip collectSound; // sound played when cell collected
    public InventoryItem inventoryItem;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        // rotate on the y axis with a speed of 100
        transform.Rotate(0, 100f * Time.deltaTime, 0);
    }

    // player picks up collectable
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(_player))
        {
            // play pickup sound
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            
            // access player inventory
            var inventory = other.transform.GetComponent<InventoryHolder>();

            // if item was successfully added to the inventory then play pickup sound and destroy game object
            if (inventory.Inventory.AddToInventory(inventoryItem, 1))
            {
                // play pickup sound
                AudioSource.PlayClipAtPoint(collectSound, transform.position);

                // destroy pickup item so player can only collect one
                Destroy(gameObject);
            }
        }
    }
}
