using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStarter : MonoBehaviour
{
    private GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("Player")) {
            gameManager.GetComponent<GameManager>().startGame();
        }
        // deactivate the trigger
        gameObject.SetActive(false);
	}

	public void Reset()
    {
        gameObject.SetActive(true);
    }
}
