using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
	private GameObject gameManager;

	private void Start()
	{
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy")) {
			// Destroy the Ship
			other.GetComponent<AlienShip>().kill();
			// reduce game lives based on ship type
			if (other.GetComponent<AlienShip>().getShipType() == "Battle")
			{
				gameManager.GetComponent<GameManager>().reduceLives(999);
			}
			else if (other.GetComponent<AlienShip>().getShipType() == "Mother")
			{
				gameManager.GetComponent<GameManager>().reduceLives(2);
			}
			else { // any other ship, in our case Speeder and Scout
				gameManager.GetComponent<GameManager>().reduceLives(1);
			}
			
		}
	}
}
