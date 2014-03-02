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
    public string image;

    public string NameItem {
        get {
            int i = name.IndexOf(',');
            if (i < 0)
                return name;
            return name.Substring(0, i).Trim();
        }
    }
    public string NameDetails { 
        get {
            int i = name.IndexOf(',');
            if (i < 0)
                return "";
            return name.Substring(i+1).Trim();
        }
    }

	public static FoodAndAmount FromJSON(JSONNode node) {
		return new FoodAndAmount {
			name = node["name"].Value, 
			genre = node["genre"].Value,
			amount = node["amount"].AsInt,
            image = node["image"].Value
		};
	}
}


