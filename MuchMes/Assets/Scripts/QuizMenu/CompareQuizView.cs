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
		optionAText.SetText(compQuestions.foodA.NameItem);
		optionBText.SetText(compQuestions.foodB.NameItem);
        optionAText.transform.FindChild("Subtitle").GetComponent<GameGUIText>().SetText(compQuestions.foodA.NameDetails);
        optionBText.transform.FindChild("Subtitle").GetComponent<GameGUIText>().SetText(compQuestions.foodB.NameDetails);
	}

	 public override void DetectClick(string name, int value)
	{
		base.DetectClick(name, value);
	}
}
