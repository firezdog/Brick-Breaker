using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	private int numberOfBlocks;
	private SceneLoader loader;

	void Start() {
		loader = GameObject
			.Find("SceneLoader")
			.GetComponent<SceneLoader>();
	}
	
	// Update is called once per frame
	void Update () {
		int previous = numberOfBlocks;
		numberOfBlocks = getNumberOfBlocks();
		if (numberOfBlocks == 0) {
			loader.LoadNextScene();
		}
	}

	private int getNumberOfBlocks() {
		return GameObject.FindGameObjectsWithTag("block").Length;
	}

}
