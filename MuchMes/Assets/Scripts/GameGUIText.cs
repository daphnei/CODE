using UnityEngine;
using System;
using System.Collections;

public class GameGUIText : MonoBehaviour {

	private TextMesh textMesh;
	private Action<GameGUIText> onClick;

	// Use this for initialization
	void Start () {
		this.textMesh = this.GetComponentInChildren<TextMesh>(); 
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		if (onClick != null)
			onClick(this);
	}

	public void SetText(string text) {
		this.textMesh.text = text;
	}
}
