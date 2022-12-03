using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    public GameObject scoutShip;
    private float spawnTime;
    private int spawnAmount;
    // Start is called before the first frame update
    void Start()
    {
        // wait between 1 and 6 seconds for spawning initially
        spawnTime = Random.Range(1.0f, 6.0f);
        // spawn 1-3 ships
        spawnAmount = Random.Range(1,4);
        Debug.Log(spawnAmount);
        //Start to spawn enemies
        StartCoroutine(SpawnShips(spawnTime, spawnAmount));
    }
    IEnumerator SpawnShips(float spawnTime, int spawnAmount)
    {
        //Wait spawnTime
        yield return new WaitForSeconds(spawnTime);
        // TODO: decide what ship to spawn based on wave level etc
        GameObject prefab = scoutShip;

        // calculate min x, min y and min z compared to the spawner's position

        float minX = transform.position.x - 15.0f ;
        float maxX = transform.position.x + 15.0f ;
        float minY = 23.0f; // this is a good height for gameplay
        float maxY = 40.0f;
        float minZ = transform.position.z - 5.0f ;
        float maxZ = transform.position.z + 5.0f;

        //Spawn prefab at random position near this spawner
        Instantiate(prefab, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ)), transform.rotation);
        spawnAmount--;
        // wait between 1 and 6 seconds for spawning
        spawnTime = Random.Range(1.0f, 6.0f);
        //Start the spawn again
        if (spawnAmount > 0) {
            StartCoroutine(SpawnShips(spawnTime, spawnAmount));
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
