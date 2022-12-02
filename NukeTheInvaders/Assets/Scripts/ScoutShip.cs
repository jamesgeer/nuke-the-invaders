using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutShip : AlienShip
{
    Transform player;
    private Rigidbody rb;
    private float thrust = 30f;

    void Awake()
    {
        this._health = 1;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If the enemy has health left...
        if (this._health > 0 && player)
        {
            transform.LookAt(player.position + new Vector3(0,40,0));
            // the ship should fly above Y 23
            if (transform.position.y <= 23)
            {
                rb.velocity = new Vector3(0,0,0);
            }
            else
            {
                Vector3 targetLocation = player.position - transform.position;
                float distance = targetLocation.magnitude;
                rb.AddRelativeForce((Vector3.forward + new Vector3(0, -0.4f, 0)) * thrust);
            }

        }
    }
}
