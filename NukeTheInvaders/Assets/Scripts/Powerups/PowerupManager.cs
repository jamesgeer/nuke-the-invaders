using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private GameObject gameManager;
    [SerializeField] GameObject lifePowerup;
    private Vector3[] spawnLocations = { new Vector3(57, 2.16f, -19.26f),
                                         new Vector3(2.62f, 0.09f, -22.25f),
                                         new Vector3(2.62f, 0.09f, -49.75f),
                                         new Vector3(38.21f, 2.13f, -43.09f) };
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    public void startPowerup() {
        //after 7 seconds there is a chance that a powerup will spawn
        StartCoroutine(startPowerupSpawn());
    }

    IEnumerator startPowerupSpawn() {
        //Wait 7 seconds before deciding if a powerup spawns
        yield return new WaitForSeconds(7);
        var random = Random.Range(0.0f, 1.0f);
        // 20% chance to spawn a powerup
        //if (random <= 0.20f) {
            // same chance for all powerup types to spawn
            random = Random.Range(0.0f, 1.0f);
            int j = Random.Range(0, 3);
            //if (random < 0.25f) {
                Instantiate(lifePowerup, spawnLocations[j], lifePowerup.transform.rotation);
            //}
        //}
    }

    public void increaseLife() {
        gameManager.GetComponent<GameManager>().increaseLives(1);
    }
}
