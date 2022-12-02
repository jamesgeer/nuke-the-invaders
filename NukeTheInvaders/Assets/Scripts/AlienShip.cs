using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShip : MonoBehaviour
{
    protected float _health { get; set; }

	public void ReduceHealth()
    {
        _health--;
        if (_health <= 0){
            Destroy(this);

        }
    }
    // this should be used to increase/decrease the health of a particular type of ship at initialization
    protected void IncreaseHealth(int amount) {
        _health += amount;
    }
	private void OnDestroy()
	{
        // todo: add some effects for when ship gets destroyed
    }
}
