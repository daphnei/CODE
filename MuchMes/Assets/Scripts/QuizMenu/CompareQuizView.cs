using UnityEngine;
using System.Collections;

public class CompareQuizView : QuizView {

	protected GameGUIText optionAText;
	protected GameGUIText optionBText;
    protected ImageView optionAImg;
    protected ImageView optionBImg;

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
        foreach (ImageView guiText in this.transform.GetComponentsInChildren<ImageView>())
        {
            switch (guiText.gameObject.name)
            {
                case "ImageViewA":
                    optionAImg = guiText; break;
                case "ImageViewB":
                    optionBImg = guiText; break;
            }
        }
	}

	public override void Fill(Question question)
	{
		CompareQuestion compQuestions = question as CompareQuestion;
		questionText.SetText("Which has more " + compQuestions.valueBeingCompared + "?");
        optionAText.SetTextPure(FormatFood(compQuestions.foodA));
        optionBText.SetTextPure(FormatFood(compQuestions.foodB));
	}

    private string FormatFood(FoodAndAmount f)
    {
        int capName = 16;
        int capDes = 28;
        int capGenre = 16;
        return "<size=35>" + f.genre.Cap(capGenre) + "</size>\n" + f.NameItem.Cap(capName) + "\n<size=35>" + f.NameDetails.Cap(capDes) + "</size>";
    }

	 public override void DetectClick(string name, int value)
	{
		base.DetectClick(name, value);
	}
}
