using UnityEngine;
using System.Collections;

public class CompareQuizView : QuizView {

	protected GameGUIText optionAText;
	protected GameGUIText optionBText;
    protected GameGUIText buttonAText;
    protected GameGUIText buttonBText;

    private CompareQuestion currentQuestion;

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
                case "AButton":
                    buttonAText = guiText; break;
                case "BButton":
                    buttonBText = guiText; break;
			}
		}
	}

	public override void Fill(Question question)
	{
		CompareQuestion compQuestions = question as CompareQuestion;
		questionText.SetText("Which has more " + compQuestions.valueBeingCompared.Replace('_', ' ') + "?");
        optionAText.SetTextPure(FormatFood(compQuestions.foodA));
        optionBText.SetTextPure(FormatFood(compQuestions.foodB));
        optionAImg.UpdatePicture(compQuestions.foodA.image);
        optionBImg.UpdatePicture(compQuestions.foodB.image);
        buttonAText.renderer.material.color = buttonAText.startColor;
        buttonBText.renderer.material.color = buttonBText.startColor;
        currentQuestion = compQuestions;
	}

    private string FormatFood(FoodAndAmount f)
    {
        int capName = 16;
        int capDes = 28;
        int capGenre = 16;
        return "<size=35>" + f.genre.Cap(capGenre) + "</size>\n" + f.NameItem.Cap(capName) + "\n<size=35>" + f.NameDetails.Cap(capDes) + "</size>";
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

