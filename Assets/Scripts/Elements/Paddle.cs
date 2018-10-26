using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// config parameters
	[SerializeField] public float xMin = 1.25f;
	[SerializeField] public float xMax = 14.75f;
	[SerializeField] public float worldWidthUnits = 16f;
	GameStatus status;
	Ball ball;
	// Use this for initialization
	void Start () {
		status = FindObjectOfType<GameStatus>();
		// This doesn't work if there are multiple balls.
		ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		float xPos = status.getAutoPlay() ? autoUpdateX() : mouseInputUpdateX();
		transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
	}

	float mouseInputUpdateX() {
		float screenWidth = Screen.width;
		float xPos = Input.mousePosition.x / screenWidth * worldWidthUnits;
		return Mathf.Clamp(xPos, xMin, xMax);
	}

	float autoUpdateX() {
		return Mathf.Clamp(ball.transform.position.x, xMin, xMax);
	}

}
