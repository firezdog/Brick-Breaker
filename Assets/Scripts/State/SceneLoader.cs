using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadNextScene()
	{
		int totalScenes = SceneManager.sceneCountInBuildSettings;
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		int nextSceneIndex = (currentSceneIndex + 1) % totalScenes;
		SceneManager.LoadScene(nextSceneIndex);
	}

	public void Quit() {
		Application.Quit();
	}

}
