using UnityEngine;
using System.Collections;

public class GameGUIText : MonoBehaviour {

	private TextMesh textMesh;

	// Use this for initialization
	void Start () {
		this.textMesh = this.GetComponent<TextMesh>(); 
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void SetText(string text) {
		this.textMesh.text = text;
	}
}
