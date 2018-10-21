using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    //health and affordances
    [SerializeField] int maxHealth;
    private int currentHealth;
    [SerializeField] Sprite[] healthSprites;
    	
    //sounds
    [SerializeField] AudioClip[] collideSounds;
	private int numberOfSounds;
    private Vector3 cameraPostion;

    //destruction
    [SerializeField] GameObject destructionEffect;

    //book-keeping
    private GameStatus state;

	private void Start() {
		numberOfSounds = collideSounds.Length;
        currentHealth = maxHealth;
        cameraPostion = Camera.main.transform.position;
	}

	private void OnCollisionEnter2D()
    {
        if (gameObject.tag != "unbreakable") 
        {
            if (currentHealth <= 1) 
            {
                createDestroyEffect();
                destroyBlock();
                increaseScore();
            } 
            else {
                currentHealth--;
                replaceSprite();
                
            }
        }
        playHitSound();
    }

    private void replaceSprite() 
    {
        var rend = gameObject.GetComponent<SpriteRenderer>();
        rend.sprite = healthSprites[currentHealth-1];
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
        AudioSource.PlayClipAtPoint(toPlay, cameraPostion);
    }

}