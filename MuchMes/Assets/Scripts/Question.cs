using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System.Text;
using System;
using SimpleJSON;

public class Question
{
	public FoodAndAmount foodA;
	public FoodAndAmount foodB;

	public virtual void SetPropertiesFromJSON(JSONNode node) {
		foodA = FoodAndAmount.FromJSON(node["food1"]);
		foodB = FoodAndAmount.FromJSON(node["food2"]);
	}

	public static Question FromJSON(JSONNode node) {
		Question result;

		switch (node["question_type"].Value) {
			case "composition":
				result = new CompositionQuestion();
				break;
			case "compare":
				result = new CompareQuestion();
				break;
			default:
				throw new InvalidOperationException("Unrecognized question type.");
		}

		result.SetPropertiesFromJSON(node);
		return result;
	}
}

public class CompositionQuestion : Question {
	public string valueBeingCompared;
	public FoodAndAmount baseFood;
	public FoodAndAmount composedFood;
	public float actualValue;
	public string unit;

	public override void SetPropertiesFromJSON(JSONNode node) {
		base.SetPropertiesFromJSON (node);

		baseFood = this.foodB;
		composedFood = this.foodA;

		valueBeingCompared = node["parameter"].Value;
		actualValue = composedFood.amount / baseFood.amount;
		unit = node ["unit"].Value;
	}
}


public class CompareQuestion : Question {
	public string valueBeingCompared;
	
	public override void SetPropertiesFromJSON(JSONNode node) {
		base.SetPropertiesFromJSON (node);

		valueBeingCompared = node["parameter"].Value;
	}
}
