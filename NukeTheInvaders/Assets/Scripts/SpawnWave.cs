using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public GameObject scoutShip;
    private float spawnTime;
    private int spawnAmount;
    private Vector3 shipDirection;
    private GameObject gameManager;
	private void Start()
	{
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
	}
	public void startSpawn(Vector3 shipDirection, int wave) {
        // wait between 1 and 6 seconds for spawning initially
        spawnTime = Random.Range(1.0f, 6.0f);
        // spawn 1-3 ships initially
        spawnAmount = Random.Range(1, 3);
        this.shipDirection = shipDirection;

        //Start to spawn enemies
        StartCoroutine(SpawnShips(spawnTime, spawnAmount, wave));
    }
    IEnumerator SpawnShips(float spawnTime, int spawnAmount, int wave)
    {
        //Wait spawnTime
        yield return new WaitForSeconds(spawnTime);
        // TODO: decide what ship to spawn based on wave level etc
        GameObject prefab = scoutShip;

        // calculate min x, min y and min z compared to the spawner's position

        float minX = transform.position.x - 20.0f ;
        float maxX = transform.position.x + 20.0f ;
        float minY = 23.0f; // this is a good height for game play
        float maxY = 40.0f;
        float minZ = transform.position.z - 2.0f ;
        float maxZ = transform.position.z + 2.0f;

        //Spawn ship at random position near this spawner
        GameObject ship = Instantiate(prefab, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), transform.rotation);
        ship.GetComponent<AlienShip>().StartMoving(this.shipDirection);
        spawnAmount--;
        // wait between 1 and 6 seconds for spawning
        spawnTime = Random.Range(1.0f, 6.0f);
        //Start the spawn again
        if (spawnAmount > 0)
        {
            StartCoroutine(SpawnShips(spawnTime, spawnAmount, wave));
        }
        else {
            // start checking for wave winning conditions
            gameManager.GetComponent<GameManager>().checkGameStatus();
        }

    }
}
