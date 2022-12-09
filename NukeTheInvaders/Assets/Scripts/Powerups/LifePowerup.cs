using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerup : MonoBehaviour
{
    private GameObject powerupManager;
    // Start is called before the first frame update
    void Start()
    {
        powerupManager = GameObject.FindGameObjectWithTag("PowerUpManager");
        Destroy(transform.root.gameObject, 10);
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("Player"))
        {
            // give life to player
            powerupManager.GetComponent<PowerupManager>().increaseLife();
            // then destroy
            Destroy(transform.root.gameObject);
        }
	}
}
