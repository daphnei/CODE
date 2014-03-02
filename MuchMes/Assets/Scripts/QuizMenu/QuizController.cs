using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class QuizController : MonoBehaviour {
	
	// public GameGUIText buttonPrefab;

	GameGUIText header;

	List<QuizView> quizViews = new List<QuizView>();
	QuizView compositionQuizView;
	QuizView compareQuizView;

	QuizView currentQuizView = null;

	List<Question> questions = new List<Question>();
    int questionNumber = 1;

	void Awake() {
		this.header = GameObject.Find("GameGUIHeader").GetComponent<GameGUIText>();
		foreach (QuizView view in GameObject.FindObjectsOfType<QuizView>()) {
			quizViews.Add(view);
			switch (view.gameObject.name) {
				case "CompositionQuizView":
					compositionQuizView = view;
					break;
				case "CompareQuizView":
					compareQuizView = view;
					break;
			}
		}
		if (compositionQuizView == null)
			Debug.LogWarning("No composition view!");
		if (compareQuizView == null)
			Debug.LogWarning("No compare view!");
	}
	
	// Use this for initialization
	void Start () {
		foreach (QuizView view in quizViews)
			view.gameObject.SetActive(false);

		this.questions = RequestServer.GetQuestions();
		NextQuestion();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void AnswerQuestion(float correctness) {
        questionNumber++;
        header.SetText("Question " + questionNumber);
        NextQuestion();
    }

	public void NextQuestion() {
		Question question = questions[0];
		questions.RemoveAt(0);

		Action next = delegate() {
			if (question is CompositionQuestion)
				this.currentQuizView = compositionQuizView;
			else if (question is CompareQuestion)
				this.currentQuizView = compareQuizView;

			if (currentQuizView == null) {
				NextQuestion();
				return;
			}

			this.currentQuizView.Show();
			this.currentQuizView.Fill(question);
		};

		if (this.currentQuizView != null)
			this.currentQuizView.Hide(next);
		else
			next();
	}

	// Because take a crazy chance!!!
	/*for (int i = 0; i < questionList.Count; i++) {
			GameGUIText button = Instantiate(buttonPrefab) as GameGUIText;
			button.SetText(questionList[i]);
			button.flyInAnimation.delay = i * 0.25f;
			button.transform.parent = questions.transform;
			button.transform.localPosition = Vector3.zero + Vector3.down * i * 1.2f;
		}*/
}
