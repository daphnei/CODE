using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CompositionQuizView : QuizView {

	protected GameGUIText choiceA;
	protected GameGUIText choiceB;
	protected GameGUIText choiceC;

	List<GameGUIText> choices = new List<GameGUIText>();

	CompositionQuestion q;

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

		choices.Add(choiceA);
		choices.Add(choiceB);
		choices.Add(choiceC);
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

		values.Shuffle();

		for (int i = 0; i < choices.Count; i++) {
			choices[i].SetTextPure(values[i].ToString("#.#"));
			choices[i].value = values[i];
			choices[i].renderer.material.color = choices[i].startColor;
		}

		base.Fill (question);
		q = compQuestions;
	}

    public override void DetectClick(GameGUIText text)
    {
		if (clicked)
			return;
		
		clicked = true;
		
		text.renderer.material.color = Color.red;
		foreach(GameGUIText t in choices)
			if (t.value == q.actualValue)
				t.renderer.material.color = Color.green;
		
		float result = text.value == q.actualValue  ? 1f : 0f;
		
		TimerManager.instance.StartTimer(delegate {
				this.controller.AnswerQuestion(result);
		}, 1);
    }
}
