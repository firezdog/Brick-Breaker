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
			loader.LoadNextScene();
		}
	}

	private int getNumberOfBlocks() {
		return GameObject.FindGameObjectsWithTag("block").Length;
	}

}
