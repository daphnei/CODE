using System;
using UnityEngine;

public static class Helpers
{
	public static void TraverseChildren(Action<GameObject> action, GameObject obj){
		action(obj);
		foreach (Transform child in obj.transform) {
			TraverseChildren(action, child.gameObject);
		}
	}
}
