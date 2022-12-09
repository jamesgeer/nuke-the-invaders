using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShip : AlienShip
{
    private Rigidbody rb;
    private float speed = 5f;

	void Start()
    {
        this._health = 5;
    }

    
    public override void ReduceHealth()
    {
        _health -= 1;
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

	public override void kill()
	{
        Destroy(gameObject);
    }

    public override string getShipType()
    {
        return "Battle";

    }
}

