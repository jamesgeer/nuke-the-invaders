using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
	public GameObject explode;
	//private GameObject tripod;
	float removeTime = 2.0f;

	public float maxSpeed = 60; //max rocket speed
	public float rocketAcceleration = 1;
	void Start()
	{
		//tripod = GameObject.Find("tripod");//find the tripod
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
		//instantiate the explosion
		// this will end up creating 2 explosions, which I am aware of, but the workshop spec asks us to paste this here... task 2.14
		GameObject explosion = Instantiate(explode, transform.position, transform.rotation);
		//reduce the tripod's health
		//tripod.GetComponent<triPodHealth>().reduceHealth();

		Destroy(gameObject);//destroy self
							// Making sure the explosion also gets removed after a while, to clear the light effect leftover
		Destroy(explosion, removeTime);


	}
	void OnDestroy()
	{
		GameObject explosion = Instantiate(explode, transform.position, transform.rotation);
		// Making sure the explosion also gets removed after a while, to clear the light effect leftover
		Destroy(explosion, removeTime);
	}
}