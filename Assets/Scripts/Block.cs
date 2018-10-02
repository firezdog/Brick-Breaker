using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D collission) {
		if (gameObject.tag == "block") {
			GetComponent<AudioSource>().Play();
			GetComponent<SpriteRenderer>().enabled = false;
		}
		Invoke("Break", 0.1f);
	}

	private void Break() {
		Destroy(gameObject);
	}
}
