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
			}
		}
	}

	public override void Fill(Question question)
	{
		CompareQuestion compQuestions = question as CompareQuestion;
		questionText.SetText("Which has more " + compQuestions.valueBeingCompared.Replace('_', ' ') + "?");

		base.Fill (question);
	}


	public override void DetectClick(GameGUIText text)
	{
        if (beingHidden)
            return;

        text.renderer.material.color = Color.red;

        bool winnerIsA = currentQuestion.foodA.amount > currentQuestion.foodB.amount;
        bool choosenA = text.name == "ButtonA";

        GameGUIText winner = winnerIsA ? buttonAText : buttonBText;
        winner.renderer.material.color = Color.green;
            
        float result = winnerIsA == choosenA ? 1f : 0f;
        this.controller.AnswerQuestion(result);
	}
}

