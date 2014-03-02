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
}
