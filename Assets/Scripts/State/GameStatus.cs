using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {

	[SerializeField, Range(0,2)] public float speed = 1f;
	[SerializeField] public int score;
	[SerializeField] public int pointsPerBrick;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		Time.timeScale = speed;
	}

	public void increaseScore ()
	{
		score += pointsPerBrick;
	}

}
