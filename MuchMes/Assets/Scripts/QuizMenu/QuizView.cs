using UnityEngine;
using System.Collections;
using System;

public class QuizView : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DetectClick(String name, int value) {
		this.Show();
	}

	public void Show() {
		SetVisibilityTraverse(true, this.gameObject);
	}

	public void Hide() {
		SetVisibilityTraverse(false, this.gameObject);
	}

	private void SetVisibilityTraverse(bool visibility, GameObject obj) {

		if (obj.renderer != null)
			obj.renderer.enabled = visibility;

		FlyIn animation = obj.GetComponent<FlyIn>();
		if (animation != null) {
			if (visibility)
				animation.TriggerIn();
			else
				animation.TriggerOut();
		}

		foreach (Transform child in obj.transform) {
			SetVisibilityTraverse(visibility, child.gameObject);
		}
	}
}
