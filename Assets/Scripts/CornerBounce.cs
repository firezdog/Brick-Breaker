using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerBounce : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log(other.gameObject.name);
		Rigidbody2D body = other.gameObject.GetComponent<Rigidbody2D>();
		Vector2 newDirection;
		if (transform.position.x > 10) 
		{
			newDirection = new Vector2(-1,-1);
		} else {
			newDirection = new Vector2(1,-1);
		}
			
		body.velocity = newDirection.normalized * body.velocity.magnitude;
	}

}
