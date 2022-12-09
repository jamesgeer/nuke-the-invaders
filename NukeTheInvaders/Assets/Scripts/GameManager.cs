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
    private GameObject powerupManager;
    private int lives;
    public int restartSceneNumber;
    [SerializeField] private TextMeshProUGUI waveCount;
    [SerializeField] private TextMeshProUGUI livesCount;
    // Start is called before the first frame update
    void Start()
    {
        // starts with 10 lives
        lives = 10;
        livesCount.text = lives.ToString();
        // initiate wave counter
        currentWave = 1;
        waveCount.text = currentWave.ToString();
        
        waveManager = GameObject.FindGameObjectWithTag("WaveManager");
        powerupManager = GameObject.FindGameObjectWithTag("PowerUpManager");
        waveStarter = GameObject.FindGameObjectWithTag("WaveStarter");
        musicManager = GameObject.FindGameObjectWithTag("MusicManager");
    }

    public void startGame() {
        // start the wave, music etc here
        waveManager.GetComponent<WaveManager>().startWave(currentWave);
        powerupManager.GetComponent<PowerupManager>().startPowerup();
        musicManager.GetComponent<AudioSource>().Play();
        currentWave++;

    }
    public void checkGameStatus() {
        // start checking if the wave has ended
        StartCoroutine(checkGameEnd());
    }

	IEnumerator checkGameEnd()
	{
        // check every 3 seconds if game has ended (player has won)
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
        // cleanup here and restart trigger
        if (win)
        {
            waveStarter.GetComponent<WaveStarter>().Reset();
            musicManager.GetComponent<AudioSource>().Stop();

            waveCount.text = currentWave.ToString();
        }
        else { // load restart scene if the player has lost
            SceneManager.LoadScene(restartSceneNumber);
        }

    }

    public void reduceLives(int amount) {
        lives -= amount;
        livesCount.text = lives.ToString();
        if (lives <= 0)
        {
            endGame(false);
        }
    }

    public void increaseLives(int amount)
    {
        lives += amount;
        livesCount.text = lives.ToString();
    }

    void Update()
    {
        TriggerEvent();
    }

    private void TriggerEvent()
    {
        // when player presses "P" he quits to main menu
        if (Input.GetButtonDown("Quit"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
