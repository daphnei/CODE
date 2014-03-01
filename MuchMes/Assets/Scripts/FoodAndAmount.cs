using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System.Text;
using System;
using SimpleJSON;

public class FoodAndAmount
{
	public string name;
	public string genre;
	public float amount;

	public static FoodAndAmount FromJSON(JSONNode node) {
		return new FoodAndAmount {
			name = node["name"].Value, genre = node["genre"].Value,
			amount = node["amount"].AsInt
		};
	}
}


