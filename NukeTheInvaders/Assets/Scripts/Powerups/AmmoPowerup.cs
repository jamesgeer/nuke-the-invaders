using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPowerup : MonoBehaviour
{
    private GameObject powerupManager;
    [SerializeField] private AudioClip collectSound;
    void Start()
    {
        powerupManager = GameObject.FindGameObjectWithTag("PowerUpManager");
        // gets deleted after 15 seconds
        Destroy(transform.root.gameObject, 15f);
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("Player"))
        {
            // give ammo to player
            powerupManager.GetComponent<PowerupManager>().giveAmmo();
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 0.5f);
            // then destroy
            Destroy(transform.root.gameObject);
        }
	}
}
