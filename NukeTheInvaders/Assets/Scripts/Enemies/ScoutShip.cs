using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutShip : AlienShip
{
    private Rigidbody rb;
    private float speed = 10f;

    void Awake()
    {
        this._health = 1;
    }


    public override void ReduceHealth()
    {
        _health -= 1;
        if (_health <= 0)
        {
            _player.IncreaseTokens(1);
            Destroy(gameObject);
        }
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
        return "Scout";
    }
}


