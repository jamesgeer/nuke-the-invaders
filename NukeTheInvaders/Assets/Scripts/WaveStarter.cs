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
        // "F5" starts the wave
        if (Input.GetButtonDown("StartWave"))
        {
            gameManager.GetComponent<GameManager>().startGame();
            
            // deactivate this so that player can't start another wave
            gameObject.SetActive(false);
            // make text inactive
            startText.SetActive(false);
        }
    }
    public void Reset()
    {
        // reactivate everything
        gameObject.SetActive(true);
        startText.SetActive(true);
    }
}
