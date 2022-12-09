using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * class for dealing with the weapon ammo
 * as we only have one weapon, the ammo is currently just rockets
 */
public class Ammo : MonoBehaviour
{
	public GameObject explode;
	readonly float removeTime = 5.0f; // essentially the fuse of the rocket

	public float maxSpeed = 60; //max rocket speed
	public float rocketAcceleration = 1;

	void Start()
	{
		// light the fuse....🔥
		Destroy(gameObject, removeTime); //destroy the object after a set amount of time
	}
	
	private void Update()
	{
		transform.Translate(0, rocketAcceleration * Time.deltaTime, 0);
		if (rocketAcceleration < maxSpeed)
		{
			rocketAcceleration += 0.3f;
		}
	}
	
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			//reduce the ship's health
			other.gameObject.GetComponent<AlienShip>().ReduceHealth();
		}
		Destroy(gameObject);//destroy self
	}
	
	void OnDestroy()
	{
		// this makes sure the rocket explosion doesn't get instantiated after a player loses the game
		if (!this.gameObject.scene.isLoaded) return;
		GameObject explosion = Instantiate(explode, transform.position, transform.rotation);
		// Making sure the explosion also gets removed after a while, to clear the light effect leftover
		Destroy(explosion, removeTime);
	}
}
