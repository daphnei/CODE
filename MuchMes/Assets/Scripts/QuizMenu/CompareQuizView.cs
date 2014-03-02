using UnityEngine;
using System.Collections;

public class CompareQuizView : QuizView {
	
    protected GameGUIText buttonAText;
    protected GameGUIText buttonBText;

    private CompareQuestion currentQuestion;


	protected override void Awake()
	{
		base.Awake();

		foreach (GameGUIText guiText in this.transform.GetComponentsInChildren<GameGUIText>()) {
			switch(guiText.gameObject.name)
			{
			case "ButtonA":
				buttonAText = guiText;
				break;
			case "ButtonB":
				buttonBText = guiText;
				break;
			}
		}

		if (buttonAText == null)
			Debug.LogWarning("BUTTON A NO GO!!");
		if (buttonBText == null)
			Debug.LogWarning("BUTTON B NO GO!!");
	}

	public override void Fill(Question question)
	{
		CompareQuestion compQuestions = question as CompareQuestion;
		currentQuestion = compQuestions;
		questionText.SetText("Which has more " + compQuestions.valueBeingCompared.Replace('_', ' ') + "?");

		buttonAText.renderer.material.color = buttonAText.startColor;
		buttonBText.renderer.material.color = buttonBText.startColor;

		base.Fill (question);
	}


	public override void DetectClick(GameGUIText text)
	{
        if (clicked)
            return;

		clicked = true;

        text.renderer.material.color = Color.red;

        bool winnerIsA = currentQuestion.foodA.amount > currentQuestion.foodB.amount;
        bool choosenA = text.name == "ButtonA";

        GameGUIText winner = winnerIsA ? buttonAText : buttonBText;
        winner.renderer.material.color = Color.green;
            
        float result = winnerIsA == choosenA ? 1f : 0f;

		TimerManager.instance.StartTimer(delegate {
			this.controller.AnswerQuestion(result);
		}, 1);
        
	}
}

