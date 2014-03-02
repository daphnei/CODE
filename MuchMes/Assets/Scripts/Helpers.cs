using System;
using UnityEngine;
using System.Collections.Generic;

public static class Helpers
{
	public static void TraverseChildren(Action<GameObject> action, GameObject obj){
		action(obj);
		foreach (Transform child in obj.transform) {
			TraverseChildren(action, child.gameObject);
		}
	}

    public static void SetRenderer(GameObject obj, bool set)
    {
        TraverseChildren(delegate(GameObject o) {
            if (o.renderer != null)
                o.renderer.enabled = set;
        }, obj);
    }

    public static String Cap(this String s, int cap)
    {
        return s.Substring(0, Math.Min(cap, s.Length));
    }

	public static void Shuffle<T>(this IList<T> list)  
	{  
		System.Random rng = new System.Random();  
		int n = list.Count;  
		while (n > 1) {  
			n--;  
			int k = rng.Next(n + 1);  
			T value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		}  
	}
}
