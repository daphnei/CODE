using UnityEngine;
using System;
using System.Collections;

public class GameGUIText : MonoBehaviour {

	private TextMesh textMesh;
	private TextSize textSize;

    public Color startColor { get; set; }
	public FlyIn flyInAnimation { get; set; }
	public Action<GameGUIText> onClick;

	public float textMaxWidth = 4;
	public QuizView view;
	public String guiName;
	public float value;

	// Use this for initialization
	void Awake () {
		this.textMesh = this.GetComponentInChildren<TextMesh>();
		this.textSize = new TextSize(textMesh);
		this.flyInAnimation = this.GetComponent<FlyIn>();
        this.startColor = this.renderer ? this.renderer.material.color : Color.white;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		if (onClick != null)
			onClick(this);
		if (view != null)
			view.DetectClick(this);
	}

	public void SetText(string text) {
		this.textMesh.text = textSize.SplitText(text, textMaxWidth);
	}

    public void SetTextPure(string text) {
        this.textMesh.text = text;
    }
}
