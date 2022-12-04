using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestartButton : MonoBehaviour
{
	public int gameMainScene;

	public void RestartGame()
	{
		SceneManager.LoadScene(gameMainScene);
	}
}
