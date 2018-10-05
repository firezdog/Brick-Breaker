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
	}

	private void OnCollisionEnter2D(Collision2D collission)
    {
        playHitSound();
        destroyBlock();
    }

    private void destroyBlock()
    {
        Destroy(gameObject);
    }

    private void playHitSound()
    {
        int randSoundIndex = Random.Range(0, numberOfSounds);
        AudioClip toPlay = collideSounds[randSoundIndex];
        AudioSource.PlayClipAtPoint(toPlay, Camera.current.transform.position);
    }

}