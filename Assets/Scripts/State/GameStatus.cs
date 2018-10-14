using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

	[SerializeField, Range(0,2)] public float speed = 1f;
	[SerializeField] public int score = 0;
	[SerializeField] public int pointsPerBrick;
	[SerializeField] public TMP_Text scoreDisplay;

	// Use this for initialization
	void Start () 
	{
		scoreDisplay.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Time.timeScale = speed;
	}

	public void increaseScore ()
	{
		score += pointsPerBrick;
		scoreDisplay.text = score.ToString();
	}

}
