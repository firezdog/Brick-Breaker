using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

// Script controls "bouncing" sound for walls and paddle.
	private void OnCollisionEnter2D(Collision2D other) {
		GetComponent<AudioSource>().Play();
	}

}
