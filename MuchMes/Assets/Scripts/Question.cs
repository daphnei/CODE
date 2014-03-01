using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System.Text;
using System;
using SimpleJSON;

public abstract class Question
{
	public abstract void SetPropertiesFromJSON(JSONNode node);

	public static Question FromJSON(JSONNode node) {
		Question result;

		switch (node["question_type"].Value) {
		case "composition":
			result = new CompositionQuestion();
			break;
		default:
			throw new InvalidOperationException("Unrecognized question type.");
		}

		result.SetPropertiesFromJSON(node);
		return result;
	}
}

public class CompositionQuestion : Question {
	public FoodAndAmount baseFood;
	public FoodAndAmount composedFood;

	public override void SetPropertiesFromJSON(JSONNode node) {
		baseFood = FoodAndAmount.FromJSON(node["food1"]);
		composedFood = FoodAndAmount.FromJSON(node["food2"]);
	}
}
