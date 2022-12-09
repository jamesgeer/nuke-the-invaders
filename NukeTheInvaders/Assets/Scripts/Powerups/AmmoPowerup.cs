using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPowerup : MonoBehaviour
{
    private GameObject powerupManager;
    [SerializeField] private AudioClip collectSound;
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
            // give ammo to player
            powerupManager.GetComponent<PowerupManager>().giveAmmo();
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 0.5f);
            // then destroy
            Destroy(transform.root.gameObject);
        }
	}
}
