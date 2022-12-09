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
			// for now only reduce lives by 1 for most ships
			if (other.GetComponent<AlienShip>().getShipType() == "Battle")
			{
				gameManager.GetComponent<GameManager>().reduceLives(999);
			}
			else if (other.GetComponent<AlienShip>().getShipType() == "Mother")
			{
				gameManager.GetComponent<GameManager>().reduceLives(2);
			}
			else {
				gameManager.GetComponent<GameManager>().reduceLives(1);
			}
			
		}
	}
}
