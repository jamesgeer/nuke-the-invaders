using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCellCollectable : MonoBehaviour
{
    private GameObject _shooter;
    public AudioClip collectSound; // sound played when cell collected
    
    // Start is called before the first frame update
    void Start()
    {
        _shooter = GameObject.Find("Player Camera");
        Debug.Log(_shooter.GetComponent<Shooter>().noCell);
    }

    private void Update()
    {
        // rotate on the y axis with a speed of 100
        transform.Rotate(0, 100f * Time.deltaTime, 0);
    }

    // player picks up collectable
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // play pickup sound
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            // increment cells held
            _shooter.GetComponent<Shooter>().IncrementCellsHeld();
            // destroy pickup item so player can only collect one
            Destroy(gameObject);
        }
    }
}
