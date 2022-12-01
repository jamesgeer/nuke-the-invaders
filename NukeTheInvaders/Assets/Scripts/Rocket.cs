using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
	public GameObject explode;
	//private GameObject tripod;
	float removeTime = 3.0f;
	// Use this for initialization
	void Start()
	{
		//tripod = GameObject.Find("tripod");//find the tripod
		Destroy(gameObject, removeTime); //destroy the object after a set amount of time
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