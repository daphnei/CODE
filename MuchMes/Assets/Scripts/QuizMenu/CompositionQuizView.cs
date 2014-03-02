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
		questionText.SetText("How much of " + compQuestions.baseFood.NameItem + " does it take to get the " + compQuestions.valueBeingCompared.Replace('_', ' ') + " in " + compQuestions.composedFood.NameItem  + "?");

		IList<float> values = new List<float> {
			UnityEngine.Random.Range (1f, 4),
			UnityEngine.Random.Range (1f, 4),
			compQuestions.actualValue
		};

		choiceA.SetText (values[0].ToString("#.#"));
		choiceB.SetText (values[1].ToString("#.#"));
		choiceC.SetText (values[2].ToString("#.#"));

		base.Fill (question);
	}

    public override void DetectClick(GameGUIText text)
    {
        this.controller.AnswerQuestion(1f);

		if (clicked)
			return;
		
		clicked = true;
		
		/*text.renderer.material.color = Color.red;
		
		bool winnerIsA = currentQuestion.foodA.amount > currentQuestion.foodB.amount;
		bool choosenA = text.name == "ButtonA";
		
		GameGUIText winner = winnerIsA ? buttonAText : buttonBText;
		winner.renderer.material.color = Color.green;
		
		float result = winnerIsA == choosenA ? 1f : 0f;*/
		
		TimerManager.instance.StartTimer(delegate {
			this.controller.AnswerQuestion(1);//result);
		}, 1);
    }
}
