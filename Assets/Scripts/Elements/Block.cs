using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	[SerializeField] AudioClip[] collideSounds;
	private int numberOfSounds;
    private GameStatus state;

	private void Start() {
		numberOfSounds = collideSounds.Length;
	}

	private void OnCollisionEnter2D()
    {
        playHitSound();
        destroyBlock();
        if (state == null) {
            state = FindObjectOfType<GameStatus>();
        }
        state.increaseScore();
    }

    private void destroyBlock()
    {
        Destroy(gameObject);
    }

    private void playHitSound()
    {
        int randSoundIndex = Random.Range(0, numberOfSounds);
        AudioClip toPlay = collideSounds[randSoundIndex];
        AudioSource.PlayClipAtPoint(toPlay, Camera.main.transform.position);
    }

}