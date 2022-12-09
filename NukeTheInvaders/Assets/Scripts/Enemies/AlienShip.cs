using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AlienShip : MonoBehaviour
{
    protected float _health { get; set; }
    protected PlayerToken _player { get; set; }
	private void Start()
	{
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerToken>();
	}
	// reduces health by 1
	public abstract void ReduceHealth();
    // kills the ship
    public abstract void kill();
    // returns the ship type
    public abstract string getShipType();
    // starts moving the ship
    public abstract void StartMoving(Vector3 shipDirection);

}
