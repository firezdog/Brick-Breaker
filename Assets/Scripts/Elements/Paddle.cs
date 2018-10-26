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
		Vector3 newPaddlePos = new Vector3();
		if (status.autoPlay == false) {
			mouseInputUpdatePaddle(newPaddlePos);
		} else {
			autoUpdatePaddle(newPaddlePos);
		}
	}

	void mouseInputUpdatePaddle(Vector3 newPaddlePos) {
		float screenWidth = Screen.width;
		float xPos = Input.mousePosition.x / screenWidth * worldWidthUnits;
		xPos = Mathf.Clamp(xPos, xMin, xMax);
		newPaddlePos = new Vector3(xPos, transform.position.y, transform.position.z);
		transform.position = newPaddlePos;
	}

	void autoUpdatePaddle(Vector3 newPaddlePos) {
		float xPos = Mathf.Clamp(ball.transform.position.x, xMin, xMax);
		newPaddlePos = new Vector3(xPos, transform.position.y, transform.position.z);
		transform.position = newPaddlePos;
	}

}
