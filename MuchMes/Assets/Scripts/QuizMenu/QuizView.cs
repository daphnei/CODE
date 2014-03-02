using UnityEngine;
using System.Collections;
using System;

public class QuizView : MonoBehaviour {
	
	protected GameGUIText questionText;
	protected QuizController controller;
	protected ImageView optionAImg;
	protected ImageView optionBImg;

	public float transitionTime = 0.5f;
	public Action transitionAction = null;
	float transitionTimer = 0f;

    protected bool beingHidden = true;

	// Use this for initialization
	protected virtual void Awake () {
		this.controller = GameObject.Find("QuizController").GetComponent<QuizController>();

		foreach (GameGUIText guiText in this.transform.GetComponentsInChildren<GameGUIText>()) {
			if (guiText.gameObject.name == "QuestionText")
				questionText = guiText;
		}
		foreach (ImageView guiText in this.transform.GetComponentsInChildren<ImageView>())
		{
			switch (guiText.gameObject.name)
			{
			case "ImageViewA":
				optionAImg = guiText;
				break;
			case "ImageViewB":
				optionBImg = guiText;
				break;
		  }
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

	public virtual void DetectClick(GameGUIText text) {

	}

	public virtual void Fill(Question question) {

	}

	public void Show() {
        beingHidden = false;
        SetAnimationsRecursive(true, this.gameObject);
        ShowNoAnimate();
	}

	public void Hide(Action onComplete) {
        beingHidden = true;
		transitionTimer = 0;

		SetAnimationsRecursive(false, this.gameObject);

		transitionAction = delegate() {
            HideNoAnimate();
			onComplete();
		};
	}

    public void HideNoAnimate()
    {
        beingHidden = true;
        Helpers.SetRenderer(this.gameObject, false);
    }

    public void ShowNoAnimate()
    {
        beingHidden = false;
        Helpers.SetRenderer(this.gameObject, true);
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
