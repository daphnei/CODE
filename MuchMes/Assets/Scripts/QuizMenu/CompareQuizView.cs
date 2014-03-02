using UnityEngine;
using System.Collections;

public class CompareQuizView : QuizView {


	protected override void Awake()
	{
		base.Awake();

		foreach (GameGUIText guiText in this.transform.GetComponentsInChildren<GameGUIText>()) {
			switch(guiText.gameObject.name)
			{
			}
		}

	}

	public override void Fill(Question question)
	{
		CompareQuestion compQuestions = question as CompareQuestion;
		questionText.SetText("Which has more " + compQuestions.valueBeingCompared.Replace('_', ' ') + "?");

		base.Fill (question);
	}


	public override void DetectClick(string name, int value)
	{
		base.DetectClick(name, value);
	}
}

