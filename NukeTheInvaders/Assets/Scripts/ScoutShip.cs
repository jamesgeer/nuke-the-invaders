using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutShip : AlienShip
{
    private Rigidbody rb;
    private float speed = 10f;

    void Start()
    {
        this._health = 1;
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * speed;
    }

    public override void ReduceHealth()
    {
        _health--;
        if (_health <= 0)
        {
            Destroy(gameObject);
        } 
    }
	public override void OnDestroy()
	{
        // add functionality
	}

}

