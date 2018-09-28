using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    // config
    // get paddle
    [SerializeField] public Vector2 launchVelocity;
	[SerializeField] public Paddle paddle;
	Vector3 paddleBallDelta;
    Boolean ballReleased = false;

	// Use this for initialization
	void Start ()
    {
		var paddlePosition = paddle.transform.position;
		paddleBallDelta = transform.position - paddlePosition;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!ballReleased)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
	}

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ballReleased = true;
            var rigid_body = GetComponent<Rigidbody2D>();
            rigid_body.velocity = launchVelocity;
        }
    }

    private void LockBallToPaddle()
    {
        var paddlePosition = paddle.transform.position;
        float ballNewPositionY = paddlePosition.y + paddleBallDelta.y;
        transform.position = new Vector3(paddlePosition.x, ballNewPositionY, transform.position.z);
    }

}
