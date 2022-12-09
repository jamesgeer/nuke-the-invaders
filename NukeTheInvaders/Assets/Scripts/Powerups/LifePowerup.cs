using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerup : MonoBehaviour
{
    private GameObject powerupManager;
    [SerializeField] private AudioClip collectSound;
    // Start is called before the first frame update
    void Start()
    {
        powerupManager = GameObject.FindGameObjectWithTag("PowerUpManager");
        // gets deleted after 15 seconds
        Destroy(transform.root.gameObject, 15);
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("Player"))
        {
            // give life to player
            powerupManager.GetComponent<PowerupManager>().increaseLife();
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 0.5f);
            // then destroy
            Destroy(transform.root.gameObject);
        }
	}
}
