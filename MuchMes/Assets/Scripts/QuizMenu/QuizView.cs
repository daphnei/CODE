using UnityEngine;
using System.Collections;
using System;

public class QuizView : MonoBehaviour {
	
	protected GameGUIText questionText;
	protected QuizController controller;

	public float transitionTime = 0.5f;
	public Action transitionAction = null;

	float transitionTimer = 0f;

	// Use this for initialization
	protected virtual void Awake () {
		this.controller = GameObject.Find("QuizController").GetComponent<QuizController>();

		foreach (GameGUIText guiText in this.transform.GetComponentsInChildren<GameGUIText>()) {
			if (guiText.gameObject.name == "QuestionText")
				questionText = guiText;
		}
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (transitionTimer > -float.Epsilon) {
			transitionTimer += Time.deltaTime;
			if (transitionTimer > transitionTime) {
				if (transitionAction != null) {
					transitionAction();
				}
				transitionTimer = -1;
			}
		}
	}

	public virtual void DetectClick(String name, int value) {
        this.controller.AnswerQuestion(1f);
	}

	public virtual void Fill(Question question) {

	}

	public void Show() {
        this.gameObject.SetActive(true);
        SetAnimationsRecursive(true, this.gameObject);
	}

	public void Hide(Action onComplete) {
		transitionTimer = 0;

		SetAnimationsRecursive(false, this.gameObject);

		transitionAction = delegate() {
			this.gameObject.SetActive(false);
			onComplete();
		};
	}

	public void SetAnimationsRecursive(bool visibility, GameObject startObj)
	{
		Helpers.TraverseChildren(delegate(GameObject obj) {
			FlyIn animation = obj.GetComponent<FlyIn>();
			if (animation != null) {
				if (visibility)
					animation.TriggerIn();
				else
					animation.TriggerOut();
			}
		}, startObj);
	}
}
