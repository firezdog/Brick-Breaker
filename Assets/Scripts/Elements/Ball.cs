using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ayn = UnityEngine.Random;

public class Ball : MonoBehaviour
{

    [SerializeField] public Vector2 launchVelocity;
	[SerializeField] public Paddle paddle;
    [SerializeField] float rveloffsetFactor = 0.2f;
	
    Vector3 paddleBallDelta;
    Boolean ballReleased = false;

    Rigidbody2D ballBody;

    GameStatus status;

	// Use this for initialization
	void Start ()
    {
        status = FindObjectOfType<GameStatus>();
		var paddlePosition = paddle.transform.position;
		paddleBallDelta = transform.position - paddlePosition;
        ballBody = GetComponent<Rigidbody2D>();
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
        if (Input.GetMouseButtonDown(0) || status.getAutoPlay() == true)
        {
            ballReleased = true;
            ballBody.velocity = launchVelocity;
        }
    }

    private void LockBallToPaddle()
    {
        var paddlePosition = paddle.transform.position;
        float ballNewPositionY = paddlePosition.y + paddleBallDelta.y;
        transform.position = new Vector3(paddlePosition.x, ballNewPositionY, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        float x_v_Offset = ayn.Range(0f, rveloffsetFactor) * ayn.Range(-1,1);
        float y_v_Offset = ayn.Range(0f, rveloffsetFactor) * ayn.Range(-1,1);
        Vector2 velocityOffset = new Vector2(x_v_Offset, y_v_Offset);
        ballBody.velocity += velocityOffset;
    }

}
