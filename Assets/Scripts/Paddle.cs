using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// config parameters
	[SerializeField] public float xMin = 1.25f;
	[SerializeField] public float xMax = 14.75f;
	[SerializeField] public float worldWidthUnits = 16f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float screenWidth = Screen.width;
		float xPos = Input.mousePosition.x / screenWidth * worldWidthUnits;
		xPos = Mathf.Clamp(xPos, xMin, xMax);
		Vector3 newPaddlePos = new Vector3(xPos, transform.position.y, transform.position.z);
		transform.position = newPaddlePos;
	}
}
