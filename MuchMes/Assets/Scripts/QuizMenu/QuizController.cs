using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class QuizController : MonoBehaviour {

	public GameGUIText buttonPrefab;

	List<String> questionList = new List<string>() {"make him sad", "give up!", "the flavour is too much!!!"};

	GameGUIText header;
	GameObject questions;

	// Use this for initialization
	void Start () {
		this.header = GameObject.Find("GameGUIHeader").GetComponent<GameGUIText>();


		foreach (String s in questionList) {

		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
