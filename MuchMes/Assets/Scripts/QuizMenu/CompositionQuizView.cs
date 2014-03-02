using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CompositionQuizView : QuizView {

	protected GameGUIText choiceA;
	protected GameGUIText choiceB;
	protected GameGUIText choiceC;

	protected override void Awake ()
	{
		base.Awake ();
		foreach (GameGUIText guiText in this.transform.GetComponentsInChildren<GameGUIText>()) {
			switch(guiText.gameObject.name)
			{
			case "ChoiceA":
				choiceA = guiText;
				break;
			case "ChoiceB":
				choiceB = guiText;
				break;
			case "ChoiceC":
				choiceC = guiText;
				break;
			}
		}
	}

	public override void Fill(Question question)
	{
		CompositionQuestion compQuestions = question as CompositionQuestion;
		questionText.SetText("How much " + compQuestions.valueBeingCompared.Replace('_', ' ') + "?");

		IList<float> values = new List<float> {
			UnityEngine.Random.Range (0.25f, 4),
			UnityEngine.Random.Range (0.25f, 4),
			compQuestions.actualValue
		};

		choiceA.SetText (values[0].ToString("#.#") + " " + compQuestions.unit);
		choiceB.SetText (values[1].ToString("#.#") + " " + compQuestions.unit);
		choiceC.SetText (values[2].ToString("#.#") + " " + compQuestions.unit);

		base.Fill (question);
	}

    public override void DetectClick(GameGUIText text)
    {
        this.controller.AnswerQuestion(1f);
    }
}
