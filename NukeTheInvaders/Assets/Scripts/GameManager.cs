using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int currentWave { get; set; }
    private GameObject waveManager;
    private GameObject waveStarter;
    private GameObject musicManager;
    private GameObject player;
    private int lives;
    public int restartSceneNumber;
    private Vector3 startLocation = new Vector3(80,4,-18);
    [SerializeField] private TextMeshProUGUI waveCount;
    // Start is called before the first frame update
    void Start()
    {
        lives = 1;
        currentWave = 1;
        waveCount.text = currentWave.ToString();
        waveManager = GameObject.FindGameObjectWithTag("WaveManager");
        waveStarter = GameObject.FindGameObjectWithTag("WaveStarter");
        musicManager = GameObject.FindGameObjectWithTag("MusicManager");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void startGame() {
        // start the wave, music etc here
        waveManager.GetComponent<WaveManager>().startWave(currentWave);
        musicManager.GetComponent<AudioSource>().Play();
        currentWave++;

    }
    public void checkGameStatus() {
        StartCoroutine(checkGameEnd());
    }

	IEnumerator checkGameEnd()
	{
        // check every 5 seconds if game has ended (player has won)
        yield return new WaitForSeconds(3);
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && lives > 0)
        {
            endGame(true);
        }
        else
        {
            StartCoroutine(checkGameEnd());
        }
    }

	private void endGame(bool win)
    {
        // cleanup here, teleport player to start and restart trigger
        if (win)
        {
            Debug.Log("You won this wave!");
            waveStarter.GetComponent<WaveStarter>().Reset();
            musicManager.GetComponent<AudioSource>().Stop();

            // This would teleport the player to the start location (not used at the moment)
            //player.transform.position = startLocation;
            waveCount.text = currentWave.ToString();
        }
        else {
            SceneManager.LoadScene(restartSceneNumber);
        }

    }

    public void reduceLives(int amount) {
        lives -= amount;
        if (lives <= 0)
        {
            endGame(false);
        }
    }
}
