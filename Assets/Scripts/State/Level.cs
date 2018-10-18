using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	[SerializeField] int numberOfBlocks; // serialized for debugging
	private SceneLoader loader;

	void Start() {
		loader = FindObjectOfType<SceneLoader>();
	}
	
	// Update is called once per frame
	void Update () {
		numberOfBlocks = getNumberOfBlocks();
		if (numberOfBlocks == 0) {
			Invoke("loadNextSceneWrapper", 0.25f);
		}
	}

	private int getNumberOfBlocks() {
		return 	FindObjectsOfType<Block>().Length - 
				GameObject.FindGameObjectsWithTag("unbreakable").Length;
	}

	private void loadNextSceneWrapper() {
		loader.LoadNextScene();
	}

}
