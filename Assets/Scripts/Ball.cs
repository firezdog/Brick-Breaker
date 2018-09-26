using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	// config
	// get paddle
	[SerializeField] public Paddle paddle;
	Vector3 paddleBallDelta;

	// Use this for initialization
	void Start () {
		var paddlePosition = paddle.transform.position;
		paddleBallDelta = transform.position - paddlePosition;
	}
	
	// Update is called once per frame
	void Update () {
		var paddlePosition = paddle.transform.position;
		float ballNewPositionY = paddlePosition.y + paddleBallDelta.y;
		transform.position = new Vector3(paddlePosition.x, ballNewPositionY, transform.position.z);
	}
}
