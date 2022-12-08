using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    [SerializeField] private GameObject scoutShip;
    [SerializeField] private GameObject speederShip;
    private float spawnTime;
    private int spawnAmount;
    private Vector3 shipDirection;
    private GameObject gameManager;
	private void Start()
	{
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
	}
	public void startSpawn(Vector3 shipDirection, int wave) {
        // wait between 3 and 6 seconds for spawning initially
        spawnTime = Random.Range(3.0f, 6.0f);
        // spawn ships based on wave count

        // a bit of RNG here
        spawnAmount = Random.Range(wave, wave + 3);
        this.shipDirection = shipDirection;

        //Start to spawn enemies
        StartCoroutine(SpawnShips(spawnTime, spawnAmount, wave));
    }
    IEnumerator SpawnShips(float spawnTime, int spawnAmount, int wave)
    {
        //Wait spawnTime
        yield return new WaitForSeconds(spawnTime);
        // till wave 3 only spawn scout ships, every 6 waves a boss ship appears
        GameObject prefab;
        if (wave > 3)
        {
            float random = Random.Range(0.0f, 1.0f);
            // 25% for a speeder
            if (random > 0.25f)
            {
                prefab = scoutShip;
            }
            else {
                prefab = speederShip;
            }
        }
        else
        {
            prefab = scoutShip;
        }



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
        // wait between 3 and 6 seconds for spawning
        spawnTime = Random.Range(3.0f, 6.0f);
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
