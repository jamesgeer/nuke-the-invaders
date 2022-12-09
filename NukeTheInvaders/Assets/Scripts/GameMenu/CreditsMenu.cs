using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour
{
	public GameObject credits;

	public void CreditsOpen()
	{
		credits.SetActive(true);
	}
	public void CreditsClose()
	{
		Debug.Log("test");
		credits.SetActive(false);
	}
}
