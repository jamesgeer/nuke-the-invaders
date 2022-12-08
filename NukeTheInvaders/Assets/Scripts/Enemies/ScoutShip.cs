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
    }

    
    public override void ReduceHealth(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        } 
    }
	public override void OnDestroy()
	{
        // add functionality
	}
	public override void StartMoving(Vector3 shipDirection)
	{
        rb = GetComponent<Rigidbody>();
        rb.velocity = shipDirection * speed;
    }

}

