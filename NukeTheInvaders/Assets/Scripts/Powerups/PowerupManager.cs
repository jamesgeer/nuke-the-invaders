using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private GameObject gameManager;
    private GameObject player;
    [SerializeField] GameObject lifePowerup;
    [SerializeField] GameObject ammoPowerup;
    private Vector3[] spawnLocations = { new Vector3(57, 2.16f, -19.26f),
                                         new Vector3(2.62f, 0.09f, -22.25f),
                                         new Vector3(2.62f, 0.09f, -49.75f),
                                         new Vector3(38.21f, 2.13f, -43.09f) };
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void startPowerup() {
        //after 7 seconds there is a chance that a powerup will spawn
        StartCoroutine(startPowerupSpawn());
    }

    IEnumerator startPowerupSpawn() {
        //Wait 4 seconds before deciding if a powerup spawns
        yield return new WaitForSeconds(4);
        var random = Random.Range(0.0f, 1.0f);
        // 65% chance to spawn a powerup
        if (random <= 0.65f) {
            // same chance for all powerup types to spawn
            random = Random.Range(0.0f, 1.0f);
            int j = Random.Range(0, 3);
            if (random < 0.5f)
            {
                Instantiate(lifePowerup, spawnLocations[j], lifePowerup.transform.rotation);
            }
            else {
                Instantiate(ammoPowerup, spawnLocations[j], ammoPowerup.transform.rotation);
            }
        }
    }

    public void increaseLife() {
        gameManager.GetComponent<GameManager>().increaseLives(1);
    }

    public void giveAmmo()
    {
        player.GetComponent<Player>().refillRedAmmo(5);
    }
}
