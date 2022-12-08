using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStarter : MonoBehaviour
{
    private GameObject gameManager;
    [SerializeField] private GameObject startText;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void Update()
    {
        TriggerEvent();
    }

    private void TriggerEvent()
    {
        // left mouse click
        if (Input.GetButtonDown("StartWave"))
        {
            gameManager.GetComponent<GameManager>().startGame();
            // make text inactive
            gameObject.SetActive(false);
            startText.SetActive(false);
        }
    }
    public void Reset()
    {
        gameObject.SetActive(true);
        startText.SetActive(true);
    }
}
