using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class QuizController : MonoBehaviour {
	
	// public GameGUIText buttonPrefab;

	GameGUIText header;
		GameGUIText scoreText;
		int score = 0;

	List<QuizView> quizViews = new List<QuizView>();
	QuizView compositionQuizView;
	QuizView compareQuizView;

	QuizView currentQuizView = null;

	List<Question> questions = new List<Question>();
    int questionNumber = 1;

		Dictionary<string, GameObject> catStates;
		public string currentCatState = "Neutral";

	void Awake() {
				this.score = 0;
		this.header = GameObject.Find("GameGUIHeader").GetComponent<GameGUIText>();
		this.scoreText = GameObject.Find ("ScoreHeader").GetComponent<GameGUIText> ();
				this.scoreText.SetTextPure("Score: " + 0);
				this.catStates = new Dictionary<string, GameObject> {
						{"Happy", GameObject.Find("HappyCat")},
						{"Neutral", GameObject.Find("NeutralCat")},
						{"Sad", GameObject.Find("SadCat")},
				};
				this.catStates ["Happy"].SetActive (false);
				this.catStates ["Sad"].SetActive (false);
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

		private void SetCatState(string newState) {
				catStates [this.currentCatState].SetActive (false);
				catStates [newState].SetActive (true);
				this.currentCatState = newState;
		}
	
	// Use this for initialization
	void Start () {
        foreach (QuizView view in quizViews)
            view.HideNoAnimate();

		this.questions = RequestServer.GetQuestions();
		NextQuestion();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void IncrementScore(int score) {
		this.score += score;
				this.scoreText.SetTextPure ("Score: " + this.score);
	}
    public void AnswerQuestion(float correctness) {
        questionNumber++;
		header.SetTextPure("Q." + questionNumber);
        NextQuestion();
				Debug.Log ("Answered question with correctness: " + correctness);
				this.IncrementScore ((int)(correctness * 20));
				if (Mathf.Approximately(correctness, 1)) {
						if (currentCatState == "Neutral") {
								this.SetCatState ("Happy");
						} else if (currentCatState == "Sad") {
								this.SetCatState("Neutral");
						}
				} else if (Mathf.Approximately(correctness, 0)) {
						if (currentCatState == "Neutral") {
								this.SetCatState ("Sad");
						} else if (currentCatState == "Happy") {
								this.SetCatState("Neutral");
						}
				}
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
