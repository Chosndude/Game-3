using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void goToMainMenu()
	{
		SceneManager.LoadScene ("Title_Scene");
	}

	public void goToControls()
	{
		SceneManager.LoadScene ("Controls_Scene");
	}

	public void startGame()
	{
		SceneManager.LoadScene ("Scenes/Main");
	}
}
