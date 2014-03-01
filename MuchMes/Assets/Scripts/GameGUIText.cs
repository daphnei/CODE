using UnityEngine;
using System;
using System.Collections;

public class GameGUIText : MonoBehaviour {

	private TextMesh textMesh;

	public FlyIn flyInAnimation { get; set; }
	public Action<GameGUIText> onClick;

	public QuizView view;
	public String name;
	public int value;

	// Use this for initialization
	void Awake () {
		this.textMesh = this.GetComponentInChildren<TextMesh>();
		this.flyInAnimation = this.GetComponent<FlyIn>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		if (onClick != null)
			onClick(this);
		if (view != null)
			view.DetectClick(name, value);
	}

	public void SetText(string text) {
		this.textMesh.text = text;
	}
}
