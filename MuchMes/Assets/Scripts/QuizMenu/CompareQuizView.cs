using UnityEngine;
using System.Collections;

public class CompareQuizView : QuizView {

	protected GameGUIText optionAText;
	protected GameGUIText optionBText;

	protected override void Awake()
	{
		base.Awake();

		foreach (GameGUIText guiText in this.transform.GetComponentsInChildren<GameGUIText>()) {
			switch(guiText.gameObject.name)
			{
				case "OptionA":
					optionAText = guiText; break;
				case "OptionB":
					optionBText = guiText; break;
			}
		}

	}

	public override void Fill(Question question)
	{
		CompareQuestion compQuestions = question as CompareQuestion;
		questionText.SetText("Which has more " + compQuestions.valueBeingCompared + "?");
        optionAText.SetTextPure(compQuestions.foodA.NameItem + "\n<size=30>" + compQuestions.foodA.NameDetails + "</size>");
		optionBText.SetTextPure(compQuestions.foodB.NameItem + "\n<size=30>" + compQuestions.foodB.NameDetails + "</size>");
	}

	 public override void DetectClick(string name, int value)
	{
		base.DetectClick(name, value);
	}
}
