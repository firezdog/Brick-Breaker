using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	[SerializeField] AudioClip[] collideSounds;
    [SerializeField] GameObject destructionEffect;
	private int numberOfSounds;
    private GameStatus state;

	private void Start() {
		numberOfSounds = collideSounds.Length;
	}

	private void OnCollisionEnter2D()
    {
        if (gameObject.tag != "unbreakable") 
        {
            playHitSound();
            createDestroyEffect();
            destroyBlock();
            increaseScore();
        }
    }

    private void increaseScore() 
    {
        if (state == null) {
            state = FindObjectOfType<GameStatus>();
        }
        state.increaseScore();
    }

    private void destroyBlock()
    {
        Destroy(gameObject);
    }

    private void createDestroyEffect() 
    {
        GameObject thisDestructionEffect = Instantiate(
            destructionEffect, 
            gameObject.transform.position, 
            gameObject.transform.rotation
        );
        Destroy(thisDestructionEffect, 1f);
    }

    private void playHitSound()
    {
        int randSoundIndex = Random.Range(0, numberOfSounds);
        AudioClip toPlay = collideSounds[randSoundIndex];
        AudioSource.PlayClipAtPoint(toPlay, Camera.main.transform.position);
    }

}