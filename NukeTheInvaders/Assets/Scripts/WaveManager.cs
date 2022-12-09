using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private GameObject waveSpawner;
    private Vector3 shipDirection;
    private Vector3[] spawnLocations = { new Vector3(15, 40, -135),
                                         new Vector3(15, 40, 105),
                                         new Vector3(-100, 40, -15),
                                         new Vector3(155, 40, -15) };
    private GameObject endZone;

    // Start is called before the first frame update
    void Start()
    {
        waveSpawner = GameObject.FindGameObjectWithTag("WaveSpawner");
        endZone = GameObject.FindGameObjectWithTag("ShipDestination");
    }

    public void startWave(int wave) {
        // randomly select a position for the wave to come from
        int locationIndex = Random.Range(0, 4);
        waveSpawner.transform.position = spawnLocations[locationIndex];
        endZone.transform.position = new Vector3(-100, 40, -15);
        endZone.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

		#region Rotate spawner, endzone and ships
		// also rotate the spawner so that the ships face the correct direction
		// and place endzone at the opposite side
		switch (locationIndex) {
            case 0:
                endZone.transform.position = spawnLocations[1];
                endZone.transform.Rotate(0, 90, 0);
                waveSpawner.transform.LookAt(endZone.transform.position);
                shipDirection = new Vector3(0,0,1);
                break;
            case 1:
                endZone.transform.position = spawnLocations[0];
                endZone.transform.Rotate(0, 90, 0);
                waveSpawner.transform.LookAt(endZone.transform.position);
                shipDirection = new Vector3(0,0,-1);
                break;
            case 2:
                endZone.transform.position = spawnLocations[3];
                waveSpawner.transform.LookAt(endZone.transform.position);
                shipDirection = new Vector3(1,0,0);
                break;
            case 3:
                endZone.transform.position = spawnLocations[2];
                waveSpawner.transform.LookAt(endZone.transform.position);
                shipDirection = new Vector3(-1,0,0);
                break;
        }
        #endregion

        waveSpawner.GetComponent<SpawnWave>().startSpawn(shipDirection, wave);
        endZone.SetActive(true);
    }
}
