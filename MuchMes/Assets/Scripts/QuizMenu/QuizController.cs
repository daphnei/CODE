using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class QuizController : MonoBehaviour {
	
	public GameGUIText buttonPrefab;

	List<String> questionList = new List<string>() { "make him sad", "give up!", "the flavour is too much!!!" };

	GameGUIText header;
	GameObject questions;

	void Awake() {
		this.header = GameObject.Find("GameGUIHeader").GetComponent<GameGUIText>();
		this.questions = GameObject.Find("Questions");
	}
	
	// Use this for initialization
	void Start () {

		var questionsServer = RequestServer.GetQuestion();

		foreach (String s in questionList) {

		/*for (int i = 0; i < questionList.Count; i++) {
			GameGUIText button = Instantiate(buttonPrefab) as GameGUIText;
			button.SetText(questionList[i]);
			button.flyInAnimation.delay = i * 0.25f;
			button.transform.parent = questions.transform;
			button.transform.localPosition = Vector3.zero + Vector3.down * i * 1.2f;
		}*/
	}
	
	// Update is called once per frame
	void Update () {

	}
}
