using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

// Script controls "bouncing" sound for walls and paddle.

	private AudioSource source;
	
	void Start() 
	{
		source = GetComponent<AudioSource>();	
	}
	
	private void OnCollisionEnter2D() 
	{
		AudioSource.PlayClipAtPoint(source.clip, Camera.current.transform.position);
	}

}
