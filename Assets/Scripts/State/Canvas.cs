using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour {

	void Awake () {
		int canvasCount = FindObjectsOfType<Canvas>().Length;
		if (canvasCount > 1) {
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
