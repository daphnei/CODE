using UnityEngine;
using System.Collections;

public class LastScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TextMesh textMesh = GetComponent<TextMesh>();
		if (QuizController.prevScore != -1)
			textMesh.text = "SCORE: " + QuizController.prevScore.ToString();
		else
			textMesh.text = "";

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
