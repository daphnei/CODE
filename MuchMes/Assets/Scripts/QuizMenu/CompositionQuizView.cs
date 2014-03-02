using UnityEngine;
using System.Collections;

public class CompositionQuizView : QuizView {
	public override void Fill(Question question)
	{
		CompositionQuestion compQuestions = question as CompositionQuestion;
		questionText.SetText(compQuestions.baseFood.name);
	}
}
