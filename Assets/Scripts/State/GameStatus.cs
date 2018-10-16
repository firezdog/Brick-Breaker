using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameStatus : MonoBehaviour {

	[SerializeField, Range(0,2)] public float speed = 1f;
	[SerializeField] public int score;
	[SerializeField] public int pointsPerBrick;
	[SerializeField] public TextMeshProUGUI scoreDisplay;

	void Awake() 
	{
		int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
		if (gameStatusCount > 1) 
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

    public void destroy()
    {
        Destroy(gameObject);
    }

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
