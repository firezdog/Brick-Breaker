using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour 
{

	private void OnTriggerEnter2D(Collider2D collision) 
	{
		if (gameObject.name == "Lose Collider") {
			GetComponent<AudioSource>().Play();
		}
		Invoke("GameOver", 0.2f);
	}

	private void GameOver() {
		SceneManager.LoadScene("Game Over");
	}

}
