using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	[SerializeField] AudioClip[] collideSounds;
	private int numberOfSounds;
	private AudioSource player;
	private SpriteRenderer rend;

	private void Start() {
		numberOfSounds = collideSounds.Length;
		player = GetComponent<AudioSource>();
		rend = GetComponent<SpriteRenderer>();
	}

	private void OnCollisionEnter2D(Collision2D collission) {
		if (gameObject.tag == "block") {
			int randSoundIndex = Random.Range(0, numberOfSounds);
			AudioClip toPlay = collideSounds[randSoundIndex];
			player.PlayOneShot(clip: toPlay);
			rend.enabled = false;
		}
		Invoke("Break", 0.1f);
	}

	private void Break() {
		Destroy(gameObject);
	}
}
