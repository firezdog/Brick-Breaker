using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	int currentSceneIndex;
	int totalScenes;

	public void Start() {
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		totalScenes = SceneManager.sceneCountInBuildSettings;
		resetGameStatus();
	}

    private void resetGameStatus()
    {
        if (currentSceneIndex == 0)
		{
			GameStatus status = FindObjectOfType<GameStatus>();
			if (status != null) {
				status.destroy();
			}
		}
    }

    public void LoadNextScene()
	{
		int totalScenes = SceneManager.sceneCountInBuildSettings;
		int nextSceneIndex = (currentSceneIndex + 1) % totalScenes;
		SceneManager.LoadScene(nextSceneIndex);
	}

	public void Quit() {
		Application.Quit();
	}

}
